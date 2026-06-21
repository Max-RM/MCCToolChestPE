using System;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class ToolTipNeededEventArgs : EventArgs
{
	public Place Place { get; private set; }

	public string HoveredWord { get; private set; }

	public string ToolTipTitle { get; set; }

	public string ToolTipText { get; set; }

	public ToolTipIcon ToolTipIcon { get; set; }

	public ToolTipNeededEventArgs(Place place, string hoveredWord)
	{
		HoveredWord = hoveredWord;
		Place = place;
	}
}
