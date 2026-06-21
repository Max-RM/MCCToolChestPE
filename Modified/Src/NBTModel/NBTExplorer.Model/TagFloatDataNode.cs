using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagFloatDataNode : TagDataNode
{
	protected new TagNodeFloat Tag => base.Tag as TagNodeFloat;

	public TagFloatDataNode(TagNodeFloat tag)
		: base(tag)
	{
	}

	public override bool Parse(string value)
	{
		if (!float.TryParse(value, out var result))
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
