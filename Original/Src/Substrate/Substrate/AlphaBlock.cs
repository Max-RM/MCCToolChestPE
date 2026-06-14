using System;
using Substrate.Core;

namespace Substrate;

public class AlphaBlock : IDataBlock, IPropertyBlock, IActiveBlock, IBlock, ICopyable<AlphaBlock>
{
	private int _id;

	private int _data;

	private TileEntity _tileEntity;

	private TileTick _tileTick;

	public BlockInfo Info => BlockInfo.BlockTable[_id];

	public int ID
	{
		get
		{
			return _id;
		}
		set
		{
			UpdateTileEntity(_id, value);
			_id = value;
		}
	}

	public int Data
	{
		get
		{
			return _data;
		}
		set
		{
			_data = value;
		}
	}

	public int TileTickValue
	{
		get
		{
			if (_tileTick == null)
			{
				return 0;
			}
			return _tileTick.Ticks;
		}
		set
		{
			if (_tileTick == null)
			{
				CreateTileTick();
			}
			_tileTick.Ticks = value;
		}
	}

	public AlphaBlock(int id)
	{
		_id = id;
		UpdateTileEntity(0, id);
	}

	public AlphaBlock(int id, int data)
	{
		_id = id;
		_data = data;
		UpdateTileEntity(0, id);
	}

	public AlphaBlock(AlphaBlockCollection chunk, int lx, int ly, int lz)
	{
		_id = chunk.GetID(lx, ly, lz);
		_data = chunk.GetData(lx, ly, lz);
		TileEntity tileEntity = chunk.GetTileEntity(lx, ly, lz);
		if (tileEntity != null)
		{
			_tileEntity = tileEntity.Copy();
		}
	}

	public TileEntity GetTileEntity()
	{
		return _tileEntity;
	}

	public void SetTileEntity(TileEntity te)
	{
		if (!(BlockInfo.BlockTable[_id] is BlockInfoEx blockInfoEx))
		{
			throw new InvalidOperationException("The current block type does not accept a Tile Entity");
		}
		if (te.GetType() != TileEntityFactory.Lookup(blockInfoEx.TileEntityName))
		{
			throw new ArgumentException("The current block type is not compatible with the given Tile Entity", "te");
		}
		_tileEntity = te;
	}

	public void CreateTileEntity()
	{
		if (!(BlockInfo.BlockTable[_id] is BlockInfoEx blockInfoEx))
		{
			throw new InvalidOperationException("The given block is of a type that does not support TileEntities.");
		}
		TileEntity tileEntity = TileEntityFactory.Create(blockInfoEx.TileEntityName);
		if (tileEntity == null)
		{
			throw new UnknownTileEntityException("The TileEntity type '" + blockInfoEx.TileEntityName + "' has not been registered with the TileEntityFactory.");
		}
		_tileEntity = tileEntity;
	}

	public void ClearTileEntity()
	{
		_tileEntity = null;
	}

	public TileTick GetTileTick()
	{
		return _tileTick;
	}

	public void SetTileTick(TileTick tt)
	{
		_tileTick = tt;
	}

	public void CreateTileTick()
	{
		_tileTick = new TileTick
		{
			ID = _id
		};
	}

	public void ClearTileTick()
	{
		_tileTick = null;
	}

	public AlphaBlock Copy()
	{
		AlphaBlock alphaBlock = new AlphaBlock(_id, _data);
		if (_tileEntity != null)
		{
			alphaBlock._tileEntity = _tileEntity.Copy();
		}
		return alphaBlock;
	}

	private void UpdateTileEntity(int old, int value)
	{
		BlockInfoEx blockInfoEx = BlockInfo.BlockTable[old] as BlockInfoEx;
		BlockInfoEx blockInfoEx2 = BlockInfo.BlockTable[value] as BlockInfoEx;
		if (blockInfoEx != blockInfoEx2)
		{
			if (blockInfoEx != null)
			{
				_tileEntity = null;
			}
			if (blockInfoEx2 != null)
			{
				_tileEntity = TileEntityFactory.Create(blockInfoEx2.TileEntityName);
			}
		}
	}
}
