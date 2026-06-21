namespace FastColoredTextBoxNS;

public abstract class UndoableCommand : Command
{
	internal RangeInfo sel;

	internal RangeInfo lastSel;

	internal bool autoUndo;

	public UndoableCommand(TextSource ts)
	{
		base.ts = ts;
		sel = new RangeInfo(ts.CurrentTB.Selection);
	}

	public virtual void Undo()
	{
		OnTextChanged(invert: true);
	}

	public override void Execute()
	{
		lastSel = new RangeInfo(ts.CurrentTB.Selection);
		OnTextChanged(invert: false);
	}

	protected virtual void OnTextChanged(bool invert)
	{
		bool flag = sel.Start.iLine < lastSel.Start.iLine;
		if (invert)
		{
			if (flag)
			{
				ts.OnTextChanged(sel.Start.iLine, sel.Start.iLine);
			}
			else
			{
				ts.OnTextChanged(sel.Start.iLine, lastSel.Start.iLine);
			}
		}
		else if (flag)
		{
			ts.OnTextChanged(sel.Start.iLine, lastSel.Start.iLine);
		}
		else
		{
			ts.OnTextChanged(lastSel.Start.iLine, lastSel.Start.iLine);
		}
	}

	public abstract UndoableCommand Clone();
}
