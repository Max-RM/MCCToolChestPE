using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.model;
using MCCToolChest.PECode.model;
using MCCToolChest.utils;
using MCPELevelDBI.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class PCFileTree
{
	private static string[] kBYSTQpq5Cr;

	private Dictionary<string, int> h55STOTLOpI;

	private ChunkLookup QHDSTCiPJIM;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisplayMinecraftFiles(string folderPath, TreeView treeView, ChunkLookup chunkLookups, ToolStripStatusLabel versionLabel)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		QHDSTCiPJIM = chunkLookups;
		folderPath = FileUtils.CheckFolderSep(folderPath);
		if (Working.RXpStXcJiRk() != PlatformType.PC && Working.RXpStXcJiRk() == PlatformType.PE)
		{
			DdcST6bsU6N(folderPath, treeView);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DdcST6bsU6N(string P_0, TreeView P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.Nodes.Clear();
		P_1.BeginUpdate();
		IndexEntry indexEntry = new IndexEntry();
		indexEntry.FileName = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516);
		indexEntry.FilePath = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516);
		DisplayFileItem(indexEntry, P_0, P_1);
		string[] peFiles = PEConsts.peFiles;
		foreach (string text in peFiles)
		{
			string[] array = text.Split('\\');
			string text2 = (PEConsts.txtFiles.Contains(array[1]) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69582) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554));
			IndexEntry indexEntry2 = new IndexEntry();
			indexEntry2.FileName = array[1];
			indexEntry2.FilePath = text + text2;
			indexEntry2.ParentName = array[0];
			DisplayFileItem(indexEntry2, P_0, P_1);
		}
		foreach (string key in Constants.dimensionNames.Keys)
		{
			TreeNode treeNode = P_1.Nodes.Add(key, Constants.dimensionNames[key]);
			string path = P_0 + Working.WorkFolder + FileUtils.CheckFolderSep(key);
			treeNode.Tag = new DimensionWorkingData(key, path);
			aBaSTu5eKYN(treeNode, key);
		}
		K8DSTNiumlW(P_0, P_1);
		P_1.EndUpdate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void K8DSTNiumlW(string P_0, TreeView P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEProcessWorker pEProcessWorker = new PEProcessWorker();
		List<PEDimension> availableChunks = pEProcessWorker.GetAvailableChunks(P_0);
		for (int i = 0; i < availableChunks.Count; i++)
		{
			_ = kBYSTQpq5Cr[i];
			foreach (string key in availableChunks[i].Region.Keys)
			{
				_ = availableChunks[i].Region[key];
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TreeNode DisplayFileItem(IndexEntry entry, string folderPath, TreeView treeView)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = null;
		TreeNode treeNode2 = aOZSTJvuvSm(entry, treeView);
		string fileName = entry.FileName;
		if (treeNode2 != null)
		{
			if (entry.IsRegion)
			{
				string key = fileName.Substring(0, fileName.LastIndexOf('.'));
				treeNode = treeNode2.Nodes.Add(key, fileName);
			}
			else
			{
				treeNode = treeNode2.Nodes.Add(fileName);
			}
		}
		else
		{
			treeNode = treeView.Nodes.Add(fileName);
		}
		treeNode.Tag = entry;
		aBaSTu5eKYN(treeNode, entry.ParentName);
		return treeNode;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TreeNode CheckFileExists(IndexEntry entry, TreeView treeView)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode result = null;
		foreach (TreeNode node in treeView.Nodes)
		{
			if (node.Tag is IndexEntry indexEntry && indexEntry.FileName == entry.FileName)
			{
				result = node;
				break;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XTOSTD06Is1(string P_0, TreeNode P_1, IndexEntry P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = P_2.RX;
		_ = P_2.RZ;
		List<ChunkIndexEntry> list = lxe7hMuSirBXGUQugsD.kM7SgjjqASt(P_0);
		if (P_2.RX >= 0)
		{
			for (int i = 0; i < 32; i++)
			{
				if (P_2.RZ >= 0)
				{
					for (int j = 0; j < 32; j++)
					{
						NOOSTcUwGiG(P_2, P_1, list, P_0, i, j, i, j);
					}
					continue;
				}
				for (int num = 31; num >= 0; num--)
				{
					NOOSTcUwGiG(P_2, P_1, list, P_0, i, num, i, num - 32);
				}
			}
			return;
		}
		for (int num2 = 31; num2 >= 0; num2--)
		{
			if (P_2.RZ >= 0)
			{
				for (int k = 0; k < 32; k++)
				{
					NOOSTcUwGiG(P_2, P_1, list, P_0, num2, k, num2 - 32, k);
				}
			}
			else
			{
				for (int num3 = 31; num3 >= 0; num3--)
				{
					NOOSTcUwGiG(P_2, P_1, list, P_0, num2, num3, num2 - 32, num3 - 32);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NOOSTcUwGiG(IndexEntry P_0, TreeNode P_1, List<ChunkIndexEntry> P_2, string P_3, int P_4, int P_5, int P_6, int P_7)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (lxe7hMuSirBXGUQugsD.gMiSP4Al2WT(P_2, P_4, P_5))
		{
			ChunkIndexEntry chunkIndexEntry = lxe7hMuSirBXGUQugsD.XnuSPVkd0a5(P_2, P_4, P_5);
			_ = P_3 + chunkIndexEntry.ChunkIndex + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554);
			string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28870) + P_6 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + P_7 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542);
			ChunkData chunkData = new ChunkData();
			chunkData.XRegionOffset = P_4;
			chunkData.ZRegionOffset = P_5;
			chunkData.XWorldCoords = P_6;
			chunkData.ZWorldCoords = P_7;
			chunkData.Path = P_3;
			chunkData.Parent = P_0.ParentName;
			chunkData.Text = text;
			chunkData.WxMS0gYhqtY(chunkIndexEntry);
			chunkData.RegionIndex = P_0;
			ChunkData tag = chunkData;
			TreeNode treeNode = P_1.Nodes.Add(text);
			aBaSTu5eKYN(treeNode, P_0.ParentName);
			treeNode.Tag = tag;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TreeNode aOZSTJvuvSm(IndexEntry P_0, TreeView P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = null;
		string parentName = P_0.ParentName;
		if (!string.IsNullOrWhiteSpace(parentName))
		{
			TreeNode[] array = P_1.Nodes.Find(parentName, searchAllChildren: true);
			if (array != null && array.Length > 0)
			{
				treeNode = array[0];
			}
			if (treeNode == null)
			{
				string text = parentName;
				if (Constants.dimensionNames.ContainsKey(text))
				{
					text = Constants.dimensionNames[text];
				}
				treeNode = P_1.Nodes.Add(parentName, text);
				aBaSTu5eKYN(treeNode, parentName);
			}
		}
		return treeNode;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aBaSTu5eKYN(TreeNode P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int selectedImageIndex = (P_0.ImageIndex = PBiSTonbcDX(P_1));
		P_0.SelectedImageIndex = selectedImageIndex;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int PBiSTonbcDX(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (P_0 != null && h55STOTLOpI.ContainsKey(P_0.ToLower()))
		{
			result = h55STOTLOpI[P_0.ToLower()];
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PCFileTree()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		h55STOTLOpI = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60350),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60336),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436),
				1
			}
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PCFileTree()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		kBYSTQpq5Cr = new string[3]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780)
		};
	}
}
