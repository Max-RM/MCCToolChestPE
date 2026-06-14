using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class SearchBlocks
{
	private SearchBlockParameter cMqSidM1aiT;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<string, List<BlockSearchResult>> Search(Block searchBlock, string region, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, List<BlockSearchResult>> dictionary = new Dictionary<string, List<BlockSearchResult>>();
		string[] regionFileNames = Constants.regionFileNames;
		foreach (string text in regionFileNames)
		{
			List<BlockSearchResult> value = RylSiCFMZJm(searchBlock, region, text, outFolderPath);
			dictionary.Add(text, value);
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SearchRegion(object threadContext)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		cMqSidM1aiT = threadContext as SearchBlockParameter;
		List<BlockSearchResult> result = null;
		try
		{
			result = RylSiCFMZJm(cMqSidM1aiT.SearchBlock, cMqSidM1aiT.Dimension, cMqSidM1aiT.Region, cMqSidM1aiT.OutFolderPath);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88682));
		}
		cMqSidM1aiT.Result = result;
		cMqSidM1aiT.Completed = true;
		cMqSidM1aiT.DoneEvent.Set();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<BlockSearchResult> RylSiCFMZJm(Block P_0, string P_1, string P_2, string P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new List<BlockSearchResult>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pXiSi7xwnI7(Block P_0, TagNodeCompound P_1, string P_2, string P_3, ChunkIndexEntry P_4, List<BlockSearchResult> P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		TagNodeCompound tagNodeCompound = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
		TagNodeByteArray tagNodeByteArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] as TagNodeByteArray;
		TagNodeByteArray tagNodeByteArray2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeByteArray;
		TagNodeByteArray tagNodeByteArray3 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70018)] as TagNodeByteArray;
		int num = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)];
		int num2 = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)];
		int num3 = ((num >= 0) ? (num * 16) : ((num + 1) * 16));
		int num4 = ((num2 >= 0) ? (num2 * 16) : ((num2 + 1) * 16));
		int num5 = ((tagNodeByteArray.Length == 65536) ? 16 : 8);
		for (int i = 0; i < num5; i++)
		{
			int num6 = ((i >= 8) ? 32768 : 0);
			int offset = num6 / 2;
			int num7 = ((i < 8) ? i : (i - 8));
			for (int j = 0; j < 16; j++)
			{
				int num8 = i * 16;
				for (int k = 0; k < 16; k++)
				{
					for (int l = 0; l < 16; l++)
					{
						int index = (j << 11) | (l << 7) | (k + (num7 << 4) + num6);
						byte b = tagNodeByteArray[index];
						int num9 = nibbleSetters.RegionGet(tagNodeByteArray2, j, k + (num7 << 4), l, offset);
						if (b == P_0.Id && (num9 == P_0.Data || P_0.Data == -1))
						{
							int light = nibbleSetters.RegionGet(tagNodeByteArray3, j, k + (num7 << 4), l, offset);
							int x = num3 + ((num >= 0) ? j : ((16 - j) * -1));
							int z = num4 + ((num2 >= 0) ? l : ((16 - l) * -1));
							BlockSearchResult blockSearchResult = new BlockSearchResult(b, num9, light, P_2, P_3, P_4, num, num2, x, num8, z);
							blockSearchResult.LocalX = j;
							blockSearchResult.LocalZ = l;
							P_5.Add(blockSearchResult);
							if (P_5.Count > 1500)
							{
								return;
							}
						}
					}
					num8++;
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void a4BSiAMLgHy(Block P_0, TU17ChunkData P_1, string P_2, string P_3, ChunkIndexEntry P_4, List<BlockSearchResult> P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		byte[] blocks = P_1.Blocks;
		byte[] blockData = P_1.BlockData;
		byte[] blockLight = P_1.BlockLight;
		int x = P_1.X;
		int z = P_1.Z;
		int num = ((x >= 0) ? (x * 16) : ((x + 1) * 16));
		int num2 = ((z >= 0) ? (z * 16) : ((z + 1) * 16));
		for (int i = 0; i < 256; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					int num3 = i * 256 + j * 16 + k;
					byte b = blocks[num3];
					int num4 = nibbleSetters.TU17GetFast(blockData, num3);
					if (b == P_0.Id && (num4 == P_0.Data || P_0.Data == -1))
					{
						int light = nibbleSetters.TU17GetFast(blockLight, num3);
						int x2 = num + ((x >= 0) ? j : ((16 - j) * -1));
						int z2 = num2 + ((z >= 0) ? k : ((16 - k) * -1));
						BlockSearchResult blockSearchResult = new BlockSearchResult(b, num4, light, P_2, P_3, P_4, x, z, x2, i, z2);
						blockSearchResult.LocalX = j;
						blockSearchResult.LocalZ = k;
						P_5.Add(blockSearchResult);
						if (P_5.Count > 1500)
						{
							return;
						}
					}
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchBlocks()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
