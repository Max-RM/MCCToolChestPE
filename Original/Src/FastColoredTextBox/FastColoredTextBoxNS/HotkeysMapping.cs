using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class HotkeysMapping : SortedDictionary<Keys, FCTBAction>
{
	public virtual void InitDefault()
	{
		base[System.Windows.Forms.Keys.G | System.Windows.Forms.Keys.Control] = FCTBAction.GoToDialog;
		base[System.Windows.Forms.Keys.F | System.Windows.Forms.Keys.Control] = FCTBAction.FindDialog;
		base[System.Windows.Forms.Keys.F | System.Windows.Forms.Keys.Alt] = FCTBAction.FindChar;
		base[System.Windows.Forms.Keys.F3] = FCTBAction.FindNext;
		base[System.Windows.Forms.Keys.H | System.Windows.Forms.Keys.Control] = FCTBAction.ReplaceDialog;
		base[System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control] = FCTBAction.Copy;
		base[System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.CommentSelected;
		base[System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Control] = FCTBAction.Cut;
		base[System.Windows.Forms.Keys.V | System.Windows.Forms.Keys.Control] = FCTBAction.Paste;
		base[System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control] = FCTBAction.SelectAll;
		base[System.Windows.Forms.Keys.Z | System.Windows.Forms.Keys.Control] = FCTBAction.Undo;
		base[System.Windows.Forms.Keys.R | System.Windows.Forms.Keys.Control] = FCTBAction.Redo;
		base[System.Windows.Forms.Keys.U | System.Windows.Forms.Keys.Control] = FCTBAction.UpperCase;
		base[System.Windows.Forms.Keys.U | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.LowerCase;
		base[System.Windows.Forms.Keys.OemMinus | System.Windows.Forms.Keys.Control] = FCTBAction.NavigateBackward;
		base[System.Windows.Forms.Keys.OemMinus | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.NavigateForward;
		base[System.Windows.Forms.Keys.B | System.Windows.Forms.Keys.Control] = FCTBAction.BookmarkLine;
		base[System.Windows.Forms.Keys.B | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.UnbookmarkLine;
		base[System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control] = FCTBAction.GoNextBookmark;
		base[System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoPrevBookmark;
		base[System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.Alt] = FCTBAction.Undo;
		base[System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.Control] = FCTBAction.ClearWordLeft;
		base[System.Windows.Forms.Keys.Insert] = FCTBAction.ReplaceMode;
		base[System.Windows.Forms.Keys.Insert | System.Windows.Forms.Keys.Control] = FCTBAction.Copy;
		base[System.Windows.Forms.Keys.Insert | System.Windows.Forms.Keys.Shift] = FCTBAction.Paste;
		base[System.Windows.Forms.Keys.Delete] = FCTBAction.DeleteCharRight;
		base[System.Windows.Forms.Keys.Delete | System.Windows.Forms.Keys.Control] = FCTBAction.ClearWordRight;
		base[System.Windows.Forms.Keys.Delete | System.Windows.Forms.Keys.Shift] = FCTBAction.Cut;
		base[System.Windows.Forms.Keys.Left] = FCTBAction.GoLeft;
		base[System.Windows.Forms.Keys.Left | System.Windows.Forms.Keys.Shift] = FCTBAction.GoLeftWithSelection;
		base[System.Windows.Forms.Keys.Left | System.Windows.Forms.Keys.Control] = FCTBAction.GoWordLeft;
		base[System.Windows.Forms.Keys.Left | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoWordLeftWithSelection;
		base[System.Windows.Forms.Keys.Left | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt] = FCTBAction.GoLeft_ColumnSelectionMode;
		base[System.Windows.Forms.Keys.Right] = FCTBAction.GoRight;
		base[System.Windows.Forms.Keys.Right | System.Windows.Forms.Keys.Shift] = FCTBAction.GoRightWithSelection;
		base[System.Windows.Forms.Keys.Right | System.Windows.Forms.Keys.Control] = FCTBAction.GoWordRight;
		base[System.Windows.Forms.Keys.Right | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoWordRightWithSelection;
		base[System.Windows.Forms.Keys.Right | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt] = FCTBAction.GoRight_ColumnSelectionMode;
		base[System.Windows.Forms.Keys.Up] = FCTBAction.GoUp;
		base[System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Shift] = FCTBAction.GoUpWithSelection;
		base[System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt] = FCTBAction.GoUp_ColumnSelectionMode;
		base[System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Alt] = FCTBAction.MoveSelectedLinesUp;
		base[System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Control] = FCTBAction.ScrollUp;
		base[System.Windows.Forms.Keys.Down] = FCTBAction.GoDown;
		base[System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Shift] = FCTBAction.GoDownWithSelection;
		base[System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt] = FCTBAction.GoDown_ColumnSelectionMode;
		base[System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Alt] = FCTBAction.MoveSelectedLinesDown;
		base[System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Control] = FCTBAction.ScrollDown;
		base[System.Windows.Forms.Keys.Prior] = FCTBAction.GoPageUp;
		base[System.Windows.Forms.Keys.Prior | System.Windows.Forms.Keys.Shift] = FCTBAction.GoPageUpWithSelection;
		base[System.Windows.Forms.Keys.Next] = FCTBAction.GoPageDown;
		base[System.Windows.Forms.Keys.Next | System.Windows.Forms.Keys.Shift] = FCTBAction.GoPageDownWithSelection;
		base[System.Windows.Forms.Keys.Home] = FCTBAction.GoHome;
		base[System.Windows.Forms.Keys.Home | System.Windows.Forms.Keys.Shift] = FCTBAction.GoHomeWithSelection;
		base[System.Windows.Forms.Keys.Home | System.Windows.Forms.Keys.Control] = FCTBAction.GoFirstLine;
		base[System.Windows.Forms.Keys.Home | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoFirstLineWithSelection;
		base[System.Windows.Forms.Keys.End] = FCTBAction.GoEnd;
		base[System.Windows.Forms.Keys.End | System.Windows.Forms.Keys.Shift] = FCTBAction.GoEndWithSelection;
		base[System.Windows.Forms.Keys.End | System.Windows.Forms.Keys.Control] = FCTBAction.GoLastLine;
		base[System.Windows.Forms.Keys.End | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoLastLineWithSelection;
		base[System.Windows.Forms.Keys.Escape] = FCTBAction.ClearHints;
		base[System.Windows.Forms.Keys.M | System.Windows.Forms.Keys.Control] = FCTBAction.MacroRecord;
		base[System.Windows.Forms.Keys.E | System.Windows.Forms.Keys.Control] = FCTBAction.MacroExecute;
		base[System.Windows.Forms.Keys.Space | System.Windows.Forms.Keys.Control] = FCTBAction.AutocompleteMenu;
		base[System.Windows.Forms.Keys.Tab] = FCTBAction.IndentIncrease;
		base[System.Windows.Forms.Keys.Tab | System.Windows.Forms.Keys.Shift] = FCTBAction.IndentDecrease;
		base[System.Windows.Forms.Keys.Subtract | System.Windows.Forms.Keys.Control] = FCTBAction.ZoomOut;
		base[System.Windows.Forms.Keys.Add | System.Windows.Forms.Keys.Control] = FCTBAction.ZoomIn;
		base[System.Windows.Forms.Keys.D0 | System.Windows.Forms.Keys.Control] = FCTBAction.ZoomNormal;
		base[System.Windows.Forms.Keys.I | System.Windows.Forms.Keys.Control] = FCTBAction.AutoIndentChars;
	}

	public override string ToString()
	{
		CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
		StringBuilder stringBuilder = new StringBuilder();
		KeysConverter keysConverter = new KeysConverter();
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<Keys, FCTBAction> current = enumerator.Current;
				stringBuilder.AppendFormat("{0}={1}, ", keysConverter.ConvertToString(current.Key), current.Value);
			}
		}
		if (stringBuilder.Length > 1)
		{
			stringBuilder.Remove(stringBuilder.Length - 2, 2);
		}
		Thread.CurrentThread.CurrentUICulture = currentUICulture;
		return stringBuilder.ToString();
	}

	public static HotkeysMapping Parse(string s)
	{
		HotkeysMapping hotkeysMapping = new HotkeysMapping();
		hotkeysMapping.Clear();
		CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
		KeysConverter keysConverter = new KeysConverter();
		string[] array = s.Split(',');
		foreach (string text in array)
		{
			string[] array2 = text.Split('=');
			Keys key = (Keys)keysConverter.ConvertFromString(array2[0].Trim());
			FCTBAction value = (FCTBAction)Enum.Parse(typeof(FCTBAction), array2[1].Trim());
			hotkeysMapping[key] = value;
		}
		Thread.CurrentThread.CurrentUICulture = currentUICulture;
		return hotkeysMapping;
	}
}
