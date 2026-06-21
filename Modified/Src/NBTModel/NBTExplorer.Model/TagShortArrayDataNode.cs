using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagShortArrayDataNode : TagDataNode
{
	protected new TagNodeShortArray Tag => base.Tag as TagNodeShortArray;

	public override bool CanEditNode => true;

	public override string NodeDisplay => base.NodeDisplayPrefix + Tag.Data.Length + " shorts";

	public TagShortArrayDataNode(TagNodeShortArray tag)
		: base(tag)
	{
	}

	public override bool EditNode()
	{
		return EditShortHexValue(Tag);
	}
}
