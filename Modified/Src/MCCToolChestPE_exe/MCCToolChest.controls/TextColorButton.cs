using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class TextColorButton : UserControl
{
	private int r0HxFaMgeb;

	private TextColorPicked Y5oxjvwMvA;

	private string Egsx8hHDY3;

	private IContainer D7xx9lHebf;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextColorButton(string id, int argb, TextColorPicked colorPicked)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		y7hxHydx4R();
		Egsx8hHDY3 = id;
		r0HxFaMgeb = argb;
		Y5oxjvwMvA = colorPicked;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TaaxAdoyVX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = Color.FromArgb(r0HxFaMgeb);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ejbxd6KFH1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Y5oxjvwMvA(Egsx8hHDY3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && D7xx9lHebf != null)
		{
			D7xx9lHebf.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void y7hxHydx4R()
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
		base.Load += TaaxAdoyVX;
		base.Click += ejbxd6KFH1;
		ResumeLayout(performLayout: false);
	}
}
