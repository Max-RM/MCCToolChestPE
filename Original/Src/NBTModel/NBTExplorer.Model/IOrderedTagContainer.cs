using Substrate.Nbt;

namespace NBTExplorer.Model;

public interface IOrderedTagContainer : ITagContainer
{
	int GetTagIndex(TagNode tag);

	bool InsertTag(TagNode tag, int index);

	bool AppendTag(TagNode tag);
}
