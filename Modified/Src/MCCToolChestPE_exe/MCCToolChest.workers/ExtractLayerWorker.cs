using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class ExtractLayerWorker
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<ChunkYLayer> ExtractLayers(TagNodeList sections)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<ChunkYLayer> list = new List<ChunkYLayer>();
		NibbleSetters nibbleSetters = new NibbleSetters();
		for (int i = 0; i < 256; i++)
		{
			ChunkYLayer chunkYLayer = new ChunkYLayer();
			chunkYLayer.Layer = i;
			list.Add(chunkYLayer);
		}
		for (int j = 0; j < sections.Count; j++)
		{
			TagNodeCompound tagNodeCompound = sections[j] as TagNodeCompound;
			int num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
			int num2 = num * 16;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] is TagNodeByteArray)
			{
				TagNodeByteArray tagNodeByteArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] as TagNodeByteArray;
				TagNodeByteArray tagNodeByteArray2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeByteArray;
				byte[] data = tagNodeByteArray.Data;
				byte[] data2 = tagNodeByteArray2.Data;
				for (int k = 0; k < 16; k++)
				{
					for (int l = 0; l < 256; l++)
					{
						int num3 = k * 256 + l;
						list[num2 + k].Blocks[l].Id = data[num3];
						list[num2 + k].Blocks[l].Data = nibbleSetters.TU17GetFast(data2, num3);
					}
				}
			}
			else
			{
				if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)) || !(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] is TagNodeList))
				{
					continue;
				}
				TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] as TagNodeList;
				if (tagNodeList.Count <= 0)
				{
					continue;
				}
				TagNodeCompound tagNodeCompound2 = tagNodeList[0] as TagNodeCompound;
				TagNodeIntArray tagNodeIntArray = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] as TagNodeIntArray;
				int[] data3 = tagNodeIntArray.Data;
				TagNodeList paletteEntries = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] as TagNodeList;
				BlockState[] blockStatesFromPalette = PEUtility.GetBlockStatesFromPalette(paletteEntries);
				for (int m = 0; m < 16; m++)
				{
					for (int n = 0; n < 256; n++)
					{
						int num4 = m * 256 + n;
						int num5 = data3[num4];
						list[num2 + m].Blocks[n].Id = blockStatesFromPalette[num5].id.Value;
						list[num2 + m].Blocks[n].Data = blockStatesFromPalette[num5].data;
					}
				}
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ExtractLayerWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
