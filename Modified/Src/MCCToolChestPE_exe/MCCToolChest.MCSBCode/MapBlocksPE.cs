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
using MCCToolChest.Properties;
using MCCToolChest.utils;
using MCCToolChest.workers;
using MCPELevelDBI.workers;
using OAxWrWumnobfHyEL9yr;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class MapBlocksPE
{
	private static Color[][] G62SpqEKIuT;

	private int dU9SpKeWgtO;

	private static int[] FawSphudHMm;

	private MapBlockPEParameter VRMSpmbxeAJ;

	private DirectBitmap IhbSpnIHaTv;

	private DirectBitmap OgySpl5w7E8;

	private DirectBitmap QwHSp2eV5Ue;

	private byte[] elcSpygWTtS;

	private byte[] uXXSp0MS3Fp;

	public static int[] TransparentBlocks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return FawSphudHMm;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			FawSphudHMm = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MapRegion(object threadContext)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		VRMSpmbxeAJ = threadContext as MapBlockPEParameter;
		MapRegion(VRMSpmbxeAJ);
		VRMSpmbxeAJ.Completed = true;
		VRMSpmbxeAJ.DoneEvent.Set();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MapRegion(MapBlockPEParameter parms)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < 256; i++)
		{
			elcSpygWTtS[i] = byte.MaxValue;
		}
		for (int j = 0; j < 256; j++)
		{
			uXXSp0MS3Fp[j] = 0;
		}
		IhbSpnIHaTv = new DirectBitmap(dU9SpKeWgtO, dU9SpKeWgtO);
		OgySpl5w7E8 = new DirectBitmap(dU9SpKeWgtO, dU9SpKeWgtO);
		QwHSp2eV5Ue = new DirectBitmap(dU9SpKeWgtO, dU9SpKeWgtO);
		ykiSpv2oRbh(parms.PERegion, parms.DBWorker);
		parms.BlockImage = IhbSpnIHaTv;
		parms.BiomeImage = OgySpl5w7E8;
		parms.HeightImage = QwHSp2eV5Ue;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ykiSpv2oRbh(PERegion P_0, LevelDBWorker P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 32; j++)
			{
				pQWSpwC4jGd(P_0, lxe7hMuSirBXGUQugsD.QdsSP76hcgY(i, P_0.RX), lxe7hMuSirBXGUQugsD.QdsSP76hcgY(j, P_0.RZ), P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pQWSpwC4jGd(PERegion P_0, int P_1, int P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = elcSpygWTtS;
		byte[] array2 = uXXSp0MS3Fp;
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_1, P_0.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_2, P_0.RZ);
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		if (P_0.Chunks[num3] != 1)
		{
			return;
		}
		byte[] key = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 45);
		byte[] array3 = P_3.ReadDbValue(key);
		if (array3 != null)
		{
			int num4 = 0;
			for (int i = 0; i < 512; i += 2)
			{
				array[num4++] = array3[i];
			}
			array2 = array3.Skip(512).Take(256).ToArray();
		}
		key = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 47, 0);
		List<byte[]> list = new List<byte[]>();
		bool flag = false;
		for (byte b = 0; b < 16; b++)
		{
			key[key.Length - 1] = b;
			byte[] array4 = P_3.ReadDbValue(key);
			if (array4 != null)
			{
				flag = true;
				list.Add(array4);
			}
		}
		if (flag)
		{
			y4gSp4u8hd4(list, P_0, array, P_1, P_2);
		}
		else
		{
			key = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 48);
			byte[] array5 = P_3.ReadDbValue(key);
			if (array5 != null)
			{
				iD4UxTj3qtoFpKTXiYf iD4UxTj3qtoFpKTXiYf2 = new iD4UxTj3qtoFpKTXiYf();
				iD4UxTj3qtoFpKTXiYf2.Blocks = array5.Take(32768).ToArray();
				iD4UxTj3qtoFpKTXiYf2.Data = array5.Skip(32768).Take(16384).ToArray();
				sevSpWDsWXM(iD4UxTj3qtoFpKTXiYf2, P_0, array, P_1, P_2);
			}
		}
		mEDSpsCwFeE(array, P_1, P_2);
		MqdSpi7L4kY(array2, P_1, P_2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void y4gSp4u8hd4(List<byte[]> P_0, PERegion P_1, byte[] P_2, int P_3, int P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		NibbleSetters nibbleSetters = new NibbleSetters();
		byte[] array = null;
		byte[] array2 = null;
		int num2 = ((P_3 >= 0) ? (P_3 * 16) : ((P_3 + 1) * 16));
		int num3 = ((P_4 >= 0) ? (P_4 * 16) : ((P_4 + 1) * 16));
		Dictionary<int, iD4UxTj3qtoFpKTXiYf> dictionary = new Dictionary<int, iD4UxTj3qtoFpKTXiYf>();
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num4 = P_2[j * 16 + i];
				byte b = 0;
				int num5 = 0;
				do
				{
					array = null;
					array2 = null;
					b = 0;
					num = num4 / 16;
					if (num < P_0.Count)
					{
						if (!dictionary.ContainsKey(num))
						{
							dictionary.Add(num, AvSSpV9hf8U(P_0[num], (byte)num));
						}
						array = dictionary[num].Blocks;
						array2 = dictionary[num].Data;
						if (array == null || array.Length < 4096 || array2 == null || array2.Length < 2048)
						{
							return;
						}
						num5 = i * 256 + j * 16 + (num4 - num * 16);
						b = array[num5];
					}
					num4--;
				}
				while (num4 >= 0 && FawSphudHMm.Contains(b));
				if (num4 < 0)
				{
					num4 = 0;
				}
				int num6 = 0;
				if (array2 != null && array2.Length >= 2048)
				{
					num6 = nibbleSetters.TU17GetFast(array2, num5);
				}
				Color colour = G62SpqEKIuT[b][num6];
				int num7 = num2 + ((P_3 >= 0) ? i : ((16 - i) * -1));
				int num8 = num3 + ((P_4 >= 0) ? j : ((16 - j) * -1));
				if (num7 < 0)
				{
					num7 = dU9SpKeWgtO + num7;
				}
				if (num8 < 0)
				{
					num8 = dU9SpKeWgtO + num8;
				}
				IhbSpnIHaTv.SetPixel(num7, num8, colour);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private iD4UxTj3qtoFpKTXiYf AvSSpV9hf8U(byte[] P_0, byte P_1)
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
			iD4UxTj3qtoFpKTXiYf2 = QenSppy5ejX(P_0, P_1);
		}
		return iD4UxTj3qtoFpKTXiYf2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sevSpWDsWXM(iD4UxTj3qtoFpKTXiYf P_0, PERegion P_1, byte[] P_2, int P_3, int P_4)
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
				while (num3 >= 0 && FawSphudHMm.Contains(b));
				if (num3 < 0)
				{
					num3 = 0;
				}
				int num5 = 0;
				if (array2 != null && array2.Length > 0)
				{
					num5 = nibbleSetters.TU17GetFast(array2, num4);
				}
				Color colour = G62SpqEKIuT[b][num5];
				int num6 = num + ((P_3 >= 0) ? i : ((16 - i) * -1));
				int num7 = num2 + ((P_4 >= 0) ? j : ((16 - j) * -1));
				if (num6 < 0)
				{
					num6 = dU9SpKeWgtO + num6;
				}
				if (num7 < 0)
				{
					num7 = dU9SpKeWgtO + num7;
				}
				IhbSpnIHaTv.SetPixel(num6, num7, colour);
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
		byte[] array3 = elcSpygWTtS;
		byte[] key = PEUtility.BuildChunkKey(dimension, chunkX, chunkZ, 45);
		byte[] array4 = dbWorker.ReadDbValue(key);
		if (array4 != null)
		{
			int num = 0;
			for (int i = 0; i < 512; i += 2)
			{
				array3[num++] = array4[i];
			}
		}
		key = PEUtility.BuildChunkKey(dimension, chunkX, chunkZ, 47, 0);
		List<byte[]> list = new List<byte[]>();
		bool flag = false;
		for (byte b = 0; b < 16; b++)
		{
			key[key.Length - 1] = b;
			byte[] array5 = dbWorker.ReadDbValue(key);
			if (array5 != null)
			{
				flag = true;
				list.Add(array5);
			}
		}
		if (flag)
		{
			Dictionary<int, iD4UxTj3qtoFpKTXiYf> dictionary = new Dictionary<int, iD4UxTj3qtoFpKTXiYf>();
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					int num2 = array3[k * 16 + j];
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
								dictionary.Add(num4, AvSSpV9hf8U(list[num4], (byte)num4));
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
					while (num2 >= 0 && FawSphudHMm.Contains(b2));
					if (num2 < 0)
					{
						num2 = 0;
					}
					int num5 = 0;
					if (array2 != null && array2.Length >= 2048)
					{
						num5 = nibbleSetters.TU17GetFast(array2, num3);
					}
					Color color = G62SpqEKIuT[b2][num5];
					bitmap.SetPixel(j, k, color);
				}
			}
		}
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private iD4UxTj3qtoFpKTXiYf QenSppy5ejX(byte[] P_0, byte P_1)
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
			num = gr0SpZEomFZ(P_0, array, num);
		}
		byte[] array2 = P_0.Skip(num).Take(P_0.Length - num).ToArray();
		BlockState[] array3 = I7cSpfXSCUR(array2);
		byte[] array4 = new byte[4096];
		byte[] array5 = new byte[2048];
		iD4UxTj3qtoFpKTXiYf iD4UxTj3qtoFpKTXiYf2 = new iD4UxTj3qtoFpKTXiYf();
		iD4UxTj3qtoFpKTXiYf2.Blocks = array4;
		iD4UxTj3qtoFpKTXiYf2.Data = array5;
		iD4UxTj3qtoFpKTXiYf2.SkyLight = new byte[2048];
		iD4UxTj3qtoFpKTXiYf2.BlockLight = new byte[2048];
		for (int j = 0; j < array.Length; j++)
		{
			int? id = array3[array[j]].id;
			array4[j] = (byte)((!id.HasValue || id >= 256) ? new int?(0) : id).Value;
			nibbleSetters.TU17SetFast(array5, j, (byte)array3[array[j]].data);
		}
		return iD4UxTj3qtoFpKTXiYf2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int gr0SpZEomFZ(byte[] P_0, int[] P_1, int P_2)
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
	private BlockState[] I7cSpfXSCUR(byte[] P_0)
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
			if (!((TagNodeCompound)tagNodeList[j]).ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19874)) && ((TagNodeCompound)tagNodeList[j]).ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)))
			{
				val = (TagNodeShort)((TagNodeCompound)tagNodeList[j])[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)];
			}
			array[j] = BlockMaster.GetBedrockBlockState(name, val);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MqdSpi7L4kY(byte[] P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ((P_1 >= 0) ? (P_1 * 16) : ((P_1 + 1) * 16));
		int num2 = ((P_2 >= 0) ? (P_2 * 16) : ((P_2 + 1) * 16));
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num3 = j * 16 + i;
				int argb = 0;
				if (BiomeLookup.bedrockId.ContainsKey(P_0[num3]))
				{
					argb = (int)(4278190080u + (int)BiomeLookup.bedrockId[P_0[num3]].Color);
				}
				Color colour = Color.FromArgb(argb);
				int num4 = num + ((P_1 >= 0) ? i : ((16 - i) * -1));
				int num5 = num2 + ((P_2 >= 0) ? j : ((16 - j) * -1));
				if (num4 < 0)
				{
					num4 = dU9SpKeWgtO + num4;
				}
				if (num5 < 0)
				{
					num5 = dU9SpKeWgtO + num5;
				}
				OgySpl5w7E8.SetPixel(num4, num5, colour);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mEDSpsCwFeE(byte[] P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ((P_1 >= 0) ? (P_1 * 16) : ((P_1 + 1) * 16));
		int num2 = ((P_2 >= 0) ? (P_2 * 16) : ((P_2 + 1) * 16));
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num3 = j * 16 + i;
				int num4 = P_0[num3];
				if (Settings.Default.HeightView == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86038))
				{
					num4 = 255 - num4;
				}
				Color colour = Color.FromArgb(num4, num4, num4);
				int num5 = num + ((P_1 >= 0) ? i : ((16 - i) * -1));
				int num6 = num2 + ((P_2 >= 0) ? j : ((16 - j) * -1));
				if (num5 < 0)
				{
					num5 = dU9SpKeWgtO + num5;
				}
				if (num6 < 0)
				{
					num6 = dU9SpKeWgtO + num6;
				}
				QwHSp2eV5Ue.SetPixel(num5, num6, colour);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BuildColorLookupTable()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (G62SpqEKIuT != null)
		{
			return;
		}
		MapConverterII mapConverterII = new MapConverterII();
		G62SpqEKIuT = new Color[256][];
		for (int i = 0; i < 256; i++)
		{
			G62SpqEKIuT[i] = new Color[16];
			for (int j = 0; j < 16; j++)
			{
				Color color = mapConverterII.BlockToColor(i, j, 2);
				G62SpqEKIuT[i][j] = color;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapBlocksPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		dU9SpKeWgtO = 512;
		elcSpygWTtS = new byte[256];
		uXXSp0MS3Fp = new byte[256];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MapBlocksPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		G62SpqEKIuT = null;
		FawSphudHMm = new int[45]
		{
			0, 20, 27, 28, 50, 55, 65, 66, 69, 75,
			76, 77, 90, 92, 93, 94, 95, 102, 123, 131,
			140, 144, 149, 150, 160, 166, 198, 217, 219, 220,
			221, 222, 223, 224, 225, 226, 227, 228, 228, 229,
			230, 231, 232, 233, 234
		};
	}
}
