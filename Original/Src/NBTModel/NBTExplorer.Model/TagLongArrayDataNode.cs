using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagLongArrayDataNode : TagDataNode
{
	protected new TagNodeLongArray Tag => base.Tag as TagNodeLongArray;

	public override bool CanEditNode => true;

	public override string NodeDisplay => base.NodeDisplayPrefix + Tag.Data.Length + " long integers";

	public TagLongArrayDataNode(TagNodeLongArray tag)
		: base(tag)
	{
	}

	public override bool EditNode()
	{
		return EditLongHexValue(Tag);
	}
}
