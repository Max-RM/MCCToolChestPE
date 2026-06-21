using System;
using System.Windows.Forms;
using NBTModel.Interop;

namespace NBTExplorer.Windows;

public static class FormHandlers
{
	public static void Register()
	{
		FormRegistry.EditByteArray = EditByteArrayHandler;
		FormRegistry.EditString = EditStringHandler;
		FormRegistry.EditTagScalar = EditTagScalarValueHandler;
		FormRegistry.RenameTag = RenameTagHandler;
		FormRegistry.CreateNode = CreateNodeHandler;
		FormRegistry.MessageBox = MessageBoxHandler;
	}

	public static void MessageBoxHandler(string message)
	{
		MessageBox.Show(message);
	}

	public static bool EditStringHandler(StringFormData data)
	{
		EditString editString = new EditString(data.Value);
		if (editString.ShowDialog() == DialogResult.OK)
		{
			data.Value = editString.StringValue;
			return true;
		}
		return false;
	}

	public static bool RenameTagHandler(RestrictedStringFormData data)
	{
		EditName editName = new EditName(data.Value);
		editName.AllowEmpty = data.AllowEmpty;
		EditName editName2 = editName;
		editName2.InvalidNames.AddRange(data.RestrictedValues);
		if (editName2.ShowDialog() == DialogResult.OK && editName2.IsModified)
		{
			data.Value = editName2.TagName;
			return true;
		}
		return false;
	}

	public static bool EditTagScalarValueHandler(TagScalarFormData data)
	{
		EditValue editValue = new EditValue(data.Tag);
		if (editValue.ShowDialog() == DialogResult.OK)
		{
			return true;
		}
		return false;
	}

	public static bool EditByteArrayHandler(ByteArrayFormData data)
	{
		HexEditor hexEditor = new HexEditor(data.NodeName, data.Data, data.BytesPerElement);
		if (hexEditor.ShowDialog() == DialogResult.OK && hexEditor.Modified)
		{
			data.Data = new byte[hexEditor.Data.Length];
			Array.Copy(hexEditor.Data, data.Data, data.Data.Length);
			return true;
		}
		return false;
	}

	public static bool CreateNodeHandler(CreateTagFormData data)
	{
		CreateNodeForm createNodeForm = new CreateNodeForm(data.TagType, data.HasName);
		createNodeForm.InvalidNames.AddRange(data.RestrictedNames);
		if (createNodeForm.ShowDialog() == DialogResult.OK)
		{
			data.TagNode = createNodeForm.TagNode;
			data.TagName = createNodeForm.TagName;
			return true;
		}
		return false;
	}
}
