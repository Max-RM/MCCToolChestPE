using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagLongDataNode : TagDataNode
{
	protected new TagNodeLong Tag => base.Tag as TagNodeLong;

	public TagLongDataNode(TagNodeLong tag)
		: base(tag)
	{
	}

	public override bool Parse(string value)
	{
		if (!long.TryParse(value, out var result))
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
