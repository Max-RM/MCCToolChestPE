using System;

namespace FastColoredTextBoxNS;

public class CustomActionEventArgs : EventArgs
{
	public FCTBAction Action { get; private set; }

	public CustomActionEventArgs(FCTBAction action)
	{
		Action = action;
	}
}
