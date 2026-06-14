using System;
using System.Collections;
using System.Collections.Generic;
using Substrate.Core;

namespace Substrate;

public class RegionChunkManager : IChunkManager, IChunkContainer, IEnumerable<ChunkRef>, IEnumerable
{
	private class Enumerator : IEnumerator<ChunkRef>, IDisposable, IEnumerator
	{
		private RegionChunkManager _cm;

		private IEnumerator<IRegion> _enum;

		private IRegion _region;

		private ChunkRef _chunk;

		private int _x;

		private int _z = -1;

		object IEnumerator.Current => Current;

		ChunkRef IEnumerator<ChunkRef>.Current => Current;

		public ChunkRef Current
		{
			get
			{
				if (_x >= 32)
				{
					throw new InvalidOperationException();
				}
				return _chunk;
			}
		}

		public Enumerator(RegionChunkManager cm)
		{
			_cm = cm;
			_enum = _cm.RegionManager.GetEnumerator();
			_enum.MoveNext();
			_region = _enum.Current;
		}

		public virtual bool MoveNext()
		{
			if (_enum == null)
			{
				return MoveNextInRegion();
			}
			do
			{
				if (_x >= 32)
				{
					if (!_enum.MoveNext())
					{
						return false;
					}
					_x = 0;
					_z = -1;
					_region = _enum.Current;
				}
			}
			while (!MoveNextInRegion());
			_chunk = _region.GetChunkRef(_x, _z);
			return true;
		}

		protected bool MoveNextInRegion()
		{
			while (_x < 32)
			{
				_z++;
				while (_z < 32)
				{
					if (_region.ChunkExists(_x, _z))
					{
						goto end_IL_0058;
					}
					_z++;
				}
				_z = -1;
				_x++;
				continue;
				end_IL_0058:
				break;
			}
			return _x < 32;
		}

		public void Reset()
		{
			if (_enum != null)
			{
				_enum.Reset();
				_enum.MoveNext();
				_region = _enum.Current;
			}
			_x = 0;
			_z = -1;
		}

		void IDisposable.Dispose()
		{
		}
	}

	private const int REGION_XLEN = 32;

	private const int REGION_ZLEN = 32;

	private const int REGION_XLOG = 5;

	private const int REGION_ZLOG = 5;

	private const int REGION_XMASK = 31;

	private const int REGION_ZMASK = 31;

	private IRegionManager _regionMan;

	private ChunkCache _cache;

	public IRegionManager RegionManager => _regionMan;

	public bool CanDelegateCoordinates => true;

	public RegionChunkManager(IRegionManager rm, ChunkCache cache)
	{
		_regionMan = rm;
		_cache = cache;
	}

	public RegionChunkManager(RegionChunkManager cm)
	{
		_regionMan = cm._regionMan;
		_cache = cm._cache;
	}

	public int ChunkGlobalX(int cx)
	{
		return cx;
	}

	public int ChunkGlobalZ(int cz)
	{
		return cz;
	}

	public int ChunkLocalX(int cx)
	{
		return cx & 0x1F;
	}

	public int ChunkLocalZ(int cz)
	{
		return cz & 0x1F;
	}

	public IChunk GetChunk(int cx, int cz)
	{
		return GetRegion(cx, cz)?.GetChunk(cx & 0x1F, cz & 0x1F);
	}

	public ChunkRef GetChunkRef(int cx, int cz)
	{
		return GetRegion(cx, cz)?.GetChunkRef(cx & 0x1F, cz & 0x1F);
	}

	public bool ChunkExists(int cx, int cz)
	{
		return GetRegion(cx, cz)?.ChunkExists(cx & 0x1F, cz & 0x1F) ?? false;
	}

	public ChunkRef CreateChunk(int cx, int cz)
	{
		IRegion region = GetRegion(cx, cz);
		if (region == null)
		{
			int rx = cx >> 5;
			int rz = cz >> 5;
			region = _regionMan.CreateRegion(rx, rz);
		}
		return region.CreateChunk(cx & 0x1F, cz & 0x1F);
	}

	public ChunkRef SetChunk(int cx, int cz, IChunk chunk)
	{
		IRegion region = GetRegion(cx, cz);
		if (region == null)
		{
			int rx = cx >> 5;
			int rz = cz >> 5;
			region = _regionMan.CreateRegion(rx, rz);
		}
		chunk.SetLocation(cx, cz);
		region.SaveChunk(chunk);
		return region.GetChunkRef(cx & 0x1F, cz & 0x1F);
	}

	public int Save()
	{
		_cache.SyncDirty();
		int num = 0;
		IEnumerator<ChunkRef> dirtyEnumerator = _cache.GetDirtyEnumerator();
		while (dirtyEnumerator.MoveNext())
		{
			ChunkRef current = dirtyEnumerator.Current;
			IRegion region = GetRegion(current.X, current.Z);
			if (region != null)
			{
				current.Save(region.GetChunkOutStream(current.LocalX, current.LocalZ));
				num++;
			}
		}
		_cache.ClearDirty();
		return num;
	}

	public bool SaveChunk(IChunk chunk)
	{
		return GetRegion(chunk.X, chunk.Z)?.SaveChunk(chunk) ?? false;
	}

	public bool DeleteChunk(int cx, int cz)
	{
		IRegion region = GetRegion(cx, cz);
		if (region == null)
		{
			return false;
		}
		if (!region.DeleteChunk(cx & 0x1F, cz & 0x1F))
		{
			return false;
		}
		if (region.ChunkCount() == 0)
		{
			_regionMan.DeleteRegion(region.X, region.Z);
		}
		return true;
	}

	public ChunkRef CopyChunk(int src_cx, int src_cz, int dst_cx, int dst_cz)
	{
		IRegion region = GetRegion(src_cx, src_cz);
		if (region == null)
		{
			return null;
		}
		IRegion region2 = GetRegion(dst_cx, dst_cz);
		if (region2 == null)
		{
			int rx = dst_cx >> 5;
			int rz = dst_cz >> 5;
			region2 = _regionMan.CreateRegion(rx, rz);
		}
		IChunk chunk = region.GetChunk(src_cx & 0x1F, src_cz & 0x1F);
		chunk.SetLocation(dst_cx, dst_cz);
		region2.SaveChunk(chunk);
		return region2.GetChunkRef(dst_cx & 0x1F, dst_cz & 0x1F);
	}

	public void RelightDirtyChunks()
	{
		Dictionary<ChunkKey, ChunkRef> dictionary = new Dictionary<ChunkKey, ChunkRef>();
		_cache.SyncDirty();
		IEnumerator<ChunkRef> dirtyEnumerator = _cache.GetDirtyEnumerator();
		while (dirtyEnumerator.MoveNext())
		{
			ChunkKey key = new ChunkKey(dirtyEnumerator.Current.X, dirtyEnumerator.Current.Z);
			dictionary[key] = dirtyEnumerator.Current;
		}
		foreach (ChunkRef value in dictionary.Values)
		{
			value.Blocks.ResetBlockLight();
			value.Blocks.ResetSkyLight();
		}
		foreach (ChunkRef value2 in dictionary.Values)
		{
			value2.Blocks.RebuildBlockLight();
			value2.Blocks.RebuildSkyLight();
		}
		foreach (ChunkRef value3 in dictionary.Values)
		{
			if (!dictionary.ContainsKey(new ChunkKey(value3.X, value3.Z - 1)))
			{
				ChunkRef eastNeighbor = value3.GetEastNeighbor();
				value3.Blocks.StitchBlockLight(eastNeighbor.Blocks, BlockCollectionEdge.EAST);
				value3.Blocks.StitchSkyLight(eastNeighbor.Blocks, BlockCollectionEdge.EAST);
			}
			if (!dictionary.ContainsKey(new ChunkKey(value3.X, value3.Z + 1)))
			{
				ChunkRef westNeighbor = value3.GetWestNeighbor();
				value3.Blocks.StitchBlockLight(westNeighbor.Blocks, BlockCollectionEdge.WEST);
				value3.Blocks.StitchSkyLight(westNeighbor.Blocks, BlockCollectionEdge.WEST);
			}
			if (!dictionary.ContainsKey(new ChunkKey(value3.X - 1, value3.Z)))
			{
				ChunkRef northNeighbor = value3.GetNorthNeighbor();
				value3.Blocks.StitchBlockLight(northNeighbor.Blocks, BlockCollectionEdge.NORTH);
				value3.Blocks.StitchSkyLight(northNeighbor.Blocks, BlockCollectionEdge.NORTH);
			}
			if (!dictionary.ContainsKey(new ChunkKey(value3.X + 1, value3.Z)))
			{
				ChunkRef southNeighbor = value3.GetSouthNeighbor();
				value3.Blocks.StitchBlockLight(southNeighbor.Blocks, BlockCollectionEdge.SOUTH);
				value3.Blocks.StitchSkyLight(southNeighbor.Blocks, BlockCollectionEdge.SOUTH);
			}
		}
	}

	public int GetChunkTimestamp(int cx, int cz)
	{
		return GetRegion(cx, cz)?.GetChunkTimestamp(cx & 0x1F, cz & 0x1F) ?? 0;
	}

	public void SetChunkTimestamp(int cx, int cz, int timestamp)
	{
		GetRegion(cx, cz)?.SetChunkTimestamp(cx & 0x1F, cz & 0x1F, timestamp);
	}

	private ChunkRef GetChunkRefInRegion(IRegion r, int lcx, int lcz)
	{
		int cx = r.X * 32 + lcx;
		int cz = r.Z * 32 + lcz;
		return GetChunkRef(cx, cz);
	}

	private IRegion GetRegion(int cx, int cz)
	{
		cx >>= 5;
		cz >>= 5;
		return _regionMan.GetRegion(cx, cz);
	}

	public IEnumerator<ChunkRef> GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this);
	}
}
