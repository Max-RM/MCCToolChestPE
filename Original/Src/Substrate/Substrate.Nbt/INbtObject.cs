namespace Substrate.Nbt;

public interface INbtObject<T>
{
	T LoadTree(TagNode tree);

	T LoadTreeSafe(TagNode tree);

	TagNode BuildTree();

	bool ValidateTree(TagNode tree);
}
