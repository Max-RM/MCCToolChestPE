using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCPELevelDBI.workers;
using Substrate.Nbt;
using t2dancj1aDNBEPVYsFL;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class ChangeBlockState
{
	private Dictionary<int, TagNodeCompound> U3E9LvNOpV;

	private BackgroundWorker q4I9g8PLD3;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChangeBlockState()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		U3E9LvNOpV = new Dictionary<int, TagNodeCompound>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChangeBlockState(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		U3E9LvNOpV = new Dictionary<int, TagNodeCompound>();
		q4I9g8PLD3 = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoChangeProcess()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = PEUtility.GetPEDimension(Constants.dimensionFolderNames[0]);
		DoChangeProcess(pEDimension, Working.T92StMGt1p4(), BlockStateFormatType.FORMAT_112);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoChangeProcess(PEDimension peDimension, string workingFolder, BlockStateFormatType formatType)
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
				s6x9U4nRAI(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63632) + text, (int)((float)num / (float)count * 100f));
				if (Nw292HWnAf(peDimension, value, formatType, levelDBWorker))
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
	private bool Nw292HWnAf(PEDimension P_0, PERegion P_1, BlockStateFormatType P_2, LevelDBWorker P_3)
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
				if (loA9yl4Wqq(P_0, P_1, lxe7hMuSirBXGUQugsD.QdsSP76hcgY(i, P_1.RX), lxe7hMuSirBXGUQugsD.QdsSP76hcgY(j, P_1.RZ), P_2, P_3))
				{
					result = true;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool loA9yl4Wqq(PEDimension P_0, PERegion P_1, int P_2, int P_3, BlockStateFormatType P_4, LevelDBWorker P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_2, P_1.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_3, P_1.RZ);
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		s6x9U4nRAI(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63676), P_1.ToString(), num, num2));
		if (P_1.Chunks[num3] == 1)
		{
			result = tpQ90imJxl(P_1.Dimension, P_1, num, num2, P_4, P_5);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool tpQ90imJxl(int P_0, PERegion P_1, int P_2, int P_3, BlockStateFormatType P_4, LevelDBWorker P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(P_2, P_3);
		bool result = false;
		if (P_1.Chunks[num] == 1)
		{
			byte[] array = PEUtility.BuildChunkKey(P_1.Dimension, P_2, P_3, 47, 0);
			for (byte b = 0; b < 16; b++)
			{
				array[array.Length - 1] = b;
				byte[] array2 = P_5.ReadDbValue(array);
				if (array2 != null && (array2[0] == 1 || array2[0] >= 8 || array2.Length < 6145) && (array2[0] == 1 || array2[0] == 8) && JCd9BkR2uI(array, b, array2, P_4, P_5))
				{
					result = true;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool JCd9BkR2uI(byte[] P_0, int P_1, byte[] P_2, BlockStateFormatType P_3, LevelDBWorker P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		TagNodeList tagNodeList = BlockStorageSection(P_2);
		for (int i = 0; i < tagNodeList.Count; i++)
		{
			TagNodeCompound tagNodeCompound = tagNodeList[i] as TagNodeCompound;
			if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)))
			{
				continue;
			}
			TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] as TagNodeList;
			for (int j = 0; j < tagNodeList2.Count; j++)
			{
				TagNodeCompound tagNodeCompound2 = tagNodeList2[j] as TagNodeCompound;
				BlockStateFormatType blockStateFormatType = ((!tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876))) ? BlockStateFormatType.FORMAT_113 : BlockStateFormatType.FORMAT_112);
				if (blockStateFormatType != P_3)
				{
					switch (blockStateFormatType)
					{
					case BlockStateFormatType.FORMAT_112:
						ChangeTo113Palette(tagNodeCompound2);
						break;
					case BlockStateFormatType.FORMAT_113:
						pg09ttcj1b(tagNodeCompound2);
						break;
					}
					YCv9xbjynp(P_0, P_1, tagNodeList, P_4);
					result = true;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeTo113Palette(TagNodeCompound paletteEntry)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string name = paletteEntry[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] as TagNodeString;
		short num = paletteEntry[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)] as TagNodeShort;
		BlockState bedrockBlockState = BlockMaster.GetBedrockBlockState(name, num);
		bedrockBlockState.data = num;
		ConvertDataValueToBlockStates(paletteEntry, bedrockBlockState);
		paletteEntry.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876));
		paletteEntry[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19874)] = new TagNodeInt(17760256);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pg09ttcj1b(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ConvertBlockStatesToDataValue(P_0);
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)] = new TagNodeShort((short)num);
		P_0.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19874));
		P_0.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int ConvertBlockStatesToDataValue(TagNodeCompound paletteEntry)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string name = paletteEntry[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] as TagNodeString;
		TagNodeCompound values = null;
		if (paletteEntry.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892)))
		{
			values = paletteEntry[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892)] as TagNodeCompound;
		}
		BlockState bedrockBlockState = BlockMaster.GetBedrockBlockState(name, values);
		return s2K9af1ijS(paletteEntry, bedrockBlockState);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int s2K9af1ijS(TagNodeCompound P_0, BlockState P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		try
		{
			num = P_1.data;
			string blockStates = P_1.masterBlock.blockStates;
			if (blockStates != null && BlockMaster.DataStates.ContainsKey(blockStates))
			{
				List<BlockStateDefinition> blockStates2 = BlockMaster.DataStates[blockStates].blockStates;
				if (P_1.properties != null)
				{
					foreach (MasterBlockItemProperty property in P_1.properties)
					{
						foreach (BlockStateDefinition item in blockStates2)
						{
							if (!(item.bedrockName == property.name))
							{
								continue;
							}
							for (int i = 0; i < item.states.Length; i++)
							{
								if (property.value == item.states[i].bedrockPropertyValue)
								{
									num |= item.states[i].bedrock;
									break;
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConvertDataValueToBlockStates(TagNodeCompound paletteEntry, BlockState bbs)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		try
		{
			int data = bbs.data;
			string blockStates = bbs.masterBlock.blockStates;
			if (bbs.masterBlock.bedrock.properties != null)
			{
				foreach (MasterBlockItemProperty property in bbs.masterBlock.bedrock.properties)
				{
					if (property.name != null)
					{
						tagNodeCompound[property.name] = Pc59Xu1met(property.nbtType, property.value);
					}
				}
			}
			if (blockStates != null && BlockMaster.DataStates.ContainsKey(blockStates))
			{
				List<BlockStateDefinition> blockStates2 = BlockMaster.DataStates[blockStates].blockStates;
				foreach (BlockStateDefinition item in blockStates2)
				{
					if (item.bedrockMask <= 0 || string.IsNullOrWhiteSpace(item.bedrockName))
					{
						continue;
					}
					int num = data & item.bedrockMask;
					for (int i = 0; i < item.states.Length; i++)
					{
						if (num == item.states[i].bedrock)
						{
							tagNodeCompound[item.bedrockName] = Pc59Xu1met(item.bedrockNbtType, item.states[i].bedrockPropertyValue);
							break;
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
		paletteEntry[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892)] = tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNode Pc59Xu1met(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9862))
		{
			byte.TryParse(P_1, out var result);
			return new TagNodeByte(result);
		}
		if (P_0 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9844))
		{
			int.TryParse(P_1, out var result2);
			return new TagNodeInt(result2);
		}
		return new TagNodeString(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YCv9xbjynp(byte[] P_0, int P_1, TagNodeList P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)P_1);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = new TagNodeByte(1);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] = P_2;
		byte[] value = PEUtility.BuildBlockStateChunk(tagNodeCompound);
		P_3.Put(P_0, value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] ABl9eC6Bum(pq4QvWjGbnFyoqlVrDa P_0)
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
	private void wVI9MII4oC(int P_0, int P_1, int P_2, LevelDBWorker P_3)
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
	public static TagNodeList BlockStorageSection(byte[] peSection)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 1;
		int num2 = 1;
		if (peSection[0] == 8)
		{
			num = peSection[1];
			num2++;
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		for (int i = 0; i < num; i++)
		{
			int[] array = new int[4096];
			num2 = ProcessBlockStorage(peSection, array, num2);
			int bytesRead = 0;
			byte[] paletteData = peSection.Skip(num2).Take(peSection.Length - num2).ToArray();
			TagNodeList value = PEUtility.ReadPaletteEntries(paletteData, out bytesRead);
			num2 += bytesRead;
			TagNodeCompound tagNodeCompound = new TagNodeCompound();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(array);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = value;
			tagNodeList.Add(tagNodeCompound);
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ProcessBlockStorage(byte[] peSection, int[] blocks, int readPosition)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new TagNodeCompound();
		_ = peSection[readPosition];
		int num = peSection[readPosition] >> 1;
		readPosition++;
		int num2 = (int)Math.Floor((decimal)(32 / num));
		int num3 = (int)Math.Ceiling(4096.0 / (double)num2);
		uint num4 = (uint)((1 << num) - 1);
		int num5 = 0;
		for (int i = 0; i < num3; i++)
		{
			uint num6 = PEUtility.ReadWord(peSection, readPosition);
			for (int j = 0; j < num2; j++)
			{
				if (num5 >= 4096)
				{
					break;
				}
				int num7 = (int)((num6 >> j * num) & num4);
				blocks[num5] = num7;
				num5++;
			}
			readPosition += 4;
		}
		return readPosition;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void s6x9U4nRAI(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (q4I9g8PLD3 != null)
		{
			q4I9g8PLD3.ReportProgress(P_1, P_0);
		}
	}
}
