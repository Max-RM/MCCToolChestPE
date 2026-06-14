using System.Collections.Generic;

namespace NBTModel.Interop;

public class RestrictedStringFormData(string value) : StringFormData(value)
{
	private List<string> _restricted = new List<string>();

	public List<string> RestrictedValues => _restricted;
}
