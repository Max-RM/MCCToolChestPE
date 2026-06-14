using System;

namespace FastColoredTextBoxNS;

public class TextChangedEventArgs : EventArgs
{
	public Range ChangedRange { get; set; }

	public TextChangedEventArgs(Range changedRange)
	{
		ChangedRange = changedRange;
	}
}
