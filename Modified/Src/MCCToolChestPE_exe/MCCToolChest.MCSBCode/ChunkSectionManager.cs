using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.PECode.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class ChunkSectionManager
{
	public Dictionary<int, ChunkSection> chunkSections;

	private Dictionary<string, BlockHandlerBedrockToJava> wqvSpbuLM16;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkSectionManager(Dictionary<string, BlockHandlerBedrockToJava> blockHandlerList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		chunkSections = new Dictionary<int, ChunkSection>();
		wqvSpbuLM16 = blockHandlerList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkSection GetSection(int cx, int cz, int ySection, byte[] rawChunkData)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkSection chunkSection = null;
		int hashCode = (cx + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + cz + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + ySection).GetHashCode();
		if (chunkSections.ContainsKey(hashCode))
		{
			chunkSection = chunkSections[hashCode];
		}
		else
		{
			chunkSection = BOxSpT6Djiv(rawChunkData);
			if (chunkSection != null)
			{
				chunkSections.Add(hashCode, chunkSection);
			}
		}
		return chunkSection;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkSection GetSection(int dimension, int cx, int cz, int ySection)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkSection chunkSection = null;
		int hashCode = (cx + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + cz + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + ySection).GetHashCode();
		if (chunkSections.ContainsKey(hashCode))
		{
			chunkSection = chunkSections[hashCode];
		}
		else if (MasterChunkList.worldChunks != null && MasterChunkList.worldChunks.NS3SWObVTQd().ContainsKey(dimension))
		{
			string key = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + (cx >> 5) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + (cz >> 5);
			if (MasterChunkList.worldChunks.NS3SWObVTQd()[dimension].ContainsKey(key))
			{
				string key2 = cx + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + cz;
				if (MasterChunkList.worldChunks.NS3SWObVTQd()[dimension][key].Chunks.ContainsKey(key2))
				{
					PEChunkData pEChunkData = MasterChunkList.worldChunks.NS3SWObVTQd()[dimension][key].Chunks[key2];
					if (pEChunkData.BlockSections.ContainsKey(ySection))
					{
						chunkSection = BOxSpT6Djiv(pEChunkData.BlockSections[ySection]);
						if (chunkSection != null)
						{
							chunkSections.Add(hashCode, chunkSection);
						}
					}
				}
			}
		}
		return chunkSection;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ChunkSection BOxSpT6Djiv(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkSection result = null;
		if (P_0 != null && (P_0[0] == 1 || P_0[0] == 8 || P_0.Length < 6145) && (P_0[0] == 1 || P_0[0] == 8))
		{
			result = zwBSpSE2O7b(P_0);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ChunkSection zwBSpSE2O7b(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = PEUtility.BlockStorageSection(P_0);
		TagNodeCompound tagNodeCompound = tagNodeList[0] as TagNodeCompound;
		int[] data = ((TagNodeIntArray)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)]).Data;
		BedrockPaletteConversionResults bedrockPaletteConversionResults = XuWSpGNtcr7(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] as TagNodeList);
		ChunkSection chunkSection = new ChunkSection();
		chunkSection.bedrockBlockStates = bedrockPaletteConversionResults.dataStates;
		chunkSection.blockIndexes = data;
		chunkSection.blockHandlers = bedrockPaletteConversionResults.blockHandlers;
		return chunkSection;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BedrockPaletteConversionResults XuWSpGNtcr7(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockState> list = new List<BlockState>();
		Dictionary<int, BlockHandlerDataBedrockToJava> dictionary = new Dictionary<int, BlockHandlerDataBedrockToJava>();
		BedrockPaletteConversionResults bedrockPaletteConversionResults = new BedrockPaletteConversionResults();
		bedrockPaletteConversionResults.dataStates = list;
		bedrockPaletteConversionResults.blockHandlers = dictionary;
		BedrockPaletteConversionResults result = bedrockPaletteConversionResults;
		for (int i = 0; i < P_0.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
			string name = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] as TagNodeString;
			BlockState blockState = null;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)))
			{
				short num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)] as TagNodeShort;
				blockState = BlockMaster.GetBedrockBlockState(name, num);
				blockState.data = num;
			}
			else
			{
				TagNodeCompound values = null;
				if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892)))
				{
					values = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892)] as TagNodeCompound;
				}
				blockState = BlockMaster.GetBedrockBlockState(name, values);
				blockState.useProperties = true;
			}
			if (blockState.masterBlock.blockStates != null && wqvSpbuLM16.ContainsKey(blockState.masterBlock.blockStates))
			{
				dictionary.Add(i, new BlockHandlerDataBedrockToJava(wqvSpbuLM16[blockState.masterBlock.blockStates]));
			}
			if (blockState.masterBlock.blockStates == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65470))
			{
				blockState.isDoor = true;
			}
			list.Add(blockState);
		}
		return result;
	}
}
