namespace Substrate.Nbt;

public sealed class TagNodeInt : TagNode
{
	private int _data;

	public int Data
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

	public override TagNodeInt ToTagInt()
	{
		return this;
	}

	public override TagNodeLong ToTagLong()
	{
		return new TagNodeLong(_data);
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_INT;
	}

	public override bool IsCastableTo(TagType type)
	{
		if (type != TagType.TAG_INT)
		{
			return type == TagType.TAG_LONG;
		}
		return true;
	}

	public TagNodeInt()
	{
	}

	public TagNodeInt(int d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		return new TagNodeInt(_data);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeInt(byte b)
	{
		return new TagNodeInt(b);
	}

	public static implicit operator TagNodeInt(short s)
	{
		return new TagNodeInt(s);
	}

	public static implicit operator TagNodeInt(int i)
	{
		return new TagNodeInt(i);
	}

	public static implicit operator int(TagNodeInt i)
	{
		return i._data;
	}

	public static implicit operator long(TagNodeInt i)
	{
		return i._data;
	}
}
