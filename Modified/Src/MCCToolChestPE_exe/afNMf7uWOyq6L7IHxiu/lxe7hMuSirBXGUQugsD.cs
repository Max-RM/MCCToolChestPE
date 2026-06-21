using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using HiT3kduFNLtRQIR37JV;
using Ionic.Zlib;
using MCCToolChest.model;
using MCCToolChest.utils;
using MCPELevelDBI.workers;
using mwbfmPuu2xATDbQldmM;
using OAxWrWumnobfHyEL9yr;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace afNMf7uWOyq6L7IHxiu;

internal class lxe7hMuSirBXGUQugsD
{
	[CompilerGenerated]
	private static Func<ChunkIndexEntry, int> MABSRGuw5Gy;

	[CompilerGenerated]
	private static Func<ChunkIndexEntry, int> Q0VSRbaS7n6;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string UCYSg7s8eRf(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = "";
		switch (P_0)
		{
		case 0:
			result = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214374);
			break;
		case 1:
			result = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214394);
			break;
		case 2:
			result = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214414);
			break;
		case 3:
			result = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214436);
			break;
		case 4:
			result = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214456);
			break;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<IndexEntry> a2jSgARJtVq(BinaryReader P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IndexOffsetData indexOffsetData = null;
		List<IndexEntry> list = null;
		indexOffsetData = r2vSgdhSd98(P_0);
		return zMNSgHfvoBR(P_0, indexOffsetData);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static IndexOffsetData r2vSgdhSd98(BinaryReader P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IndexOffsetData indexOffsetData = new IndexOffsetData();
		P_0.BaseStream.Seek(0L, SeekOrigin.Begin);
		indexOffsetData.IndexOffset = FileUtils.ReadUInt32(P_0, FileUtils.ByteOrder.BigEndian);
		indexOffsetData.FileCount = FileUtils.ReadUInt32(P_0, FileUtils.ByteOrder.BigEndian);
		return indexOffsetData;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<IndexEntry> zMNSgHfvoBR(BinaryReader P_0, IndexOffsetData P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<IndexEntry> list = new List<IndexEntry>();
		long num = P_0.BaseStream.Length - P_1.IndexOffset;
		int num2 = (int)(num / 144);
		if (num2 <= P_1.FileCount)
		{
			P_0.BaseStream.Seek(P_1.IndexOffset, SeekOrigin.Begin);
			for (int i = 0; i < num2; i++)
			{
				IndexEntry indexEntry = pyMSgFqkNt9(P_0);
				if (!string.IsNullOrWhiteSpace(indexEntry.FileName))
				{
					list.Add(indexEntry);
				}
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static IndexEntry pyMSgFqkNt9(BinaryReader P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[144];
		for (int i = 0; i < 144; i++)
		{
			array[i] = P_0.ReadByte();
			if (P_0.BaseStream.Position == P_0.BaseStream.Length)
			{
				break;
			}
		}
		return new IndexEntry(array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ChunkIndexEntry> kM7SgjjqASt(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<ChunkIndexEntry> result = null;
		if (File.Exists(P_0))
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(P_0, FileMode.Open));
			if (binaryReader.BaseStream.Length >= 4096)
			{
				result = kl2Sg8rssmH(binaryReader);
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<ChunkIndexEntry> kl2Sg8rssmH(BinaryReader P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<ChunkIndexEntry> list = new List<ChunkIndexEntry>();
		for (int i = 0; i < 1024; i++)
		{
			uint chunkOffset = uFiSgIiySfH(P_0.ReadBytes(3));
			byte chunkLength = P_0.ReadByte();
			list.Add(new ChunkIndexEntry(i, chunkOffset, chunkLength));
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<ChunkIndexEntry> gCmSg9Efe8W()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<ChunkIndexEntry> list = new List<ChunkIndexEntry>();
		for (int i = 0; i < 1024; i++)
		{
			uint chunkOffset = 0u;
			byte chunkLength = 0;
			list.Add(new ChunkIndexEntry(i, chunkOffset, chunkLength));
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static uint uFiSgIiySfH(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[4];
		array[3] = 0;
		array[2] = P_0[0];
		array[1] = P_0[1];
		array[0] = P_0[2];
		return BitConverter.ToUInt32(array, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] PijSgzkOLmd(string P_0, ChunkIndexEntry P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = null;
		using BinaryReader binaryReader = new BinaryReader(File.Open(P_0, FileMode.Open));
		return O8ZSPT5V6Yi(binaryReader, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] O8ZSPT5V6Yi(BinaryReader P_0, ChunkIndexEntry P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = null;
		array = new byte[P_1.OldChunkLength * 4096];
		P_0.BaseStream.Position = P_1.OldChunkOffset * 4096;
		P_0.Read(array, 0, array.Length);
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] TOTSPSDDf3y(byte[] P_0, ChunkIndexEntry P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = null;
		int num = P_1.OldChunkLength * 4096;
		uint srcOffset = P_1.OldChunkOffset * 4096;
		array = new byte[num];
		Buffer.BlockCopy(P_0, (int)srcOffset, array, 0, num);
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void kJ1SPGSfj2q(byte[] P_0, ChunkIndexEntry P_1, BinaryWriter P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null && P_0.Length > 0)
		{
			long num = ((P_0.Length % 4096 != 0) ? (4096 - P_0.Length % 4096) : 0);
			P_1.NewChunkOffset = (uint)(P_2.BaseStream.Position / 4096);
			P_1.NewChunkLength = (byte)((P_0.Length + num) / 4096);
			P_2.Write(P_0, 0, P_0.Length);
			for (int i = 0; i < num; i++)
			{
				P_2.Write((byte)0);
			}
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214478), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214512));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BC3SPblL86K(byte[] P_0, ChunkIndexEntry P_1, MemoryStream P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null && P_0.Length > 0)
		{
			long num = ((P_0.Length % 4096 != 0) ? (4096 - P_0.Length % 4096) : 0);
			P_1.NewChunkOffset = (uint)(P_2.Position / 4096);
			P_1.NewChunkLength = (byte)((P_0.Length + num) / 4096);
			P_2.Write(P_0, 0, P_0.Length);
			for (int i = 0; i < num; i++)
			{
				P_2.WriteByte(0);
			}
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214478), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214512));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int wXGSPvWZmex(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 & 0x1F) + (P_1 & 0x1F) * 32;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint KnZSPw4VRaI(List<ChunkIndexEntry> P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uint result = 0u;
		if (P_0 != null)
		{
			ChunkIndexEntry chunkIndexEntry = P_0[P_1 + P_2 * 32];
			if (chunkIndexEntry != null)
			{
				result = P_0[P_1 + P_2 * 32].OldChunkOffset;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool gMiSP4Al2WT(List<ChunkIndexEntry> P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return KnZSPw4VRaI(P_0, P_1, P_2) != 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ChunkIndexEntry XnuSPVkd0a5(List<ChunkIndexEntry> P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null && P_0.Count >= P_1 + P_2 * 32)
		{
			return P_0[P_1 + P_2 * 32];
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DFqSPWpEMEG<XFsVKIuoiqeIB7ulR98>(XFsVKIuoiqeIB7ulR98[] P_0, int P_1, out XFsVKIuoiqeIB7ulR98[] P_2, out XFsVKIuoiqeIB7ulR98[] P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_2 = P_0.Take(P_1).ToArray();
		P_3 = P_0.Skip(P_1).ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string bOHSPpkAwil(BinaryReader P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.BaseStream.Seek(8L, SeekOrigin.Begin);
		short num = FileUtils.ReadShort(P_0);
		short num2 = FileUtils.ReadShort(P_0);
		return string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214538), num2, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void bcySPZ9TtT9(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(P_0, FileMode.Create));
		wZ4SPffRUG3(binaryWriter);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void wZ4SPffRUG3(BinaryWriter P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte value = 0;
		for (int i = 0; i < 8192; i++)
		{
			P_0.Write(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void aVeSPi2nWxI(MemoryStream P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte value = 0;
		for (int i = 0; i < 8192; i++)
		{
			P_0.WriteByte(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LXASPshAxvx(int P_0, byte[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = QioSPh7iEFE(P_0);
		P_1[0] = 128;
		P_1[1] = array[1];
		P_1[2] = array[2];
		P_1[3] = array[3];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DKESPqGooqw(int P_0, byte[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = QioSPh7iEFE(P_0);
		P_1[4] = array[0];
		P_1[5] = array[1];
		P_1[6] = array[2];
		P_1[7] = array[3];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void wp2SPKh1O1o(int P_0, byte[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = QioSPh7iEFE(P_0);
		P_1[8] = array[0];
		P_1[9] = array[1];
		P_1[10] = array[2];
		P_1[11] = array[3];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] QioSPh7iEFE(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] bytes = BitConverter.GetBytes(P_0);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
		}
		return bytes;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void rjsSPmBeBNR(BinaryWriter P_0, List<ChunkIndexEntry> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.BaseStream.Seek(0L, SeekOrigin.Begin);
		P_1 = P_1.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (ChunkIndexEntry chunkIndexEntry) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return chunkIndexEntry.ChunkIndex;
		}).ToList();
		foreach (ChunkIndexEntry item in P_1)
		{
			uint newChunkOffset = item.NewChunkOffset;
			P_0.Write((byte)((newChunkOffset & 0xFF0000) >> 16));
			P_0.Write((byte)((newChunkOffset & 0xFF00) >> 8));
			P_0.Write((byte)(newChunkOffset & 0xFF));
			P_0.Write(item.NewChunkLength);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void V78SPnI5tNJ(MemoryStream P_0, List<ChunkIndexEntry> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Seek(0L, SeekOrigin.Begin);
		P_1 = P_1.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (ChunkIndexEntry chunkIndexEntry) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return chunkIndexEntry.ChunkIndex;
		}).ToList();
		foreach (ChunkIndexEntry item in P_1)
		{
			uint newChunkOffset = item.NewChunkOffset;
			P_0.WriteByte((byte)((newChunkOffset & 0xFF0000) >> 16));
			P_0.WriteByte((byte)((newChunkOffset & 0xFF00) >> 8));
			P_0.WriteByte((byte)(newChunkOffset & 0xFF));
			P_0.WriteByte(item.NewChunkLength);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Gp8SPlGw5nQ(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(P_0, FileMode.Create));
		wZ4SPffRUG3(binaryWriter);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound KgPSP2NfV9O(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		try
		{
			MemoryStream memoryStream = sObSPJXcvXK(P_0);
			memoryStream.Seek(0L, SeekOrigin.End);
			memoryStream.WriteByte(0);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			NbtTree nbtTree = new NbtTree(memoryStream);
			result = nbtTree.Root;
		}
		catch (Exception)
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool XySSPyn1o7b(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Constants.BEDROCK_ENTITY_BLOCKS.ContainsKey(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string Fg2SP0llmHq(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Constants.BEDROCK_ENTITY_BLOCKS.ContainsKey(P_0))
		{
			return Constants.BEDROCK_ENTITY_BLOCKS[P_0];
		}
		return string.Empty;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound gagSPBRJius(TagNodeCompound P_0, int P_1, int P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = P_0;
		if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)))
		{
			tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
		}
		if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)))
		{
			TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)] as TagNodeList;
			return YcASPtiwwBY(tagNodeList, P_1, P_2, P_3);
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound YcASPtiwwBY(TagNodeList P_0, int P_1, int P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = kxISPapgZlQ(P_0, P_1, P_2, P_3);
		if (tagNodeCompound != null)
		{
			P_0.Remove(tagNodeCompound);
		}
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound kxISPapgZlQ(TagNodeList P_0, int P_1, int P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int num = P_0.Count - 1; num >= 0; num--)
		{
			TagNodeCompound tagNodeCompound = P_0[num] as TagNodeCompound;
			ovfrckujlufyR7DEI0H ovfrckujlufyR7DEI0H2 = asNSPg5KOvd(tagNodeCompound);
			if (P_1 == ovfrckujlufyR7DEI0H2.X && P_2 == ovfrckujlufyR7DEI0H2.Y && P_3 == ovfrckujlufyR7DEI0H2.Z)
			{
				return tagNodeCompound;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void uOuSPX05suh(int P_0, TagNodeList P_1, int P_2, int P_3, int P_4, Dictionary<int, TagNodeCompound> P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Count == 0 && P_1.ValueType != TagType.TAG_COMPOUND)
		{
			P_1.ChangeValueType(TagType.TAG_COMPOUND);
		}
		TagNodeCompound tagNodeCompound = null;
		if (P_5 != null && P_5.ContainsKey(P_0))
		{
			tagNodeCompound = P_5[P_0].Copy() as TagNodeCompound;
		}
		else if (Constants.peEntityDefaults.ContainsKey(P_0))
		{
			string text = Constants.peEntityDefaults[P_0];
			tagNodeCompound = (TagNodeCompound)v4fSPe0WJtV(text);
			if (P_5 != null)
			{
				P_5[P_0] = tagNodeCompound;
			}
		}
		if (tagNodeCompound != null)
		{
			psnSPLt4q2O(tagNodeCompound, P_2, P_3, P_4);
			P_1.Add(tagNodeCompound);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string R1tSPxItoCC(string P_0, TagNode P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NbtTree nbtTree = new NbtTree();
		nbtTree.UseBigEndian = true;
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[P_0] = P_1;
		nbtTree.Root.Add(P_0, tagNodeCompound);
		MemoryStream memoryStream = new MemoryStream();
		nbtTree.ChildrenWriteTo(memoryStream);
		byte[] ba = memoryStream.ToArray();
		return Utils.ConvertByteArrayToHexString(ba);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNode v4fSPe0WJtV(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNode result = null;
		byte[] array = Utils.ConvertHexStringToByteArray(P_0);
		if (array != null && array.Length > 0)
		{
			NbtTree nbtTree = new NbtTree();
			nbtTree.UseBigEndian = true;
			using (MemoryStream s = new MemoryStream(array))
			{
				try
				{
					nbtTree.ReadFrom(s);
				}
				catch (Exception)
				{
				}
			}
			if (nbtTree != null && nbtTree.Root != null)
			{
				foreach (string key in nbtTree.Root.Keys)
				{
					TagNode tagNode = nbtTree.Root[key];
					if (tagNode != null)
					{
						if (tagNode is TagNodeCompound)
						{
							result = tagNode as TagNodeCompound;
						}
						else if (tagNode is TagNodeList)
						{
							result = tagNode as TagNodeList;
						}
						break;
					}
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNode Ec8SPM9mSqm(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = Utils.ConvertHexStringToByteArray(P_0);
		TagNode result = null;
		if (array != null && array.Length > 0)
		{
			NbtTree nbtTree = new NbtTree();
			nbtTree.UseBigEndian = true;
			using MemoryStream s = new MemoryStream(array);
			try
			{
				nbtTree.ReadFrom(s);
				result = nbtTree.Root;
			}
			catch (Exception)
			{
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EAISPUuIyGd(TagNodeCompound P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NbtTree nbtTree = new NbtTree(P_0);
		MemoryStream memoryStream = new MemoryStream();
		nbtTree.WriteTo(memoryStream);
		byte[] array = memoryStream.ToArray();
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(P_1, FileMode.Create));
		binaryWriter.Write(array, 0, array.Length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void psnSPLt4q2O(TagNodeCompound P_0, int P_1, int P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] = new TagNodeInt(P_1);
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] = new TagNodeInt(P_2);
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] = new TagNodeInt(P_3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ovfrckujlufyR7DEI0H asNSPg5KOvd(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ovfrckujlufyR7DEI0H ovfrckujlufyR7DEI0H2 = new ovfrckujlufyR7DEI0H();
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)) && P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)) && P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)))
		{
			ovfrckujlufyR7DEI0H2.X = (TagNodeInt)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)];
			ovfrckujlufyR7DEI0H2.Y = (TagNodeInt)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)];
			ovfrckujlufyR7DEI0H2.Z = (TagNodeInt)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)];
		}
		return ovfrckujlufyR7DEI0H2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int VnhSPPKC0e9(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0 >> 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound VM0SPR2pYyo(ChunkIndexEntry P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		if (P_0.OldChunkOffset != 0)
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(P_1, FileMode.Open));
			result = WnJSPkBUCJf(P_0, binaryReader);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound WnJSPkBUCJf(ChunkIndexEntry P_0, BinaryReader P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.BaseStream.Position = P_0.OldChunkOffset * 4096;
		return MtHSPYYXeal(P_0, P_1.BaseStream);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound MtHSPYYXeal(ChunkIndexEntry P_0, Stream P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v();
		nJVJiCuZKORGPYB1Y4v.PsDSRt4knGJ(P_1);
		nJVJiCuZKORGPYB1Y4v.PsDSRt4knGJ(P_1);
		return new TagNodeCompound();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound ypwSP3uBdKl(ChunkData P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		PEProcessWorker pEProcessWorker = new PEProcessWorker();
		int xWorldCoords = P_0.XWorldCoords;
		int zWorldCoords = P_0.ZWorldCoords;
		return pEProcessWorker.GetChunk(P_1, P_0.Dimension, xWorldCoords, zWorldCoords);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] XHFSP1WaY70(object P_0, ChunkData P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] result = null;
		if (P_0 != null)
		{
			MemoryStream memoryStream = null;
			TagNodeCompound tree = P_0 as TagNodeCompound;
			memoryStream = new MemoryStream();
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream);
			P_1.NewFileSize = (int)memoryStream.Length;
			memoryStream = T8BSPuY023C(memoryStream.ToArray());
			result = bP9SPEHtBom(memoryStream.ToArray(), P_1);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] bP9SPEHtBom(byte[] P_0, ChunkData P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0.Length;
		byte[] array = null;
		if (Working.RXpStXcJiRk() != PlatformType.PC && Working.RXpStXcJiRk() == PlatformType.PE)
		{
			array = OYFSPN6ytQn(P_0);
			byte[] first = new byte[12];
			array = first.Concat(array).ToArray();
			LXASPshAxvx(array.Length - 8, array);
			DKESPqGooqw(P_1.NewFileSize, array);
			wp2SPKh1O1o(num, array);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] byDSPrUjE5G(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using MemoryStream memoryStream = new MemoryStream();
		using (ZlibStream zlibStream = new ZlibStream(memoryStream, Ionic.Zlib.CompressionMode.Compress, leaveOpen: true))
		{
			zlibStream.Write(P_0, 0, P_0.Length);
		}
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] KpwSP5kgJSU(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using MemoryStream memoryStream = new MemoryStream();
		using (ZlibStream zlibStream = new ZlibStream(memoryStream, Ionic.Zlib.CompressionMode.Decompress, leaveOpen: true))
		{
			zlibStream.Write(P_0, 0, P_0.Length);
		}
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] RacSP6aHwsa(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using MemoryStream memoryStream = new MemoryStream();
		using MemoryStream stream = new MemoryStream(P_0);
		using GZipStream gZipStream = new GZipStream(stream, System.IO.Compression.CompressionMode.Decompress);
		gZipStream.CopyTo(memoryStream);
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] OYFSPN6ytQn(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using MemoryStream memoryStream = new MemoryStream(P_0);
		using MemoryStream memoryStream2 = new MemoryStream();
		using DeflateStream deflateStream = new DeflateStream(memoryStream2, System.IO.Compression.CompressionMode.Compress);
		memoryStream.CopyTo(deflateStream);
		deflateStream.Close();
		return memoryStream2.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] BAvSPDQGhag(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using MemoryStream memoryStream = new MemoryStream();
		using MemoryStream stream = new MemoryStream(P_0);
		using DeflateStream deflateStream = new DeflateStream(stream, System.IO.Compression.CompressionMode.Decompress);
		deflateStream.CopyTo(memoryStream);
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MemoryStream JTKSPcoEAsX(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = FileUtils.pURSg6Zk53A(P_0);
		return sObSPJXcvXK(array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MemoryStream sObSPJXcvXK(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		int num = 0;
		while (num < P_0.Length)
		{
			byte b = P_0[num++];
			if (b != byte.MaxValue)
			{
				memoryStream.WriteByte(b);
				continue;
			}
			byte b2 = P_0[num++];
			byte value = byte.MaxValue;
			if (b2 >= 3)
			{
				value = P_0[num++];
			}
			for (int i = 0; i <= b2; i++)
			{
				memoryStream.WriteByte(value);
			}
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MemoryStream T8BSPuY023C(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < P_0.Length; i++)
		{
			byte b = P_0[i];
			if (i < P_0.Length - 1 && b == P_0[i + 1])
			{
				byte b2 = b;
				int num = 1;
				for (; i + 1 < P_0.Length && P_0[i + 1] == b2; i++)
				{
					if (num == 256)
					{
						break;
					}
					num++;
				}
				if (b2 == byte.MaxValue)
				{
					q7gSPQ71vvZ(num, memoryStream);
				}
				else
				{
					gARSPoN0F7y(b2, num, memoryStream);
				}
			}
			else
			{
				memoryStream.WriteByte(b);
				if (b == byte.MaxValue)
				{
					memoryStream.WriteByte(0);
				}
			}
		}
		return memoryStream;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void gARSPoN0F7y(byte P_0, int P_1, MemoryStream P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 > 3)
		{
			P_2.WriteByte(byte.MaxValue);
			P_2.WriteByte((byte)(P_1 - 1));
			P_2.WriteByte(P_0);
		}
		else
		{
			for (int i = 0; i < P_1; i++)
			{
				P_2.WriteByte(P_0);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void q7gSPQ71vvZ(int P_0, MemoryStream P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.WriteByte(byte.MaxValue);
		if (P_0 == 1)
		{
			P_1.WriteByte(0);
		}
		else
		{
			P_1.WriteByte((byte)(P_0 - 1));
		}
		if (P_0 > 3)
		{
			P_1.WriteByte(byte.MaxValue);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int rMDSPOktq2F(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 & 0x1F) + (P_1 & 0x1F) * 32;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int e1cSPCO6PUl(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1 = ((P_1 < 0) ? (P_1 + 1) : P_1);
		return P_0 + P_1 * 32;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int QdsSP76hcgY(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 < 0)
		{
			return P_0 - 32;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool zNZSPALhXMG(byte[] P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = rMDSPOktq2F(P_1, P_2);
		return P_0[num] != 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static short rLoSPdg2uBc(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short result = 0;
		if (P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
		{
			string key = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
			if (INYifyudg3hCpcrleHt.mXTS0yn6FgU().ContainsKey(key))
			{
				result = (short)INYifyudg3hCpcrleHt.mXTS0yn6FgU()[key].Id;
			}
			else if (ItemTranslations.BedrockItemsByName.ContainsKey(key))
			{
				result = (short)ItemTranslations.BedrockItemsByName[key].BedrockId;
			}
		}
		else
		{
			result = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeShort;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int rgNSPHt47SB(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		string text;
		if ((text = P_0) != null)
		{
			if (!(text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936)))
			{
				if (!(text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780)))
				{
					if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794))
					{
						result = 2;
					}
				}
				else
				{
					result = 1;
				}
			}
			else
			{
				result = 0;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int vADSPFUS622(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		int num2 = P_0 >> 5;
		int num3 = num2 + P_1;
		int num4 = P_0 % 32;
		if (num4 == 0 && P_0 < 0)
		{
			num4 = -32;
		}
		if (num2 < 0 && num3 >= 0)
		{
			num4 = 32 - Math.Abs(num4);
		}
		else if (num2 >= 0 && num3 < 0)
		{
			num4 = (32 - Math.Abs(num4)) * -1;
		}
		if (num3 < 0)
		{
			num3++;
		}
		return num3 * 32 + num4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int KmDSPjYqJTp(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 == 0)
		{
			return P_0;
		}
		int num = 0;
		int num2 = P_0 >> 4;
		int num3 = vADSPFUS622(num2, P_1);
		int num4 = P_0 % 16;
		if (num4 == 0 && P_0 < 0)
		{
			num4 = -16;
		}
		if (num2 < 0 && num3 >= 0)
		{
			num4 = 16 - Math.Abs(num4);
		}
		else if (num2 >= 0 && num3 < 0)
		{
			num4 = (16 - Math.Abs(num4)) * -1;
		}
		if (num3 < 0)
		{
			num3++;
		}
		return num3 * 16 + num4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FlatWorld ifaSP8IqSLO(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlatWorld result = null;
		try
		{
			if (!string.IsNullOrWhiteSpace(P_0))
			{
				JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
				result = javaScriptSerializer.Deserialize<FlatWorld>(P_0);
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ClQSP9TgpRp(TagNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 is TagNodeString)
		{
			return t3VSPzOdrQd(((TagNodeString)P_0).Data);
		}
		if (P_0 is TagNodeCompound)
		{
			return nPkSPIlVgkp(P_0 as TagNodeCompound);
		}
		return "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string nPkSPIlVgkp(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlatWorld flatWorld = new FlatWorld();
		List<FlatWorldBlockLayer> list = new List<FlatWorldBlockLayer>();
		string key = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214562)] as TagNodeString;
		if (BiomeLookup.name.ContainsKey(key))
		{
			flatWorld.biome_id = BiomeLookup.name[key].BedrockId;
		}
		TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214576)] as TagNodeList;
		for (int num = tagNodeList.Count - 1; num >= 0; num--)
		{
			TagNodeCompound tagNodeCompound = tagNodeList[num] as TagNodeCompound;
			FlatWorldBlockLayer flatWorldBlockLayer = new FlatWorldBlockLayer();
			flatWorldBlockLayer.block_name = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214592)] as TagNodeString;
			flatWorldBlockLayer.count = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73624)] as TagNodeByte;
			list.Add(flatWorldBlockLayer);
		}
		flatWorld.block_layers = list.ToArray();
		return flatWorld.ToBedrock();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string t3VSPzOdrQd(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return "";
		}
		FlatWorld flatWorld = new FlatWorld();
		string[] array = P_0.Split(';');
		if (array.Length > 3)
		{
			_ = array[0];
			int result = 0;
			int.TryParse(array[2].Trim(), out result);
			flatWorld.biome_id = result;
			string[] array2 = array[1].Split(',');
			List<FlatWorldBlockLayer> list = new List<FlatWorldBlockLayer>();
			for (int num = array2.Length - 1; num >= 0; num--)
			{
				if (array2[num].IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974)) >= 0)
				{
					int result2 = 1;
					string text = "";
					if (array2[num].IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10366)) > 0)
					{
						string[] array3 = array2[num].Split('*');
						int.TryParse(array3[0].Trim(), out result2);
						text = array3[1].Trim();
					}
					else
					{
						text = array2[num].Trim();
					}
					FlatWorldBlockLayer flatWorldBlockLayer = new FlatWorldBlockLayer();
					flatWorldBlockLayer.block_name = text;
					flatWorldBlockLayer.count = result2;
					list.Add(flatWorldBlockLayer);
				}
				flatWorld.block_layers = list.ToArray();
			}
		}
		return flatWorld.ToBedrock();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public lxe7hMuSirBXGUQugsD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int NjvSRTNa63L(ChunkIndexEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkIndex;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int VuLSRS6SgTW(ChunkIndexEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkIndex;
	}
}
