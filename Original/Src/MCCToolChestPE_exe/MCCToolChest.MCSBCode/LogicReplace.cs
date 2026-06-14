using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using afNMf7uWOyq6L7IHxiu;
using HQvrMLjs568pRpCE1da;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.utils;
using MCPELevelDBI.workers;
using nTlP9Vjesj51LNpQccs;
using Substrate.Nbt;
using t2dancj1aDNBEPVYsFL;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class LogicReplace
{
	private Dictionary<int, TagNodeCompound> pPEIIqcDtL;

	private BackgroundWorker ccZIz3pGfC;

	public StringBuilder chunkChanges;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LogicReplace()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		pPEIIqcDtL = new Dictionary<int, TagNodeCompound>();
		chunkChanges = new StringBuilder();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LogicReplace(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		pPEIIqcDtL = new Dictionary<int, TagNodeCompound>();
		chunkChanges = new StringBuilder();
		ccZIz3pGfC = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoSearchReplace()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = PEUtility.GetPEDimension(Constants.dimensionFolderNames[0]);
		DoSearchReplace(pEDimension, Working.T92StMGt1p4());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoSearchReplace(PEDimension peDimension, string workingFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(workingFolder);
		try
		{
			new List<EntitySearchResult>();
			int count = peDimension.Region.Values.Count;
			int num = 0;
			foreach (PERegion value in peDimension.Region.Values)
			{
				string text = value.ToString();
				ca3I9WwnxQ(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64314) + text, (int)((float)num / (float)count * 100f));
				if (xikIcpMjeF(peDimension, value, levelDBWorker))
				{
					result = true;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			levelDBWorker.CloseDB();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool xikIcpMjeF(PEDimension P_0, PERegion P_1, LevelDBWorker P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 32; j++)
			{
				if (NMtIJvYtSX(P_0, P_1, lxe7hMuSirBXGUQugsD.QdsSP76hcgY(i, P_1.RX), lxe7hMuSirBXGUQugsD.QdsSP76hcgY(j, P_1.RZ), P_2))
				{
					result = true;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NMtIJvYtSX(PEDimension P_0, PERegion P_1, int P_2, int P_3, LevelDBWorker P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = false;
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_2, P_1.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_3, P_1.RZ);
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		if (P_1.Chunks[num3] == 1)
		{
			Dictionary<int, pq4QvWjGbnFyoqlVrDa> dictionary = gxQIo5rIJM(P_1.Dimension, P_1, num, num2, P_4);
			if (dictionary.Count > 0)
			{
				emy4g6j4wKut7LJdxNM emy4g6j4wKut7LJdxNM2 = new emy4g6j4wKut7LJdxNM();
				emy4g6j4wKut7LJdxNM2.qSDSf7yj00M(num);
				emy4g6j4wKut7LJdxNM2.bF5SfHo7MuC(num2);
				emy4g6j4wKut7LJdxNM2.ITSSfICbk2l = dictionary;
				emy4g6j4wKut7LJdxNM2.wx2Sf97dUwq = P_1.Dimension;
				emy4g6j4wKut7LJdxNM2.TileEntities = CYEIuPaORx(P_1.Dimension, num, num2, P_4);
				flag = wrKIAOAn5D(emy4g6j4wKut7LJdxNM2);
				if (flag)
				{
					TFLIdDWeoJ(emy4g6j4wKut7LJdxNM2, P_4);
				}
			}
		}
		return flag;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList CYEIuPaORx(int P_0, int P_1, int P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		byte[] key = PEUtility.BuildChunkKey(P_0, P_1, P_2, 49);
		byte[] array = P_3.ReadDbValue(key);
		try
		{
			if (array != null)
			{
				MemoryStream memoryStream = new MemoryStream(array);
				while (memoryStream.Position < memoryStream.Length)
				{
					NbtTree nbtTree = new NbtTree(memoryStream);
					if (nbtTree.Root != null)
					{
						tagNodeList.Add(nbtTree.Root);
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<int, pq4QvWjGbnFyoqlVrDa> gxQIo5rIJM(int P_0, PERegion P_1, int P_2, int P_3, LevelDBWorker P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(P_2, P_3);
		Dictionary<int, pq4QvWjGbnFyoqlVrDa> dictionary = new Dictionary<int, pq4QvWjGbnFyoqlVrDa>();
		if (P_1.Chunks[num] == 1)
		{
			byte[] array = PEUtility.BuildChunkKey(P_1.Dimension, P_2, P_3, 47, 0);
			bool flag = false;
			for (byte b = 0; b < 16; b++)
			{
				array[array.Length - 1] = b;
				byte[] array2 = P_4.ReadDbValue(array);
				if (array2 != null)
				{
					flag = true;
					if (array2[0] != 1 && array2[0] < 8 && array2.Length >= 6145)
					{
						pq4QvWjGbnFyoqlVrDa value = z0jIQNlIO4(array2, b);
						dictionary[b] = value;
					}
					else if (array2[0] == 1 || array2[0] == 8)
					{
						pq4QvWjGbnFyoqlVrDa value2 = tcLICbZxpf(array2, b);
						dictionary[b] = value2;
					}
				}
			}
			if (!flag)
			{
				array = PEUtility.BuildChunkKey(P_1.Dimension, P_2, P_3, 48);
				byte[] array3 = P_4.ReadDbValue(array);
				if (array3 != null)
				{
					GycIO5FBym(array3, dictionary);
				}
			}
			for (int i = 0; i < 16; i++)
			{
				if (!dictionary.ContainsKey(i))
				{
					pq4QvWjGbnFyoqlVrDa pq4QvWjGbnFyoqlVrDa2 = new pq4QvWjGbnFyoqlVrDa(i);
					pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0] = new r9Iugsja8XwTquxO33t();
					pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].NNfSf5rRdUd(new int[4096]);
					pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].data = new byte[2048];
					pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1] = new r9Iugsja8XwTquxO33t();
					pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1].NNfSf5rRdUd(new int[4096]);
					pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1].data = new byte[2048];
					dictionary[i] = pq4QvWjGbnFyoqlVrDa2;
				}
			}
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private pq4QvWjGbnFyoqlVrDa z0jIQNlIO4(byte[] P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pq4QvWjGbnFyoqlVrDa pq4QvWjGbnFyoqlVrDa2 = new pq4QvWjGbnFyoqlVrDa(P_1);
		pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0] = new r9Iugsja8XwTquxO33t();
		int[] array = new int[4096];
		for (int i = 0; i < 4096; i++)
		{
			array[i] = P_0[i + 1];
			if (array[i] > 0)
			{
				pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].Oh7Sfc8ly6q = true;
			}
		}
		pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].NNfSf5rRdUd(array);
		pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].data = P_0.Skip(4097).Take(2048).ToArray();
		pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1] = new r9Iugsja8XwTquxO33t();
		pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1].NNfSf5rRdUd(new int[4096]);
		pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1].data = new byte[2048];
		return pq4QvWjGbnFyoqlVrDa2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GycIO5FBym(byte[] P_0, Dictionary<int, pq4QvWjGbnFyoqlVrDa> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		byte[] data = P_0.Skip(32768).Take(16384).ToArray();
		int[] array = new int[32768];
		byte[] array2 = new byte[16384];
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 128; k++)
				{
					int num = i * 2048 + j * 128 + k;
					byte b = P_0[num];
					int val = nibbleSetters.TU17GetFast(data, num);
					int num2 = k * 256 + j * 16 + i;
					array[num2] = b;
					nibbleSetters.TU17SetFast(array2, num2, val);
				}
			}
		}
		for (byte b2 = 0; b2 < 8; b2++)
		{
			pq4QvWjGbnFyoqlVrDa pq4QvWjGbnFyoqlVrDa2 = new pq4QvWjGbnFyoqlVrDa(b2);
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0] = new r9Iugsja8XwTquxO33t();
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].NNfSf5rRdUd(array.Skip(4096 * b2).Take(4096).ToArray());
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].data = array2.Skip(2048 * b2).Take(2048).ToArray();
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].Oh7Sfc8ly6q = true;
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1] = new r9Iugsja8XwTquxO33t();
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1].NNfSf5rRdUd(new int[4096]);
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1].data = new byte[2048];
			P_1[b2] = pq4QvWjGbnFyoqlVrDa2;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private pq4QvWjGbnFyoqlVrDa tcLICbZxpf(byte[] P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 1;
		int num2 = 1;
		if (P_0[0] == 8)
		{
			num = P_0[num2];
			num2++;
		}
		pq4QvWjGbnFyoqlVrDa pq4QvWjGbnFyoqlVrDa2 = new pq4QvWjGbnFyoqlVrDa(P_1);
		pq4QvWjGbnFyoqlVrDa2.MhUSfOQVlhS = true;
		for (int i = 0; i < num; i++)
		{
			r9Iugsja8XwTquxO33t r9Iugsja8XwTquxO33t2 = new r9Iugsja8XwTquxO33t();
			num2 = RXqI7ISuVr(P_0, r9Iugsja8XwTquxO33t2, num2);
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[i] = r9Iugsja8XwTquxO33t2;
		}
		if (num == 1)
		{
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1] = new r9Iugsja8XwTquxO33t();
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1].NNfSf5rRdUd(new int[4096]);
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[1].data = new byte[2048];
		}
		return pq4QvWjGbnFyoqlVrDa2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int RXqI7ISuVr(byte[] P_0, r9Iugsja8XwTquxO33t P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		bool oh7Sfc8ly6q = false;
		_ = P_0[P_2];
		int num = P_0[P_2] >> 1;
		P_2++;
		int num2 = (int)Math.Floor((decimal)(32 / num));
		int num3 = (int)Math.Ceiling(4096.0 / (double)num2);
		int[] array = new int[4096];
		byte[] array2 = new byte[2048];
		uint num4 = (uint)((1 << num) - 1);
		int num5 = num3 * 4 + P_2;
		byte[] paletteData = P_0.Skip(num5).Take(P_0.Length - num5).ToArray();
		int bytesRead = 0;
		TagNodeList paletteEntries = PEUtility.ReadPaletteEntries(paletteData, out bytesRead);
		BlockState[] blockStatesFromPalette = PEUtility.GetBlockStatesFromPalette(paletteEntries);
		int num6 = 0;
		for (int i = 0; i < num3; i++)
		{
			uint num7 = PEUtility.ReadWord(P_0, P_2);
			for (int j = 0; j < num2; j++)
			{
				if (num6 >= 4096)
				{
					break;
				}
				int num8 = (int)((num7 >> j * num) & num4);
				if (num8 < blockStatesFromPalette.Length)
				{
					int value = blockStatesFromPalette[num8].id.Value;
					int data = blockStatesFromPalette[num8].data;
					int num9 = value;
					byte val = (byte)data;
					if (num9 > 0)
					{
						oh7Sfc8ly6q = true;
					}
					array[num6] = num9;
					nibbleSetters.TU17SetFast(array2, num6, val);
				}
				num6++;
			}
			P_2 += 4;
		}
		P_1.NNfSf5rRdUd(array);
		P_1.data = array2;
		P_1.Oh7Sfc8ly6q = oh7Sfc8ly6q;
		return P_2 + bytesRead;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool wrKIAOAn5D(emy4g6j4wKut7LJdxNM P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		NibbleSetters nibbleSetters = new NibbleSetters();
		if (P_0.MPeSfCmqMuW() < 0)
		{
			P_0.MPeSfCmqMuW();
		}
		else
		{
			P_0.MPeSfCmqMuW();
		}
		if (P_0.QwkSfdMLlTU() < 0)
		{
			P_0.QwkSfdMLlTU();
		}
		else
		{
			P_0.QwkSfdMLlTU();
		}
		List<MCCoordinate> list = new List<MCCoordinate>();
		for (int i = 0; i < 16; i++)
		{
			pq4QvWjGbnFyoqlVrDa pq4QvWjGbnFyoqlVrDa2 = P_0.ITSSfICbk2l[i];
			int[] array = pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].fOtSfr3dypQ();
			byte[] data = pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].data;
			bool oh7Sfc8ly6q = false;
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					for (int l = 0; l < 16; l++)
					{
						int num = j * 256 + k * 16 + l;
						int num2 = array[num];
						int val = nibbleSetters.TU17GetFast(data, num);
						int num3 = i * 16 + l;
						if (num2 == 385)
						{
							bool flag = false;
							for (int m = 0; m < list.Count; m++)
							{
								if (list[m].ax9Sw78H4rf(j, num3, k))
								{
									nibbleSetters.TU17SetFast(data, num, 2);
									result = true;
									flag = true;
									list.Remove(list[m]);
									break;
								}
							}
							if (!flag)
							{
								list.Add(new MCCoordinate(j, num3 + 1, k, val));
								nibbleSetters.TU17SetFast(data, num, 1);
							}
						}
						if (array[num] > 0)
						{
							oh7Sfc8ly6q = true;
						}
					}
				}
			}
			pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].Oh7Sfc8ly6q = oh7Sfc8ly6q;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TFLIdDWeoJ(emy4g6j4wKut7LJdxNM P_0, LevelDBWorker P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PnQIjS6hkl(P_0.wx2Sf97dUwq, P_0.MPeSfCmqMuW(), P_0.QwkSfdMLlTU(), P_1);
		bool flag = false;
		chunkChanges.AppendLine(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64188), P_0.MPeSfCmqMuW(), P_0.QwkSfdMLlTU()));
		wKOIFr6qCi(P_0, P_1);
		for (int num = 15; num >= 0; num--)
		{
			pq4QvWjGbnFyoqlVrDa pq4QvWjGbnFyoqlVrDa2 = P_0.ITSSfICbk2l[num];
			if (pq4QvWjGbnFyoqlVrDa2.DftSfQChQ6N[0].Oh7Sfc8ly6q || flag)
			{
				byte[] array = null;
				if (pq4QvWjGbnFyoqlVrDa2.MhUSfOQVlhS)
				{
					TagNodeCompound node = x93I8NmyOO(pq4QvWjGbnFyoqlVrDa2);
					array = PEUtility.BuildBlockStateChunk(node);
				}
				else
				{
					array = JobIHCtXEF(pq4QvWjGbnFyoqlVrDa2);
				}
				byte[] key = PEUtility.BuildChunkKey(P_0.wx2Sf97dUwq, P_0.MPeSfCmqMuW(), P_0.QwkSfdMLlTU(), 47, (byte)num);
				P_1.Put(key, array);
				flag = true;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] JobIHCtXEF(pq4QvWjGbnFyoqlVrDa P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.WriteByte(0);
		byte[] array = new byte[4096];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)P_0.DftSfQChQ6N[0].fOtSfr3dypQ()[i];
		}
		memoryStream.Write(array, 0, 4096);
		memoryStream.Write(P_0.DftSfQChQ6N[0].data, 0, 2048);
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wKOIFr6qCi(emy4g6j4wKut7LJdxNM P_0, LevelDBWorker P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < P_0.TileEntities.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = P_0.TileEntities[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		if (memoryStream.Length > 0)
		{
			byte[] key = PEUtility.BuildChunkKey(P_0.wx2Sf97dUwq, P_0.MPeSfCmqMuW(), P_0.QwkSfdMLlTU(), 49);
			P_1.Put(key, memoryStream.ToArray());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PnQIjS6hkl(int P_0, int P_1, int P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] key = PEUtility.BuildChunkKey(P_0, P_1, P_2, 48);
		P_3.Delete(key);
		key = PEUtility.BuildChunkKey(P_0, P_1, P_2, 49);
		P_3.Delete(key);
		for (byte b = 0; b < 16; b++)
		{
			key = PEUtility.BuildChunkKey(P_0, P_1, P_2, 47, b);
			P_3.Delete(key);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound x93I8NmyOO(pq4QvWjGbnFyoqlVrDa P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		int num = ((P_0.DftSfQChQ6N[1] == null || !P_0.DftSfQChQ6N[1].Oh7Sfc8ly6q) ? 1 : 2);
		for (int i = 0; i < num; i++)
		{
			PaletteIndexWorker paletteIndexWorker = new PaletteIndexWorker();
			Dictionary<string, Dictionary<short, BlockState>> dictionary = new Dictionary<string, Dictionary<short, BlockState>>();
			dictionary.Clear();
			int[] array = new int[4096];
			for (int j = 0; j < 4096; j++)
			{
				int id = P_0.DftSfQChQ6N[i].fOtSfr3dypQ()[j];
				short num2 = (short)nibbleSetters.TU17GetFast(P_0.DftSfQChQ6N[i].data, j);
				string name = BlockMaster.GetBedrockBlockState(id, num2).name;
				int paletteIndex = paletteIndexWorker.GetPaletteIndex(dictionary, name, num2);
				array[j] = paletteIndex;
			}
			TagNodeCompound tagNodeCompound = new TagNodeCompound();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = PEUtility.BuildNBTPalette(dictionary);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(array);
			tagNodeList.Add(tagNodeCompound);
		}
		TagNodeCompound tagNodeCompound2 = null;
		tagNodeCompound2 = new TagNodeCompound();
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)P_0.ODxSfoMUjRL);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = new TagNodeByte(1);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] = tagNodeList;
		return tagNodeCompound2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ca3I9WwnxQ(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ccZIz3pGfC != null)
		{
			ccZIz3pGfC.ReportProgress(P_1, P_0);
		}
	}
}
