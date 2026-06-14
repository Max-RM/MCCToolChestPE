using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.Properties;
using nJfKIGjYOandKUMf9r2;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class OfferEditorUI : UserControl
{
	private int dykskaIGwj;

	private TagNodeCompound HiTsY4Ltfw;

	private OfferItem l2rs3fuDCH;

	private OfferItemUI fXAs1M1J4y;

	private EnchantOfferForm WGJsEj3QRf;

	private IContainer J4xsr1xEO3;

	private FlowLayoutPanel S46s5tCg2v;

	private EntityHelperHeader iEXs69SQNk;

	private ItemListUI MjHsN2QZGv;

	private Panel zwGsD6MJvS;

	private Button jTHscrt2q3;

	private Button pDHsJGjxTX;

	private Label XlisuQV2Ek;

	private Button YnEso5nO7B;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OfferEditorUI(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		sqvsPZd69r();
		HiTsY4Ltfw = entity;
		F5ps25d8TG();
		hV5std5Y3J();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void F5ps25d8TG()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!HiTsY4Ltfw.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)))
		{
			return;
		}
		TagNodeCompound tagNodeCompound = HiTsY4Ltfw[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)] as TagNodeCompound;
		if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)))
		{
			return;
		}
		TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)] as TagNodeList;
		int num = S46s5tCg2v.ClientSize.Width;
		foreach (TagNodeCompound item in tagNodeList)
		{
			OfferItemUI offerItemUI = new OfferItemUI(item, FIEsMDePCT, lSmsUvGj4P);
			offerItemUI.Width = num;
			S46s5tCg2v.Controls.Add(offerItemUI);
		}
		gEKs0IWvdO();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList AftsyrQAA4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!HiTsY4Ltfw.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)))
		{
			HiTsY4Ltfw[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)] = new TagNodeCompound();
		}
		TagNodeCompound tagNodeCompound = HiTsY4Ltfw[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)] as TagNodeCompound;
		if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)))
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)] = new TagNodeList(TagType.TAG_COMPOUND);
		}
		return tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)] as TagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gEKs0IWvdO()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = S46s5tCg2v.ClientSize.Width - 10;
		for (int i = 0; i < S46s5tCg2v.Controls.Count; i++)
		{
			S46s5tCg2v.Controls[i].Width = num;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList eVbsBb5G2Y()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!HiTsY4Ltfw.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)))
		{
			HiTsY4Ltfw[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)] = new TagNodeCompound();
		}
		TagNodeCompound tagNodeCompound = HiTsY4Ltfw[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)] as TagNodeCompound;
		if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)))
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)] = new TagNodeList(TagType.TAG_COMPOUND);
		}
		return tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)] as TagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hV5std5Y3J()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XlisuQV2Ek.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18534) + eVbsBb5G2Y().Count;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XDJsaBMsJh(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (iEXs69SQNk.ViewState == EntityHelperViewState.Contracted)
		{
			dykskaIGwj = base.Height;
			base.Height = iEXs69SQNk.Top + iEXs69SQNk.Height;
		}
		else
		{
			base.Height = dykskaIGwj;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ai1sXgCStv(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = S46s5tCg2v.ClientSize.Width;
		TagNodeCompound tagNodeCompound = fGAse5jADxgBiXK2mJb.NouSwj6vCtj(false, 10000, 0);
		eVbsBb5G2Y().Add(tagNodeCompound);
		OfferItemUI offerItemUI = new OfferItemUI(tagNodeCompound, FIEsMDePCT, lSmsUvGj4P);
		offerItemUI.Width = num;
		S46s5tCg2v.Controls.Add(offerItemUI);
		hV5std5Y3J();
		gEKs0IWvdO();
		ScrollToBottom(S46s5tCg2v);
		FIEsMDePCT(offerItemUI);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qKysxx66WL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = -1;
		OfferItemUI value = null;
		for (int i = 0; i < S46s5tCg2v.Controls.Count; i++)
		{
			if (S46s5tCg2v.Controls[i] is OfferItemUI && ((OfferItemUI)S46s5tCg2v.Controls[i]).Active)
			{
				num = i;
				value = (OfferItemUI)S46s5tCg2v.Controls[i];
				break;
			}
		}
		if (num >= 0)
		{
			jKEse2TqiZ(((OfferItemUI)S46s5tCg2v.Controls[num]).NdRqXifW2b().KNkSw9LmE1U());
			S46s5tCg2v.Controls.Remove(value);
			if (S46s5tCg2v.Controls.Count > num)
			{
				((OfferItemUI)S46s5tCg2v.Controls[num]).SetActive(active: true);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jKEse2TqiZ(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = eVbsBb5G2Y();
		tagNodeList.Remove(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FIEsMDePCT(OfferItemUI P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < S46s5tCg2v.Controls.Count; i++)
		{
			if (S46s5tCg2v.Controls[i] is OfferItemUI)
			{
				((OfferItemUI)S46s5tCg2v.Controls[i]).SetActive(active: false);
			}
		}
		P_0.SetActive(active: true);
		fXAs1M1J4y = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lSmsUvGj4P(OfferItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		l2rs3fuDCH = P_0;
		if (l2rs3fuDCH != null && WGJsEj3QRf != null)
		{
			WGJsEj3QRf.Update(l2rs3fuDCH);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ScrollToBottom(Panel p)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Control control = new Control();
		control.Parent = p;
		control.Dock = DockStyle.Bottom;
		using Control control2 = control;
		p.ScrollControlIntoView(control2);
		control2.Parent = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vBBsLj1pfL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OfferItemUI.ENCHANT_FORM_SHOWING = true;
		WGJsEj3QRf = new EnchantOfferForm(uLhsgolojr);
		YnEso5nO7B.Enabled = false;
		WGJsEj3QRf.Closed += [MethodImpl(MethodImplOptions.NoInlining)] (object obj, EventArgs e) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			YnEso5nO7B.Enabled = true;
			WGJsEj3QRf = null;
		};
		if (l2rs3fuDCH != null)
		{
			WGJsEj3QRf.Update(l2rs3fuDCH);
		}
		WGJsEj3QRf.Show(this);
		OfferItemUI.ENCHANT_FORM_SHOWING = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uLhsgolojr()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (fXAs1M1J4y != null)
		{
			fXAs1M1J4y.JkFq0nWyHJ();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateInventory()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (UserControl control in S46s5tCg2v.Controls)
		{
			OfferItemUI offerItemUI = control as OfferItemUI;
			offerItemUI.NdRqXifW2b().hgdSw8jyXUM();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && J4xsr1xEO3 != null)
		{
			J4xsr1xEO3.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sqvsPZd69r()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		S46s5tCg2v = new FlowLayoutPanel();
		zwGsD6MJvS = new Panel();
		XlisuQV2Ek = new Label();
		jTHscrt2q3 = new Button();
		pDHsJGjxTX = new Button();
		YnEso5nO7B = new Button();
		MjHsN2QZGv = new ItemListUI();
		iEXs69SQNk = new EntityHelperHeader();
		zwGsD6MJvS.SuspendLayout();
		SuspendLayout();
		S46s5tCg2v.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		S46s5tCg2v.AutoScroll = true;
		S46s5tCg2v.BorderStyle = BorderStyle.FixedSingle;
		S46s5tCg2v.FlowDirection = FlowDirection.TopDown;
		S46s5tCg2v.Location = new Point(8, 79);
		S46s5tCg2v.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18552);
		S46s5tCg2v.Padding = new Padding(0, 6, 0, 0);
		S46s5tCg2v.Size = new Size(317, 460);
		S46s5tCg2v.TabIndex = 1;
		S46s5tCg2v.WrapContents = false;
		zwGsD6MJvS.BackColor = Color.Gray;
		zwGsD6MJvS.Controls.Add(YnEso5nO7B);
		zwGsD6MJvS.Controls.Add(XlisuQV2Ek);
		zwGsD6MJvS.Controls.Add(jTHscrt2q3);
		zwGsD6MJvS.Controls.Add(pDHsJGjxTX);
		zwGsD6MJvS.Location = new Point(8, 51);
		zwGsD6MJvS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		zwGsD6MJvS.Size = new Size(317, 28);
		zwGsD6MJvS.TabIndex = 7;
		XlisuQV2Ek.AutoSize = true;
		XlisuQV2Ek.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		XlisuQV2Ek.ForeColor = Color.White;
		XlisuQV2Ek.Location = new Point(64, 7);
		XlisuQV2Ek.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18582);
		XlisuQV2Ek.Size = new Size(55, 16);
		XlisuQV2Ek.TabIndex = 9;
		XlisuQV2Ek.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18614);
		jTHscrt2q3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		jTHscrt2q3.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		jTHscrt2q3.Image = Resources.GSfSEcQrVsG();
		jTHscrt2q3.Location = new Point(33, 2);
		jTHscrt2q3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14426);
		jTHscrt2q3.Size = new Size(24, 24);
		jTHscrt2q3.TabIndex = 8;
		jTHscrt2q3.UseVisualStyleBackColor = true;
		jTHscrt2q3.Click += qKysxx66WL;
		pDHsJGjxTX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pDHsJGjxTX.Image = Resources.C61S3HP5IFi();
		pDHsJGjxTX.Location = new Point(7, 2);
		pDHsJGjxTX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14448);
		pDHsJGjxTX.Size = new Size(24, 24);
		pDHsJGjxTX.TabIndex = 7;
		pDHsJGjxTX.UseVisualStyleBackColor = true;
		pDHsJGjxTX.Click += ai1sXgCStv;
		YnEso5nO7B.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		YnEso5nO7B.BackgroundImage = Resources.zeRSEw3laGs();
		YnEso5nO7B.BackgroundImageLayout = ImageLayout.Stretch;
		YnEso5nO7B.Location = new Point(288, 3);
		YnEso5nO7B.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18634);
		YnEso5nO7B.Size = new Size(24, 24);
		YnEso5nO7B.TabIndex = 10;
		YnEso5nO7B.UseVisualStyleBackColor = true;
		YnEso5nO7B.Click += vBBsLj1pfL;
		MjHsN2QZGv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		MjHsN2QZGv.Location = new Point(341, 51);
		MjHsN2QZGv.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18658);
		MjHsN2QZGv.Size = new Size(274, 491);
		MjHsN2QZGv.TabIndex = 6;
		iEXs69SQNk.BackColor = Color.Silver;
		iEXs69SQNk.Dock = DockStyle.Top;
		iEXs69SQNk.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		iEXs69SQNk.ForeColor = Color.Black;
		iEXs69SQNk.Location = new Point(0, 0);
		iEXs69SQNk.Margin = new Padding(4);
		iEXs69SQNk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		iEXs69SQNk.Size = new Size(626, 35);
		iEXs69SQNk.TabIndex = 5;
		iEXs69SQNk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500);
		iEXs69SQNk.ViewState = EntityHelperViewState.Expanded;
		iEXs69SQNk.ChangeViewState += XDJsaBMsJh;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(zwGsD6MJvS);
		base.Controls.Add(MjHsN2QZGv);
		base.Controls.Add(iEXs69SQNk);
		base.Controls.Add(S46s5tCg2v);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18684);
		base.Size = new Size(626, 549);
		zwGsD6MJvS.ResumeLayout(performLayout: false);
		zwGsD6MJvS.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private void FNCsRDERMV(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		YnEso5nO7B.Enabled = true;
		WGJsEj3QRf = null;
	}
}
