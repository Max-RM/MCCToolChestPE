using System.Collections.Generic;

namespace FastColoredTextBoxNS;

public class ReplaceMultipleTextCommand : UndoableCommand
{
	public class ReplaceRange
	{
		public Range ReplacedRange { get; set; }

		public string ReplaceText { get; set; }
	}

	private List<ReplaceRange> ranges;

	private List<string> prevText = new List<string>();

	public ReplaceMultipleTextCommand(TextSource ts, List<ReplaceRange> ranges)
		: base(ts)
	{
		ranges.Sort((ReplaceRange r1, ReplaceRange r2) => (r1.ReplacedRange.Start.iLine == r2.ReplacedRange.Start.iLine) ? r1.ReplacedRange.Start.iChar.CompareTo(r2.ReplacedRange.Start.iChar) : r1.ReplacedRange.Start.iLine.CompareTo(r2.ReplacedRange.Start.iLine));
		this.ranges = ranges;
		lastSel = (sel = new RangeInfo(ts.CurrentTB.Selection));
	}

	public override void Undo()
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		ts.OnTextChanging();
		currentTB.Selection.BeginUpdate();
		for (int i = 0; i < ranges.Count; i++)
		{
			currentTB.Selection.Start = ranges[i].ReplacedRange.Start;
			for (int j = 0; j < ranges[i].ReplaceText.Length; j++)
			{
				currentTB.Selection.GoRight(shift: true);
			}
			ClearSelectedCommand.ClearSelected(ts);
			int index = ranges.Count - 1 - i;
			InsertTextCommand.InsertText(prevText[index], ts);
			ts.OnTextChanged(ranges[i].ReplacedRange.Start.iLine, ranges[i].ReplacedRange.Start.iLine);
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
		for (int num = ranges.Count - 1; num >= 0; num--)
		{
			currentTB.Selection.Start = ranges[num].ReplacedRange.Start;
			currentTB.Selection.End = ranges[num].ReplacedRange.End;
			prevText.Add(currentTB.Selection.Text);
			ClearSelectedCommand.ClearSelected(ts);
			InsertTextCommand.InsertText(ranges[num].ReplaceText, ts);
			ts.OnTextChanged(ranges[num].ReplacedRange.Start.iLine, ranges[num].ReplacedRange.End.iLine);
		}
		currentTB.Selection.EndUpdate();
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
		lastSel = new RangeInfo(currentTB.Selection);
	}

	public override UndoableCommand Clone()
	{
		return new ReplaceMultipleTextCommand(ts, new List<ReplaceRange>(ranges));
	}
}
