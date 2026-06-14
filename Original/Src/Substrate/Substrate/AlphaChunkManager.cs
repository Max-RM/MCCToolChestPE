using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class AlphaChunkManager : IChunkManager, IChunkContainer, IEnumerable<ChunkRef>, IEnumerable
{
	private class Enumerator : IEnumerator<ChunkRef>, IDisposable, IEnumerator
	{
		protected AlphaChunkManager _cm;

		protected Queue<string> _tld;

		protected Queue<string> _sld;

		protected Queue<ChunkRef> _chunks;

		private string _curtld;

		private string _cursld;

		private ChunkRef _curchunk;

		protected static Regex _namePattern = new Regex("c\\.(-?[0-9a-zA-Z]+)\\.(-?[0-9a-zA-Z]+)\\.dat$");

		object IEnumerator.Current => Current;

		ChunkRef IEnumerator<ChunkRef>.Current => Current;

		public ChunkRef Current
		{
			get
			{
				if (_curchunk == null)
				{
					throw new InvalidOperationException();
				}
				return _curchunk;
			}
		}

		public Enumerator(AlphaChunkManager cfm)
		{
			_cm = cfm;
			if (!Directory.Exists(_cm.ChunkPath))
			{
				throw new DirectoryNotFoundException();
			}
			Reset();
		}

		private bool MoveNextTLD()
		{
			if (_tld.Count == 0)
			{
				return false;
			}
			_curtld = _tld.Dequeue();
			string[] directories = Directory.GetDirectories(_curtld);
			string[] array = directories;
			foreach (string item in array)
			{
				_sld.Enqueue(item);
			}
			return true;
		}

		public bool MoveNextSLD()
		{
			while (_sld.Count == 0)
			{
				if (!MoveNextTLD())
				{
					return false;
				}
			}
			_cursld = _sld.Dequeue();
			string[] files = Directory.GetFiles(_cursld);
			string[] array = files;
			foreach (string path in array)
			{
				string fileName = Path.GetFileName(path);
				if (ParseFileName(fileName, out var x, out var z))
				{
					ChunkRef chunkRef = _cm.GetChunkRef(x, z);
					if (chunkRef != null)
					{
						_chunks.Enqueue(chunkRef);
					}
				}
			}
			return true;
		}

		public bool MoveNext()
		{
			while (_chunks.Count == 0)
			{
				if (!MoveNextSLD())
				{
					return false;
				}
			}
			_curchunk = _chunks.Dequeue();
			return true;
		}

		public void Reset()
		{
			_curchunk = null;
			_tld = new Queue<string>();
			_sld = new Queue<string>();
			_chunks = new Queue<ChunkRef>();
			string[] directories = Directory.GetDirectories(_cm.ChunkPath);
			string[] array = directories;
			foreach (string item in array)
			{
				_tld.Enqueue(item);
			}
		}

		void IDisposable.Dispose()
		{
		}

		private bool ParseFileName(string filename, out int x, out int z)
		{
			x = 0;
			z = 0;
			Match match = _namePattern.Match(filename);
			if (!match.Success)
			{
				return false;
			}
			x = (int)Base36.Decode(match.Groups[1].Value);
			z = (int)Base36.Decode(match.Groups[2].Value);
			return true;
		}
	}

	private string _mapPath;

	private LRUCache<ChunkKey, ChunkRef> _cache;

	private Dictionary<ChunkKey, ChunkRef> _dirty;

	public string ChunkPath => _mapPath;

	public bool CanDelegateCoordinates => true;

	public AlphaChunkManager(string mapDir)
	{
		_mapPath = mapDir;
		_cache = new LRUCache<ChunkKey, ChunkRef>(256);
		_dirty = new Dictionary<ChunkKey, ChunkRef>();
	}

	private ChunkFile GetChunkFile(int cx, int cz)
	{
		return new ChunkFile(_mapPath, cx, cz);
	}

	private NbtTree GetChunkTree(int cx, int cz)
	{
		ChunkFile chunkFile = GetChunkFile(cx, cz);
		Stream dataInputStream = chunkFile.GetDataInputStream();
		if (dataInputStream == null)
		{
			return null;
		}
		return new NbtTree(dataInputStream);
	}

	private bool SaveChunkTree(int cx, int cz, NbtTree tree)
	{
		ChunkFile chunkFile = GetChunkFile(cx, cz);
		Stream dataOutputStream = chunkFile.GetDataOutputStream();
		if (dataOutputStream == null)
		{
			return false;
		}
		tree.WriteTo(dataOutputStream);
		dataOutputStream.Close();
		return true;
	}

	private Stream GetChunkOutStream(int cx, int cz)
	{
		return new ChunkFile(_mapPath, cx, cz).GetDataOutputStream();
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
		return cx;
	}

	public int ChunkLocalZ(int cz)
	{
		return cz;
	}

	public IChunk GetChunk(int cx, int cz)
	{
		if (!ChunkExists(cx, cz))
		{
			return null;
		}
		return AlphaChunk.CreateVerified(GetChunkTree(cx, cz));
	}

	public ChunkRef GetChunkRef(int cx, int cz)
	{
		ChunkKey key = new ChunkKey(cx, cz);
		ChunkRef value = null;
		if (_cache.TryGetValue(key, out value))
		{
			return value;
		}
		value = ChunkRef.Create(this, cx, cz);
		if (value != null)
		{
			_cache[key] = value;
		}
		return value;
	}

	public ChunkRef CreateChunk(int cx, int cz)
	{
		DeleteChunk(cx, cz);
		AlphaChunk alphaChunk = AlphaChunk.Create(cx, cz);
		alphaChunk.Save(GetChunkOutStream(cx, cz));
		ChunkRef chunkRef = ChunkRef.Create(this, cx, cz);
		ChunkKey key = new ChunkKey(cx, cz);
		_cache[key] = chunkRef;
		return chunkRef;
	}

	public bool ChunkExists(int cx, int cz)
	{
		return new ChunkFile(_mapPath, cx, cz).Exists();
	}

	public bool DeleteChunk(int cx, int cz)
	{
		new ChunkFile(_mapPath, cx, cz).Delete();
		ChunkKey key = new ChunkKey(cx, cz);
		_cache.Remove(key);
		_dirty.Remove(key);
		return true;
	}

	public ChunkRef SetChunk(int cx, int cz, IChunk chunk)
	{
		DeleteChunk(cx, cz);
		chunk.SetLocation(cx, cz);
		chunk.Save(GetChunkOutStream(cx, cz));
		ChunkRef chunkRef = ChunkRef.Create(this, cx, cz);
		ChunkKey key = new ChunkKey(cx, cz);
		_cache[key] = chunkRef;
		return chunkRef;
	}

	public int Save()
	{
		foreach (KeyValuePair<ChunkKey, ChunkRef> item in _cache)
		{
			if (item.Value.IsDirty)
			{
				_dirty[item.Key] = item.Value;
			}
		}
		int num = 0;
		foreach (ChunkRef value in _dirty.Values)
		{
			int cx = ChunkGlobalX(value.X);
			int cz = ChunkGlobalZ(value.Z);
			if (value.Save(GetChunkOutStream(cx, cz)))
			{
				num++;
			}
		}
		_dirty.Clear();
		return num;
	}

	public bool SaveChunk(IChunk chunk)
	{
		if (chunk.Save(GetChunkOutStream(ChunkGlobalX(chunk.X), ChunkGlobalZ(chunk.Z))))
		{
			_dirty.Remove(new ChunkKey(chunk.X, chunk.Z));
			return true;
		}
		return false;
	}

	public int GetChunkTimestamp(int cx, int cz)
	{
		return GetChunkFile(cx, cz)?.GetModifiedTime() ?? 0;
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
