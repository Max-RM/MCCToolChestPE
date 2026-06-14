using System.Collections.Generic;
using Substrate.Nbt;

namespace NBTModel.Interop;

public class CreateTagFormData
{
	public TagType TagType { get; set; }

	public bool HasName { get; set; }

	public List<string> RestrictedNames { get; private set; }

	public TagNode TagNode { get; set; }

	public string TagName { get; set; }

	public CreateTagFormData()
	{
		RestrictedNames = new List<string>();
	}
}
