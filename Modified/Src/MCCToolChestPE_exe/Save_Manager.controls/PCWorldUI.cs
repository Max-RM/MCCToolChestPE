using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.Properties;
using Save_Manager.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.controls;

public class PCWorldUI : UserControl
{
	private PCWorldAction ahjSVjgi0ZR;

	private PCWorldAction aWDSV82luoA;

	private PCWorldFolder aJhSV9Td3w6;

	private bool dQiSVIlHCk6;

	private IContainer lSeSVzedQSv;

	private Label zZtSWTNGW1T;

	private Label mjlSWSCPG4E;

	private PictureBox MjBSWGT1wcS;

	private TextBox WYjSWbaQg3x;

	private ContextMenuStrip LM2SWviVAbQ;

	private ToolStripMenuItem pMiSWwube4x;

	private ToolStripMenuItem a1BSW4IY3GU;

	private Label OxCSWVlj3OH;

	private Label tuySWWooFcS;

	private PictureBox vJsSWphYuTf;

	public bool WorldActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return dQiSVIlHCk6;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			dQiSVIlHCk6 = value;
			PnuSVOgkvjT(value ? Color.LightBlue : Color.White);
		}
	}

	public PCWorldFolder SaveDef
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return aJhSV9Td3w6;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			aJhSV9Td3w6 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PCWorldUI(PCWorldAction PCWorldSelected, PCWorldAction PCWorldOpen, PCWorldFolder saveDef)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		To3SVFgsRuh();
		ahjSVjgi0ZR = PCWorldSelected;
		aWDSV82luoA = PCWorldOpen;
		aJhSV9Td3w6 = saveDef;
		EpCSVueqxoR();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EpCSVueqxoR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mjlSWSCPG4E.Text = aJhSV9Td3w6.Name;
		MjBSWGT1wcS.Image = aJhSV9Td3w6.Image;
		long size = aJhSV9Td3w6.Size;
		_ = (float)size / 1000000f;
		zZtSWTNGW1T.Text = lxe7hMuSirBXGUQugsD.UCYSg7s8eRf(aJhSV9Td3w6.GameType);
		tuySWWooFcS.Text = Path.GetFileName(aJhSV9Td3w6.Path);
		OxCSWVlj3OH.Text = aJhSV9Td3w6.Date.ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84980));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void r9USVo5Y3kq(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PnuSVOgkvjT(Color.LightBlue);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YdESVQ6TXrN(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!dQiSVIlHCk6)
		{
			PnuSVOgkvjT(Color.White);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PnuSVOgkvjT(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void c4vSVCeiUCA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uiYSVAijqjJ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cgXSV78Kjlf(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uiYSVAijqjJ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uiYSVAijqjJ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ahjSVjgi0ZR(this, aJhSV9Td3w6);
		dQiSVIlHCk6 = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ivXSVdpqLZP()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		aWDSV82luoA(this, aJhSV9Td3w6);
		dQiSVIlHCk6 = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void G0FSVHNMIwQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ivXSVdpqLZP();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIconVisibility(bool visible)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vJsSWphYuTf.Visible = visible;
		zZtSWTNGW1T.Visible = !visible;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && lSeSVzedQSv != null)
		{
			lSeSVzedQSv.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void To3SVFgsRuh()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lSeSVzedQSv = new Container();
		zZtSWTNGW1T = new Label();
		mjlSWSCPG4E = new Label();
		WYjSWbaQg3x = new TextBox();
		LM2SWviVAbQ = new ContextMenuStrip(lSeSVzedQSv);
		pMiSWwube4x = new ToolStripMenuItem();
		a1BSW4IY3GU = new ToolStripMenuItem();
		OxCSWVlj3OH = new Label();
		tuySWWooFcS = new Label();
		vJsSWphYuTf = new PictureBox();
		MjBSWGT1wcS = new PictureBox();
		LM2SWviVAbQ.SuspendLayout();
		((ISupportInitialize)vJsSWphYuTf).BeginInit();
		((ISupportInitialize)MjBSWGT1wcS).BeginInit();
		SuspendLayout();
		zZtSWTNGW1T.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		zZtSWTNGW1T.ForeColor = SystemColors.ControlDarkDark;
		zZtSWTNGW1T.Location = new Point(360, 38);
		zZtSWTNGW1T.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85000);
		zZtSWTNGW1T.Size = new Size(80, 16);
		zZtSWTNGW1T.TabIndex = 5;
		zZtSWTNGW1T.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		zZtSWTNGW1T.TextAlign = ContentAlignment.MiddleRight;
		zZtSWTNGW1T.Click += c4vSVCeiUCA;
		zZtSWTNGW1T.DoubleClick += G0FSVHNMIwQ;
		zZtSWTNGW1T.MouseEnter += r9USVo5Y3kq;
		zZtSWTNGW1T.MouseLeave += YdESVQ6TXrN;
		mjlSWSCPG4E.AutoSize = true;
		mjlSWSCPG4E.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		mjlSWSCPG4E.Location = new Point(73, 8);
		mjlSWSCPG4E.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10178);
		mjlSWSCPG4E.Size = new Size(51, 20);
		mjlSWSCPG4E.TabIndex = 4;
		mjlSWSCPG4E.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		mjlSWSCPG4E.Click += cgXSV78Kjlf;
		mjlSWSCPG4E.DoubleClick += G0FSVHNMIwQ;
		mjlSWSCPG4E.MouseEnter += r9USVo5Y3kq;
		mjlSWSCPG4E.MouseLeave += YdESVQ6TXrN;
		WYjSWbaQg3x.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		WYjSWbaQg3x.Location = new Point(77, 8);
		WYjSWbaQg3x.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55110);
		WYjSWbaQg3x.Size = new Size(306, 26);
		WYjSWbaQg3x.TabIndex = 6;
		WYjSWbaQg3x.Visible = false;
		LM2SWviVAbQ.Items.AddRange(new ToolStripItem[2] { pMiSWwube4x, a1BSW4IY3GU });
		LM2SWviVAbQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85026);
		LM2SWviVAbQ.Size = new Size(177, 48);
		pMiSWwube4x.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85054);
		pMiSWwube4x.Size = new Size(176, 22);
		pMiSWwube4x.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60992);
		pMiSWwube4x.Visible = false;
		a1BSW4IY3GU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85072);
		a1BSW4IY3GU.Size = new Size(176, 22);
		a1BSW4IY3GU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85100);
		a1BSW4IY3GU.Visible = false;
		OxCSWVlj3OH.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		OxCSWVlj3OH.ForeColor = SystemColors.ControlDarkDark;
		OxCSWVlj3OH.Location = new Point(360, 8);
		OxCSWVlj3OH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85136);
		OxCSWVlj3OH.Size = new Size(80, 16);
		OxCSWVlj3OH.TabIndex = 7;
		OxCSWVlj3OH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		OxCSWVlj3OH.TextAlign = ContentAlignment.MiddleRight;
		OxCSWVlj3OH.Click += c4vSVCeiUCA;
		OxCSWVlj3OH.DoubleClick += G0FSVHNMIwQ;
		OxCSWVlj3OH.MouseEnter += r9USVo5Y3kq;
		OxCSWVlj3OH.MouseLeave += YdESVQ6TXrN;
		tuySWWooFcS.AutoSize = true;
		tuySWWooFcS.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tuySWWooFcS.ForeColor = SystemColors.ControlDarkDark;
		tuySWWooFcS.Location = new Point(74, 38);
		tuySWWooFcS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85154);
		tuySWWooFcS.Size = new Size(46, 18);
		tuySWWooFcS.TabIndex = 8;
		tuySWWooFcS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		tuySWWooFcS.TextAlign = ContentAlignment.MiddleLeft;
		tuySWWooFcS.Click += c4vSVCeiUCA;
		tuySWWooFcS.DoubleClick += G0FSVHNMIwQ;
		tuySWWooFcS.MouseEnter += r9USVo5Y3kq;
		tuySWWooFcS.MouseLeave += YdESVQ6TXrN;
		vJsSWphYuTf.Image = Resources.xuBSrSPGlgx();
		vJsSWphYuTf.Location = new Point(402, 33);
		vJsSWphYuTf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85184);
		vJsSWphYuTf.Size = new Size(26, 26);
		vJsSWphYuTf.TabIndex = 9;
		vJsSWphYuTf.TabStop = false;
		vJsSWphYuTf.Visible = false;
		vJsSWphYuTf.Click += c4vSVCeiUCA;
		vJsSWphYuTf.DoubleClick += G0FSVHNMIwQ;
		vJsSWphYuTf.MouseEnter += r9USVo5Y3kq;
		vJsSWphYuTf.MouseLeave += YdESVQ6TXrN;
		MjBSWGT1wcS.Location = new Point(0, 0);
		MjBSWGT1wcS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85212);
		MjBSWGT1wcS.Size = new Size(64, 64);
		MjBSWGT1wcS.SizeMode = PictureBoxSizeMode.StretchImage;
		MjBSWGT1wcS.TabIndex = 3;
		MjBSWGT1wcS.TabStop = false;
		MjBSWGT1wcS.Click += c4vSVCeiUCA;
		MjBSWGT1wcS.DoubleClick += G0FSVHNMIwQ;
		MjBSWGT1wcS.MouseEnter += r9USVo5Y3kq;
		MjBSWGT1wcS.MouseLeave += YdESVQ6TXrN;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.BorderStyle = BorderStyle.FixedSingle;
		ContextMenuStrip = LM2SWviVAbQ;
		base.Controls.Add(zZtSWTNGW1T);
		base.Controls.Add(vJsSWphYuTf);
		base.Controls.Add(tuySWWooFcS);
		base.Controls.Add(OxCSWVlj3OH);
		base.Controls.Add(mjlSWSCPG4E);
		base.Controls.Add(MjBSWGT1wcS);
		base.Controls.Add(WYjSWbaQg3x);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85242);
		base.Size = new Size(448, 64);
		base.Click += c4vSVCeiUCA;
		base.DoubleClick += G0FSVHNMIwQ;
		base.MouseEnter += r9USVo5Y3kq;
		base.MouseLeave += YdESVQ6TXrN;
		LM2SWviVAbQ.ResumeLayout(performLayout: false);
		((ISupportInitialize)vJsSWphYuTf).EndInit();
		((ISupportInitialize)MjBSWGT1wcS).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
