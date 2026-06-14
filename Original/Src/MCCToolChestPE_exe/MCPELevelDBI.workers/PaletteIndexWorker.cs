using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using YBh7EaXMWmkFRJOX37M;

namespace MCPELevelDBI.workers;

public class PaletteIndexWorker
{
	private int lGmSptMA5rO;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPaletteIndex(Dictionary<string, Dictionary<short, BlockState>> palette, string name, short data)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = -1;
		if (palette.ContainsKey(name) && palette[name].ContainsKey(data))
		{
			num = palette[name][data].paletteIndex;
		}
		if (num == -1)
		{
			num = lGmSptMA5rO++;
			if (!palette.ContainsKey(name))
			{
				palette.Add(name, new Dictionary<short, BlockState>());
			}
			BlockState blockState = BlockMaster.GetBedrockBlockState(name, data).Copy(num);
			blockState.data = data;
			palette[name].Add(data, blockState);
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int JGcSpBeAOws(List<BlockState> P_0, string P_1, short P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].name == P_1 && P_0[i].data == P_2)
			{
				return i;
			}
		}
		BlockState bedrockBlockState = BlockMaster.GetBedrockBlockState(P_1, P_2);
		num = P_0.Count;
		P_0.Add(bedrockBlockState);
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PaletteIndexWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
