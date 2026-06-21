using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class Hints : ICollection<Hint>, IEnumerable<Hint>, IEnumerable, IDisposable
{
	private FastColoredTextBox tb;

	private List<Hint> items = new List<Hint>();

	public int Count => items.Count;

	public bool IsReadOnly => false;

	public Hints(FastColoredTextBox tb)
	{
		this.tb = tb;
		tb.TextChanged += OnTextBoxTextChanged;
		tb.KeyDown += OnTextBoxKeyDown;
		tb.VisibleRangeChanged += OnTextBoxVisibleRangeChanged;
	}

	protected virtual void OnTextBoxKeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && e.Modifiers == Keys.None)
		{
			Clear();
		}
	}

	protected virtual void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
	{
		Clear();
	}

	public void Dispose()
	{
		tb.TextChanged -= OnTextBoxTextChanged;
		tb.KeyDown -= OnTextBoxKeyDown;
		tb.VisibleRangeChanged -= OnTextBoxVisibleRangeChanged;
	}

	private void OnTextBoxVisibleRangeChanged(object sender, EventArgs e)
	{
		if (items.Count == 0)
		{
			return;
		}
		tb.NeedRecalc(forced: true);
		foreach (Hint item in items)
		{
			LayoutHint(item);
			item.HostPanel.Invalidate();
		}
	}

	private void LayoutHint(Hint hint)
	{
		if (hint.Inline)
		{
			if (hint.Range.Start.iLine < tb.LineInfos.Count - 1)
			{
				hint.HostPanel.Top = tb.LineInfos[hint.Range.Start.iLine + 1].startY - hint.TopPadding - hint.HostPanel.Height - tb.VerticalScroll.Value;
			}
			else
			{
				hint.HostPanel.Top = tb.TextHeight + tb.Paddings.Top - hint.HostPanel.Height - tb.VerticalScroll.Value;
			}
		}
		else
		{
			if (hint.Range.Start.iLine > tb.LinesCount - 1)
			{
				return;
			}
			if (hint.Range.Start.iLine == tb.LinesCount - 1)
			{
				int num = tb.LineInfos[hint.Range.Start.iLine].startY - tb.VerticalScroll.Value + tb.CharHeight;
				if (num + hint.HostPanel.Height + 1 > tb.ClientRectangle.Bottom)
				{
					hint.HostPanel.Top = Math.Max(0, tb.LineInfos[hint.Range.Start.iLine].startY - tb.VerticalScroll.Value - hint.HostPanel.Height);
				}
				else
				{
					hint.HostPanel.Top = num;
				}
			}
			else
			{
				hint.HostPanel.Top = tb.LineInfos[hint.Range.Start.iLine + 1].startY - tb.VerticalScroll.Value;
				if (hint.HostPanel.Bottom > tb.ClientRectangle.Bottom)
				{
					hint.HostPanel.Top = tb.LineInfos[hint.Range.Start.iLine + 1].startY - tb.CharHeight - hint.TopPadding - hint.HostPanel.Height - tb.VerticalScroll.Value;
				}
			}
		}
		if (hint.Dock == DockStyle.Fill)
		{
			hint.Width = tb.ClientSize.Width - tb.LeftIndent - 2;
			hint.HostPanel.Left = tb.LeftIndent;
			return;
		}
		Point point = tb.PlaceToPoint(hint.Range.Start);
		Point point2 = tb.PlaceToPoint(hint.Range.End);
		int num2 = (point.X + point2.X) / 2;
		int num3 = num2 - hint.HostPanel.Width / 2;
		hint.HostPanel.Left = Math.Max(tb.LeftIndent, num3);
		if (hint.HostPanel.Right > tb.ClientSize.Width)
		{
			hint.HostPanel.Left = Math.Max(tb.LeftIndent, num3 - (hint.HostPanel.Right - tb.ClientSize.Width));
		}
	}

	public IEnumerator<Hint> GetEnumerator()
	{
		foreach (Hint item in items)
		{
			yield return item;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Clear()
	{
		items.Clear();
		if (tb.Controls.Count == 0)
		{
			return;
		}
		List<Control> list = new List<Control>();
		foreach (Control control in tb.Controls)
		{
			if (control is UnfocusablePanel)
			{
				list.Add(control);
			}
		}
		foreach (Control item in list)
		{
			tb.Controls.Remove(item);
		}
		for (int i = 0; i < tb.LineInfos.Count; i++)
		{
			LineInfo value = tb.LineInfos[i];
			value.bottomPadding = 0;
			tb.LineInfos[i] = value;
		}
		tb.NeedRecalc();
		tb.Invalidate();
		tb.Select();
		tb.ActiveControl = null;
	}

	public void Add(Hint hint)
	{
		items.Add(hint);
		if (hint.Inline)
		{
			LineInfo value = tb.LineInfos[hint.Range.Start.iLine];
			hint.TopPadding = value.bottomPadding;
			value.bottomPadding += hint.HostPanel.Height;
			tb.LineInfos[hint.Range.Start.iLine] = value;
			tb.NeedRecalc(forced: true);
		}
		LayoutHint(hint);
		tb.OnVisibleRangeChanged();
		hint.HostPanel.Parent = tb;
		tb.Select();
		tb.ActiveControl = null;
		tb.Invalidate();
	}

	public bool Contains(Hint item)
	{
		return items.Contains(item);
	}

	public void CopyTo(Hint[] array, int arrayIndex)
	{
		items.CopyTo(array, arrayIndex);
	}

	public bool Remove(Hint item)
	{
		throw new NotImplementedException();
	}
}
