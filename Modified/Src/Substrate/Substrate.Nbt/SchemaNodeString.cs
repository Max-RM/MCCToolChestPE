namespace Substrate.Nbt;

public sealed class SchemaNodeString : SchemaNode
{
	private string _value = "";

	private int _length;

	public int Length => _length;

	public string Value => _value;

	public bool HasMaxLength => _length > 0;

	public SchemaNodeString(string name)
		: base(name)
	{
	}

	public SchemaNodeString(string name, SchemaOptions options)
		: base(name, options)
	{
	}

	public SchemaNodeString(string name, string value)
		: base(name)
	{
		_value = value;
	}

	public SchemaNodeString(string name, string value, SchemaOptions options)
		: base(name, options)
	{
		_value = value;
	}

	public SchemaNodeString(string name, int length)
		: base(name)
	{
		_length = length;
	}

	public SchemaNodeString(string name, int length, SchemaOptions options)
		: base(name, options)
	{
		_length = length;
	}

	public override TagNode BuildDefaultTree()
	{
		if (_value.Length > 0)
		{
			return new TagNodeString(_value);
		}
		return new TagNodeString();
	}
}
