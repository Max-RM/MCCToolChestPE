using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class Constants
{
	public class RegionModifier
	{
		private int KuIS0F2pxEX;

		private int T36S0j4Zj4L;

		public int X
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return KuIS0F2pxEX;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				KuIS0F2pxEX = value;
			}
		}

		public int Z
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return T36S0j4Zj4L;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				T36S0j4Zj4L = value;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public RegionModifier()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}
	}

	public const int DOUBLE_TALL_PLANTS = 175;

	public const int INDEX_RECORD_LENGTH = 144;

	public const int INDEX_ENTRY_FILE_LENGTH_POSITION = 128;

	public const int INDEX_ENTRY_FILE_OFFSET_POSITION = 132;

	public static byte[] grfIndexEntry;

	public static byte[] entitiesSearchBytes;

	public static byte[] TileEntitiesSearchBytes;

	public static byte[] mapOptionsBytes;

	public static Dictionary<int, string> BEDROCK_ENTITY_BLOCKS;

	public static string PE_Villager_Attributes;

	public static string PE_Entity_Template;

	public static string PE_Painting_Template;

	public static string PE_ItemFrame_Template;

	public static Dictionary<int, string> peEntityDefaults;

	public static Dictionary<string, int> BEDROCK_ENTITY_BLOCKS_BY_NAME;

	public static string mapItemFrame;

	public static Dictionary<string, int> regionSizes;

	public static Dictionary<string, int> regionSizesExt;

	public static string[] dimensionFolderNames;

	public static string[] regionFileNames;

	public static Dictionary<string, string> dimensionNames;

	public static Dictionary<int, string> dimensionById;

	public static Dictionary<string, int> dimensionByName;

	public static List<string> scriptDimensionNames;

	public static Dictionary<string, int> scriptDimensionXref;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetDimensionFolderName(int dimensionId)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (dimensionId <= 2)
		{
			return dimensionFolderNames[dimensionId];
		}
		if (dimensionById.TryGetValue(dimensionId, out string folderName))
		{
			return folderName;
		}
		EnsureCustomDimensionRegistered(dimensionId);
		return dimensionById[dimensionId];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetDimensionDisplayName(int dimensionId)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (dimensionId <= 2)
		{
			return GetDimensionDisplayName(dimensionFolderNames[dimensionId]);
		}
		EnsureCustomDimensionRegistered(dimensionId);
		if (dimensionById.TryGetValue(dimensionId, out string treeKey) && dimensionNames.TryGetValue(treeKey, out string displayName))
		{
			return displayName;
		}
		return "dm" + dimensionId;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetDimensionDisplayName(string folderKey)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (folderKey != null && dimensionNames.TryGetValue(folderKey, out string displayName))
		{
			return displayName;
		}
		return folderKey;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EnsureCustomDimensionRegistered(int dimensionId)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (dimensionId <= 2 || dimensionById.ContainsKey(dimensionId))
		{
			return;
		}
		string treeKey = "pe_dim_" + dimensionId;
		string displayName = "dm" + dimensionId;
		dimensionById[dimensionId] = treeKey;
		dimensionByName[treeKey.ToLowerInvariant()] = dimensionId;
		dimensionNames[treeKey] = displayName;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RefreshWorldDimensions()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<string> customKeys = new List<string>();
		foreach (string key in dimensionNames.Keys)
		{
			if (key.StartsWith("pe_dim_", StringComparison.OrdinalIgnoreCase))
			{
				customKeys.Add(key);
			}
		}
		foreach (string key in customKeys)
		{
			dimensionNames.Remove(key);
			dimensionByName.Remove(key.ToLowerInvariant());
		}
		List<int> customIds = new List<int>();
		foreach (int key2 in dimensionById.Keys)
		{
			if (key2 >= 3)
			{
				customIds.Add(key2);
			}
		}
		foreach (int item in customIds)
		{
			dimensionById.Remove(item);
		}
		if (Working.PEDimensions == null)
		{
			return;
		}
		for (int i = 0; i < Working.PEDimensions.Count; i++)
		{
			if (i >= 3 && Working.PEDimensions[i].Region.Count == 0)
			{
				continue;
			}
			EnsureCustomDimensionRegistered(i);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<DimensionListItem> GetDimensionListItems()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RefreshWorldDimensions();
		List<DimensionListItem> list = new List<DimensionListItem>();
		List<int> list2 = new List<int>(dimensionById.Keys);
		list2.Sort();
		foreach (int item in list2)
		{
			if (item >= 3 && Working.PEDimensions != null && item < Working.PEDimensions.Count && Working.PEDimensions[item].Region.Count == 0)
			{
				continue;
			}
			list.Add(new DimensionListItem(item, GetDimensionDisplayName(item)));
		}
		return list;
	}

	public static void PopulateDimensionCombo(ComboBox comboBox, string selectedFolderKey = null)
	{
		if (comboBox == null)
		{
			return;
		}
		comboBox.DataSource = null;
		comboBox.Items.Clear();
		foreach (DimensionListItem dimensionListItem in GetDimensionListItems())
		{
			comboBox.Items.Add(dimensionListItem);
		}
		if (comboBox.Items.Count == 0)
		{
			return;
		}
		if (!string.IsNullOrWhiteSpace(selectedFolderKey))
		{
			for (int i = 0; i < comboBox.Items.Count; i++)
			{
				if (comboBox.Items[i] is DimensionListItem dimensionListItem2 && string.Equals(dimensionListItem2.FolderKey, selectedFolderKey, StringComparison.OrdinalIgnoreCase))
				{
					comboBox.SelectedIndex = i;
					return;
				}
			}
		}
		comboBox.SelectedIndex = 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RegisterCustomDimension(int dimensionId, string folderName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EnsureCustomDimensionRegistered(dimensionId);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetDimensionId(string folderKey)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (string.IsNullOrEmpty(folderKey))
		{
			return -1;
		}
		if (dimensionByName.TryGetValue(folderKey.ToLower(), out int dimensionId))
		{
			return dimensionId;
		}
		if (folderKey.StartsWith("pe_dim_", StringComparison.OrdinalIgnoreCase) && int.TryParse(folderKey.Substring(7), out dimensionId))
		{
			return dimensionId;
		}
		if (folderKey.Length > 2 && folderKey.StartsWith("dm", StringComparison.OrdinalIgnoreCase) && int.TryParse(folderKey.Substring(2), out dimensionId))
		{
			EnsureCustomDimensionRegistered(dimensionId);
			return dimensionId;
		}
		return -1;
	}

	internal static Dictionary<int, string> wwBS0AsRbLZ;

	internal static Dictionary<int, string> xpSS0dKndLy;

	internal static Dictionary<string, RegionModifier> RdHS0HX8ItF;

	public static Dictionary<string, string> MC_TEXT_CODES;

	public static Dictionary<string, string> conditionValues;

	public static Dictionary<string, string> replaceNodeTypeValues;

	public static Dictionary<string, string> variableDataTypes;

	public static Dictionary<string, string> variableListTypes;

	public static Dictionary<int, short> itemDamageValues;

	public static Dictionary<int, byte> InventoryMaxCount;

	public static Dictionary<int, Enchantment> enchantmentsJava;

	public static Dictionary<int, Enchantment> enchantments;

	public static List<List<string>> careers;

	public static Dictionary<string, int> professionId;

	public static Dictionary<int, string[]> professionNames;

	public static Dictionary<string, int> careerId;

	public static Dictionary<string, MobAge> ageGroup;

	public static Dictionary<string, VillagerBehavior> behaviorGroup;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Constants()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Constants()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		grfIndexEntry = new byte[144]
		{
			0, 114, 0, 101, 0, 113, 0, 117, 0, 105,
			0, 114, 0, 101, 0, 100, 0, 71, 0, 97,
			0, 109, 0, 101, 0, 82, 0, 117, 0, 108,
			0, 101, 0, 115, 0, 46, 0, 103, 0, 114,
			0, 102, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		};
		entitiesSearchBytes = new byte[11]
		{
			9, 0, 8, 69, 110, 116, 105, 116, 105, 101,
			115
		};
		TileEntitiesSearchBytes = new byte[15]
		{
			9, 0, 12, 84, 105, 108, 101, 69, 110, 116,
			105, 116, 105, 101, 115
		};
		mapOptionsBytes = new byte[12]
		{
			0, 10, 77, 97, 112, 79, 112, 116, 105, 111,
			110, 115
		};
		BEDROCK_ENTITY_BLOCKS = new Dictionary<int, string>
		{
			{
				23,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121752)
			},
			{
				25,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65826)
			},
			{
				26,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120686)
			},
			{
				29,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64530)
			},
			{
				33,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64530)
			},
			{
				52,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15682)
			},
			{
				54,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15174)
			},
			{
				61,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121302)
			},
			{
				62,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121302)
			},
			{
				63,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15604)
			},
			{
				68,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15604)
			},
			{
				84,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65840)
			},
			{
				116,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121044)
			},
			{
				117,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120746)
			},
			{
				118,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14806)
			},
			{
				119,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(159812)
			},
			{
				125,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15344)
			},
			{
				130,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15222)
			},
			{
				137,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65798)
			},
			{
				138,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120670)
			},
			{
				140,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64700)
			},
			{
				144,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(2564)
			},
			{
				146,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15174)
			},
			{
				149,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120798)
			},
			{
				151,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120944)
			},
			{
				154,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15292)
			},
			{
				176,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14496)
			},
			{
				177,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14496)
			},
			{
				188,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(159834)
			},
			{
				189,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(159880)
			},
			{
				199,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5366)
			},
			{
				209,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65878)
			},
			{
				218,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15464)
			},
			{
				412,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65902)
			},
			{
				449,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121986)
			},
			{
				451,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122004)
			},
			{
				453,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122032)
			},
			{
				458,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122048)
			},
			{
				461,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122064)
			},
			{
				464,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122076)
			}
		};
		PE_Villager_Attributes = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(159918);
		PE_Entity_Template = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(162134);
		PE_Painting_Template = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(168314);
		PE_ItemFrame_Template = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(170362);
		peEntityDefaults = new Dictionary<int, string>
		{
			{
				23,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(170902)
			},
			{
				25,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(171206)
			},
			{
				26,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(171474)
			},
			{
				29,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(171738)
			},
			{
				33,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(171738)
			},
			{
				52,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(172414)
			},
			{
				54,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(173598)
			},
			{
				61,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(173886)
			},
			{
				62,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(174354)
			},
			{
				63,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(174822)
			},
			{
				68,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(174822)
			},
			{
				84,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(175118)
			},
			{
				116,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(175362)
			},
			{
				117,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(175670)
			},
			{
				118,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(176154)
			},
			{
				119,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(176566)
			},
			{
				125,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(176818)
			},
			{
				130,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(177114)
			},
			{
				137,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(177422)
			},
			{
				138,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(178618)
			},
			{
				140,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(178978)
			},
			{
				144,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(179482)
			},
			{
				146,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(173598)
			},
			{
				149,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(179942)
			},
			{
				151,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(180274)
			},
			{
				154,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(180554)
			},
			{
				176,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(180938)
			},
			{
				177,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(180938)
			},
			{
				188,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(177422)
			},
			{
				189,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(177422)
			},
			{
				199,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(170362)
			},
			{
				209,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(181222)
			},
			{
				218,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(181706)
			},
			{
				412,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(182102)
			},
			{
				449,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(182454)
			},
			{
				451,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(182698)
			},
			{
				453,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(183238)
			},
			{
				458,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(183754)
			},
			{
				461,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(184094)
			},
			{
				464,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(184482)
			}
		};
		BEDROCK_ENTITY_BLOCKS_BY_NAME = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15400),
				23
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65826),
				25
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14546),
				26
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(184986),
				29
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64530),
				33
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15682),
				52
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15174),
				54
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121302),
				61
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(185014),
				62
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(185038),
				63
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(185066),
				68
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65840),
				84
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121044),
				116
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120746),
				117
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14806),
				118
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121238),
				119
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15344),
				125
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15222),
				130
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65798),
				137
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120670),
				138
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64700),
				140
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(2564),
				144
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(185086),
				146
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120798),
				149
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(185114),
				149
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(185156),
				150
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120908),
				151
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15292),
				154
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(185194),
				176
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(185226),
				177
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(159834),
				188
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(159880),
				189
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5366),
				199
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65878),
				209
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15464),
				218
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15604),
				63
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14496),
				176
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65902),
				412
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121986),
				449
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122004),
				451
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122032),
				453
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122048),
				458
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122064),
				461
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122076),
				464
			}
		};
		mapItemFrame = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(185250);
		regionSizes = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936),
				1024
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780),
				1024
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794),
				1024
			}
		};
		regionSizesExt = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936),
				1024
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780),
				1024
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794),
				1024
			}
		};
		dimensionFolderNames = new string[3]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794)
		};
		regionFileNames = new string[4]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22076),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21996),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22036),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21952)
		};
		dimensionNames = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28692)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28772)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28734)
			}
		};
		dimensionById = new Dictionary<int, string>
		{
			{
				0,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936)
			},
			{
				1,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780)
			},
			{
				2,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794)
			}
		};
		dimensionByName = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60336),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60350),
				2
			}
		};
		scriptDimensionNames = new List<string>
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186734),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186756),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186772)
		};
		scriptDimensionXref = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186734),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186756),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186772),
				2
			}
		};
		wwBS0AsRbLZ = new Dictionary<int, string>
		{
			{
				-1,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186788)
			},
			{
				0,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186822)
			},
			{
				1,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186850)
			},
			{
				2,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186878)
			},
			{
				3,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186906)
			},
			{
				4,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186934)
			},
			{
				5,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186962)
			},
			{
				6,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(186990)
			},
			{
				7,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187018)
			},
			{
				8,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187046)
			},
			{
				9,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187074)
			},
			{
				10,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187102)
			},
			{
				11,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187132)
			},
			{
				12,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187162)
			},
			{
				13,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187192)
			},
			{
				14,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187222)
			},
			{
				15,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187252)
			}
		};
		xpSS0dKndLy = new Dictionary<int, string>
		{
			{
				-1,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122616)
			},
			{
				1,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187282)
			},
			{
				2,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187296)
			},
			{
				3,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187316)
			},
			{
				4,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187330)
			},
			{
				5,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187362)
			},
			{
				6,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187382)
			},
			{
				7,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187414)
			},
			{
				8,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187446)
			},
			{
				9,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187470)
			},
			{
				10,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187486)
			},
			{
				11,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187514)
			},
			{
				12,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187538)
			},
			{
				13,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187572)
			},
			{
				14,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187606)
			},
			{
				15,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187634)
			},
			{
				16,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187656)
			},
			{
				17,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187684)
			},
			{
				18,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187700)
			},
			{
				19,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187720)
			},
			{
				20,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6818)
			},
			{
				21,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187736)
			},
			{
				22,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187764)
			},
			{
				23,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187788)
			},
			{
				25,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187812)
			},
			{
				29,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187836)
			},
			{
				30,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187866)
			}
		};
		RdHS0HX8ItF = new Dictionary<string, RegionModifier>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22076),
				new RegionModifier
				{
					X = 0,
					Z = 0
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21996),
				new RegionModifier
				{
					X = 0,
					Z = -1
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22036),
				new RegionModifier
				{
					X = -1,
					Z = 0
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21952),
				new RegionModifier
				{
					X = -1,
					Z = -1
				}
			}
		};
		MC_TEXT_CODES = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187900),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17572)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187914),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187928)
			}
		};
		conditionValues = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57288),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187934)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187948),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187970)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(187992),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188020)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188048),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188070)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188092),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188106)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188120),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188142)
			}
		};
		replaceNodeTypeValues = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9862),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188164)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99206),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188176)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9844),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188190)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99228),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188200)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99248),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188212)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99270),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188226)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30200),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188242)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9820),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188266)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30262),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188282)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30232),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188302)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30176),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15976)
			}
		};
		variableDataTypes = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9862),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188164)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99206),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188176)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9844),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188190)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99228),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188200)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99248),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188212)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99270),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188226)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9820),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188266)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30200),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188242)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30232),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188302)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30156),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188324)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30262),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188282)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30176),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15976)
			}
		};
		variableListTypes = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9862),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188164)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99206),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188176)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9844),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188190)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99228),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188200)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99248),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188212)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99270),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188226)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9820),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188266)
			}
		};
		itemDamageValues = new Dictionary<int, short>
		{
			{ 256, 250 },
			{ 257, 250 },
			{ 258, 250 },
			{ 259, 64 },
			{ 261, 384 },
			{ 267, 250 },
			{ 268, 59 },
			{ 269, 59 },
			{ 270, 59 },
			{ 271, 59 },
			{ 272, 131 },
			{ 273, 131 },
			{ 274, 131 },
			{ 275, 131 },
			{ 276, 1561 },
			{ 277, 1561 },
			{ 278, 1561 },
			{ 279, 1561 },
			{ 283, 32 },
			{ 284, 32 },
			{ 285, 32 },
			{ 286, 32 },
			{ 290, 59 },
			{ 291, 131 },
			{ 292, 250 },
			{ 293, 1561 },
			{ 294, 32 },
			{ 298, 34 },
			{ 299, 48 },
			{ 300, 46 },
			{ 301, 40 },
			{ 302, 68 },
			{ 303, 96 },
			{ 304, 92 },
			{ 305, 80 },
			{ 306, 136 },
			{ 307, 192 },
			{ 308, 184 },
			{ 309, 160 },
			{ 310, 272 },
			{ 311, 384 },
			{ 312, 368 },
			{ 313, 320 },
			{ 314, 68 },
			{ 315, 96 },
			{ 316, 92 },
			{ 317, 80 },
			{ 346, 64 },
			{ 359, 238 },
			{ 398, 25 }
		};
		InventoryMaxCount = new Dictionary<int, byte>
		{
			{ 58, 1 },
			{ 116, 1 },
			{ 256, 1 },
			{ 257, 1 },
			{ 258, 1 },
			{ 259, 1 },
			{ 261, 1 },
			{ 267, 1 },
			{ 268, 1 },
			{ 269, 1 },
			{ 270, 1 },
			{ 271, 1 },
			{ 272, 1 },
			{ 273, 1 },
			{ 274, 1 },
			{ 275, 1 },
			{ 276, 1 },
			{ 277, 1 },
			{ 278, 1 },
			{ 279, 1 },
			{ 282, 1 },
			{ 283, 1 },
			{ 284, 1 },
			{ 285, 1 },
			{ 286, 1 },
			{ 290, 1 },
			{ 291, 1 },
			{ 292, 1 },
			{ 293, 1 },
			{ 294, 1 },
			{ 298, 1 },
			{ 299, 1 },
			{ 300, 1 },
			{ 301, 1 },
			{ 302, 1 },
			{ 303, 1 },
			{ 304, 1 },
			{ 305, 1 },
			{ 306, 1 },
			{ 307, 1 },
			{ 308, 1 },
			{ 309, 1 },
			{ 310, 1 },
			{ 311, 1 },
			{ 312, 1 },
			{ 313, 1 },
			{ 314, 1 },
			{ 315, 1 },
			{ 316, 1 },
			{ 317, 1 },
			{ 323, 16 },
			{ 324, 1 },
			{ 325, 16 },
			{ 326, 1 },
			{ 327, 1 },
			{ 328, 1 },
			{ 329, 1 },
			{ 330, 1 },
			{ 332, 16 },
			{ 333, 1 },
			{ 335, 1 },
			{ 342, 1 },
			{ 343, 1 },
			{ 346, 1 },
			{ 354, 1 },
			{ 355, 1 },
			{ 358, 1 },
			{ 359, 1 },
			{ 386, 1 },
			{ 387, 1 },
			{ 395, 1 },
			{ 398, 1 },
			{ 500, 1 },
			{ 501, 1 },
			{ 502, 1 },
			{ 503, 1 },
			{ 504, 1 },
			{ 505, 1 },
			{ 506, 1 },
			{ 507, 1 },
			{ 508, 1 },
			{ 509, 1 },
			{ 510, 1 },
			{ 511, 1 }
		};
		enchantmentsJava = new Dictionary<int, Enchantment>
		{
			{
				0,
				new Enchantment(0, 0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188336), 4, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				1,
				new Enchantment(1, 1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188360), 4, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				2,
				new Enchantment(2, 2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188394), 4, new List<short> { 301, 305, 309, 313, 317 })
			},
			{
				3,
				new Enchantment(3, 3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188428), 4, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				4,
				new Enchantment(4, 4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188464), 4, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				5,
				new Enchantment(5, 6, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188510), 3, new List<short> { 298, 302, 306, 310, 314 })
			},
			{
				6,
				new Enchantment(6, 8, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188536), 1, new List<short> { 298, 302, 306, 310, 314 })
			},
			{
				7,
				new Enchantment(7, 5, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188566), 3, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				8,
				new Enchantment(8, 7, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188582), 3, new List<short> { 301, 305, 309, 313, 317 })
			},
			{
				9,
				new Enchantment(9, 25, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188612), 2, new List<short> { 301, 305, 309, 313, 317 })
			},
			{
				16,
				new Enchantment(16, 9, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188640), 5, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				17,
				new Enchantment(17, 10, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188662), 5, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				18,
				new Enchantment(18, 11, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188676), 5, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				19,
				new Enchantment(19, 12, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188716), 2, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				20,
				new Enchantment(20, 13, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188738), 2, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				21,
				new Enchantment(21, 14, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188764), 3, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				32,
				new Enchantment(32, 15, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188782), 5, new List<short>
				{
					269, 270, 271, 273, 274, 275, 256, 257, 258, 277,
					278, 279, 284, 285, 286
				})
			},
			{
				33,
				new Enchantment(33, 16, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188806), 1, new List<short>
				{
					269, 270, 271, 273, 274, 275, 256, 257, 258, 277,
					278, 279, 284, 285, 286
				})
			},
			{
				34,
				new Enchantment(34, 17, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188830), 3, new List<short>
				{
					269, 270, 271, 273, 274, 275, 256, 257, 258, 277,
					278, 279, 284, 285, 286
				})
			},
			{
				35,
				new Enchantment(35, 18, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188854), 3, new List<short>
				{
					269, 270, 271, 273, 274, 275, 256, 257, 258, 277,
					278, 279, 284, 285, 286
				})
			},
			{
				48,
				new Enchantment(48, 19, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188872), 5, new List<short> { 261 })
			},
			{
				49,
				new Enchantment(49, 20, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188886), 2, new List<short> { 261 })
			},
			{
				50,
				new Enchantment(50, 21, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188900), 1, new List<short> { 261 })
			},
			{
				51,
				new Enchantment(51, 22, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188914), 1, new List<short> { 261 })
			},
			{
				61,
				new Enchantment(61, 23, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188934), 3, new List<short> { 346 })
			},
			{
				62,
				new Enchantment(62, 24, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188968), 3, new List<short> { 346 })
			},
			{
				70,
				new Enchantment(70, 26, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188980), 1, new List<short>
				{
					259, 298, 299, 300, 301, 302, 303, 304, 305, 306,
					307, 308, 309, 310, 311, 312, 313, 314, 315, 316,
					317, 398, 442, 443
				})
			},
			{
				66,
				new Enchantment(66, 29, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188998), 5, new List<short>())
			},
			{
				67,
				new Enchantment(67, 30, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189018), 3, new List<short>())
			},
			{
				65,
				new Enchantment(65, 31, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189036), 3, new List<short>())
			},
			{
				68,
				new Enchantment(68, 32, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189054), 1, new List<short>())
			},
			{
				1004,
				new Enchantment(1004, 33, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189078), 1, new List<short>())
			},
			{
				1005,
				new Enchantment(1005, 34, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189100), 4, new List<short>())
			},
			{
				1006,
				new Enchantment(1006, 35, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189120), 3, new List<short>())
			},
			{
				1007,
				new Enchantment(1007, 36, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189148), 3, new List<short>())
			}
		};
		enchantments = new Dictionary<int, Enchantment>
		{
			{
				0,
				new Enchantment(0, 0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188336), 4, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				1,
				new Enchantment(1, 1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188360), 4, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				2,
				new Enchantment(2, 2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188394), 4, new List<short> { 301, 305, 309, 313, 317 })
			},
			{
				3,
				new Enchantment(3, 3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188428), 4, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				4,
				new Enchantment(4, 4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188464), 4, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				6,
				new Enchantment(5, 6, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188510), 3, new List<short> { 298, 302, 306, 310, 314 })
			},
			{
				8,
				new Enchantment(6, 8, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188536), 1, new List<short> { 298, 302, 306, 310, 314 })
			},
			{
				5,
				new Enchantment(7, 5, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188566), 3, new List<short>
				{
					298, 299, 300, 301, 302, 303, 304, 305, 306, 307,
					308, 309, 310, 311, 312, 313, 314, 315, 316, 317
				})
			},
			{
				7,
				new Enchantment(8, 7, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188582), 3, new List<short> { 301, 305, 309, 313, 317 })
			},
			{
				25,
				new Enchantment(9, 25, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188612), 2, new List<short> { 301, 305, 309, 313, 317 })
			},
			{
				9,
				new Enchantment(16, 9, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188640), 5, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				10,
				new Enchantment(17, 10, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188662), 5, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				11,
				new Enchantment(18, 11, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188676), 5, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				12,
				new Enchantment(19, 12, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188716), 2, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				13,
				new Enchantment(20, 13, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188738), 2, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				14,
				new Enchantment(21, 14, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188764), 3, new List<short> { 268, 272, 267, 276, 283 })
			},
			{
				15,
				new Enchantment(32, 15, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188782), 5, new List<short>
				{
					269, 270, 271, 273, 274, 275, 256, 257, 258, 277,
					278, 279, 284, 285, 286
				})
			},
			{
				16,
				new Enchantment(33, 16, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188806), 1, new List<short>
				{
					269, 270, 271, 273, 274, 275, 256, 257, 258, 277,
					278, 279, 284, 285, 286
				})
			},
			{
				17,
				new Enchantment(34, 17, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188830), 3, new List<short>
				{
					269, 270, 271, 273, 274, 275, 256, 257, 258, 277,
					278, 279, 284, 285, 286
				})
			},
			{
				18,
				new Enchantment(35, 18, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188854), 3, new List<short>
				{
					269, 270, 271, 273, 274, 275, 256, 257, 258, 277,
					278, 279, 284, 285, 286
				})
			},
			{
				19,
				new Enchantment(48, 19, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188872), 5, new List<short> { 261 })
			},
			{
				20,
				new Enchantment(49, 20, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188886), 2, new List<short> { 261 })
			},
			{
				21,
				new Enchantment(50, 21, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188900), 1, new List<short> { 261 })
			},
			{
				22,
				new Enchantment(51, 22, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188914), 1, new List<short> { 261 })
			},
			{
				23,
				new Enchantment(61, 23, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188934), 3, new List<short> { 346 })
			},
			{
				24,
				new Enchantment(62, 24, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188968), 3, new List<short> { 346 })
			},
			{
				26,
				new Enchantment(70, 26, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188980), 1, new List<short>
				{
					259, 298, 299, 300, 301, 302, 303, 304, 305, 306,
					307, 308, 309, 310, 311, 312, 313, 314, 315, 316,
					317, 398, 442, 443
				})
			},
			{
				29,
				new Enchantment(66, 29, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(188998), 5, new List<short>())
			},
			{
				30,
				new Enchantment(67, 30, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189018), 3, new List<short>())
			},
			{
				31,
				new Enchantment(65, 31, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189036), 3, new List<short>())
			},
			{
				32,
				new Enchantment(68, 32, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189054), 1, new List<short>())
			},
			{
				33,
				new Enchantment(1004, 33, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189078), 1, new List<short>())
			},
			{
				34,
				new Enchantment(1005, 34, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189100), 4, new List<short>())
			},
			{
				35,
				new Enchantment(1006, 35, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189120), 3, new List<short>())
			},
			{
				36,
				new Enchantment(1007, 36, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189148), 3, new List<short>())
			}
		};
		careers = new List<List<string>>
		{
			new List<string>
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7820),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189172),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189194),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189214)
			},
			new List<string>
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7836),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189234)
			},
			new List<string> { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189262) },
			new List<string>
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189278),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189296),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189324)
			},
			new List<string>
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7898),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189348)
			},
			new List<string> { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7916) }
		};
		professionId = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189378),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189396),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189420),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189442),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189464),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189488),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189518),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189536),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189556),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189584),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189608),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189628),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189660),
				5
			}
		};
		professionNames = new Dictionary<int, string[]>
		{
			{
				0,
				new string[4]
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189378),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189396),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189420),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189442)
				}
			},
			{
				1,
				new string[2]
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189464),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189488)
				}
			},
			{
				2,
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189518) }
			},
			{
				3,
				new string[3]
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189536),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189556),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189584)
				}
			},
			{
				4,
				new string[2]
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189608),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189628)
				}
			},
			{
				5,
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189660) }
			}
		};
		careerId = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189378),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189396),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189420),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189442),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189464),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189488),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189518),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189536),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189556),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189584),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189608),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189628),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189660),
				0
			}
		};
		ageGroup = new Dictionary<string, MobAge>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18986),
				MobAge.Baby
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19016),
				MobAge.Adult
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19032),
				MobAge.Adult
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19000),
				MobAge.Baby
			}
		};
		behaviorGroup = new Dictionary<string, VillagerBehavior>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19046),
				VillagerBehavior.Peasant
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19084),
				VillagerBehavior.NonPeasant
			}
		};
	}
}
