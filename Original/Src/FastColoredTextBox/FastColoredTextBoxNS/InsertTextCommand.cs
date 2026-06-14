namespace FastColoredTextBoxNS;

public class InsertTextCommand : UndoableCommand
{
	public string InsertedText;

	public InsertTextCommand(TextSource ts, string insertedText)
		: base(ts)
	{
		InsertedText = insertedText;
	}

	public override void Undo()
	{
		ts.CurrentTB.Selection.Start = sel.Start;
		ts.CurrentTB.Selection.End = lastSel.Start;
		ts.OnTextChanging();
		ClearSelectedCommand.ClearSelected(ts);
		base.Undo();
	}

	public override void Execute()
	{
		ts.OnTextChanging(ref InsertedText);
		InsertText(InsertedText, ts);
		base.Execute();
	}

	internal static void InsertText(string insertedText, TextSource ts)
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		try
		{
			currentTB.Selection.BeginUpdate();
			char deletedChar = '\0';
			if (ts.Count == 0)
			{
				InsertCharCommand.InsertLine(ts);
				currentTB.Selection.Start = Place.Empty;
			}
			currentTB.ExpandBlock(currentTB.Selection.Start.iLine);
			int length = insertedText.Length;
			for (int i = 0; i < length; i++)
			{
				char c = insertedText[i];
				if (c == '\r' && (i >= length - 1 || insertedText[i + 1] != '\n'))
				{
					InsertCharCommand.InsertChar('\n', ref deletedChar, ts);
				}
				else
				{
					InsertCharCommand.InsertChar(c, ref deletedChar, ts);
				}
			}
			ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
		}
		finally
		{
			currentTB.Selection.EndUpdate();
		}
	}

	public override UndoableCommand Clone()
	{
		return new InsertTextCommand(ts, InsertedText);
	}
}
