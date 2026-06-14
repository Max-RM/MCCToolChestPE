using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class SplashScreen : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1
	{
		public Timer t;

		public int currentCount;

		public SplashScreen _003C_003E4__this;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass1()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _003CSplashScreen_Load_003Eb__0(object o, EventArgs e)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			t.Stop();
			if (!_003C_003E4__this.Nco8XpW1Hr)
			{
				currentCount++;
				if (currentCount >= 200)
				{
					_003C_003E4__this.Nco8XpW1Hr = true;
				}
				t.Start();
			}
			else
			{
				currentCount++;
				if (currentCount >= 225)
				{
					_003C_003E4__this.Close();
				}
				else
				{
					_003C_003E4__this.tIN8aADr8w -= 0.04f;
					_003C_003E4__this.Invalidate();
					t.Start();
				}
			}
			_003C_003E4__this.EV88RBClJk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259004) + (225 - currentCount);
		}
	}

	private static Timer NJQ8tanHkE;

	private float tIN8aADr8w;

	private bool Nco8XpW1Hr;

	private string ApP8xvxVA3;

	private string G788eDHJeu;

	private string w6D8MSHbGq;

	private IContainer KTc8UAE0HL;

	private Label HDq8LBlSTc;

	private PictureBox h2Q8gyOpTG;

	private Button opa8P32kUE;

	private Label EV88RBClJk;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SplashScreen(string splashCaption, string buttonCaption, string buttonAction)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		tIN8aADr8w = 1f;
		rYf8BHfJlt();
		ApP8xvxVA3 = splashCaption;
		G788eDHJeu = buttonCaption;
		w6D8MSHbGq = buttonAction;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mNf82UMY6K(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003C_003Ec__DisplayClass1 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass1();
		CS_0024_003C_003E8__locals20._003C_003E4__this = this;
		HDq8LBlSTc.Text = ApP8xvxVA3;
		opa8P32kUE.Text = G788eDHJeu;
		CS_0024_003C_003E8__locals20.t = new Timer();
		CS_0024_003C_003E8__locals20.t.Interval = 10;
		CS_0024_003C_003E8__locals20.currentCount = 0;
		CS_0024_003C_003E8__locals20.t.Tick += [MethodImpl(MethodImplOptions.NoInlining)] (object o, EventArgs e) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			CS_0024_003C_003E8__locals20.t.Stop();
			if (!CS_0024_003C_003E8__locals20._003C_003E4__this.Nco8XpW1Hr)
			{
				CS_0024_003C_003E8__locals20.currentCount++;
				if (CS_0024_003C_003E8__locals20.currentCount >= 200)
				{
					CS_0024_003C_003E8__locals20._003C_003E4__this.Nco8XpW1Hr = true;
				}
				CS_0024_003C_003E8__locals20.t.Start();
			}
			else
			{
				CS_0024_003C_003E8__locals20.currentCount++;
				if (CS_0024_003C_003E8__locals20.currentCount >= 225)
				{
					CS_0024_003C_003E8__locals20._003C_003E4__this.Close();
				}
				else
				{
					CS_0024_003C_003E8__locals20._003C_003E4__this.tIN8aADr8w -= 0.04f;
					CS_0024_003C_003E8__locals20._003C_003E4__this.Invalidate();
					CS_0024_003C_003E8__locals20.t.Start();
				}
			}
			CS_0024_003C_003E8__locals20._003C_003E4__this.EV88RBClJk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259004) + (225 - CS_0024_003C_003E8__locals20.currentCount);
		};
		CS_0024_003C_003E8__locals20.t.Start();
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
	private void gI28yHZcXf(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image image = new Bitmap(Resources.Qb6SEHD1AjC());
		new Point(0, 0);
		ColorMatrix colorMatrix = new ColorMatrix();
		colorMatrix.Matrix33 = tIN8aADr8w;
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		P_0.Graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
		base.Opacity = tIN8aADr8w;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zDv80yEggY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CallBrowser callBrowser = new CallBrowser();
		callBrowser.Call(w6D8MSHbGq);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && KTc8UAE0HL != null)
		{
			KTc8UAE0HL.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rYf8BHfJlt()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SplashScreen));
		HDq8LBlSTc = new Label();
		h2Q8gyOpTG = new PictureBox();
		opa8P32kUE = new Button();
		EV88RBClJk = new Label();
		((ISupportInitialize)h2Q8gyOpTG).BeginInit();
		SuspendLayout();
		HDq8LBlSTc.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 16f, FontStyle.Regular, GraphicsUnit.Point, 0);
		HDq8LBlSTc.Location = new Point(189, 46);
		HDq8LBlSTc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62412);
		HDq8LBlSTc.Padding = new Padding(20);
		HDq8LBlSTc.Size = new Size(483, 169);
		HDq8LBlSTc.TabIndex = 0;
		HDq8LBlSTc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		h2Q8gyOpTG.BackgroundImage = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62434));
		h2Q8gyOpTG.BackgroundImageLayout = ImageLayout.Stretch;
		h2Q8gyOpTG.Location = new Point(12, 46);
		h2Q8gyOpTG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10152);
		h2Q8gyOpTG.Size = new Size(180, 169);
		h2Q8gyOpTG.TabIndex = 1;
		h2Q8gyOpTG.TabStop = false;
		opa8P32kUE.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 14f, FontStyle.Regular, GraphicsUnit.Point, 0);
		opa8P32kUE.Location = new Point(308, 150);
		opa8P32kUE.Margin = new Padding(3, 3, 3, 10);
		opa8P32kUE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62492);
		opa8P32kUE.Size = new Size(256, 46);
		opa8P32kUE.TabIndex = 2;
		opa8P32kUE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62510);
		opa8P32kUE.TextImageRelation = TextImageRelation.ImageBeforeText;
		opa8P32kUE.UseVisualStyleBackColor = true;
		opa8P32kUE.Click += zDv80yEggY;
		EV88RBClJk.AutoSize = true;
		EV88RBClJk.Location = new Point(591, 198);
		EV88RBClJk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62524);
		EV88RBClJk.Size = new Size(45, 13);
		EV88RBClJk.TabIndex = 3;
		EV88RBClJk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62556);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Silver;
		base.ClientSize = new Size(671, 239);
		base.Controls.Add(EV88RBClJk);
		base.Controls.Add(opa8P32kUE);
		base.Controls.Add(h2Q8gyOpTG);
		base.Controls.Add(HDq8LBlSTc);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62576);
		base.Padding = new Padding(10);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62576);
		base.Load += mNf82UMY6K;
		((ISupportInitialize)h2Q8gyOpTG).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SplashScreen()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
