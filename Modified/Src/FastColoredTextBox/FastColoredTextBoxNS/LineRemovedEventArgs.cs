using System;
using System.Collections.Generic;

namespace FastColoredTextBoxNS;

public class LineRemovedEventArgs : EventArgs
{
	public int Index { get; private set; }

	public int Count { get; private set; }

	public List<int> RemovedLineUniqueIds { get; private set; }

	public LineRemovedEventArgs(int index, int count, List<int> removedLineIds)
	{
		Index = index;
		Count = count;
		RemovedLineUniqueIds = removedLineIds;
	}
}
