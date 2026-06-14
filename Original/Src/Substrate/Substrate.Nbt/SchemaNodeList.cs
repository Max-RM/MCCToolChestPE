namespace Substrate.Nbt;

public sealed class SchemaNodeList : SchemaNode
{
	private TagType _type;

	private int _length;

	private SchemaNode _subschema;

	public int Length => _length;

	public TagType Type => _type;

	public SchemaNode SubSchema => _subschema;

	public bool HasExpectedLength => _length > 0;

	public SchemaNodeList(string name, TagType type)
		: base(name)
	{
		_type = type;
	}

	public SchemaNodeList(string name, TagType type, SchemaOptions options)
		: base(name, options)
	{
		_type = type;
	}

	public SchemaNodeList(string name, TagType type, int length)
		: base(name)
	{
		_type = type;
		_length = length;
	}

	public SchemaNodeList(string name, TagType type, int length, SchemaOptions options)
		: base(name, options)
	{
		_type = type;
		_length = length;
	}

	public SchemaNodeList(string name, TagType type, SchemaNode subschema)
		: base(name)
	{
		_type = type;
		_subschema = subschema;
	}

	public SchemaNodeList(string name, TagType type, SchemaNode subschema, SchemaOptions options)
		: base(name, options)
	{
		_type = type;
		_subschema = subschema;
	}

	public SchemaNodeList(string name, TagType type, int length, SchemaNode subschema)
		: base(name)
	{
		_type = type;
		_length = length;
		_subschema = subschema;
	}

	public SchemaNodeList(string name, TagType type, int length, SchemaNode subschema, SchemaOptions options)
		: base(name, options)
	{
		_type = type;
		_length = length;
		_subschema = subschema;
	}

	public override TagNode BuildDefaultTree()
	{
		if (_length == 0)
		{
			return new TagNodeList(_type);
		}
		TagNodeList tagNodeList = new TagNodeList(_type);
		for (int i = 0; i < _length; i++)
		{
			tagNodeList.Add(_subschema.BuildDefaultTree());
		}
		return tagNodeList;
	}
}
