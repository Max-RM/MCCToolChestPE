using System.Collections.Generic;

namespace FastColoredTextBoxNS;

public struct LineInfo(int startY)
{
	private List<int> cutOffPositions = null;

	internal int startY = startY;

	internal int bottomPadding = 0;

	internal int wordWrapIndent = 0;

	public VisibleState VisibleState = VisibleState.Visible;

	public List<int> CutOffPositions
	{
		get
		{
			if (cutOffPositions == null)
			{
				cutOffPositions = new List<int>();
			}
			return cutOffPositions;
		}
	}

	public int WordWrapStringsCount
	{
		get
		{
			switch (VisibleState)
			{
			case VisibleState.Visible:
				if (cutOffPositions == null)
				{
					return 1;
				}
				return cutOffPositions.Count + 1;
			case VisibleState.Hidden:
				return 0;
			case VisibleState.StartOfHiddenBlock:
				return 1;
			default:
				return 0;
			}
		}
	}

	internal int GetWordWrapStringStartPosition(int iWordWrapLine)
	{
		return (iWordWrapLine != 0) ? CutOffPositions[iWordWrapLine - 1] : 0;
	}

	internal int GetWordWrapStringFinishPosition(int iWordWrapLine, Line line)
	{
		if (WordWrapStringsCount <= 0)
		{
			return 0;
		}
		return (iWordWrapLine == WordWrapStringsCount - 1) ? (line.Count - 1) : (CutOffPositions[iWordWrapLine] - 1);
	}

	public int GetWordWrapStringIndex(int iChar)
	{
		if (cutOffPositions == null || cutOffPositions.Count == 0)
		{
			return 0;
		}
		for (int i = 0; i < cutOffPositions.Count; i++)
		{
			if (cutOffPositions[i] > iChar)
			{
				return i;
			}
		}
		return cutOffPositions.Count;
	}
}
