using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagByteArrayDataNode : TagDataNode
{
	protected new TagNodeByteArray Tag => base.Tag as TagNodeByteArray;

	public override bool CanEditNode => true;

	public override string NodeDisplay => base.NodeDisplayPrefix + Tag.Data.Length + " bytes";

	public TagByteArrayDataNode(TagNodeByteArray tag)
		: base(tag)
	{
	}

	public override bool EditNode()
	{
		return EditByteHexValue(Tag);
	}
}
