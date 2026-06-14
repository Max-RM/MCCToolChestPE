using System;
using Substrate.Core;

namespace Substrate;

public abstract class BlockManager : IVersion10BlockManager, IActiveBlockCollection, IBlockManager, IAlphaBlockCollection, IDataBlockCollection, ILitBlockCollection, IPropertyBlockCollection, IBlockCollection
{
	public const int MIN_X = -32000000;

	public const int MAX_X = 32000000;

	public const int MIN_Y = 0;

	public const int MAX_Y = 256;

	public const int MIN_Z = -32000000;

	public const int MAX_Z = 32000000;

	protected int chunkXDim;

	protected int chunkYDim;

	protected int chunkZDim;

	protected int chunkXMask;

	protected int chunkYMask;

	protected int chunkZMask;

	protected int chunkXLog;

	protected int chunkYLog;

	protected int chunkZLog;

	protected IChunkManager chunkMan;

	protected ChunkRef cache;

	private bool _autoLight = true;

	private bool _autoFluid;

	private bool _autoTileTick;

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
			return _autoTileTick;
		}
		set
		{
			_autoTileTick = value;
		}
	}

	public BlockManager(IChunkManager cm)
	{
		chunkMan = cm;
	}

	public AlphaBlock GetBlock(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null || !Check(x, y, z))
		{
			return null;
		}
		return cache.Blocks.GetBlock(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public AlphaBlockRef GetBlockRef(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null || !Check(x, y, z))
		{
			return default(AlphaBlockRef);
		}
		return cache.Blocks.GetBlockRef(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public void SetBlock(int x, int y, int z, AlphaBlock block)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.SetBlock(x & chunkXMask, y & chunkYMask, z & chunkZMask, block);
		}
	}

	public ChunkRef GetChunk(int x, int y, int z)
	{
		x >>= chunkXLog;
		z >>= chunkZLog;
		return chunkMan.GetChunkRef(x, z);
	}

	protected int Log2(int x)
	{
		int num = 0;
		while (x > 1)
		{
			x >>= 1;
			num++;
		}
		return num;
	}

	protected virtual bool Check(int x, int y, int z)
	{
		if (x >= -32000000 && x < 32000000 && y >= 0 && y < 256 && z >= -32000000)
		{
			return z < 32000000;
		}
		return false;
	}

	IBlock IBlockCollection.GetBlock(int x, int y, int z)
	{
		return GetBlock(x, y, z);
	}

	IBlock IBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, IBlock block)
	{
		cache.Blocks.SetBlock(x, y, z, block);
	}

	public BlockInfo GetInfo(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null || !Check(x, y, z))
		{
			return null;
		}
		return cache.Blocks.GetInfo(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public int GetID(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null)
		{
			return 0;
		}
		return cache.Blocks.GetID(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public void SetID(int x, int y, int z, int id)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			bool autoLight = cache.Blocks.AutoLight;
			bool autoFluid = cache.Blocks.AutoFluid;
			bool autoTileTick = cache.Blocks.AutoTileTick;
			cache.Blocks.AutoLight = _autoLight;
			cache.Blocks.AutoFluid = _autoFluid;
			cache.Blocks.AutoTileTick = _autoTileTick;
			cache.Blocks.SetID(x & chunkXMask, y & chunkYMask, z & chunkZMask, id);
			cache.Blocks.AutoFluid = autoFluid;
			cache.Blocks.AutoLight = autoLight;
			cache.Blocks.AutoTileTick = autoTileTick;
		}
	}

	IDataBlock IDataBlockCollection.GetBlock(int x, int y, int z)
	{
		return GetBlock(x, y, z);
	}

	IDataBlock IDataBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, IDataBlock block)
	{
		cache.Blocks.SetBlock(x, y, z, block);
	}

	public int GetData(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null)
		{
			return 0;
		}
		return cache.Blocks.GetData(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public void SetData(int x, int y, int z, int data)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.SetData(x & chunkXMask, y & chunkYMask, z & chunkZMask, data);
		}
	}

	ILitBlock ILitBlockCollection.GetBlock(int x, int y, int z)
	{
		throw new NotImplementedException();
	}

	ILitBlock ILitBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, ILitBlock block)
	{
		cache.Blocks.SetBlock(x, y, z, block);
	}

	public int GetBlockLight(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null)
		{
			return 0;
		}
		return cache.Blocks.GetBlockLight(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public int GetSkyLight(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null)
		{
			return 0;
		}
		return cache.Blocks.GetSkyLight(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public void SetBlockLight(int x, int y, int z, int light)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.SetBlockLight(x & chunkXMask, y & chunkYMask, z & chunkZMask, light);
		}
	}

	public void SetSkyLight(int x, int y, int z, int light)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.SetSkyLight(x & chunkXMask, y & chunkYMask, z & chunkZMask, light);
		}
	}

	public int GetHeight(int x, int z)
	{
		cache = GetChunk(x, 0, z);
		if (cache == null || !Check(x, 0, z))
		{
			return 0;
		}
		return cache.Blocks.GetHeight(x & chunkXMask, z & chunkZMask);
	}

	public void SetHeight(int x, int z, int height)
	{
		cache = GetChunk(x, 0, z);
		if (cache != null && Check(x, 0, z))
		{
			cache.Blocks.SetHeight(x & chunkXMask, z & chunkZMask, height);
		}
	}

	public void UpdateBlockLight(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.UpdateBlockLight(x & chunkXMask, y & chunkYMask, z & chunkZMask);
		}
	}

	public void UpdateSkyLight(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.UpdateBlockLight(x & chunkXMask, y & chunkYMask, z & chunkZMask);
		}
	}

	IPropertyBlock IPropertyBlockCollection.GetBlock(int x, int y, int z)
	{
		return GetBlock(x, y, z);
	}

	IPropertyBlock IPropertyBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, IPropertyBlock block)
	{
		cache.Blocks.SetBlock(x, y, z, block);
	}

	public TileEntity GetTileEntity(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null || !Check(x, y, z))
		{
			return null;
		}
		return cache.Blocks.GetTileEntity(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public void SetTileEntity(int x, int y, int z, TileEntity te)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.SetTileEntity(x & chunkXMask, y & chunkYMask, z & chunkZMask, te);
		}
	}

	public void CreateTileEntity(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.CreateTileEntity(x & chunkXMask, y & chunkYMask, z & chunkZMask);
		}
	}

	public void ClearTileEntity(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.ClearTileEntity(x & chunkXMask, y & chunkYMask, z & chunkZMask);
		}
	}

	IActiveBlock IActiveBlockCollection.GetBlock(int x, int y, int z)
	{
		return GetBlock(x, y, z);
	}

	IActiveBlock IActiveBlockCollection.GetBlockRef(int x, int y, int z)
	{
		return GetBlockRef(x, y, z);
	}

	public void SetBlock(int x, int y, int z, IActiveBlock block)
	{
		cache.Blocks.SetBlock(x, y, z, block);
	}

	public int GetTileTickValue(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null || !Check(x, y, z))
		{
			return 0;
		}
		return cache.Blocks.GetTileTickValue(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public void SetTileTickValue(int x, int y, int z, int tickValue)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.SetTileTickValue(x & chunkXMask, y & chunkYMask, z & chunkZMask, tickValue);
		}
	}

	public TileTick GetTileTick(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache == null || !Check(x, y, z))
		{
			return null;
		}
		return cache.Blocks.GetTileTick(x & chunkXMask, y & chunkYMask, z & chunkZMask);
	}

	public void SetTileTick(int x, int y, int z, TileTick te)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.SetTileTick(x & chunkXMask, y & chunkYMask, z & chunkZMask, te);
		}
	}

	public void CreateTileTick(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.CreateTileTick(x & chunkXMask, y & chunkYMask, z & chunkZMask);
		}
	}

	public void ClearTileTick(int x, int y, int z)
	{
		cache = GetChunk(x, y, z);
		if (cache != null && Check(x, y, z))
		{
			cache.Blocks.ClearTileTick(x & chunkXMask, y & chunkYMask, z & chunkZMask);
		}
	}
}
