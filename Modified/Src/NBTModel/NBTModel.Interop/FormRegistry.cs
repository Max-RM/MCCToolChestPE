using System;

namespace NBTModel.Interop;

public static class FormRegistry
{
	public delegate bool EditStringAction(StringFormData data);

	public delegate bool EditRestrictedStringAction(RestrictedStringFormData data);

	public delegate bool EditTagScalarAction(TagScalarFormData data);

	public delegate bool EditByteArrayAction(ByteArrayFormData data);

	public delegate bool CreateNodeAction(CreateTagFormData data);

	public static EditStringAction EditString { get; set; }

	public static EditRestrictedStringAction RenameTag { get; set; }

	public static EditTagScalarAction EditTagScalar { get; set; }

	public static EditByteArrayAction EditByteArray { get; set; }

	public static CreateNodeAction CreateNode { get; set; }

	public static Action<string> MessageBox { get; set; }
}
