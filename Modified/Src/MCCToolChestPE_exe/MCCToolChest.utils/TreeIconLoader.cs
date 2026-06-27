using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MCCToolChest.utils;

public static class TreeIconLoader
{
	public const int IconMaps = 5;

	public const int IconStructures = 6;

	public const int IconTickingareas = 7;

	public const int IconPortals = 8;

	public const int IconCustomDimension = 9;

	private const int RequiredIconCount = 10;

	private static readonly Dictionary<string, int> IconIndexByFile = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
	{
		{ "tree_maps.png", IconMaps },
		{ "tree_structures.png", IconStructures },
		{ "tree_tickingareas.png", IconTickingareas },
		{ "tree_portals.png", IconPortals },
		{ "tree_custom_dimension.png", IconCustomDimension },
		{ "tree_structure_manager.png", IconStructures },
		{ "tree_tickingarea_manager.png", IconTickingareas }
	};

	public static void EnsureExtendedIconSlots(ImageList imageList)
	{
		if (imageList == null)
		{
			return;
		}
		while (imageList.Images.Count < RequiredIconCount)
		{
			imageList.Images.Add(new Bitmap(imageList.ImageSize.Width, imageList.ImageSize.Height));
		}
	}

	public static void ApplyCustomIcons(ImageList imageList)
	{
		if (imageList == null)
		{
			return;
		}
		EnsureExtendedIconSlots(imageList);
		string iconsFolder = GetIconsFolder();
		if (!Directory.Exists(iconsFolder))
		{
			return;
		}
		foreach (KeyValuePair<string, int> item in IconIndexByFile)
		{
			string path = Path.Combine(iconsFolder, item.Key);
			if (!File.Exists(path))
			{
				continue;
			}
			try
			{
				using Bitmap bitmap = new Bitmap(path);
				imageList.Images[item.Value] = new Bitmap(bitmap, imageList.ImageSize);
			}
			catch (Exception)
			{
			}
		}
	}

	public static string GetIconsFolder()
	{
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		return Path.Combine(baseDirectory, "support", "icons");
	}

	public static void EnsurePlaceholderIcons()
	{
		string iconsFolder = GetIconsFolder();
		Directory.CreateDirectory(iconsFolder);
		string[] array = new string[5]
		{
			"tree_maps.png",
			"tree_structures.png",
			"tree_tickingareas.png",
			"tree_portals.png",
			"tree_custom_dimension.png"
		};
		byte[] minimalPng = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg==");
		string[] array2 = array;
		foreach (string path in array2)
		{
			string text = Path.Combine(iconsFolder, path);
			if (!File.Exists(text))
			{
				File.WriteAllBytes(text, minimalPng);
			}
		}
	}
}
