namespace NBTModel.Interop;

public class StringFormData
{
	public string Value { get; set; }

	public bool AllowEmpty { get; set; }

	public StringFormData(string value)
	{
		Value = value;
	}
}
