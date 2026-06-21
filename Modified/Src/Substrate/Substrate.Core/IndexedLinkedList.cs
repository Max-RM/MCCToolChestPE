using System;
using System.Collections;
using System.Collections.Generic;

namespace Substrate.Core;

internal class IndexedLinkedList<T> : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable
{
	private LinkedList<T> _list;

	private Dictionary<T, LinkedListNode<T>> _index;

	public T First => _list.First.Value;

	public T Last => _list.Last.Value;

	public bool IsReadOnly => false;

	public int Count => _list.Count;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => ((ICollection)_list).SyncRoot;

	public IndexedLinkedList()
	{
		_list = new LinkedList<T>();
		_index = new Dictionary<T, LinkedListNode<T>>();
	}

	public void AddFirst(T value)
	{
		LinkedListNode<T> value2 = _list.AddFirst(value);
		_index.Add(value, value2);
	}

	public void AddLast(T value)
	{
		LinkedListNode<T> value2 = _list.AddLast(value);
		_index.Add(value, value2);
	}

	public void RemoveFirst()
	{
		_index.Remove(_list.First.Value);
		_list.RemoveFirst();
	}

	public void RemoveLast()
	{
		_index.Remove(_list.First.Value);
		_list.RemoveLast();
	}

	public void Add(T item)
	{
		AddLast(item);
	}

	public void Clear()
	{
		_index.Clear();
		_list.Clear();
	}

	public bool Contains(T item)
	{
		return _index.ContainsKey(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		_list.CopyTo(array, arrayIndex);
	}

	public bool Remove(T value)
	{
		if (_index.TryGetValue(value, out var value2))
		{
			_index.Remove(value);
			_list.Remove(value2);
			return true;
		}
		return false;
	}

	void ICollection.CopyTo(Array array, int index)
	{
		((ICollection)_list).CopyTo(array, index);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _list.GetEnumerator();
	}
}
