namespace Substrate.Nbt;

public sealed class TagNodeString : TagNode
{
	private string _data = "";

	public string Data
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

	public override TagNodeString ToTagString()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_STRING;
	}

	public TagNodeString()
	{
	}

	public TagNodeString(string d)
	{
		_data = d;
		if (_data == null)
		{
			_data = "";
		}
	}

	public override TagNode Copy()
	{
		return new TagNodeString(_data);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeString(string s)
	{
		return new TagNodeString(s);
	}

	public static implicit operator string(TagNodeString s)
	{
		return s._data;
	}
}
