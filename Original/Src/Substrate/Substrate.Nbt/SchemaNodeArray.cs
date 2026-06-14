namespace Substrate.Nbt;

public sealed class SchemaNodeArray : SchemaNode
{
	private int _length;

	public int Length => _length;

	public bool HasExpectedLength => _length > 0;

	public SchemaNodeArray(string name)
		: base(name)
	{
		_length = 0;
	}

	public SchemaNodeArray(string name, SchemaOptions options)
		: base(name, options)
	{
		_length = 0;
	}

	public SchemaNodeArray(string name, int length)
		: base(name)
	{
		_length = length;
	}

	public SchemaNodeArray(string name, int length, SchemaOptions options)
		: base(name, options)
	{
		_length = length;
	}

	public override TagNode BuildDefaultTree()
	{
		return new TagNodeByteArray(new byte[_length]);
	}
}
