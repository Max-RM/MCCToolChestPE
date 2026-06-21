using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCPELevelDBI.workers;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode.Workers;

public class BedrockChestConnections
{
	private int jITSvsedqcn;

	private int gc6SvqDT38Q;

	private int Ab6SvKAT2AN;

	private int yA3Svhl9edF;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessChests(int dimension, List<ConversionChest> list, LevelDBWorker dbWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			while (list.Count > 0)
			{
				MCCoordinate coord = list[0].Coord;
				MCCoordinate mCCoordinate = list[0].link;
				if (mCCoordinate == null)
				{
					mCCoordinate = gUtSv4CqErx(list, coord);
				}
				if (mCCoordinate != null)
				{
					niGSvpUilLQ(dimension, coord, mCCoordinate, dbWorker);
					hfQSvwSqkOC(list, mCCoordinate);
				}
				list.Remove(list[0]);
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hfQSvwSqkOC(List<ConversionChest> P_0, MCCoordinate P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = -1;
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].Coord.x == P_1.x && P_0[i].Coord.y == P_1.y && P_0[i].Coord.z == P_1.z)
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			P_0.Remove(P_0[num]);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MCCoordinate gUtSv4CqErx(List<ConversionChest> P_0, MCCoordinate P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MCCoordinate result = null;
		if (P_1.val == jITSvsedqcn || P_1.val == gc6SvqDT38Q)
		{
			for (int i = 0; i < P_0.Count; i++)
			{
				int x = P_1.x;
				if ((x - 1 == P_0[i].Coord.x || x + 1 == P_0[i].Coord.x) && P_1.y == P_0[i].Coord.y && P_1.z == P_0[i].Coord.z && P_1.val == P_0[i].Coord.val)
				{
					result = P_0[i].Coord;
					break;
				}
			}
		}
		else if (P_1.val == yA3Svhl9edF || P_1.val == Ab6SvKAT2AN)
		{
			for (int j = 0; j < P_0.Count; j++)
			{
				int z = P_1.z;
				if ((z - 1 == P_0[j].Coord.z || z + 1 == P_0[j].Coord.z) && P_1.y == P_0[j].Coord.y && P_1.x == P_0[j].Coord.x && P_1.val == P_0[j].Coord.val)
				{
					result = P_0[j].Coord;
					break;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int QZdSvVGv3xX(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0 >> 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] TQNSvWXdqKO(int P_0, MCCoordinate P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return PEUtility.BuildChunkKey(P_0, QZdSvVGv3xX(P_1.x), QZdSvVGv3xX(P_1.z), 49);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void niGSvpUilLQ(int P_0, MCCoordinate P_1, MCCoordinate P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = TQNSvWXdqKO(P_0, P_1);
		byte[] array2 = TQNSvWXdqKO(P_0, P_2);
		byte[] blockEntity = P_3.Get(array);
		TagNodeList tagNodeList = PEUtility.ExtractTileEntities(blockEntity);
		TagNodeList tagNodeList2 = tagNodeList;
		if (array != array2)
		{
			blockEntity = P_3.Get(array2);
			tagNodeList2 = PEUtility.ExtractTileEntities(blockEntity);
		}
		TagNodeCompound tagNodeCompound = mbiSvZi50AE(P_1, tagNodeList);
		TagNodeCompound tagNodeCompound2 = mbiSvZi50AE(P_2, tagNodeList2);
		if (tagNodeCompound != null && tagNodeCompound2 != null)
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72880)] = new TagNodeByte(1);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72900)] = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)].Copy();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72914)] = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)].Copy();
			O5vSviGI3GM(array, tagNodeList, P_3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound mbiSvZi50AE(MCCoordinate P_0, TagNodeList P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		for (int i = 0; i < P_1.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_1[i] as TagNodeCompound;
			if (IXbSvfDfMPv(P_0, tagNodeCompound))
			{
				result = tagNodeCompound;
				break;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IXbSvfDfMPv(MCCoordinate P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] as TagNodeInt;
		int num2 = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] as TagNodeInt;
		int num3 = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] as TagNodeInt;
		if (P_0.x == num && P_0.y == num2)
		{
			return P_0.z == num3;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void O5vSviGI3GM(byte[] P_0, TagNodeList P_1, LevelDBWorker P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < P_1.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = P_1[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		if (memoryStream.Length > 0)
		{
			P_2.Put(P_0, memoryStream.ToArray());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BedrockChestConnections()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		jITSvsedqcn = 2;
		gc6SvqDT38Q = 3;
		Ab6SvKAT2AN = 5;
		yA3Svhl9edF = 4;
	}
}
