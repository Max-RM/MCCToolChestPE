namespace Substrate.Nbt;

public sealed class TagNodeFloat : TagNode
{
	private float _data;

	public float Data
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

	public override TagNodeFloat ToTagFloat()
	{
		return this;
	}

	public override TagNodeDouble ToTagDouble()
	{
		return new TagNodeDouble(_data);
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_FLOAT;
	}

	public override bool IsCastableTo(TagType type)
	{
		if (type != TagType.TAG_FLOAT)
		{
			return type == TagType.TAG_DOUBLE;
		}
		return true;
	}

	public TagNodeFloat()
	{
	}

	public TagNodeFloat(float d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		return new TagNodeFloat(_data);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeFloat(float f)
	{
		return new TagNodeFloat(f);
	}

	public static implicit operator float(TagNodeFloat f)
	{
		return f._data;
	}

	public static implicit operator double(TagNodeFloat f)
	{
		return f._data;
	}
}
