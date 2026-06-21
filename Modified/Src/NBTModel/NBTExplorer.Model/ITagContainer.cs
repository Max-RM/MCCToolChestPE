using Substrate.Nbt;

namespace NBTExplorer.Model;

public interface ITagContainer
{
	int TagCount { get; }

	bool DeleteTag(TagNode tag);
}
