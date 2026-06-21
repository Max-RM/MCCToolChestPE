using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.forms;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class ReplaceBlockConfigII : UserControl
{
	private List<BlockChange> QNDxwaKQCY;

	private ConvertType kXrx4rvTUp;

	private ListViewItem tgdxVfXc81;

	private IContainer gY9xWb3AQI;

	private MenuStrip FNaxptKuHc;

	private ToolStripMenuItem i2RxZWBkAf;

	private ToolStripMenuItem qrQxf8vEqv;

	private ToolStripMenuItem JLExi1QFvj;

	private ToolStripMenuItem v1XxsxRDQ0;

	private ToolStripMenuItem fl2xqEoe49;

	private ListViewEx LnlxKbv190;

	private ColumnHeader wA0xhTFXmR;

	private ColumnHeader caxxmBQBwy;

	private ColumnHeader gmIxnjEQSE;

	private ColumnHeader sJAxldXHSW;

	private ColumnHeader bT8x21mlbS;

	private ColumnHeader nNVxy5KWio;

	private ContextMenuStrip wKcx0Qtq7c;

	private ToolStripMenuItem TI8xBHibvt;

	private ToolStripMenuItem JIdxtOZijf;

	private ColumnHeader xIhxaAMla5;

	public List<BlockChange> BlockList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return QNDxwaKQCY;
		}
	}

	public ConvertType ConvertType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return kXrx4rvTUp;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			kXrx4rvTUp = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceBlockConfigII()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		f3Qxv05HXX();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetReset(bool visible)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fl2xqEoe49.Visible = visible;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisplayBlockChangeList(List<BlockChange> blockList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LnlxKbv190.Items.Clear();
		if (blockList != null)
		{
			for (int i = 0; i < blockList.Count; i++)
			{
				jSnXuSCUjH(blockList[i]);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void q1fXJeZoO4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockChange blockChange = new BlockChange();
		ListViewItem listViewItem = jSnXuSCUjH(blockChange);
		el9XoIoZM6();
		listViewItem.Selected = true;
		mMJXAEmvv6();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ListViewItem jSnXuSCUjH(BlockChange P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewItem listViewItem = new ListViewItem();
		ET8XQgKDfw(P_0, listViewItem);
		LnlxKbv190.Items.Add(listViewItem);
		return listViewItem;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void el9XoIoZM6()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (LnlxKbv190.SelectedIndices.Count > 0)
		{
			for (int i = 0; i < LnlxKbv190.SelectedIndices.Count; i++)
			{
				LnlxKbv190.Items[LnlxKbv190.SelectedIndices[i]].Selected = false;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ET8XQgKDfw(BlockChange P_0, ListViewItem P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = P_1.SubItems.Count; i < 7; i++)
		{
			P_1.SubItems.Add(string.Empty);
		}
		string text = "";
		text = ((ConvertType == ConvertType.FROM_PC) ? INYifyudg3hCpcrleHt.EVJS0flQIhs()[P_0.FromBlock].IdName : INYifyudg3hCpcrleHt.zhkS0lPoAGR()[P_0.FromBlock].IdName);
		P_1.Text = text;
		P_1.SubItems[1].Text = (P_0.FromData.Contains(-1) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29052) : IntSringConverter.ConvertToString(P_0.FromData.ToArray()));
		P_1.SubItems[2].Text = (P_0.Layers.Contains(-1) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29084) : IntSringConverter.ConvertToString(P_0.Layers.ToArray()));
		text = ((ConvertType != ConvertType.TO_PC) ? INYifyudg3hCpcrleHt.zhkS0lPoAGR()[P_0.ToBlock].IdName : INYifyudg3hCpcrleHt.EVJS0flQIhs()[P_0.ToBlock].IdName);
		P_1.SubItems[3].Text = text;
		P_1.SubItems[4].Text = ((P_0.ToData == -1) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29108) : P_0.ToData.ToString());
		P_1.SubItems[5].Text = INYifyudg3hCpcrleHt.zhkS0lPoAGR()[P_0.Layer2Block].IdName;
		P_1.SubItems[6].Text = ((P_0.Layer2Data == -1) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29108) : P_0.Layer2Data.ToString());
		P_1.Tag = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<BlockChange> BuildBlockChangeList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockChange> list = new List<BlockChange>();
		for (int i = 0; i < LnlxKbv190.Items.Count; i++)
		{
			if (LnlxKbv190.Items[i].Tag is BlockChange item)
			{
				list.Add(item);
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uYwXOuJwjV(object P_0, CancelEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (LnlxKbv190.SelectedItems.Count == 0)
		{
			TI8xBHibvt.Visible = false;
		}
		else
		{
			TI8xBHibvt.Visible = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jjoXCA04Fh(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (LnlxKbv190.SelectedItems.Count != 0)
		{
			LnlxKbv190.Items.Remove(LnlxKbv190.SelectedItems[0]);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pfrX78NCdQ(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mMJXAEmvv6();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mMJXAEmvv6()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (LnlxKbv190.SelectedItems.Count == 0)
		{
			return;
		}
		ListViewItem listViewItem = LnlxKbv190.SelectedItems[0];
		if (listViewItem.Tag is BlockChange blockChange)
		{
			BlockReplaceType blockReplaceType = BlockReplaceType.ReplacePE;
			if (kXrx4rvTUp == ConvertType.FROM_PC)
			{
				blockReplaceType = BlockReplaceType.ConvertToPE;
			}
			else if (kXrx4rvTUp == ConvertType.TO_PC)
			{
				blockReplaceType = BlockReplaceType.ConvertToPC;
			}
			BlockAssign blockAssign = new BlockAssign(blockChange, blockReplaceType);
			if (blockAssign.ShowDialog(this) == DialogResult.OK)
			{
				ET8XQgKDfw(blockChange, listViewItem);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void R78XdFXvIt(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LnlxKbv190.Items.Clear();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bXQXHE5WwD(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DoPXF2mHWs(object P_0, ItemDragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DoDragDrop(P_1.Item, DragDropEffects.Link);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dXYXjtQJcV(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.Effect = DragDropEffects.Link;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lDVX87wC7Y(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Point point = LnlxKbv190.PointToClient(new Point(P_1.X, P_1.Y));
		ListViewItem itemAt = LnlxKbv190.GetItemAt(point.X, point.Y);
		if (itemAt == null)
		{
			return;
		}
		Rectangle bounds = itemAt.GetBounds(ItemBoundsPortion.Entire);
		bool flag = ((point.Y < bounds.Top + bounds.Height / 2) ? true : false);
		if (tgdxVfXc81 != itemAt)
		{
			if (flag)
			{
				LnlxKbv190.Items.Remove(tgdxVfXc81);
				LnlxKbv190.Items.Insert(itemAt.Index, tgdxVfXc81);
			}
			else
			{
				LnlxKbv190.Items.Remove(tgdxVfXc81);
				LnlxKbv190.Items.Insert(itemAt.Index + 1, tgdxVfXc81);
			}
		}
		tgdxVfXc81 = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vG5X9H32R8(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (tgdxVfXc81 == null)
		{
			return;
		}
		Cursor = Cursors.Hand;
		int num = Math.Min(P_1.Y, LnlxKbv190.Items[LnlxKbv190.Items.Count - 1].GetBounds(ItemBoundsPortion.Entire).Bottom - 1);
		ListViewItem itemAt = LnlxKbv190.GetItemAt(0, num);
		if (itemAt != null)
		{
			Rectangle bounds = itemAt.GetBounds(ItemBoundsPortion.Entire);
			if (P_1.Y < bounds.Top + bounds.Height / 2)
			{
				LnlxKbv190.LineBefore = itemAt.Index;
				LnlxKbv190.LineAfter = -1;
			}
			else
			{
				LnlxKbv190.LineBefore = -1;
				LnlxKbv190.LineAfter = itemAt.Index;
			}
			LnlxKbv190.Invalidate();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void h4MXILf2o6(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tgdxVfXc81 = LnlxKbv190.GetItemAt(P_1.X, P_1.Y);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GU3XzlJh1L(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewEx lnlxKbv = LnlxKbv190;
		int lineAfter = (LnlxKbv190.LineBefore = -1);
		lnlxKbv.LineAfter = lineAfter;
		tgdxVfXc81 = null;
		Cursor = Cursors.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vr7xTKINrc(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (tgdxVfXc81 == null)
		{
			return;
		}
		Cursor = Cursors.Hand;
		Math.Min(P_1.Y, LnlxKbv190.Items[LnlxKbv190.Items.Count - 1].GetBounds(ItemBoundsPortion.Entire).Bottom - 1);
		Point point = LnlxKbv190.PointToClient(new Point(P_1.X, P_1.Y));
		ListViewItem itemAt = LnlxKbv190.GetItemAt(point.X, point.Y);
		if (itemAt != null)
		{
			Rectangle bounds = itemAt.GetBounds(ItemBoundsPortion.Entire);
			if (point.Y < bounds.Top + bounds.Height / 2)
			{
				LnlxKbv190.LineBefore = itemAt.Index;
				LnlxKbv190.LineAfter = -1;
			}
			else
			{
				LnlxKbv190.LineBefore = -1;
				LnlxKbv190.LineAfter = itemAt.Index;
			}
			LnlxKbv190.Invalidate();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oGFxSRa5kp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!cDWxbTeFkg())
		{
			return;
		}
		string blockReplaceDefFolder = Utils.GetBlockReplaceDefFolder();
		string text = FileUtils.BugSgNoWh4E(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29142), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29154), blockReplaceDefFolder);
		if (string.IsNullOrWhiteSpace(text) || !text.ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29142)))
		{
			return;
		}
		using StreamReader streamReader = new StreamReader(text);
		string blockReplaceString = streamReader.ReadToEnd();
		List<BlockChange> blockList = Utils.ConvertBlockReplaceString(blockReplaceString);
		DisplayBlockChangeList(blockList);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Jk4xG3EAIl(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!cDWxbTeFkg())
		{
			return;
		}
		string blockReplaceDefFolder = Utils.GetBlockReplaceDefFolder();
		string text = FileUtils.VXKSgcyptXi(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29142), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29154), blockReplaceDefFolder);
		if (string.IsNullOrWhiteSpace(text) || !text.ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29142)))
		{
			return;
		}
		List<BlockChange> blockChanges = BuildBlockChangeList();
		string value = Utils.CreateBlockReplaceString(blockChanges);
		using StreamWriter streamWriter = new StreamWriter(text, append: false);
		streamWriter.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool cDWxbTeFkg()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new Settings();
		string value = Utils.BRDPath();
		bool result = false;
		if (string.IsNullOrWhiteSpace(value))
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29208) + Environment.NewLine + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29326), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29454));
		}
		else
		{
			result = true;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && gY9xWb3AQI != null)
		{
			gY9xWb3AQI.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void f3Qxv05HXX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		gY9xWb3AQI = new Container();
		FNaxptKuHc = new MenuStrip();
		i2RxZWBkAf = new ToolStripMenuItem();
		qrQxf8vEqv = new ToolStripMenuItem();
		JLExi1QFvj = new ToolStripMenuItem();
		v1XxsxRDQ0 = new ToolStripMenuItem();
		fl2xqEoe49 = new ToolStripMenuItem();
		wKcx0Qtq7c = new ContextMenuStrip(gY9xWb3AQI);
		TI8xBHibvt = new ToolStripMenuItem();
		JIdxtOZijf = new ToolStripMenuItem();
		LnlxKbv190 = new ListViewEx();
		wA0xhTFXmR = new ColumnHeader();
		caxxmBQBwy = new ColumnHeader();
		gmIxnjEQSE = new ColumnHeader();
		sJAxldXHSW = new ColumnHeader();
		bT8x21mlbS = new ColumnHeader();
		nNVxy5KWio = new ColumnHeader();
		xIhxaAMla5 = new ColumnHeader();
		FNaxptKuHc.SuspendLayout();
		wKcx0Qtq7c.SuspendLayout();
		SuspendLayout();
		FNaxptKuHc.Items.AddRange(new ToolStripItem[3] { i2RxZWBkAf, v1XxsxRDQ0, fl2xqEoe49 });
		FNaxptKuHc.Location = new Point(0, 0);
		FNaxptKuHc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		FNaxptKuHc.Size = new Size(813, 24);
		FNaxptKuHc.TabIndex = 1;
		FNaxptKuHc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		i2RxZWBkAf.DropDownItems.AddRange(new ToolStripItem[2] { qrQxf8vEqv, JLExi1QFvj });
		i2RxZWBkAf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29486);
		i2RxZWBkAf.Size = new Size(37, 20);
		i2RxZWBkAf.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29532);
		qrQxf8vEqv.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29544);
		qrQxf8vEqv.Size = new Size(103, 22);
		qrQxf8vEqv.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29568);
		qrQxf8vEqv.Click += oGFxSRa5kp;
		JLExi1QFvj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29580);
		JLExi1QFvj.Size = new Size(103, 22);
		JLExi1QFvj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29604);
		JLExi1QFvj.Click += Jk4xG3EAIl;
		v1XxsxRDQ0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28918);
		v1XxsxRDQ0.Size = new Size(41, 20);
		v1XxsxRDQ0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28934);
		v1XxsxRDQ0.Click += q1fXJeZoO4;
		fl2xqEoe49.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29616);
		fl2xqEoe49.Size = new Size(47, 20);
		fl2xqEoe49.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29636);
		fl2xqEoe49.Click += bXQXHE5WwD;
		wKcx0Qtq7c.Items.AddRange(new ToolStripItem[2] { TI8xBHibvt, JIdxtOZijf });
		wKcx0Qtq7c.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28944);
		wKcx0Qtq7c.Size = new Size(125, 48);
		wKcx0Qtq7c.Opening += uYwXOuJwjV;
		TI8xBHibvt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28278);
		TI8xBHibvt.Size = new Size(124, 22);
		TI8xBHibvt.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326);
		TI8xBHibvt.Click += jjoXCA04Fh;
		JIdxtOZijf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29650);
		JIdxtOZijf.Size = new Size(124, 22);
		JIdxtOZijf.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29678);
		JIdxtOZijf.Click += R78XdFXvIt;
		LnlxKbv190.AllowDrop = true;
		LnlxKbv190.Columns.AddRange(new ColumnHeader[7] { wA0xhTFXmR, caxxmBQBwy, gmIxnjEQSE, sJAxldXHSW, bT8x21mlbS, nNVxy5KWio, xIhxaAMla5 });
		LnlxKbv190.ContextMenuStrip = wKcx0Qtq7c;
		LnlxKbv190.Dock = DockStyle.Fill;
		LnlxKbv190.FullRowSelect = true;
		LnlxKbv190.LineAfter = -1;
		LnlxKbv190.LineBefore = -1;
		LnlxKbv190.Location = new Point(0, 24);
		LnlxKbv190.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29702);
		LnlxKbv190.Size = new Size(813, 360);
		LnlxKbv190.TabIndex = 6;
		LnlxKbv190.UseCompatibleStateImageBehavior = false;
		LnlxKbv190.View = View.Details;
		LnlxKbv190.ItemDrag += DoPXF2mHWs;
		LnlxKbv190.DragDrop += lDVX87wC7Y;
		LnlxKbv190.DragEnter += dXYXjtQJcV;
		LnlxKbv190.DragOver += vr7xTKINrc;
		LnlxKbv190.MouseDoubleClick += pfrX78NCdQ;
		LnlxKbv190.MouseDown += h4MXILf2o6;
		LnlxKbv190.MouseMove += vG5X9H32R8;
		LnlxKbv190.MouseUp += GU3XzlJh1L;
		wA0xhTFXmR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11190);
		wA0xhTFXmR.Width = 140;
		caxxmBQBwy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29728);
		caxxmBQBwy.Width = 100;
		gmIxnjEQSE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11148);
		gmIxnjEQSE.Width = 80;
		sJAxldXHSW.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29750);
		sJAxldXHSW.Width = 140;
		bT8x21mlbS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29778);
		bT8x21mlbS.Width = 80;
		nNVxy5KWio.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29804);
		nNVxy5KWio.Width = 140;
		xIhxaAMla5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29832);
		xIhxaAMla5.Width = 80;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(LnlxKbv190);
		base.Controls.Add(FNaxptKuHc);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29858);
		base.Size = new Size(813, 384);
		FNaxptKuHc.ResumeLayout(performLayout: false);
		FNaxptKuHc.PerformLayout();
		wKcx0Qtq7c.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
