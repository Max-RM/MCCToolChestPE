using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.utils;
using MCPELevelDBI.workers;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class UpgradeBedrockSections
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNodeList ToBlockStateSections(TagNodeList sections)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		NibbleSetters nibbleSetters = new NibbleSetters();
		for (int i = 0; i < sections.Count; i++)
		{
			int[] array = new int[4096];
			TagNodeCompound tagNodeCompound = sections[i] as TagNodeCompound;
			TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] is TagNodeByteArray)
			{
				byte d = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
				byte[] array2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] as TagNodeByteArray;
				byte[] data = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeByteArray;
				Dictionary<string, Dictionary<short, BlockState>> dictionary = new Dictionary<string, Dictionary<short, BlockState>>();
				PaletteIndexWorker paletteIndexWorker = new PaletteIndexWorker();
				for (int j = 0; j < 4096; j++)
				{
					int id = array2[j];
					int num = nibbleSetters.TU17GetFast(data, j);
					BlockState bedrockBlockState = BlockMaster.GetBedrockBlockState(id, (short)num);
					int paletteIndex = paletteIndexWorker.GetPaletteIndex(dictionary, bedrockBlockState.name, bedrockBlockState.data);
					array[j] = paletteIndex;
				}
				tagNodeCompound2 = new TagNodeCompound();
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte(d);
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = new TagNodeByte(8);
				TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
				TagNodeCompound tagNodeCompound3 = new TagNodeCompound();
				tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = PEUtility.BuildNBTPalette(dictionary);
				tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(array);
				tagNodeList2.Add(tagNodeCompound3);
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] = tagNodeList2;
				tagNodeList.Add(tagNodeCompound2);
			}
			else
			{
				tagNodeList.Add(tagNodeCompound);
			}
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UpgradeBedrockSections()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
