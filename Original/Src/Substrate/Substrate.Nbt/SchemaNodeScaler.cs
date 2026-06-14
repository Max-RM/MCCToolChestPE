namespace Substrate.Nbt;

public sealed class SchemaNodeScaler : SchemaNode
{
	private TagType _type;

	public TagType Type => _type;

	public SchemaNodeScaler(string name, TagType type)
		: base(name)
	{
		_type = type;
	}

	public SchemaNodeScaler(string name, TagType type, SchemaOptions options)
		: base(name, options)
	{
		_type = type;
	}

	public override TagNode BuildDefaultTree()
	{
		return _type switch
		{
			TagType.TAG_STRING => new TagNodeString(), 
			TagType.TAG_BYTE => new TagNodeByte(), 
			TagType.TAG_SHORT => new TagNodeShort(), 
			TagType.TAG_INT => new TagNodeInt(), 
			TagType.TAG_LONG => new TagNodeLong(), 
			TagType.TAG_FLOAT => new TagNodeFloat(), 
			TagType.TAG_DOUBLE => new TagNodeDouble(), 
			_ => null, 
		};
	}
}
