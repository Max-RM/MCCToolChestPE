using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using cXUvZQGsy3oNeOsXBK;
using MCCToolChest.controls;
using NBTExplorer.Model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class NBTBeforeAfter : Form
{
	private TagNodeCompound tMQJGFrM7C;

	public TagNodeCompound afterNode;

	private List<CdELYEsI8gGLPIZHPv> PNlJbLleZJ;

	private IContainer uoKJvlvIrt;

	private SplitContainer herJwihqtO;

	private NBTFrame sSTJ4bpNvO;

	private NBTFrame DPXJVeLRLZ;

	private Label FelJWmX2QS;

	private Label t23JpITkJh;

	private Button KnWJZMcShn;

	private Button GgQJfd64nv;

	private SplitContainer I4wJipGXsD;

	private ListView HgkJstHUdg;

	private ColumnHeader aeeJqCbBeH;

	private ColumnHeader ynJJKH7Grp;

	private ColumnHeader cBwJhaBALp;

	private ColumnHeader eygJmSsUpv;

	private Label P2hJnsB840;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NBTBeforeAfter(TagNodeCompound beforeNode, TagNodeCompound afterNode)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		i0AJStMMy7();
		tMQJGFrM7C = beforeNode;
		this.afterNode = afterNode;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CwFcAvgX4j(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Qufcd8DccZ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Qufcd8DccZ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (tMQJGFrM7C != null && afterNode != null)
		{
			W6XcFUMGIj();
		}
		if (tMQJGFrM7C != null)
		{
			TagCompoundDataNode node = new TagCompoundDataNode(tMQJGFrM7C);
			sSTJ4bpNvO.OpenExistingNode(node);
		}
		if (afterNode != null)
		{
			TagCompoundDataNode node2 = new TagCompoundDataNode(afterNode);
			DPXJVeLRLZ.OpenExistingNode(node2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kkIcHKIEK0(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void W6XcFUMGIj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PNlJbLleZJ = new List<CdELYEsI8gGLPIZHPv>();
		HgkJstHUdg.Items.Clear();
		y7XcjBR8gu(tMQJGFrM7C, afterNode, "");
		IlPc8Y9Pwl(tMQJGFrM7C, afterNode, "");
		for (int i = 0; i < PNlJbLleZJ.Count; i++)
		{
			ListViewItem listViewItem = new ListViewItem(PNlJbLleZJ[i].BBQJlFjswE);
			listViewItem.SubItems.Add(PNlJbLleZJ[i].FFAJ2sSJJQ);
			listViewItem.SubItems.Add(PNlJbLleZJ[i].qYJJyg1GUg);
			listViewItem.SubItems.Add(PNlJbLleZJ[i].lCsJ0GTqxB);
			listViewItem.Tag = PNlJbLleZJ[i];
			HgkJstHUdg.Items.Add(listViewItem);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void y7XcjBR8gu(TagNode P_0, TagNode P_1, string P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!(P_0 is TagNodeCompound) || !(P_1 is TagNodeCompound))
		{
			return;
		}
		TagNodeCompound tagNodeCompound = P_0 as TagNodeCompound;
		TagNodeCompound tagNodeCompound2 = P_1 as TagNodeCompound;
		foreach (string key in tagNodeCompound.Keys)
		{
			if (!tagNodeCompound2.ContainsKey(key))
			{
				PNlJbLleZJ.Add(new CdELYEsI8gGLPIZHPv
				{
					BBQJlFjswE = P_2 + key,
					FFAJ2sSJJQ = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53290),
					qYJJyg1GUg = tagNodeCompound[key].ToString()
				});
			}
			else if (tagNodeCompound[key].GetType() != tagNodeCompound2[key].GetType())
			{
				string qYJJyg1GUg = string.Concat(tagNodeCompound[key].GetTagType(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13740), tagNodeCompound[key].ToString());
				string lCsJ0GTqxB = string.Concat(tagNodeCompound2[key].GetTagType(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13740), tagNodeCompound2[key].ToString());
				PNlJbLleZJ.Add(new CdELYEsI8gGLPIZHPv
				{
					BBQJlFjswE = P_2 + key,
					FFAJ2sSJJQ = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53326),
					qYJJyg1GUg = qYJJyg1GUg,
					lCsJ0GTqxB = lCsJ0GTqxB
				});
			}
			else if (tagNodeCompound[key].GetType() == tagNodeCompound2[key].GetType())
			{
				if (tagNodeCompound[key].ToString() != tagNodeCompound2[key].ToString())
				{
					PNlJbLleZJ.Add(new CdELYEsI8gGLPIZHPv
					{
						BBQJlFjswE = P_2 + key,
						FFAJ2sSJJQ = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53364),
						qYJJyg1GUg = tagNodeCompound[key].ToString(),
						lCsJ0GTqxB = tagNodeCompound2[key].ToString()
					});
				}
				if (tagNodeCompound[key] is TagNodeCompound)
				{
					y7XcjBR8gu(tagNodeCompound[key], tagNodeCompound2[key], P_2 + key + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710));
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IlPc8Y9Pwl(TagNode P_0, TagNode P_1, string P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!(P_0 is TagNodeCompound) || !(P_1 is TagNodeCompound))
		{
			return;
		}
		TagNodeCompound tagNodeCompound = P_0 as TagNodeCompound;
		TagNodeCompound tagNodeCompound2 = P_1 as TagNodeCompound;
		foreach (string key in tagNodeCompound2.Keys)
		{
			if (!tagNodeCompound.ContainsKey(key))
			{
				PNlJbLleZJ.Add(new CdELYEsI8gGLPIZHPv
				{
					BBQJlFjswE = P_2 + key,
					FFAJ2sSJJQ = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53404),
					lCsJ0GTqxB = tagNodeCompound2[key].ToString()
				});
			}
			else if (tagNodeCompound[key] is TagNodeCompound && tagNodeCompound[key].GetType() == tagNodeCompound2[key].GetType())
			{
				IlPc8Y9Pwl(tagNodeCompound[key], tagNodeCompound2[key], P_2 + key + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hVpc9UahaR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (HgkJstHUdg.SelectedItems.Count > 0)
		{
			CdELYEsI8gGLPIZHPv cdELYEsI8gGLPIZHPv = HgkJstHUdg.SelectedItems[0].Tag as CdELYEsI8gGLPIZHPv;
			TreeNode treeNode = NMmcIYYTwv(sSTJ4bpNvO.tvNBTEdit, cdELYEsI8gGLPIZHPv.BBQJlFjswE);
			if (treeNode != null)
			{
				sSTJ4bpNvO.Controller.SelectNode(treeNode.Tag as DataNode);
				treeNode.EnsureVisible();
			}
			treeNode = NMmcIYYTwv(DPXJVeLRLZ.tvNBTEdit, cdELYEsI8gGLPIZHPv.BBQJlFjswE);
			if (treeNode != null)
			{
				DPXJVeLRLZ.Controller.SelectNode(treeNode.Tag as DataNode);
				treeNode.EnsureVisible();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TreeNode NMmcIYYTwv(TreeView P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = P_1.Split('.');
		TreeNode treeNode = P_0.Nodes[0];
		string[] array2 = array;
		foreach (string text in array2)
		{
			foreach (TreeNode node in treeNode.Nodes)
			{
				if (node.Tag is TagDataNode tagDataNode && tagDataNode.NodeName == text)
				{
					treeNode = node;
					break;
				}
			}
		}
		return treeNode;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VYpcznDZRk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P2hJnsB840.Visible = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void grjJTF1tTT(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P2hJnsB840.Visible = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && uoKJvlvIrt != null)
		{
			uoKJvlvIrt.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void i0AJStMMy7()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		herJwihqtO = new SplitContainer();
		FelJWmX2QS = new Label();
		sSTJ4bpNvO = new NBTFrame();
		t23JpITkJh = new Label();
		DPXJVeLRLZ = new NBTFrame();
		KnWJZMcShn = new Button();
		GgQJfd64nv = new Button();
		I4wJipGXsD = new SplitContainer();
		HgkJstHUdg = new ListView();
		aeeJqCbBeH = new ColumnHeader();
		ynJJKH7Grp = new ColumnHeader();
		cBwJhaBALp = new ColumnHeader();
		eygJmSsUpv = new ColumnHeader();
		P2hJnsB840 = new Label();
		((ISupportInitialize)herJwihqtO).BeginInit();
		herJwihqtO.Panel1.SuspendLayout();
		herJwihqtO.Panel2.SuspendLayout();
		herJwihqtO.SuspendLayout();
		((ISupportInitialize)I4wJipGXsD).BeginInit();
		I4wJipGXsD.Panel1.SuspendLayout();
		I4wJipGXsD.Panel2.SuspendLayout();
		I4wJipGXsD.SuspendLayout();
		SuspendLayout();
		herJwihqtO.Dock = DockStyle.Fill;
		herJwihqtO.Location = new Point(0, 0);
		herJwihqtO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		herJwihqtO.Panel1.Controls.Add(FelJWmX2QS);
		herJwihqtO.Panel1.Controls.Add(sSTJ4bpNvO);
		herJwihqtO.Panel2.Controls.Add(t23JpITkJh);
		herJwihqtO.Panel2.Controls.Add(DPXJVeLRLZ);
		herJwihqtO.Size = new Size(911, 446);
		herJwihqtO.SplitterDistance = 453;
		herJwihqtO.TabIndex = 0;
		FelJWmX2QS.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		FelJWmX2QS.BackColor = SystemColors.ActiveBorder;
		FelJWmX2QS.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		FelJWmX2QS.Location = new Point(0, 0);
		FelJWmX2QS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		FelJWmX2QS.Padding = new Padding(2, 4, 0, 0);
		FelJWmX2QS.Size = new Size(451, 28);
		FelJWmX2QS.TabIndex = 1;
		FelJWmX2QS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53436);
		sSTJ4bpNvO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		sSTJ4bpNvO.Location = new Point(0, 31);
		sSTJ4bpNvO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53452);
		sSTJ4bpNvO.Size = new Size(450, 415);
		sSTJ4bpNvO.TabIndex = 0;
		t23JpITkJh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		t23JpITkJh.BackColor = SystemColors.ActiveBorder;
		t23JpITkJh.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		t23JpITkJh.Location = new Point(0, 0);
		t23JpITkJh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		t23JpITkJh.Padding = new Padding(2, 4, 0, 0);
		t23JpITkJh.Size = new Size(454, 28);
		t23JpITkJh.TabIndex = 2;
		t23JpITkJh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53474);
		DPXJVeLRLZ.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DPXJVeLRLZ.Location = new Point(0, 31);
		DPXJVeLRLZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53488);
		DPXJVeLRLZ.Size = new Size(451, 415);
		DPXJVeLRLZ.TabIndex = 1;
		KnWJZMcShn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		KnWJZMcShn.DialogResult = DialogResult.Cancel;
		KnWJZMcShn.Location = new Point(824, 613);
		KnWJZMcShn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53508);
		KnWJZMcShn.Size = new Size(75, 23);
		KnWJZMcShn.TabIndex = 18;
		KnWJZMcShn.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		KnWJZMcShn.UseVisualStyleBackColor = true;
		GgQJfd64nv.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		GgQJfd64nv.Location = new Point(737, 613);
		GgQJfd64nv.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35742);
		GgQJfd64nv.Size = new Size(75, 23);
		GgQJfd64nv.TabIndex = 19;
		GgQJfd64nv.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53536);
		GgQJfd64nv.Click += kkIcHKIEK0;
		GgQJfd64nv.MouseEnter += VYpcznDZRk;
		GgQJfd64nv.MouseLeave += grjJTF1tTT;
		I4wJipGXsD.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		I4wJipGXsD.Location = new Point(0, 0);
		I4wJipGXsD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13784);
		I4wJipGXsD.Orientation = Orientation.Horizontal;
		I4wJipGXsD.Panel1.Controls.Add(herJwihqtO);
		I4wJipGXsD.Panel2.Controls.Add(HgkJstHUdg);
		I4wJipGXsD.Size = new Size(911, 605);
		I4wJipGXsD.SplitterDistance = 446;
		I4wJipGXsD.TabIndex = 20;
		HgkJstHUdg.Columns.AddRange(new ColumnHeader[4] { aeeJqCbBeH, ynJJKH7Grp, cBwJhaBALp, eygJmSsUpv });
		HgkJstHUdg.Dock = DockStyle.Fill;
		HgkJstHUdg.FullRowSelect = true;
		HgkJstHUdg.Location = new Point(0, 0);
		HgkJstHUdg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53546);
		HgkJstHUdg.Size = new Size(911, 155);
		HgkJstHUdg.TabIndex = 0;
		HgkJstHUdg.UseCompatibleStateImageBehavior = false;
		HgkJstHUdg.View = View.Details;
		HgkJstHUdg.SelectedIndexChanged += hVpc9UahaR;
		aeeJqCbBeH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		aeeJqCbBeH.Width = 200;
		ynJJKH7Grp.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53568);
		ynJJKH7Grp.Width = 200;
		cBwJhaBALp.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53592);
		cBwJhaBALp.Width = 200;
		eygJmSsUpv.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53614);
		eygJmSsUpv.Width = 200;
		P2hJnsB840.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		P2hJnsB840.Location = new Point(12, 613);
		P2hJnsB840.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53636);
		P2hJnsB840.Size = new Size(656, 23);
		P2hJnsB840.TabIndex = 21;
		P2hJnsB840.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53668);
		P2hJnsB840.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(911, 643);
		base.Controls.Add(P2hJnsB840);
		base.Controls.Add(I4wJipGXsD);
		base.Controls.Add(KnWJZMcShn);
		base.Controls.Add(GgQJfd64nv);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53808);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53840);
		base.Load += CwFcAvgX4j;
		herJwihqtO.Panel1.ResumeLayout(performLayout: false);
		herJwihqtO.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)herJwihqtO).EndInit();
		herJwihqtO.ResumeLayout(performLayout: false);
		I4wJipGXsD.Panel1.ResumeLayout(performLayout: false);
		I4wJipGXsD.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)I4wJipGXsD).EndInit();
		I4wJipGXsD.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
