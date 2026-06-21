using System;

namespace FastColoredTextBoxNS;

public class ClearSelectedCommand : UndoableCommand
{
	private string deletedText;

	public ClearSelectedCommand(TextSource ts)
		: base(ts)
	{
	}

	public override void Undo()
	{
		ts.CurrentTB.Selection.Start = new Place(sel.FromX, Math.Min(sel.Start.iLine, sel.End.iLine));
		ts.OnTextChanging();
		InsertTextCommand.InsertText(deletedText, ts);
		ts.OnTextChanged(sel.Start.iLine, sel.End.iLine);
		ts.CurrentTB.Selection.Start = sel.Start;
		ts.CurrentTB.Selection.End = sel.End;
	}

	public override void Execute()
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		string text = null;
		ts.OnTextChanging(ref text);
		if (text == "")
		{
			throw new ArgumentOutOfRangeException();
		}
		deletedText = currentTB.Selection.Text;
		ClearSelected(ts);
		lastSel = new RangeInfo(currentTB.Selection);
		ts.OnTextChanged(lastSel.Start.iLine, lastSel.Start.iLine);
	}

	internal static void ClearSelected(TextSource ts)
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		Place start = currentTB.Selection.Start;
		Place end = currentTB.Selection.End;
		int num = Math.Min(end.iLine, start.iLine);
		int num2 = Math.Max(end.iLine, start.iLine);
		int fromX = currentTB.Selection.FromX;
		int toX = currentTB.Selection.ToX;
		if (num >= 0)
		{
			if (num == num2)
			{
				ts[num].RemoveRange(fromX, toX - fromX);
			}
			else
			{
				ts[num].RemoveRange(fromX, ts[num].Count - fromX);
				ts[num2].RemoveRange(0, toX);
				ts.RemoveLine(num + 1, num2 - num - 1);
				InsertCharCommand.MergeLines(num, ts);
			}
			currentTB.Selection.Start = new Place(fromX, num);
			ts.NeedRecalc(new TextSource.TextChangedEventArgs(num, num2));
		}
	}

	public override UndoableCommand Clone()
	{
		return new ClearSelectedCommand(ts);
	}
}
