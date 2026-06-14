using Substrate.Nbt;

namespace NBTModel.Interop;

public class TagScalarFormData
{
	public TagNode Tag { get; private set; }

	public TagScalarFormData(TagNode tag)
	{
		Tag = tag;
	}
}
