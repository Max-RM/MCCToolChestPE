using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using jWBDofdcGMieH0qfdS;
using MCCToolChest.controls;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using mwbfmPuu2xATDbQldmM;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class ChunkDesigner : Form
{
	private delegate int brP7YOaaIjJP3w7Exq();

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8
	{
		public int paletteIndexLayer0;

		public int paletteIndexLayer1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass8()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int _003CRebuildBlockStateBlockData_003Eb__4()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return paletteIndexLayer0++;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int _003CRebuildBlockStateBlockData_003Eb__5()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return paletteIndexLayer1++;
		}
	}

	private int TR31TWlffo;

	private int tVy1SFetZK;

	private ChunkYLayer[] COf1GjPtBV;

	private Block T8c1b8J6LG;

	private Block gV71vQuv1x;

	private Block DlZ1wxfc3I;

	private TagNodeList UtL14E0NCi;

	private TagNodeList ngk1Vy6MaY;

	private int[] cN81WxvMnc;

	private Color hx51plCOBg;

	private BlockLayer[] adb1Z0rYVQ;

	private int r7P1fk6qOK;

	private ToolTip gXV1iOii3s;

	private IContainer cDx1sIV8uy;

	private SplitContainer iMV1qTqvrs;

	private SplitContainer Hu41KbPExH;

	private ListView t5y1h9JIbn;

	private ListView A5q1m15FRu;

	private ColumnHeader TJ51n5vbXA;

	private ColumnHeader Gif1lhHJL6;

	private ContextMenuStrip UGG12XCIUo;

	private ContextMenuStrip yvV1yqEOfe;

	private ToolStripMenuItem u4U10IENP8;

	private ToolStripMenuItem gO41Bi3LZM;

	private ToolStripMenuItem L5m1tdPtEC;

	private ColumnHeader R6q1aIbfrR;

	private ChunkUI XsY1Xw31DW;

	private BlockSettingsUI a2o1xs3eIu;

	private BlockSettingsUI tKi1eNKjlQ;

	private PictureBox sTB1M5qd0q;

	private PictureBox oya1UuiyVZ;

	private PictureBox jrw1LxY8yV;

	private PictureBox zoo1gvBMig;

	private PictureBox TpT1PGjiNK;

	private Button I5P1RMvjhD;

	private Button SO31kMnkr8;

	private TextBox cbd1YM4Z09;

	private ToolStripMenuItem iUx13Kidfk;

	private ToolStripMenuItem Boa11Zh50m;

	private CheckBox dP11EhvBpb;

	private BlockSettingsUI s4h1rKsiiR;

	private ColumnHeader xGc153QyhS;

	private Label rGZ16f6yAh;

	private RadioButton yFe1NHvq9o;

	private RadioButton KVZ1D0w89Y;

	[CompilerGenerated]
	private static Func<ChunkYLayer, int> py31cUPJLA;

	[CompilerGenerated]
	private static Func<ChunkYLayer, int> unU1Jlgsox;

	[CompilerGenerated]
	private static Func<ChunkYLayer, int> a3p1uwNIbo;

	[CompilerGenerated]
	private static Func<BlockState, int> J731oxH5YA;

	[CompilerGenerated]
	private static Func<ChunkYLayer, int> jkm1QeXcjS;

	[CompilerGenerated]
	private static Func<ChunkYLayer, int> CTf1OxCIsK;

	public TagNodeList Sections
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ngk1Vy6MaY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ngk1Vy6MaY = value;
		}
	}

	public TagNodeList TileEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return UtL14E0NCi;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			UtL14E0NCi = value;
		}
	}

	public int[] HeightMap
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return cN81WxvMnc;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			cN81WxvMnc = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkDesigner()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		tVy1SFetZK = 255;
		T8c1b8J6LG = new Block();
		gV71vQuv1x = new Block();
		DlZ1wxfc3I = new Block();
		adb1Z0rYVQ = new BlockLayer[2];
		Lv8343SHdm();
		qWy30D6FM0();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkDesigner(TagNodeList sections, TagNodeList tileEntities, TagNodeIntArray heightMapNode, int chunkX, int chunkZ)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		tVy1SFetZK = 255;
		T8c1b8J6LG = new Block();
		gV71vQuv1x = new Block();
		DlZ1wxfc3I = new Block();
		adb1Z0rYVQ = new BlockLayer[2];
		ngk1Vy6MaY = sections;
		UtL14E0NCi = tileEntities;
		Lv8343SHdm();
		XsY1Xw31DW.ChunkX = chunkX;
		XsY1Xw31DW.ChunkZ = chunkZ;
		cN81WxvMnc = heightMapNode.Data;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Lv8343SHdm()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qy83QKZJTS();
		TR31TWlffo = 0;
		ohY3WAFRTb(t5y1h9JIbn, BFRL2f2UoG7tBGIHJF.mAVSRPT1qd().Values.ToList());
		XsY1Xw31DW.mMcwjePRFC(T8c1b8J6LG);
		XsY1Xw31DW.f4Uwdj01tF(gV71vQuv1x);
		tKi1eNKjlQ.Block = T8c1b8J6LG;
		a2o1xs3eIu.Block = gV71vQuv1x;
		s4h1rKsiiR.Block = DlZ1wxfc3I;
		XsY1Xw31DW.SearchBlock = DlZ1wxfc3I;
		XsY1Xw31DW.SearchActive = dP11EhvBpb.Checked;
		hx51plCOBg = jrw1LxY8yV.BackColor;
		F1h3BkVQ4H(ngk1Vy6MaY);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FPk3V9w7Au()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		gXV1iOii3s = new ToolTip();
		gXV1iOii3s.AutoPopDelay = 5000;
		gXV1iOii3s.InitialDelay = 750;
		gXV1iOii3s.ReshowDelay = 200;
		gXV1iOii3s.ShowAlways = true;
		gXV1iOii3s.SetToolTip(jrw1LxY8yV, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38590));
		gXV1iOii3s.SetToolTip(tKi1eNKjlQ, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38614));
		gXV1iOii3s.SetToolTip(a2o1xs3eIu, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38638));
		gXV1iOii3s.SetToolTip(sTB1M5qd0q, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38664));
		gXV1iOii3s.SetToolTip(oya1UuiyVZ, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38690));
		gXV1iOii3s.SetToolTip(TpT1PGjiNK, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38718));
		gXV1iOii3s.SetToolTip(zoo1gvBMig, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38748));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal Block yth3FTnSrQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return gV71vQuv1x;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void J483j4Piml(Block value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		gV71vQuv1x = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal Block zn939SFk4c()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return T8c1b8J6LG;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void XNN3IrHo6J(Block value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		T8c1b8J6LG = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ohY3WAFRTb(ListView P_0, List<jLK03d0ZSlci2XsVe6> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Items.Clear();
		P_0.LargeImageList = BFRL2f2UoG7tBGIHJF.fyLSLwvej3();
		P_0.SmallImageList = BFRL2f2UoG7tBGIHJF.fyLSLwvej3();
		foreach (jLK03d0ZSlci2XsVe6 item in P_1)
		{
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.ImageKey = item.Name;
			string text = item.Description;
			listViewItem.SubItems.Add(text);
			listViewItem.Tag = item;
			P_0.Items.Add(listViewItem);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void d8O3pQbXqX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewItem listViewItem = new ListViewItem();
		ChunkYLayer chunkYLayer = new ChunkYLayer();
		chunkYLayer.Layer = A5q1m15FRu.Items.Count;
		listViewItem.Text = chunkYLayer.Layer.ToString();
		listViewItem.Tag = chunkYLayer;
		A5q1m15FRu.Items.Add(listViewItem);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hto3Z9CGIF(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (A5q1m15FRu.SelectedItems.Count > 0)
		{
			XsY1Xw31DW.Level = A5q1m15FRu.SelectedItems[0].Tag as ChunkYLayer;
			tVy1SFetZK = 255 - XsY1Xw31DW.Level.Layer;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uVO3fBTv7P(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		t5y1h9JIbn.PointToClient(new Point(P_1.X, P_1.Y));
		ListViewItem itemAt = t5y1h9JIbn.GetItemAt(P_1.X, P_1.Y);
		foreach (ListViewItem selectedItem in t5y1h9JIbn.SelectedItems)
		{
			selectedItem.Selected = false;
		}
		if (itemAt != null)
		{
			itemAt.Selected = true;
			jLK03d0ZSlci2XsVe6 jLK03d0ZSlci2XsVe7 = itemAt.Tag as jLK03d0ZSlci2XsVe6;
			Block block = ((P_1.Button != MouseButtons.Left) ? gV71vQuv1x : T8c1b8J6LG);
			MasterBlockItem bedrock = BlockMaster.Blocks[jLK03d0ZSlci2XsVe7.Name].bedrock;
			block.Id = bedrock.id.Value;
			block.Data = bedrock.data.Value;
			block.Light = 0;
			yhn3i3ROmD();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yhn3i3ROmD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tKi1eNKjlQ.UpdateSettingsUI();
		a2o1xs3eIu.UpdateSettingsUI();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Fyq3sxitQm(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XsY1Xw31DW.CopyBlockActive = !XsY1Xw31DW.CopyBlockActive;
		jrw1LxY8yV.BackColor = (XsY1Xw31DW.CopyBlockActive ? Color.Aquamarine : hx51plCOBg);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nfW3qTNdhr(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XsY1Xw31DW.Rotate(RotateType.Left);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oW23KFdLab(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XsY1Xw31DW.Rotate(RotateType.Right);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eOO3hhMb1F(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XsY1Xw31DW.Flip(FlipType.Vertical);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OFd3mYqGm8(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XsY1Xw31DW.Flip(FlipType.Horizontal);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kgJ3nAT6EW(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yhn3i3ROmD();
		jrw1LxY8yV.BackColor = hx51plCOBg;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RBY3lOCjIq(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		FPk3V9w7Au();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Qd332iNff9(ChunkYLayer[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		A5q1m15FRu.Items.Clear();
		for (int num = P_0.Length - 1; num >= 0; num--)
		{
			ChunkYLayer chunkYLayer = P_0[num];
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = chunkYLayer.Layer.ToString();
			listViewItem.SubItems.Add(fPK3yRBdEm(chunkYLayer.TileEntities));
			listViewItem.Tag = chunkYLayer;
			A5q1m15FRu.Items.Add(listViewItem);
		}
		if (tVy1SFetZK > A5q1m15FRu.Items.Count)
		{
			tVy1SFetZK = 0;
		}
		if (A5q1m15FRu.Items.Count > 0)
		{
			A5q1m15FRu.Items[tVy1SFetZK].Selected = true;
			A5q1m15FRu.TopItem = A5q1m15FRu.Items[tVy1SFetZK];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string fPK3yRBdEm(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = P_0.Count - 1; num >= 0; num--)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952));
			}
			TagNodeCompound tagNodeCompound = P_0[num] as TagNodeCompound;
			stringBuilder.Append(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)].ToString());
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qWy30D6FM0()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkYLayer[] array = new ChunkYLayer[64];
		for (int i = 0; i < 64; i++)
		{
			ChunkYLayer chunkYLayer = new ChunkYLayer();
			chunkYLayer.Layer = i;
			array[i] = chunkYLayer;
		}
		Qd332iNff9(array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void F1h3BkVQ4H(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new NibbleSetters();
		adb1Z0rYVQ[0] = new BlockLayer();
		for (int i = 0; i < 256; i++)
		{
			ChunkYLayer chunkYLayer = new ChunkYLayer();
			chunkYLayer.Layer = i;
			adb1Z0rYVQ[0].yLayers[i] = chunkYLayer;
		}
		adb1Z0rYVQ[1] = new BlockLayer();
		for (int j = 0; j < 256; j++)
		{
			ChunkYLayer chunkYLayer2 = new ChunkYLayer();
			chunkYLayer2.Layer = j;
			adb1Z0rYVQ[1].yLayers[j] = chunkYLayer2;
		}
		for (int k = 0; k < P_0.Count; k++)
		{
			TagNodeCompound tagNodeCompound = P_0[k] as TagNodeCompound;
			Gc13tcR9Hw(tagNodeCompound);
		}
		ChunkYLayer[] yLayers = adb1Z0rYVQ[0].yLayers;
		foreach (ChunkYLayer chunkYLayer3 in yLayers)
		{
			for (int num = UtL14E0NCi.Count - 1; num >= 0; num--)
			{
				TagNodeCompound tagNodeCompound2 = UtL14E0NCi[num].Copy() as TagNodeCompound;
				ovfrckujlufyR7DEI0H ovfrckujlufyR7DEI0H2 = lxe7hMuSirBXGUQugsD.asNSPg5KOvd(tagNodeCompound2);
				if (ovfrckujlufyR7DEI0H2.Y == chunkYLayer3.Layer)
				{
					chunkYLayer3.TileEntities.Add(tagNodeCompound2);
					UtL14E0NCi.Remove(tagNodeCompound2);
				}
			}
		}
		Qd332iNff9(adb1Z0rYVQ[0].yLayers);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Gc13tcR9Hw(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		int num = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
		int num2 = num * 16;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)) && P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] is TagNodeByteArray)
		{
			TagNodeByteArray tagNodeByteArray = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] as TagNodeByteArray;
			TagNodeByteArray tagNodeByteArray2 = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeByteArray;
			byte[] data = tagNodeByteArray.Data;
			byte[] data2 = tagNodeByteArray2.Data;
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 256; j++)
				{
					int num3 = i * 256 + j;
					adb1Z0rYVQ[0].yLayers[num2 + i].Blocks[j].Id = data[num3];
					adb1Z0rYVQ[0].yLayers[num2 + i].Blocks[j].Data = nibbleSetters.TU17GetFast(data2, num3);
				}
			}
		}
		else
		{
			if (!P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)) || !(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] is TagNodeList))
			{
				return;
			}
			TR31TWlffo = 1;
			TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] as TagNodeList;
			for (int k = 0; k < tagNodeList.Count; k++)
			{
				TagNodeCompound tagNodeCompound = tagNodeList[k] as TagNodeCompound;
				TagNodeIntArray tagNodeIntArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] as TagNodeIntArray;
				int[] data3 = tagNodeIntArray.Data;
				TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] as TagNodeList;
				BlockState[] array = IOG3aLvqrp(tagNodeList2);
				for (int l = 0; l < 16; l++)
				{
					for (int m = 0; m < 256; m++)
					{
						int num4 = l * 256 + m;
						int num5 = data3[num4];
						adb1Z0rYVQ[k].yLayers[num2 + l].Blocks[m].Id = array[num5].id.Value;
						adb1Z0rYVQ[k].yLayers[num2 + l].Blocks[m].Data = array[num5].data;
					}
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BlockState[] IOG3aLvqrp(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChangeBlockState changeBlockState = new ChangeBlockState();
		BlockState[] array = new BlockState[P_0.Count];
		for (int i = 0; i < P_0.Count; i++)
		{
			string text = (TagNodeString)((TagNodeCompound)P_0[i])[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)];
			int num = 0;
			num = (((TagNodeCompound)P_0[i]).ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19874)) ? changeBlockState.ConvertBlockStatesToDataValue((TagNodeCompound)P_0[i]) : ((int)(TagNodeShort)((TagNodeCompound)P_0[i])[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)]));
			array[i] = uQA3XtvhQq(text, (short)num);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BlockState uQA3XtvhQq(string P_0, short P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!P_0.StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974)))
		{
			P_0 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974) + P_0;
		}
		if (BlockMaster.BedrockBlockStatesByName.ContainsKey(P_0))
		{
			if (BlockMaster.BedrockBlockStatesByName[P_0].ContainsKey(P_1))
			{
				return BlockMaster.BedrockBlockStatesByName[P_0][P_1];
			}
			short key = BlockMaster.BedrockBlockStatesByName[P_0].First().Key;
			BlockState blockState = BlockMaster.BedrockBlockStatesByName[P_0][key];
			blockState.data = P_1;
			return blockState;
		}
		return BlockMaster.BlockStates[0];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vND3xTPMsD(TagNodeList P_0, TagNodeList P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qIJ3MJCpWu(P_0);
		Wqa3Pm1OA9(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vLl3eh3myB(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		Dictionary<int, TagNodeCompound> dictionary = new Dictionary<int, TagNodeCompound>();
		NibbleSetters nibbleSetters = new NibbleSetters();
		bool flag = false;
		for (int i = 0; i < P_0.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
			byte key = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
			dictionary.Add(key, tagNodeCompound);
		}
		ChunkYLayer[] array = adb1Z0rYVQ[0].yLayers.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (ChunkYLayer chunkYLayer2) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return chunkYLayer2.Layer;
		}).ToArray();
		bool flag2 = false;
		for (int num = 15; num >= 0; num--)
		{
			byte[] array2 = new byte[4096];
			byte[] array3 = new byte[2048];
			for (int num2 = 0; num2 < 16; num2++)
			{
				ChunkYLayer chunkYLayer = array[num * 16 + num2];
				for (int num3 = 0; num3 < 256; num3++)
				{
					int num4 = num2 * 256 + num3;
					byte b = (array2[num4] = (byte)chunkYLayer.Blocks[num3].Id);
					nibbleSetters.TU17SetFast(array3, num4, chunkYLayer.Blocks[num3].Data);
					if (b != 0)
					{
						flag2 = true;
					}
				}
			}
			if (flag2 || flag)
			{
				TagNodeCompound tagNodeCompound2 = null;
				if (dictionary.ContainsKey(num))
				{
					tagNodeCompound2 = dictionary[num];
				}
				else
				{
					tagNodeCompound2 = new TagNodeCompound();
					tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)num);
				}
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] = new TagNodeByteArray(array2);
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] = new TagNodeByteArray(array3);
				tagNodeList.Add(tagNodeCompound2);
				flag = true;
			}
		}
		ngk1Vy6MaY = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qIJ3MJCpWu(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		Dictionary<int, TagNodeCompound> dictionary = new Dictionary<int, TagNodeCompound>();
		new NibbleSetters();
		bool flag = false;
		Dictionary<string, Dictionary<short, BlockState>> dictionary2 = new Dictionary<string, Dictionary<short, BlockState>>();
		Dictionary<string, Dictionary<short, BlockState>> dictionary3 = new Dictionary<string, Dictionary<short, BlockState>>();
		for (int i = 0; i < P_0.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)))
			{
				byte key = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
				dictionary.Add(key, tagNodeCompound);
			}
		}
		ChunkYLayer[] array = adb1Z0rYVQ[0].yLayers.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (ChunkYLayer chunkYLayer3) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return chunkYLayer3.Layer;
		}).ToArray();
		ChunkYLayer[] array2 = adb1Z0rYVQ[1].yLayers.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (ChunkYLayer chunkYLayer3) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return chunkYLayer3.Layer;
		}).ToArray();
		bool flag2 = false;
		bool flag3 = false;
		for (int num = 15; num >= 0; num--)
		{
			_003C_003Ec__DisplayClass8 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass8();
			int[] array3 = new int[4096];
			int[] array4 = new int[4096];
			dictionary2.Clear();
			dictionary3.Clear();
			CS_0024_003C_003E8__locals4.paletteIndexLayer0 = 0;
			brP7YOaaIjJP3w7Exq brP7YOaaIjJP3w7Exq2 = [MethodImpl(MethodImplOptions.NoInlining)] () =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return CS_0024_003C_003E8__locals4.paletteIndexLayer0++;
			};
			CS_0024_003C_003E8__locals4.paletteIndexLayer1 = 0;
			brP7YOaaIjJP3w7Exq brP7YOaaIjJP3w7Exq3 = [MethodImpl(MethodImplOptions.NoInlining)] () =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return CS_0024_003C_003E8__locals4.paletteIndexLayer1++;
			};
			flag3 = false;
			for (int num2 = 0; num2 < 16; num2++)
			{
				ChunkYLayer chunkYLayer = array[num * 16 + num2];
				ChunkYLayer chunkYLayer2 = array2[num * 16 + num2];
				for (int num3 = 0; num3 < 256; num3++)
				{
					int num4 = num2 * 256 + num3;
					int id = chunkYLayer.Blocks[num3].Id;
					short num5 = (short)chunkYLayer.Blocks[num3].Data;
					string name = BlockMaster.GetBedrockBlockState(id, num5).name;
					int num6 = WXe3gvD6SU(dictionary2, name, num5, brP7YOaaIjJP3w7Exq2);
					array3[num4] = num6;
					if (id != 0)
					{
						flag2 = true;
					}
					int id2 = chunkYLayer2.Blocks[num3].Id;
					short num7 = (short)chunkYLayer2.Blocks[num3].Data;
					string name2 = BlockMaster.GetBedrockBlockState(id2, num7).name;
					int num8 = WXe3gvD6SU(dictionary3, name2, num7, brP7YOaaIjJP3w7Exq3);
					array4[num4] = num8;
					if (id2 != 0)
					{
						flag3 = true;
					}
				}
			}
			if (flag2 || flag3 || flag)
			{
				TagNodeCompound tagNodeCompound2 = null;
				if (dictionary.ContainsKey(num))
				{
					tagNodeCompound2 = dictionary[num];
				}
				else
				{
					tagNodeCompound2 = new TagNodeCompound();
					tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)num);
					tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = new TagNodeByte(1);
				}
				TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
				TagNodeCompound tagNodeCompound3 = new TagNodeCompound();
				tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = Ama3UmDsw6(dictionary2);
				tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(array3);
				tagNodeList2.Add(tagNodeCompound3);
				if (flag3)
				{
					TagNodeCompound tagNodeCompound4 = new TagNodeCompound();
					tagNodeCompound4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = Ama3UmDsw6(dictionary3);
					tagNodeCompound4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(array4);
					tagNodeList2.Add(tagNodeCompound4);
				}
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] = tagNodeList2;
				tagNodeList.Add(tagNodeCompound2);
				flag = true;
			}
		}
		ngk1Vy6MaY = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList Ama3UmDsw6(Dictionary<string, Dictionary<short, BlockState>> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockState> list = new List<BlockState>();
		foreach (string key in P_0.Keys)
		{
			foreach (short key2 in P_0[key].Keys)
			{
				list.Add(P_0[key][key2]);
			}
		}
		list = list.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (BlockState blockState) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return blockState.paletteIndex;
		}).ToList();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		foreach (BlockState item in list)
		{
			TagNodeCompound tagNodeCompound = new TagNodeCompound();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] = new TagNodeString(item.name);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)] = new TagNodeShort(item.data);
			tagNodeList.Add(tagNodeCompound);
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pfb3LX6wia()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num = 256;
				int num2 = 0;
				do
				{
					num--;
					int num3 = i + j * 16;
					num2 = adb1Z0rYVQ[0].yLayers[num].Blocks[num3].Id;
				}
				while (num > 0 && MapBlocksPE.TransparentBlocks.Contains(num2));
				if (num != 0 && num != 255)
				{
					num++;
				}
				cN81WxvMnc[j * 16 + i] = (byte)num;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int WXe3gvD6SU(Dictionary<string, Dictionary<short, BlockState>> P_0, string P_1, short P_2, brP7YOaaIjJP3w7Exq P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = -1;
		if (P_0.ContainsKey(P_1) && P_0[P_1].ContainsKey(P_2))
		{
			num = P_0[P_1][P_2].paletteIndex;
		}
		if (num == -1)
		{
			num = P_3();
			if (!P_0.ContainsKey(P_1))
			{
				P_0.Add(P_1, new Dictionary<short, BlockState>());
			}
			BlockState value = BlockMaster.GetBedrockBlockState(P_1, P_2).Copy(num);
			P_0[P_1].Add(P_2, value);
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Wqa3Pm1OA9(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < adb1Z0rYVQ[0].yLayers.Length; i++)
		{
			ChunkYLayer chunkYLayer = adb1Z0rYVQ[0].yLayers[i];
			for (int j = 0; j < chunkYLayer.TileEntities.Count; j++)
			{
				P_0.Add(chunkYLayer.TileEntities[j]);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LpL3R9lkMH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UtL14E0NCi = new TagNodeList(TagType.TAG_COMPOUND);
		vND3xTPMsD(ngk1Vy6MaY, UtL14E0NCi);
		pfb3LX6wia();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ekc3kT6GQH(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string value = cbd1YM4Z09.Text.Trim();
		if (string.IsNullOrWhiteSpace(value))
		{
			ohY3WAFRTb(t5y1h9JIbn, BFRL2f2UoG7tBGIHJF.mAVSRPT1qd().Values.ToList());
			return;
		}
		List<jLK03d0ZSlci2XsVe6> list = new List<jLK03d0ZSlci2XsVe6>();
		foreach (jLK03d0ZSlci2XsVe6 value2 in BFRL2f2UoG7tBGIHJF.mAVSRPT1qd().Values)
		{
			if (value2.Description.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				list.Add(value2);
			}
		}
		ohY3WAFRTb(t5y1h9JIbn, list);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LiV3YVdP2j(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AUh31uKjmn();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void v1p33Gej26(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		u4E3EqoGOr();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AUh31uKjmn()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		ChunkYLayer[] array = null;
		if (A5q1m15FRu.SelectedItems.Count <= 0)
		{
			return;
		}
		array = new ChunkYLayer[A5q1m15FRu.SelectedItems.Count];
		foreach (ListViewItem selectedItem in A5q1m15FRu.SelectedItems)
		{
			array[num++] = selectedItem.Tag as ChunkYLayer;
		}
		array = array.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (ChunkYLayer P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.Layer;
		}).ToArray();
		YB43rMwlgg(array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void u4E3EqoGOr()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		ChunkYLayer[] array = null;
		ChunkYLayer[] array2 = FUv35hSOw4();
		if (A5q1m15FRu.SelectedItems.Count <= 0 || array2 == null || array2.Length <= 0)
		{
			return;
		}
		array = new ChunkYLayer[A5q1m15FRu.SelectedItems.Count];
		foreach (ListViewItem selectedItem in A5q1m15FRu.SelectedItems)
		{
			array[num++] = selectedItem.Tag as ChunkYLayer;
		}
		array = array.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (ChunkYLayer P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.Layer;
		}).ToArray();
		num = 0;
		ChunkYLayer[] array3 = array;
		foreach (ChunkYLayer chunkYLayer in array3)
		{
			for (int num3 = 0; num3 < 256; num3++)
			{
				chunkYLayer.Blocks[num3] = array2[num].Blocks[num3].Copy();
			}
			chunkYLayer.TileEntities = WWf360ZF0c(array2[num], chunkYLayer.Layer);
			num++;
			if (num >= array2.Length)
			{
				num = 0;
			}
		}
		foreach (ListViewItem selectedItem2 in A5q1m15FRu.SelectedItems)
		{
			ChunkYLayer chunkYLayer2 = selectedItem2.Tag as ChunkYLayer;
			selectedItem2.SubItems[1].Text = fPK3yRBdEm(chunkYLayer2.TileEntities);
		}
		XsY1Xw31DW.Level = A5q1m15FRu.SelectedItems[0].Tag as ChunkYLayer;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YB43rMwlgg(ChunkYLayer[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LayersClipboard data = new LayersClipboard(P_0);
		DataObject dataObject = new DataObject();
		dataObject.SetData(typeof(LayersClipboard).FullName, autoConvert: true, data);
		Clipboard.SetDataObject(dataObject);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ChunkYLayer[] FUv35hSOw4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Clipboard.GetData(typeof(LayersClipboard).FullName) is LayersClipboard layersClipboard)
		{
			return layersClipboard.ToChunkLayers();
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList WWf360ZF0c(ChunkYLayer P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		for (int num = P_0.TileEntities.Count - 1; num >= 0; num--)
		{
			TagNodeCompound tagNodeCompound = P_0.TileEntities[num] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)))
			{
				TagNodeCompound tagNodeCompound2 = (TagNodeCompound)tagNodeCompound.Copy();
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] = new TagNodeInt(P_1);
				tagNodeList.Add(tagNodeCompound2);
			}
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KZb3NBQ6wJ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XsY1Xw31DW.SearchActive = dP11EhvBpb.Checked;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ie13DYV6l7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XsY1Xw31DW.SearchActive = dP11EhvBpb.Checked;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void t883cd7FAt(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (A5q1m15FRu.SelectedItems.Count > 0)
		{
			ListViewItem listViewItem = A5q1m15FRu.SelectedItems[0];
			ChunkYLayer chunkYLayer = listViewItem.Tag as ChunkYLayer;
			listViewItem.SubItems[1].Text = fPK3yRBdEm(chunkYLayer.TileEntities);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I4L3JtVsD6(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.KeyCode == Keys.C && P_1.Control)
		{
			AUh31uKjmn();
		}
		else if (P_1.KeyCode == Keys.V && P_1.Control)
		{
			u4E3EqoGOr();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rcs3u4m6yW(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (KVZ1D0w89Y.Checked)
		{
			r7P1fk6qOK = 0;
			Qd332iNff9(adb1Z0rYVQ[r7P1fk6qOK].yLayers);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Kx73oVJiTK(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (yFe1NHvq9o.Checked)
		{
			r7P1fk6qOK = 1;
			Qd332iNff9(adb1Z0rYVQ[r7P1fk6qOK].yLayers);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && cDx1sIV8uy != null)
		{
			cDx1sIV8uy.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qy83QKZJTS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		cDx1sIV8uy = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ChunkDesigner));
		iMV1qTqvrs = new SplitContainer();
		rGZ16f6yAh = new Label();
		yFe1NHvq9o = new RadioButton();
		KVZ1D0w89Y = new RadioButton();
		dP11EhvBpb = new CheckBox();
		zoo1gvBMig = new PictureBox();
		TpT1PGjiNK = new PictureBox();
		sTB1M5qd0q = new PictureBox();
		oya1UuiyVZ = new PictureBox();
		jrw1LxY8yV = new PictureBox();
		Hu41KbPExH = new SplitContainer();
		t5y1h9JIbn = new ListView();
		TJ51n5vbXA = new ColumnHeader();
		Gif1lhHJL6 = new ColumnHeader();
		cbd1YM4Z09 = new TextBox();
		A5q1m15FRu = new ListView();
		R6q1aIbfrR = new ColumnHeader();
		xGc153QyhS = new ColumnHeader();
		UGG12XCIUo = new ContextMenuStrip(cDx1sIV8uy);
		gO41Bi3LZM = new ToolStripMenuItem();
		L5m1tdPtEC = new ToolStripMenuItem();
		iUx13Kidfk = new ToolStripMenuItem();
		Boa11Zh50m = new ToolStripMenuItem();
		yvV1yqEOfe = new ContextMenuStrip(cDx1sIV8uy);
		u4U10IENP8 = new ToolStripMenuItem();
		I5P1RMvjhD = new Button();
		SO31kMnkr8 = new Button();
		s4h1rKsiiR = new BlockSettingsUI();
		a2o1xs3eIu = new BlockSettingsUI();
		tKi1eNKjlQ = new BlockSettingsUI();
		XsY1Xw31DW = new ChunkUI();
		((ISupportInitialize)iMV1qTqvrs).BeginInit();
		iMV1qTqvrs.Panel1.SuspendLayout();
		iMV1qTqvrs.Panel2.SuspendLayout();
		iMV1qTqvrs.SuspendLayout();
		((ISupportInitialize)zoo1gvBMig).BeginInit();
		((ISupportInitialize)TpT1PGjiNK).BeginInit();
		((ISupportInitialize)sTB1M5qd0q).BeginInit();
		((ISupportInitialize)oya1UuiyVZ).BeginInit();
		((ISupportInitialize)jrw1LxY8yV).BeginInit();
		((ISupportInitialize)Hu41KbPExH).BeginInit();
		Hu41KbPExH.Panel1.SuspendLayout();
		Hu41KbPExH.Panel2.SuspendLayout();
		Hu41KbPExH.SuspendLayout();
		UGG12XCIUo.SuspendLayout();
		yvV1yqEOfe.SuspendLayout();
		SuspendLayout();
		iMV1qTqvrs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		iMV1qTqvrs.Location = new Point(0, 0);
		iMV1qTqvrs.Margin = new Padding(10);
		iMV1qTqvrs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		iMV1qTqvrs.Panel1.Controls.Add(rGZ16f6yAh);
		iMV1qTqvrs.Panel1.Controls.Add(yFe1NHvq9o);
		iMV1qTqvrs.Panel1.Controls.Add(KVZ1D0w89Y);
		iMV1qTqvrs.Panel1.Controls.Add(dP11EhvBpb);
		iMV1qTqvrs.Panel1.Controls.Add(s4h1rKsiiR);
		iMV1qTqvrs.Panel1.Controls.Add(zoo1gvBMig);
		iMV1qTqvrs.Panel1.Controls.Add(TpT1PGjiNK);
		iMV1qTqvrs.Panel1.Controls.Add(sTB1M5qd0q);
		iMV1qTqvrs.Panel1.Controls.Add(oya1UuiyVZ);
		iMV1qTqvrs.Panel1.Controls.Add(jrw1LxY8yV);
		iMV1qTqvrs.Panel1.Controls.Add(a2o1xs3eIu);
		iMV1qTqvrs.Panel1.Controls.Add(tKi1eNKjlQ);
		iMV1qTqvrs.Panel1.Controls.Add(XsY1Xw31DW);
		iMV1qTqvrs.Panel1.Padding = new Padding(10);
		iMV1qTqvrs.Panel2.Controls.Add(Hu41KbPExH);
		iMV1qTqvrs.Panel2.Padding = new Padding(0, 10, 4, 10);
		iMV1qTqvrs.Size = new Size(964, 662);
		iMV1qTqvrs.SplitterDistance = 623;
		iMV1qTqvrs.TabIndex = 1;
		rGZ16f6yAh.Location = new Point(575, 207);
		rGZ16f6yAh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		rGZ16f6yAh.Size = new Size(35, 26);
		rGZ16f6yAh.TabIndex = 15;
		rGZ16f6yAh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38892);
		yFe1NHvq9o.AutoSize = true;
		yFe1NHvq9o.Location = new Point(579, 260);
		yFe1NHvq9o.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38918);
		yFe1NHvq9o.Size = new Size(31, 17);
		yFe1NHvq9o.TabIndex = 14;
		yFe1NHvq9o.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18714);
		yFe1NHvq9o.UseVisualStyleBackColor = true;
		yFe1NHvq9o.CheckedChanged += Kx73oVJiTK;
		KVZ1D0w89Y.AutoSize = true;
		KVZ1D0w89Y.Checked = true;
		KVZ1D0w89Y.Location = new Point(579, 237);
		KVZ1D0w89Y.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38938);
		KVZ1D0w89Y.Size = new Size(31, 17);
		KVZ1D0w89Y.TabIndex = 13;
		KVZ1D0w89Y.TabStop = true;
		KVZ1D0w89Y.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708);
		KVZ1D0w89Y.UseVisualStyleBackColor = true;
		KVZ1D0w89Y.CheckedChanged += rcs3u4m6yW;
		dP11EhvBpb.AutoSize = true;
		dP11EhvBpb.Location = new Point(445, 587);
		dP11EhvBpb.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38958);
		dP11EhvBpb.Size = new Size(56, 17);
		dP11EhvBpb.TabIndex = 12;
		dP11EhvBpb.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11530);
		dP11EhvBpb.UseVisualStyleBackColor = true;
		dP11EhvBpb.CheckedChanged += KZb3NBQ6wJ;
		zoo1gvBMig.BackgroundImageLayout = ImageLayout.Center;
		zoo1gvBMig.BorderStyle = BorderStyle.FixedSingle;
		zoo1gvBMig.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38988));
		zoo1gvBMig.Location = new Point(577, 83);
		zoo1gvBMig.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39036);
		zoo1gvBMig.Padding = new Padding(1, 2, 0, 0);
		zoo1gvBMig.Size = new Size(30, 30);
		zoo1gvBMig.TabIndex = 10;
		zoo1gvBMig.TabStop = false;
		zoo1gvBMig.Click += OFd3mYqGm8;
		TpT1PGjiNK.BackgroundImageLayout = ImageLayout.Center;
		TpT1PGjiNK.BorderStyle = BorderStyle.FixedSingle;
		TpT1PGjiNK.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39072));
		TpT1PGjiNK.Location = new Point(577, 47);
		TpT1PGjiNK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39116);
		TpT1PGjiNK.Padding = new Padding(1, 2, 0, 0);
		TpT1PGjiNK.Size = new Size(30, 30);
		TpT1PGjiNK.TabIndex = 9;
		TpT1PGjiNK.TabStop = false;
		TpT1PGjiNK.Click += eOO3hhMb1F;
		sTB1M5qd0q.BackgroundImageLayout = ImageLayout.Center;
		sTB1M5qd0q.BorderStyle = BorderStyle.FixedSingle;
		sTB1M5qd0q.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39148));
		sTB1M5qd0q.Location = new Point(577, 119);
		sTB1M5qd0q.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39188);
		sTB1M5qd0q.Padding = new Padding(1, 2, 0, 0);
		sTB1M5qd0q.Size = new Size(30, 30);
		sTB1M5qd0q.TabIndex = 8;
		sTB1M5qd0q.TabStop = false;
		sTB1M5qd0q.Click += nfW3qTNdhr;
		oya1UuiyVZ.BackgroundImageLayout = ImageLayout.Center;
		oya1UuiyVZ.BorderStyle = BorderStyle.FixedSingle;
		oya1UuiyVZ.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39216));
		oya1UuiyVZ.Location = new Point(577, 155);
		oya1UuiyVZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39258);
		oya1UuiyVZ.Padding = new Padding(2, 2, 0, 0);
		oya1UuiyVZ.Size = new Size(30, 30);
		oya1UuiyVZ.TabIndex = 7;
		oya1UuiyVZ.TabStop = false;
		oya1UuiyVZ.Click += oW23KFdLab;
		jrw1LxY8yV.BackgroundImageLayout = ImageLayout.Center;
		jrw1LxY8yV.BorderStyle = BorderStyle.FixedSingle;
		jrw1LxY8yV.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39288));
		jrw1LxY8yV.Location = new Point(577, 11);
		jrw1LxY8yV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39326);
		jrw1LxY8yV.Padding = new Padding(3, 2, 0, 0);
		jrw1LxY8yV.Size = new Size(30, 30);
		jrw1LxY8yV.TabIndex = 6;
		jrw1LxY8yV.TabStop = false;
		jrw1LxY8yV.Click += Fyq3sxitQm;
		Hu41KbPExH.Dock = DockStyle.Fill;
		Hu41KbPExH.Location = new Point(0, 10);
		Hu41KbPExH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13784);
		Hu41KbPExH.Orientation = Orientation.Horizontal;
		Hu41KbPExH.Panel1.Controls.Add(t5y1h9JIbn);
		Hu41KbPExH.Panel1.Controls.Add(cbd1YM4Z09);
		Hu41KbPExH.Panel2.Controls.Add(A5q1m15FRu);
		Hu41KbPExH.Size = new Size(333, 642);
		Hu41KbPExH.SplitterDistance = 295;
		Hu41KbPExH.TabIndex = 0;
		t5y1h9JIbn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		t5y1h9JIbn.Columns.AddRange(new ColumnHeader[2] { TJ51n5vbXA, Gif1lhHJL6 });
		t5y1h9JIbn.FullRowSelect = true;
		t5y1h9JIbn.Location = new Point(0, 21);
		t5y1h9JIbn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11006);
		t5y1h9JIbn.Size = new Size(333, 274);
		t5y1h9JIbn.TabIndex = 0;
		t5y1h9JIbn.UseCompatibleStateImageBehavior = false;
		t5y1h9JIbn.View = View.Details;
		t5y1h9JIbn.MouseDown += uVO3fBTv7P;
		TJ51n5vbXA.Text = "";
		TJ51n5vbXA.Width = 39;
		Gif1lhHJL6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11032);
		Gif1lhHJL6.Width = 216;
		cbd1YM4Z09.Dock = DockStyle.Top;
		cbd1YM4Z09.Location = new Point(0, 0);
		cbd1YM4Z09.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11046);
		cbd1YM4Z09.Size = new Size(333, 20);
		cbd1YM4Z09.TabIndex = 0;
		cbd1YM4Z09.KeyUp += ekc3kT6GQH;
		A5q1m15FRu.Columns.AddRange(new ColumnHeader[2] { R6q1aIbfrR, xGc153QyhS });
		A5q1m15FRu.ContextMenuStrip = UGG12XCIUo;
		A5q1m15FRu.Dock = DockStyle.Fill;
		A5q1m15FRu.FullRowSelect = true;
		A5q1m15FRu.HideSelection = false;
		A5q1m15FRu.Location = new Point(0, 0);
		A5q1m15FRu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39352);
		A5q1m15FRu.Size = new Size(333, 343);
		A5q1m15FRu.TabIndex = 0;
		A5q1m15FRu.UseCompatibleStateImageBehavior = false;
		A5q1m15FRu.View = View.Details;
		A5q1m15FRu.SelectedIndexChanged += hto3Z9CGIF;
		A5q1m15FRu.KeyDown += I4L3JtVsD6;
		R6q1aIbfrR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782);
		R6q1aIbfrR.Width = 40;
		xGc153QyhS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39382);
		xGc153QyhS.Width = 304;
		UGG12XCIUo.Items.AddRange(new ToolStripItem[4] { gO41Bi3LZM, L5m1tdPtEC, iUx13Kidfk, Boa11Zh50m });
		UGG12XCIUo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39412);
		UGG12XCIUo.Size = new Size(145, 92);
		gO41Bi3LZM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39444);
		gO41Bi3LZM.Size = new Size(144, 22);
		gO41Bi3LZM.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39470);
		gO41Bi3LZM.Visible = false;
		gO41Bi3LZM.Click += d8O3pQbXqX;
		L5m1tdPtEC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39492);
		L5m1tdPtEC.Size = new Size(144, 22);
		L5m1tdPtEC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39524);
		L5m1tdPtEC.Visible = false;
		iUx13Kidfk.Image = Resources.fp5S1ExUZGo();
		iUx13Kidfk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39552);
		iUx13Kidfk.ShortcutKeys = Keys.C | Keys.Control;
		iUx13Kidfk.Size = new Size(144, 22);
		iUx13Kidfk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20950);
		iUx13Kidfk.Click += LiV3YVdP2j;
		Boa11Zh50m.Image = Resources.XPyS13kSbEo();
		Boa11Zh50m.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39580);
		Boa11Zh50m.ShortcutKeys = Keys.V | Keys.Control;
		Boa11Zh50m.Size = new Size(144, 22);
		Boa11Zh50m.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20982);
		Boa11Zh50m.Click += v1p33Gej26;
		yvV1yqEOfe.Items.AddRange(new ToolStripItem[1] { u4U10IENP8 });
		yvV1yqEOfe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39610);
		yvV1yqEOfe.Size = new Size(121, 26);
		u4U10IENP8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39632);
		u4U10IENP8.Size = new Size(120, 22);
		u4U10IENP8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39660);
		I5P1RMvjhD.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		I5P1RMvjhD.DialogResult = DialogResult.Cancel;
		I5P1RMvjhD.Location = new Point(882, 663);
		I5P1RMvjhD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		I5P1RMvjhD.Size = new Size(75, 23);
		I5P1RMvjhD.TabIndex = 2;
		I5P1RMvjhD.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		I5P1RMvjhD.UseVisualStyleBackColor = true;
		SO31kMnkr8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		SO31kMnkr8.Location = new Point(799, 663);
		SO31kMnkr8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		SO31kMnkr8.Size = new Size(75, 23);
		SO31kMnkr8.TabIndex = 3;
		SO31kMnkr8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		SO31kMnkr8.UseVisualStyleBackColor = true;
		SO31kMnkr8.Click += LpL3R9lkMH;
		s4h1rKsiiR.Location = new Point(355, 585);
		s4h1rKsiiR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39684);
		s4h1rKsiiR.Size = new Size(148, 76);
		s4h1rKsiiR.TabIndex = 11;
		s4h1rKsiiR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39712);
		s4h1rKsiiR.BlockChanged += ie13DYV6l7;
		a2o1xs3eIu.Location = new Point(187, 585);
		a2o1xs3eIu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39746);
		a2o1xs3eIu.Size = new Size(150, 73);
		a2o1xs3eIu.TabIndex = 5;
		a2o1xs3eIu.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39780);
		tKi1eNKjlQ.Location = new Point(12, 585);
		tKi1eNKjlQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39832);
		tKi1eNKjlQ.Size = new Size(157, 73);
		tKi1eNKjlQ.TabIndex = 4;
		tKi1eNKjlQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39864);
		XsY1Xw31DW.ChunkX = 0;
		XsY1Xw31DW.ChunkZ = 0;
		XsY1Xw31DW.CopyBlockActive = false;
		XsY1Xw31DW.Level = null;
		XsY1Xw31DW.Location = new Point(0, 0);
		XsY1Xw31DW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39914);
		XsY1Xw31DW.SearchActive = false;
		XsY1Xw31DW.SearchBlock = null;
		XsY1Xw31DW.Size = new Size(570, 579);
		XsY1Xw31DW.TabIndex = 3;
		XsY1Xw31DW.BlockCopied += kgJ3nAT6EW;
		XsY1Xw31DW.BlockChanged += t883cd7FAt;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = I5P1RMvjhD;
		base.ClientSize = new Size(964, 692);
		base.Controls.Add(SO31kMnkr8);
		base.Controls.Add(I5P1RMvjhD);
		base.Controls.Add(iMV1qTqvrs);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39932);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39962);
		base.Load += RBY3lOCjIq;
		iMV1qTqvrs.Panel1.ResumeLayout(performLayout: false);
		iMV1qTqvrs.Panel1.PerformLayout();
		iMV1qTqvrs.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)iMV1qTqvrs).EndInit();
		iMV1qTqvrs.ResumeLayout(performLayout: false);
		((ISupportInitialize)zoo1gvBMig).EndInit();
		((ISupportInitialize)TpT1PGjiNK).EndInit();
		((ISupportInitialize)sTB1M5qd0q).EndInit();
		((ISupportInitialize)oya1UuiyVZ).EndInit();
		((ISupportInitialize)jrw1LxY8yV).EndInit();
		Hu41KbPExH.Panel1.ResumeLayout(performLayout: false);
		Hu41KbPExH.Panel1.PerformLayout();
		Hu41KbPExH.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)Hu41KbPExH).EndInit();
		Hu41KbPExH.ResumeLayout(performLayout: false);
		UGG12XCIUo.ResumeLayout(performLayout: false);
		yvV1yqEOfe.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int W0I3O5tEab(ChunkYLayer P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Layer;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int QT83CTPVRV(ChunkYLayer P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Layer;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int CkC37ch9IV(ChunkYLayer P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Layer;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int CHw3AC6HSb(BlockState P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.paletteIndex;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int VS93d1knyi(ChunkYLayer P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Layer;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int psb3HK5GSD(ChunkYLayer P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Layer;
	}
}
