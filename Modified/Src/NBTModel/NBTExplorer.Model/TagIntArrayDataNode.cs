using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagIntArrayDataNode : TagDataNode
{
	protected new TagNodeIntArray Tag => base.Tag as TagNodeIntArray;

	public override bool CanEditNode => true;

	public override string NodeDisplay => base.NodeDisplayPrefix + Tag.Data.Length + " integers";

	public TagIntArrayDataNode(TagNodeIntArray tag)
		: base(tag)
	{
	}

	public override bool EditNode()
	{
		return EditIntHexValue(Tag);
	}
}
