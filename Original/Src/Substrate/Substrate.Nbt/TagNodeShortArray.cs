namespace Substrate.Nbt;

public sealed class TagNodeShortArray : TagNode
{
	private short[] _data;

	public short[] Data
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

	public short this[int index]
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

	public override TagNodeShortArray ToTagShortArray()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_SHORT_ARRAY;
	}

	public TagNodeShortArray()
	{
	}

	public TagNodeShortArray(short[] d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		short[] array = new short[_data.Length];
		_data.CopyTo(array, 0);
		return new TagNodeShortArray(array);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeShortArray(short[] i)
	{
		return new TagNodeShortArray(i);
	}

	public static implicit operator short[](TagNodeShortArray i)
	{
		return i._data;
	}
}
