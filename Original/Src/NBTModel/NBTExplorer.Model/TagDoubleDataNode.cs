using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagDoubleDataNode : TagDataNode
{
	protected new TagNodeDouble Tag => base.Tag as TagNodeDouble;

	public TagDoubleDataNode(TagNodeDouble tag)
		: base(tag)
	{
	}

	public override bool Parse(string value)
	{
		if (!double.TryParse(value, out var result))
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
