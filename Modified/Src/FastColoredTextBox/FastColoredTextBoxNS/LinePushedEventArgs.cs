using System;

namespace FastColoredTextBoxNS;

public class LinePushedEventArgs : EventArgs
{
	public string SourceLineText { get; private set; }

	public int DisplayedLineIndex { get; private set; }

	public string DisplayedLineText { get; private set; }

	public string SavedText { get; set; }

	public LinePushedEventArgs(string sourceLineText, int displayedLineIndex, string displayedLineText)
	{
		SourceLineText = sourceLineText;
		DisplayedLineIndex = displayedLineIndex;
		DisplayedLineText = displayedLineText;
		SavedText = displayedLineText;
	}
}
