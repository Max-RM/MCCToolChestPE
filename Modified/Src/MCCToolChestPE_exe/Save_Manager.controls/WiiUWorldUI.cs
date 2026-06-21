using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Save_Manager.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.controls;

public class WiiUWorldUI : UserControl
{
	private WiiUGameFile Ut6Sx3DFPJA;

	private bool rUvSx1NkrBa;

	private WiiUWorldAction pDRSxEnmtqB;

	private WiiUWorldAction UZXSxroQXAg;

	private IContainer pJmSx5fDeZm;

	private Label GErSx6EY7w4;

	private Label daqSxNAxa3j;

	private PictureBox TaMSxD6gYEI;

	private TextBox l87Sxct3MOY;

	private ContextMenuStrip rwLSxJrmhnM;

	private ToolStripMenuItem c4USxuA1Tne;

	private ToolStripMenuItem JSrSxocXwCy;

	private ToolStripMenuItem X7JSxQyIbgS;

	public bool WorldActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return rUvSx1NkrBa;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			rUvSx1NkrBa = value;
			a7NSxXh6D57(value ? Color.LightBlue : Color.White);
		}
	}

	public WiiUGameFile SaveDef
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Ut6Sx3DFPJA;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Ut6Sx3DFPJA = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WiiUWorldUI(WiiUWorldAction wiiuWorldSelected, WiiUWorldAction wiiuWorldOpen, WiiUGameFile saveDef)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		fFjSxYapKBU();
		pDRSxEnmtqB = wiiuWorldSelected;
		UZXSxroQXAg = wiiuWorldOpen;
		Ut6Sx3DFPJA = saveDef;
		GNgSxBFC8c6();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GNgSxBFC8c6()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		l87Sxct3MOY.Text = Ut6Sx3DFPJA.Name;
		daqSxNAxa3j.Text = Ut6Sx3DFPJA.Name;
		TaMSxD6gYEI.Image = Ut6Sx3DFPJA.Image;
		long size = Ut6Sx3DFPJA.Size;
		float num = (float)size / 1000000f;
		GErSx6EY7w4.Text = num.ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208460));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PPhSxtAk1tX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		a7NSxXh6D57(Color.LightBlue);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mqsSxawEuSZ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!rUvSx1NkrBa)
		{
			a7NSxXh6D57(Color.White);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void a7NSxXh6D57(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Jx8SxxayHX0(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pfWSxg3VhmS();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tbkSxevRYTn(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rCFSxM8ddBL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPySxLvP5Hi();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CY8SxUonSYv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		daqSxNAxa3j.Visible = false;
		l87Sxct3MOY.Visible = true;
		l87Sxct3MOY.Focus();
		pfWSxg3VhmS();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tPySxLvP5Hi()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		daqSxNAxa3j.Visible = true;
		l87Sxct3MOY.Visible = false;
		daqSxNAxa3j.Text = l87Sxct3MOY.Text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pfWSxg3VhmS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pDRSxEnmtqB(this, Ut6Sx3DFPJA);
		rUvSx1NkrBa = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dpwSxPWsyiv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UZXSxroQXAg(this, Ut6Sx3DFPJA);
		rUvSx1NkrBa = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uNiSxRaB7Kp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CY8SxUonSYv();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QbESxkWnZS5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dpwSxPWsyiv();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && pJmSx5fDeZm != null)
		{
			pJmSx5fDeZm.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fFjSxYapKBU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pJmSx5fDeZm = new Container();
		GErSx6EY7w4 = new Label();
		daqSxNAxa3j = new Label();
		TaMSxD6gYEI = new PictureBox();
		l87Sxct3MOY = new TextBox();
		rwLSxJrmhnM = new ContextMenuStrip(pJmSx5fDeZm);
		c4USxuA1Tne = new ToolStripMenuItem();
		X7JSxQyIbgS = new ToolStripMenuItem();
		JSrSxocXwCy = new ToolStripMenuItem();
		((ISupportInitialize)TaMSxD6gYEI).BeginInit();
		rwLSxJrmhnM.SuspendLayout();
		SuspendLayout();
		GErSx6EY7w4.AutoSize = true;
		GErSx6EY7w4.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GErSx6EY7w4.Location = new Point(71, 46);
		GErSx6EY7w4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10208);
		GErSx6EY7w4.Size = new Size(45, 16);
		GErSx6EY7w4.TabIndex = 5;
		GErSx6EY7w4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		GErSx6EY7w4.Click += Jx8SxxayHX0;
		GErSx6EY7w4.DoubleClick += QbESxkWnZS5;
		GErSx6EY7w4.MouseEnter += PPhSxtAk1tX;
		GErSx6EY7w4.MouseLeave += mqsSxawEuSZ;
		daqSxNAxa3j.AutoSize = true;
		daqSxNAxa3j.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		daqSxNAxa3j.Location = new Point(70, 3);
		daqSxNAxa3j.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10178);
		daqSxNAxa3j.Size = new Size(51, 20);
		daqSxNAxa3j.TabIndex = 4;
		daqSxNAxa3j.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		daqSxNAxa3j.Click += Jx8SxxayHX0;
		daqSxNAxa3j.DoubleClick += QbESxkWnZS5;
		daqSxNAxa3j.MouseEnter += PPhSxtAk1tX;
		daqSxNAxa3j.MouseLeave += mqsSxawEuSZ;
		TaMSxD6gYEI.Location = new Point(2, 1);
		TaMSxD6gYEI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85212);
		TaMSxD6gYEI.Size = new Size(64, 64);
		TaMSxD6gYEI.TabIndex = 3;
		TaMSxD6gYEI.TabStop = false;
		TaMSxD6gYEI.Click += Jx8SxxayHX0;
		TaMSxD6gYEI.DoubleClick += QbESxkWnZS5;
		TaMSxD6gYEI.MouseEnter += PPhSxtAk1tX;
		TaMSxD6gYEI.MouseLeave += mqsSxawEuSZ;
		l87Sxct3MOY.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		l87Sxct3MOY.Location = new Point(70, 3);
		l87Sxct3MOY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55110);
		l87Sxct3MOY.Size = new Size(216, 26);
		l87Sxct3MOY.TabIndex = 6;
		l87Sxct3MOY.Visible = false;
		l87Sxct3MOY.Leave += rCFSxM8ddBL;
		rwLSxJrmhnM.Items.AddRange(new ToolStripItem[3] { c4USxuA1Tne, X7JSxQyIbgS, JSrSxocXwCy });
		rwLSxJrmhnM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208562);
		rwLSxJrmhnM.Size = new Size(177, 70);
		c4USxuA1Tne.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85054);
		c4USxuA1Tne.Size = new Size(176, 22);
		c4USxuA1Tne.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60992);
		X7JSxQyIbgS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208688);
		X7JSxQyIbgS.Size = new Size(176, 22);
		X7JSxQyIbgS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208710);
		X7JSxQyIbgS.Click += uNiSxRaB7Kp;
		JSrSxocXwCy.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85072);
		JSrSxocXwCy.Size = new Size(176, 22);
		JSrSxocXwCy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85100);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(GErSx6EY7w4);
		base.Controls.Add(daqSxNAxa3j);
		base.Controls.Add(TaMSxD6gYEI);
		base.Controls.Add(l87Sxct3MOY);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208726);
		base.Size = new Size(292, 67);
		base.Click += Jx8SxxayHX0;
		base.DoubleClick += QbESxkWnZS5;
		base.MouseEnter += PPhSxtAk1tX;
		base.MouseLeave += mqsSxawEuSZ;
		((ISupportInitialize)TaMSxD6gYEI).EndInit();
		rwLSxJrmhnM.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
