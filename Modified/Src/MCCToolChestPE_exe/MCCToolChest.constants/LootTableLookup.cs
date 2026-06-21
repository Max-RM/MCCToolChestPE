using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.constants;

public class LootTableLookup
{
	public static Dictionary<string, string> lootTableXRef;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ConvertLootTable(string inLootTable)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = inLootTable;
		int num = inLootTable.LastIndexOf('/');
		if (num > 0)
		{
			string key = inLootTable.Substring(num + 1);
			if (lootTableXRef.ContainsKey(key))
			{
				result = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7932) + lootTableXRef[key];
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LootTableLookup()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LootTableLookup()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		lootTableXRef = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7974),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8016)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8068),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8102)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8144),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8176)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8218),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8256)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8304),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8330)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8366),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8396)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8436),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8486)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8528),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8558)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8598),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8628)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8660),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8696)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8740),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8780)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8828),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8860)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8902),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8940)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(8988),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9030)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9082),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9124)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9176),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9216)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9266),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9308)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9360),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9406)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9462),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9502)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9552),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9588)
			}
		};
	}
}
