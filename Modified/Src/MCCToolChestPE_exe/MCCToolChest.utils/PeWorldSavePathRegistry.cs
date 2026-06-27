using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MCCToolChest.model;

namespace MCCToolChest.utils;

public static class PeWorldSavePathRegistry
{
	private static readonly string CustomPathsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MCCToolChestPE", "custom_world_save_paths.json");

	public static List<PeWorldSavePathItem> GetAvailablePaths()
	{
		Dictionary<string, PeWorldSavePathItem> dictionary = new Dictionary<string, PeWorldSavePathItem>(StringComparer.OrdinalIgnoreCase);
		foreach (PeWorldSavePathTemplate template in PeWorldSavePathDefinitions.BuiltInTemplates)
		{
			TryAddResolvedPath(dictionary, template.Label, ResolveTemplatePath(template), template.Kind, isCustom: false);
		}
		TryAddResolvedPath(dictionary, "Bedrock UWP", Utils.GetGetMCPESaveFolder(), PeWorldSavePathKind.BedrockUwp, isCustom: false);
		DiscoverClonedUwpPaths(dictionary);
		DiscoverEducationUwpClonedPaths(dictionary);
		DiscoverGdkUserPaths(dictionary, @"Roaming\Minecraft Bedrock\Users", "Bedrock GDK", PeWorldSavePathKind.BedrockGdkUser);
		DiscoverGdkUserPaths(dictionary, @"Roaming\Minecraft Bedrock Preview\Users", "Bedrock GDK Preview", PeWorldSavePathKind.BedrockGdkPreviewUser);
		foreach (PeWorldSavePathItem customPath in LoadCustomPaths())
		{
			TryAddResolvedPath(dictionary, customPath.Label, customPath.Path, PeWorldSavePathKind.Custom, isCustom: true);
		}
		return SortPaths(dictionary.Values);
	}

	public static List<PeWorldSavePathItem> LoadCustomPaths()
	{
		List<PeWorldSavePathItem> list = new List<PeWorldSavePathItem>();
		try
		{
			if (!File.Exists(CustomPathsFile))
			{
				return list;
			}
			string[] array = File.ReadAllLines(CustomPathsFile);
			foreach (string text in array)
			{
				if (string.IsNullOrWhiteSpace(text) || text.StartsWith("#", StringComparison.Ordinal))
				{
					continue;
				}
				int num = text.IndexOf('\t');
				if (num <= 0)
				{
					continue;
				}
				list.Add(new PeWorldSavePathItem
				{
					Label = text.Substring(0, num).Trim(),
					Path = text.Substring(num + 1).Trim(),
					IsCustom = true,
					Kind = PeWorldSavePathKind.Custom
				});
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	public static void SaveCustomPaths(IEnumerable<PeWorldSavePathItem> customPaths)
	{
		Directory.CreateDirectory(Path.GetDirectoryName(CustomPathsFile));
		List<string> list = new List<string> { "# Custom world save paths: Label<TAB>FullPath" };
		foreach (PeWorldSavePathItem customPath in customPaths ?? Array.Empty<PeWorldSavePathItem>())
		{
			if (!string.IsNullOrWhiteSpace(customPath?.Label) && !string.IsNullOrWhiteSpace(customPath.Path))
			{
				list.Add(customPath.Label.Trim() + "\t" + customPath.Path.Trim());
			}
		}
		File.WriteAllLines(CustomPathsFile, list);
	}

	public static void AddCustomPath(string label, string path)
	{
		if (string.IsNullOrWhiteSpace(label) || string.IsNullOrWhiteSpace(path))
		{
			return;
		}
		List<PeWorldSavePathItem> list = LoadCustomPaths();
		list.RemoveAll((PeWorldSavePathItem item) => string.Equals(item.Label, label, StringComparison.OrdinalIgnoreCase) || string.Equals(item.Path, path, StringComparison.OrdinalIgnoreCase));
		list.Add(new PeWorldSavePathItem
		{
			Label = label.Trim(),
			Path = path.Trim(),
			IsCustom = true,
			Kind = PeWorldSavePathKind.Custom
		});
		SaveCustomPaths(list);
	}

	public static void RemoveCustomPath(string label)
	{
		if (string.IsNullOrWhiteSpace(label))
		{
			return;
		}
		List<PeWorldSavePathItem> list = LoadCustomPaths();
		list.RemoveAll((PeWorldSavePathItem item) => string.Equals(item.Label, label, StringComparison.OrdinalIgnoreCase));
		SaveCustomPaths(list);
	}

	private static string ResolveTemplatePath(PeWorldSavePathTemplate template)
	{
		string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		string text = template.RelativePath;
		if (text.StartsWith("Packages\\", StringComparison.OrdinalIgnoreCase))
		{
			return Path.Combine(localAppData, text);
		}
		if (text.StartsWith("Roaming\\", StringComparison.OrdinalIgnoreCase))
		{
			return Path.Combine(appData, text.Substring("Roaming\\".Length));
		}
		return text;
	}

	private static string ResolveRoamingRelativePath(string relativePath)
	{
		string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		if (relativePath.StartsWith("Roaming\\", StringComparison.OrdinalIgnoreCase))
		{
			return Path.Combine(appData, relativePath.Substring("Roaming\\".Length));
		}
		return Path.Combine(appData, relativePath.Replace('/', Path.DirectorySeparatorChar));
	}

	private static void DiscoverClonedUwpPaths(Dictionary<string, PeWorldSavePathItem> paths)
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages");
		if (!Directory.Exists(path))
		{
			return;
		}
		string[] directories = Directory.GetDirectories(path);
		foreach (string path2 in directories)
		{
			string fileName = Path.GetFileName(path2);
			if (fileName.IndexOf("Minecraft", StringComparison.OrdinalIgnoreCase) < 0)
			{
				continue;
			}
			if (fileName.IndexOf("MinecraftEducationEdition", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				continue;
			}
			if (fileName.StartsWith("Microsoft.MinecraftUWP_", StringComparison.OrdinalIgnoreCase)
				|| fileName.StartsWith("Microsoft.MinecraftWindowsBeta_", StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			string text = Path.Combine(path2, "LocalState", "games", "com.mojang", "minecraftWorlds");
			TryAddResolvedPath(paths, "Bedrock UWP Cloned: " + fileName, text, PeWorldSavePathKind.BedrockUwpCloned, isCustom: false);
		}
	}

	private static void DiscoverEducationUwpClonedPaths(Dictionary<string, PeWorldSavePathItem> paths)
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages");
		if (!Directory.Exists(path))
		{
			return;
		}
		string[] directories = Directory.GetDirectories(path);
		foreach (string path2 in directories)
		{
			string fileName = Path.GetFileName(path2);
			if (fileName.IndexOf("MinecraftEducationEdition", StringComparison.OrdinalIgnoreCase) < 0)
			{
				continue;
			}
			if (fileName.StartsWith("Microsoft.MinecraftEducationEdition_", StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			string text = Path.Combine(path2, "LocalState", "games", "com.mojang", "minecraftWorlds");
			TryAddResolvedPath(paths, "Education Edition UWP: " + fileName, text, PeWorldSavePathKind.EducationUwpCloned, isCustom: false);
		}
	}

	private static void DiscoverGdkUserPaths(Dictionary<string, PeWorldSavePathItem> paths, string usersRelativePath, string labelPrefix, PeWorldSavePathKind kind)
	{
		string path = ResolveRoamingRelativePath(usersRelativePath);
		if (!Directory.Exists(path))
		{
			return;
		}
		string[] directories = Directory.GetDirectories(path);
		foreach (string path2 in directories)
		{
			string fileName = Path.GetFileName(path2);
			if (string.Equals(fileName, "Shared", StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			string text = Path.Combine(path2, "games", "com.mojang", "minecraftWorlds");
			TryAddResolvedPath(paths, labelPrefix + " " + fileName, text, kind, isCustom: false);
		}
	}

	private static void TryAddResolvedPath(Dictionary<string, PeWorldSavePathItem> paths, string label, string fullPath, PeWorldSavePathKind kind, bool isCustom)
	{
		if (string.IsNullOrWhiteSpace(fullPath) || !Directory.Exists(fullPath))
		{
			return;
		}
		string path = fullPath.TrimEnd('\\', '/');
		string dictionaryKey = path;
		if (paths.TryGetValue(path, out PeWorldSavePathItem existing) && !string.Equals(existing.Label, label, StringComparison.OrdinalIgnoreCase))
		{
			dictionaryKey = path + "\0" + label;
		}
		if (paths.ContainsKey(dictionaryKey))
		{
			return;
		}
		paths[dictionaryKey] = new PeWorldSavePathItem
		{
			Label = label,
			Path = path,
			IsCustom = isCustom,
			Kind = kind
		};
	}

	private static List<PeWorldSavePathItem> SortPaths(IEnumerable<PeWorldSavePathItem> items)
	{
		return items.OrderBy(GetSortOrder).ThenBy((PeWorldSavePathItem item) => item.Label, StringComparer.OrdinalIgnoreCase).ToList();
	}

	private static int GetSortOrder(PeWorldSavePathItem item)
	{
		switch (item.Kind)
		{
		case PeWorldSavePathKind.BedrockUwp:
			return 0;
		case PeWorldSavePathKind.BedrockUwpPreview:
			return 1;
		case PeWorldSavePathKind.BedrockUwpCloned:
			return 2;
		case PeWorldSavePathKind.BedrockGdkShared:
			return 3;
		case PeWorldSavePathKind.BedrockGdkUser:
			return 4;
		case PeWorldSavePathKind.BedrockGdkPreviewShared:
			return 5;
		case PeWorldSavePathKind.BedrockGdkPreviewUser:
			return 6;
		case PeWorldSavePathKind.Netease:
			return 40;
		case PeWorldSavePathKind.Netease2:
			return 41;
		case PeWorldSavePathKind.EducationUwp:
			return 50;
		case PeWorldSavePathKind.EducationUwpCloned:
			return 51;
		case PeWorldSavePathKind.Custom:
			return 100;
		default:
			return 55;
		}
	}
}
