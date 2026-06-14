using System;
using System.Collections.Generic;

namespace FastColoredTextBoxNS;

public class MultiRangeCommand : UndoableCommand
{
	private UndoableCommand cmd;

	private Range range;

	private List<UndoableCommand> commandsByRanges = new List<UndoableCommand>();

	public MultiRangeCommand(UndoableCommand command)
		: base(command.ts)
	{
		cmd = command;
		range = ts.CurrentTB.Selection.Clone();
	}

	public override void Execute()
	{
		commandsByRanges.Clear();
		Range range = this.range.Clone();
		int iChar = -1;
		int iLine = range.Start.iLine;
		int iLine2 = range.End.iLine;
		ts.CurrentTB.Selection.ColumnSelectionMode = false;
		ts.CurrentTB.Selection.BeginUpdate();
		ts.CurrentTB.BeginUpdate();
		ts.CurrentTB.AllowInsertRemoveLines = false;
		try
		{
			if (cmd is InsertTextCommand)
			{
				ExecuteInsertTextCommand(ref iChar, (cmd as InsertTextCommand).InsertedText);
			}
			else if (cmd is InsertCharCommand && (cmd as InsertCharCommand).c != 0 && (cmd as InsertCharCommand).c != '\b')
			{
				ExecuteInsertTextCommand(ref iChar, (cmd as InsertCharCommand).c.ToString());
			}
			else
			{
				ExecuteCommand(ref iChar);
			}
		}
		catch (ArgumentOutOfRangeException)
		{
		}
		finally
		{
			ts.CurrentTB.AllowInsertRemoveLines = true;
			ts.CurrentTB.EndUpdate();
			ts.CurrentTB.Selection = this.range;
			if (iChar >= 0)
			{
				ts.CurrentTB.Selection.Start = new Place(iChar, iLine);
				ts.CurrentTB.Selection.End = new Place(iChar, iLine2);
			}
			ts.CurrentTB.Selection.ColumnSelectionMode = true;
			ts.CurrentTB.Selection.EndUpdate();
		}
	}

	private void ExecuteInsertTextCommand(ref int iChar, string text)
	{
		string[] array = text.Split('\n');
		int num = 0;
		foreach (Range subRange in range.GetSubRanges(includeEmpty: true))
		{
			Line line = ts.CurrentTB[subRange.Start.iLine];
			if (!(subRange.End < subRange.Start) || line.StartSpacesCount != line.Count)
			{
				string text2 = array[num % array.Length];
				if (subRange.End < subRange.Start && text2 != "")
				{
					text2 = new string(' ', subRange.Start.iChar - subRange.End.iChar) + text2;
					subRange.Start = subRange.End;
				}
				ts.CurrentTB.Selection = subRange;
				InsertTextCommand insertTextCommand = new InsertTextCommand(ts, text2);
				insertTextCommand.Execute();
				if (ts.CurrentTB.Selection.End.iChar > iChar)
				{
					iChar = ts.CurrentTB.Selection.End.iChar;
				}
				commandsByRanges.Add(insertTextCommand);
			}
			num++;
		}
	}

	private void ExecuteCommand(ref int iChar)
	{
		foreach (Range subRange in range.GetSubRanges(includeEmpty: false))
		{
			ts.CurrentTB.Selection = subRange;
			UndoableCommand undoableCommand = cmd.Clone();
			undoableCommand.Execute();
			if (ts.CurrentTB.Selection.End.iChar > iChar)
			{
				iChar = ts.CurrentTB.Selection.End.iChar;
			}
			commandsByRanges.Add(undoableCommand);
		}
	}

	public override void Undo()
	{
		ts.CurrentTB.BeginUpdate();
		ts.CurrentTB.Selection.BeginUpdate();
		try
		{
			for (int num = commandsByRanges.Count - 1; num >= 0; num--)
			{
				commandsByRanges[num].Undo();
			}
		}
		finally
		{
			ts.CurrentTB.Selection.EndUpdate();
			ts.CurrentTB.EndUpdate();
		}
		ts.CurrentTB.Selection = range.Clone();
		ts.CurrentTB.OnTextChanged(range);
		ts.CurrentTB.OnSelectionChanged();
		ts.CurrentTB.Selection.ColumnSelectionMode = true;
	}

	public override UndoableCommand Clone()
	{
		throw new NotImplementedException();
	}
}
