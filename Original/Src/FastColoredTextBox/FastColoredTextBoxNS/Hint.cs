using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class Hint
{
	public string Text
	{
		get
		{
			return HostPanel.Text;
		}
		set
		{
			HostPanel.Text = value;
		}
	}

	public Range Range { get; set; }

	public Color BackColor
	{
		get
		{
			return HostPanel.BackColor;
		}
		set
		{
			HostPanel.BackColor = value;
		}
	}

	public Color BackColor2
	{
		get
		{
			return HostPanel.BackColor2;
		}
		set
		{
			HostPanel.BackColor2 = value;
		}
	}

	public Color BorderColor
	{
		get
		{
			return HostPanel.BorderColor;
		}
		set
		{
			HostPanel.BorderColor = value;
		}
	}

	public Color ForeColor
	{
		get
		{
			return HostPanel.ForeColor;
		}
		set
		{
			HostPanel.ForeColor = value;
		}
	}

	public StringAlignment TextAlignment
	{
		get
		{
			return HostPanel.TextAlignment;
		}
		set
		{
			HostPanel.TextAlignment = value;
		}
	}

	public Font Font
	{
		get
		{
			return HostPanel.Font;
		}
		set
		{
			HostPanel.Font = value;
		}
	}

	public Control InnerControl { get; set; }

	public DockStyle Dock { get; set; }

	public int Width
	{
		get
		{
			return HostPanel.Width;
		}
		set
		{
			HostPanel.Width = value;
		}
	}

	public int Height
	{
		get
		{
			return HostPanel.Height;
		}
		set
		{
			HostPanel.Height = value;
		}
	}

	public UnfocusablePanel HostPanel { get; private set; }

	internal int TopPadding { get; set; }

	public object Tag { get; set; }

	public Cursor Cursor
	{
		get
		{
			return HostPanel.Cursor;
		}
		set
		{
			HostPanel.Cursor = value;
		}
	}

	public bool Inline { get; set; }

	public event EventHandler Click
	{
		add
		{
			HostPanel.Click += value;
		}
		remove
		{
			HostPanel.Click -= value;
		}
	}

	public virtual void DoVisible()
	{
		Range.tb.DoRangeVisible(Range, tryToCentre: true);
		Range.tb.DoVisibleRectangle(HostPanel.Bounds);
		Range.tb.Invalidate();
	}

	private Hint(Range range, Control innerControl, string text, bool inline, bool dock)
	{
		Range = range;
		Inline = inline;
		InnerControl = innerControl;
		Init();
		Dock = (dock ? DockStyle.Fill : DockStyle.None);
		Text = text;
	}

	public Hint(Range range, string text, bool inline, bool dock)
		: this(range, null, text, inline, dock)
	{
	}

	public Hint(Range range, string text)
		: this(range, null, text, inline: true, dock: true)
	{
	}

	public Hint(Range range, Control innerControl, bool inline, bool dock)
		: this(range, innerControl, null, inline, dock)
	{
	}

	public Hint(Range range, Control innerControl)
		: this(range, innerControl, null, inline: true, dock: true)
	{
	}

	protected virtual void Init()
	{
		HostPanel = new UnfocusablePanel();
		HostPanel.Click += OnClick;
		Cursor = Cursors.Default;
		BorderColor = Color.Silver;
		BackColor2 = Color.White;
		BackColor = ((InnerControl == null) ? Color.Silver : SystemColors.Control);
		ForeColor = Color.Black;
		TextAlignment = StringAlignment.Near;
		Font = ((Range.tb.Parent == null) ? Range.tb.Font : Range.tb.Parent.Font);
		if (InnerControl != null)
		{
			HostPanel.Controls.Add(InnerControl);
			Size preferredSize = InnerControl.GetPreferredSize(InnerControl.Size);
			HostPanel.Width = preferredSize.Width + 2;
			HostPanel.Height = preferredSize.Height + 2;
			InnerControl.Dock = DockStyle.Fill;
			InnerControl.Visible = true;
			BackColor = SystemColors.Control;
		}
		else
		{
			HostPanel.Height = Range.tb.CharHeight + 5;
		}
	}

	protected virtual void OnClick(object sender, EventArgs e)
	{
		Range.tb.OnHintClick(this);
	}
}
