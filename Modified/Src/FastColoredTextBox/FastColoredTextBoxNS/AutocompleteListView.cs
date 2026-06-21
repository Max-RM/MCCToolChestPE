using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

[ToolboxItem(false)]
public class AutocompleteListView : UserControl, IDisposable
{
	internal List<AutocompleteItem> visibleItems;

	private IEnumerable<AutocompleteItem> sourceItems = new List<AutocompleteItem>();

	private int focussedItemIndex = 0;

	private int hoveredItemIndex = -1;

	private int oldItemCount = 0;

	private FastColoredTextBox tb;

	internal ToolTip toolTip = new ToolTip();

	private Timer timer = new Timer();

	private int ItemHeight => Font.Height + 2;

	private AutocompleteMenu Menu => base.Parent as AutocompleteMenu;

	internal bool AllowTabKey { get; set; }

	public ImageList ImageList { get; set; }

	internal int AppearInterval
	{
		get
		{
			return timer.Interval;
		}
		set
		{
			timer.Interval = value;
		}
	}

	internal int ToolTipDuration { get; set; }

	internal Size MaxToolTipSize { get; set; }

	internal bool AlwaysShowTooltip
	{
		get
		{
			return toolTip.ShowAlways;
		}
		set
		{
			toolTip.ShowAlways = value;
		}
	}

	public Color SelectedColor { get; set; }

	public Color HoveredColor { get; set; }

	public int FocussedItemIndex
	{
		get
		{
			return focussedItemIndex;
		}
		set
		{
			if (focussedItemIndex != value)
			{
				focussedItemIndex = value;
				if (this.FocussedItemIndexChanged != null)
				{
					this.FocussedItemIndexChanged(this, EventArgs.Empty);
				}
			}
		}
	}

	public AutocompleteItem FocussedItem
	{
		get
		{
			if (FocussedItemIndex >= 0 && focussedItemIndex < visibleItems.Count)
			{
				return visibleItems[focussedItemIndex];
			}
			return null;
		}
		set
		{
			FocussedItemIndex = visibleItems.IndexOf(value);
		}
	}

	public int Count => visibleItems.Count;

	public event EventHandler FocussedItemIndexChanged;

	internal AutocompleteListView(FastColoredTextBox tb)
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		base.Font = new Font(FontFamily.GenericSansSerif, 9f);
		visibleItems = new List<AutocompleteItem>();
		base.VerticalScroll.SmallChange = ItemHeight;
		MaximumSize = new Size(base.Size.Width, 180);
		toolTip.ShowAlways = false;
		AppearInterval = 500;
		timer.Tick += timer_Tick;
		SelectedColor = Color.Orange;
		HoveredColor = Color.Red;
		ToolTipDuration = 3000;
		toolTip.Popup += ToolTip_Popup;
		this.tb = tb;
		tb.KeyDown += tb_KeyDown;
		tb.SelectionChanged += tb_SelectionChanged;
		tb.KeyPressed += tb_KeyPressed;
		Form form = tb.FindForm();
		if (form != null)
		{
			form.LocationChanged += delegate
			{
				SafetyClose();
			};
			form.ResizeBegin += delegate
			{
				SafetyClose();
			};
			form.FormClosing += delegate
			{
				SafetyClose();
			};
			form.LostFocus += delegate
			{
				SafetyClose();
			};
		}
		tb.LostFocus += delegate
		{
			if (Menu != null && !Menu.IsDisposed && !Menu.Focused)
			{
				SafetyClose();
			}
		};
		tb.Scroll += delegate
		{
			SafetyClose();
		};
		base.VisibleChanged += delegate
		{
			if (base.Visible)
			{
				DoSelectedVisible();
			}
		};
	}

	private void ToolTip_Popup(object sender, PopupEventArgs e)
	{
		if (MaxToolTipSize.Height > 0 && MaxToolTipSize.Width > 0)
		{
			e.ToolTipSize = MaxToolTipSize;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (toolTip != null)
		{
			toolTip.Popup -= ToolTip_Popup;
			toolTip.Dispose();
		}
		if (tb != null)
		{
			tb.KeyDown -= tb_KeyDown;
			tb.KeyPress -= tb_KeyPressed;
			tb.SelectionChanged -= tb_SelectionChanged;
		}
		if (timer != null)
		{
			timer.Stop();
			timer.Tick -= timer_Tick;
			timer.Dispose();
		}
		base.Dispose(disposing);
	}

	private void SafetyClose()
	{
		if (Menu != null && !Menu.IsDisposed)
		{
			Menu.Close();
		}
	}

	private void tb_KeyPressed(object sender, KeyPressEventArgs e)
	{
		bool flag = e.KeyChar == '\b' || e.KeyChar == 'ÿ';
		if (Menu.Visible && !flag)
		{
			DoAutocomplete(forced: false);
		}
		else
		{
			ResetTimer(timer);
		}
	}

	private void timer_Tick(object sender, EventArgs e)
	{
		timer.Stop();
		DoAutocomplete(forced: false);
	}

	private void ResetTimer(Timer timer)
	{
		timer.Stop();
		timer.Start();
	}

	internal void DoAutocomplete()
	{
		DoAutocomplete(forced: false);
	}

	internal void DoAutocomplete(bool forced)
	{
		if (!Menu.Enabled)
		{
			Menu.Close();
			return;
		}
		visibleItems.Clear();
		FocussedItemIndex = 0;
		base.VerticalScroll.Value = 0;
		base.AutoScrollMinSize -= new Size(1, 0);
		base.AutoScrollMinSize += new Size(1, 0);
		Range fragment = tb.Selection.GetFragment(Menu.SearchPattern);
		string text = fragment.Text;
		Point position = tb.PlaceToPoint(fragment.End);
		position.Offset(2, tb.CharHeight);
		if (forced || (text.Length >= Menu.MinFragmentLength && tb.Selection.IsEmpty && (tb.Selection.Start > fragment.Start || text.Length == 0)))
		{
			Menu.Fragment = fragment;
			bool flag = false;
			foreach (AutocompleteItem sourceItem in sourceItems)
			{
				sourceItem.Parent = Menu;
				CompareResult compareResult = sourceItem.Compare(text);
				if (compareResult != CompareResult.Hidden)
				{
					visibleItems.Add(sourceItem);
				}
				if (compareResult == CompareResult.VisibleAndSelected && !flag)
				{
					flag = true;
					FocussedItemIndex = visibleItems.Count - 1;
				}
			}
			if (flag)
			{
				AdjustScroll();
				DoSelectedVisible();
			}
		}
		if (Count > 0)
		{
			if (!Menu.Visible)
			{
				CancelEventArgs e = new CancelEventArgs();
				Menu.OnOpening(e);
				if (!e.Cancel)
				{
					Menu.Show(tb, position);
				}
			}
			DoSelectedVisible();
			Invalidate();
		}
		else
		{
			Menu.Close();
		}
	}

	private void tb_SelectionChanged(object sender, EventArgs e)
	{
		if (!Menu.Visible)
		{
			return;
		}
		bool flag = false;
		if (!tb.Selection.IsEmpty)
		{
			flag = true;
		}
		else if (!Menu.Fragment.Contains(tb.Selection.Start))
		{
			if (tb.Selection.Start.iLine == Menu.Fragment.End.iLine && tb.Selection.Start.iChar == Menu.Fragment.End.iChar + 1)
			{
				if (!Regex.IsMatch(tb.Selection.CharBeforeStart.ToString(), Menu.SearchPattern))
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
		{
			Menu.Close();
		}
	}

	private void tb_KeyDown(object sender, KeyEventArgs e)
	{
		FastColoredTextBox fastColoredTextBox = sender as FastColoredTextBox;
		if (Menu.Visible && ProcessKey(e.KeyCode, e.Modifiers))
		{
			e.Handled = true;
		}
		if (!Menu.Visible)
		{
			if (fastColoredTextBox.HotkeysMapping.ContainsKey(e.KeyData) && fastColoredTextBox.HotkeysMapping[e.KeyData] == FCTBAction.AutocompleteMenu)
			{
				DoAutocomplete();
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Escape && timer.Enabled)
			{
				timer.Stop();
			}
		}
	}

	private void AdjustScroll()
	{
		if (oldItemCount != visibleItems.Count)
		{
			int val = ItemHeight * visibleItems.Count + 1;
			base.Height = Math.Min(val, MaximumSize.Height);
			Menu.CalcSize();
			base.AutoScrollMinSize = new Size(0, val);
			oldItemCount = visibleItems.Count;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		AdjustScroll();
		int itemHeight = ItemHeight;
		int val = base.VerticalScroll.Value / itemHeight - 1;
		int val2 = (base.VerticalScroll.Value + base.ClientSize.Height) / itemHeight + 1;
		val = Math.Max(val, 0);
		val2 = Math.Min(val2, visibleItems.Count);
		int num = 0;
		int num2 = 18;
		for (int i = val; i < val2; i++)
		{
			num = i * itemHeight - base.VerticalScroll.Value;
			AutocompleteItem autocompleteItem = visibleItems[i];
			if (autocompleteItem.BackColor != Color.Transparent)
			{
				using SolidBrush brush = new SolidBrush(autocompleteItem.BackColor);
				e.Graphics.FillRectangle(brush, 1, num, base.ClientSize.Width - 1 - 1, itemHeight - 1);
			}
			if (ImageList != null && visibleItems[i].ImageIndex >= 0)
			{
				e.Graphics.DrawImage(ImageList.Images[autocompleteItem.ImageIndex], 1, num);
			}
			if (i == FocussedItemIndex)
			{
				using LinearGradientBrush brush2 = new LinearGradientBrush(new Point(0, num - 3), new Point(0, num + itemHeight), Color.Transparent, SelectedColor);
				using Pen pen = new Pen(SelectedColor);
				e.Graphics.FillRectangle(brush2, num2, num, base.ClientSize.Width - 1 - num2, itemHeight - 1);
				e.Graphics.DrawRectangle(pen, num2, num, base.ClientSize.Width - 1 - num2, itemHeight - 1);
			}
			if (i == hoveredItemIndex)
			{
				using Pen pen2 = new Pen(HoveredColor);
				e.Graphics.DrawRectangle(pen2, num2, num, base.ClientSize.Width - 1 - num2, itemHeight - 1);
			}
			using SolidBrush brush3 = new SolidBrush((autocompleteItem.ForeColor != Color.Transparent) ? autocompleteItem.ForeColor : ForeColor);
			e.Graphics.DrawString(autocompleteItem.ToString(), Font, brush3, num2, num);
		}
	}

	protected override void OnScroll(ScrollEventArgs se)
	{
		base.OnScroll(se);
		Invalidate();
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		base.OnMouseClick(e);
		if (e.Button == MouseButtons.Left)
		{
			FocussedItemIndex = PointToItemIndex(e.Location);
			DoSelectedVisible();
			Invalidate();
		}
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		base.OnMouseDoubleClick(e);
		FocussedItemIndex = PointToItemIndex(e.Location);
		Invalidate();
		OnSelecting();
	}

	internal virtual void OnSelecting()
	{
		if (FocussedItemIndex < 0 || FocussedItemIndex >= visibleItems.Count)
		{
			return;
		}
		tb.TextSource.Manager.BeginAutoUndoCommands();
		try
		{
			AutocompleteItem focussedItem = FocussedItem;
			SelectingEventArgs e = new SelectingEventArgs
			{
				Item = focussedItem,
				SelectedIndex = FocussedItemIndex
			};
			Menu.OnSelecting(e);
			if (e.Cancel)
			{
				FocussedItemIndex = e.SelectedIndex;
				Invalidate();
				return;
			}
			if (!e.Handled)
			{
				Range fragment = Menu.Fragment;
				DoAutocomplete(focussedItem, fragment);
			}
			Menu.Close();
			SelectedEventArgs e2 = new SelectedEventArgs
			{
				Item = focussedItem,
				Tb = Menu.Fragment.tb
			};
			focussedItem.OnSelected(Menu, e2);
			Menu.OnSelected(e2);
		}
		finally
		{
			tb.TextSource.Manager.EndAutoUndoCommands();
		}
	}

	private void DoAutocomplete(AutocompleteItem item, Range fragment)
	{
		string textForReplace = item.GetTextForReplace();
		FastColoredTextBox fastColoredTextBox = fragment.tb;
		fastColoredTextBox.BeginAutoUndo();
		fastColoredTextBox.TextSource.Manager.ExecuteCommand(new SelectCommand(fastColoredTextBox.TextSource));
		if (fastColoredTextBox.Selection.ColumnSelectionMode)
		{
			Place start = fastColoredTextBox.Selection.Start;
			Place end = fastColoredTextBox.Selection.End;
			start.iChar = fragment.Start.iChar;
			end.iChar = fragment.End.iChar;
			fastColoredTextBox.Selection.Start = start;
			fastColoredTextBox.Selection.End = end;
		}
		else
		{
			fastColoredTextBox.Selection.Start = fragment.Start;
			fastColoredTextBox.Selection.End = fragment.End;
		}
		fastColoredTextBox.InsertText(textForReplace);
		fastColoredTextBox.TextSource.Manager.ExecuteCommand(new SelectCommand(fastColoredTextBox.TextSource));
		fastColoredTextBox.EndAutoUndo();
		fastColoredTextBox.Focus();
	}

	private int PointToItemIndex(Point p)
	{
		return (p.Y + base.VerticalScroll.Value) / ItemHeight;
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		ProcessKey(keyData, Keys.None);
		return base.ProcessCmdKey(ref msg, keyData);
	}

	private bool ProcessKey(Keys keyData, Keys keyModifiers)
	{
		if (keyModifiers == Keys.None)
		{
			switch (keyData)
			{
			case Keys.Down:
				SelectNext(1);
				return true;
			case Keys.Next:
				SelectNext(10);
				return true;
			case Keys.Up:
				SelectNext(-1);
				return true;
			case Keys.Prior:
				SelectNext(-10);
				return true;
			case Keys.Return:
				OnSelecting();
				return true;
			case Keys.Tab:
				if (!AllowTabKey)
				{
					break;
				}
				OnSelecting();
				return true;
			case Keys.Escape:
				Menu.Close();
				return true;
			}
		}
		return false;
	}

	public void SelectNext(int shift)
	{
		FocussedItemIndex = Math.Max(0, Math.Min(FocussedItemIndex + shift, visibleItems.Count - 1));
		DoSelectedVisible();
		Invalidate();
	}

	private void DoSelectedVisible()
	{
		if (FocussedItem != null)
		{
			SetToolTip(FocussedItem);
		}
		int num = FocussedItemIndex * ItemHeight - base.VerticalScroll.Value;
		if (num < 0)
		{
			base.VerticalScroll.Value = FocussedItemIndex * ItemHeight;
		}
		if (num > base.ClientSize.Height - ItemHeight)
		{
			base.VerticalScroll.Value = Math.Min(base.VerticalScroll.Maximum, FocussedItemIndex * ItemHeight - base.ClientSize.Height + ItemHeight);
		}
		base.AutoScrollMinSize -= new Size(1, 0);
		base.AutoScrollMinSize += new Size(1, 0);
	}

	private void SetToolTip(AutocompleteItem autocompleteItem)
	{
		string toolTipTitle = autocompleteItem.ToolTipTitle;
		string toolTipText = autocompleteItem.ToolTipText;
		if (string.IsNullOrEmpty(toolTipTitle))
		{
			toolTip.ToolTipTitle = null;
			toolTip.SetToolTip(this, null);
		}
		else if (base.Parent != null)
		{
			IWin32Window win32Window = base.Parent ?? this;
			Point point = ((PointToScreen(base.Location).X + MaxToolTipSize.Width + 105 >= Screen.FromControl(base.Parent).WorkingArea.Right) ? new Point(base.Left - 105 - MaximumSize.Width, 0) : new Point(base.Right + 5, 0));
			if (string.IsNullOrEmpty(toolTipText))
			{
				toolTip.ToolTipTitle = null;
				toolTip.Show(toolTipTitle, win32Window, point.X, point.Y, ToolTipDuration);
			}
			else
			{
				toolTip.ToolTipTitle = toolTipTitle;
				toolTip.Show(toolTipText, win32Window, point.X, point.Y, ToolTipDuration);
			}
		}
	}

	public void SetAutocompleteItems(ICollection<string> items)
	{
		List<AutocompleteItem> list = new List<AutocompleteItem>(items.Count);
		foreach (string item in items)
		{
			list.Add(new AutocompleteItem(item));
		}
		SetAutocompleteItems(list);
	}

	public void SetAutocompleteItems(IEnumerable<AutocompleteItem> items)
	{
		sourceItems = items;
	}
}
