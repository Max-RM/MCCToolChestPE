using System.IO;
using Substrate.Core;

namespace Substrate;

public class ChunkRef : IChunk
{
	private IChunkContainer _container;

	private IChunk _chunk;

	private AlphaBlockCollection _blocks;

	private EntityCollection _entities;

	private int _cx;

	private int _cz;

	private bool _dirty;

	public int X => _container.ChunkGlobalX(_cx);

	public int Z => _container.ChunkGlobalZ(_cz);

	public int LocalX => _container.ChunkLocalX(_cx);

	public int LocalZ => _container.ChunkLocalZ(_cz);

	public AlphaBlockCollection Blocks
	{
		get
		{
			if (_blocks == null)
			{
				GetChunk();
			}
			return _blocks;
		}
	}

	public EntityCollection Entities
	{
		get
		{
			if (_entities == null)
			{
				GetChunk();
			}
			return _entities;
		}
	}

	public bool IsDirty
	{
		get
		{
			if (!_dirty && (_blocks == null || !_blocks.IsDirty))
			{
				if (_entities != null)
				{
					return _entities.IsDirty;
				}
				return false;
			}
			return true;
		}
		set
		{
			_dirty = value;
			if (_blocks != null)
			{
				_blocks.IsDirty = false;
			}
			if (_entities != null)
			{
				_entities.IsDirty = false;
			}
		}
	}

	public bool IsTerrainPopulated
	{
		get
		{
			return GetChunk().IsTerrainPopulated;
		}
		set
		{
			if (GetChunk().IsTerrainPopulated != value)
			{
				GetChunk().IsTerrainPopulated = value;
				_dirty = true;
			}
		}
	}

	private ChunkRef()
	{
	}

	public static ChunkRef Create(IChunkContainer container, int cx, int cz)
	{
		if (!container.ChunkExists(cx, cz))
		{
			return null;
		}
		ChunkRef chunkRef = new ChunkRef();
		chunkRef._container = container;
		chunkRef._cx = cx;
		chunkRef._cz = cz;
		return chunkRef;
	}

	public bool Save(Stream outStream)
	{
		if (IsDirty)
		{
			if (GetChunk().Save(outStream))
			{
				IsDirty = false;
				return true;
			}
			return false;
		}
		return true;
	}

	public void SetLocation(int x, int z)
	{
		int cx = LocalX + (x - X);
		int cz = LocalZ + (z - Z);
		ChunkRef chunkRef = _container.SetChunk(cx, cz, GetChunk());
		_container = chunkRef._container;
		_cx = chunkRef._cx;
		_cz = chunkRef._cz;
	}

	public ChunkRef GetNorthNeighbor()
	{
		return _container.GetChunkRef(_cx - 1, _cz);
	}

	public ChunkRef GetSouthNeighbor()
	{
		return _container.GetChunkRef(_cx + 1, _cz);
	}

	public ChunkRef GetEastNeighbor()
	{
		return _container.GetChunkRef(_cx, _cz - 1);
	}

	public ChunkRef GetWestNeighbor()
	{
		return _container.GetChunkRef(_cx, _cz + 1);
	}

	public IChunk GetChunkRef()
	{
		IChunk chunk = GetChunk();
		_chunk = null;
		_dirty = false;
		return chunk;
	}

	public void SetChunkRef(IChunk chunk)
	{
		_chunk = chunk;
		_chunk.SetLocation(X, Z);
		_dirty = true;
	}

	private IChunk GetChunk()
	{
		if (_chunk == null)
		{
			_chunk = _container.GetChunk(_cx, _cz);
			if (_chunk != null)
			{
				_blocks = _chunk.Blocks;
				_entities = _chunk.Entities;
				_blocks.ResolveNeighbor += ResolveNeighborHandler;
				_blocks.TranslateCoordinates += TranslateCoordinatesHandler;
			}
		}
		return _chunk;
	}

	private AlphaBlockCollection ResolveNeighborHandler(int relx, int rely, int relz)
	{
		return _container.GetChunkRef(_cx + relx, _cz + relz)?.Blocks;
	}

	private BlockKey TranslateCoordinatesHandler(int lx, int ly, int lz)
	{
		int x = X * _blocks.XDim + lx;
		int z = Z * _blocks.ZDim + lz;
		return new BlockKey(x, ly, z);
	}
}
