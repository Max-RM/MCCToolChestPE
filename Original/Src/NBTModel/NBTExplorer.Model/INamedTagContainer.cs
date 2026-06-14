using System.Collections.Generic;
using Substrate.Nbt;

namespace NBTExplorer.Model;

public interface INamedTagContainer : ITagContainer
{
	IEnumerable<string> TagNamesInUse { get; }

	string GetTagName(TagNode tag);

	TagNode GetTagNode(string name);

	bool AddTag(TagNode tag, string name);

	bool RenameTag(TagNode tag, string name);

	bool ContainsTag(string name);

	bool DeleteTag(string name);
}
