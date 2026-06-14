namespace Substrate.Nbt;

public sealed class TagNodeByte : TagNode
{
	private byte _data;

	public byte Data
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

	public override TagNodeByte ToTagByte()
	{
		return this;
	}

	public override TagNodeShort ToTagShort()
	{
		return new TagNodeShort(_data);
	}

	public override TagNodeInt ToTagInt()
	{
		return new TagNodeInt(_data);
	}

	public override TagNodeLong ToTagLong()
	{
		return new TagNodeLong(_data);
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_BYTE;
	}

	public override bool IsCastableTo(TagType type)
	{
		if (type != TagType.TAG_BYTE && type != TagType.TAG_SHORT && type != TagType.TAG_INT)
		{
			return type == TagType.TAG_LONG;
		}
		return true;
	}

	public TagNodeByte()
	{
	}

	public TagNodeByte(byte d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		return new TagNodeByte(_data);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeByte(byte b)
	{
		return new TagNodeByte(b);
	}

	public static implicit operator byte(TagNodeByte b)
	{
		return b._data;
	}

	public static implicit operator short(TagNodeByte b)
	{
		return b._data;
	}

	public static implicit operator int(TagNodeByte b)
	{
		return b._data;
	}

	public static implicit operator long(TagNodeByte b)
	{
		return b._data;
	}
}
