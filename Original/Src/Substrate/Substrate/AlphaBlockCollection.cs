using System;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class AlphaBlockCollection : IBoundedAlphaBlockCollection, IBoundedDataBlockCollection, IBoundedLitBlockCollection, IBoundedPropertyBlockCollection, IBoundedActiveBlockCollection, IBoundedBlockCollection
{
	public delegate AlphaBlockCollection NeighborLookupHandler(int relx, int rely, int relz);

	private readonly int _xdim;

	private readonly int _ydim;

	private readonly int _zdim;

	private IDataArray3 _blocks;

	private IDataArray3 _data;

	private IDataArray3 _blockLight;

	private IDataArray3 _skyLight;

	private IDataArray2 _heightMap;

	private TagNodeList _tileEntities;

	private TagNodeList _tileTicks;

	private BlockLight _lightManager;

	private BlockFluid _fluidManager;

	private BlockTileEntities _tileEntityManager;

	private BlockTileTicks _tileTickManager;

	private bool _dirty;

	private bool _autoLight = true;

	private bool _autoFluid;

	private bool _autoTick;

	internal TagNodeList TileTicks => _tileTicks;

	public bool AutoLight
	{
		get
		{
			return _autoLight;
		}
		set
		{
			_autoLight = value;
		}
	}

	public bool AutoFluid
	{
		get
		{
			return _autoFluid;
		}
		set
		{
			_autoFluid = value;
		}
	}

	public bool AutoTileTick
	{
		get
		{
			return _autoTick;
		}
		set
		{
			_autoTick = value;
		}
	}

	public bool IsDirty
	{
		get
		{
			return _dirty;
		}
		set
		{
			_dirty = value;
		}
	}

	public int XDim => _xdim;

	public int YDim => _ydim;

	public int ZDim => _zdim;

	public event NeighborLookupHandler ResolveNeighbor
	{
		add
		{
			_lightManager.ResolveNeighbor += (int relx, int rely, int relz) => value(relx, rely, relz);
			_fluidManager.ResolveNeighbor += (int relx, int rely, int relz) => value(relx, rely, relz);
		}
		remove
		{
			_lightManager = new BlockLight(this);
			_fluidManager = new BlockFluid(this);
		}
	}

	public event BlockCoordinateHandler TranslateCoordinates
	{
		add
		{
			_tileEntityManager.TranslateCoordinates += value;
		}
		remove
		{
			_tileEntityManager.TranslateCoordinates -= value;
		}
	}

	[Obsolete]
	public AlphaBlockCollection(int xdim, int ydim, int zdim)
	{
		_blocks = new XZYByteArray(xdim, ydim, zdim);
		_data = new XZYNibbleArray(xdim, ydim, zdim);
		_blockLight = new XZYNibbleArray(xdim, ydim, zdim);
		_skyLight = new XZYNibbleArray(xdim, ydim, zdim);
		_heightMap = new ZXByteArray(xdim, zdim);
		_tileEntities = new TagNodeList(TagType.TAG_COMPOUND);
		_tileTicks = new TagNodeList(TagType.TAG_COMPOUND);
		_xdim = xdim;
		_ydim = ydim;
		_zdim = zdim;
		Refresh();
	}

	public AlphaBlockCollection(IDataArray3 blocks, IDataArray3 data, IDataArray3 blockLight, IDataArray3 skyLight, IDataArray2 heightMap, TagNodeList tileEntities)
		: this(blocks, data, blockLight, skyLight, heightMap, tileEntities, null)
	{
	}

	public AlphaBlockCollection(IDataArray3 blocks, IDataArray3 data, IDataArray3 blockLight, IDataArray3 skyLight, IDataArray2 heightMap, TagNodeList tileEntities, TagNodeList tileTicks)
	{
		_blocks = blocks;
		_data = data;
		_blockLight = blockLight;
		_skyLight = skyLight;
		_heightMap = heightMap;
		_tileEntities = tileEntities;
		_tileTicks = tileTicks;
		if (_tileTicks == null)
		{
			_tileTicks = new TagNodeList(TagType.TAG_COMPOUND);
		}
		_xdim = _blocks.XDim;
		_ydim = _blocks.YDim;
		_zdim = _blocks.ZDim;
		Refresh();
	}

	public void Refresh()
	{
		_lightManager = new BlockLight(this);
		_fluidManager = new BlockFluid(this);
		_tileEntityManager = new BlockTileEntities(_blocks, _tileEntities);
		_tileTickManager = new BlockTileTicks(_blocks, _tileTicks);
	}

	public AlphaBlock GetBlock(int x, int y, int z)
	{
		return new AlphaBlock(this, x, y, z);
	}

	public AlphaBlockRef GetBlockRef(int x, int y, int z)
	{
		return new AlphaBlockRef(this, _blocks.GetIndex(x, y, z));
	}

	public void SetBlock(int x, int y, int z, AlphaBlock block)
	{
		SetID(x, y, z, block.ID);
		SetData(x, y, z, block.Data);
		TileEntity tileEntity = block.GetTileEntity();
		if (tileEntity != null)
		{
			SetTileEntity(x, y, z, tileEntity.Copy());
		}
		TileTick tileTick = block.GetTileTick();
		if (tileTick != null)
		{
			SetTileTick(x, y, z, tileTick.Copy());
		}
	}

	IBlock IBoundedBlockCollection.GetBlock(int x, int y, int z)
	{
		return GetBlock(x, y, z);
	}

	IBlock IBoundedBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, IBlock block)
	{
		SetID(x, y, z, block.ID);
	}

	public BlockInfo GetInfo(int x, int y, int z)
	{
		return BlockInfo.BlockTable[_blocks[x, y, z]];
	}

	internal BlockInfo GetInfo(int index)
	{
		return BlockInfo.BlockTable[_blocks[index]];
	}

	public int GetID(int x, int y, int z)
	{
		return _blocks[x, y, z];
	}

	internal int GetID(int index)
	{
		return _blocks[index];
	}

	public void SetID(int x, int y, int z, int id)
	{
		int num = _blocks[x, y, z];
		if (num == id)
		{
			return;
		}
		_blocks[x, y, z] = id;
		BlockInfo blockInfo = BlockInfo.BlockTable[num];
		BlockInfo blockInfo2 = BlockInfo.BlockTable[id];
		BlockInfoEx blockInfoEx = blockInfo as BlockInfoEx;
		BlockInfoEx blockInfoEx2 = blockInfo2 as BlockInfoEx;
		if (blockInfoEx != blockInfoEx2)
		{
			if (blockInfoEx != null || !blockInfo.Registered)
			{
				ClearTileEntity(x, y, z);
			}
			if (blockInfoEx2 != null)
			{
				CreateTileEntity(x, y, z);
			}
		}
		if (_autoLight)
		{
			if (blockInfo.ObscuresLight != blockInfo2.ObscuresLight)
			{
				_lightManager.UpdateHeightMap(x, y, z);
			}
			if (blockInfo.Luminance != blockInfo2.Luminance || blockInfo.Opacity != blockInfo2.Opacity || blockInfo.TransmitsLight != blockInfo2.TransmitsLight)
			{
				UpdateBlockLight(x, y, z);
			}
			if (blockInfo.Opacity != blockInfo2.Opacity || blockInfo.TransmitsLight != blockInfo2.TransmitsLight)
			{
				UpdateSkyLight(x, y, z);
			}
		}
		if (_autoFluid && (blockInfo.State == BlockState.FLUID || blockInfo2.State == BlockState.FLUID))
		{
			UpdateFluid(x, y, z);
		}
		if (_autoTick && blockInfo.ID != blockInfo2.ID)
		{
			ClearTileTick(x, y, z);
			if (blockInfo2.Tick > 0)
			{
				SetTileTickValue(x, y, z, blockInfo2.Tick);
			}
		}
		_dirty = true;
	}

	internal void SetID(int index, int id)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		SetID(x, y, z, id);
	}

	public int CountByID(int id)
	{
		int num = 0;
		for (int i = 0; i < _blocks.Length; i++)
		{
			if (_blocks[i] == id)
			{
				num++;
			}
		}
		return num;
	}

	IDataBlock IBoundedDataBlockCollection.GetBlock(int x, int y, int z)
	{
		return GetBlock(x, y, z);
	}

	IDataBlock IBoundedDataBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, IDataBlock block)
	{
		SetID(x, y, z, block.ID);
		SetData(x, y, z, block.Data);
	}

	public int GetData(int x, int y, int z)
	{
		return _data[x, y, z];
	}

	internal int GetData(int index)
	{
		return _data[index];
	}

	public void SetData(int x, int y, int z, int data)
	{
		if (_data[x, y, z] != data)
		{
			_data[x, y, z] = (byte)data;
			_dirty = true;
		}
	}

	internal void SetData(int index, int data)
	{
		if (_data[index] != data)
		{
			_data[index] = (byte)data;
			_dirty = true;
		}
	}

	public int CountByData(int id, int data)
	{
		int num = 0;
		for (int i = 0; i < _blocks.Length; i++)
		{
			if (_blocks[i] == id && _data[i] == data)
			{
				num++;
			}
		}
		return num;
	}

	ILitBlock IBoundedLitBlockCollection.GetBlock(int x, int y, int z)
	{
		throw new NotImplementedException();
	}

	ILitBlock IBoundedLitBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, ILitBlock block)
	{
		SetID(x, y, z, block.ID);
		SetBlockLight(x, y, z, block.BlockLight);
		SetSkyLight(x, y, z, block.SkyLight);
	}

	public int GetBlockLight(int x, int y, int z)
	{
		return _blockLight[x, y, z];
	}

	internal int GetBlockLight(int index)
	{
		return _blockLight[index];
	}

	public int GetSkyLight(int x, int y, int z)
	{
		return _skyLight[x, y, z];
	}

	internal int GetSkyLight(int index)
	{
		return _skyLight[index];
	}

	public void SetBlockLight(int x, int y, int z, int light)
	{
		if (_blockLight[x, y, z] != light)
		{
			_blockLight[x, y, z] = (byte)light;
			_dirty = true;
		}
	}

	internal void SetBlockLight(int index, int light)
	{
		if (_blockLight[index] != light)
		{
			_blockLight[index] = (byte)light;
			_dirty = true;
		}
	}

	public void SetSkyLight(int x, int y, int z, int light)
	{
		if (_skyLight[x, y, z] != light)
		{
			_skyLight[x, y, z] = (byte)light;
			_dirty = true;
		}
	}

	internal void SetSkyLight(int index, int light)
	{
		if (_skyLight[index] != light)
		{
			_skyLight[index] = (byte)light;
			_dirty = true;
		}
	}

	public int GetHeight(int x, int z)
	{
		return _heightMap[x, z];
	}

	public void SetHeight(int x, int z, int height)
	{
		_heightMap[x, z] = (byte)height;
	}

	public void UpdateBlockLight(int x, int y, int z)
	{
		_lightManager.UpdateBlockLight(x, y, z);
		_dirty = true;
	}

	public void UpdateSkyLight(int x, int y, int z)
	{
		_lightManager.UpdateBlockSkyLight(x, y, z);
		_dirty = true;
	}

	public void ResetBlockLight()
	{
		_blockLight.Clear();
		_dirty = true;
	}

	public void ResetSkyLight()
	{
		_skyLight.Clear();
		_dirty = true;
	}

	public void RebuildBlockLight()
	{
		_lightManager.RebuildBlockLight();
		_dirty = true;
	}

	public void RebuildSkyLight()
	{
		_lightManager.RebuildBlockSkyLight();
		_dirty = true;
	}

	public void RebuildHeightMap()
	{
		_lightManager.RebuildHeightMap();
		_dirty = true;
	}

	public void StitchBlockLight()
	{
		_lightManager.StitchBlockLight();
		_dirty = true;
	}

	public void StitchSkyLight()
	{
		_lightManager.StitchBlockSkyLight();
		_dirty = true;
	}

	public void StitchBlockLight(IBoundedLitBlockCollection blockset, BlockCollectionEdge edge)
	{
		_lightManager.StitchBlockLight(blockset, edge);
		_dirty = true;
	}

	public void StitchSkyLight(IBoundedLitBlockCollection blockset, BlockCollectionEdge edge)
	{
		_lightManager.StitchBlockSkyLight(blockset, edge);
		_dirty = true;
	}

	IPropertyBlock IBoundedPropertyBlockCollection.GetBlock(int x, int y, int z)
	{
		return GetBlock(x, y, z);
	}

	IPropertyBlock IBoundedPropertyBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, IPropertyBlock block)
	{
		SetID(x, y, z, block.ID);
		SetTileEntity(x, y, z, block.GetTileEntity().Copy());
	}

	public TileEntity GetTileEntity(int x, int y, int z)
	{
		return _tileEntityManager.GetTileEntity(x, y, z);
	}

	internal TileEntity GetTileEntity(int index)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		return _tileEntityManager.GetTileEntity(x, y, z);
	}

	public void SetTileEntity(int x, int y, int z, TileEntity te)
	{
		_tileEntityManager.SetTileEntity(x, y, z, te);
		_dirty = true;
	}

	internal void SetTileEntity(int index, TileEntity te)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		_tileEntityManager.SetTileEntity(x, y, z, te);
		_dirty = true;
	}

	public void CreateTileEntity(int x, int y, int z)
	{
		_tileEntityManager.CreateTileEntity(x, y, z);
		_dirty = true;
	}

	internal void CreateTileEntity(int index)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		_tileEntityManager.CreateTileEntity(x, y, z);
		_dirty = true;
	}

	public void ClearTileEntity(int x, int y, int z)
	{
		_tileEntityManager.ClearTileEntity(x, y, z);
		_dirty = true;
	}

	internal void ClearTileEntity(int index)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		_tileEntityManager.ClearTileEntity(x, y, z);
		_dirty = true;
	}

	IActiveBlock IBoundedActiveBlockCollection.GetBlock(int x, int y, int z)
	{
		return GetBlock(x, y, z);
	}

	IActiveBlock IBoundedActiveBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, IActiveBlock block)
	{
		SetID(x, y, z, block.ID);
		SetTileTick(x, y, z, block.GetTileTick().Copy());
	}

	public int GetTileTickValue(int x, int y, int z)
	{
		return _tileTickManager.GetTileTickValue(x, y, z);
	}

	internal int GetTileTickValue(int index)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		return _tileTickManager.GetTileTickValue(x, y, z);
	}

	public void SetTileTickValue(int x, int y, int z, int tickValue)
	{
		_tileTickManager.SetTileTickValue(x, y, z, tickValue);
		_dirty = true;
	}

	internal void SetTileTickValue(int index, int tickValue)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		_tileTickManager.SetTileTickValue(x, y, z, tickValue);
		_dirty = true;
	}

	public TileTick GetTileTick(int x, int y, int z)
	{
		return _tileTickManager.GetTileTick(x, y, z);
	}

	internal TileTick GetTileTick(int index)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		return _tileTickManager.GetTileTick(x, y, z);
	}

	public void SetTileTick(int x, int y, int z, TileTick tt)
	{
		_tileTickManager.SetTileTick(x, y, z, tt);
		_dirty = true;
	}

	internal void SetTileTick(int index, TileTick tt)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		_tileTickManager.SetTileTick(x, y, z, tt);
		_dirty = true;
	}

	public void CreateTileTick(int x, int y, int z)
	{
		_tileTickManager.CreateTileTick(x, y, z);
		_dirty = true;
	}

	internal void CreateTileTick(int index)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		_tileTickManager.CreateTileTick(x, y, z);
		_dirty = true;
	}

	public void ClearTileTick(int x, int y, int z)
	{
		_tileTickManager.ClearTileTick(x, y, z);
		_dirty = true;
	}

	internal void ClearTileTick(int index)
	{
		_blocks.GetMultiIndex(index, out var x, out var y, out var z);
		_tileTickManager.ClearTileTick(x, y, z);
		_dirty = true;
	}

	public void ResetFluid()
	{
		_fluidManager.ResetWater(_blocks, _data);
		_fluidManager.ResetLava(_blocks, _data);
		_dirty = true;
	}

	public void RebuildFluid()
	{
		_fluidManager.RebuildWater();
		_fluidManager.RebuildLava();
		_dirty = true;
	}

	public void UpdateFluid(int x, int y, int z)
	{
		bool autoFluid = _autoFluid;
		_autoFluid = false;
		int num = _blocks[x, y, z];
		if (num == BlockInfo.Water.ID || num == BlockInfo.StationaryWater.ID)
		{
			_fluidManager.UpdateWater(x, y, z);
			_dirty = true;
		}
		else if (num == BlockInfo.Lava.ID || num == BlockInfo.StationaryLava.ID)
		{
			_fluidManager.UpdateLava(x, y, z);
			_dirty = true;
		}
		_autoFluid = autoFluid;
	}
}
