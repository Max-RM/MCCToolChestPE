using System;
using System.Collections.Generic;

namespace FastColoredTextBoxNS;

public class CommandManager
{
	private readonly int maxHistoryLength = 200;

	private LimitedStack<UndoableCommand> history;

	private Stack<UndoableCommand> redoStack = new Stack<UndoableCommand>();

	protected int disabledCommands = 0;

	private int autoUndoCommands = 0;

	public TextSource TextSource { get; private set; }

	public bool UndoRedoStackIsEnabled { get; set; }

	public bool UndoEnabled => history.Count > 0;

	public bool RedoEnabled => redoStack.Count > 0;

	public event EventHandler RedoCompleted = delegate
	{
	};

	public CommandManager(TextSource ts)
	{
		history = new LimitedStack<UndoableCommand>(maxHistoryLength);
		TextSource = ts;
		UndoRedoStackIsEnabled = true;
	}

	public virtual void ExecuteCommand(Command cmd)
	{
		if (disabledCommands > 0)
		{
			return;
		}
		if (cmd.ts.CurrentTB.Selection.ColumnSelectionMode && cmd is UndoableCommand)
		{
			cmd = new MultiRangeCommand((UndoableCommand)cmd);
		}
		if (cmd is UndoableCommand)
		{
			(cmd as UndoableCommand).autoUndo = autoUndoCommands > 0;
			history.Push(cmd as UndoableCommand);
		}
		try
		{
			cmd.Execute();
		}
		catch (ArgumentOutOfRangeException)
		{
			if (cmd is UndoableCommand)
			{
				history.Pop();
			}
		}
		if (!UndoRedoStackIsEnabled)
		{
			ClearHistory();
		}
		redoStack.Clear();
		TextSource.CurrentTB.OnUndoRedoStateChanged();
	}

	public void Undo()
	{
		if (history.Count > 0)
		{
			UndoableCommand undoableCommand = history.Pop();
			BeginDisableCommands();
			try
			{
				undoableCommand.Undo();
			}
			finally
			{
				EndDisableCommands();
			}
			redoStack.Push(undoableCommand);
		}
		if (history.Count > 0 && history.Peek().autoUndo)
		{
			Undo();
		}
		TextSource.CurrentTB.OnUndoRedoStateChanged();
	}

	private void EndDisableCommands()
	{
		disabledCommands--;
	}

	private void BeginDisableCommands()
	{
		disabledCommands++;
	}

	public void EndAutoUndoCommands()
	{
		autoUndoCommands--;
		if (autoUndoCommands == 0 && history.Count > 0)
		{
			history.Peek().autoUndo = false;
		}
	}

	public void BeginAutoUndoCommands()
	{
		autoUndoCommands++;
	}

	internal void ClearHistory()
	{
		history.Clear();
		redoStack.Clear();
		TextSource.CurrentTB.OnUndoRedoStateChanged();
	}

	internal void Redo()
	{
		if (redoStack.Count == 0)
		{
			return;
		}
		BeginDisableCommands();
		UndoableCommand undoableCommand;
		try
		{
			undoableCommand = redoStack.Pop();
			if (TextSource.CurrentTB.Selection.ColumnSelectionMode)
			{
				TextSource.CurrentTB.Selection.ColumnSelectionMode = false;
			}
			TextSource.CurrentTB.Selection.Start = undoableCommand.sel.Start;
			TextSource.CurrentTB.Selection.End = undoableCommand.sel.End;
			undoableCommand.Execute();
			history.Push(undoableCommand);
		}
		finally
		{
			EndDisableCommands();
		}
		this.RedoCompleted(this, EventArgs.Empty);
		if (undoableCommand.autoUndo)
		{
			Redo();
		}
		TextSource.CurrentTB.OnUndoRedoStateChanged();
	}
}
