using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class Ruler : UserControl
{
	public EventHandler TargetChanged;

	private FastColoredTextBox target;

	private IContainer components = null;

	[DefaultValue(typeof(Color), "ControlLight")]
	public Color BackColor2 { get; set; }

	[DefaultValue(typeof(Color), "DarkGray")]
	public Color TickColor { get; set; }

	[DefaultValue(typeof(Color), "Black")]
	public Color CaretTickColor { get; set; }

	[Description("Target FastColoredTextBox")]
	public FastColoredTextBox Target
	{
		get
		{
			return target;
		}
		set
		{
			if (target != null)
			{
				UnSubscribe(target);
			}
			target = value;
			Subscribe(target);
			OnTargetChanged();
		}
	}

	public Ruler()
	{
		InitializeComponent();
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		MinimumSize = new Size(0, 24);
		MaximumSize = new Size(1073741823, 24);
		BackColor2 = SystemColors.ControlLight;
		TickColor = Color.DarkGray;
		CaretTickColor = Color.Black;
	}

	protected virtual void OnTargetChanged()
	{
		if (TargetChanged != null)
		{
			TargetChanged(this, EventArgs.Empty);
		}
	}

	protected virtual void UnSubscribe(FastColoredTextBox target)
	{
		target.Scroll -= target_Scroll;
		target.SelectionChanged -= target_SelectionChanged;
		target.VisibleRangeChanged -= target_VisibleRangeChanged;
	}

	protected virtual void Subscribe(FastColoredTextBox target)
	{
		target.Scroll += target_Scroll;
		target.SelectionChanged += target_SelectionChanged;
		target.VisibleRangeChanged += target_VisibleRangeChanged;
	}

	private void target_VisibleRangeChanged(object sender, EventArgs e)
	{
		Invalidate();
	}

	private void target_SelectionChanged(object sender, EventArgs e)
	{
		Invalidate();
	}

	protected virtual void target_Scroll(object sender, ScrollEventArgs e)
	{
		Invalidate();
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		Invalidate();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (target == null)
		{
			return;
		}
		Point point = PointToClient(target.PointToScreen(target.PlaceToPoint(target.Selection.Start)));
		Size size = TextRenderer.MeasureText("W", Font);
		int num = 0;
		e.Graphics.FillRectangle(new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), BackColor, BackColor2, 270f), new Rectangle(0, 0, base.Width, base.Height));
		float num2 = target.CharWidth;
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Near;
		Point p = target.PositionToPoint(0);
		p = PointToClient(target.PointToScreen(p));
		using (Pen pen = new Pen(TickColor))
		{
			using SolidBrush brush = new SolidBrush(ForeColor);
			float num3 = p.X;
			while (num3 < (float)base.Right)
			{
				if (num % 10 == 0)
				{
					e.Graphics.DrawString(num.ToString(), Font, brush, num3, 0f, stringFormat);
				}
				e.Graphics.DrawLine(pen, (int)num3, size.Height + ((num % 5 == 0) ? 1 : 3), (int)num3, base.Height - 4);
				num3 += num2;
				num++;
			}
		}
		using (Pen pen2 = new Pen(TickColor))
		{
			e.Graphics.DrawLine(pen2, new Point(point.X - 3, base.Height - 3), new Point(point.X + 3, base.Height - 3));
		}
		using Pen pen3 = new Pen(CaretTickColor);
		e.Graphics.DrawLine(pen3, new Point(point.X - 2, size.Height + 3), new Point(point.X - 2, base.Height - 4));
		e.Graphics.DrawLine(pen3, new Point(point.X, size.Height + 1), new Point(point.X, base.Height - 4));
		e.Graphics.DrawLine(pen3, new Point(point.X + 2, size.Height + 3), new Point(point.X + 2, base.Height - 4));
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	}
}
