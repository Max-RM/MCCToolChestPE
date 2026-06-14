using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagIntDataNode : TagDataNode
{
	protected new TagNodeInt Tag => base.Tag as TagNodeInt;

	public TagIntDataNode(TagNodeInt tag)
		: base(tag)
	{
	}

	public override bool Parse(string value)
	{
		if (!int.TryParse(value, out var result))
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
