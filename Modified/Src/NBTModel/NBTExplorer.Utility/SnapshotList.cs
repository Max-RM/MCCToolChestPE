using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NBTExplorer.Utility;

public class SnapshotList<T> : Collection<T>
{
	private class ProxyList<K> : IList<K>, ICollection<K>, IEnumerable<K>, IEnumerable
	{
		public IList<K> InnerList { get; set; }

		public K this[int index]
		{
			get
			{
				return InnerList[index];
			}
			set
			{
				InnerList[index] = value;
			}
		}

		public int Count => InnerList.Count;

		public bool IsReadOnly => InnerList.IsReadOnly;

		public ProxyList()
		{
			InnerList = new List<K>();
		}

		public ProxyList(IList<K> list)
		{
			InnerList = list;
		}

		public int IndexOf(K item)
		{
			return InnerList.IndexOf(item);
		}

		public void Insert(int index, K item)
		{
			InnerList.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

		public void Add(K item)
		{
			InnerList.Add(item);
		}

		public void Clear()
		{
			InnerList.Clear();
		}

		public bool Contains(K item)
		{
			return InnerList.Contains(item);
		}

		public void CopyTo(K[] array, int arrayIndex)
		{
			InnerList.CopyTo(array, arrayIndex);
		}

		public bool Remove(K item)
		{
			return InnerList.Remove(item);
		}

		public IEnumerator<K> GetEnumerator()
		{
			return InnerList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return InnerList.GetEnumerator();
		}
	}

	private IList<T> _snapshot;

	private IList<T> _recycled;

	private int _snapshots;

	private new ProxyList<T> Items => base.Items as ProxyList<T>;

	public SnapshotList()
		: base((IList<T>)new ProxyList<T>())
	{
	}

	public SnapshotList(IList<T> list)
		: base((IList<T>)new ProxyList<T>(new List<T>(list)))
	{
	}

	public SnapshotList(int capacity)
		: base((IList<T>)new ProxyList<T>(new List<T>(capacity)))
	{
	}

	public IList<T> Begin()
	{
		Modified();
		_snapshot = Items.InnerList;
		_snapshots++;
		return _snapshot;
	}

	public void End()
	{
		_snapshots = Math.Max(0, _snapshots - 1);
		if (_snapshot != null)
		{
			if (_snapshot != Items.InnerList && _snapshots == 0)
			{
				_recycled = _snapshot;
				_recycled.Clear();
			}
			_snapshot = null;
		}
	}

	public SnapshotState<T> Snapshot()
	{
		return new SnapshotState<T>(this);
	}

	private void Modified()
	{
		if (_snapshot == null || _snapshot != Items.InnerList)
		{
			return;
		}
		if (_recycled != null)
		{
			for (int i = 0; i < base.Count; i++)
			{
				_recycled.Add(Items[i]);
			}
			Items.InnerList = _recycled;
			_recycled = null;
		}
		else
		{
			Resize(Items.Count);
		}
	}

	private void Resize(int newSize)
	{
		IList<T> innerList = Items.InnerList;
		List<T> list = new List<T>(newSize);
		int i = 0;
		for (int count = innerList.Count; i < count; i++)
		{
			list.Add(innerList[i]);
		}
		Items.InnerList = list;
	}

	protected override void InsertItem(int index, T item)
	{
		Modified();
		base.InsertItem(index, item);
	}

	protected override void SetItem(int index, T item)
	{
		Modified();
		base.SetItem(index, item);
	}

	protected override void RemoveItem(int index)
	{
		Modified();
		base.RemoveItem(index);
	}

	protected override void ClearItems()
	{
		Modified();
		base.ClearItems();
	}
}
