using System;

namespace FastColoredTextBoxNS;

public class AutoIndentEventArgs : EventArgs
{
	public int iLine { get; internal set; }

	public int TabLength { get; internal set; }

	public string LineText { get; internal set; }

	public string PrevLineText { get; internal set; }

	public int Shift { get; set; }

	public int ShiftNextLines { get; set; }

	public int AbsoluteIndentation { get; set; }

	public AutoIndentEventArgs(int iLine, string lineText, string prevLineText, int tabLength, int currentIndentation)
	{
		this.iLine = iLine;
		LineText = lineText;
		PrevLineText = prevLineText;
		TabLength = tabLength;
		AbsoluteIndentation = currentIndentation;
	}
}
