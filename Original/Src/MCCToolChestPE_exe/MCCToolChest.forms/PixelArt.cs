using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class PixelArt : Form
{
	private Bitmap JNKjRnLGsS;

	private IContainer fesjkeTVlB;

	private ToolStrip V74jYwkgbu;

	private ToolStripButton PNSj3CfoGW;

	private FlowLayoutPanel nGej1jqBQf;

	private DoubleBufferPanel FZAjE9v8tP;

	private SplitContainer Kp2jrsl5Md;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PixelArt()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		liOjPe5I8y();
		FZAjE9v8tP.Paint += OnPanelPaint;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bh6jx1VuUS(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rnKjeUsYxQ();
		FZAjE9v8tP.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rnKjeUsYxQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22324);
		string text2 = FileUtils.BugSgNoWh4E(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22518), text, null, null);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			WkbjMrEjb5(text2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WkbjMrEjb5(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			JNKjRnLGsS = new Bitmap(P_0);
			FZAjE9v8tP.Width = JNKjRnLGsS.Width;
			FZAjE9v8tP.Height = JNKjRnLGsS.Height;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void r8HjUSJQod(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnPanelPaint(object sender, PaintEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Graphics graphics = e.Graphics;
		A97jLMhv38(graphics);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void A97jLMhv38(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (JNKjRnLGsS != null)
		{
			Rectangle rectangle = new Rectangle(0, 0, JNKjRnLGsS.Width, JNKjRnLGsS.Height);
			P_0.DrawImage(JNKjRnLGsS, rectangle, rectangle, GraphicsUnit.Pixel);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void B9sjgGy1FI(object P_0, PaintEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Graphics graphics = P_1.Graphics;
		A97jLMhv38(graphics);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && fesjkeTVlB != null)
		{
			fesjkeTVlB.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void liOjPe5I8y()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(PixelArt));
		V74jYwkgbu = new ToolStrip();
		PNSj3CfoGW = new ToolStripButton();
		nGej1jqBQf = new FlowLayoutPanel();
		Kp2jrsl5Md = new SplitContainer();
		FZAjE9v8tP = new DoubleBufferPanel();
		V74jYwkgbu.SuspendLayout();
		nGej1jqBQf.SuspendLayout();
		((ISupportInitialize)Kp2jrsl5Md).BeginInit();
		Kp2jrsl5Md.Panel1.SuspendLayout();
		Kp2jrsl5Md.SuspendLayout();
		SuspendLayout();
		V74jYwkgbu.AutoSize = false;
		V74jYwkgbu.GripStyle = ToolStripGripStyle.Hidden;
		V74jYwkgbu.Items.AddRange(new ToolStripItem[1] { PNSj3CfoGW });
		V74jYwkgbu.Location = new Point(0, 0);
		V74jYwkgbu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22784);
		V74jYwkgbu.RenderMode = ToolStripRenderMode.System;
		V74jYwkgbu.Size = new Size(965, 45);
		V74jYwkgbu.TabIndex = 23;
		V74jYwkgbu.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22784);
		PNSj3CfoGW.AutoSize = false;
		PNSj3CfoGW.BackColor = Color.Transparent;
		PNSj3CfoGW.DisplayStyle = ToolStripItemDisplayStyle.Text;
		PNSj3CfoGW.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22882));
		PNSj3CfoGW.ImageTransparentColor = Color.Magenta;
		PNSj3CfoGW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22922);
		PNSj3CfoGW.Size = new Size(100, 22);
		PNSj3CfoGW.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22950);
		PNSj3CfoGW.TextImageRelation = TextImageRelation.Overlay;
		PNSj3CfoGW.Click += bh6jx1VuUS;
		nGej1jqBQf.AutoScroll = true;
		nGej1jqBQf.Controls.Add(FZAjE9v8tP);
		nGej1jqBQf.Dock = DockStyle.Fill;
		nGej1jqBQf.Location = new Point(0, 0);
		nGej1jqBQf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20642);
		nGej1jqBQf.Size = new Size(708, 562);
		nGej1jqBQf.TabIndex = 24;
		Kp2jrsl5Md.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Kp2jrsl5Md.Location = new Point(12, 48);
		Kp2jrsl5Md.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		Kp2jrsl5Md.Panel1.Controls.Add(nGej1jqBQf);
		Kp2jrsl5Md.Size = new Size(941, 562);
		Kp2jrsl5Md.SplitterDistance = 708;
		Kp2jrsl5Md.TabIndex = 25;
		FZAjE9v8tP.Location = new Point(3, 3);
		FZAjE9v8tP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20676);
		FZAjE9v8tP.Size = new Size(98, 99);
		FZAjE9v8tP.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(965, 622);
		base.Controls.Add(Kp2jrsl5Md);
		base.Controls.Add(V74jYwkgbu);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62090);
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62110);
		base.Load += r8HjUSJQod;
		V74jYwkgbu.ResumeLayout(performLayout: false);
		V74jYwkgbu.PerformLayout();
		nGej1jqBQf.ResumeLayout(performLayout: false);
		Kp2jrsl5Md.Panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)Kp2jrsl5Md).EndInit();
		Kp2jrsl5Md.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
