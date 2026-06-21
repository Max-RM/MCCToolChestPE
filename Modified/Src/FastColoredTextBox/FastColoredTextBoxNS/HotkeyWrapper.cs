using System.Windows.Forms;

namespace FastColoredTextBoxNS;

internal class HotkeyWrapper
{
	private bool Ctrl;

	private bool Shift;

	private bool Alt;

	public string Modifiers
	{
		get
		{
			string text = "";
			if (Ctrl)
			{
				text += "Ctrl + ";
			}
			if (Shift)
			{
				text += "Shift + ";
			}
			if (Alt)
			{
				text += "Alt + ";
			}
			return text.Trim(' ', '+');
		}
		set
		{
			if (value == null)
			{
				Ctrl = (Alt = (Shift = false));
				return;
			}
			Ctrl = value.Contains("Ctrl");
			Shift = value.Contains("Shift");
			Alt = value.Contains("Alt");
		}
	}

	public Keys Key { get; set; }

	public FCTBAction Action { get; set; }

	public HotkeyWrapper(Keys keyData, FCTBAction action)
	{
		KeyEventArgs e = new KeyEventArgs(keyData);
		Ctrl = e.Control;
		Shift = e.Shift;
		Alt = e.Alt;
		Key = e.KeyCode;
		Action = action;
	}

	public Keys ToKeyData()
	{
		Keys keys = Key;
		if (Ctrl)
		{
			keys |= Keys.Control;
		}
		if (Alt)
		{
			keys |= Keys.Alt;
		}
		if (Shift)
		{
			keys |= Keys.Shift;
		}
		return keys;
	}
}
