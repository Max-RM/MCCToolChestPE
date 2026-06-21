using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagShortDataNode : TagDataNode
{
	protected new TagNodeShort Tag => base.Tag as TagNodeShort;

	public TagShortDataNode(TagNodeShort tag)
		: base(tag)
	{
	}

	public override bool Parse(string value)
	{
		if (!short.TryParse(value, out var result))
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
