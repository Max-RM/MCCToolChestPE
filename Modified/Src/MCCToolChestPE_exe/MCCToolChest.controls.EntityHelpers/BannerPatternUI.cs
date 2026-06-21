using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.ConfigData;
using MCCToolChest.controllers;
using MCCToolChest.events;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class BannerPatternUI : UserControl
{
	private string xNRWQtc0j2;

	private int wvOWORp5dq;

	private BannerPatternChanged QkqWCvOEVd;

	private BannerPatternUISelected S3pW7gwnCc;

	private Bitmap e6cWAUUVrv;

	private bool RDAWd7y450;

	private bool oflWHkp5Or;

	private bool pRqWF7FTdp;

	private IContainer AmFWj46yts;

	private ComboBox vKwW8X5Ljq;

	private PictureBoxWithInterpolationMode hhgW9Jwl9l;

	private Panel ETtWI3Eq1L;

	public string PatternCode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return xNRWQtc0j2;
		}
	}

	public int PatternColorIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wvOWORp5dq;
		}
	}

	public Color PatternColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ksyW6EqKjS();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActiveState(bool active)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pRqWF7FTdp = active;
		base.BorderStyle = (active ? BorderStyle.FixedSingle : BorderStyle.None);
		if (active)
		{
			vKwW8X5Ljq.Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BannerPatternUI(string patternCode, int colorIndex, BannerPatternChanged bannerPatternChanged, BannerPatternUISelected bannerPatternUISelected)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		xNRWQtc0j2 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42);
		e6cWAUUVrv = new Bitmap(250, 500);
		H1FWoEnGqb();
		if (BannerImageManager.qajEg1seF().ContainsKey(patternCode))
		{
			xNRWQtc0j2 = patternCode;
		}
		wvOWORp5dq = colorIndex;
		QkqWCvOEVd = bannerPatternChanged;
		S3pW7gwnCc = bannerPatternUISelected;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YtCWEfJENR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TTSW5013LQ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Image Image()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!RDAWd7y450)
		{
			mufWrQ6Viq();
			RDAWd7y450 = true;
		}
		return e6cWAUUVrv;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mufWrQ6Viq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image image = BannerImageManager.qajEg1seF()[xNRWQtc0j2].Image;
		_ = Color.Black;
		Color color = ksyW6EqKjS();
		Color color2 = Color.FromArgb(0, 0, 0, 0);
		Bitmap bitmap = (Bitmap)image;
		for (int i = 0; i < image.Width; i++)
		{
			for (int j = 0; j < image.Height; j++)
			{
				Color pixel = bitmap.GetPixel(i, j);
				if (pixel != color2)
				{
					pixel = Color.FromArgb(pixel.A, color.R, color.G, color.B);
					bitmap.SetPixel(i, j, pixel);
				}
			}
		}
		Graphics graphics = Graphics.FromImage(e6cWAUUVrv);
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		graphics.Clear(Color.Transparent);
		Rectangle destRect = new Rectangle(0, 0, e6cWAUUVrv.Width, e6cWAUUVrv.Height);
		graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TTSW5013LQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		oflWHkp5Or = true;
		BindingSource bindingSource = new BindingSource();
		bindingSource.DataSource = BannerImagesDefinition.bannerImages.ToList();
		vKwW8X5Ljq.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		vKwW8X5Ljq.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14208);
		vKwW8X5Ljq.DataSource = bindingSource.DataSource;
		vKwW8X5Ljq.SelectedIndex = -1;
		oflWHkp5Or = false;
		vKwW8X5Ljq.SelectedValue = xNRWQtc0j2;
		int num = 0;
		int num2 = 0;
		foreach (ColorCode value in ColorConstants.colorCodes.Values)
		{
			ColorButton colorButton = new ColorButton(value.Index, urvWcUswgG);
			colorButton.Size = new Size(20, 20);
			colorButton.Location = new Point(num * 24, num2);
			colorButton.Visible = true;
			ETtWI3Eq1L.Controls.Add(colorButton);
			num++;
			if (num == 8)
			{
				num = 0;
				num2 = 25;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Color ksyW6EqKjS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int color = ColorConstants.colorCodes[wvOWORp5dq].Color;
		return Color.FromArgb(color);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void i8XWNdNdBD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Color color = ksyW6EqKjS();
		Image image = BannerImageManager.BannerImages.Images[xNRWQtc0j2];
		Bitmap image2 = new Bitmap(hhgW9Jwl9l.Width, hhgW9Jwl9l.Height);
		Graphics graphics = Graphics.FromImage(image2);
		_ = Color.Black;
		Color color2 = Color.FromArgb(0, 0, 0, 0);
		Bitmap bitmap = (Bitmap)image;
		for (int i = 0; i < image.Width; i++)
		{
			for (int j = 0; j < image.Height; j++)
			{
				Color pixel = bitmap.GetPixel(i, j);
				if (pixel != color2)
				{
					pixel = Color.FromArgb(pixel.A, color.R, color.G, color.B);
					bitmap.SetPixel(i, j, pixel);
				}
			}
		}
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		Rectangle destRect = new Rectangle(0, 0, hhgW9Jwl9l.Width, hhgW9Jwl9l.Height);
		graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
		hhgW9Jwl9l.Image = image2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QopWDBsxDi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (vKwW8X5Ljq.SelectedItem is BannerDefinition bannerDefinition && !oflWHkp5Or)
		{
			xNRWQtc0j2 = bannerDefinition.Code;
			UfBWJDjnLU();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void urvWcUswgG(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wvOWORp5dq = P_0;
		UfBWJDjnLU();
		S3pW7gwnCc(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UfBWJDjnLU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		i8XWNdNdBD();
		RDAWd7y450 = false;
		if (!oflWHkp5Or)
		{
			QkqWCvOEVd();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OOPWu3BXxc(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		S3pW7gwnCc(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && AmFWj46yts != null)
		{
			AmFWj46yts.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void H1FWoEnGqb()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vKwW8X5Ljq = new ComboBox();
		ETtWI3Eq1L = new Panel();
		hhgW9Jwl9l = new PictureBoxWithInterpolationMode();
		((ISupportInitialize)hhgW9Jwl9l).BeginInit();
		SuspendLayout();
		vKwW8X5Ljq.DropDownStyle = ComboBoxStyle.DropDownList;
		vKwW8X5Ljq.FormattingEnabled = true;
		vKwW8X5Ljq.Location = new Point(49, 5);
		vKwW8X5Ljq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14220);
		vKwW8X5Ljq.Size = new Size(251, 21);
		vKwW8X5Ljq.TabIndex = 1;
		vKwW8X5Ljq.SelectedIndexChanged += QopWDBsxDi;
		vKwW8X5Ljq.Click += OOPWu3BXxc;
		ETtWI3Eq1L.Location = new Point(49, 34);
		ETtWI3Eq1L.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14244);
		ETtWI3Eq1L.Size = new Size(251, 50);
		ETtWI3Eq1L.TabIndex = 3;
		ETtWI3Eq1L.Click += OOPWu3BXxc;
		hhgW9Jwl9l.BorderStyle = BorderStyle.FixedSingle;
		hhgW9Jwl9l.InterpolationMode = InterpolationMode.NearestNeighbor;
		hhgW9Jwl9l.Location = new Point(3, 5);
		hhgW9Jwl9l.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14266);
		hhgW9Jwl9l.Size = new Size(40, 80);
		hhgW9Jwl9l.SizeMode = PictureBoxSizeMode.Zoom;
		hhgW9Jwl9l.TabIndex = 2;
		hhgW9Jwl9l.TabStop = false;
		hhgW9Jwl9l.Click += OOPWu3BXxc;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(ETtWI3Eq1L);
		base.Controls.Add(hhgW9Jwl9l);
		base.Controls.Add(vKwW8X5Ljq);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14288);
		base.Size = new Size(321, 91);
		base.Load += YtCWEfJENR;
		base.Click += OOPWu3BXxc;
		((ISupportInitialize)hhgW9Jwl9l).EndInit();
		ResumeLayout(performLayout: false);
	}
}
