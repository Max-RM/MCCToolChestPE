using System;
using System.Collections.Generic;

namespace FastColoredTextBoxNS;

public class ReplaceTextCommand : UndoableCommand
{
	private string insertedText;

	private List<Range> ranges;

	private List<string> prevText = new List<string>();

	public ReplaceTextCommand(TextSource ts, List<Range> ranges, string insertedText)
		: base(ts)
	{
		ranges.Sort((Range r1, Range r2) => (r1.Start.iLine == r2.Start.iLine) ? r1.Start.iChar.CompareTo(r2.Start.iChar) : r1.Start.iLine.CompareTo(r2.Start.iLine));
		this.ranges = ranges;
		this.insertedText = insertedText;
		lastSel = (sel = new RangeInfo(ts.CurrentTB.Selection));
	}

	public override void Undo()
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		ts.OnTextChanging();
		currentTB.BeginUpdate();
		currentTB.Selection.BeginUpdate();
		for (int i = 0; i < ranges.Count; i++)
		{
			currentTB.Selection.Start = ranges[i].Start;
			for (int j = 0; j < insertedText.Length; j++)
			{
				currentTB.Selection.GoRight(shift: true);
			}
			ClearSelected(ts);
			InsertTextCommand.InsertText(prevText[prevText.Count - i - 1], ts);
		}
		currentTB.Selection.EndUpdate();
		currentTB.EndUpdate();
		if (ranges.Count > 0)
		{
			ts.OnTextChanged(ranges[0].Start.iLine, ranges[ranges.Count - 1].End.iLine);
		}
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
	}

	public override void Execute()
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		prevText.Clear();
		ts.OnTextChanging(ref insertedText);
		currentTB.Selection.BeginUpdate();
		currentTB.BeginUpdate();
		for (int num = ranges.Count - 1; num >= 0; num--)
		{
			currentTB.Selection.Start = ranges[num].Start;
			currentTB.Selection.End = ranges[num].End;
			prevText.Add(currentTB.Selection.Text);
			ClearSelected(ts);
			if (insertedText != "")
			{
				InsertTextCommand.InsertText(insertedText, ts);
			}
		}
		if (ranges.Count > 0)
		{
			ts.OnTextChanged(ranges[0].Start.iLine, ranges[ranges.Count - 1].End.iLine);
		}
		currentTB.EndUpdate();
		currentTB.Selection.EndUpdate();
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
		lastSel = new RangeInfo(currentTB.Selection);
	}

	public override UndoableCommand Clone()
	{
		return new ReplaceTextCommand(ts, new List<Range>(ranges), insertedText);
	}

	internal static void ClearSelected(TextSource ts)
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		currentTB.Selection.Normalize();
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
				return;
			}
			ts[num].RemoveRange(fromX, ts[num].Count - fromX);
			ts[num2].RemoveRange(0, toX);
			ts.RemoveLine(num + 1, num2 - num - 1);
			InsertCharCommand.MergeLines(num, ts);
		}
	}
}
