using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class TextFormatButton : UserControl
{
	private string BU5eSr7NG4;

	private FontStyle chqeGtMZna;

	private TextFormatPicked AUPebJCCFC;

	private IContainer XF8evC8vnp;

	private PictureBox P3dew0rptf;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextFormatButton(string formatCode, FontStyle fontStyle, TextFormatPicked formatPicked)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Ky8eT9mHf1();
		BU5eSr7NG4 = formatCode;
		chqeGtMZna = fontStyle;
		AUPebJCCFC = formatPicked;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nFFxI9kc8v(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		switch (chqeGtMZna)
		{
		case FontStyle.Regular:
			P3dew0rptf.Image = Resources.XsrS1zluJbJ();
			break;
		case FontStyle.Bold:
			P3dew0rptf.Image = Resources.ojES1j82gOZ();
			break;
		case FontStyle.Italic:
			P3dew0rptf.Image = Resources.dZyS19YM2Y7();
			break;
		case FontStyle.Strikeout:
			P3dew0rptf.Image = Resources.BYfSESRGUDm();
			break;
		case FontStyle.Underline:
			P3dew0rptf.Image = Resources.mTwSEb3UQYV();
			break;
		case FontStyle.Bold | FontStyle.Italic:
		case FontStyle.Bold | FontStyle.Underline:
		case FontStyle.Italic | FontStyle.Underline:
		case FontStyle.Bold | FontStyle.Italic | FontStyle.Underline:
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hdYxzltdfw(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AUPebJCCFC(BU5eSr7NG4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && XF8evC8vnp != null)
		{
			XF8evC8vnp.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ky8eT9mHf1()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P3dew0rptf = new PictureBox();
		((ISupportInitialize)P3dew0rptf).BeginInit();
		SuspendLayout();
		P3dew0rptf.Dock = DockStyle.Fill;
		P3dew0rptf.Location = new Point(0, 0);
		P3dew0rptf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30092);
		P3dew0rptf.Size = new Size(23, 23);
		P3dew0rptf.SizeMode = PictureBoxSizeMode.Zoom;
		P3dew0rptf.TabIndex = 0;
		P3dew0rptf.TabStop = false;
		P3dew0rptf.Click += hdYxzltdfw;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(P3dew0rptf);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30120);
		base.Size = new Size(23, 23);
		base.Load += nFFxI9kc8v;
		base.Click += hdYxzltdfw;
		((ISupportInitialize)P3dew0rptf).EndInit();
		ResumeLayout(performLayout: false);
	}
}
