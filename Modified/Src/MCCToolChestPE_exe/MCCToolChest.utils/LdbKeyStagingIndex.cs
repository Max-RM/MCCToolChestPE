using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MCCToolChest.model;

namespace MCCToolChest.utils;

public static class LdbKeyStagingIndex
{
	private const string IndexFileName = "ldb_key_index.txt";

	private static readonly Dictionary<string, Dictionary<string, string>> CacheByStagingRoot = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

	public static bool IsHashedStagingFileName(string fileNameWithoutExtension)
	{
		if (string.IsNullOrEmpty(fileNameWithoutExtension))
		{
			return false;
		}
		int num = fileNameWithoutExtension.IndexOf('~');
		return num > 0 && fileNameWithoutExtension.Length > num + 8;
	}

	public static void Register(string stagingRoot, string fileNameWithoutExtension, string ldbKey)
	{
		if (string.IsNullOrWhiteSpace(stagingRoot) || string.IsNullOrWhiteSpace(fileNameWithoutExtension) || string.IsNullOrWhiteSpace(ldbKey))
		{
			return;
		}
		if (!IsHashedStagingFileName(fileNameWithoutExtension))
		{
			return;
		}
		Dictionary<string, string> map = GetOrLoad(stagingRoot);
		map[fileNameWithoutExtension] = ldbKey;
	}

	public static bool TryGetLdbKey(string stagingRoot, string fileNameWithoutExtension, out string ldbKey)
	{
		ldbKey = null;
		if (string.IsNullOrWhiteSpace(stagingRoot) || string.IsNullOrWhiteSpace(fileNameWithoutExtension))
		{
			return false;
		}
		if (!IsHashedStagingFileName(fileNameWithoutExtension))
		{
			return false;
		}
		Dictionary<string, string> map = GetOrLoad(stagingRoot);
		return map.TryGetValue(fileNameWithoutExtension, out ldbKey);
	}

	public static void Save(string stagingRoot)
	{
		if (string.IsNullOrWhiteSpace(stagingRoot) || !CacheByStagingRoot.TryGetValue(NormalizeRoot(stagingRoot), out Dictionary<string, string> map) || map.Count == 0)
		{
			return;
		}
		string indexPath = GetIndexPath(stagingRoot);
		Directory.CreateDirectory(Path.GetDirectoryName(indexPath));
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, string> item in map)
		{
			stringBuilder.Append(item.Key);
			stringBuilder.Append('=');
			stringBuilder.AppendLine(item.Value);
		}
		File.WriteAllText(indexPath, stringBuilder.ToString(), Encoding.UTF8);
	}

	public static void ClearCache(string stagingRoot = null)
	{
		if (string.IsNullOrWhiteSpace(stagingRoot))
		{
			CacheByStagingRoot.Clear();
			return;
		}
		CacheByStagingRoot.Remove(NormalizeRoot(stagingRoot));
	}

	private static Dictionary<string, string> GetOrLoad(string stagingRoot)
	{
		string key = NormalizeRoot(stagingRoot);
		if (CacheByStagingRoot.TryGetValue(key, out Dictionary<string, string> map))
		{
			return map;
		}
		map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		string indexPath = GetIndexPath(stagingRoot);
		if (File.Exists(indexPath))
		{
			string[] array = File.ReadAllLines(indexPath);
			foreach (string text in array)
			{
				if (string.IsNullOrWhiteSpace(text))
				{
					continue;
				}
				int num = text.IndexOf('=');
				if (num <= 0 || num >= text.Length - 1)
				{
					continue;
				}
				string key2 = text.Substring(0, num);
				string value = text.Substring(num + 1);
				if (!string.IsNullOrWhiteSpace(key2) && !string.IsNullOrWhiteSpace(value))
				{
					map[key2] = value;
				}
			}
		}
		CacheByStagingRoot[key] = map;
		return map;
	}

	private static string GetIndexPath(string stagingRoot)
	{
		return Path.Combine(PeStagingPaths.GetDataFolderPath(stagingRoot), IndexFileName);
	}

	private static string NormalizeRoot(string stagingRoot)
	{
		return FileUtils.CheckFolderSep(Path.GetFullPath(stagingRoot)).TrimEnd('\\', '/');
	}
}
