using System.Collections.Generic;
using System.IO;
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

public class PEFileTree
{
	private Dictionary<string, int> TCSSnmOuqX2;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisplayMinecraftFiles(string folderPath, TreeView treeView, ToolStripStatusLabel versionLabel)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		folderPath = FileUtils.CheckFolderSep(folderPath);
		if (Working.RXpStXcJiRk() != PlatformType.PC && Working.RXpStXcJiRk() == PlatformType.PE)
		{
			WG3SnpCMnnn(folderPath, treeView);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WG3SnpCMnnn(string P_0, TreeView P_1)
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
			if (File.Exists(P_0 + text + text2))
			{
				IndexEntry indexEntry2 = new IndexEntry();
				indexEntry2.FileName = array[1];
				indexEntry2.FilePath = text + text2;
				indexEntry2.ParentName = array[0];
				DisplayFileItem(indexEntry2, P_0, P_1);
			}
		}
		foreach (string key in Constants.dimensionNames.Keys)
		{
			TreeNode treeNode = P_1.Nodes.Add(key, Constants.dimensionNames[key]);
			string path = P_0 + Working.WorkFolder + FileUtils.CheckFolderSep(key);
			treeNode.Tag = new DimensionWorkingData(key, path);
			QMYSnKmL9tX(treeNode, key);
		}
		s5dSnisdgCa(P_0, P_1);
		lSgSnZFH4Ph(P_0, P_1);
		LtlSnfMDHRa(P_0, P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87116));
		LtlSnfMDHRa(P_0, P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87132));
		LtlSnfMDHRa(P_0, P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87152));
		P_1.EndUpdate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lSgSnZFH4Ph(string P_0, TreeView P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] files = Directory.GetFiles(Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99040));
		string[] array = files;
		foreach (string path in array)
		{
			IndexEntry indexEntry = new IndexEntry();
			indexEntry.FileName = Path.GetFileNameWithoutExtension(path);
			indexEntry.FilePath = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55192) + Path.GetFileName(path);
			indexEntry.ParentName = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206);
			DisplayFileItem(indexEntry, P_0, P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LtlSnfMDHRa(string P_0, TreeView P_1, string P_2, string P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] files = Directory.GetFiles(Path.Combine(P_0, P_2), P_3 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99056));
		string[] array = files;
		foreach (string path in array)
		{
			IndexEntry indexEntry = new IndexEntry();
			indexEntry.FileName = Path.GetFileNameWithoutExtension(path);
			indexEntry.FilePath = Path.Combine(P_2, Path.GetFileName(path));
			indexEntry.ParentName = P_2;
			DisplayFileItem(indexEntry, P_0, P_1);
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
		TreeNode treeNode2 = wxvSnq3Ojyu(entry, treeView);
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
		QMYSnKmL9tX(treeNode, entry.ParentName);
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
	private void s5dSnisdgCa(string P_0, TreeView P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEProcessWorker pEProcessWorker = new PEProcessWorker();
		List<PEDimension> list = (Working.PEDimensions = pEProcessWorker.GetAvailableChunks(P_0));
		for (int i = 0; i < list.Count; i++)
		{
			string key = Constants.dimensionFolderNames[i];
			foreach (string key2 in list[i].Region.Keys)
			{
				PERegion pERegion = list[i].Region[key2];
				TreeNode treeNode = P_1.Nodes[key].Nodes.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + key2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + key2);
				treeNode.Tag = pERegion;
				QMYSnKmL9tX(treeNode, Constants.dimensionFolderNames[pERegion.Dimension].ToLower());
				TreeNode treeNode2 = treeNode.Nodes.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93588));
				treeNode2.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93588);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisplayChunkNodes(TreeNode pNode, PERegion region)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (region.RX >= 0)
		{
			for (int i = 0; i < 32; i++)
			{
				if (region.RZ >= 0)
				{
					for (int j = 0; j < 32; j++)
					{
						yuaSnsLPwj2(region, pNode, i, j, i, j);
					}
					continue;
				}
				for (int num = 31; num >= 0; num--)
				{
					yuaSnsLPwj2(region, pNode, i, num, i, num - 32);
				}
			}
			return;
		}
		for (int num2 = 31; num2 >= 0; num2--)
		{
			if (region.RZ >= 0)
			{
				for (int k = 0; k < 32; k++)
				{
					yuaSnsLPwj2(region, pNode, num2, k, num2 - 32, k);
				}
			}
			else
			{
				for (int num3 = 31; num3 >= 0; num3--)
				{
					yuaSnsLPwj2(region, pNode, num2, num3, num2 - 32, num3 - 32);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yuaSnsLPwj2(PERegion P_0, TreeNode P_1, int P_2, int P_3, int P_4, int P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_4, P_0.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_5, P_0.RZ);
		if (lxe7hMuSirBXGUQugsD.zNZSPALhXMG(P_0.Chunks, num, num2))
		{
			string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28870) + num + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542);
			ChunkData chunkData = new ChunkData();
			chunkData.XRegionOffset = P_2;
			chunkData.ZRegionOffset = P_3;
			chunkData.XWorldCoords = num;
			chunkData.ZWorldCoords = num2;
			chunkData.Parent = Constants.dimensionFolderNames[P_0.Dimension].ToLower();
			chunkData.Text = text;
			chunkData.WxMS0gYhqtY(new ChunkIndexEntry(lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2), 0u, 0));
			chunkData.RegionIndex = new IndexEntry
			{
				RX = P_0.RX,
				RZ = P_0.RZ
			};
			chunkData.Dimension = P_0.Dimension;
			ChunkData chunkData2 = chunkData;
			TreeNode treeNode = P_1.Nodes.Add(text);
			QMYSnKmL9tX(treeNode, chunkData2.Parent);
			treeNode.Tag = chunkData2;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TreeNode wxvSnq3Ojyu(IndexEntry P_0, TreeView P_1)
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
				QMYSnKmL9tX(treeNode, parentName);
			}
		}
		return treeNode;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QMYSnKmL9tX(TreeNode P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int selectedImageIndex = (P_0.ImageIndex = mUdSnhUy6uB(P_1));
		P_0.SelectedImageIndex = selectedImageIndex;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int mUdSnhUy6uB(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (P_0 != null && TCSSnmOuqX2.ContainsKey(P_0.ToLower()))
		{
			result = TCSSnmOuqX2[P_0.ToLower()];
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEFileTree()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		TCSSnmOuqX2 = new Dictionary<string, int>
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
}
