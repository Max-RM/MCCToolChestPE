using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using MCCToolChest.Properties;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class PlayerItemUI : UserControl
{
	private static Dictionary<int, Bitmap> QNJamrgHNC;

	private static Dictionary<int, Bitmap> KRlankyD54;

	private int V4Xal5WMLC;

	private int X9ja2AGIqK;

	private PlayerSelected JyWayjjOUY;

	private PlayerDelete kvUa0bKhHy;

	private string jpOaB7j4p1;

	private bool cQ5atG1jMP;

	private IContainer kqZaa7F4Xx;

	private Label VvGaX3Ceum;

	private Label XApaxXndBh;

	private Label KPUaeA6XoE;

	private Label BHiaM3iD1T;

	private PictureBoxWithInterpolationMode h42aUHZFto;

	private ContextMenuStrip WisaLncMM7;

	private ToolStripMenuItem XPnag3U6EL;

	private PictureBoxWithInterpolationMode OhnaPMU9Hi;

	private PictureBoxWithInterpolationMode XHjaRJjeXN;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerItemUI(PlayerDisplayData playerData, PlayerSelected playerSelected, PlayerDelete playerDelete)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Hu8ahmrwVJ();
		jpOaB7j4p1 = playerData.Path;
		JyWayjjOUY = playerSelected;
		kvUa0bKhHy = playerDelete;
		LHga4sbwL9(playerData.Player);
		JcZaWR7qlc();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LHga4sbwL9(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27914);
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27938)))
		{
			text += (P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27938)] as TagNodeLong).ToString();
		}
		VvGaX3Ceum.Text = text;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27958)))
		{
			wkjaVjigfN(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27958)] as TagNodeList);
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)))
		{
			TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
			int num = (int)(float)(tagNodeList[0] as TagNodeFloat);
			int num2 = (int)(float)(tagNodeList[1] as TagNodeFloat);
			int num3 = (int)(float)(tagNodeList[2] as TagNodeFloat);
			string text2 = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27982), num, num2, num3);
			BHiaM3iD1T.Text = text2;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wkjaVjigfN(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
			string text = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] as TagNodeString;
			if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28046))
			{
				V4Xal5WMLC = (int)(float)(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28082)] as TagNodeFloat);
			}
			if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28100))
			{
				X9ja2AGIqK = (int)(float)(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28082)] as TagNodeFloat);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JcZaWR7qlc()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!QNJamrgHNC.ContainsKey(V4Xal5WMLC))
		{
			Bitmap value = SuWapluliV(V4Xal5WMLC, Resources.qkTSEBlHnHo(), Resources.RTtSEaZ0f5j(), Resources.JngSExMBDoN());
			QNJamrgHNC[V4Xal5WMLC] = value;
		}
		OhnaPMU9Hi.Image = QNJamrgHNC[V4Xal5WMLC];
		if (!KRlankyD54.ContainsKey(X9ja2AGIqK))
		{
			Bitmap value2 = SuWapluliV(X9ja2AGIqK, Resources.gwTSEMOvEZk(), Resources.MYwSELRyTdB(), Resources.FEBSEP8odDW());
			KRlankyD54[X9ja2AGIqK] = value2;
		}
		XHjaRJjeXN.Image = KRlankyD54[X9ja2AGIqK];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Bitmap SuWapluliV(int P_0, Bitmap P_1, Bitmap P_2, Bitmap P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Bitmap bitmap = new Bitmap(160, 16);
		using Graphics graphics = Graphics.FromImage(bitmap);
		for (int i = 0; i < 10; i++)
		{
			graphics.DrawImage(P_3, i * 16, 0, 16, 16);
			Image image = P_3;
			if (P_0 == i * 2 + 1)
			{
				image = P_2;
			}
			else if (P_0 >= i * 2 + 2)
			{
				image = P_1;
			}
			graphics.DrawImage(image, i * 16, 0, 16, 16);
		}
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MpjaZXtgE1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DI1aiiIksV(Color.LightBlue);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xtfaf7PUPs(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DI1aiiIksV(Color.White);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DI1aiiIksV(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IqgasjgShV(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!cQ5atG1jMP)
		{
			JyWayjjOUY(jpOaB7j4p1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hKaaq8JW7f(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		cQ5atG1jMP = P_1.Button == MouseButtons.Right;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BxsaK6taWQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kvUa0bKhHy(this, jpOaB7j4p1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && kqZaa7F4Xx != null)
		{
			kqZaa7F4Xx.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Hu8ahmrwVJ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kqZaa7F4Xx = new Container();
		VvGaX3Ceum = new Label();
		XApaxXndBh = new Label();
		KPUaeA6XoE = new Label();
		BHiaM3iD1T = new Label();
		WisaLncMM7 = new ContextMenuStrip(kqZaa7F4Xx);
		XPnag3U6EL = new ToolStripMenuItem();
		XHjaRJjeXN = new PictureBoxWithInterpolationMode();
		OhnaPMU9Hi = new PictureBoxWithInterpolationMode();
		h42aUHZFto = new PictureBoxWithInterpolationMode();
		WisaLncMM7.SuspendLayout();
		((ISupportInitialize)XHjaRJjeXN).BeginInit();
		((ISupportInitialize)OhnaPMU9Hi).BeginInit();
		((ISupportInitialize)h42aUHZFto).BeginInit();
		SuspendLayout();
		VvGaX3Ceum.AutoSize = true;
		VvGaX3Ceum.BackColor = Color.Transparent;
		VvGaX3Ceum.Location = new Point(81, 9);
		VvGaX3Ceum.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10178);
		VvGaX3Ceum.Size = new Size(35, 13);
		VvGaX3Ceum.TabIndex = 0;
		VvGaX3Ceum.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		VvGaX3Ceum.Click += IqgasjgShV;
		VvGaX3Ceum.MouseDown += hKaaq8JW7f;
		VvGaX3Ceum.MouseEnter += MpjaZXtgE1;
		VvGaX3Ceum.MouseLeave += xtfaf7PUPs;
		XApaxXndBh.AutoSize = true;
		XApaxXndBh.BackColor = Color.Transparent;
		XApaxXndBh.Location = new Point(81, 28);
		XApaxXndBh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28150);
		XApaxXndBh.Size = new Size(41, 13);
		XApaxXndBh.TabIndex = 1;
		XApaxXndBh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28172);
		XApaxXndBh.Click += IqgasjgShV;
		XApaxXndBh.MouseDown += hKaaq8JW7f;
		XApaxXndBh.MouseEnter += MpjaZXtgE1;
		XApaxXndBh.MouseLeave += xtfaf7PUPs;
		KPUaeA6XoE.AutoSize = true;
		KPUaeA6XoE.BackColor = Color.Transparent;
		KPUaeA6XoE.Location = new Point(81, 47);
		KPUaeA6XoE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28190);
		KPUaeA6XoE.Size = new Size(45, 13);
		KPUaeA6XoE.TabIndex = 2;
		KPUaeA6XoE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28212);
		KPUaeA6XoE.Click += IqgasjgShV;
		KPUaeA6XoE.MouseDown += hKaaq8JW7f;
		KPUaeA6XoE.MouseEnter += MpjaZXtgE1;
		KPUaeA6XoE.MouseLeave += xtfaf7PUPs;
		BHiaM3iD1T.AutoSize = true;
		BHiaM3iD1T.BackColor = Color.Transparent;
		BHiaM3iD1T.Location = new Point(81, 66);
		BHiaM3iD1T.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28230);
		BHiaM3iD1T.Size = new Size(51, 13);
		BHiaM3iD1T.TabIndex = 3;
		BHiaM3iD1T.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28256);
		BHiaM3iD1T.Click += IqgasjgShV;
		BHiaM3iD1T.MouseDown += hKaaq8JW7f;
		BHiaM3iD1T.MouseEnter += MpjaZXtgE1;
		BHiaM3iD1T.MouseLeave += xtfaf7PUPs;
		WisaLncMM7.Items.AddRange(new ToolStripItem[1] { XPnag3U6EL });
		WisaLncMM7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20692);
		WisaLncMM7.Size = new Size(108, 26);
		XPnag3U6EL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28278);
		XPnag3U6EL.Size = new Size(107, 22);
		XPnag3U6EL.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326);
		XPnag3U6EL.Click += BxsaK6taWQ;
		XHjaRJjeXN.InterpolationMode = InterpolationMode.NearestNeighbor;
		XHjaRJjeXN.Location = new Point(128, 47);
		XHjaRJjeXN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28300);
		XHjaRJjeXN.Size = new Size(190, 16);
		XHjaRJjeXN.TabIndex = 6;
		XHjaRJjeXN.TabStop = false;
		XHjaRJjeXN.Click += IqgasjgShV;
		XHjaRJjeXN.MouseDown += hKaaq8JW7f;
		XHjaRJjeXN.MouseEnter += MpjaZXtgE1;
		XHjaRJjeXN.MouseLeave += xtfaf7PUPs;
		OhnaPMU9Hi.InterpolationMode = InterpolationMode.NearestNeighbor;
		OhnaPMU9Hi.Location = new Point(128, 26);
		OhnaPMU9Hi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28320);
		OhnaPMU9Hi.Size = new Size(190, 16);
		OhnaPMU9Hi.TabIndex = 5;
		OhnaPMU9Hi.TabStop = false;
		OhnaPMU9Hi.Click += IqgasjgShV;
		OhnaPMU9Hi.MouseDown += hKaaq8JW7f;
		OhnaPMU9Hi.MouseEnter += MpjaZXtgE1;
		OhnaPMU9Hi.MouseLeave += xtfaf7PUPs;
		h42aUHZFto.BackgroundImage = Resources.dVaSE9EwSab();
		h42aUHZFto.InterpolationMode = InterpolationMode.NearestNeighbor;
		h42aUHZFto.Location = new Point(8, 10);
		h42aUHZFto.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28340);
		h42aUHZFto.Size = new Size(64, 64);
		h42aUHZFto.TabIndex = 4;
		h42aUHZFto.TabStop = false;
		h42aUHZFto.Click += IqgasjgShV;
		h42aUHZFto.MouseDown += hKaaq8JW7f;
		h42aUHZFto.MouseEnter += MpjaZXtgE1;
		h42aUHZFto.MouseLeave += xtfaf7PUPs;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.BorderStyle = BorderStyle.FixedSingle;
		ContextMenuStrip = WisaLncMM7;
		base.Controls.Add(XHjaRJjeXN);
		base.Controls.Add(OhnaPMU9Hi);
		base.Controls.Add(h42aUHZFto);
		base.Controls.Add(BHiaM3iD1T);
		base.Controls.Add(KPUaeA6XoE);
		base.Controls.Add(XApaxXndBh);
		base.Controls.Add(VvGaX3Ceum);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28408);
		base.Size = new Size(320, 88);
		base.Click += IqgasjgShV;
		base.MouseDown += hKaaq8JW7f;
		base.MouseEnter += MpjaZXtgE1;
		base.MouseLeave += xtfaf7PUPs;
		WisaLncMM7.ResumeLayout(performLayout: false);
		((ISupportInitialize)XHjaRJjeXN).EndInit();
		((ISupportInitialize)OhnaPMU9Hi).EndInit();
		((ISupportInitialize)h42aUHZFto).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PlayerItemUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		QNJamrgHNC = new Dictionary<int, Bitmap>();
		KRlankyD54 = new Dictionary<int, Bitmap>();
	}
}
