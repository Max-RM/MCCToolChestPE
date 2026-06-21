using System;

namespace FastColoredTextBoxNS;

public class SnippetAutocompleteItem : AutocompleteItem
{
	public SnippetAutocompleteItem(string snippet)
	{
		Text = snippet.Replace("\r", "");
		ToolTipTitle = "Code snippet:";
		ToolTipText = Text;
	}

	public override string ToString()
	{
		return MenuText ?? Text.Replace("\n", " ").Replace("^", "");
	}

	public override string GetTextForReplace()
	{
		return Text;
	}

	public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
	{
		e.Tb.BeginUpdate();
		e.Tb.Selection.BeginUpdate();
		Place start = popupMenu.Fragment.Start;
		Place start2 = e.Tb.Selection.Start;
		if (e.Tb.AutoIndent)
		{
			for (int i = start.iLine + 1; i <= start2.iLine; i++)
			{
				e.Tb.Selection.Start = new Place(0, i);
				e.Tb.DoAutoIndent(i);
			}
		}
		e.Tb.Selection.Start = start;
		while (e.Tb.Selection.CharBeforeStart != '^' && e.Tb.Selection.GoRightThroughFolded())
		{
		}
		e.Tb.Selection.GoLeft(shift: true);
		e.Tb.InsertText("");
		e.Tb.Selection.EndUpdate();
		e.Tb.EndUpdate();
	}

	public override CompareResult Compare(string fragmentText)
	{
		if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) && Text != fragmentText)
		{
			return CompareResult.Visible;
		}
		return CompareResult.Hidden;
	}
}
