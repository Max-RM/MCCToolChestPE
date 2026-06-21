using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class LogicWriteBiomeList
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteBiomeList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		List<int> list = BiomeLookup.bedrockId.Keys.ToList();
		list.Sort();
		foreach (int item in list)
		{
			Biome biome = BiomeLookup.bedrockId[item];
			string value = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64356), item, biome.Name);
			stringBuilder.AppendLine(value);
		}
		File.WriteAllText(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64376), stringBuilder.ToString());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LogicWriteBiomeList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
