namespace Substrate.Nbt;

public sealed class TagNodeDouble : TagNode
{
	private double _data;

	public double Data
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

	public override TagNodeDouble ToTagDouble()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_DOUBLE;
	}

	public TagNodeDouble()
	{
	}

	public TagNodeDouble(double d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		return new TagNodeDouble(_data);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeDouble(float f)
	{
		return new TagNodeDouble(f);
	}

	public static implicit operator TagNodeDouble(double d)
	{
		return new TagNodeDouble(d);
	}

	public static implicit operator double(TagNodeDouble d)
	{
		return d._data;
	}
}
