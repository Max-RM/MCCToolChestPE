using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.utils;
using MCCToolChestDB.Model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class CloudLibraryItem : UserControl
{
	private NBTLibraryItem yoO42M5LMh;

	private bool XOA4yRiNV2;

	private LibraryItemSelected bKl40bcC5d;

	private IContainer WH94BLrCei;

	private PictureBox eE04tBlElH;

	private Label nd54aNKuAk;

	private Label Dhi4XYUyWs;

	private Label nsb4xKkke3;

	private Label XWu4eOBvn7;

	private Label tCC4MnE12y;

	private Label hlO4URXvpB;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CloudLibraryItem(NBTLibraryItem nbtLibraryItem, LibraryItemSelected libraryItemSelected)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		wty4lwcLvV();
		yoO42M5LMh = nbtLibraryItem;
		bKl40bcC5d = libraryItemSelected;
		nd54aNKuAk.Text = nbtLibraryItem.Name;
		Dhi4XYUyWs.Text = nbtLibraryItem.Description;
		XWu4eOBvn7.Text = nbtLibraryItem.Author;
		S5I4noyC4b();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mr04sRfaB9(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!XOA4yRiNV2)
		{
			bKl40bcC5d(yoO42M5LMh);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void upe4q9n20Q(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XOA4yRiNV2 = P_1.Button == MouseButtons.Right;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GwH4KnVMXk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlowLayoutPanel flowLayoutPanel = base.Parent as FlowLayoutPanel;
		flowLayoutPanel.Focus();
		oSc4maKLXy(Color.LightBlue);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LlI4hZaXqp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		oSc4maKLXy(Color.White);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oSc4maKLXy(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void S5I4noyC4b()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			string text = Path.Combine(Utils.LibraryImagePath(), yoO42M5LMh.ID.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722));
			if (File.Exists(text))
			{
				eE04tBlElH.Image = Image.FromFile(text);
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && WH94BLrCei != null)
		{
			WH94BLrCei.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wty4lwcLvV()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		nd54aNKuAk = new Label();
		Dhi4XYUyWs = new Label();
		eE04tBlElH = new PictureBox();
		nsb4xKkke3 = new Label();
		XWu4eOBvn7 = new Label();
		tCC4MnE12y = new Label();
		hlO4URXvpB = new Label();
		((ISupportInitialize)eE04tBlElH).BeginInit();
		SuspendLayout();
		nd54aNKuAk.AutoSize = true;
		nd54aNKuAk.Location = new Point(185, 6);
		nd54aNKuAk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10178);
		nd54aNKuAk.Size = new Size(35, 13);
		nd54aNKuAk.TabIndex = 1;
		nd54aNKuAk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		nd54aNKuAk.Click += Mr04sRfaB9;
		nd54aNKuAk.MouseDown += upe4q9n20Q;
		nd54aNKuAk.MouseEnter += GwH4KnVMXk;
		nd54aNKuAk.MouseLeave += LlI4hZaXqp;
		Dhi4XYUyWs.Location = new Point(144, 44);
		Dhi4XYUyWs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12734);
		Dhi4XYUyWs.Size = new Size(399, 60);
		Dhi4XYUyWs.TabIndex = 2;
		Dhi4XYUyWs.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		Dhi4XYUyWs.Click += Mr04sRfaB9;
		Dhi4XYUyWs.MouseDown += upe4q9n20Q;
		Dhi4XYUyWs.MouseEnter += GwH4KnVMXk;
		Dhi4XYUyWs.MouseLeave += LlI4hZaXqp;
		eE04tBlElH.BackgroundImageLayout = ImageLayout.Center;
		eE04tBlElH.Location = new Point(9, 6);
		eE04tBlElH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12766);
		eE04tBlElH.Size = new Size(128, 128);
		eE04tBlElH.TabIndex = 0;
		eE04tBlElH.TabStop = false;
		eE04tBlElH.Click += Mr04sRfaB9;
		eE04tBlElH.MouseDown += upe4q9n20Q;
		eE04tBlElH.MouseEnter += GwH4KnVMXk;
		eE04tBlElH.MouseLeave += LlI4hZaXqp;
		nsb4xKkke3.AutoSize = true;
		nsb4xKkke3.ForeColor = SystemColors.Highlight;
		nsb4xKkke3.Location = new Point(144, 119);
		nsb4xKkke3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		nsb4xKkke3.Size = new Size(90, 13);
		nsb4xKkke3.TabIndex = 3;
		nsb4xKkke3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12784);
		nsb4xKkke3.Click += Mr04sRfaB9;
		nsb4xKkke3.MouseDown += upe4q9n20Q;
		nsb4xKkke3.MouseEnter += GwH4KnVMXk;
		nsb4xKkke3.MouseLeave += LlI4hZaXqp;
		XWu4eOBvn7.AutoSize = true;
		XWu4eOBvn7.Location = new Point(241, 119);
		XWu4eOBvn7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12824);
		XWu4eOBvn7.Size = new Size(35, 13);
		XWu4eOBvn7.TabIndex = 4;
		XWu4eOBvn7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		XWu4eOBvn7.Click += Mr04sRfaB9;
		XWu4eOBvn7.MouseDown += upe4q9n20Q;
		XWu4eOBvn7.MouseEnter += GwH4KnVMXk;
		XWu4eOBvn7.MouseLeave += LlI4hZaXqp;
		tCC4MnE12y.AutoSize = true;
		tCC4MnE12y.ForeColor = SystemColors.Highlight;
		tCC4MnE12y.Location = new Point(144, 31);
		tCC4MnE12y.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		tCC4MnE12y.Size = new Size(60, 13);
		tCC4MnE12y.TabIndex = 5;
		tCC4MnE12y.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11830);
		tCC4MnE12y.Click += Mr04sRfaB9;
		tCC4MnE12y.MouseDown += upe4q9n20Q;
		tCC4MnE12y.MouseEnter += GwH4KnVMXk;
		tCC4MnE12y.MouseLeave += LlI4hZaXqp;
		hlO4URXvpB.AutoSize = true;
		hlO4URXvpB.ForeColor = SystemColors.Highlight;
		hlO4URXvpB.Location = new Point(144, 6);
		hlO4URXvpB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12846);
		hlO4URXvpB.Size = new Size(35, 13);
		hlO4URXvpB.TabIndex = 6;
		hlO4URXvpB.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		hlO4URXvpB.Click += Mr04sRfaB9;
		hlO4URXvpB.MouseDown += upe4q9n20Q;
		hlO4URXvpB.MouseEnter += GwH4KnVMXk;
		hlO4URXvpB.MouseLeave += LlI4hZaXqp;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.Controls.Add(hlO4URXvpB);
		base.Controls.Add(tCC4MnE12y);
		base.Controls.Add(XWu4eOBvn7);
		base.Controls.Add(nsb4xKkke3);
		base.Controls.Add(Dhi4XYUyWs);
		base.Controls.Add(nd54aNKuAk);
		base.Controls.Add(eE04tBlElH);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12862);
		base.Size = new Size(557, 138);
		base.Click += Mr04sRfaB9;
		base.MouseDown += upe4q9n20Q;
		base.MouseEnter += GwH4KnVMXk;
		base.MouseLeave += LlI4hZaXqp;
		((ISupportInitialize)eE04tBlElH).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
