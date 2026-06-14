using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controllers;
using MCCToolChest.controls.EntityHelpers;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class EntityEditor : UserControl
{
	private TagNodeList tXNWng28Pr;

	private TagNodeList LBWWlFT7Pe;

	private EntityLookup NyWW2Q3H3l;

	private static ImageList aXMWyi2q4B;

	private static Dictionary<string, int> IolW0nluBi;

	private EntityLookup UGFWBvqN8t;

	private IContainer bDhWtfMRhX;

	private SplitContainer PeEWaZhdyw;

	private TreeView LIpWXLaIxZ;

	private TreeView n8oWxDC23D;

	private SplitContainer T80WeL00ZR;

	private EntityHelperContainer SkPWMaObkr;

	public TagNodeList TileEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return tXNWng28Pr;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			tXNWng28Pr = value;
			pHxWw7wdso(tXNWng28Pr);
		}
	}

	public TagNodeList Entities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return LBWWlFT7Pe;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			LBWWlFT7Pe = value;
			PWFWTSQjHs(LBWWlFT7Pe);
			LIpWXLaIxZ.SelectedNode = null;
		}
	}

	public int ChunkX
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return SkPWMaObkr.ChunkX;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			SkPWMaObkr.ChunkX = value;
		}
	}

	public int ChunkZ
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return SkPWMaObkr.ChunkZ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			SkPWMaObkr.ChunkZ = value;
		}
	}

	public List<ChunkYLayer> Layers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return SkPWMaObkr.Layers;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			SkPWMaObkr.Layers = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntityEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		NyWW2Q3H3l = new EntityLookup();
		UGFWBvqN8t = new EntityLookup();
		naLWmaZLA7();
		if (aXMWyi2q4B == null)
		{
			aXMWyi2q4B = new ImageList();
			aXMWyi2q4B.ColorDepth = ColorDepth.Depth32Bit;
			aXMWyi2q4B.TransparentColor = Color.Transparent;
			aXMWyi2q4B.ImageSize = new Size(32, 32);
			Bitmap value = new Bitmap(32, 32);
			aXMWyi2q4B.Images.Add(value);
			IolW0nluBi = new Dictionary<string, int>();
		}
		LIpWXLaIxZ.ImageList = MobImageManager.MobImages;
		n8oWxDC23D.ImageList = aXMWyi2q4B;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PWFWTSQjHs(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LIpWXLaIxZ.Nodes.Clear();
		if (P_0 != null)
		{
			for (int i = 0; i < P_0.Count; i++)
			{
				TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
				UPEWS2sYfM(tagNodeCompound);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UPEWS2sYfM(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 == null)
		{
			return;
		}
		string text = SkPWMaObkr.GetIDName(P_0);
		if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702) && P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)))
		{
			TagNodeCompound tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
			{
				string key = "";
				if (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
				{
					key = (TagNodeString)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
				}
				if (UGFWBvqN8t.PCEntities.ContainsKey(key))
				{
					text = UGFWBvqN8t.PCEntities[key].ConsoleName;
				}
			}
		}
		string text2 = text;
		if (text2.IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974)) >= 0 && NyWW2Q3H3l.PCEntities.ContainsKey(text2))
		{
			text2 = NyWW2Q3H3l.PCEntities[text2].ConsoleName;
		}
		Tuple<Guid, TagNodeCompound> tag = new Tuple<Guid, TagNodeCompound>(Guid.NewGuid(), P_0);
		string text3 = W40WGr5xly(P_0);
		TreeNode treeNode = new TreeNode(text3);
		treeNode.ImageKey = text2;
		treeNode.SelectedImageKey = text2;
		treeNode.Tag = tag;
		LIpWXLaIxZ.Nodes.Add(treeNode);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string W40WGr5xly(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string empty = string.Empty;
		string iDName = SkPWMaObkr.GetIDName(P_0);
		string text = string.Empty;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716)))
		{
			text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13740) + (P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716)] as TagNodeString);
		}
		return iDName + text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ceeWbLmE5r(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (LIpWXLaIxZ.HitTest(P_1.Location).Node != null)
		{
			LIpWXLaIxZ.SelectedNode = LIpWXLaIxZ.HitTest(P_1.Location).Node;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lZJWvM7aWT(object P_0, TreeViewEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (LIpWXLaIxZ.SelectedNode == null)
		{
			return;
		}
		if (LIpWXLaIxZ.SelectedNode.Tag is Tuple<Guid, TagNodeCompound> tuple)
		{
			_ = tuple.Item1;
			TagNodeCompound item = tuple.Item2;
			if (item != null)
			{
				SkPWMaObkr.ActiveEntity = item;
			}
		}
		n8oWxDC23D.SelectedNode = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pHxWw7wdso(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		n8oWxDC23D.Nodes.Clear();
		if (P_0 != null)
		{
			for (int i = 0; i < P_0.Count; i++)
			{
				TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
				rKLW479X7A(tagNodeCompound);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rKLW479X7A(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			string text = (TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
			int num = e3FWVpB6d3(text);
			Tuple<Guid, TagNodeCompound> tag = new Tuple<Guid, TagNodeCompound>(Guid.NewGuid(), P_0);
			TreeNode treeNode = new TreeNode();
			treeNode.ImageIndex = num;
			treeNode.SelectedImageIndex = num;
			treeNode.Text = text;
			treeNode.Tag = tag;
			n8oWxDC23D.Nodes.Add(treeNode);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int e3FWVpB6d3(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		P_0.IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974));
		_ = 0;
		if (IolW0nluBi.ContainsKey(P_0))
		{
			num = IolW0nluBi[P_0];
		}
		else if (Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME.ContainsKey(P_0))
		{
			int num2 = Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME[P_0];
			Image image = BFRL2f2UoG7tBGIHJF.xRoSMGJq48(num2, 0);
			if (image != null)
			{
				num = aXMWyi2q4B.Images.Count;
				aXMWyi2q4B.Images.Add(image);
				IolW0nluBi.Add(P_0, num);
			}
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qmDWWSZIcQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SkPWMaObkr.ResizeEntityHelpers();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yWFWp6jhPw(object P_0, SplitterEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SkPWMaObkr.ResizeEntityHelpers();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEntity(TagNodeCompound entity, EntityType entityType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (entityType == EntityType.Entity)
		{
			LBWWlFT7Pe.Add(entity);
			UPEWS2sYfM(entity);
		}
		else
		{
			tXNWng28Pr.Add(entity);
			rKLW479X7A(entity);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zFsWZus4X7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		iu2WfeV7UI();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iu2WfeV7UI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Tuple<Guid, TagNodeCompound> tuple = LIpWXLaIxZ.SelectedNode.Tag as Tuple<Guid, TagNodeCompound>;
		TagNodeCompound item = tuple.Item2;
		LIpWXLaIxZ.SelectedNode.Text = W40WGr5xly(item);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uNTWiZEg8m(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (n8oWxDC23D.HitTest(P_1.Location).Node != null)
		{
			n8oWxDC23D.SelectedNode = n8oWxDC23D.HitTest(P_1.Location).Node;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void msTWsZfyxp(object P_0, TreeViewEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (n8oWxDC23D.SelectedNode == null)
		{
			return;
		}
		if (n8oWxDC23D.SelectedNode.Tag is Tuple<Guid, TagNodeCompound> tuple)
		{
			_ = tuple.Item1;
			TagNodeCompound item = tuple.Item2;
			if (item != null)
			{
				SkPWMaObkr.ActiveEntity = item;
			}
		}
		LIpWXLaIxZ.SelectedNode = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OCOWqirin2(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.KeyCode == Keys.Delete && LIpWXLaIxZ.SelectedNode != null)
		{
			Tuple<Guid, TagNodeCompound> tuple = LIpWXLaIxZ.SelectedNode.Tag as Tuple<Guid, TagNodeCompound>;
			SkPWMaObkr.ActiveEntity = null;
			LIpWXLaIxZ.Nodes.Remove(LIpWXLaIxZ.SelectedNode);
			LBWWlFT7Pe.Remove(tuple.Item2);
			if (LIpWXLaIxZ.SelectedNode == null)
			{
				SkPWMaObkr.ClearDisplay();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bbXWKlHGhl(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.KeyCode == Keys.Delete && n8oWxDC23D.SelectedNode != null)
		{
			Tuple<Guid, TagNodeCompound> tuple = n8oWxDC23D.SelectedNode.Tag as Tuple<Guid, TagNodeCompound>;
			SkPWMaObkr.ActiveEntity = null;
			n8oWxDC23D.Nodes.Remove(n8oWxDC23D.SelectedNode);
			tXNWng28Pr.Remove(tuple.Item2);
			if (n8oWxDC23D.SelectedNode == null)
			{
				SkPWMaObkr.ClearDisplay();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void kngWhtAtHF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SkPWMaObkr.SaveEntityChanges();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && bDhWtfMRhX != null)
		{
			bDhWtfMRhX.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void naLWmaZLA7()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PeEWaZhdyw = new SplitContainer();
		T80WeL00ZR = new SplitContainer();
		LIpWXLaIxZ = new TreeView();
		n8oWxDC23D = new TreeView();
		SkPWMaObkr = new EntityHelperContainer();
		((ISupportInitialize)PeEWaZhdyw).BeginInit();
		PeEWaZhdyw.Panel1.SuspendLayout();
		PeEWaZhdyw.Panel2.SuspendLayout();
		PeEWaZhdyw.SuspendLayout();
		((ISupportInitialize)T80WeL00ZR).BeginInit();
		T80WeL00ZR.Panel1.SuspendLayout();
		T80WeL00ZR.Panel2.SuspendLayout();
		T80WeL00ZR.SuspendLayout();
		SuspendLayout();
		PeEWaZhdyw.Dock = DockStyle.Fill;
		PeEWaZhdyw.Location = new Point(0, 0);
		PeEWaZhdyw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		PeEWaZhdyw.Panel1.Controls.Add(T80WeL00ZR);
		PeEWaZhdyw.Panel2.Controls.Add(SkPWMaObkr);
		PeEWaZhdyw.Size = new Size(684, 672);
		PeEWaZhdyw.SplitterDistance = 179;
		PeEWaZhdyw.TabIndex = 0;
		PeEWaZhdyw.SplitterMoved += yWFWp6jhPw;
		PeEWaZhdyw.ClientSizeChanged += qmDWWSZIcQ;
		T80WeL00ZR.Dock = DockStyle.Fill;
		T80WeL00ZR.Location = new Point(0, 0);
		T80WeL00ZR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13784);
		T80WeL00ZR.Orientation = Orientation.Horizontal;
		T80WeL00ZR.Panel1.Controls.Add(LIpWXLaIxZ);
		T80WeL00ZR.Panel2.Controls.Add(n8oWxDC23D);
		T80WeL00ZR.Size = new Size(179, 672);
		T80WeL00ZR.SplitterDistance = 337;
		T80WeL00ZR.TabIndex = 1;
		LIpWXLaIxZ.Dock = DockStyle.Fill;
		LIpWXLaIxZ.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LIpWXLaIxZ.FullRowSelect = true;
		LIpWXLaIxZ.HideSelection = false;
		LIpWXLaIxZ.ItemHeight = 34;
		LIpWXLaIxZ.Location = new Point(0, 0);
		LIpWXLaIxZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13818);
		LIpWXLaIxZ.ShowLines = false;
		LIpWXLaIxZ.ShowPlusMinus = false;
		LIpWXLaIxZ.ShowRootLines = false;
		LIpWXLaIxZ.Size = new Size(179, 337);
		LIpWXLaIxZ.TabIndex = 0;
		LIpWXLaIxZ.AfterSelect += lZJWvM7aWT;
		LIpWXLaIxZ.KeyDown += OCOWqirin2;
		LIpWXLaIxZ.MouseDown += ceeWbLmE5r;
		n8oWxDC23D.Dock = DockStyle.Fill;
		n8oWxDC23D.FullRowSelect = true;
		n8oWxDC23D.HideSelection = false;
		n8oWxDC23D.Location = new Point(0, 0);
		n8oWxDC23D.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13842);
		n8oWxDC23D.ShowLines = false;
		n8oWxDC23D.ShowPlusMinus = false;
		n8oWxDC23D.ShowRootLines = false;
		n8oWxDC23D.Size = new Size(179, 331);
		n8oWxDC23D.TabIndex = 0;
		n8oWxDC23D.AfterSelect += msTWsZfyxp;
		n8oWxDC23D.KeyDown += bbXWKlHGhl;
		n8oWxDC23D.MouseDown += uNTWiZEg8m;
		SkPWMaObkr.ActiveEntity = null;
		SkPWMaObkr.ChunkX = 0;
		SkPWMaObkr.ChunkZ = 0;
		SkPWMaObkr.Dock = DockStyle.Fill;
		SkPWMaObkr.Layers = null;
		SkPWMaObkr.Location = new Point(0, 0);
		SkPWMaObkr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13874);
		SkPWMaObkr.Size = new Size(501, 672);
		SkPWMaObkr.TabIndex = 0;
		SkPWMaObkr.EntityChanged += zFsWZus4X7;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(PeEWaZhdyw);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13922);
		base.Size = new Size(684, 672);
		base.Resize += qmDWWSZIcQ;
		PeEWaZhdyw.Panel1.ResumeLayout(performLayout: false);
		PeEWaZhdyw.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)PeEWaZhdyw).EndInit();
		PeEWaZhdyw.ResumeLayout(performLayout: false);
		T80WeL00ZR.Panel1.ResumeLayout(performLayout: false);
		T80WeL00ZR.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)T80WeL00ZR).EndInit();
		T80WeL00ZR.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static EntityEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
