using System;

namespace FastColoredTextBoxNS;

public class TextChangingEventArgs : EventArgs
{
	public string InsertingText { get; set; }

	public bool Cancel { get; set; }
}
