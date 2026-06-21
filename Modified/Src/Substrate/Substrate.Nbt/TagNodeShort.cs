namespace Substrate.Nbt;

public sealed class TagNodeShort : TagNode
{
	private short _data;

	public short Data
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

	public override TagNodeShort ToTagShort()
	{
		return this;
	}

	public override TagNodeInt ToTagInt()
	{
		return new TagNodeInt(_data);
	}

	public override TagNodeLong ToTagLong()
	{
		return new TagNodeLong(_data);
	}

	public override TagNodeFloat ToTagFloat()
	{
		return new TagNodeFloat(_data);
	}

	public override TagNodeDouble ToTagDouble()
	{
		return new TagNodeDouble(_data);
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_SHORT;
	}

	public override bool IsCastableTo(TagType type)
	{
		if (type != TagType.TAG_SHORT && type != TagType.TAG_INT && type != TagType.TAG_LONG && type != TagType.TAG_FLOAT)
		{
			return type == TagType.TAG_DOUBLE;
		}
		return true;
	}

	public TagNodeShort()
	{
	}

	public TagNodeShort(short d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		return new TagNodeShort(_data);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeShort(byte b)
	{
		return new TagNodeShort(b);
	}

	public static implicit operator TagNodeShort(short s)
	{
		return new TagNodeShort(s);
	}

	public static implicit operator short(TagNodeShort s)
	{
		return s._data;
	}

	public static implicit operator int(TagNodeShort s)
	{
		return s._data;
	}

	public static implicit operator long(TagNodeShort s)
	{
		return s._data;
	}
}
