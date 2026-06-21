using System;
using System.Collections;
using System.Collections.Generic;

namespace Substrate.Core;

internal class LRUCache<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	public class CacheValueArgs : EventArgs
	{
		private TKey _key;

		private TValue _value;

		public TKey Key => _key;

		public TValue Value => _value;

		public CacheValueArgs(TKey key, TValue value)
		{
			_key = key;
			_value = value;
		}
	}

	private Dictionary<TKey, TValue> _data;

	private IndexedLinkedList<TKey> _index;

	private int _capacity;

	public ICollection<TKey> Keys => _data.Keys;

	public ICollection<TValue> Values => _data.Values;

	public TValue this[TKey key]
	{
		get
		{
			TValue result = _data[key];
			_index.Remove(key);
			_index.Add(key);
			return result;
		}
		set
		{
			_data[key] = value;
			_index.Remove(key);
			_index.Add(key);
			if (_data.Count > _capacity)
			{
				OnRemoveCacheValue(new CacheValueArgs(_index.First, _data[_index.First]));
				_data.Remove(_index.First);
				_index.RemoveFirst();
			}
		}
	}

	public int Count => _data.Count;

	public bool IsReadOnly => false;

	public event EventHandler<CacheValueArgs> RemoveCacheValue;

	public LRUCache(int capacity)
	{
		if (capacity <= 0)
		{
			throw new ArgumentException("Cache capacity must be positive");
		}
		_capacity = capacity;
		_data = new Dictionary<TKey, TValue>();
		_index = new IndexedLinkedList<TKey>();
	}

	public void Add(TKey key, TValue value)
	{
		if (_data.ContainsKey(key))
		{
			throw new ArgumentException("Attempted to insert a duplicate key");
		}
		_data[key] = value;
		_index.Add(key);
		if (_data.Count > _capacity)
		{
			OnRemoveCacheValue(new CacheValueArgs(_index.First, _data[_index.First]));
			_data.Remove(_index.First);
			_index.RemoveFirst();
		}
	}

	public bool ContainsKey(TKey key)
	{
		return _data.ContainsKey(key);
	}

	public bool Remove(TKey key)
	{
		if (_data.Remove(key))
		{
			_index.Remove(key);
			return true;
		}
		return false;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		if (!_data.TryGetValue(key, out value))
		{
			return false;
		}
		_index.Remove(key);
		_index.Add(key);
		return true;
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		Add(item.Key, item.Value);
	}

	public void Clear()
	{
		_data.Clear();
		_index.Clear();
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		return ((ICollection<KeyValuePair<TKey, TValue>>)_data).Contains(item);
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		((ICollection<KeyValuePair<TKey, TValue>>)_data).CopyTo(array, arrayIndex);
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		if (((ICollection<KeyValuePair<TKey, TValue>>)_data).Remove(item))
		{
			_index.Remove(item.Key);
			return true;
		}
		return false;
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return _data.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _data.GetEnumerator();
	}

	private void OnRemoveCacheValue(CacheValueArgs e)
	{
		if (this.RemoveCacheValue != null)
		{
			this.RemoveCacheValue(this, e);
		}
	}
}
