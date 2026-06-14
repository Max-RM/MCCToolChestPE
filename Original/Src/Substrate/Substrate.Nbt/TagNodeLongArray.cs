namespace Substrate.Nbt;

public sealed class TagNodeLongArray : TagNode
{
	private long[] _data;

	public long[] Data
	{
		get
		{
			return _data;
		}
		set
		{
			_data = value;
		}
	}

	public int Length => _data.Length;

	public long this[int index]
	{
		get
		{
			return _data[index];
		}
		set
		{
			_data[index] = value;
		}
	}

	public override TagNodeLongArray ToTagLongArray()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_LONG_ARRAY;
	}

	public TagNodeLongArray()
	{
	}

	public TagNodeLongArray(long[] d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		long[] array = new long[_data.Length];
		_data.CopyTo(array, 0);
		return new TagNodeLongArray(array);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeLongArray(long[] i)
	{
		return new TagNodeLongArray(i);
	}

	public static implicit operator long[](TagNodeLongArray i)
	{
		return i._data;
	}
}
