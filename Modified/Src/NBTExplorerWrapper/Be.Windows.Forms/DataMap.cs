using System;
using System.Collections;

namespace Be.Windows.Forms;

internal class DataMap : ICollection, IEnumerable
{
	internal class Enumerator : IEnumerator, IDisposable
	{
		private DataMap _map;

		private DataBlock _current;

		private int _index;

		private int _version;

		object IEnumerator.Current
		{
			get
			{
				if (_index < 0 || _index > _map.Count)
				{
					throw new InvalidOperationException("Enumerator is positioned before the first element or after the last element of the collection.");
				}
				return _current;
			}
		}

		internal Enumerator(DataMap map)
		{
			_map = map;
			_version = map._version;
			_current = null;
			_index = -1;
		}

		public bool MoveNext()
		{
			if (_version != _map._version)
			{
				throw new InvalidOperationException("Collection was modified after the enumerator was instantiated.");
			}
			if (_index >= _map.Count)
			{
				return false;
			}
			if (++_index == 0)
			{
				_current = _map.FirstBlock;
			}
			else
			{
				_current = _current.NextBlock;
			}
			return _index < _map.Count;
		}

		void IEnumerator.Reset()
		{
			if (_version != _map._version)
			{
				throw new InvalidOperationException("Collection was modified after the enumerator was instantiated.");
			}
			_index = -1;
			_current = null;
		}

		public void Dispose()
		{
		}
	}

	private readonly object _syncRoot = new object();

	internal int _count;

	internal DataBlock _firstBlock;

	internal int _version;

	public DataBlock FirstBlock => _firstBlock;

	public int Count => _count;

	public bool IsSynchronized => false;

	public object SyncRoot => _syncRoot;

	public DataMap()
	{
	}

	public DataMap(IEnumerable collection)
	{
		if (collection == null)
		{
			throw new ArgumentNullException("collection");
		}
		foreach (DataBlock item in collection)
		{
			AddLast(item);
		}
	}

	public void AddAfter(DataBlock block, DataBlock newBlock)
	{
		AddAfterInternal(block, newBlock);
	}

	public void AddBefore(DataBlock block, DataBlock newBlock)
	{
		AddBeforeInternal(block, newBlock);
	}

	public void AddFirst(DataBlock block)
	{
		if (_firstBlock == null)
		{
			AddBlockToEmptyMap(block);
		}
		else
		{
			AddBeforeInternal(_firstBlock, block);
		}
	}

	public void AddLast(DataBlock block)
	{
		if (_firstBlock == null)
		{
			AddBlockToEmptyMap(block);
		}
		else
		{
			AddAfterInternal(GetLastBlock(), block);
		}
	}

	public void Remove(DataBlock block)
	{
		RemoveInternal(block);
	}

	public void RemoveFirst()
	{
		if (_firstBlock == null)
		{
			throw new InvalidOperationException("The collection is empty.");
		}
		RemoveInternal(_firstBlock);
	}

	public void RemoveLast()
	{
		if (_firstBlock == null)
		{
			throw new InvalidOperationException("The collection is empty.");
		}
		RemoveInternal(GetLastBlock());
	}

	public DataBlock Replace(DataBlock block, DataBlock newBlock)
	{
		AddAfterInternal(block, newBlock);
		RemoveInternal(block);
		return newBlock;
	}

	public void Clear()
	{
		DataBlock dataBlock = FirstBlock;
		while (dataBlock != null)
		{
			DataBlock nextBlock = dataBlock.NextBlock;
			InvalidateBlock(dataBlock);
			dataBlock = nextBlock;
		}
		_firstBlock = null;
		_count = 0;
		_version++;
	}

	private void AddAfterInternal(DataBlock block, DataBlock newBlock)
	{
		newBlock._previousBlock = block;
		newBlock._nextBlock = block._nextBlock;
		newBlock._map = this;
		if (block._nextBlock != null)
		{
			block._nextBlock._previousBlock = newBlock;
		}
		block._nextBlock = newBlock;
		_version++;
		_count++;
	}

	private void AddBeforeInternal(DataBlock block, DataBlock newBlock)
	{
		newBlock._nextBlock = block;
		newBlock._previousBlock = block._previousBlock;
		newBlock._map = this;
		if (block._previousBlock != null)
		{
			block._previousBlock._nextBlock = newBlock;
		}
		block._previousBlock = newBlock;
		if (_firstBlock == block)
		{
			_firstBlock = newBlock;
		}
		_version++;
		_count++;
	}

	private void RemoveInternal(DataBlock block)
	{
		DataBlock previousBlock = block._previousBlock;
		DataBlock nextBlock = block._nextBlock;
		if (previousBlock != null)
		{
			previousBlock._nextBlock = nextBlock;
		}
		if (nextBlock != null)
		{
			nextBlock._previousBlock = previousBlock;
		}
		if (_firstBlock == block)
		{
			_firstBlock = nextBlock;
		}
		InvalidateBlock(block);
		_count--;
		_version++;
	}

	private DataBlock GetLastBlock()
	{
		DataBlock result = null;
		for (DataBlock dataBlock = FirstBlock; dataBlock != null; dataBlock = dataBlock.NextBlock)
		{
			result = dataBlock;
		}
		return result;
	}

	private void InvalidateBlock(DataBlock block)
	{
		block._map = null;
		block._nextBlock = null;
		block._previousBlock = null;
	}

	private void AddBlockToEmptyMap(DataBlock block)
	{
		block._map = this;
		block._nextBlock = null;
		block._previousBlock = null;
		_firstBlock = block;
		_version++;
		_count++;
	}

	public void CopyTo(Array array, int index)
	{
		DataBlock[] array2 = array as DataBlock[];
		for (DataBlock dataBlock = FirstBlock; dataBlock != null; dataBlock = dataBlock.NextBlock)
		{
			array2[index++] = dataBlock;
		}
	}

	public IEnumerator GetEnumerator()
	{
		return new Enumerator(this);
	}
}
