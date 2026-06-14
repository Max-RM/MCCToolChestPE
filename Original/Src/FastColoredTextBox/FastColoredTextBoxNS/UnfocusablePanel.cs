using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

[ToolboxItem(false)]
public class UnfocusablePanel : UserControl
{
	public Color BackColor2 { get; set; }

	public Color BorderColor { get; set; }

	public new string Text { get; set; }

	public StringAlignment TextAlignment { get; set; }

	public UnfocusablePanel()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		using (LinearGradientBrush brush = new LinearGradientBrush(base.ClientRectangle, BackColor2, BackColor, 90f))
		{
			e.Graphics.FillRectangle(brush, 0, 0, base.ClientSize.Width - 1, base.ClientSize.Height - 1);
		}
		using (Pen pen = new Pen(BorderColor))
		{
			e.Graphics.DrawRectangle(pen, 0, 0, base.ClientSize.Width - 1, base.ClientSize.Height - 1);
		}
		if (!string.IsNullOrEmpty(Text))
		{
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = TextAlignment;
			stringFormat.LineAlignment = StringAlignment.Center;
			using SolidBrush brush2 = new SolidBrush(ForeColor);
			e.Graphics.DrawString(Text, Font, brush2, new RectangleF(1f, 1f, base.ClientSize.Width - 2, base.ClientSize.Height - 2), stringFormat);
		}
	}
}
