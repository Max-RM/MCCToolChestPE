using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Substrate.Nbt;

namespace Substrate.Core;

public abstract class Region : IDisposable, IRegion, IChunkContainer
{
	protected const int XDIM = 32;

	protected const int ZDIM = 32;

	protected const int XMASK = 31;

	protected const int ZMASK = 31;

	protected const int XLOG = 5;

	protected const int ZLOG = 5;

	protected int _rx;

	protected int _rz;

	private bool _disposed;

	protected RegionManager _regionMan;

	private static Regex _namePattern = new Regex("r\\.(-?[0-9]+)\\.(-?[0-9]+)\\.mca$");

	private WeakReference _regionFile;

	protected ChunkCache _cache;

	public int X => _rx;

	public int Z => _rz;

	public int XDim => 32;

	public int ZDim => 32;

	public bool CanDelegateCoordinates => true;

	protected abstract IChunk CreateChunkCore(int cx, int cz);

	protected abstract IChunk CreateChunkVerifiedCore(NbtTree tree);

	protected abstract bool ParseFileNameCore(string filename, out int x, out int z);

	public abstract string GetFileName();

	public abstract string GetFilePath();

	public Region(RegionManager rm, ChunkCache cache, int rx, int rz)
	{
		_regionMan = rm;
		_cache = cache;
		_regionFile = new WeakReference(null);
		_rx = rx;
		_rz = rz;
		if (!File.Exists(GetFilePath()))
		{
			throw new FileNotFoundException();
		}
	}

	public Region(RegionManager rm, ChunkCache cache, string filename)
	{
		_regionMan = rm;
		_cache = cache;
		_regionFile = new WeakReference(null);
		ParseFileNameCore(filename, out _rx, out _rz);
		if (!File.Exists(Path.Combine(_regionMan.GetRegionPath(), filename)))
		{
			throw new FileNotFoundException();
		}
	}

	~Region()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing && _regionFile.Target is RegionFile regionFile)
		{
			regionFile.Dispose();
			RegionFile regionFile2 = null;
		}
		_disposed = true;
	}

	private RegionFile GetRegionFile()
	{
		RegionFile regionFile = _regionFile.Target as RegionFile;
		if (regionFile == null)
		{
			regionFile = new RegionFile(GetFilePath());
			_regionFile.Target = regionFile;
		}
		return regionFile;
	}

	public NbtTree GetChunkTree(int lcx, int lcz)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.GetChunkTree(ForeignX(lcx), ForeignZ(lcz));
		}
		RegionFile regionFile = GetRegionFile();
		Stream chunkDataInputStream = regionFile.GetChunkDataInputStream(lcx, lcz);
		if (chunkDataInputStream == null)
		{
			return null;
		}
		NbtTree result = new NbtTree(chunkDataInputStream);
		chunkDataInputStream.Close();
		return result;
	}

	public bool SaveChunkTree(int lcx, int lcz, NbtTree tree)
	{
		return SaveChunkTree(lcx, lcz, tree, null);
	}

	public bool SaveChunkTree(int lcx, int lcz, NbtTree tree, int timestamp)
	{
		return SaveChunkTree(lcx, lcz, tree, timestamp);
	}

	private bool SaveChunkTree(int lcx, int lcz, NbtTree tree, int? timestamp)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.SaveChunkTree(ForeignX(lcx), ForeignZ(lcz), tree) ?? false;
		}
		RegionFile regionFile = GetRegionFile();
		Stream stream = ((!timestamp.HasValue) ? regionFile.GetChunkDataOutputStream(lcx, lcz) : regionFile.GetChunkDataOutputStream(lcx, lcz, timestamp.Value));
		if (stream == null)
		{
			return false;
		}
		tree.WriteTo(stream);
		stream.Close();
		return true;
	}

	public Stream GetChunkOutStream(int lcx, int lcz)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.GetChunkOutStream(ForeignX(lcx), ForeignZ(lcz));
		}
		RegionFile regionFile = GetRegionFile();
		return regionFile.GetChunkDataOutputStream(lcx, lcz);
	}

	public int ChunkCount()
	{
		RegionFile regionFile = GetRegionFile();
		int num = 0;
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 32; j++)
			{
				if (regionFile.HasChunk(i, j))
				{
					num++;
				}
			}
		}
		return num;
	}

	public ChunkRef GetChunkRef(int lcx, int lcz)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.GetChunkRef(ForeignX(lcx), ForeignZ(lcz));
		}
		int cx = lcx + _rx * 32;
		int cz = lcz + _rz * 32;
		ChunkKey key = new ChunkKey(cx, cz);
		ChunkRef chunkRef = _cache.Fetch(key);
		if (chunkRef != null)
		{
			return chunkRef;
		}
		chunkRef = ChunkRef.Create(this, lcx, lcz);
		if (chunkRef != null)
		{
			_cache.Insert(chunkRef);
		}
		return chunkRef;
	}

	public ChunkRef CreateChunk(int lcx, int lcz)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.CreateChunk(ForeignX(lcx), ForeignZ(lcz));
		}
		DeleteChunk(lcx, lcz);
		int cx = lcx + _rx * 32;
		int cz = lcz + _rz * 32;
		IChunk chunk = CreateChunkCore(cx, cz);
		chunk.Save(GetChunkOutStream(lcx, lcz));
		ChunkRef chunkRef = ChunkRef.Create(this, lcx, lcz);
		_cache.Insert(chunkRef);
		return chunkRef;
	}

	public int ChunkGlobalX(int cx)
	{
		return _rx * 32 + cx;
	}

	public int ChunkGlobalZ(int cz)
	{
		return _rz * 32 + cz;
	}

	public int ChunkLocalX(int cx)
	{
		return cx;
	}

	public int ChunkLocalZ(int cz)
	{
		return cz;
	}

	public IChunk GetChunk(int lcx, int lcz)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.GetChunk(ForeignX(lcx), ForeignZ(lcz));
		}
		if (!ChunkExists(lcx, lcz))
		{
			return null;
		}
		return CreateChunkVerifiedCore(GetChunkTree(lcx, lcz));
	}

	public bool ChunkExists(int lcx, int lcz)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.ChunkExists(ForeignX(lcx), ForeignZ(lcz)) ?? false;
		}
		RegionFile regionFile = GetRegionFile();
		return regionFile.HasChunk(lcx, lcz);
	}

	public bool DeleteChunk(int lcx, int lcz)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.DeleteChunk(ForeignX(lcx), ForeignZ(lcz)) ?? false;
		}
		RegionFile regionFile = GetRegionFile();
		if (!regionFile.HasChunk(lcx, lcz))
		{
			return false;
		}
		regionFile.DeleteChunk(lcx, lcz);
		ChunkKey key = new ChunkKey(ChunkGlobalX(lcx), ChunkGlobalZ(lcz));
		_cache.Remove(key);
		if (ChunkCount() == 0)
		{
			_regionMan.DeleteRegion(X, Z);
			_regionFile.Target = null;
		}
		return true;
	}

	public ChunkRef SetChunk(int lcx, int lcz, IChunk chunk)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.CreateChunk(ForeignX(lcx), ForeignZ(lcz));
		}
		DeleteChunk(lcx, lcz);
		int x = lcx + _rx * 32;
		int z = lcz + _rz * 32;
		chunk.SetLocation(x, z);
		chunk.Save(GetChunkOutStream(lcx, lcz));
		ChunkRef chunkRef = ChunkRef.Create(this, lcx, lcz);
		_cache.Insert(chunkRef);
		return chunkRef;
	}

	public int Save()
	{
		_cache.SyncDirty();
		int num = 0;
		IEnumerator<ChunkRef> dirtyEnumerator = _cache.GetDirtyEnumerator();
		while (dirtyEnumerator.MoveNext())
		{
			ChunkRef current = dirtyEnumerator.Current;
			if (!ChunkExists(current.LocalX, current.LocalZ))
			{
				throw new MissingChunkException();
			}
			if (current.Save(GetChunkOutStream(current.LocalX, current.LocalZ)))
			{
				num++;
			}
		}
		_cache.ClearDirty();
		return num;
	}

	public bool SaveChunk(IChunk chunk)
	{
		return chunk.Save(GetChunkOutStream(ForeignX(chunk.X), ForeignZ(chunk.Z)));
	}

	public int GetChunkTimestamp(int lcx, int lcz)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			return GetForeignRegion(lcx, lcz)?.GetChunkTimestamp(ForeignX(lcx), ForeignZ(lcz)) ?? 0;
		}
		RegionFile regionFile = GetRegionFile();
		return regionFile.GetTimestamp(lcx, lcz);
	}

	public void SetChunkTimestamp(int lcx, int lcz, int timestamp)
	{
		if (!LocalBoundsCheck(lcx, lcz))
		{
			GetForeignRegion(lcx, lcz)?.SetChunkTimestamp(ForeignX(lcx), ForeignZ(lcz), timestamp);
		}
		RegionFile regionFile = GetRegionFile();
		regionFile.SetTimestamp(lcx, lcz, timestamp);
	}

	protected bool LocalBoundsCheck(int lcx, int lcz)
	{
		if (lcx >= 0 && lcx < 32 && lcz >= 0)
		{
			return lcz < 32;
		}
		return false;
	}

	protected IRegion GetForeignRegion(int lcx, int lcz)
	{
		return _regionMan.GetRegion(_rx + (lcx >> 5), _rz + (lcz >> 5));
	}

	protected int ForeignX(int lcx)
	{
		return (lcx + 320000) & 0x1F;
	}

	protected int ForeignZ(int lcz)
	{
		return (lcz + 320000) & 0x1F;
	}
}
