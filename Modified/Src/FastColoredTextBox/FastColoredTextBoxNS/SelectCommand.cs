namespace FastColoredTextBoxNS;

public class SelectCommand : UndoableCommand
{
	public SelectCommand(TextSource ts)
		: base(ts)
	{
	}

	public override void Execute()
	{
		lastSel = new RangeInfo(ts.CurrentTB.Selection);
	}

	protected override void OnTextChanged(bool invert)
	{
	}

	public override void Undo()
	{
		ts.CurrentTB.Selection = new Range(ts.CurrentTB, lastSel.Start, lastSel.End);
	}

	public override UndoableCommand Clone()
	{
		SelectCommand selectCommand = new SelectCommand(ts);
		if (lastSel != null)
		{
			selectCommand.lastSel = new RangeInfo(new Range(ts.CurrentTB, lastSel.Start, lastSel.End));
		}
		return selectCommand;
	}
}
