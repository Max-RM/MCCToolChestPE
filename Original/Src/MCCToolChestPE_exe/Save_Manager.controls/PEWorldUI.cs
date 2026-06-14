using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.Properties;
using Save_Manager.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.controls;

public class PEWorldUI : UserControl
{
	private PEWorldAction YwNSXpHDhdQ;

	private PEWorldAction hMkSXZ7o8gT;

	private PEWorldFolder JlrSXfdFIrK;

	private bool iMySXif1v3v;

	private IContainer KopSXsfY1Ta;

	private Label uV8SXqtbqGF;

	private Label WfiSXKLXXlA;

	private PictureBox eLLSXhQxFLO;

	private TextBox TleSXmCklOT;

	private ContextMenuStrip GnHSXnIfGUF;

	private ToolStripMenuItem KDNSXlf49T9;

	private ToolStripMenuItem S3ZSX2XEqbX;

	private Label QAmSXyO23UH;

	private Label KYASX0fF8Ei;

	private PictureBox rBsSXBRZ8EA;

	public bool WorldActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return iMySXif1v3v;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			iMySXif1v3v = value;
			aR7SXGlA0dy(value ? Color.LightBlue : Color.White);
		}
	}

	public PEWorldFolder SaveDef
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return JlrSXfdFIrK;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			JlrSXfdFIrK = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWorldUI(PEWorldAction PEWorldSelected, PEWorldAction PEWorldOpen, PEWorldFolder saveDef)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		iIVSXWwnqqT();
		YwNSXpHDhdQ = PEWorldSelected;
		hMkSXZ7o8gT = PEWorldOpen;
		JlrSXfdFIrK = saveDef;
		Qj0SazhPUWr();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Qj0SazhPUWr()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WfiSXKLXXlA.Text = JlrSXfdFIrK.Name;
		eLLSXhQxFLO.Image = JlrSXfdFIrK.Image;
		long size = JlrSXfdFIrK.Size;
		float num = (float)size / 1000000f;
		uV8SXqtbqGF.Text = num.ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208460));
		KYASX0fF8Ei.Text = lxe7hMuSirBXGUQugsD.UCYSg7s8eRf(JlrSXfdFIrK.GameType);
		QAmSXyO23UH.Text = JlrSXfdFIrK.Date.ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84980));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mi6SXTMT85B(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		aR7SXGlA0dy(Color.LightBlue);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void d2lSXS4Fu6x(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!iMySXif1v3v)
		{
			aR7SXGlA0dy(Color.White);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aR7SXGlA0dy(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PebSXbHprx3(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OBlSXwF9FS9();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MTTSXv5r5Ef(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OBlSXwF9FS9();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OBlSXwF9FS9()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		YwNSXpHDhdQ(this, JlrSXfdFIrK);
		iMySXif1v3v = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jXSSX4YAEEP()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hMkSXZ7o8gT(this, JlrSXfdFIrK);
		iMySXif1v3v = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xs9SXVL0g9S(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		jXSSX4YAEEP();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIconVisibility(bool visible)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rBsSXBRZ8EA.Visible = visible;
		uV8SXqtbqGF.Visible = !visible;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && KopSXsfY1Ta != null)
		{
			KopSXsfY1Ta.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iIVSXWwnqqT()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		KopSXsfY1Ta = new Container();
		uV8SXqtbqGF = new Label();
		WfiSXKLXXlA = new Label();
		TleSXmCklOT = new TextBox();
		GnHSXnIfGUF = new ContextMenuStrip(KopSXsfY1Ta);
		KDNSXlf49T9 = new ToolStripMenuItem();
		S3ZSX2XEqbX = new ToolStripMenuItem();
		QAmSXyO23UH = new Label();
		KYASX0fF8Ei = new Label();
		rBsSXBRZ8EA = new PictureBox();
		eLLSXhQxFLO = new PictureBox();
		GnHSXnIfGUF.SuspendLayout();
		((ISupportInitialize)rBsSXBRZ8EA).BeginInit();
		((ISupportInitialize)eLLSXhQxFLO).BeginInit();
		SuspendLayout();
		uV8SXqtbqGF.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		uV8SXqtbqGF.ForeColor = SystemColors.ControlDarkDark;
		uV8SXqtbqGF.Location = new Point(360, 38);
		uV8SXqtbqGF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10208);
		uV8SXqtbqGF.Size = new Size(80, 16);
		uV8SXqtbqGF.TabIndex = 5;
		uV8SXqtbqGF.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		uV8SXqtbqGF.TextAlign = ContentAlignment.MiddleRight;
		uV8SXqtbqGF.Click += PebSXbHprx3;
		uV8SXqtbqGF.DoubleClick += xs9SXVL0g9S;
		uV8SXqtbqGF.MouseEnter += Mi6SXTMT85B;
		uV8SXqtbqGF.MouseLeave += d2lSXS4Fu6x;
		WfiSXKLXXlA.AutoSize = true;
		WfiSXKLXXlA.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		WfiSXKLXXlA.Location = new Point(114, 8);
		WfiSXKLXXlA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10178);
		WfiSXKLXXlA.Size = new Size(51, 20);
		WfiSXKLXXlA.TabIndex = 4;
		WfiSXKLXXlA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		WfiSXKLXXlA.Click += MTTSXv5r5Ef;
		WfiSXKLXXlA.DoubleClick += xs9SXVL0g9S;
		WfiSXKLXXlA.MouseEnter += Mi6SXTMT85B;
		WfiSXKLXXlA.MouseLeave += d2lSXS4Fu6x;
		TleSXmCklOT.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TleSXmCklOT.Location = new Point(114, 8);
		TleSXmCklOT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55110);
		TleSXmCklOT.Size = new Size(216, 26);
		TleSXmCklOT.TabIndex = 6;
		TleSXmCklOT.Visible = false;
		GnHSXnIfGUF.Items.AddRange(new ToolStripItem[2] { KDNSXlf49T9, S3ZSX2XEqbX });
		GnHSXnIfGUF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85026);
		GnHSXnIfGUF.Size = new Size(177, 48);
		KDNSXlf49T9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85054);
		KDNSXlf49T9.Size = new Size(176, 22);
		KDNSXlf49T9.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60992);
		KDNSXlf49T9.Visible = false;
		S3ZSX2XEqbX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85072);
		S3ZSX2XEqbX.Size = new Size(176, 22);
		S3ZSX2XEqbX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85100);
		S3ZSX2XEqbX.Visible = false;
		QAmSXyO23UH.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		QAmSXyO23UH.ForeColor = SystemColors.ControlDarkDark;
		QAmSXyO23UH.Location = new Point(360, 8);
		QAmSXyO23UH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85136);
		QAmSXyO23UH.Size = new Size(80, 16);
		QAmSXyO23UH.TabIndex = 7;
		QAmSXyO23UH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		QAmSXyO23UH.TextAlign = ContentAlignment.MiddleRight;
		QAmSXyO23UH.Click += PebSXbHprx3;
		QAmSXyO23UH.DoubleClick += xs9SXVL0g9S;
		QAmSXyO23UH.MouseEnter += Mi6SXTMT85B;
		QAmSXyO23UH.MouseLeave += d2lSXS4Fu6x;
		KYASX0fF8Ei.AutoSize = true;
		KYASX0fF8Ei.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		KYASX0fF8Ei.ForeColor = SystemColors.ControlDarkDark;
		KYASX0fF8Ei.Location = new Point(115, 38);
		KYASX0fF8Ei.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85000);
		KYASX0fF8Ei.Size = new Size(46, 18);
		KYASX0fF8Ei.TabIndex = 8;
		KYASX0fF8Ei.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		KYASX0fF8Ei.TextAlign = ContentAlignment.MiddleLeft;
		KYASX0fF8Ei.Click += PebSXbHprx3;
		KYASX0fF8Ei.DoubleClick += xs9SXVL0g9S;
		KYASX0fF8Ei.MouseEnter += Mi6SXTMT85B;
		KYASX0fF8Ei.MouseLeave += d2lSXS4Fu6x;
		rBsSXBRZ8EA.Image = Resources.xuBSrSPGlgx();
		rBsSXBRZ8EA.Location = new Point(402, 33);
		rBsSXBRZ8EA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85184);
		rBsSXBRZ8EA.Size = new Size(26, 26);
		rBsSXBRZ8EA.TabIndex = 9;
		rBsSXBRZ8EA.TabStop = false;
		rBsSXBRZ8EA.Visible = false;
		rBsSXBRZ8EA.Click += PebSXbHprx3;
		rBsSXBRZ8EA.DoubleClick += xs9SXVL0g9S;
		rBsSXBRZ8EA.MouseEnter += Mi6SXTMT85B;
		rBsSXBRZ8EA.MouseLeave += d2lSXS4Fu6x;
		eLLSXhQxFLO.Location = new Point(0, 0);
		eLLSXhQxFLO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85212);
		eLLSXhQxFLO.Size = new Size(110, 64);
		eLLSXhQxFLO.SizeMode = PictureBoxSizeMode.StretchImage;
		eLLSXhQxFLO.TabIndex = 3;
		eLLSXhQxFLO.TabStop = false;
		eLLSXhQxFLO.Click += PebSXbHprx3;
		eLLSXhQxFLO.DoubleClick += xs9SXVL0g9S;
		eLLSXhQxFLO.MouseEnter += Mi6SXTMT85B;
		eLLSXhQxFLO.MouseLeave += d2lSXS4Fu6x;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.BorderStyle = BorderStyle.FixedSingle;
		ContextMenuStrip = GnHSXnIfGUF;
		base.Controls.Add(rBsSXBRZ8EA);
		base.Controls.Add(KYASX0fF8Ei);
		base.Controls.Add(QAmSXyO23UH);
		base.Controls.Add(uV8SXqtbqGF);
		base.Controls.Add(WfiSXKLXXlA);
		base.Controls.Add(eLLSXhQxFLO);
		base.Controls.Add(TleSXmCklOT);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208478);
		base.Size = new Size(448, 64);
		base.Click += PebSXbHprx3;
		base.DoubleClick += xs9SXVL0g9S;
		base.MouseEnter += Mi6SXTMT85B;
		base.MouseLeave += d2lSXS4Fu6x;
		GnHSXnIfGUF.ResumeLayout(performLayout: false);
		((ISupportInitialize)rBsSXBRZ8EA).EndInit();
		((ISupportInitialize)eLLSXhQxFLO).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
