using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCPELevelDBI.workers;
using Substrate.Nbt;

namespace MCCToolChest.utils;

public enum PeManagedDataKind
{
	Structure,
	Tickingarea
}

public class PeManagedDataEntry
{
	public string LdbKey { get; set; }

	public string DisplayName { get; set; }

	public string StagingFilePath { get; set; }
}

public static class PeLdbDataHelper
{
	private const string DefaultStructureNamespace = "mystructure";

	public static List<PeManagedDataEntry> ListEntries(string worldStagingPath, PeManagedDataKind kind, TreeView treeView = null)
	{
		Dictionary<string, PeManagedDataEntry> dictionary = new Dictionary<string, PeManagedDataEntry>(StringComparer.Ordinal);
		foreach (PeManagedDataEntry item in ListEntriesFromDisk(worldStagingPath, kind))
		{
			dictionary[item.LdbKey] = item;
		}
		if (treeView != null)
		{
			foreach (PeManagedDataEntry item2 in ListEntriesFromTree(treeView, kind))
			{
				if (!dictionary.ContainsKey(item2.LdbKey))
				{
					dictionary[item2.LdbKey] = item2;
				}
			}
		}
		List<PeManagedDataEntry> list = dictionary.Values.ToList();
		list.Sort((PeManagedDataEntry a, PeManagedDataEntry b) => string.Compare(a.LdbKey, b.LdbKey, StringComparison.OrdinalIgnoreCase));
		return list;
	}

	public static List<PeManagedDataEntry> ListEntriesFromDisk(string worldStagingPath, PeManagedDataKind kind)
	{
		List<PeManagedDataEntry> list = new List<PeManagedDataEntry>();
		string dataFolderPath = PeStagingPaths.GetDataFolderPath(worldStagingPath);
		if (!Directory.Exists(dataFolderPath))
		{
			return list;
		}
		string prefix = GetPrefix(kind);
		string[] files = Directory.GetFiles(dataFolderPath, prefix + "*");
		Array.Sort(files, StringComparer.OrdinalIgnoreCase);
		foreach (string text in files)
		{
			AddEntryFromFile(list, text, kind);
		}
		return list;
	}

	public static List<PeManagedDataEntry> ListEntriesFromTree(TreeView treeView, PeManagedDataKind kind)
	{
		Dictionary<string, PeManagedDataEntry> dictionary = new Dictionary<string, PeManagedDataEntry>(StringComparer.Ordinal);
		if (treeView == null)
		{
			return new List<PeManagedDataEntry>();
		}
		string prefix = GetPrefix(kind);
		CollectTreeEntries(treeView.Nodes, dictionary, prefix, kind);
		List<PeManagedDataEntry> list = dictionary.Values.ToList();
		list.Sort((PeManagedDataEntry a, PeManagedDataEntry b) => string.Compare(a.LdbKey, b.LdbKey, StringComparison.OrdinalIgnoreCase));
		return list;
	}

	public static string BuildDisplayName(string ldbKey, PeManagedDataKind kind, string stagingFilePath)
	{
		string text = FileUtils.FormatLdbKeyForDisplay(ldbKey);
		if (kind == PeManagedDataKind.Tickingarea)
		{
			string tickingAreaName = TryReadTickingAreaName(stagingFilePath);
			if (!string.IsNullOrWhiteSpace(tickingAreaName))
			{
				text = text + " | " + tickingAreaName;
			}
		}
		return text;
	}

	public static string TryReadTickingAreaName(string stagingFilePath)
	{
		try
		{
			if (!File.Exists(stagingFilePath))
			{
				return null;
			}
			byte[] data = File.ReadAllBytes(stagingFilePath);
			TagNodeCompound tagNodeCompound = TryParseCompoundRoot(data);
			if (tagNodeCompound == null)
			{
				return null;
			}
			return FindNameTag(tagNodeCompound);
		}
		catch (Exception)
		{
		}
		return null;
	}

	public static string StructureExportFileName(string ldbKey)
	{
		string text = ldbKey;
		int num = text.IndexOf(':');
		if (num >= 0 && num < text.Length - 1)
		{
			text = text.Substring(num + 1);
		}
		return FileUtils.SanitizeWindowsFileName(text) + ".mcstructure";
	}

	public static string TickingareaExportFileName(string ldbKey, string stagingFilePath)
	{
		string text = FileUtils.SanitizeWindowsFileName(ldbKey);
		string tickingAreaName = TryReadTickingAreaName(stagingFilePath);
		if (!string.IsNullOrWhiteSpace(tickingAreaName))
		{
			text = text + "_" + FileUtils.SanitizeWindowsFileName(tickingAreaName);
		}
		return text + ".nbt";
	}

	public static string DefaultStructureImportKey(string filePath, string namespacePrefix = DefaultStructureNamespace)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
		return PeTreeTags.StructureTemplatePrefix + namespacePrefix + ":" + fileNameWithoutExtension;
	}

	public static string DefaultTickingareaImportKey(string filePath)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
		return PeTreeTags.TickingareaPrefix + fileNameWithoutExtension;
	}

	public static string SuggestImportKey(string filePath, PeManagedDataKind kind, string namespacePrefix = DefaultStructureNamespace)
	{
		if (kind == PeManagedDataKind.Structure)
		{
			return DefaultStructureImportKey(filePath, namespacePrefix);
		}
		return DefaultTickingareaImportKey(filePath);
	}

	public static bool ExportEntry(PeManagedDataEntry entry, PeManagedDataKind kind, string targetFilePath)
	{
		if (entry == null || string.IsNullOrWhiteSpace(entry.LdbKey))
		{
			return false;
		}
		Working.FlushStagingEntriesForExport?.Invoke(new string[1] { entry.LdbKey });
		if (string.IsNullOrWhiteSpace(entry.StagingFilePath) || !File.Exists(entry.StagingFilePath))
		{
			PeManagedDataEntry refreshed = TryGetEntry(Working.T92StMGt1p4(), kind, entry.LdbKey);
			if (refreshed != null)
			{
				entry = refreshed;
			}
		}
		if (string.IsNullOrWhiteSpace(entry.StagingFilePath) || !File.Exists(entry.StagingFilePath))
		{
			MessageBox.Show("Selected entry file was not found in the staging folder.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return false;
		}
		if (File.Exists(targetFilePath))
		{
			DialogResult dialogResult = MessageBox.Show("File already exists:\n" + targetFilePath + "\n\nOverwrite?", "Export", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return false;
			}
		}
		Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath));
		File.Copy(entry.StagingFilePath, targetFilePath, overwrite: true);
		return true;
	}

	public static List<string> ImportFiles(string worldStagingPath, PeManagedDataKind kind, IEnumerable<string> sourceFiles, string singleLdbKeyOverride, TreeView treeView)
	{
		string[] array = sourceFiles?.Where(File.Exists).ToArray() ?? Array.Empty<string>();
		if (array.Length == 0)
		{
			return new List<string>();
		}
		bool multi = array.Length > 1;
		List<(string file, string key)> list = new List<(string, string)>();
		foreach (string text in array)
		{
			string item = BuildImportKey(text, kind, singleLdbKeyOverride, multi);
			if (string.IsNullOrWhiteSpace(item))
			{
				return new List<string>();
			}
			list.Add((text, item));
		}
		Dictionary<string, PeManagedDataEntry> existing = ListEntries(worldStagingPath, kind, treeView).ToDictionary((PeManagedDataEntry e) => e.LdbKey, (PeManagedDataEntry e) => e, StringComparer.Ordinal);
		List<(string file, string key)> list2 = list.Where(((string file, string key) p) => existing.ContainsKey(p.key)).ToList();
		if (list2.Count > 0)
		{
			string text2 = (list2.Count == 1) ? ("An entry already exists for key:\n" + list2[0].key) : ("Some import keys already exist (" + list2.Count + "). Replace all existing matches?");
			DialogResult dialogResult = ((list2.Count == 1) ? MessageBox.Show(text2 + "\n\nReplace existing entry?", "Import", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) : MessageBox.Show(text2, "Import", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question));
			if (dialogResult == DialogResult.Cancel)
			{
				return new List<string>();
			}
			if (dialogResult == DialogResult.No && list2.Count > 1)
			{
				list = list.Where(((string file, string key) p) => !existing.ContainsKey(p.key)).ToList();
				if (list.Count == 0)
				{
					return new List<string>();
				}
			}
			else if (dialogResult == DialogResult.No)
			{
				return new List<string>();
			}
		}
		Directory.CreateDirectory(PeStagingPaths.GetDataFolderPath(worldStagingPath));
		PEFileTree pEFileTree = new PEFileTree();
		string dedicatedParent = (kind == PeManagedDataKind.Structure) ? PeTreeTags.StructuresFolder : PeTreeTags.TickingareasFolder;
		List<string> list3 = new List<string>();
		foreach (var item2 in list)
		{
			string text3 = FileUtils.EncodeLdbKeyFileName(item2.key) + PeStagingPaths.DataFileExtension;
			string text4 = PeStagingPaths.BuildDataAbsolutePath(worldStagingPath, text3);
			File.Copy(item2.file, text4, overwrite: true);
			RemoveTreeEntriesByKey(treeView, item2.key);
			string displayName = BuildDisplayName(item2.key, kind, text4);
			IndexEntry indexEntry = new IndexEntry
			{
				FileName = item2.key,
				FilePath = PeStagingPaths.BuildDataRelativePath(text3),
				ParentName = PeStagingPaths.DataFolderName
			};
			pEFileTree.DisplayFileItem(indexEntry, worldStagingPath, treeView, displayName);
			IndexEntry indexEntry2 = new IndexEntry
			{
				FileName = item2.key,
				FilePath = indexEntry.FilePath,
				ParentName = dedicatedParent
			};
			pEFileTree.DisplayFileItem(indexEntry2, worldStagingPath, treeView, displayName);
			list3.Add(item2.key);
		}
		Working.DataChanged = true;
		return list3;
	}

	public static List<string> AddEmptyEntry(string worldStagingPath, PeManagedDataKind kind, bool circleTickingarea, TreeView treeView, string structureNamespacePrefix = DefaultStructureNamespace, string structureName = "new_structure", string ldbKeyOverride = null)
	{
		byte[] bytes = (kind == PeManagedDataKind.Structure) ? BuildEmptyStructureBytes() : BuildEmptyTickingareaBytes(circleTickingarea);
		string text = ResolveNewEntryKey(kind, circleTickingarea, structureNamespacePrefix, structureName, ldbKeyOverride, worldStagingPath, treeView);
		Directory.CreateDirectory(PeStagingPaths.GetDataFolderPath(worldStagingPath));
		string text2 = FileUtils.EncodeLdbKeyFileName(text) + PeStagingPaths.DataFileExtension;
		string text3 = PeStagingPaths.BuildDataAbsolutePath(worldStagingPath, text2);
		int num = 0;
		while (File.Exists(text3) || KeyExistsInTree(treeView, text))
		{
			num++;
			text = ((kind == PeManagedDataKind.Structure) ? ResolveStructureManualKey(PeTreeTags.StructureTemplatePrefix + structureNamespacePrefix + ":new_structure" + ((num == 1) ? "_1" : ("_" + num)), structureNamespacePrefix, worldStagingPath, treeView) : ResolveTickingareaManualKey(PeTreeTags.TickingareaPrefix + "new_tickingarea" + ((num == 1) ? "" : ("_" + num)), worldStagingPath, treeView));
			text2 = FileUtils.EncodeLdbKeyFileName(text) + PeStagingPaths.DataFileExtension;
			text3 = PeStagingPaths.BuildDataAbsolutePath(worldStagingPath, text2);
		}
		FileUtils.WriteFile(bytes, text3);
		PEFileTree pEFileTree = new PEFileTree();
		string dedicatedParent = (kind == PeManagedDataKind.Structure) ? PeTreeTags.StructuresFolder : PeTreeTags.TickingareasFolder;
		string displayName = BuildDisplayName(text, kind, text3);
		IndexEntry indexEntry = new IndexEntry
		{
			FileName = text,
			FilePath = PeStagingPaths.BuildDataRelativePath(text2),
			ParentName = PeStagingPaths.DataFolderName
		};
		pEFileTree.DisplayFileItem(indexEntry, worldStagingPath, treeView, displayName);
		IndexEntry indexEntry2 = new IndexEntry
		{
			FileName = text,
			FilePath = indexEntry.FilePath,
			ParentName = dedicatedParent
		};
		pEFileTree.DisplayFileItem(indexEntry2, worldStagingPath, treeView, displayName);
		Working.DataChanged = true;
		return new List<string> { text };
	}

	public static PeManagedDataEntry TryGetEntry(string worldStagingPath, PeManagedDataKind kind, string ldbKey, TreeView treeView = null)
	{
		if (string.IsNullOrWhiteSpace(ldbKey))
		{
			return null;
		}
		foreach (PeManagedDataEntry item in ListEntries(worldStagingPath, kind, treeView))
		{
			if (string.Equals(item.LdbKey, ldbKey, StringComparison.Ordinal))
			{
				return item;
			}
		}
		return null;
	}

	public static IndexEntry BuildIndexEntry(string ldbKey, PeManagedDataKind kind, string worldStagingPath)
	{
		string fileNameOnDisk = FileUtils.EncodeLdbKeyFileName(ldbKey) + PeStagingPaths.DataFileExtension;
		return new IndexEntry
		{
			FileName = ldbKey,
			FilePath = PeStagingPaths.BuildDataRelativePath(fileNameOnDisk),
			ParentName = PeStagingPaths.DataFolderName
		};
	}

	public static PeManagedDataEntry CreateEntryFromIndex(IndexEntry indexEntry, string worldStagingPath, PeManagedDataKind kind)
	{
		if (indexEntry == null)
		{
			return null;
		}
		string stagingFilePath = worldStagingPath + indexEntry.FilePath;
		return new PeManagedDataEntry
		{
			LdbKey = indexEntry.FileName,
			DisplayName = BuildDisplayName(indexEntry.FileName, kind, stagingFilePath),
			StagingFilePath = stagingFilePath
		};
	}

	public static bool DeleteEntry(string worldStagingPath, string ldbKey, TreeView treeView)
	{
		if (string.IsNullOrWhiteSpace(worldStagingPath) || string.IsNullOrWhiteSpace(ldbKey))
		{
			return false;
		}
		RemoveTreeEntriesByKey(treeView, ldbKey);
		string fileNameOnDisk = FileUtils.EncodeLdbKeyFileName(ldbKey) + PeStagingPaths.DataFileExtension;
		string absolutePath = PeStagingPaths.BuildDataAbsolutePath(worldStagingPath, fileNameOnDisk);
		if (File.Exists(absolutePath))
		{
			File.Delete(absolutePath);
		}
		try
		{
			PEProcessWorker.DeleteRecord(ldbKey, worldStagingPath);
		}
		catch (Exception)
		{
		}
		Working.DataChanged = true;
		return true;
	}

	public static bool RenameEntry(string worldStagingPath, string oldKey, string newKey, TreeView treeView, PeManagedDataKind kind)
	{
		if (string.IsNullOrWhiteSpace(worldStagingPath) || string.IsNullOrWhiteSpace(oldKey) || string.IsNullOrWhiteSpace(newKey))
		{
			return false;
		}
		oldKey = oldKey.Trim();
		newKey = newKey.Trim();
		if (string.Equals(oldKey, newKey, StringComparison.Ordinal))
		{
			return true;
		}
		string oldFileNameOnDisk = FileUtils.EncodeLdbKeyFileName(oldKey) + PeStagingPaths.DataFileExtension;
		string newFileNameOnDisk = FileUtils.EncodeLdbKeyFileName(newKey) + PeStagingPaths.DataFileExtension;
		string oldAbsolutePath = PeStagingPaths.BuildDataAbsolutePath(worldStagingPath, oldFileNameOnDisk);
		string newAbsolutePath = PeStagingPaths.BuildDataAbsolutePath(worldStagingPath, newFileNameOnDisk);
		if (!File.Exists(oldAbsolutePath) || File.Exists(newAbsolutePath) || KeyExistsInTree(treeView, newKey))
		{
			return false;
		}
		List<TreeNode> list = new List<TreeNode>();
		FindTreeNodesByKey(treeView?.Nodes, oldKey, list);
		HashSet<string> parentNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		foreach (TreeNode item in list)
		{
			if (item.Tag is IndexEntry indexEntry)
			{
				parentNames.Add(indexEntry.ParentName);
			}
		}
		foreach (TreeNode item2 in list)
		{
			item2.Remove();
		}
		File.Move(oldAbsolutePath, newAbsolutePath);
		string newRelativePath = PeStagingPaths.BuildDataRelativePath(newFileNameOnDisk);
		string displayName = BuildDisplayName(newKey, kind, newAbsolutePath);
		PEFileTree pEFileTree = new PEFileTree();
		foreach (string parentName in parentNames)
		{
			if (string.IsNullOrWhiteSpace(parentName))
			{
				continue;
			}
			IndexEntry indexEntry2 = new IndexEntry
			{
				FileName = newKey,
				FilePath = newRelativePath,
				ParentName = parentName
			};
			pEFileTree.DisplayFileItem(indexEntry2, worldStagingPath, treeView, displayName);
		}
		try
		{
			PEProcessWorker.DeleteRecord(oldKey, worldStagingPath);
		}
		catch (Exception)
		{
		}
		Working.DataChanged = true;
		return true;
	}

	private static string ResolveNewEntryKey(PeManagedDataKind kind, bool circleTickingarea, string structureNamespacePrefix, string structureName, string ldbKeyOverride, string worldStagingPath, TreeView treeView)
	{
		if (kind == PeManagedDataKind.Structure)
		{
			if (ldbKeyOverride != null)
			{
				return ResolveStructureManualKey(ldbKeyOverride, structureNamespacePrefix, worldStagingPath, treeView);
			}
			return PeTreeTags.StructureTemplatePrefix + structureNamespacePrefix + ":" + structureName;
		}
		if (ldbKeyOverride == null)
		{
			return PeTreeTags.TickingareaPrefix + Guid.NewGuid().ToString("N");
		}
		return ResolveTickingareaManualKey(ldbKeyOverride, worldStagingPath, treeView);
	}

	private static string ResolveStructureManualKey(string ldbKeyOverride, string structureNamespacePrefix, string worldStagingPath, TreeView treeView)
	{
		string text = PeTreeTags.StructureTemplatePrefix + structureNamespacePrefix + ":";
		string text2 = (ldbKeyOverride ?? text).Trim();
		if (!text2.StartsWith(PeTreeTags.StructureTemplatePrefix, StringComparison.OrdinalIgnoreCase))
		{
			text2 = text + text2;
		}
		int num = text2.IndexOf(':');
		if (num < 0)
		{
			text2 = text;
		}
		string namePart = (num >= 0 && num < text2.Length - 1) ? text2.Substring(num + 1) : "";
		if (string.IsNullOrEmpty(namePart))
		{
			if (!KeyExists(worldStagingPath, text2, treeView))
			{
				return text2;
			}
			int num2 = 0;
			while (true)
			{
				string candidate = text + "new_structure" + ((num2 == 0) ? "" : ("_" + num2));
				if (!KeyExists(worldStagingPath, candidate, treeView))
				{
					return candidate;
				}
				num2++;
			}
		}
		return text2;
	}

	private static string ResolveTickingareaManualKey(string ldbKeyOverride, string worldStagingPath, TreeView treeView)
	{
		string prefix = PeTreeTags.TickingareaPrefix;
		string text = (ldbKeyOverride ?? prefix).Trim();
		if (!text.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
		{
			text = prefix + text;
		}
		string namePart = text.Substring(prefix.Length);
		if (string.IsNullOrEmpty(namePart))
		{
			if (!KeyExists(worldStagingPath, prefix, treeView))
			{
				return prefix;
			}
			int num = 0;
			while (true)
			{
				string candidate = prefix + "new_tickingarea" + ((num == 0) ? "" : ("_" + num));
				if (!KeyExists(worldStagingPath, candidate, treeView))
				{
					return candidate;
				}
				num++;
			}
		}
		return text;
	}

	private static bool KeyExists(string worldStagingPath, string ldbKey, TreeView treeView)
	{
		string fileNameOnDisk = FileUtils.EncodeLdbKeyFileName(ldbKey) + PeStagingPaths.DataFileExtension;
		if (File.Exists(PeStagingPaths.BuildDataAbsolutePath(worldStagingPath, fileNameOnDisk)))
		{
			return true;
		}
		return KeyExistsInTree(treeView, ldbKey);
	}

	private static bool KeyExistsInTree(TreeView treeView, string ldbKey)
	{
		if (treeView == null || string.IsNullOrWhiteSpace(ldbKey))
		{
			return false;
		}
		List<TreeNode> list = new List<TreeNode>();
		FindTreeNodesByKey(treeView.Nodes, ldbKey, list);
		return list.Count > 0;
	}

	private static void AddEntryFromFile(List<PeManagedDataEntry> list, string absolutePath, PeManagedDataKind kind)
	{
		string ldbKey = FileUtils.DecodeLdbKeyFileName(Path.GetFileNameWithoutExtension(absolutePath));
		list.Add(new PeManagedDataEntry
		{
			LdbKey = ldbKey,
			DisplayName = BuildDisplayName(ldbKey, kind, absolutePath),
			StagingFilePath = absolutePath
		});
	}

	private static void CollectTreeEntries(TreeNodeCollection nodes, Dictionary<string, PeManagedDataEntry> entries, string prefix, PeManagedDataKind kind)
	{
		foreach (TreeNode node in nodes)
		{
			if (node.Tag is IndexEntry indexEntry && indexEntry.FileName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
			{
				string stagingFilePath = Working.T92StMGt1p4() + indexEntry.FilePath;
				if (!entries.ContainsKey(indexEntry.FileName))
				{
					entries[indexEntry.FileName] = new PeManagedDataEntry
					{
						LdbKey = indexEntry.FileName,
						DisplayName = BuildDisplayName(indexEntry.FileName, kind, stagingFilePath),
						StagingFilePath = stagingFilePath
					};
				}
			}
			CollectTreeEntries(node.Nodes, entries, prefix, kind);
		}
	}

	private static void RemoveTreeEntriesByKey(TreeView treeView, string ldbKey)
	{
		if (treeView == null)
		{
			return;
		}
		List<TreeNode> list = new List<TreeNode>();
		FindTreeNodesByKey(treeView.Nodes, ldbKey, list);
		foreach (TreeNode item in list)
		{
			item.Remove();
		}
	}

	private static void FindTreeNodesByKey(TreeNodeCollection nodes, string ldbKey, List<TreeNode> matches)
	{
		foreach (TreeNode node in nodes)
		{
			if (node.Tag is IndexEntry indexEntry && string.Equals(indexEntry.FileName, ldbKey, StringComparison.Ordinal))
			{
				matches.Add(node);
			}
			FindTreeNodesByKey(node.Nodes, ldbKey, matches);
		}
	}

	private static string BuildImportKey(string filePath, PeManagedDataKind kind, string singleLdbKeyOverride, bool multi)
	{
		if (kind == PeManagedDataKind.Structure)
		{
			if (multi)
			{
				return DefaultStructureImportKey(filePath);
			}
			if (!string.IsNullOrWhiteSpace(singleLdbKeyOverride))
			{
				return singleLdbKeyOverride.Trim();
			}
			return DefaultStructureImportKey(filePath);
		}
		if (multi)
		{
			return DefaultTickingareaImportKey(filePath);
		}
		if (!string.IsNullOrWhiteSpace(singleLdbKeyOverride))
		{
			return singleLdbKeyOverride.Trim();
		}
		return DefaultTickingareaImportKey(filePath);
	}

	private static string GetPrefix(PeManagedDataKind kind)
	{
		if (kind != PeManagedDataKind.Structure)
		{
			return PeTreeTags.TickingareaPrefix;
		}
		return PeTreeTags.StructureTemplatePrefix;
	}

	private static TagNodeCompound TryParseCompoundRoot(byte[] data)
	{
		int[] array = new int[4] { 0, 4, 8, 12 };
		foreach (int num in array)
		{
			if (data.Length <= num)
			{
				continue;
			}
			try
			{
				MemoryStream memoryStream = new MemoryStream(data, num, data.Length - num, writable: false);
				NbtTree nbtTree = new NbtTree();
				nbtTree.UseBigEndian = false;
				nbtTree.ReadFrom(memoryStream);
				if (nbtTree.Root != null)
				{
					return nbtTree.Root;
				}
			}
			catch (Exception)
			{
			}
		}
		return null;
	}

	private static string FindNameTag(TagNode tag)
	{
		if (tag is TagNodeCompound tagNodeCompound)
		{
			foreach (KeyValuePair<string, TagNode> item in tagNodeCompound)
			{
				if (string.Equals(item.Key, "Name", StringComparison.OrdinalIgnoreCase) && item.Value is TagNodeString tagNodeString && !string.IsNullOrWhiteSpace(tagNodeString.Data))
				{
					return tagNodeString.Data;
				}
			}
			foreach (TagNode value in tagNodeCompound.Values)
			{
				string text = FindNameTag(value);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return text;
				}
			}
		}
		else if (tag is TagNodeList tagNodeList)
		{
			foreach (TagNode item2 in tagNodeList)
			{
				string text2 = FindNameTag(item2);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					return text2;
				}
			}
		}
		return null;
	}

	private static TagNodeList CreateIntList(int a, int b, int c)
	{
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_INT);
		tagNodeList.Add(new TagNodeInt(a));
		tagNodeList.Add(new TagNodeInt(b));
		tagNodeList.Add(new TagNodeInt(c));
		return tagNodeList;
	}

	private static byte[] BuildEmptyStructureBytes()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound["format_version"] = new TagNodeInt(1);
		tagNodeCompound["size"] = CreateIntList(0, 0, 0);
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_INT);
		tagNodeList.Add(new TagNodeInt(0));
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_INT);
		tagNodeList2.Add(new TagNodeInt(0));
		TagNodeList tagNodeList3 = new TagNodeList(TagType.TAG_LIST);
		tagNodeList3.Add(tagNodeList);
		tagNodeList3.Add(tagNodeList2);
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		tagNodeCompound2["block_indices"] = tagNodeList3;
		tagNodeCompound2["entities"] = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeCompound tagNodeCompound3 = new TagNodeCompound();
		TagNodeCompound tagNodeCompound4 = new TagNodeCompound();
		TagNodeList tagNodeList4 = new TagNodeList(TagType.TAG_COMPOUND);
		tagNodeList4.Add(new TagNodeCompound());
		tagNodeCompound4["block_palette"] = tagNodeList4;
		tagNodeCompound4["block_position_data"] = new TagNodeCompound();
		tagNodeCompound3["default"] = tagNodeCompound4;
		tagNodeCompound2["palette"] = tagNodeCompound3;
		tagNodeCompound["structure"] = tagNodeCompound2;
		tagNodeCompound["structure_world_origin"] = CreateIntList(0, 0, 0);
		return CompoundToFileBytes(tagNodeCompound);
	}

	private static byte[] BuildEmptyTickingareaBytes(bool circle)
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound
		{
			["Dimension"] = new TagNodeInt(0),
			["IsCircle"] = new TagNodeByte((byte)(circle ? 1 : 0)),
			["MaxX"] = new TagNodeInt(0),
			["MaxZ"] = new TagNodeInt(0),
			["MinX"] = new TagNodeInt(0),
			["MinZ"] = new TagNodeInt(0),
			["Name"] = new TagNodeString("")
		};
		if (circle)
		{
			tagNodeCompound["EntityId"] = new TagNodeLong(0L);
			tagNodeCompound["IsAlwaysActive"] = new TagNodeByte(0);
			tagNodeCompound["MaxDistToPlayers"] = new TagNodeFloat(0f);
		}
		return CompoundToFileBytes(tagNodeCompound);
	}

	private static byte[] CompoundToFileBytes(TagNodeCompound compound)
	{
		MemoryStream memoryStream = new MemoryStream();
		NbtTree nbtTree = new NbtTree(compound);
		nbtTree.UseBigEndian = false;
		nbtTree.WriteTo(memoryStream);
		return memoryStream.ToArray();
	}
}
