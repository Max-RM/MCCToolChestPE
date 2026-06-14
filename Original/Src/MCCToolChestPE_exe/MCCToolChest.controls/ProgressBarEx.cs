using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class ProgressBarEx : ProgressBar
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public ProgressBarEx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		SetStyle(ControlStyles.UserPaint, value: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using Image image = new Bitmap(base.Width, base.Height);
		using Graphics graphics = Graphics.FromImage(image);
		Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
		if (ProgressBarRenderer.IsSupported)
		{
			ProgressBarRenderer.DrawHorizontalBar(graphics, rectangle);
		}
		rectangle.Inflate(new Size(-2, -2));
		rectangle.Width = (int)((double)rectangle.Width * ((double)base.Value / (double)base.Maximum));
		if (rectangle.Width == 0)
		{
			rectangle.Width = 1;
		}
		LinearGradientBrush brush = new LinearGradientBrush(rectangle, BackColor, ForeColor, LinearGradientMode.Vertical);
		graphics.FillRectangle(brush, 2, 2, rectangle.Width, rectangle.Height);
		e.Graphics.DrawImage(image, 0, 0);
		image.Dispose();
	}
}
