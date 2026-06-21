using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.forms;
using MCCToolChest.model;
using MCPELevelDBI.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class AreaActionWorker
{
	private delegate bool EqHanauqAqPdAV78Oqc(int xChunk, int zChunk, int x1, int z1, int x2, int z2);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GgkSRNkbixQ(int P_0, int P_1, int P_2, int P_3, int P_4, int P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 >= P_2 && P_0 <= P_4)
		{
			if (P_1 >= P_3)
			{
				return P_1 > P_5;
			}
			return true;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CUMSRDiUuXH(int P_0, int P_1, int P_2, int P_3, int P_4, int P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 >= P_2 && P_0 <= P_4 && P_1 >= P_3)
		{
			return P_1 <= P_5;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoAreaAction(AreaActionEventArgs args, TreeView treeView, MainForm mainform)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEProcessWorker pEProcessWorker = new PEProcessWorker();
		if (args.AreaAction == AreaActionType.DELETE || args.AreaAction == AreaActionType.PRUNE)
		{
			EqHanauqAqPdAV78Oqc eqHanauqAqPdAV78Oqc = ((args.AreaAction == AreaActionType.DELETE) ? new EqHanauqAqPdAV78Oqc(CUMSRDiUuXH) : new EqHanauqAqPdAV78Oqc(GgkSRNkbixQ));
			int[] coords = pcWSRJxNm4G(args.Dimension, args.X1, args.Z1, args.X2, args.Z2, eqHanauqAqPdAV78Oqc);
			pEProcessWorker.DeleteChunks(args.Dimension, coords, Working.T92StMGt1p4());
			if (treeView != null)
			{
				pOCSRu59klZ(args.Dimension, args.X1, args.Z1, args.X2, args.Z2, eqHanauqAqPdAV78Oqc, treeView);
			}
		}
		else if (args.AreaAction == AreaActionType.CHUNKFILL)
		{
			ChunkFillArea(args, mainform);
			dNlSRQ2auZm(args, treeView);
		}
		else if (args.AreaAction == AreaActionType.BIOMEFILL)
		{
			XCdSRc21PJa(args, mainform);
		}
		else if (args.AreaAction == AreaActionType.AREACOPY)
		{
			CopyArea(args, mainform);
		}
		else if (args.AreaAction == AreaActionType.AREAFILL)
		{
			AreaFillArea(args, mainform);
			dNlSRQ2auZm(args, treeView);
		}
		Working.DataChanged = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XCdSRc21PJa(AreaActionEventArgs P_0, MainForm P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeWorker biomeWorker = new BiomeWorker();
		biomeWorker.DoBiomeFillArea(P_0, Working.T92StMGt1p4());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChunkFillArea(AreaActionEventArgs args, MainForm mainform)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AreaActionDialog areaActionDialog = new AreaActionDialog(args);
		areaActionDialog.ShowDialog(mainform);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyArea(AreaActionEventArgs args, MainForm mainform)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AreaActionDialog areaActionDialog = new AreaActionDialog(args);
		areaActionDialog.ShowDialog(mainform);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AreaFillArea(AreaActionEventArgs args, MainForm mainform)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AreaActionDialog areaActionDialog = new AreaActionDialog(args);
		areaActionDialog.ShowDialog(mainform);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int[] pcWSRJxNm4G(int P_0, int P_1, int P_2, int P_3, int P_4, EqHanauqAqPdAV78Oqc P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<int> list = new List<int>();
		PEDimension pEDimension = Working.PEDimensions[P_0];
		foreach (PERegion value in pEDimension.Region.Values)
		{
			for (int i = 0; i < 32; i++)
			{
				for (int j = 0; j < 32; j++)
				{
					int chunkCoord = GetChunkCoord(i, value.RX);
					int chunkCoord2 = GetChunkCoord(j, value.RZ);
					if (P_5(chunkCoord, chunkCoord2, P_1, P_2, P_3, P_4))
					{
						list.Add(chunkCoord);
						list.Add(chunkCoord2);
					}
				}
			}
		}
		return list.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pOCSRu59klZ(int P_0, int P_1, int P_2, int P_3, int P_4, EqHanauqAqPdAV78Oqc P_5, TreeView P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = Working.PEDimensions[P_0];
		foreach (PERegion value in pEDimension.Region.Values)
		{
			for (int i = 0; i < 32; i++)
			{
				for (int j = 0; j < 32; j++)
				{
					int chunkCoord = GetChunkCoord(i, value.RX);
					int chunkCoord2 = GetChunkCoord(j, value.RZ);
					if (P_5(chunkCoord, chunkCoord2, P_1, P_2, P_3, P_4))
					{
						int num = (chunkCoord & 0x1F) + (chunkCoord2 & 0x1F) * 32;
						if (value.Chunks[num] == 1)
						{
							value.Chunks[num] = 0;
							lHhSRo9DVJp(Constants.GetDimensionFolderName(P_0), value.ToString(), num, P_6);
						}
					}
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lHhSRo9DVJp(string P_0, string P_1, int P_2, TreeView P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = null;
		TreeNode treeNode2 = null;
		TreeNode[] array = P_3.Nodes.Find(P_1, searchAllChildren: true);
		if (array != null && array.Length > 0)
		{
			TreeNode[] array2 = array;
			foreach (TreeNode treeNode3 in array2)
			{
				if (treeNode3.Parent.Text == Constants.dimensionNames[P_0])
				{
					treeNode = treeNode3;
					break;
				}
			}
		}
		if (treeNode == null)
		{
			return;
		}
		foreach (TreeNode node in treeNode.Nodes)
		{
			if (node.Tag is ChunkData chunkData && chunkData.SQ7S0L9d7YF().ChunkIndex == P_2)
			{
				treeNode2 = node;
				break;
			}
		}
		treeNode2?.Remove();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetChunkCoord(int cval, int rval)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		cval = ((rval < 0) ? ((cval + 1) * -1) : cval);
		rval = ((rval < 0) ? (rval + 1) : rval);
		return cval + rval * 32;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dNlSRQ2auZm(AreaActionEventArgs P_0, TreeView P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string key = Constants.GetDimensionFolderName(P_0.Dimension);
		TreeNode[] array = P_1.Nodes.Find(key, searchAllChildren: true);
		if (array == null || array.Length <= 0)
		{
			return;
		}
		foreach (string regionEntry in P_0.RegionEntries)
		{
			string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + regionEntry;
			TreeNode treeNode = null;
			TreeNode[] array2 = array[0].Nodes.Find(text, searchAllChildren: true);
			if (array2 != null && array2.Length > 0)
			{
				array2[0].Nodes.Clear();
				treeNode = array2[0];
			}
			else
			{
				treeNode = array[0].Nodes.Add(text, text);
			}
			treeNode.Tag = Working.PEDimensions[P_0.Dimension].Region[regionEntry];
			TreeNode treeNode2 = treeNode.Nodes.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93588));
			treeNode2.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93588);
			treeNode.Collapse();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AreaActionWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
