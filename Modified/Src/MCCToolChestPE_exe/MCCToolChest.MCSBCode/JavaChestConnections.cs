using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.PECode.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class JavaChestConnections
{
	private ChestConnectioExtractnParameters gIESvX34Hcj;

	private static int w2YSvxMsiq4;

	private static int eXNSveyx0hI;

	private static int sVNSvMQyjpP;

	private static int ccASvUuohZW;

	private NibbleSetters FmYSvL2IG99;

	private static readonly object rx6SvgyWuFu;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateChestsList(object threadContext)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChestConnectioExtractnParameters chestConnectioExtractnParameters = threadContext as ChestConnectioExtractnParameters;
		Dictionary<int, MCCoordinate> dictionary = new Dictionary<int, MCCoordinate>();
		if (chestConnectioExtractnParameters == null)
		{
			return;
		}
		gIESvX34Hcj = chestConnectioExtractnParameters;
		foreach (PEChunkData value2 in chestConnectioExtractnParameters.PeRegion.Chunks.Values)
		{
			if (!value2.ChunkData.ContainsKey(49))
			{
				continue;
			}
			TagNodeList tagNodeList = PEUtility.ExtractTileEntities(value2.ChunkData[49]);
			for (int i = 0; i < tagNodeList.Count; i++)
			{
				TagNodeCompound tagNodeCompound = tagNodeList[i] as TagNodeCompound;
				if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && (TagNodeString)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15174))
				{
					int num = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)];
					int num2 = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)];
					int num3 = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)];
					int val = LOwSv2Zhgkc(num, num2, num3, value2);
					MCCoordinate value = new MCCoordinate(num, num2, num3, val);
					dictionary.Add(BuildKey(num, num2, num3), value);
				}
			}
		}
		chestConnectioExtractnParameters.Chests = dictionary;
		chestConnectioExtractnParameters.Done = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int LOwSv2Zhgkc(int P_0, int P_1, int P_2, PEChunkData P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		int num2 = NOqSvtQvb4y(P_0, 16);
		int num3 = NOqSvtQvb4y(P_2, 16);
		if (P_3.ChunkData.ContainsKey(48) && P_3.BlockSections.Count == 0)
		{
			int pos = num2 * 2048 + num3 * 128 + P_1 + 32768;
			byte[] data = P_3.ChunkData[48];
			return FmYSvL2IG99.TU17GetFast(data, pos);
		}
		return WpPSvy7G8bk(num2, P_1, num3, P_3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int WpPSvy7G8bk(int P_0, int P_1, int P_2, PEChunkData P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		int num = P_1 / 16;
		if (P_3.BlockSections.ContainsKey(num))
		{
			byte[] array = P_3.BlockSections[num];
			if (array[0] != 1 && array[0] != 8)
			{
				if (array.Length >= 6145)
				{
					byte[] data = array.Skip(4097).Take(2048).ToArray();
					int pos = P_0 * 256 + P_2 * 16 + (P_1 - num * 16);
					result = FmYSvL2IG99.TU17GetFast(data, pos);
				}
			}
			else if (array[0] == 1 || array[0] == 8)
			{
				TagNodeList tagNodeList = PEUtility.BlockStorageSection(array);
				TagNodeCompound tagNodeCompound = tagNodeList[0] as TagNodeCompound;
				List<BlockState> list = UdRSv0ND7kK(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] as TagNodeList);
				int[] data2 = ((TagNodeIntArray)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)]).Data;
				int num2 = (P_1 - num * 16) * 256 + P_2 * 16 + P_0;
				int index = data2[num2];
				result = list[index].data;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<BlockState> UdRSv0ND7kK(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockState> list = new List<BlockState>();
		for (int i = 0; i < P_0.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
			string name = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] as TagNodeString;
			short data = 0;
			if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19874)))
			{
				data = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)] as TagNodeShort;
			}
			BlockState blockState = new BlockState();
			blockState.name = name;
			blockState.data = data;
			BlockState item = blockState;
			list.Add(item);
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string eggSvBTpPcc(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return NOqSvtQvb4y(P_0, 16).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int NOqSvtQvb4y(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 % P_1 + P_1) % P_1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ProcessChest(int x, int y, int z, short chestDir, Dictionary<int, MCCoordinate> chests, Dictionary<int, string> chestConnections)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72928);
		lock (rx6SvgyWuFu)
		{
			return rlBSvauHZCL(x, y, z, chestDir, chests, chestConnections);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string rlBSvauHZCL(int P_0, int P_1, int P_2, short P_3, Dictionary<int, MCCoordinate> P_4, Dictionary<int, string> P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int key = BuildKey(P_0, P_1, P_2);
		if (P_5 != null && P_5.ContainsKey(key))
		{
			string result = P_5[key];
			P_5.Remove(key);
			return result;
		}
		if (P_4 != null)
		{
			try
			{
				int num = 0;
				if (P_3 == w2YSvxMsiq4 || P_3 == eXNSveyx0hI)
				{
					num = BuildKey(P_0 - 1, P_1, P_2);
					if (P_4.ContainsKey(num))
					{
						int val = P_4[num].val;
						if (P_3 == val)
						{
							P_4.Remove(num);
							P_4.Remove(key);
							P_5.Add(num, (P_3 == w2YSvxMsiq4) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65630) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65642));
							return (P_3 == w2YSvxMsiq4) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65642) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65630);
						}
					}
					num = BuildKey(P_0 + 1, P_1, P_2);
					if (P_4.ContainsKey(num))
					{
						int val2 = P_4[num].val;
						if (P_3 == val2)
						{
							P_4.Remove(num);
							P_4.Remove(key);
							P_5.Add(num, (P_3 == w2YSvxMsiq4) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65642) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65630));
							return (P_3 == w2YSvxMsiq4) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65630) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65642);
						}
					}
				}
				else if (P_3 == ccASvUuohZW || P_3 == sVNSvMQyjpP)
				{
					num = BuildKey(P_0, P_1, P_2 - 1);
					if (P_4.ContainsKey(num))
					{
						int val3 = P_4[num].val;
						if (P_3 == val3)
						{
							P_4.Remove(num);
							P_4.Remove(key);
							P_5.Add(num, (P_3 == ccASvUuohZW) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65642) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65630));
							return (P_3 == ccASvUuohZW) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65630) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65642);
						}
					}
					num = BuildKey(P_0, P_1, P_2 + 1);
					if (P_4.ContainsKey(num))
					{
						int val4 = P_4[num].val;
						if (P_3 == val4)
						{
							P_4.Remove(num);
							P_4.Remove(key);
							P_5.Add(num, (P_3 == ccASvUuohZW) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65630) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65642));
							return (P_3 == ccASvUuohZW) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65642) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65630);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72928);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int BuildKey(int x, int y, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (x + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + y + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + z).GetHashCode();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JavaChestConnections()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		FmYSvL2IG99 = new NibbleSetters();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static JavaChestConnections()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		w2YSvxMsiq4 = 2;
		eXNSveyx0hI = 3;
		sVNSvMQyjpP = 5;
		ccASvUuohZW = 4;
		rx6SvgyWuFu = new object();
	}
}
