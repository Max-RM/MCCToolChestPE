using System;

namespace FastColoredTextBoxNS;

public class LineInsertedEventArgs : EventArgs
{
	public int Index { get; private set; }

	public int Count { get; private set; }

	public LineInsertedEventArgs(int index, int count)
	{
		Index = index;
		Count = count;
	}
}
