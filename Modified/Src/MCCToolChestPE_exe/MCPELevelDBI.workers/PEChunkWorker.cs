using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.utils;
using OAxWrWumnobfHyEL9yr;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCPELevelDBI.workers;

public class PEChunkWorker
{
	private enum GjMFNPjotuYOdBwXIM5
	{

	}

	private GjMFNPjotuYOdBwXIM5 nyUSpJGAeGs;

	private LevelDBWorker P0rSpuDn2Xr;

	private IntPtr GcMSposZkQC;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEChunkWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEChunkWorker(IntPtr batch)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		nyUSpJGAeGs = (GjMFNPjotuYOdBwXIM5)1;
		GcMSposZkQC = batch;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteModifiedChunk(int dimension, TagNodeCompound aChunk, int worldHeight, LevelDBWorker dbWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P0rSpuDn2Xr = dbWorker;
		new NibbleSetters();
		TagNodeCompound tagNodeCompound = aChunk[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
		int num = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)];
		int num2 = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)];
		TagNodeByteArray tagNodeByteArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992)] as TagNodeByteArray;
		TagNodeIntArray tagNodeIntArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65008)] as TagNodeIntArray;
		WwpSp6ucibl(dimension, num, num2);
		fqWSpYgAHpd(dimension, num, num2, tagNodeByteArray, tagNodeIntArray);
		TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)] as TagNodeList;
		eusSp3sB3aM(dimension, num, num2, tagNodeList);
		TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)] as TagNodeList;
		vUvSp1OSdik(dimension, num, num2, tagNodeList2);
		TagNodeList tagNodeList3 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)] as TagNodeList;
		deNSprgGP3y(dimension, num, num2, tagNodeList3);
		TagNodeByte tagNodeByte = new TagNodeByte(15);
		if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)))
		{
			tagNodeByte = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] as TagNodeByte;
		}
		bijSpESxnvw(dimension, num, num2, tagNodeByte);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fqWSpYgAHpd(int P_0, int P_1, int P_2, byte[] P_3, int[] P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v(false);
		byte[] array = new byte[256];
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num = (j << 4) | i;
				int num2 = (j << 4) | i;
				array[num2] = P_3[num];
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int k = 0; k < 256; k++)
		{
			nJVJiCuZKORGPYB1Y4v.CyBSRMDUOvV((short)P_4[k], memoryStream);
		}
		memoryStream.Write(array, 0, array.Length);
		byte[] array2 = PEUtility.BuildChunkKey(P_0, P_1, P_2, 45);
		kA2SpDvoIb5(array2, memoryStream.ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eusSp3sB3aM(int P_0, int P_1, int P_2, TagNodeList P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < P_3.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = P_3[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		if (memoryStream.Length > 0)
		{
			byte[] array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 49);
			kA2SpDvoIb5(array, memoryStream.ToArray());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vUvSp1OSdik(int P_0, int P_1, int P_2, TagNodeList P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < P_3.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = P_3[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		if (memoryStream.Length > 0)
		{
			byte[] array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 50);
			kA2SpDvoIb5(array, memoryStream.ToArray());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bijSpESxnvw(int P_0, int P_1, int P_2, byte P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[1] { P_3 };
		byte[] array2 = PEUtility.BuildChunkKey(P_0, P_1, P_2, 118);
		kA2SpDvoIb5(array2, array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deNSprgGP3y(int P_0, int P_1, int P_2, TagNodeList P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<int, TagNodeCompound> dictionary = new Dictionary<int, TagNodeCompound>();
		int num = 0;
		for (int i = 0; i < P_3.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_3[i] as TagNodeCompound;
			byte b = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
			dictionary.Add(b, tagNodeCompound);
			if (b > num)
			{
				num = b;
			}
		}
		for (byte b2 = 0; b2 <= num; b2++)
		{
			byte[] array = null;
			if (dictionary.ContainsKey(b2))
			{
				TagNodeCompound tagNodeCompound2 = dictionary[b2];
				array = ((!tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788))) ? BuildBlockStateChunk(tagNodeCompound2) : RpVSp5u0fYP(tagNodeCompound2));
			}
			if (array != null && array.Length > 0)
			{
				byte[] array2 = PEUtility.BuildChunkKey(P_0, P_1, P_2, 47, b2);
				kA2SpDvoIb5(array2, array);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] RpVSp5u0fYP(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		_ = (int)(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte);
		byte[] array = new byte[4096];
		byte[] array2 = new byte[2048];
		byte[] array3 = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] as TagNodeByteArray;
		byte[] data = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeByteArray;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					int num = i * 256 + j * 16 + k;
					int num2 = k * 256 + j * 16 + i;
					byte b = array3[num2];
					int val = nibbleSetters.TU17GetFast(data, num2);
					array[num] = b;
					nibbleSetters.TU17SetFast(array2, num, val);
				}
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.WriteByte(0);
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Write(array2, 0, array2.Length);
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] BuildBlockStateChunk(TagNodeCompound node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockStateLayer[] array = new BlockStateLayer[2];
		if (node.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)) && node[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] is TagNodeList)
		{
			TagNodeList tagNodeList = node[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] as TagNodeList;
			int count = tagNodeList.Count;
			for (int i = 0; i < count; i++)
			{
				TagNodeCompound tagNodeCompound = tagNodeList[i] as TagNodeCompound;
				int count2 = ((TagNodeList)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)]).Count;
				int num = PEUtility.PaletteBitsPerBlock(count2);
				int num2 = (int)Math.Floor((decimal)(32 / num));
				int num3 = (int)Math.Ceiling(4096.0 / (double)num2);
				int num4 = (1 << num) - 1;
				int[] data = ((TagNodeIntArray)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)]).Data;
				int[] array2 = new int[4096];
				for (int j = 0; j < 16; j++)
				{
					for (int k = 0; k < 16; k++)
					{
						for (int l = 0; l < 16; l++)
						{
							int num5 = j * 256 + k * 16 + l;
							int num6 = l * 256 + k * 16 + j;
							int num7 = data[num6];
							array2[num5] = num7;
						}
					}
				}
				MemoryStream memoryStream = new MemoryStream();
				int num8 = 0;
				for (int m = 0; m < num3; m++)
				{
					uint num9 = 0u;
					List<int> list = new List<int>();
					for (int n = 0; n < num2; n++)
					{
						if (num8 >= 4096)
						{
							break;
						}
						list.Add(array2[num8]);
						num8++;
					}
					for (int num10 = list.Count - 1; num10 >= 0; num10--)
					{
						num9 <<= num;
						int num11 = list[num10];
						num9 |= (uint)(num11 & num4);
					}
					byte[] bytes = BitConverter.GetBytes(num9);
					memoryStream.Write(bytes, 0, bytes.Length);
				}
				BlockStateLayer blockStateLayer = new BlockStateLayer();
				blockStateLayer.bitsPerBlock = num;
				blockStateLayer.blocks = memoryStream.ToArray();
				blockStateLayer.palette = (TagNodeList)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)];
				array[i] = blockStateLayer;
			}
			MemoryStream memoryStream2 = new MemoryStream();
			memoryStream2.WriteByte(8);
			memoryStream2.WriteByte((byte)count);
			memoryStream2.WriteByte((byte)(array[0].bitsPerBlock << 1));
			memoryStream2.Write(array[0].blocks, 0, array[0].blocks.Length);
			PEUtility.WritePaletteEntries(memoryStream2, array[0].palette);
			if (count == 2)
			{
				memoryStream2.WriteByte((byte)(array[1].bitsPerBlock << 1));
				memoryStream2.Write(array[1].blocks, 0, array[1].blocks.Length);
				PEUtility.WritePaletteEntries(memoryStream2, array[1].palette);
			}
			return memoryStream2.ToArray();
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WwpSp6ucibl(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 48);
		LCkSpcUjo6F(array);
		array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 49);
		LCkSpcUjo6F(array);
		array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 50);
		LCkSpcUjo6F(array);
		for (byte b = 0; b < 16; b++)
		{
			array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 47, b);
			LCkSpcUjo6F(array);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] i3gSpNEVrb2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new byte[10241];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kA2SpDvoIb5(byte[] P_0, byte[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (nyUSpJGAeGs == (GjMFNPjotuYOdBwXIM5)0)
		{
			P0rSpuDn2Xr.Put(P_0, P_1);
		}
		else
		{
			P0rSpuDn2Xr.WriteBatchPut(GcMSposZkQC, P_0, P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LCkSpcUjo6F(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P0rSpuDn2Xr.Delete(P_0);
	}
}
