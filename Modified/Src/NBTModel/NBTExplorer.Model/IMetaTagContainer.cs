namespace NBTExplorer.Model;

public interface IMetaTagContainer : ITagContainer
{
	bool IsNamedContainer { get; }

	bool IsOrderedContainer { get; }

	INamedTagContainer NamedTagContainer { get; }

	IOrderedTagContainer OrderedTagContainer { get; }
}
