using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

[Browsable(false)]
public class AutocompleteMenu : ToolStripDropDown, IDisposable
{
	private AutocompleteListView listView;

	public ToolStripControlHost host;

	public Range Fragment { get; internal set; }

	public string SearchPattern { get; set; }

	public int MinFragmentLength { get; set; }

	public bool AllowTabKey
	{
		get
		{
			return listView.AllowTabKey;
		}
		set
		{
			listView.AllowTabKey = value;
		}
	}

	public int AppearInterval
	{
		get
		{
			return listView.AppearInterval;
		}
		set
		{
			listView.AppearInterval = value;
		}
	}

	public Size MaxTooltipSize
	{
		get
		{
			return listView.MaxToolTipSize;
		}
		set
		{
			listView.MaxToolTipSize = value;
		}
	}

	public bool AlwaysShowTooltip
	{
		get
		{
			return listView.AlwaysShowTooltip;
		}
		set
		{
			listView.AlwaysShowTooltip = value;
		}
	}

	[DefaultValue(typeof(Color), "Orange")]
	public Color SelectedColor
	{
		get
		{
			return listView.SelectedColor;
		}
		set
		{
			listView.SelectedColor = value;
		}
	}

	[DefaultValue(typeof(Color), "Red")]
	public Color HoveredColor
	{
		get
		{
			return listView.HoveredColor;
		}
		set
		{
			listView.HoveredColor = value;
		}
	}

	public new Font Font
	{
		get
		{
			return listView.Font;
		}
		set
		{
			listView.Font = value;
		}
	}

	public new AutocompleteListView Items => listView;

	public new Size MinimumSize
	{
		get
		{
			return Items.MinimumSize;
		}
		set
		{
			Items.MinimumSize = value;
		}
	}

	public new ImageList ImageList
	{
		get
		{
			return Items.ImageList;
		}
		set
		{
			Items.ImageList = value;
		}
	}

	public int ToolTipDuration
	{
		get
		{
			return Items.ToolTipDuration;
		}
		set
		{
			Items.ToolTipDuration = value;
		}
	}

	public ToolTip ToolTip
	{
		get
		{
			return Items.toolTip;
		}
		set
		{
			Items.toolTip = value;
		}
	}

	public event EventHandler<SelectingEventArgs> Selecting;

	public event EventHandler<SelectedEventArgs> Selected;

	public new event EventHandler<CancelEventArgs> Opening;

	public AutocompleteMenu(FastColoredTextBox tb)
	{
		base.AutoClose = false;
		AutoSize = false;
		base.Margin = Padding.Empty;
		base.Padding = Padding.Empty;
		base.BackColor = Color.White;
		listView = new AutocompleteListView(tb);
		host = new ToolStripControlHost(listView);
		host.Margin = new Padding(2, 2, 2, 2);
		host.Padding = Padding.Empty;
		host.AutoSize = false;
		host.AutoToolTip = false;
		CalcSize();
		base.Items.Add(host);
		listView.Parent = this;
		SearchPattern = "[\\w\\.]";
		MinFragmentLength = 2;
	}

	internal new void OnOpening(CancelEventArgs args)
	{
		if (this.Opening != null)
		{
			this.Opening(this, args);
		}
	}

	public new void Close()
	{
		listView.toolTip.Hide(listView);
		base.Close();
	}

	internal void CalcSize()
	{
		host.Size = listView.Size;
		base.Size = new Size(listView.Size.Width + 4, listView.Size.Height + 4);
	}

	public virtual void OnSelecting()
	{
		listView.OnSelecting();
	}

	public void SelectNext(int shift)
	{
		listView.SelectNext(shift);
	}

	internal void OnSelecting(SelectingEventArgs args)
	{
		if (this.Selecting != null)
		{
			this.Selecting(this, args);
		}
	}

	public void OnSelected(SelectedEventArgs args)
	{
		if (this.Selected != null)
		{
			this.Selected(this, args);
		}
	}

	public void Show(bool forced)
	{
		Items.DoAutocomplete(forced);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (listView != null && !listView.IsDisposed)
		{
			listView.Dispose();
		}
	}
}
