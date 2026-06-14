using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.ConfigData;
using MCCToolChest.events;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class ColorButton : UserControl
{
	private int NA2Vi24BLp;

	private ColorPicked b0jVsrptJ9;

	private int sAvVqplZyR;

	private IContainer f52VKxVypw;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ColorButton(int colorIndex, ColorPicked colorPicked)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		doyVfuiXxQ();
		sAvVqplZyR = colorIndex;
		b0jVsrptJ9 = colorPicked;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YeVVpbBm9R(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = Color.FromArgb(ColorConstants.colorCodes[sAvVqplZyR].Color);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mCOVZpUJUF(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		b0jVsrptJ9(sAvVqplZyR);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && f52VKxVypw != null)
		{
			f52VKxVypw.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void doyVfuiXxQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SuspendLayout();
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(255, 128, 128);
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13014);
		base.Size = new Size(39, 37);
		base.Load += YeVVpbBm9R;
		base.Click += mCOVZpUJUF;
		ResumeLayout(performLayout: false);
	}
}
