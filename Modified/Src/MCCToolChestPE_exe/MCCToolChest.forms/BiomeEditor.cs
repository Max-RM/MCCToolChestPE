using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.comparer;
using MCCToolChest.controllers;
using MCCToolChest.controls;
using MCCToolChest.events;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class BiomeEditor : Form
{
	private int MPJ633LLPa;

	private byte swZ61dgUFF;

	private byte eTl6E6FQ1U;

	private Color mSR6rJ0BQu;

	private byte[] mBK65vElJG;

	private ToolTip brO661hSgp;

	private IContainer T9I6NjNyTm;

	private SplitContainer Sm86DPVDXg;

	private ListView PV76cerEgD;

	private ColumnHeader pKY6J1nHmS;

	private ColumnHeader yfL6u9siTa;

	private ContextMenuStrip CbO6oDhJiC;

	private ContextMenuStrip DEK6QaDnMA;

	private ToolStripMenuItem uKT6Oihy0G;

	private ToolStripMenuItem KKQ6C8U2jb;

	private ToolStripMenuItem r6v67PpGAi;

	private ColumnHeader Wud6A5lLvT;

	private PictureBox h2T6dYRmZp;

	private Button LxN6Hc2DiT;

	private Button dRx6FH3BYs;

	private ToolStripMenuItem Rq26jYD91d;

	private ToolStripMenuItem Qnw6818uEg;

	private BiomeUI KcB693W9uP;

	private BiomeSelector IZE6INk9dj;

	private BiomeSelector oZS6z7k7Xy;

	private ColumnHeader DVYNTW9MQY;

	public byte[] Biomes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return mBK65vElJG;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			mBK65vElJG = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		MPJ633LLPa = -1;
		EjD6lCFxuj();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeEditor(byte[] biomes, int chunkX, int chunkZ)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		MPJ633LLPa = -1;
		mBK65vElJG = biomes;
		EjD6lCFxuj();
		KcB693W9uP.Biomes = biomes.ToArray();
		KcB693W9uP.ChunkX = chunkX;
		KcB693W9uP.ChunkZ = chunkZ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EjD6lCFxuj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NQE6YH1agv();
		xjY6yINSSr(PV76cerEgD, BiomeLookup.bedrockId);
		KcB693W9uP.ICw4dInQyg(swZ61dgUFF);
		KcB693W9uP.BxU4CVmV62(eTl6E6FQ1U);
		oZS6z7k7Xy.Biome = swZ61dgUFF;
		IZE6INk9dj.Biome = eTl6E6FQ1U;
		mSR6rJ0BQu = h2T6dYRmZp.BackColor;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void v55628qWwn()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		brO661hSgp = new ToolTip();
		brO661hSgp.AutoPopDelay = 5000;
		brO661hSgp.InitialDelay = 500;
		brO661hSgp.ReshowDelay = 200;
		brO661hSgp.ShowAlways = true;
		brO661hSgp.SetToolTip(h2T6dYRmZp, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45178));
		brO661hSgp.SetToolTip(oZS6z7k7Xy, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38614));
		brO661hSgp.SetToolTip(IZE6INk9dj, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38638));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xjY6yINSSr(ListView P_0, Dictionary<int, Biome> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Items.Clear();
		P_0.LargeImageList = BiomeImageManager.BiomeImages;
		P_0.SmallImageList = BiomeImageManager.BiomeImages;
		foreach (Biome value in P_1.Values)
		{
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.ImageKey = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634) + value.BedrockId;
			listViewItem.SubItems.Add(value.BedrockId.ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12920)).ToUpper());
			listViewItem.SubItems.Add(value.Label);
			listViewItem.Tag = value;
			P_0.Items.Add(listViewItem);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NTf60GTt91(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		KcB693W9uP.CopyBiomeActive = !KcB693W9uP.CopyBiomeActive;
		h2T6dYRmZp.BackColor = (KcB693W9uP.CopyBiomeActive ? Color.Aquamarine : mSR6rJ0BQu);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void B9U6BMBQei(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FLj6tLGqcd(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Auq6aidN78(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ijm6XbN0ft(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Rrl6xelFjw(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		v55628qWwn();
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hMD6ePsHdb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGw6MQ1QOY();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PGw6MQ1QOY()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < mBK65vElJG.Length; i++)
		{
			mBK65vElJG[i] = KcB693W9uP.Biomes[i];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void J8J6Ukqq7w(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PV76cerEgD.PointToClient(new Point(P_1.X, P_1.Y));
		ListViewItem itemAt = PV76cerEgD.GetItemAt(P_1.X, P_1.Y);
		foreach (ListViewItem selectedItem in PV76cerEgD.SelectedItems)
		{
			selectedItem.Selected = false;
		}
		if (itemAt != null)
		{
			itemAt.Selected = true;
			Biome biome = itemAt.Tag as Biome;
			if (P_1.Button == MouseButtons.Left)
			{
				oZS6z7k7Xy.Biome = biome.BedrockId;
			}
			else
			{
				IZE6INk9dj.Biome = biome.BedrockId;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tdO6LEOCmo(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeChangedEventArgs e = P_1 as BiomeChangedEventArgs;
		KcB693W9uP.ICw4dInQyg(e.Biome);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aXy6ghTPlp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeChangedEventArgs e = P_1 as BiomeChangedEventArgs;
		KcB693W9uP.BxU4CVmV62(e.Biome);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void spH6P5E0wB(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeCopiedEventArgs e = P_1 as BiomeCopiedEventArgs;
		hhS6Rk7gZt(e);
		h2T6dYRmZp.BackColor = mSR6rJ0BQu;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hhS6Rk7gZt(BiomeCopiedEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.Button == MouseButtons.Left)
		{
			oZS6z7k7Xy.Biome = P_0.Biome;
		}
		else
		{
			IZE6INk9dj.Biome = P_0.Biome;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hbG6kdaP4S(object P_0, ColumnClickEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Column != MPJ633LLPa)
		{
			MPJ633LLPa = P_1.Column;
			PV76cerEgD.Sorting = SortOrder.Ascending;
		}
		else if (PV76cerEgD.Sorting == SortOrder.Ascending)
		{
			PV76cerEgD.Sorting = SortOrder.Descending;
		}
		else
		{
			PV76cerEgD.Sorting = SortOrder.Ascending;
		}
		PV76cerEgD.Sort();
		PV76cerEgD.ListViewItemSorter = new ListViewItemComparer(P_1.Column, PV76cerEgD.Sorting);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && T9I6NjNyTm != null)
		{
			T9I6NjNyTm.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NQE6YH1agv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		T9I6NjNyTm = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BiomeEditor));
		Wud6A5lLvT = new ColumnHeader();
		CbO6oDhJiC = new ContextMenuStrip(T9I6NjNyTm);
		KKQ6C8U2jb = new ToolStripMenuItem();
		r6v67PpGAi = new ToolStripMenuItem();
		Rq26jYD91d = new ToolStripMenuItem();
		Qnw6818uEg = new ToolStripMenuItem();
		DEK6QaDnMA = new ContextMenuStrip(T9I6NjNyTm);
		uKT6Oihy0G = new ToolStripMenuItem();
		LxN6Hc2DiT = new Button();
		dRx6FH3BYs = new Button();
		Sm86DPVDXg = new SplitContainer();
		IZE6INk9dj = new BiomeSelector();
		oZS6z7k7Xy = new BiomeSelector();
		h2T6dYRmZp = new PictureBox();
		KcB693W9uP = new BiomeUI();
		PV76cerEgD = new ListView();
		DVYNTW9MQY = new ColumnHeader();
		pKY6J1nHmS = new ColumnHeader();
		yfL6u9siTa = new ColumnHeader();
		CbO6oDhJiC.SuspendLayout();
		DEK6QaDnMA.SuspendLayout();
		((ISupportInitialize)Sm86DPVDXg).BeginInit();
		Sm86DPVDXg.Panel1.SuspendLayout();
		Sm86DPVDXg.Panel2.SuspendLayout();
		Sm86DPVDXg.SuspendLayout();
		((ISupportInitialize)h2T6dYRmZp).BeginInit();
		SuspendLayout();
		Wud6A5lLvT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11148);
		Wud6A5lLvT.Width = 180;
		CbO6oDhJiC.Items.AddRange(new ToolStripItem[4] { KKQ6C8U2jb, r6v67PpGAi, Rq26jYD91d, Qnw6818uEg });
		CbO6oDhJiC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39412);
		CbO6oDhJiC.Size = new Size(68, 92);
		KKQ6C8U2jb.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39444);
		KKQ6C8U2jb.Size = new Size(67, 22);
		r6v67PpGAi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39492);
		r6v67PpGAi.Size = new Size(67, 22);
		Rq26jYD91d.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39552);
		Rq26jYD91d.Size = new Size(67, 22);
		Qnw6818uEg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39580);
		Qnw6818uEg.Size = new Size(67, 22);
		DEK6QaDnMA.Items.AddRange(new ToolStripItem[1] { uKT6Oihy0G });
		DEK6QaDnMA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39610);
		DEK6QaDnMA.Size = new Size(120, 26);
		uKT6Oihy0G.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39632);
		uKT6Oihy0G.Size = new Size(119, 22);
		uKT6Oihy0G.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45202);
		LxN6Hc2DiT.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		LxN6Hc2DiT.DialogResult = DialogResult.Cancel;
		LxN6Hc2DiT.Location = new Point(697, 507);
		LxN6Hc2DiT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		LxN6Hc2DiT.Size = new Size(75, 23);
		LxN6Hc2DiT.TabIndex = 2;
		LxN6Hc2DiT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		LxN6Hc2DiT.UseVisualStyleBackColor = true;
		dRx6FH3BYs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		dRx6FH3BYs.Location = new Point(614, 507);
		dRx6FH3BYs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		dRx6FH3BYs.Size = new Size(75, 23);
		dRx6FH3BYs.TabIndex = 3;
		dRx6FH3BYs.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		dRx6FH3BYs.UseVisualStyleBackColor = true;
		dRx6FH3BYs.Click += hMD6ePsHdb;
		Sm86DPVDXg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Sm86DPVDXg.Location = new Point(0, 0);
		Sm86DPVDXg.Margin = new Padding(10);
		Sm86DPVDXg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		Sm86DPVDXg.Panel1.Controls.Add(IZE6INk9dj);
		Sm86DPVDXg.Panel1.Controls.Add(oZS6z7k7Xy);
		Sm86DPVDXg.Panel1.Controls.Add(h2T6dYRmZp);
		Sm86DPVDXg.Panel1.Controls.Add(KcB693W9uP);
		Sm86DPVDXg.Panel1.Padding = new Padding(10);
		Sm86DPVDXg.Panel2.Controls.Add(PV76cerEgD);
		Sm86DPVDXg.Panel2.Padding = new Padding(0, 10, 4, 10);
		Sm86DPVDXg.Size = new Size(779, 506);
		Sm86DPVDXg.SplitterDistance = 525;
		Sm86DPVDXg.TabIndex = 1;
		IZE6INk9dj.Location = new Point(262, 470);
		IZE6INk9dj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45226);
		IZE6INk9dj.Size = new Size(179, 29);
		IZE6INk9dj.TabIndex = 9;
		IZE6INk9dj.BiomeChanged += aXy6ghTPlp;
		oZS6z7k7Xy.Location = new Point(13, 470);
		oZS6z7k7Xy.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45266);
		oZS6z7k7Xy.Size = new Size(179, 29);
		oZS6z7k7Xy.TabIndex = 8;
		oZS6z7k7Xy.BiomeChanged += tdO6LEOCmo;
		h2T6dYRmZp.BackgroundImageLayout = ImageLayout.Center;
		h2T6dYRmZp.BorderStyle = BorderStyle.FixedSingle;
		h2T6dYRmZp.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45304));
		h2T6dYRmZp.Location = new Point(467, 11);
		h2T6dYRmZp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45342);
		h2T6dYRmZp.Padding = new Padding(3, 2, 0, 0);
		h2T6dYRmZp.Size = new Size(30, 30);
		h2T6dYRmZp.TabIndex = 6;
		h2T6dYRmZp.TabStop = false;
		h2T6dYRmZp.Click += NTf60GTt91;
		KcB693W9uP.Biomes = null;
		KcB693W9uP.ChunkX = 0;
		KcB693W9uP.ChunkZ = 0;
		KcB693W9uP.CopyBiomeActive = false;
		KcB693W9uP.Location = new Point(0, 0);
		KcB693W9uP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45368);
		KcB693W9uP.Size = new Size(461, 473);
		KcB693W9uP.TabIndex = 7;
		KcB693W9uP.BiomeCopied += spH6P5E0wB;
		PV76cerEgD.Columns.AddRange(new ColumnHeader[3] { DVYNTW9MQY, pKY6J1nHmS, yfL6u9siTa });
		PV76cerEgD.Dock = DockStyle.Fill;
		PV76cerEgD.FullRowSelect = true;
		PV76cerEgD.Location = new Point(0, 10);
		PV76cerEgD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45386);
		PV76cerEgD.Size = new Size(246, 486);
		PV76cerEgD.TabIndex = 0;
		PV76cerEgD.UseCompatibleStateImageBehavior = false;
		PV76cerEgD.View = View.Details;
		PV76cerEgD.ColumnClick += hbG6kdaP4S;
		PV76cerEgD.MouseDown += J8J6Ukqq7w;
		DVYNTW9MQY.Text = "";
		DVYNTW9MQY.Width = 30;
		pKY6J1nHmS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
		pKY6J1nHmS.Width = 30;
		yfL6u9siTa.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45412);
		yfL6u9siTa.Width = 160;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = LxN6Hc2DiT;
		base.ClientSize = new Size(779, 536);
		base.Controls.Add(dRx6FH3BYs);
		base.Controls.Add(LxN6Hc2DiT);
		base.Controls.Add(Sm86DPVDXg);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45426);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45452);
		base.Load += Rrl6xelFjw;
		CbO6oDhJiC.ResumeLayout(performLayout: false);
		DEK6QaDnMA.ResumeLayout(performLayout: false);
		Sm86DPVDXg.Panel1.ResumeLayout(performLayout: false);
		Sm86DPVDXg.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)Sm86DPVDXg).EndInit();
		Sm86DPVDXg.ResumeLayout(performLayout: false);
		((ISupportInitialize)h2T6dYRmZp).EndInit();
		ResumeLayout(performLayout: false);
	}
}
