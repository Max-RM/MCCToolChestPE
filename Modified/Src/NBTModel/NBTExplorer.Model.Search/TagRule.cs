using Substrate.Nbt;

namespace NBTExplorer.Model.Search;

public abstract class TagRule : SearchRule
{
	public TagType TagType { get; set; }

	public string Name { get; set; }

	protected T LookupTag<T>(TagCompoundDataNode container, string name) where T : TagNode
	{
		return container.NamedTagContainer.GetTagNode(name) as T;
	}
}
