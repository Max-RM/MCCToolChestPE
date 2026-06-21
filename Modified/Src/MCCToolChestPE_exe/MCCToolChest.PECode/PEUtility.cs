using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using DekWW8jSE3fVOo1d5ao;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.utils;
using MCPELevelDBI.workers;
using OAxWrWumnobfHyEL9yr;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.PECode;

public class PEUtility
{
	[CompilerGenerated]
	private static Func<BlockState, int> TQnSWzJYYMH;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LevelDBWorker OpenDBWorker(string path, bool createIfNotExist = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = new LevelDBWorker();
		levelDBWorker.OpenDB(Path.Combine(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)), createIfNotExist);
		levelDBWorker.DBPath = path;
		return levelDBWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] BuildChunkKey(int x, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v(false);
		nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(x, memoryStream);
		nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(z, memoryStream);
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] BuildChunkKey(int dim, int x, int z, byte dataType, byte? subchunk = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v(false);
		nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(x, memoryStream);
		nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(z, memoryStream);
		if (dim != 0)
		{
			nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(dim, memoryStream);
		}
		memoryStream.WriteByte(dataType);
		if (subchunk.HasValue)
		{
			memoryStream.WriteByte(subchunk.Value);
		}
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound LoadPELevelRaw(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] source = FileUtils.pURSg6Zk53A(Path.Combine(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)));
		MemoryStream s = new MemoryStream(source.Skip(8).ToArray());
		NbtTree nbtTree = new NbtTree();
		nbtTree.UseBigEndian = false;
		nbtTree.ReadFrom(s);
		return nbtTree.Root;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound LoadPELevel(string levelPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] buffer = FileUtils.pURSg6Zk53A(Path.Combine(levelPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)));
		MemoryStream s = new MemoryStream(buffer);
		NbtTree nbtTree = new NbtTree(s);
		return nbtTree.Root;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ChangeLevelName(string levelName, string levelPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = LoadPELevel(levelPath);
		if (tagNodeCompound != null)
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)] = new TagNodeString(levelName);
			long d = Utils.DateTimeToUnixTimestamp() / 1000;
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71344)] = new TagNodeLong(d);
			string text = Path.Combine(levelPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516));
			lxe7hMuSirBXGUQugsD.EAISPUuIyGd(tagNodeCompound, text);
		}
		File.WriteAllText(Path.Combine(levelPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810)), levelName);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetNameFromId(int id)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = "";
		if (hvd0XujpavSpj5UhiI6.eCfSVZfnEaD().ContainsKey(id))
		{
			text = hvd0XujpavSpj5UhiI6.eCfSVZfnEaD()[id].Name;
		}
		else if (hvd0XujpavSpj5UhiI6.WBHSVsHEOJC().ContainsKey(id))
		{
			text = hvd0XujpavSpj5UhiI6.WBHSVsHEOJC()[id].Name;
		}
		return text.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974), "");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PEDimension GetPEDimension(string dimension)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Working.PEDimensions == null || string.IsNullOrEmpty(dimension))
		{
			return null;
		}
		int dimensionId = Constants.GetDimensionId(dimension);
		if (dimensionId < 0 || dimensionId >= Working.PEDimensions.Count)
		{
			return null;
		}
		return Working.PEDimensions[dimensionId];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemovePEDimensionRegion(string dimension, string region)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = GetPEDimension(dimension);
		pEDimension?.Region.Remove(region.Remove(0, 2));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ConvertIDsToPC(TagNodeList entityList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = "";
		for (int i = 0; i < entityList.Count; i++)
		{
			text = "";
			TagNodeCompound tagNodeCompound = entityList[i] as TagNodeCompound;
			if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
			{
				continue;
			}
			if (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeInt)
			{
				int key = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeInt;
				if (hvd0XujpavSpj5UhiI6.eCfSVZfnEaD().ContainsKey(key))
				{
					text = hvd0XujpavSpj5UhiI6.eCfSVZfnEaD()[key].Name;
				}
				else if (hvd0XujpavSpj5UhiI6.WBHSVsHEOJC().ContainsKey(key))
				{
					text = hvd0XujpavSpj5UhiI6.WBHSVsHEOJC()[key].Name;
				}
			}
			else if (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				text = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
			}
			text = text.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974), "");
			if (!string.IsNullOrWhiteSpace(text))
			{
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeString(text);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ConvertIDsToPE(TagNodeList entityList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int num = entityList.Count - 1; num >= 0; num--)
		{
			TagNodeCompound tagNodeCompound = entityList[num] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				string text = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974) + text;
				if (hvd0XujpavSpj5UhiI6.lfnSVhSnc0q().ContainsKey(text))
				{
					int d = hvd0XujpavSpj5UhiI6.lfnSVhSnc0q()[text].YhxSVSwIOdw();
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeInt(d);
				}
				else
				{
					entityList.Remove(tagNodeCompound);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint ReadWord(byte[] peSection, int index)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			array[i] = peSection[index + i];
		}
		return BitConverter.ToUInt32(array, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeList ReadPaletteEntries(byte[] PaletteData, out int bytesRead)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v();
		nJVJiCuZKORGPYB1Y4v.S6FSRREan0P(false);
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		MemoryStream memoryStream = new MemoryStream(PaletteData);
		int num = nJVJiCuZKORGPYB1Y4v.PsDSRt4knGJ(memoryStream);
		for (int i = 0; i < num; i++)
		{
			NbtTree nbtTree = new NbtTree(memoryStream);
			if (nbtTree.Root != null)
			{
				tagNodeList.Add(nbtTree.Root);
			}
		}
		bytesRead = (int)memoryStream.Position;
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WritePaletteEntries(MemoryStream stream, TagNodeList paletteList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v();
		nJVJiCuZKORGPYB1Y4v.S6FSRREan0P(false);
		nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(paletteList.Count, stream);
		for (int i = 0; i < paletteList.Count; i++)
		{
			MemoryStream memoryStream = new MemoryStream();
			TagNodeCompound tree = paletteList[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream);
			stream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlockState[] GetBlockStatesFromPalette(TagNodeList PaletteEntries)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockState[] array = new BlockState[PaletteEntries.Count];
		for (int i = 0; i < PaletteEntries.Count; i++)
		{
			TagNodeCompound tagNodeCompound = PaletteEntries[i] as TagNodeCompound;
			string name = (TagNodeString)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)];
			short num = 0;
			BlockState blockState = null;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)))
			{
				num = (TagNodeShort)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)];
				blockState = BlockMaster.GetBedrockBlockState(name, num);
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
			array[i] = blockState;
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dictionary<string, MasterBlockItemProperty> ExtractBedrockPropertyStates(TagNodeCompound states)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, MasterBlockItemProperty> dictionary = new Dictionary<string, MasterBlockItemProperty>();
		if (states != null)
		{
			foreach (string key in states.Keys)
			{
				if (states[key] is TagNodeByte)
				{
					dictionary.Add(key, new MasterBlockItemProperty(key, (states[key] as TagNodeByte).ToString()));
				}
				else if (states[key] is TagNodeInt)
				{
					dictionary.Add(key, new MasterBlockItemProperty(key, (states[key] as TagNodeInt).ToString()));
				}
				else if (states[key] is TagNodeString)
				{
					dictionary.Add(key, new MasterBlockItemProperty(key, states[key] as TagNodeString));
				}
			}
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int PaletteBitsPerBlock(int paletteCount)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (paletteCount <= 2)
		{
			result = 1;
		}
		else if (paletteCount <= 4)
		{
			result = 2;
		}
		else if (paletteCount <= 8)
		{
			result = 3;
		}
		else if (paletteCount <= 16)
		{
			result = 4;
		}
		else if (paletteCount <= 32)
		{
			result = 5;
		}
		else if (paletteCount <= 64)
		{
			result = 6;
		}
		else if (paletteCount <= 256)
		{
			result = 8;
		}
		else if (paletteCount <= 65023)
		{
			result = 16;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeList BuildNBTPalette(Dictionary<string, Dictionary<short, BlockState>> paletteEntries, ConversionFormat format = ConversionFormat.Aquatic)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockState> list = new List<BlockState>();
		foreach (string key in paletteEntries.Keys)
		{
			foreach (short key2 in paletteEntries[key].Keys)
			{
				list.Add(paletteEntries[key][key2]);
			}
		}
		list = list.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (BlockState P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.paletteIndex;
		}).ToList();
		return BuildNBTPalette(list, format);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeList BuildNBTPalette(List<BlockState> paletteEntries, ConversionFormat format = ConversionFormat.Aquatic)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChangeBlockState changeBlockState = new ChangeBlockState();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		foreach (BlockState paletteEntry in paletteEntries)
		{
			TagNodeCompound tagNodeCompound = new TagNodeCompound();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] = new TagNodeString(paletteEntry.name);
			if (format == ConversionFormat.Aquatic113)
			{
				changeBlockState.ConvertDataValueToBlockStates(tagNodeCompound, paletteEntry);
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19874)] = new TagNodeInt(17760256);
			}
			else
			{
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)] = new TagNodeShort(paletteEntry.data);
			}
			tagNodeList.Add(tagNodeCompound);
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] BuildBlockStateChunk(TagNodeCompound node)
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
				int num = PaletteBitsPerBlock(count2);
				int num2 = (int)Math.Floor((decimal)(32 / num));
				int num3 = (int)Math.Ceiling(4096.0 / (double)num2);
				int num4 = (1 << num) - 1;
				int[] data = ((TagNodeIntArray)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)]).Data;
				MemoryStream memoryStream = new MemoryStream();
				int num5 = 0;
				for (int j = 0; j < num3; j++)
				{
					uint num6 = 0u;
					List<int> list = new List<int>();
					for (int k = 0; k < num2; k++)
					{
						if (num5 >= 4096)
						{
							break;
						}
						list.Add(data[num5]);
						num5++;
					}
					for (int num7 = list.Count - 1; num7 >= 0; num7--)
					{
						num6 <<= num;
						int num8 = list[num7];
						num6 |= (uint)(num8 & num4);
					}
					byte[] bytes = BitConverter.GetBytes(num6);
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
			WritePaletteEntries(memoryStream2, array[0].palette);
			if (count == 2)
			{
				memoryStream2.WriteByte((byte)(array[1].bitsPerBlock << 1));
				memoryStream2.Write(array[1].blocks, 0, array[1].blocks.Length);
				WritePaletteEntries(memoryStream2, array[1].palette);
			}
			return memoryStream2.ToArray();
		}
		return null;
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
			TagNodeList value = ReadPaletteEntries(paletteData, out bytesRead);
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
			uint num6 = ReadWord(peSection, readPosition);
			for (int j = 0; j < num2; j++)
			{
				if (num5 >= 4096)
				{
					break;
				}
				int num7 = (int)((num6 >> j * num) & num4);
				int num8 = (num5 >> 8) & 0xF;
				int num9 = num5 & 0xF;
				int num10 = (num5 >> 4) & 0xF;
				int num11 = num9 * 256 + num10 * 16 + num8;
				blocks[num11] = num7;
				num5++;
			}
			readPosition += 4;
		}
		return readPosition;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeList ExtractTileEntities(byte[] BlockEntity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		try
		{
			if (BlockEntity != null)
			{
				MemoryStream memoryStream = new MemoryStream(BlockEntity);
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
	public PEUtility()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int xPaSWImir7p(BlockState P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.paletteIndex;
	}
}
