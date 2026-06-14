using System.Collections.Generic;

namespace FastColoredTextBoxNS;

public class RemoveLinesCommand : UndoableCommand
{
	private List<int> iLines;

	private List<string> prevText = new List<string>();

	public RemoveLinesCommand(TextSource ts, List<int> iLines)
		: base(ts)
	{
		iLines.Sort();
		this.iLines = iLines;
		lastSel = (sel = new RangeInfo(ts.CurrentTB.Selection));
	}

	public override void Undo()
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		ts.OnTextChanging();
		currentTB.Selection.BeginUpdate();
		for (int i = 0; i < iLines.Count; i++)
		{
			int num = iLines[i];
			if (num < ts.Count)
			{
				currentTB.Selection.Start = new Place(0, num);
			}
			else
			{
				currentTB.Selection.Start = new Place(ts[ts.Count - 1].Count, ts.Count - 1);
			}
			InsertCharCommand.InsertLine(ts);
			currentTB.Selection.Start = new Place(0, num);
			string text = prevText[prevText.Count - i - 1];
			InsertTextCommand.InsertText(text, ts);
			ts[num].IsChanged = true;
			if (num < ts.Count - 1)
			{
				ts[num + 1].IsChanged = true;
			}
			else
			{
				ts[num - 1].IsChanged = true;
			}
			if (text.Trim() != string.Empty)
			{
				ts.OnTextChanged(num, num);
			}
		}
		currentTB.Selection.EndUpdate();
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
	}

	public override void Execute()
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		prevText.Clear();
		ts.OnTextChanging();
		currentTB.Selection.BeginUpdate();
		for (int num = iLines.Count - 1; num >= 0; num--)
		{
			int num2 = iLines[num];
			prevText.Add(ts[num2].Text);
			ts.RemoveLine(num2);
		}
		currentTB.Selection.Start = new Place(0, 0);
		currentTB.Selection.EndUpdate();
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
		lastSel = new RangeInfo(currentTB.Selection);
	}

	public override UndoableCommand Clone()
	{
		return new RemoveLinesCommand(ts, new List<int>(iLines));
	}
}
