using System;

namespace FastColoredTextBoxNS;

public class HintClickEventArgs : EventArgs
{
	public Hint Hint { get; private set; }

	public HintClickEventArgs(Hint hint)
	{
		Hint = hint;
	}
}
