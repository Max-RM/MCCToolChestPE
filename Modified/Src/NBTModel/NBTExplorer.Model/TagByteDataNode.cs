using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagByteDataNode : TagDataNode
{
	protected new TagNodeByte Tag => base.Tag as TagNodeByte;

	public override string NodeDisplay => base.NodeDisplayPrefix + (sbyte)Tag.Data;

	public TagByteDataNode(TagNodeByte tag)
		: base(tag)
	{
	}

	public override bool Parse(string value)
	{
		if (!byte.TryParse(value, out var result))
		{
			return false;
		}
		Tag.Data = result;
		base.IsDataModified = true;
		return true;
	}

	public override bool EditNode()
	{
		return EditScalarValue(Tag);
	}
}
