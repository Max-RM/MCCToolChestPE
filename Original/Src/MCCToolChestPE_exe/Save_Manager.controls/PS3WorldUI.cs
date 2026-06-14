using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Save_Manager.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.controls;

public class PS3WorldUI : UserControl
{
	private PS3WorldAction dJ4SX9rxxSi;

	private PS3WorldAction Gv3SXIsnqV7;

	private PS3GameFile xgUSXzHgbQJ;

	private bool NnlSxTqUyQh;

	private IContainer AlxSxSD2ePv;

	private Label d27SxGIstku;

	private Label bEwSxb0kdU4;

	private PictureBox TQWSxvH87eF;

	private TextBox OwdSxwpGhNp;

	private ContextMenuStrip SRkSx4uYW6g;

	private ToolStripMenuItem nBySxV9cv0F;

	private ToolStripMenuItem kEiSxW8DoJ2;

	private ToolStripMenuItem NaNSxp2Utbj;

	public bool WorldActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return NnlSxTqUyQh;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			NnlSxTqUyQh = value;
			lc8SXCuhcCZ(value ? Color.LightBlue : Color.White);
		}
	}

	public PS3GameFile SaveDef
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return xgUSXzHgbQJ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			xgUSXzHgbQJ = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PS3WorldUI(PS3WorldAction ps3WorldSelected, PS3WorldAction ps3WorldOpen, PS3GameFile saveDef)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		jhTSX8kngyp();
		dJ4SX9rxxSi = ps3WorldSelected;
		Gv3SXIsnqV7 = ps3WorldOpen;
		xgUSXzHgbQJ = saveDef;
		Kg1SXo2FAgW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Kg1SXo2FAgW()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bEwSxb0kdU4.Text = xgUSXzHgbQJ.Name;
		TQWSxvH87eF.Image = xgUSXzHgbQJ.Image;
		long size = xgUSXzHgbQJ.Size;
		float num = (float)size / 1000000f;
		d27SxGIstku.Text = num.ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208460));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JkWSXQghEse(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lc8SXCuhcCZ(Color.LightBlue);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e48SXO7Mqi0(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!NnlSxTqUyQh)
		{
			lc8SXCuhcCZ(Color.White);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lc8SXCuhcCZ(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XDHSX74R84T(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TqjSXd8IaNw();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dtdSXAnBTZ4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TqjSXd8IaNw();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TqjSXd8IaNw()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dJ4SX9rxxSi(this, xgUSXzHgbQJ);
		NnlSxTqUyQh = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FPkSXHBNodU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Gv3SXIsnqV7(this, xgUSXzHgbQJ);
		NnlSxTqUyQh = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dS7SXFvIqoD(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FPkSXHBNodU();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ygSSXjjrE1L(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && AlxSxSD2ePv != null)
		{
			AlxSxSD2ePv.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jhTSX8kngyp()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AlxSxSD2ePv = new Container();
		d27SxGIstku = new Label();
		bEwSxb0kdU4 = new Label();
		TQWSxvH87eF = new PictureBox();
		OwdSxwpGhNp = new TextBox();
		SRkSx4uYW6g = new ContextMenuStrip(AlxSxSD2ePv);
		nBySxV9cv0F = new ToolStripMenuItem();
		kEiSxW8DoJ2 = new ToolStripMenuItem();
		NaNSxp2Utbj = new ToolStripMenuItem();
		((ISupportInitialize)TQWSxvH87eF).BeginInit();
		SRkSx4uYW6g.SuspendLayout();
		SuspendLayout();
		d27SxGIstku.AutoSize = true;
		d27SxGIstku.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		d27SxGIstku.Location = new Point(71, 46);
		d27SxGIstku.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10208);
		d27SxGIstku.Size = new Size(45, 16);
		d27SxGIstku.TabIndex = 5;
		d27SxGIstku.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		d27SxGIstku.Click += XDHSX74R84T;
		d27SxGIstku.DoubleClick += dS7SXFvIqoD;
		d27SxGIstku.MouseEnter += JkWSXQghEse;
		d27SxGIstku.MouseLeave += e48SXO7Mqi0;
		bEwSxb0kdU4.AutoSize = true;
		bEwSxb0kdU4.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		bEwSxb0kdU4.Location = new Point(70, 3);
		bEwSxb0kdU4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10178);
		bEwSxb0kdU4.Size = new Size(51, 20);
		bEwSxb0kdU4.TabIndex = 4;
		bEwSxb0kdU4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		bEwSxb0kdU4.Click += dtdSXAnBTZ4;
		bEwSxb0kdU4.DoubleClick += dS7SXFvIqoD;
		bEwSxb0kdU4.MouseEnter += JkWSXQghEse;
		bEwSxb0kdU4.MouseLeave += e48SXO7Mqi0;
		TQWSxvH87eF.Location = new Point(2, 1);
		TQWSxvH87eF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85212);
		TQWSxvH87eF.Size = new Size(64, 64);
		TQWSxvH87eF.TabIndex = 3;
		TQWSxvH87eF.TabStop = false;
		TQWSxvH87eF.Click += XDHSX74R84T;
		TQWSxvH87eF.DoubleClick += dS7SXFvIqoD;
		TQWSxvH87eF.MouseEnter += JkWSXQghEse;
		TQWSxvH87eF.MouseLeave += e48SXO7Mqi0;
		OwdSxwpGhNp.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		OwdSxwpGhNp.Location = new Point(70, 3);
		OwdSxwpGhNp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55110);
		OwdSxwpGhNp.Size = new Size(216, 26);
		OwdSxwpGhNp.TabIndex = 6;
		OwdSxwpGhNp.Visible = false;
		SRkSx4uYW6g.Items.AddRange(new ToolStripItem[3] { nBySxV9cv0F, kEiSxW8DoJ2, NaNSxp2Utbj });
		SRkSx4uYW6g.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208562);
		SRkSx4uYW6g.Size = new Size(177, 70);
		nBySxV9cv0F.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85054);
		nBySxV9cv0F.Size = new Size(176, 22);
		nBySxV9cv0F.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60992);
		nBySxV9cv0F.Visible = false;
		kEiSxW8DoJ2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208592);
		kEiSxW8DoJ2.Size = new Size(176, 22);
		kEiSxW8DoJ2.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208614);
		kEiSxW8DoJ2.Click += ygSSXjjrE1L;
		NaNSxp2Utbj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85072);
		NaNSxp2Utbj.Size = new Size(176, 22);
		NaNSxp2Utbj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85100);
		NaNSxp2Utbj.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		ContextMenuStrip = SRkSx4uYW6g;
		base.Controls.Add(d27SxGIstku);
		base.Controls.Add(bEwSxb0kdU4);
		base.Controls.Add(TQWSxvH87eF);
		base.Controls.Add(OwdSxwpGhNp);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208630);
		base.Size = new Size(292, 67);
		base.Click += XDHSX74R84T;
		base.DoubleClick += dS7SXFvIqoD;
		base.MouseEnter += JkWSXQghEse;
		base.MouseLeave += e48SXO7Mqi0;
		((ISupportInitialize)TQWSxvH87eF).EndInit();
		SRkSx4uYW6g.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
