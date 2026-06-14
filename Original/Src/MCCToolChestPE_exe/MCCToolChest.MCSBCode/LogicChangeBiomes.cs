using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using kRXIm9jhW3jn6OgdBkT;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.utils;
using MCPELevelDBI.workers;
using OAxWrWumnobfHyEL9yr;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class LogicChangeBiomes
{
	private static Color[][] hAjzVZSaGe;

	private int QXdzWDZPYv;

	private static int[] MBSzpwtOM0;

	private byte[] Xi2zZCuGtn;

	private byte[] mtLzfbZXeg;

	private int QbkzixtVwJ;

	private byte gYczs2kAHe;

	public static int[] TransparentBlocks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return MBSzpwtOM0;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			MBSzpwtOM0 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessRegions()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = PEUtility.GetPEDimension(Constants.dimensionFolderNames[0]);
		LevelDBWorker levelDBWorker = new LevelDBWorker();
		levelDBWorker.OpenDB(Path.Combine(Working.T92StMGt1p4(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
		foreach (PERegion value in pEDimension.Region.Values)
		{
			ProcessRegion(value, levelDBWorker);
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessRegion(PERegion peRegion, LevelDBWorker dbWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < 256; i++)
		{
			Xi2zZCuGtn[i] = byte.MaxValue;
		}
		for (int j = 0; j < 256; j++)
		{
			mtLzfbZXeg[j] = 0;
		}
		for (int k = 0; k < 32; k++)
		{
			for (int l = 0; l < 32; l++)
			{
				uolzTwLfDg(peRegion, lxe7hMuSirBXGUQugsD.QdsSP76hcgY(k, peRegion.RX), lxe7hMuSirBXGUQugsD.QdsSP76hcgY(l, peRegion.RZ), dbWorker);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uolzTwLfDg(PERegion P_0, int P_1, int P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] xi2zZCuGtn = Xi2zZCuGtn;
		byte[] array = mtLzfbZXeg;
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_1, P_0.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_2, P_0.RZ);
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		if (P_0.Chunks[num3] != 1)
		{
			return;
		}
		byte[] key = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 45);
		byte[] array2 = P_3.ReadDbValue(key);
		if (array2 != null)
		{
			int num4 = 0;
			for (int i = 0; i < 512; i += 2)
			{
				xi2zZCuGtn[num4++] = array2[i];
			}
			array = array2.Skip(512).Take(256).ToArray();
		}
		key = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 47, 0);
		List<byte[]> list = new List<byte[]>();
		bool flag = false;
		for (byte b = 0; b < 16; b++)
		{
			key[key.Length - 1] = b;
			byte[] array3 = P_3.ReadDbValue(key);
			if (array3 != null)
			{
				flag = true;
				list.Add(array3);
			}
		}
		if (flag)
		{
			if (eqazSrFVgX(list, array, P_0, xi2zZCuGtn, P_1, P_2))
			{
				key = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 45);
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(array2, 0, 512);
				memoryStream.Write(array, 0, 256);
				P_3.Put(key, memoryStream.ToArray());
			}
		}
		else
		{
			key = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 48);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool eqazSrFVgX(List<byte[]> P_0, byte[] P_1, PERegion P_2, byte[] P_3, int P_4, int P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		int num = 0;
		NibbleSetters nibbleSetters = new NibbleSetters();
		byte[] array = null;
		byte[] array2 = null;
		Dictionary<int, iD4UxTj3qtoFpKTXiYf> dictionary = new Dictionary<int, iD4UxTj3qtoFpKTXiYf>();
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num2 = P_3[j * 16 + i];
				byte b = 0;
				int num3 = 0;
				do
				{
					array = null;
					array2 = null;
					b = 0;
					num = num2 / 16;
					if (num < P_0.Count)
					{
						if (!dictionary.ContainsKey(num))
						{
							dictionary.Add(num, SNlzGCOiHe(P_0[num], (byte)num));
						}
						array = dictionary[num].Blocks;
						array2 = dictionary[num].Data;
						if (array == null || array.Length < 4096 || array2 == null || array2.Length < 2048)
						{
							return result;
						}
						num3 = i * 256 + j * 16 + (num2 - num * 16);
						b = array[num3];
					}
					num2--;
				}
				while (num2 >= 0 && MBSzpwtOM0.Contains(b));
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (array2 != null && array2.Length >= 2048)
				{
					nibbleSetters.TU17GetFast(array2, num3);
				}
				int num4 = j * 16 + i;
				if (b == QbkzixtVwJ)
				{
					P_1[num4] = gYczs2kAHe;
					result = true;
					continue;
				}
				byte b2 = P_1[num4];
				switch (b)
				{
				case 12:
				case 24:
					b2 = 16;
					P_1[num4] = b2;
					result = true;
					break;
				case 13:
					b2 = 162;
					P_1[num4] = b2;
					result = true;
					break;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private iD4UxTj3qtoFpKTXiYf SNlzGCOiHe(byte[] P_0, byte P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		iD4UxTj3qtoFpKTXiYf iD4UxTj3qtoFpKTXiYf2 = new iD4UxTj3qtoFpKTXiYf();
		if (P_0[0] != 1 && P_0[0] != 8)
		{
			iD4UxTj3qtoFpKTXiYf2.Blocks = P_0.Skip(1).Take(4096).ToArray();
			iD4UxTj3qtoFpKTXiYf2.Data = P_0.Skip(4097).Take(2048).ToArray();
			if (P_0.Length > 6145)
			{
				iD4UxTj3qtoFpKTXiYf2.SkyLight = P_0.Skip(6145).Take(2048).ToArray();
				iD4UxTj3qtoFpKTXiYf2.BlockLight = P_0.Skip(8193).Take(2048).ToArray();
			}
			else
			{
				iD4UxTj3qtoFpKTXiYf2.SkyLight = new byte[2048];
				iD4UxTj3qtoFpKTXiYf2.BlockLight = new byte[2048];
			}
		}
		else
		{
			iD4UxTj3qtoFpKTXiYf2 = tl8zvrkt4o(P_0, P_1);
		}
		return iD4UxTj3qtoFpKTXiYf2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Dqnzb3c91Z(iD4UxTj3qtoFpKTXiYf P_0, PERegion P_1, byte[] P_2, int P_3, int P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		byte[] array = P_0.Blocks;
		byte[] array2 = P_0.Data;
		int num = ((P_3 >= 0) ? (P_3 * 16) : ((P_3 + 1) * 16));
		int num2 = ((P_4 >= 0) ? (P_4 * 16) : ((P_4 + 1) * 16));
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num3 = P_2[j * 16 + i];
				if (num3 > 127)
				{
					num3 = 127;
				}
				byte b = 0;
				int num4 = 0;
				do
				{
					num4 = i * 2048 + j * 128 + num3;
					b = array[num4];
					num3--;
				}
				while (num3 >= 0 && MBSzpwtOM0.Contains(b));
				if (num3 < 0)
				{
					num3 = 0;
				}
				int num5 = 0;
				if (array2 != null && array2.Length > 0)
				{
					num5 = nibbleSetters.TU17GetFast(array2, num4);
				}
				_ = hAjzVZSaGe[b][num5];
				int num6 = num + ((P_3 >= 0) ? i : ((16 - i) * -1));
				int num7 = num2 + ((P_4 >= 0) ? j : ((16 - j) * -1));
				if (num6 < 0)
				{
					num6 = QXdzWDZPYv + num6;
				}
				if (num7 < 0)
				{
					num7 = QXdzWDZPYv + num7;
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap MapJavaChunk(int dimension, int chunkX, int chunkZ, LevelDBWorker dbWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = null;
		byte[] array2 = null;
		Bitmap bitmap = new Bitmap(16, 16);
		NibbleSetters nibbleSetters = new NibbleSetters();
		byte[] xi2zZCuGtn = Xi2zZCuGtn;
		byte[] key = PEUtility.BuildChunkKey(dimension, chunkX, chunkZ, 45);
		byte[] array3 = dbWorker.ReadDbValue(key);
		if (array3 != null)
		{
			int num = 0;
			for (int i = 0; i < 512; i += 2)
			{
				xi2zZCuGtn[num++] = array3[i];
			}
		}
		key = PEUtility.BuildChunkKey(dimension, chunkX, chunkZ, 47, 0);
		List<byte[]> list = new List<byte[]>();
		bool flag = false;
		for (byte b = 0; b < 16; b++)
		{
			key[key.Length - 1] = b;
			byte[] array4 = dbWorker.ReadDbValue(key);
			if (array4 != null)
			{
				flag = true;
				list.Add(array4);
			}
		}
		if (flag)
		{
			Dictionary<int, iD4UxTj3qtoFpKTXiYf> dictionary = new Dictionary<int, iD4UxTj3qtoFpKTXiYf>();
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					int num2 = xi2zZCuGtn[k * 16 + j];
					byte b2 = 0;
					int num3 = 0;
					do
					{
						array = null;
						array2 = null;
						b2 = 0;
						int num4 = num2 / 16;
						if (num4 < list.Count)
						{
							if (!dictionary.ContainsKey(num4))
							{
								dictionary.Add(num4, SNlzGCOiHe(list[num4], (byte)num4));
							}
							array = dictionary[num4].Blocks;
							array2 = dictionary[num4].Data;
							if (array == null || array.Length < 4096 || array2 == null || array2.Length < 2048)
							{
								return bitmap;
							}
							num3 = j * 256 + k * 16 + (num2 - num4 * 16);
							b2 = array[num3];
						}
						num2--;
					}
					while (num2 >= 0 && MBSzpwtOM0.Contains(b2));
					if (num2 < 0)
					{
						num2 = 0;
					}
					int num5 = 0;
					if (array2 != null && array2.Length >= 2048)
					{
						num5 = nibbleSetters.TU17GetFast(array2, num3);
					}
					Color color = hAjzVZSaGe[b2][num5];
					bitmap.SetPixel(j, k, color);
				}
			}
		}
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private iD4UxTj3qtoFpKTXiYf tl8zvrkt4o(byte[] P_0, byte P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		int num = 1;
		if (P_0[0] == 8)
		{
			_ = P_0[1];
			num++;
		}
		int[] array = new int[4096];
		for (int i = 0; i < 1; i++)
		{
			num = dXTzwBDPHY(P_0, array, num);
		}
		byte[] array2 = P_0.Skip(num).Take(P_0.Length - num).ToArray();
		BlockState[] array3 = Hlmz4vAVe4(array2);
		byte[] array4 = new byte[4096];
		byte[] array5 = new byte[2048];
		iD4UxTj3qtoFpKTXiYf iD4UxTj3qtoFpKTXiYf2 = new iD4UxTj3qtoFpKTXiYf();
		iD4UxTj3qtoFpKTXiYf2.Blocks = array4;
		iD4UxTj3qtoFpKTXiYf2.Data = array5;
		iD4UxTj3qtoFpKTXiYf2.SkyLight = new byte[2048];
		iD4UxTj3qtoFpKTXiYf2.BlockLight = new byte[2048];
		for (int j = 0; j < array.Length; j++)
		{
			array4[j] = (byte)array3[array[j]].id.Value;
			nibbleSetters.TU17SetFast(array5, j, (byte)array3[array[j]].data);
		}
		return iD4UxTj3qtoFpKTXiYf2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int dXTzwBDPHY(byte[] P_0, int[] P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new TagNodeCompound();
		BlockStateConfig blockStateConfig = new BlockStateConfig(P_0[P_2], P_2 < 10);
		P_2++;
		int num = 0;
		for (int i = 0; i < blockStateConfig.wordCount; i++)
		{
			uint num2 = PEUtility.ReadWord(P_0, P_2);
			for (int j = 0; j < blockStateConfig.blocksPerWord; j++)
			{
				if (num >= 4096)
				{
					break;
				}
				int num3 = (int)((num2 >> j * blockStateConfig.bitsPerBlock) & blockStateConfig.mask);
				int num4 = (num >> 8) & 0xF;
				int num5 = num & 0xF;
				int num6 = (num >> 4) & 0xF;
				P_1[num] = num3;
				num++;
			}
			P_2 += 4;
		}
		return P_2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BlockState[] Hlmz4vAVe4(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v();
		nJVJiCuZKORGPYB1Y4v.S6FSRREan0P(false);
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		MemoryStream memoryStream = new MemoryStream(P_0);
		int num = nJVJiCuZKORGPYB1Y4v.PsDSRt4knGJ(memoryStream);
		for (int i = 0; i < num; i++)
		{
			try
			{
				NbtTree nbtTree = new NbtTree(memoryStream);
				if (nbtTree.Root != null)
				{
					tagNodeList.Add(nbtTree.Root);
				}
			}
			catch (Exception)
			{
			}
		}
		BlockState[] array = new BlockState[tagNodeList.Count];
		for (int j = 0; j < tagNodeList.Count; j++)
		{
			string name = (TagNodeString)((TagNodeCompound)tagNodeList[j])[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)];
			short val = 0;
			if (!((TagNodeCompound)tagNodeList[j]).ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19874)))
			{
				val = (TagNodeShort)((TagNodeCompound)tagNodeList[j])[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)];
			}
			array[j] = BlockMaster.GetBedrockBlockState(name, val);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LogicChangeBiomes()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		QXdzWDZPYv = 512;
		Xi2zZCuGtn = new byte[256];
		mtLzfbZXeg = new byte[256];
		QbkzixtVwJ = 9;
		gYczs2kAHe = 24;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LogicChangeBiomes()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		hAjzVZSaGe = null;
		MBSzpwtOM0 = new int[45]
		{
			0, 20, 27, 28, 50, 55, 65, 66, 69, 75,
			76, 77, 90, 92, 93, 94, 95, 102, 123, 131,
			140, 144, 149, 150, 160, 166, 198, 217, 219, 220,
			221, 222, 223, 224, 225, 226, 227, 228, 228, 229,
			230, 231, 232, 233, 234
		};
	}
}
