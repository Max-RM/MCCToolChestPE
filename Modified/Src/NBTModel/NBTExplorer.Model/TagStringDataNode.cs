using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagStringDataNode : TagDataNode
{
	protected new TagNodeString Tag => base.Tag as TagNodeString;

	public override string NodeDisplay => base.NodeDisplayPrefix + Tag.ToString().Replace('\n', '¶');

	public TagStringDataNode(TagNodeString tag)
		: base(tag)
	{
	}

	public override bool Parse(string value)
	{
		Tag.Data = value;
		base.IsDataModified = true;
		return true;
	}

	public override bool EditNode()
	{
		return EditStringValue(Tag);
	}
}
