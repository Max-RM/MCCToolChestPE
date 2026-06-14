using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class ReplaceBiomeConfig : UserControl
{
	private List<BiomeChange> rGSX1TkleJ;

	private BiomeReplace ThUXEtWont;

	private IContainer U6fXrfbOSm;

	private MenuStrip vFlX5UsnyX;

	private ToolStripMenuItem yabX6t9hgd;

	private ContextMenuStrip xD7XNdBB1x;

	private ToolStripMenuItem Mr3XDK296Y;

	private FlowLayoutPanel CApXcCUOfL;

	public List<BiomeChange> BiomeList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return rGSX1TkleJ;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceBiomeConfig()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		mc7X3gx9mu();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisplayBiomeChangeList(List<BiomeChange> biomeList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (biomeList != null)
		{
			for (int i = 0; i < biomeList.Count; i++)
			{
				xhGXLtWvd4(biomeList[i]);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cqaXUD4OO5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeChange biomeChange = new BiomeChange();
		xhGXLtWvd4(biomeChange);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xhGXLtWvd4(BiomeChange P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeReplace biomeReplace = new BiomeReplace();
		biomeReplace.BiomeChange = P_0;
		CApXcCUOfL.Controls.Add(biomeReplace);
		b8GXRk9uWm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int k4MXgoWPur()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!CApXcCUOfL.VerticalScroll.Visible)
		{
			return CApXcCUOfL.Size.Width - 10;
		}
		return CApXcCUOfL.Size.Width - 30;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cciXPqEo6e(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		b8GXRk9uWm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void b8GXRk9uWm()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = k4MXgoWPur();
		for (int i = 0; i < CApXcCUOfL.Controls.Count; i++)
		{
			BiomeReplace biomeReplace = CApXcCUOfL.Controls[i] as BiomeReplace;
			biomeReplace.Width = num;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<BiomeChange> BuildBiomeChangeList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rGSX1TkleJ = new List<BiomeChange>();
		for (int i = 0; i < CApXcCUOfL.Controls.Count; i++)
		{
			BiomeReplace biomeReplace = CApXcCUOfL.Controls[i] as BiomeReplace;
			rGSX1TkleJ.Add(biomeReplace.BiomeChange);
		}
		return rGSX1TkleJ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wl5XklQUTt(object P_0, CancelEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Point pt = CApXcCUOfL.PointToClient(Cursor.Position);
		if (!(CApXcCUOfL.GetChildAtPoint(pt) is BiomeReplace thUXEtWont))
		{
			ThUXEtWont = null;
			P_1.Cancel = true;
		}
		else
		{
			ThUXEtWont = thUXEtWont;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JQUXYv2QOy(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ThUXEtWont != null)
		{
			CApXcCUOfL.Controls.Remove(ThUXEtWont);
			ThUXEtWont = null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && U6fXrfbOSm != null)
		{
			U6fXrfbOSm.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mc7X3gx9mu()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		U6fXrfbOSm = new Container();
		vFlX5UsnyX = new MenuStrip();
		yabX6t9hgd = new ToolStripMenuItem();
		xD7XNdBB1x = new ContextMenuStrip(U6fXrfbOSm);
		Mr3XDK296Y = new ToolStripMenuItem();
		CApXcCUOfL = new FlowLayoutPanel();
		vFlX5UsnyX.SuspendLayout();
		xD7XNdBB1x.SuspendLayout();
		SuspendLayout();
		vFlX5UsnyX.Items.AddRange(new ToolStripItem[1] { yabX6t9hgd });
		vFlX5UsnyX.Location = new Point(0, 0);
		vFlX5UsnyX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		vFlX5UsnyX.Size = new Size(692, 24);
		vFlX5UsnyX.TabIndex = 1;
		vFlX5UsnyX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		yabX6t9hgd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28918);
		yabX6t9hgd.Size = new Size(41, 20);
		yabX6t9hgd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28934);
		yabX6t9hgd.Click += cqaXUD4OO5;
		xD7XNdBB1x.Items.AddRange(new ToolStripItem[1] { Mr3XDK296Y });
		xD7XNdBB1x.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28944);
		xD7XNdBB1x.Size = new Size(108, 26);
		xD7XNdBB1x.Opening += wl5XklQUTt;
		Mr3XDK296Y.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28278);
		Mr3XDK296Y.Size = new Size(152, 22);
		Mr3XDK296Y.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326);
		Mr3XDK296Y.Click += JQUXYv2QOy;
		CApXcCUOfL.AutoScroll = true;
		CApXcCUOfL.ContextMenuStrip = xD7XNdBB1x;
		CApXcCUOfL.Dock = DockStyle.Fill;
		CApXcCUOfL.FlowDirection = FlowDirection.TopDown;
		CApXcCUOfL.Location = new Point(0, 24);
		CApXcCUOfL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28982);
		CApXcCUOfL.Size = new Size(692, 555);
		CApXcCUOfL.TabIndex = 5;
		CApXcCUOfL.WrapContents = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(CApXcCUOfL);
		base.Controls.Add(vFlX5UsnyX);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29012);
		base.Size = new Size(692, 579);
		base.SizeChanged += cciXPqEo6e;
		vFlX5UsnyX.ResumeLayout(performLayout: false);
		vFlX5UsnyX.PerformLayout();
		xD7XNdBB1x.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
