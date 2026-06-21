namespace Substrate.Nbt;

public sealed class TagNodeLong : TagNode
{
	private long _data;

	public long Data
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

	public override TagNodeLong ToTagLong()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_LONG;
	}

	public TagNodeLong()
	{
	}

	public TagNodeLong(long d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		return new TagNodeLong(_data);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeLong(byte b)
	{
		return new TagNodeLong(b);
	}

	public static implicit operator TagNodeLong(short s)
	{
		return new TagNodeLong(s);
	}

	public static implicit operator TagNodeLong(int i)
	{
		return new TagNodeLong(i);
	}

	public static implicit operator TagNodeLong(long l)
	{
		return new TagNodeLong(l);
	}

	public static implicit operator long(TagNodeLong l)
	{
		return l._data;
	}
}
