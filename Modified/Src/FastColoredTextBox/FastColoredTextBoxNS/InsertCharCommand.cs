using System;

namespace FastColoredTextBoxNS;

public class InsertCharCommand : UndoableCommand
{
	public char c;

	private char deletedChar = '\0';

	public InsertCharCommand(TextSource ts, char c)
		: base(ts)
	{
		this.c = c;
	}

	public override void Undo()
	{
		ts.OnTextChanging();
		switch (this.c)
		{
		case '\n':
			MergeLines(sel.Start.iLine, ts);
			break;
		case '\b':
		{
			ts.CurrentTB.Selection.Start = lastSel.Start;
			char c = '\0';
			if (deletedChar != 0)
			{
				ts.CurrentTB.ExpandBlock(ts.CurrentTB.Selection.Start.iLine);
				InsertChar(deletedChar, ref c, ts);
			}
			break;
		}
		case '\t':
		{
			ts.CurrentTB.ExpandBlock(sel.Start.iLine);
			for (int i = sel.FromX; i < lastSel.FromX; i++)
			{
				ts[sel.Start.iLine].RemoveAt(sel.Start.iChar);
			}
			ts.CurrentTB.Selection.Start = sel.Start;
			break;
		}
		default:
			ts.CurrentTB.ExpandBlock(sel.Start.iLine);
			ts[sel.Start.iLine].RemoveAt(sel.Start.iChar);
			ts.CurrentTB.Selection.Start = sel.Start;
			break;
		case '\r':
			break;
		}
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(sel.Start.iLine, sel.Start.iLine));
		base.Undo();
	}

	public override void Execute()
	{
		ts.CurrentTB.ExpandBlock(ts.CurrentTB.Selection.Start.iLine);
		string text = c.ToString();
		ts.OnTextChanging(ref text);
		if (text.Length == 1)
		{
			c = text[0];
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentOutOfRangeException();
		}
		if (ts.Count == 0)
		{
			InsertLine(ts);
		}
		InsertChar(c, ref deletedChar, ts);
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(ts.CurrentTB.Selection.Start.iLine, ts.CurrentTB.Selection.Start.iLine));
		base.Execute();
	}

	internal static void InsertChar(char c, ref char deletedChar, TextSource ts)
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		switch (c)
		{
		case '\n':
			if (!ts.CurrentTB.AllowInsertRemoveLines)
			{
				throw new ArgumentOutOfRangeException("Cant insert this char in ColumnRange mode");
			}
			if (ts.Count == 0)
			{
				InsertLine(ts);
			}
			InsertLine(ts);
			break;
		case '\r':
			break;
		case '\b':
			if (currentTB.Selection.Start.iChar == 0 && currentTB.Selection.Start.iLine == 0)
			{
				break;
			}
			if (currentTB.Selection.Start.iChar == 0)
			{
				if (!ts.CurrentTB.AllowInsertRemoveLines)
				{
					throw new ArgumentOutOfRangeException("Cant insert this char in ColumnRange mode");
				}
				if (currentTB.LineInfos[currentTB.Selection.Start.iLine - 1].VisibleState != VisibleState.Visible)
				{
					currentTB.ExpandBlock(currentTB.Selection.Start.iLine - 1);
				}
				deletedChar = '\n';
				MergeLines(currentTB.Selection.Start.iLine - 1, ts);
			}
			else
			{
				deletedChar = ts[currentTB.Selection.Start.iLine][currentTB.Selection.Start.iChar - 1].c;
				ts[currentTB.Selection.Start.iLine].RemoveAt(currentTB.Selection.Start.iChar - 1);
				currentTB.Selection.Start = new Place(currentTB.Selection.Start.iChar - 1, currentTB.Selection.Start.iLine);
			}
			break;
		case '\t':
		{
			int num = currentTB.TabLength - currentTB.Selection.Start.iChar % currentTB.TabLength;
			if (num == 0)
			{
				num = currentTB.TabLength;
			}
			for (int i = 0; i < num; i++)
			{
				ts[currentTB.Selection.Start.iLine].Insert(currentTB.Selection.Start.iChar, new Char(' '));
			}
			currentTB.Selection.Start = new Place(currentTB.Selection.Start.iChar + num, currentTB.Selection.Start.iLine);
			break;
		}
		default:
			ts[currentTB.Selection.Start.iLine].Insert(currentTB.Selection.Start.iChar, new Char(c));
			currentTB.Selection.Start = new Place(currentTB.Selection.Start.iChar + 1, currentTB.Selection.Start.iLine);
			break;
		}
	}

	internal static void InsertLine(TextSource ts)
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		if (currentTB.Multiline || currentTB.LinesCount <= 0)
		{
			if (ts.Count == 0)
			{
				ts.InsertLine(0, ts.CreateLine());
			}
			else
			{
				BreakLines(currentTB.Selection.Start.iLine, currentTB.Selection.Start.iChar, ts);
			}
			currentTB.Selection.Start = new Place(0, currentTB.Selection.Start.iLine + 1);
			ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
		}
	}

	internal static void MergeLines(int i, TextSource ts)
	{
		FastColoredTextBox currentTB = ts.CurrentTB;
		if (i + 1 < ts.Count)
		{
			currentTB.ExpandBlock(i);
			currentTB.ExpandBlock(i + 1);
			int count = ts[i].Count;
			if (ts[i + 1].Count == 0)
			{
				ts.RemoveLine(i + 1);
			}
			else
			{
				ts[i].AddRange(ts[i + 1]);
				ts.RemoveLine(i + 1);
			}
			currentTB.Selection.Start = new Place(count, i);
			ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
		}
	}

	internal static void BreakLines(int iLine, int pos, TextSource ts)
	{
		Line line = ts.CreateLine();
		for (int i = pos; i < ts[iLine].Count; i++)
		{
			line.Add(ts[iLine][i]);
		}
		ts[iLine].RemoveRange(pos, ts[iLine].Count - pos);
		ts.InsertLine(iLine + 1, line);
	}

	public override UndoableCommand Clone()
	{
		return new InsertCharCommand(ts, c);
	}
}
