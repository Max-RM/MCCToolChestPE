namespace Substrate.Nbt;

public sealed class TagNodeNull : TagNode
{
	public override TagNodeNull ToTagNull()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_END;
	}

	public override TagNode Copy()
	{
		return new TagNodeNull();
	}
}
