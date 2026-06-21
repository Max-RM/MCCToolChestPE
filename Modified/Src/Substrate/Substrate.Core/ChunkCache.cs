using System.Collections.Generic;

namespace Substrate.Core;

public class ChunkCache
{
	private LRUCache<ChunkKey, ChunkRef> _cache;

	private Dictionary<ChunkKey, ChunkRef> _dirty;

	public ChunkCache()
		: this(256)
	{
	}

	public ChunkCache(int cacheSize)
	{
		_cache = new LRUCache<ChunkKey, ChunkRef>(cacheSize);
		_dirty = new Dictionary<ChunkKey, ChunkRef>();
		_cache.RemoveCacheValue += EvictionHandler;
	}

	public bool Insert(ChunkRef chunk)
	{
		ChunkKey key = new ChunkKey(chunk.X, chunk.Z);
		_dirty.Remove(key);
		if (!_cache.TryGetValue(key, out var _))
		{
			_cache[key] = chunk;
			return true;
		}
		return false;
	}

	public bool Remove(ChunkKey key)
	{
		_dirty.Remove(key);
		return _cache.Remove(key);
	}

	public ChunkRef Fetch(ChunkKey key)
	{
		if (_dirty.TryGetValue(key, out var value))
		{
			return value;
		}
		if (_cache.TryGetValue(key, out value))
		{
			return value;
		}
		return null;
	}

	public IEnumerator<ChunkRef> GetDirtyEnumerator()
	{
		return _dirty.Values.GetEnumerator();
	}

	public void Clear()
	{
		_cache.Clear();
	}

	public void ClearDirty()
	{
		_dirty.Clear();
	}

	public void SyncDirty()
	{
		foreach (KeyValuePair<ChunkKey, ChunkRef> item in _cache)
		{
			if (item.Value.IsDirty)
			{
				_dirty[item.Key] = item.Value;
			}
		}
	}

	private void EvictionHandler(object sender, LRUCache<ChunkKey, ChunkRef>.CacheValueArgs e)
	{
		if (e.Value.IsDirty)
		{
			_dirty[e.Key] = e.Value;
		}
	}
}
