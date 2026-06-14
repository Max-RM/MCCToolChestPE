using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.ConfigData;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class BannerUI : UserControl
{
	private int yCxpKQeIF6;

	private TagNodeCompound eekphIZxF0;

	private BannerPatternUI SBppmUOHFQ;

	private IContainer fW2pneeSQy;

	private PictureBox t8opl95YjN;

	private EntityHelperHeader EUxp2AZTje;

	private FlowLayoutPanel LnlpyBrsi6;

	private Button mIrp0CKnKi;

	private Button dSupBsTf1y;

	private Panel QNCptyhbaV;

	private Button AU3paFjfvf;

	private Button GvIpX9wVHt;

	public int BaseColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return eekphIZxF0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(0)] as TagNodeInt;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			eekphIZxF0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(0)] = new TagNodeInt(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BannerUI(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		BBXpq3Ud1b();
		eekphIZxF0 = entity;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cYlWzelocZ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (EUxp2AZTje.ViewState == EntityHelperViewState.Contracted)
		{
			yCxpKQeIF6 = base.Height;
			base.Height = EUxp2AZTje.Top + EUxp2AZTje.Height;
		}
		else
		{
			base.Height = yCxpKQeIF6;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PT2pT3hatQ(object P_0, PaintEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Graphics graphics = P_1.Graphics;
		Color color = Color.FromArgb(ColorConstants.colorCodes[BaseColor].Color);
		SolidBrush brush = new SolidBrush(color);
		graphics.FillRectangle(brush, 0, 0, t8opl95YjN.Width, t8opl95YjN.Height);
		foreach (Control control in LnlpyBrsi6.Controls)
		{
			BannerPatternUI bannerPatternUI = control as BannerPatternUI;
			BKYpSsT1hK(graphics, bannerPatternUI.Image());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BKYpSsT1hK(Graphics P_0, Image P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.InterpolationMode = InterpolationMode.NearestNeighbor;
		Rectangle destRect = new Rectangle(0, 0, t8opl95YjN.Width, t8opl95YjN.Height);
		P_0.DrawImage(P_1, destRect, 0, 0, P_1.Width, P_1.Height, GraphicsUnit.Pixel);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frrpG7uUrb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mY3pbFBaWs();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mY3pbFBaWs()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		YkLpvaUFte();
		YsJp4Z9h4Q();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YkLpvaUFte()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		int num2 = 0;
		foreach (ColorCode value in ColorConstants.colorCodes.Values)
		{
			ColorButton colorButton = new ColorButton(value.Index, qwppwyNXID);
			colorButton.Size = new Size(20, 20);
			colorButton.Location = new Point(num, num2 * 24);
			colorButton.Visible = true;
			QNCptyhbaV.Controls.Add(colorButton);
			num2++;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qwppwyNXID(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BaseColor = P_0;
		Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YsJp4Z9h4Q()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LnlpyBrsi6.Controls.Clear();
		if (eekphIZxF0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)) && eekphIZxF0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)] is TagNodeList)
		{
			TagNodeList tagNodeList = eekphIZxF0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)] as TagNodeList;
			for (int i = 0; i < tagNodeList.Count; i++)
			{
				TagNodeCompound entity = tagNodeList[i] as TagNodeCompound;
				string patternCode = TagNodeUtils.ReadString(entity, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14342));
				int colorIndex = TagNodeUtils.ReadInt(entity, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14360));
				BannerPatternUI value = new BannerPatternUI(patternCode, colorIndex, EnlpWvkc00, V3lpVZaDpu);
				LnlpyBrsi6.Controls.Add(value);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void V3lpVZaDpu(BannerPatternUI P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SBppmUOHFQ = P_0;
		foreach (Control control in LnlpyBrsi6.Controls)
		{
			BannerPatternUI bannerPatternUI = control as BannerPatternUI;
			bannerPatternUI.SetActiveState(bannerPatternUI == P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnlpWvkc00()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yoCpZB3i2F();
		Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Y57ppTJyBX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (LnlpyBrsi6.Controls.Count < 16)
		{
			BannerPatternUI bannerPatternUI = new BannerPatternUI(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42), 0, EnlpWvkc00, V3lpVZaDpu);
			LnlpyBrsi6.Controls.Add(bannerPatternUI);
			V3lpVZaDpu(bannerPatternUI);
			EnlpWvkc00();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yoCpZB3i2F()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		foreach (Control control in LnlpyBrsi6.Controls)
		{
			BannerPatternUI bannerPatternUI = control as BannerPatternUI;
			TagNodeCompound tagNodeCompound = new TagNodeCompound();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14360)] = new TagNodeInt(bannerPatternUI.PatternColorIndex);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14342)] = new TagNodeString(bannerPatternUI.PatternCode);
			tagNodeList.Add(tagNodeCompound);
		}
		eekphIZxF0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)] = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mRJpfDVsbC(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (SBppmUOHFQ != null)
		{
			LnlpyBrsi6.Controls.Remove(SBppmUOHFQ);
			SBppmUOHFQ = null;
			if (LnlpyBrsi6.Controls.Count > 0)
			{
				V3lpVZaDpu((BannerPatternUI)LnlpyBrsi6.Controls[LnlpyBrsi6.Controls.Count - 1]);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Jq2pim5XAp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (SBppmUOHFQ != null)
		{
			int num = LnlpyBrsi6.Controls.IndexOf(SBppmUOHFQ);
			if (num > 0)
			{
				LnlpyBrsi6.Controls.SetChildIndex(SBppmUOHFQ, num - 1);
				EnlpWvkc00();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yyqpsPrnyi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (SBppmUOHFQ != null)
		{
			int num = LnlpyBrsi6.Controls.IndexOf(SBppmUOHFQ);
			if (num < LnlpyBrsi6.Controls.Count - 1)
			{
				LnlpyBrsi6.Controls.SetChildIndex(SBppmUOHFQ, num + 1);
				EnlpWvkc00();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && fW2pneeSQy != null)
		{
			fW2pneeSQy.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BBXpq3Ud1b()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		t8opl95YjN = new PictureBox();
		LnlpyBrsi6 = new FlowLayoutPanel();
		mIrp0CKnKi = new Button();
		dSupBsTf1y = new Button();
		QNCptyhbaV = new Panel();
		AU3paFjfvf = new Button();
		GvIpX9wVHt = new Button();
		EUxp2AZTje = new EntityHelperHeader();
		((ISupportInitialize)t8opl95YjN).BeginInit();
		SuspendLayout();
		t8opl95YjN.BorderStyle = BorderStyle.FixedSingle;
		t8opl95YjN.Location = new Point(40, 55);
		t8opl95YjN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14374);
		t8opl95YjN.Size = new Size(250, 500);
		t8opl95YjN.TabIndex = 0;
		t8opl95YjN.TabStop = false;
		t8opl95YjN.Paint += PT2pT3hatQ;
		LnlpyBrsi6.AutoScroll = true;
		LnlpyBrsi6.BorderStyle = BorderStyle.FixedSingle;
		LnlpyBrsi6.Location = new Point(306, 55);
		LnlpyBrsi6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14394);
		LnlpyBrsi6.Padding = new Padding(0, 6, 0, 0);
		LnlpyBrsi6.Size = new Size(349, 500);
		LnlpyBrsi6.TabIndex = 3;
		mIrp0CKnKi.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		mIrp0CKnKi.Image = Resources.GSfSEcQrVsG();
		mIrp0CKnKi.Location = new Point(656, 80);
		mIrp0CKnKi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14426);
		mIrp0CKnKi.Size = new Size(24, 24);
		mIrp0CKnKi.TabIndex = 6;
		mIrp0CKnKi.UseVisualStyleBackColor = true;
		mIrp0CKnKi.Click += mRJpfDVsbC;
		dSupBsTf1y.Image = Resources.C61S3HP5IFi();
		dSupBsTf1y.Location = new Point(656, 55);
		dSupBsTf1y.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14448);
		dSupBsTf1y.Size = new Size(24, 24);
		dSupBsTf1y.TabIndex = 5;
		dSupBsTf1y.UseVisualStyleBackColor = true;
		dSupBsTf1y.Click += Y57ppTJyBX;
		QNCptyhbaV.Location = new Point(14, 55);
		QNCptyhbaV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14244);
		QNCptyhbaV.Size = new Size(25, 400);
		QNCptyhbaV.TabIndex = 7;
		AU3paFjfvf.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		AU3paFjfvf.Image = Resources.VIUS1sBuy0A();
		AU3paFjfvf.Location = new Point(656, 138);
		AU3paFjfvf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14464);
		AU3paFjfvf.Size = new Size(24, 24);
		AU3paFjfvf.TabIndex = 9;
		AU3paFjfvf.UseVisualStyleBackColor = true;
		AU3paFjfvf.Click += yyqpsPrnyi;
		GvIpX9wVHt.Image = Resources.h9TS1mr6yVy();
		GvIpX9wVHt.Location = new Point(656, 113);
		GvIpX9wVHt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14482);
		GvIpX9wVHt.Size = new Size(24, 24);
		GvIpX9wVHt.TabIndex = 8;
		GvIpX9wVHt.UseVisualStyleBackColor = true;
		GvIpX9wVHt.Click += Jq2pim5XAp;
		EUxp2AZTje.BackColor = Color.Silver;
		EUxp2AZTje.Dock = DockStyle.Top;
		EUxp2AZTje.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		EUxp2AZTje.ForeColor = Color.Black;
		EUxp2AZTje.Location = new Point(0, 0);
		EUxp2AZTje.Margin = new Padding(4);
		EUxp2AZTje.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		EUxp2AZTje.Size = new Size(695, 35);
		EUxp2AZTje.TabIndex = 2;
		EUxp2AZTje.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14496);
		EUxp2AZTje.ViewState = EntityHelperViewState.Expanded;
		EUxp2AZTje.ChangeViewState += cYlWzelocZ;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(AU3paFjfvf);
		base.Controls.Add(GvIpX9wVHt);
		base.Controls.Add(QNCptyhbaV);
		base.Controls.Add(mIrp0CKnKi);
		base.Controls.Add(dSupBsTf1y);
		base.Controls.Add(LnlpyBrsi6);
		base.Controls.Add(EUxp2AZTje);
		base.Controls.Add(t8opl95YjN);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14512);
		base.Size = new Size(695, 566);
		base.Load += frrpG7uUrb;
		((ISupportInitialize)t8opl95YjN).EndInit();
		ResumeLayout(performLayout: false);
	}
}
