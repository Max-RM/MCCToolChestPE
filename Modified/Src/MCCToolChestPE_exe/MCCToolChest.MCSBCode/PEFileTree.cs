using System;
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
		lSgSnZFH4Ph(P_0, P_1);
		LtlSnfMDHRa(P_0, P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87116));
		LtlSnfMDHRa(P_0, P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87132));
		LtlSnfMDHRa(P_0, P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87152));
		OHYSnExtraData(P_0, P_1);
		for (int d = 0; d < 3; d++)
		{
			string folderKey = Constants.GetDimensionFolderName(d);
			TreeNode treeNode = P_1.Nodes.Add(folderKey, Constants.dimensionNames[folderKey]);
			string path = P_0 + Working.WorkFolder + FileUtils.CheckFolderSep(folderKey);
			treeNode.Tag = new DimensionWorkingData(folderKey, path);
			QMYSnKmL9tX(treeNode, folderKey);
		}
		s5dSnisdgCa(P_0, P_1);
		P_1.EndUpdate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OHYSnExtraData(string P_0, TreeView P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string dataFolderKey = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206);
		TreeNode portalsNode = P_1.Nodes.Add(PeTreeTags.PortalsFolder, PeTreeTags.PortalsFolder);
		portalsNode.Name = PeTreeTags.PortalsFolder;
		QMYSnKmL9tX(portalsNode, dataFolderKey);
		AttachPortalsNode(P_0, portalsNode);
		TreeNode structuresNode = P_1.Nodes.Add(PeTreeTags.StructuresFolder, PeTreeTags.StructuresFolder);
		structuresNode.Name = PeTreeTags.StructuresFolder;
		structuresNode.Tag = PeTreeTags.OpenStructureManager;
		QMYSnKmL9tX(structuresNode, dataFolderKey);
		TreeNode tickingareasNode = P_1.Nodes.Add(PeTreeTags.TickingareasFolder, PeTreeTags.TickingareasFolder);
		tickingareasNode.Name = PeTreeTags.TickingareasFolder;
		tickingareasNode.Tag = PeTreeTags.OpenTickingareaManager;
		QMYSnKmL9tX(tickingareasNode, dataFolderKey);
		TreeNode mapsNode = P_1.Nodes.Add(PeTreeTags.MapsNode, PeTreeTags.MapsNode);
		mapsNode.Name = PeTreeTags.MapsNode;
		mapsNode.Tag = PeTreeTags.OpenPlayerMaps;
		QMYSnKmL9tX(mapsNode, PeTreeTags.MapsNode);
		RY8SnPrefixedData(P_0, P_1, dataFolderKey, PeTreeTags.StructureTemplatePrefix, PeTreeTags.StructuresFolder);
		RY8SnPrefixedData(P_0, P_1, dataFolderKey, PeTreeTags.TickingareaPrefix, PeTreeTags.TickingareasFolder);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AttachPortalsNode(string worldPath, TreeNode portalsNode)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string fileNameOnDisk = PeTreeTags.PortalsKey + PeStagingPaths.DataFileExtension;
		string absolutePath = PeStagingPaths.BuildDataAbsolutePath(worldPath, fileNameOnDisk);
		if (!File.Exists(absolutePath))
		{
			return;
		}
		IndexEntry indexEntry = new IndexEntry();
		indexEntry.FileName = PeTreeTags.PortalsKey;
		indexEntry.FilePath = PeStagingPaths.BuildDataRelativePath(fileNameOnDisk);
		indexEntry.ParentName = PeTreeTags.PortalsFolder;
		portalsNode.Tag = indexEntry;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RY8SnPrefixedData(string P_0, TreeView P_1, string dataFolderKey, string prefix, string dedicatedParent)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Path.Combine(P_0, dataFolderKey);
		if (!Directory.Exists(path))
		{
			return;
		}
		string[] files = Directory.GetFiles(path, prefix + "*");
		Array.Sort(files, StringComparer.OrdinalIgnoreCase);
		string[] array = files;
		foreach (string path2 in array)
		{
			string fileNameOnDisk = Path.GetFileName(path2);
			string ldbKey = FileUtils.DecodeLdbKeyFileName(Path.GetFileNameWithoutExtension(fileNameOnDisk));
			string displayName = FormatPrefixedDataDisplayName(ldbKey, prefix, path2);
			IndexEntry indexEntry = new IndexEntry();
			indexEntry.FileName = ldbKey;
			indexEntry.FilePath = PeStagingPaths.BuildDataRelativePath(fileNameOnDisk);
			indexEntry.ParentName = dataFolderKey;
			DisplayFileItem(indexEntry, P_0, P_1, displayName);
			IndexEntry indexEntry2 = new IndexEntry();
			indexEntry2.FileName = ldbKey;
			indexEntry2.FilePath = indexEntry.FilePath;
			indexEntry2.ParentName = dedicatedParent;
			DisplayFileItem(indexEntry2, P_0, P_1, displayName);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string FormatPrefixedDataDisplayName(string ldbKey, string prefix, string filePath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = FileUtils.FormatLdbKeyForDisplay(ldbKey);
		if (string.Equals(prefix, PeTreeTags.TickingareaPrefix, StringComparison.OrdinalIgnoreCase))
		{
			string tickingAreaName = PeLdbDataHelper.TryReadTickingAreaName(filePath);
			if (!string.IsNullOrWhiteSpace(tickingAreaName))
			{
				text = text + " | " + tickingAreaName;
			}
		}
		return text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lSgSnZFH4Ph(string P_0, TreeView P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string dataFolderKey = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206);
		string path = Path.Combine(P_0, dataFolderKey);
		if (!Directory.Exists(path))
		{
			return;
		}
		string[] files = Directory.GetFiles(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99040));
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		string[] array = files;
		foreach (string path2 in array)
		{
			string text = FileUtils.DecodeLdbKeyFileName(Path.GetFileNameWithoutExtension(path2));
			if (text.StartsWith(PeTreeTags.StructureTemplatePrefix, StringComparison.OrdinalIgnoreCase))
			{
				list.Add(path2);
			}
			else if (text.StartsWith(PeTreeTags.TickingareaPrefix, StringComparison.OrdinalIgnoreCase))
			{
				list2.Add(path2);
			}
			else if (text.StartsWith("map_", StringComparison.OrdinalIgnoreCase))
			{
				list3.Add(path2);
			}
			else
			{
				list4.Add(path2);
			}
		}
		list.Sort(StringComparer.OrdinalIgnoreCase);
		list2.Sort(StringComparer.OrdinalIgnoreCase);
		list3.Sort(CompareMapFilePaths);
		list4.Sort(StringComparer.OrdinalIgnoreCase);
		List<string> list5 = new List<string>();
		list5.AddRange(list);
		list5.AddRange(list2);
		list5.AddRange(list3);
		list5.AddRange(list4);
		foreach (string path3 in list5)
		{
			string text2 = FileUtils.DecodeLdbKeyFileName(Path.GetFileNameWithoutExtension(path3));
			IndexEntry indexEntry = new IndexEntry();
			indexEntry.FileName = text2;
			indexEntry.FilePath = PeStagingPaths.BuildDataRelativePath(Path.GetFileName(path3));
			indexEntry.ParentName = dataFolderKey;
			string displayName = null;
			if (text2.StartsWith(PeTreeTags.TickingareaPrefix, StringComparison.OrdinalIgnoreCase))
			{
				displayName = FormatPrefixedDataDisplayName(text2, PeTreeTags.TickingareaPrefix, path3);
			}
			else if (text2.StartsWith(PeTreeTags.StructureTemplatePrefix, StringComparison.OrdinalIgnoreCase))
			{
				displayName = FileUtils.FormatLdbKeyForDisplay(text2);
			}
			else if (text2.IndexOf('%') >= 0)
			{
				displayName = FileUtils.FormatLdbKeyForDisplay(text2);
			}
			DisplayFileItem(indexEntry, P_0, P_1, displayName);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int CompareMapFilePaths(string leftPath, string rightPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Path.GetFileNameWithoutExtension(leftPath);
		string text2 = Path.GetFileNameWithoutExtension(rightPath);
		long result = 0L;
		long result2 = 0L;
		if (text.StartsWith("map_", StringComparison.OrdinalIgnoreCase))
		{
			long.TryParse(text.Substring(4), out result);
		}
		if (text2.StartsWith("map_", StringComparison.OrdinalIgnoreCase))
		{
			long.TryParse(text2.Substring(4), out result2);
		}
		int num = result.CompareTo(result2);
		if (num != 0)
		{
			return num;
		}
		return string.Compare(text, text2, StringComparison.OrdinalIgnoreCase);
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
		return DisplayFileItem(entry, folderPath, treeView, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TreeNode DisplayFileItem(IndexEntry entry, string folderPath, TreeView treeView, string displayText)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = null;
		TreeNode treeNode2 = wxvSnq3Ojyu(entry, treeView);
		string fileName = entry.FileName;
		string text = displayText ?? FileUtils.FormatLdbKeyForDisplay(fileName);
		if (treeNode2 != null)
		{
			if (entry.IsRegion)
			{
				string key = fileName.Substring(0, fileName.LastIndexOf('.'));
				treeNode = treeNode2.Nodes.Add(key, fileName);
			}
			else
			{
				treeNode = treeNode2.Nodes.Add(fileName, text);
			}
		}
		else
		{
			treeNode = treeView.Nodes.Add(fileName, text);
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
		Constants.RefreshWorldDimensions();
		for (int i = 0; i < list.Count; i++)
		{
			if (i >= 3 && list[i].Region.Count == 0)
			{
				continue;
			}
			string folderKey = Constants.GetDimensionFolderName(i);
			TreeNode treeNode = z8dSnDmNode(P_0, P_1, folderKey, i);
			foreach (string key2 in list[i].Region.Keys)
			{
				PERegion pERegion = list[i].Region[key2];
				TreeNode treeNode2 = treeNode.Nodes.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + key2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + key2);
				treeNode2.Tag = pERegion;
				QMYSnKmL9tX(treeNode2, folderKey.ToLower());
				TreeNode treeNode3 = treeNode2.Nodes.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93588));
				treeNode3.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93588);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TreeNode z8dSnDmNode(string worldPath, TreeView treeView, string folderKey, int dimensionId)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode[] array = treeView.Nodes.Find(folderKey, searchAllChildren: false);
		if (array != null && array.Length > 0)
		{
			return array[0];
		}
		string displayName = Constants.GetDimensionDisplayName(dimensionId);
		TreeNode treeNode = treeView.Nodes.Add(folderKey, displayName);
		string path = worldPath + Working.WorkFolder + FileUtils.CheckFolderSep(folderKey);
		treeNode.Tag = new DimensionWorkingData(folderKey, path);
		QMYSnKmL9tX(treeNode, folderKey);
		return treeNode;
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
			chunkData.Parent = Constants.GetDimensionFolderName(P_0.Dimension).ToLower();
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
		if (P_0 != null)
		{
			string key = P_0.ToLower();
			if (TCSSnmOuqX2.ContainsKey(key))
			{
				result = TCSSnmOuqX2[key];
			}
			else if (key.StartsWith("pe_dim_", StringComparison.OrdinalIgnoreCase) || (key.StartsWith("dm") && key.Length > 2 && char.IsDigit(key[2])))
			{
				result = TCSSnmOuqX2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936)];
			}
			else if (string.Equals(key, PeTreeTags.StructuresFolder, StringComparison.OrdinalIgnoreCase)
				|| string.Equals(key, PeTreeTags.TickingareasFolder, StringComparison.OrdinalIgnoreCase)
				|| string.Equals(key, PeTreeTags.PortalsFolder, StringComparison.OrdinalIgnoreCase))
			{
				result = TCSSnmOuqX2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)];
			}
			else if (string.Equals(key, PeTreeTags.MapsNode, StringComparison.OrdinalIgnoreCase))
			{
				result = TCSSnmOuqX2[PeTreeTags.MapsNode.ToLowerInvariant()];
			}
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
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60336),
				3
			},
			{
				PeTreeTags.MapsNode.ToLowerInvariant(),
				5
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60350),
				4
			}
		};
	}
}
