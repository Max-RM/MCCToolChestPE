using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using DAlUunjC9jvW7R1ygAE;
using MCCToolChest.MCSBCode.JSONParser;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.PECode.model;
using MCCToolChest.utils;
using MCCToolChest.workers.converterHelpers;
using Substrate;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class ConvertToPCFromPE
{
	public delegate void ToJavaFunction(MCCToolChest.model.BlockState bs, int ySection, int x, int y, int z, int[] blocks, List<MCCToolChest.model.BlockState> bedreckBlockStates);

	private Dictionary<string, BlockHandlerBedrockToJava> LSjSSCfZR6f;

	private JavaFromBedrockItemConverter SiYSS7Zs4Du;

	private Dictionary<int, List<int>> UbmSSA9v1UZ;

	private ConvertToPCParameters v0nSSdDkyMx;

	private EntityLookup S07SSHOEy4p;

	private TileEntityLookup cTPSSFpkKVb;

	private bool[] kIhSSjfDZOf;

	private int pxGSS8IsrSr;

	private int OXxSS9QLk5s;

	private Dictionary<int, List<MasterBlockItemProperty>> NuuSSIHPrj5;

	private int Tv8SSz5OgmQ;

	private int DgXSGTG0XoV;

	private int JvXSGSPPt4U;

	private ChunkSectionManager vjwSGGOipdZ;

	public Dictionary<string, ToJavaFunction> toJavaFunctions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConvertRegionFileToPC(object threadContext)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (threadContext is ConvertToPCParameters convertToPCParameters)
		{
			v0nSSdDkyMx = convertToPCParameters;
			string regionName = convertToPCParameters.RegionName;
			if (convertToPCParameters.ConvertParameters.UseConvertOffsets)
			{
				regionName = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69594), convertToPCParameters.PERegion.RX + convertToPCParameters.ConvertParameters.XRegionOffset, convertToPCParameters.PERegion.RZ + convertToPCParameters.ConvertParameters.ZRegionOffset);
			}
			LSjSSCfZR6f = new Dictionary<string, BlockHandlerBedrockToJava> { 
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69616),
				vToSSNx1Vi9
			} };
			vjwSGGOipdZ = new ChunkSectionManager(LSjSSCfZR6f);
			ConvertRegionFileToPC(convertToPCParameters.PERegion, convertToPCParameters.RegionFolder, regionName, convertToPCParameters.WorkingFolder, convertToPCParameters.ConvertParameters);
			convertToPCParameters.DoneEvent.Set();
			convertToPCParameters.Done = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConvertRegionFileToPC(PERegionChunks peRegion, string regionFolder, string regionName, string workingFolderPath, ConvertParameters convertParameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		toJavaFunctions.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69638), FcTSS1xEbsa);
		toJavaFunctions.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69672), BjsSSMeJQ7B);
		toJavaFunctions.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69694), c2jSSYcWCsn);
		toJavaFunctions.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69732), GB7SSeaoNdj);
		ChunkIndexEntry[] array = null;
		string text = ((regionFolder.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936)) ? regionFolder : (regionFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64928)));
		string text2 = convertParameters.PCWorldFolder + text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100);
		string text3 = text2 + regionName + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64946);
		kIhSSjfDZOf = Utils.GetQuickBlocksLookup(convertParameters);
		pxGSS8IsrSr = Working.rvNSt1TVRGQ();
		OXxSS9QLk5s = Working.P5gSt5TkeBq();
		FileUtils.TTSSgQ9uTyR(text2);
		if (!File.Exists(text3))
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text3, FileMode.Create)))
			{
				lxe7hMuSirBXGUQugsD.wZ4SPffRUG3(binaryWriter);
			}
			array = lxe7hMuSirBXGUQugsD.gCmSg9Efe8W().ToArray();
		}
		else
		{
			array = lxe7hMuSirBXGUQugsD.kM7SgjjqASt(text3).ToArray();
		}
		using BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(text3, FileMode.Open));
		binaryWriter2.Seek(0, SeekOrigin.End);
		foreach (PEChunkData value in peRegion.Chunks.Values)
		{
			int num = lxe7hMuSirBXGUQugsD.wXGSPvWZmex(value.X, value.Z);
			ChunkIndexEntry chunkIndexEntry = array[num];
			byte[] array2 = YppSSpyXiRC(value, convertParameters);
			if (array2 != null && array2.Length > 0)
			{
				long num2 = ((array2.Length % 4096 != 0) ? (4096 - array2.Length % 4096) : 0);
				chunkIndexEntry.NewChunkOffset = (uint)(binaryWriter2.BaseStream.Position / 4096);
				chunkIndexEntry.NewChunkLength = (byte)((array2.Length + num2) / 4096);
				binaryWriter2.Write(array2, 0, array2.Length);
				for (int i = 0; i < num2; i++)
				{
					binaryWriter2.Write((byte)0);
				}
				if (v0nSSdDkyMx != null)
				{
					v0nSSdDkyMx.ProcessedChunkCount++;
				}
			}
		}
		lxe7hMuSirBXGUQugsD.rjsSPmBeBNR(binaryWriter2, array.ToList());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal byte[] YppSSpyXiRC(PEChunkData P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = null;
		try
		{
			NuuSSIHPrj5 = new Dictionary<int, List<MasterBlockItemProperty>>();
			array = ((P_1.ConvertToFormat != ConversionFormat.PreAquatic) ? vS5SSfMwgLw(P_0, P_1) : XHySSZwsfAx(P_0, P_1));
			if (array != null)
			{
				array = lxe7hMuSirBXGUQugsD.byDSPrUjE5G(array);
				byte[] bytes = BitConverter.GetBytes(array.Length + 1);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(bytes);
				}
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(bytes, 0, bytes.Length);
				memoryStream.WriteByte(2);
				memoryStream.Write(array, 0, array.Length);
				array = memoryStream.ToArray();
			}
		}
		catch (Exception)
		{
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] XHySSZwsfAx(PEChunkData P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = null;
		TagNodeByteArray tagNodeByteArray = new TagNodeByteArray(new byte[256]);
		TagNodeIntArray tagNodeIntArray = new TagNodeIntArray(new int[256]);
		TagNodeList value = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeList value2 = new TagNodeList(TagType.TAG_COMPOUND);
		new TagNodeList(TagType.TAG_COMPOUND);
		tagNodeList = ((!P_0.ChunkData.ContainsKey(48) || P_0.BlockSections.Count != 0) ? K5qSSsfZpo7(P_0.BlockSections) : hxqSSijW8IQ(P_0.ChunkData[48]));
		if (P_0.ChunkData.ContainsKey(49))
		{
			TagNodeList tagNodeList2 = PEUtility.ExtractTileEntities(P_0.ChunkData[49]);
			value = lfQSScEZ96T(tagNodeList2);
		}
		if (P_0.ChunkData.ContainsKey(50))
		{
			TagNodeList tagNodeList3 = PEUtility.ExtractTileEntities(P_0.ChunkData[50]);
			value2 = zBxSSOyTtMw(tagNodeList3, P_1);
		}
		if (P_0.ChunkData.ContainsKey(45))
		{
			byte[] array = P_0.ChunkData[45];
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					int index = (j << 4) | i;
					int num = (j << 4) | (i + 512);
					tagNodeByteArray[index] = array[num];
				}
			}
			for (int k = 0; k < 256; k++)
			{
				tagNodeIntArray[k] = BitConverter.ToInt16(array, k * 2);
			}
		}
		int num2 = P_0.X;
		int num3 = P_0.Z;
		if (v0nSSdDkyMx.ConvertParameters.UseConvertOffsets)
		{
			num2 = lxe7hMuSirBXGUQugsD.vADSPFUS622(num2, v0nSSdDkyMx.ConvertParameters.XRegionOffset);
			num3 = lxe7hMuSirBXGUQugsD.vADSPFUS622(num3, v0nSSdDkyMx.ConvertParameters.ZRegionOffset);
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548), tagNodeList);
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65008), tagNodeIntArray);
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992), tagNodeByteArray);
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124), value2);
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796), value);
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984), new TagNodeInt(num2));
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996), new TagNodeInt(num3));
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69758), new TagNodeByte(1));
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69794), new TagNodeByte(0));
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69826), new TagNodeLong(0L));
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69856), new TagNodeLong(0L));
		MemoryStream memoryStream = new MemoryStream();
		NbtTree nbtTree = new NbtTree();
		nbtTree.UseBigEndian = true;
		nbtTree.Root.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204), tagNodeCompound);
		nbtTree.Root.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64958), new TagNodeInt(1343));
		nbtTree.WriteTo(memoryStream);
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] vS5SSfMwgLw(PEChunkData P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Tv8SSz5OgmQ = P_0.X;
		DgXSGTG0XoV = 0;
		JvXSGSPPt4U = P_0.Z;
		TagNodeList tagNodeList = null;
		TagNodeIntArray tagNodeIntArray = new TagNodeIntArray(new int[256]);
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeList tagNodeList3 = new TagNodeList(TagType.TAG_COMPOUND);
		new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69880)] = new TagNodeByteArray(new byte[0]);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69890)] = new TagNodeByteArray(new byte[0]);
		TagNodeCompound value = new TagNodeCompound();
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69906)] = new TagNodeByteArray(new byte[0]);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69930)] = new TagNodeByteArray(new byte[0]);
		TagNodeList tagNodeList4 = null;
		if (P_0.ChunkData.ContainsKey(49))
		{
			try
			{
				tagNodeList4 = PEUtility.ExtractTileEntities(P_0.ChunkData[49]);
				tagNodeList2 = lfQSScEZ96T(tagNodeList4);
			}
			catch (Exception)
			{
			}
		}
		TagNodeList tagNodeList5 = null;
		if (P_0.ChunkData.ContainsKey(50))
		{
			try
			{
				tagNodeList5 = PEUtility.ExtractTileEntities(P_0.ChunkData[50]);
				tagNodeList3 = zBxSSOyTtMw(tagNodeList5, P_1);
			}
			catch (Exception)
			{
			}
		}
		WorkingEntitiesData workingEntitiesData = new WorkingEntitiesData();
		workingEntitiesData.BedrockEntities = tagNodeList5;
		workingEntitiesData.BedrockTileEntities = tagNodeList4;
		workingEntitiesData.JavaEntities = tagNodeList3;
		workingEntitiesData.JavaTileEntities = tagNodeList2;
		WorkingEntitiesData workingEntitiesData2 = workingEntitiesData;
		tagNodeList = ((!P_0.ChunkData.ContainsKey(48) || P_0.BlockSections.Count != 0) ? oY9SSm4pdQO(P_0.BlockSections, workingEntitiesData2) : esbSSnSlBVL(P_0.ChunkData[48], workingEntitiesData2));
		if (P_0.ChunkData.ContainsKey(45))
		{
			byte[] array = P_0.ChunkData[45];
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					int index = (j << 4) | i;
					int num = (j << 4) | (i + 512);
					tagNodeIntArray[index] = array[num];
				}
			}
		}
		int num2 = P_0.X;
		int num3 = P_0.Z;
		if (v0nSSdDkyMx.ConvertParameters.UseConvertOffsets)
		{
			num2 = lxe7hMuSirBXGUQugsD.vADSPFUS622(num2, v0nSSdDkyMx.ConvertParameters.XRegionOffset);
			num3 = lxe7hMuSirBXGUQugsD.vADSPFUS622(num3, v0nSSdDkyMx.ConvertParameters.ZRegionOffset);
		}
		TagNodeCompound tagNodeCompound3 = new TagNodeCompound();
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984), new TagNodeInt(num2));
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996), new TagNodeInt(num3));
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65030), value);
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69946), tagNodeCompound);
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69974), tagNodeCompound2);
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548), tagNodeList);
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992), tagNodeIntArray);
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124), tagNodeList3);
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796), tagNodeList2);
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69856), new TagNodeLong(0L));
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69826), new TagNodeLong(0L));
		tagNodeCompound3.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62604), new TagNodeString(P_1.ChunkStatus));
		MemoryStream memoryStream = new MemoryStream();
		NbtTree nbtTree = new NbtTree();
		nbtTree.UseBigEndian = true;
		nbtTree.Root.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204), tagNodeCompound3);
		if (P_1.ConvertToFormat == ConversionFormat.Aquatic113)
		{
			nbtTree.Root.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64958), new TagNodeInt(1628));
		}
		else if (P_1.ConvertToFormat == ConversionFormat.Aquatic)
		{
			nbtTree.Root.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64958), new TagNodeInt(1976));
		}
		nbtTree.WriteTo(memoryStream);
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList hxqSSijW8IQ(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = v0nSSdDkyMx.ConvertParameters;
		NibbleSetters nibbleSetters = new NibbleSetters();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		byte[] data = P_0.Skip(32768).Take(16384).ToArray();
		byte[] data2 = P_0.Skip(49152).Take(16384).ToArray();
		byte[] data3 = P_0.Skip(65536).Take(16384).ToArray();
		byte[] array = new byte[32768];
		byte[] array2 = new byte[16384];
		byte[] array3 = new byte[16384];
		byte[] array4 = new byte[16384];
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 128; k++)
				{
					int num = i * 2048 + j * 128 + k;
					byte inBlock = P_0[num];
					int inData = nibbleSetters.TU17GetFast(data, num);
					int val = nibbleSetters.TU17GetFast(data2, num);
					int val2 = nibbleSetters.TU17GetFast(data3, num);
					byte b = 0;
					byte val3 = 0;
					BlockConversionDefinition blockConversionDefinition = BlockMaster.JavaFromBedrockBlock(inBlock, inData);
					if (blockConversionDefinition.id < 256)
					{
						b = (byte)blockConversionDefinition.id;
						val3 = (byte)blockConversionDefinition.data;
					}
					int num2 = k * 256 + j * 16 + i;
					array[num2] = b;
					nibbleSetters.TU17SetFast(array2, num2, val3);
					nibbleSetters.TU17SetFast(array3, num2, val);
					nibbleSetters.TU17SetFast(array4, num2, val2);
				}
			}
		}
		for (int l = 0; l < 8; l++)
		{
			AnvilSection anvilSection = new AnvilSection(l);
			array.Skip(4096 * l).Take(4096).ToArray()
				.CopyTo(anvilSection.Blocks.Data, 0);
			array2.Skip(2048 * l).Take(2048).ToArray()
				.CopyTo(anvilSection.Data.Data, 0);
			array3.Skip(2048 * l).Take(2048).ToArray()
				.CopyTo(anvilSection.SkyLight.Data, 0);
			array4.Skip(2048 * l).Take(2048).ToArray()
				.CopyTo(anvilSection.BlockLight.Data, 0);
			tagNodeList.Add(anvilSection.BuildTree());
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList K5qSSsfZpo7(Dictionary<int, byte[]> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		int[] array = P_0.Keys.ToArray();
		int[] array2 = array;
		foreach (int num in array2)
		{
			byte[] array3 = P_0[num];
			if (array3 == null)
			{
				break;
			}
			if (array3[0] != 1 && array3[0] != 8 && array3.Length >= 6145)
			{
				TagNodeCompound item = I2ySSq7wEpu(array3, num);
				tagNodeList.Add(item);
			}
			else if (array3[0] == 1 || array3[0] == 8)
			{
				TagNodeCompound item2 = QBpSSKd2k1L(array3, num);
				tagNodeList.Add(item2);
			}
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound I2ySSq7wEpu(byte[] P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = v0nSSdDkyMx.ConvertParameters;
		NibbleSetters nibbleSetters = new NibbleSetters();
		byte[] data = P_0.Skip(4097).Take(2048).ToArray();
		byte[] array = null;
		byte[] array2 = null;
		byte[] array3 = new byte[4096];
		byte[] array4 = new byte[2048];
		array = new byte[2048];
		for (int i = 0; i < 2048; i++)
		{
			array[i] = byte.MaxValue;
		}
		array2 = new byte[2048];
		for (int j = 0; j < 2048; j++)
		{
			array2[j] = byte.MaxValue;
		}
		for (int k = 0; k < 16; k++)
		{
			for (int l = 0; l < 16; l++)
			{
				for (int m = 0; m < 16; m++)
				{
					int num = k * 256 + l * 16 + m + 1;
					int inBlock = P_0[num];
					num--;
					int inData = nibbleSetters.TU17GetFast(data, num);
					byte b = 0;
					byte val = 0;
					BlockConversionDefinition blockConversionDefinition = BlockMaster.JavaFromBedrockBlock(inBlock, inData);
					if (blockConversionDefinition.id < 256)
					{
						b = (byte)blockConversionDefinition.id;
						val = (byte)blockConversionDefinition.data;
					}
					int num2 = m * 256 + l * 16 + k;
					array3[num2] = b;
					nibbleSetters.TU17SetFast(array4, num2, val);
				}
			}
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)P_1);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] = new TagNodeByteArray(array3);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] = new TagNodeByteArray(array4);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69998)] = new TagNodeByteArray(array);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70018)] = new TagNodeByteArray(array2);
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound QBpSSKd2k1L(byte[] P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = v0nSSdDkyMx.ConvertParameters;
		NibbleSetters nibbleSetters = new NibbleSetters();
		byte[] array = new byte[4096];
		byte[] array2 = new byte[2048];
		int num = 1;
		if (P_0[0] == 8)
		{
			_ = P_0[num];
			num++;
		}
		_ = P_0[num];
		int num2 = P_0[num] >> 1;
		num++;
		int num3 = (int)Math.Floor((decimal)(32 / num2));
		int num4 = (int)Math.Ceiling(4096.0 / (double)num3);
		uint num5 = (uint)((1 << num2) - 1);
		int num6 = num4 * 4 + num;
		byte[] paletteData = P_0.Skip(num6).Take(P_0.Length - num6).ToArray();
		int bytesRead = 0;
		TagNodeList paletteEntries = PEUtility.ReadPaletteEntries(paletteData, out bytesRead);
		MCCToolChest.model.BlockState[] blockStatesFromPalette = PEUtility.GetBlockStatesFromPalette(paletteEntries);
		J94SShDA0UU(blockStatesFromPalette);
		int num7 = 0;
		for (int i = 0; i < num4; i++)
		{
			uint num8 = PEUtility.ReadWord(P_0, num);
			for (int j = 0; j < num3; j++)
			{
				if (num7 >= 4096)
				{
					break;
				}
				int num9 = (int)((num8 >> j * num2) & num5);
				if (num9 < blockStatesFromPalette.Length)
				{
					int num10 = (num7 >> 8) & 0xF;
					int num11 = num7 & 0xF;
					int num12 = (num7 >> 4) & 0xF;
					int num13 = num11 * 256 + num12 * 16 + num10;
					int num14 = blockStatesFromPalette[num9].id.Value;
					int data = blockStatesFromPalette[num9].data;
					if (num14 > 255 || num14 < 0)
					{
						num14 = 0;
					}
					int num15 = 0;
					int val = 0;
					try
					{
						BlockConversionDefinition blockConversionDefinition = BlockMaster.JavaFromBedrockBlock(num14, data);
						if (blockConversionDefinition.id < 256)
						{
							num15 = blockConversionDefinition.id;
							val = blockConversionDefinition.data;
						}
					}
					catch (Exception)
					{
					}
					array[num13] = (byte)num15;
					nibbleSetters.TU17SetFast(array2, num13, val);
				}
				num7++;
			}
			num += 4;
		}
		byte[] array3 = new byte[2048];
		for (int k = 0; k < 2048; k++)
		{
			array3[k] = byte.MaxValue;
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)P_1);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] = new TagNodeByteArray(array);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] = new TagNodeByteArray(array2);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69998)] = new TagNodeByteArray(array3);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70018)] = new TagNodeByteArray(array3);
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void J94SShDA0UU(MCCToolChest.model.BlockState[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (MCCToolChest.model.BlockState blockState in P_0)
		{
			if (!blockState.useProperties)
			{
				continue;
			}
			int num = blockState.data;
			string blockStates = blockState.masterBlock.blockStates;
			try
			{
				if (blockStates != null && BlockMaster.DataStates.ContainsKey(blockStates))
				{
					List<BlockStateDefinition> blockStates2 = BlockMaster.DataStates[blockStates].blockStates;
					if (blockState.properties != null)
					{
						foreach (MasterBlockItemProperty property in blockState.properties)
						{
							foreach (BlockStateDefinition item in blockStates2)
							{
								if (!(item.bedrockName == property.name))
								{
									continue;
								}
								for (int j = 0; j < item.states.Length; j++)
								{
									if (property.value == item.states[j].bedrockPropertyValue)
									{
										num |= item.states[j].bedrock;
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
			blockState.data = new TagNodeShort((short)num);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList oY9SSm4pdQO(Dictionary<int, byte[]> P_0, WorkingEntitiesData P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		int[] array = P_0.Keys.ToArray();
		int[] array2 = array;
		foreach (int num in array2)
		{
			byte[] array3 = P_0[num];
			if (array3 == null)
			{
				break;
			}
			DgXSGTG0XoV = num;
			if (array3[0] != 1 && array3[0] != 8 && array3.Length >= 6145)
			{
				TagNodeCompound item = ogySSlEN9s5(array3, num, P_1);
				tagNodeList.Add(item);
			}
			else if (array3[0] == 1 || array3[0] == 8)
			{
				TagNodeCompound item2 = vPJSSxbxeoB(array3, num, P_1);
				tagNodeList.Add(item2);
			}
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList esbSSnSlBVL(byte[] P_0, WorkingEntitiesData P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = v0nSSdDkyMx.ConvertParameters;
		NibbleSetters nibbleSetters = new NibbleSetters();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		byte[] array = new byte[2048];
		byte[] data = P_0.Skip(32768).Take(16384).ToArray();
		for (int i = 0; i < 8; i++)
		{
			new TagNodeList(TagType.TAG_COMPOUND);
			new List<int>();
			List<MNG7DMjfJPt829tiWrF> list = new List<MNG7DMjfJPt829tiWrF>();
			list.Add(new MNG7DMjfJPt829tiWrF(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944), null));
			int[] array2 = new int[4096];
			DgXSGTG0XoV = i;
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					for (int l = 0; l < 16; l++)
					{
						int num = j * 2048 + k * 128 + l + i * 16;
						byte b = P_0[num];
						int num2 = nibbleSetters.TU17GetFast(data, num);
						byte b2 = b;
						byte b3 = (byte)num2;
						int num3 = zZASS2LFk1h(b2, b3, j, l, k, P_0, list);
						int num4 = l * 256 + k * 16 + j;
						array2[num4] = num3;
						nibbleSetters.TU17SetFast(array, num4, (b2 == 0) ? 15 : 0);
					}
				}
			}
			TagNodeCompound tagNodeCompound = new TagNodeCompound();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)i);
			int num5 = JavaPaletteBitsPerBlock(list.Count);
			long[] d = Iy7SS6FX9IQ(array2, num5);
			TagNodeList value = BVGSSXZQ9Uq(list);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeLongArray(d);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70018)] = new TagNodeByteArray(new byte[2048]);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69998)] = new TagNodeByteArray(array);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = value;
			tagNodeList.Add(tagNodeCompound);
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound ogySSlEN9s5(byte[] P_0, int P_1, WorkingEntitiesData P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = v0nSSdDkyMx.ConvertParameters;
		NibbleSetters nibbleSetters = new NibbleSetters();
		int[] array = new int[4096];
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)P_1);
		new TagNodeList(TagType.TAG_COMPOUND);
		new List<int>();
		List<MNG7DMjfJPt829tiWrF> list = new List<MNG7DMjfJPt829tiWrF>();
		list.Add(new MNG7DMjfJPt829tiWrF(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944), null));
		byte[] data = P_0.Skip(4097).Take(2048).ToArray();
		byte[] array2 = new byte[2048];
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					int num = i * 256 + j * 16 + k + 1;
					int num2 = P_0[num];
					num--;
					int num3 = nibbleSetters.TU17GetFast(data, num);
					byte b = (byte)num2;
					byte b2 = (byte)num3;
					int num4 = zZASS2LFk1h(b, b2, i, k, j, P_0, list);
					int num5 = k * 256 + j * 16 + i;
					array[num5] = num4;
					nibbleSetters.TU17SetFast(array2, num5, (b == 0) ? 15 : 0);
				}
			}
		}
		int num6 = JavaPaletteBitsPerBlock(list.Count);
		long[] d = Iy7SS6FX9IQ(array, num6);
		TagNodeList value = BVGSSXZQ9Uq(list);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeLongArray(d);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70018)] = new TagNodeByteArray(new byte[2048]);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69998)] = new TagNodeByteArray(array2);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = value;
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int zZASS2LFk1h(byte P_0, byte P_1, int P_2, int P_3, int P_4, byte[] P_5, List<MNG7DMjfJPt829tiWrF> P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MNG7DMjfJPt829tiWrF mNG7DMjfJPt829tiWrF = afbSSyIdtEZ(P_0, P_1, P_2, P_3, P_4);
		for (int i = 0; i < P_6.Count; i++)
		{
			if (!(P_6[i].Name == mNG7DMjfJPt829tiWrF.Name))
			{
				continue;
			}
			bool flag = true;
			Dictionary<string, BlockStateProperty> dictionary = P_6[i].Properties;
			foreach (string key in mNG7DMjfJPt829tiWrF.Properties.Keys)
			{
				if (!dictionary.ContainsKey(key) || dictionary[key].Value != mNG7DMjfJPt829tiWrF.Properties[key].Value)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return i;
			}
		}
		P_6.Add(mNG7DMjfJPt829tiWrF);
		return P_6.Count - 1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MNG7DMjfJPt829tiWrF afbSSyIdtEZ(byte P_0, byte P_1, int P_2, int P_3, int P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MCCToolChest.model.BlockState bedrockBlockState = BlockMaster.GetBedrockBlockState(P_0, P_1);
		return CjJSS0UkK3a(bedrockBlockState, P_2, P_3, P_4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MNG7DMjfJPt829tiWrF CjJSS0UkK3a(MCCToolChest.model.BlockState P_0, int P_1, int P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MNG7DMjfJPt829tiWrF mNG7DMjfJPt829tiWrF = new MNG7DMjfJPt829tiWrF();
		string name = P_0.name;
		short data = P_0.data;
		MasterBlock masterBlock = P_0.masterBlock;
		if (name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65386))
		{
			masterBlock = BlockMaster.Blocks[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944)];
		}
		mNG7DMjfJPt829tiWrF.Name = masterBlock.java.name;
		string blockStates = masterBlock.blockStates;
		if (!string.IsNullOrWhiteSpace(blockStates) && BlockMaster.DataStates.ContainsKey(blockStates))
		{
			if (P_0.useProperties)
			{
				mNG7DMjfJPt829tiWrF.Properties = OcgSSBTfNU5(P_0.properties, BlockMaster.DataStates[blockStates].blockStates);
			}
			else
			{
				mNG7DMjfJPt829tiWrF.Properties = YmZSSa2nWKi(data, BlockMaster.DataStates[blockStates].blockStates);
			}
		}
		if (blockStates == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70042))
		{
			int num = ((Tv8SSz5OgmQ >= 0) ? (Tv8SSz5OgmQ * 16) : ((Tv8SSz5OgmQ + 1) * 16));
			int num2 = ((JvXSGSPPt4U >= 0) ? (JvXSGSPPt4U * 16) : ((JvXSGSPPt4U + 1) * 16));
			int num3 = num + ((Tv8SSz5OgmQ >= 0) ? P_1 : ((16 - P_1) * -1));
			int num4 = num2 + ((JvXSGSPPt4U >= 0) ? P_3 : ((16 - P_3) * -1));
			num3 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num3, v0nSSdDkyMx.ConvertParameters.XRegionOffset);
			num4 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num4, v0nSSdDkyMx.ConvertParameters.ZRegionOffset);
			int y = DgXSGTG0XoV * 16 + P_2;
			string value = JavaChestConnections.ProcessChest(num3, y, num4, data, v0nSSdDkyMx.Chests, v0nSSdDkyMx.ChestConnections);
			mNG7DMjfJPt829tiWrF.Properties[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31412)].Value = value;
		}
		return mNG7DMjfJPt829tiWrF;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, BlockStateProperty> OcgSSBTfNU5(List<MasterBlockItemProperty> P_0, List<BlockStateDefinition> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, BlockStateProperty> dictionary = new Dictionary<string, BlockStateProperty>();
		if (P_0 == null)
		{
			P_0 = new List<MasterBlockItemProperty>();
		}
		foreach (BlockStateDefinition item in P_1)
		{
			if (!string.IsNullOrWhiteSpace(item.name) && !string.IsNullOrWhiteSpace(item.bedrockName))
			{
				string text = GOdSStpwFe4(item.bedrockName, P_0);
				BlockStateValue[] states = item.states;
				foreach (BlockStateValue blockStateValue in states)
				{
					if (text == blockStateValue.bedrockPropertyValue)
					{
						BlockStateProperty value = new BlockStateProperty(item.name, blockStateValue.javaPropertyValue);
						if (!dictionary.ContainsKey(item.name))
						{
							dictionary[item.name] = value;
						}
						break;
					}
				}
			}
			else if (!string.IsNullOrWhiteSpace(item.name))
			{
				BlockStateProperty value2 = new BlockStateProperty(item.name, item.defaultValue);
				dictionary.Add(item.name, value2);
			}
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GOdSStpwFe4(string P_0, List<MasterBlockItemProperty> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (MasterBlockItemProperty item in P_1)
		{
			if (item.name == P_0)
			{
				return item.value;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, BlockStateProperty> YmZSSa2nWKi(short P_0, List<BlockStateDefinition> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, BlockStateProperty> dictionary = new Dictionary<string, BlockStateProperty>();
		foreach (BlockStateDefinition item in P_1)
		{
			if (!string.IsNullOrWhiteSpace(item.name) && item.bedrockMask > 0)
			{
				int num = P_0 & item.bedrockMask;
				BlockStateValue[] states = item.states;
				foreach (BlockStateValue blockStateValue in states)
				{
					if (num == blockStateValue.bedrock)
					{
						BlockStateProperty value = new BlockStateProperty(item.name, blockStateValue.javaPropertyValue);
						if (!dictionary.ContainsKey(item.name))
						{
							dictionary.Add(item.name, value);
						}
						break;
					}
				}
			}
			else if (!string.IsNullOrWhiteSpace(item.name) && item.bedrockMask == 0)
			{
				BlockStateProperty value2 = new BlockStateProperty(item.name, item.defaultValue);
				dictionary.Add(item.name, value2);
			}
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList BVGSSXZQ9Uq(List<MNG7DMjfJPt829tiWrF> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		for (int i = 0; i < P_0.Count; i++)
		{
			TagNodeCompound tagNodeCompound = new TagNodeCompound();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] = new TagNodeString(P_0[i].Name);
			if (P_0[i].Properties != null && P_0[i].Properties.Count > 0)
			{
				TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
				foreach (string key in P_0[i].Properties.Keys)
				{
					tagNodeCompound2[key] = new TagNodeString(P_0[i].Properties[key].Value);
				}
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65420)] = tagNodeCompound2;
			}
			tagNodeList.Add(tagNodeCompound);
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound vPJSSxbxeoB(byte[] P_0, int P_1, WorkingEntitiesData P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)P_1);
		List<MNG7DMjfJPt829tiWrF> list = new List<MNG7DMjfJPt829tiWrF>();
		list.Add(new MNG7DMjfJPt829tiWrF(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944), null));
		ChunkSection section = vjwSGGOipdZ.GetSection(Tv8SSz5OgmQ, JvXSGSPPt4U, P_1, P_0);
		Dictionary<int, BlockHandlerDataBedrockToJava> blockHandlers = section.blockHandlers;
		List<MCCToolChest.model.BlockState> bedrockBlockStates = section.bedrockBlockStates;
		int[] blockIndexes = section.blockIndexes;
		int[] array = new int[4096];
		byte[] array2 = new byte[2048];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					num = k * 256 + j * 16 + i;
					num2 = blockIndexes[num];
					MCCToolChest.model.BlockState blockState = bedrockBlockStates[num2];
					if (blockState.masterBlock.java.conversionFunction != null && toJavaFunctions.ContainsKey(blockState.masterBlock.java.conversionFunction))
					{
						blockState = blockState.Copy(0);
						toJavaFunctions[blockState.masterBlock.java.conversionFunction](blockState, P_1, i, k, j, blockIndexes, bedrockBlockStates);
					}
					if (!dictionary.ContainsKey(num2))
					{
						num3 = feLSSrBVc8c(blockState, i, k, j, P_0, list);
						if (blockState.masterBlock.cache)
						{
							dictionary[num2] = num3;
						}
					}
					else
					{
						num3 = dictionary[num2];
					}
					array[num] = num3;
					nibbleSetters.TU17SetFast(array2, num, (num3 == 0) ? 15 : 0);
					if (blockHandlers.ContainsKey(num2))
					{
						blockHandlers[num2].blockHandler(i, k + P_1 * 16, j, bedrockBlockStates[num2].data, blockHandlers[num2].properties, P_2);
					}
				}
			}
		}
		int num4 = JavaPaletteBitsPerBlock(list.Count);
		long[] d = Iy7SS6FX9IQ(array, num4);
		TagNodeList value = BVGSSXZQ9Uq(list);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeLongArray(d);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70018)] = new TagNodeByteArray(new byte[2048]);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69998)] = new TagNodeByteArray(array2);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = value;
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GB7SSeaoNdj(MCCToolChest.model.BlockState P_0, int P_1, int P_2, int P_3, int P_4, int[] P_5, List<MCCToolChest.model.BlockState> P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BjsSSMeJQ7B(MCCToolChest.model.BlockState P_0, int P_1, int P_2, int P_3, int P_4, int[] P_5, List<MCCToolChest.model.BlockState> P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_3 * 256 + P_4 * 16 + P_2;
		int key = JavaChestConnections.BuildKey(P_2, P_3, P_4);
		if (NuuSSIHPrj5.ContainsKey(key))
		{
			P_0.properties = NuuSSIHPrj5[key];
			P_0.useProperties = true;
			SMMSSLsYgYp(P_0.properties, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70056), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18714));
			NuuSSIHPrj5.Remove(key);
			return;
		}
		List<MasterBlockItemProperty> list = new List<MasterBlockItemProperty>();
		MCCToolChest.model.BlockState blockState = null;
		if (P_3 < 15)
		{
			num += 256;
			blockState = P_6[P_5[num]];
		}
		else
		{
			blockState = S9aSSkoMWZ6(P_1 + 1, Tv8SSz5OgmQ, JvXSGSPPt4U, P_2, 0, P_4);
		}
		if (blockState == null)
		{
			blockState = P_0.Copy(0);
		}
		if (!P_0.useProperties)
		{
			DvxSSP08gnS(P_0, P_0.masterBlock.blockStates);
			DvxSSP08gnS(blockState, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65518));
		}
		SMMSSLsYgYp(list, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70090), VbcSSUtiZlM(P_0.properties, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70090), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19230)));
		SMMSSLsYgYp(list, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70056), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708));
		SMMSSLsYgYp(list, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70112), VbcSSUtiZlM(P_0.properties, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70112), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708)));
		SMMSSLsYgYp(list, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70132), VbcSSUtiZlM(blockState.properties, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70132), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708)));
		SMMSSLsYgYp(list, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64910), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708));
		P_0.properties = list;
		P_0.useProperties = true;
		int key2 = JavaChestConnections.BuildKey(P_2, (P_3 < 15) ? (P_3 + 1) : 0, P_4);
		NuuSSIHPrj5.Add(key2, list);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string VbcSSUtiZlM(List<MasterBlockItemProperty> P_0, string P_1, string P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 == null)
		{
			return P_2;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].name == P_1)
			{
				return P_0[i].value;
			}
		}
		return P_2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SMMSSLsYgYp(List<MasterBlockItemProperty> P_0, string P_1, string P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].name == P_1)
			{
				P_0[i].value = P_2;
				return;
			}
		}
		P_0.Add(new MasterBlockItemProperty(P_1, P_2));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XBHSSg9IYRe(List<MasterBlockItemProperty> P_0, List<MasterBlockItemProperty> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			bool flag = false;
			for (int j = 0; j < P_1.Count; j++)
			{
				if (P_0[i].name == P_1[j].name)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				P_1.Add(P_0[i]);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DvxSSP08gnS(MCCToolChest.model.BlockState P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!P_0.useProperties)
		{
			P_0.properties = plSSSRbB94N(P_0, P_1);
			P_0.useProperties = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<MasterBlockItemProperty> plSSSRbB94N(MCCToolChest.model.BlockState P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int data = P_0.data;
		List<MasterBlockItemProperty> list = new List<MasterBlockItemProperty>();
		try
		{
			if (P_1 != null && BlockMaster.DataStates.ContainsKey(P_1))
			{
				List<BlockStateDefinition> blockStates = BlockMaster.DataStates[P_1].blockStates;
				foreach (BlockStateDefinition item2 in blockStates)
				{
					if (item2.bedrockMask <= 0 || string.IsNullOrWhiteSpace(item2.bedrockName))
					{
						continue;
					}
					int num = data & item2.bedrockMask;
					for (int i = 0; i < item2.states.Length; i++)
					{
						if (num == item2.states[i].bedrock)
						{
							MasterBlockItemProperty item = new MasterBlockItemProperty(item2.bedrockName, item2.states[i].bedrockPropertyValue);
							list.Add(item);
							break;
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MCCToolChest.model.BlockState S9aSSkoMWZ6(int P_0, int P_1, int P_2, int P_3, int P_4, int P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_4 * 256 + P_5 * 16 + P_3;
		MCCToolChest.model.BlockState result = null;
		ChunkSection section = vjwSGGOipdZ.GetSection(v0nSSdDkyMx.PERegion.Dimension, P_1, P_2, P_0);
		if (section != null)
		{
			result = section.bedrockBlockStates[section.blockIndexes[num]];
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void c2jSSYcWCsn(MCCToolChest.model.BlockState P_0, int P_1, int P_2, int P_3, int P_4, int[] P_5, List<MCCToolChest.model.BlockState> P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<MasterBlockItemProperty> list = new List<MasterBlockItemProperty>();
		string text = "";
		try
		{
			list.Add(new MasterBlockItemProperty(value: (P_4 <= 0) ? mwkSS3A0WTK(P_1, Tv8SSz5OgmQ, JvXSGSPPt4U - 1, P_2, P_3, 15) : mwkSS3A0WTK(P_1, Tv8SSz5OgmQ, JvXSGSPPt4U, P_2, P_3, P_4 - 1), name: Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64136)));
		}
		catch (Exception)
		{
		}
		try
		{
			list.Add(new MasterBlockItemProperty(value: (P_4 >= 15) ? mwkSS3A0WTK(P_1, Tv8SSz5OgmQ, JvXSGSPPt4U + 1, P_2, P_3, 0) : mwkSS3A0WTK(P_1, Tv8SSz5OgmQ, JvXSGSPPt4U, P_2, P_3, P_4 + 1), name: Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64150)));
		}
		catch (Exception)
		{
		}
		try
		{
			list.Add(new MasterBlockItemProperty(value: (P_2 <= 0) ? mwkSS3A0WTK(P_1, Tv8SSz5OgmQ - 1, JvXSGSPPt4U, 15, P_3, P_4) : mwkSS3A0WTK(P_1, Tv8SSz5OgmQ, JvXSGSPPt4U, P_2 - 1, P_3, P_4), name: Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64176)));
		}
		catch (Exception)
		{
		}
		try
		{
			list.Add(new MasterBlockItemProperty(value: (P_2 >= 15) ? mwkSS3A0WTK(P_1, Tv8SSz5OgmQ + 1, JvXSGSPPt4U, 0, P_3, P_4) : mwkSS3A0WTK(P_1, Tv8SSz5OgmQ, JvXSGSPPt4U, P_2 + 1, P_3, P_4), name: Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64164)));
		}
		catch (Exception)
		{
		}
		P_0.useProperties = true;
		P_0.properties = list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string mwkSS3A0WTK(int P_0, int P_1, int P_2, int P_3, int P_4, int P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70164);
		int num = P_4 * 256 + P_5 * 16 + P_3;
		ChunkSection section = vjwSGGOipdZ.GetSection(v0nSSdDkyMx.PERegion.Dimension, P_1, P_2, P_0);
		if (section == null)
		{
			return text;
		}
		if (section.bedrockBlockStates[section.blockIndexes[num]].masterBlock.Name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70176))
		{
			text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70226);
		}
		if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70164) && (P_0 > 0 || (P_0 == 0 && P_4 > 0)))
		{
			int num2 = P_0;
			if (P_4 > 0)
			{
				num = (P_4 - 1) * 256 + P_5 * 16 + P_3;
			}
			else
			{
				num = 3840 + P_5 * 16 + P_3;
				num2--;
			}
			section = vjwSGGOipdZ.GetSection(v0nSSdDkyMx.PERegion.Dimension, P_1, P_2, num2);
			if (section != null && section.bedrockBlockStates[section.blockIndexes[num]].masterBlock.Name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70176))
			{
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70226);
			}
		}
		if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70164) && (P_0 < 15 || (P_0 == 15 && P_4 < 15)))
		{
			int num3 = P_0;
			if (P_4 < 15)
			{
				num = (P_4 + 1) * 256 + P_5 * 16 + P_3;
			}
			else
			{
				num = P_5 * 16 + P_3;
				num3++;
			}
			section = vjwSGGOipdZ.GetSection(v0nSSdDkyMx.PERegion.Dimension, P_1, P_2, num3);
			if (section != null && section.bedrockBlockStates[section.blockIndexes[num]].masterBlock.Name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70176))
			{
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69290);
			}
		}
		return text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FcTSS1xEbsa(MCCToolChest.model.BlockState P_0, int P_1, int P_2, int P_3, int P_4, int[] P_5, List<MCCToolChest.model.BlockState> P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<MasterBlockItemProperty> list = new List<MasterBlockItemProperty>();
		int num = P_3 * 256 + P_4 * 16 + P_2;
		try
		{
			if (P_4 > 0)
			{
				list.Add(new MasterBlockItemProperty(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64136), P_6[P_5[num - 16]].masterBlock.linkable ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662)));
			}
			else
			{
				bool flag = X5SSSEVVWZS(P_1, Tv8SSz5OgmQ, JvXSGSPPt4U - 1, P_2, P_3, 15);
				list.Add(new MasterBlockItemProperty(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64136), flag ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662)));
			}
		}
		catch (Exception)
		{
		}
		try
		{
			if (P_4 < 15)
			{
				list.Add(new MasterBlockItemProperty(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64150), P_6[P_5[num + 16]].masterBlock.linkable ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662)));
			}
			else
			{
				bool flag2 = X5SSSEVVWZS(P_1, Tv8SSz5OgmQ, JvXSGSPPt4U + 1, P_2, P_3, 0);
				list.Add(new MasterBlockItemProperty(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64150), flag2 ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662)));
			}
		}
		catch (Exception)
		{
		}
		try
		{
			if (P_2 > 0)
			{
				list.Add(new MasterBlockItemProperty(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64176), P_6[P_5[num - 1]].masterBlock.linkable ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662)));
			}
			else
			{
				bool flag3 = X5SSSEVVWZS(P_1, Tv8SSz5OgmQ - 1, JvXSGSPPt4U, 15, P_3, P_4);
				list.Add(new MasterBlockItemProperty(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64176), flag3 ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662)));
			}
		}
		catch (Exception)
		{
		}
		try
		{
			if (P_2 < 15)
			{
				list.Add(new MasterBlockItemProperty(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64164), P_6[P_5[num + 1]].masterBlock.linkable ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662)));
			}
			else
			{
				bool flag4 = X5SSSEVVWZS(P_1, Tv8SSz5OgmQ + 1, JvXSGSPPt4U, 0, P_3, P_4);
				list.Add(new MasterBlockItemProperty(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64164), flag4 ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662)));
			}
		}
		catch (Exception)
		{
		}
		P_0.useProperties = true;
		P_0.properties = list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool X5SSSEVVWZS(int P_0, int P_1, int P_2, int P_3, int P_4, int P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_4 * 256 + P_5 * 16 + P_3;
		bool result = false;
		ChunkSection section = vjwSGGOipdZ.GetSection(v0nSSdDkyMx.PERegion.Dimension, P_1, P_2, P_0);
		if (section != null && section.bedrockBlockStates[section.blockIndexes[num]].masterBlock.linkable)
		{
			result = true;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int feLSSrBVc8c(MCCToolChest.model.BlockState P_0, int P_1, int P_2, int P_3, byte[] P_4, List<MNG7DMjfJPt829tiWrF> P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MNG7DMjfJPt829tiWrF mNG7DMjfJPt829tiWrF = CjJSS0UkK3a(P_0, P_1, P_2, P_3);
		if (!P_0.isDoor)
		{
			for (int i = 0; i < P_5.Count; i++)
			{
				if (!(P_5[i].Name == mNG7DMjfJPt829tiWrF.Name))
				{
					continue;
				}
				bool flag = true;
				Dictionary<string, BlockStateProperty> dictionary = P_5[i].Properties;
				foreach (string key in mNG7DMjfJPt829tiWrF.Properties.Keys)
				{
					if (!dictionary.ContainsKey(key) || dictionary[key].Value != mNG7DMjfJPt829tiWrF.Properties[key].Value)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return i;
				}
			}
		}
		P_5.Add(mNG7DMjfJPt829tiWrF);
		return P_5.Count - 1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cy0SS5Kbhwl(TagNodeCompound P_0, string P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		try
		{
			if (!BlockMaster.DataStates.ContainsKey(P_1))
			{
				return;
			}
			List<BlockStateDefinition> blockStates = BlockMaster.DataStates[P_1].blockStates;
			foreach (BlockStateDefinition item in blockStates)
			{
				if (item.bedrockMask <= 0 || string.IsNullOrWhiteSpace(item.name))
				{
					continue;
				}
				int num = P_2 & item.bedrockMask;
				for (int i = 0; i < item.states.Length; i++)
				{
					if (num == item.states[i].bedrock)
					{
						tagNodeCompound[item.name] = new TagNodeString(item.states[i].javaPropertyValue);
						break;
					}
				}
			}
			if (tagNodeCompound.Count > 0)
			{
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65420)] = tagNodeCompound;
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long[] Iy7SS6FX9IQ(int[] P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<long> list = new List<long>();
		uint num = (uint)((1 << P_1) - 1);
		long num2 = 0L;
		int num3 = 0;
		long num4 = 0L;
		for (int i = 0; i < 4096; i++)
		{
			num4 = P_0[i] & num;
			if (num3 + P_1 <= 64)
			{
				num4 <<= num3;
				num2 |= num4;
				num3 += P_1;
				if (num3 >= 64)
				{
					list.Add(num2);
					num2 = 0L;
					num3 = 0;
				}
			}
			else
			{
				int num5 = 64 - num3;
				uint num6 = (uint)((1 << num5) - 1);
				num4 &= num6;
				num2 |= num4 << num3;
				list.Add(num2);
				num2 = 0L;
				int num7 = P_1 - num5;
				uint num8 = (uint)((1 << num7) - 1);
				num4 = P_0[i] & num;
				num2 = (num4 >> num5) & num8;
				num3 = num7;
			}
		}
		if (num3 > 0)
		{
			list.Add(num2);
		}
		return list.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int JavaPaletteBitsPerBlock(int paletteCount)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (paletteCount <= 16)
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
		else if (paletteCount <= 128)
		{
			result = 7;
		}
		else if (paletteCount <= 256)
		{
			result = 8;
		}
		else if (paletteCount <= 512)
		{
			result = 9;
		}
		else if (paletteCount <= 1024)
		{
			result = 10;
		}
		else if (paletteCount <= 2048)
		{
			result = 11;
		}
		else if (paletteCount <= 4096)
		{
			result = 12;
		}
		else if (paletteCount <= 8192)
		{
			result = 13;
		}
		else if (paletteCount <= 16384)
		{
			result = 14;
		}
		else if (paletteCount <= 32768)
		{
			result = 15;
		}
		else if (paletteCount <= 65536)
		{
			result = 16;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vToSSNx1Vi9(int P_0, int P_1, int P_2, int P_3, Dictionary<string, BlockStateProperty> P_4, WorkingEntitiesData P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ((Tv8SSz5OgmQ >= 0) ? (Tv8SSz5OgmQ * 16) : ((Tv8SSz5OgmQ + 1) * 16));
		int num2 = ((JvXSGSPPt4U >= 0) ? (JvXSGSPPt4U * 16) : ((JvXSGSPPt4U + 1) * 16));
		int num3 = num + ((Tv8SSz5OgmQ >= 0) ? P_0 : ((16 - P_0) * -1));
		int num4 = num2 + ((JvXSGSPPt4U >= 0) ? P_2 : ((16 - P_2) * -1));
		PE2PCEntityConversion pE2PCEntityConversion = new PE2PCEntityConversion();
		TagNodeCompound tagNodeCompound = KxrSSDFHwva(num3, P_1, num4, P_5.BedrockTileEntities);
		if (tagNodeCompound != null)
		{
			TagNodeCompound tagNodeCompound2 = pE2PCEntityConversion.CreateItemFrame(tagNodeCompound, P_3, v0nSSdDkyMx.ConvertParameters);
			if (tagNodeCompound2 != null)
			{
				P_5.JavaEntities.Add(tagNodeCompound2);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound KxrSSDFHwva(int P_0, int P_1, int P_2, TagNodeList P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		for (int i = 0; i < P_3.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_3[i] as TagNodeCompound;
			int num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] as TagNodeInt;
			int num2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] as TagNodeInt;
			int num3 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] as TagNodeInt;
			if (num == P_0 && num2 == P_1 && num3 == P_2)
			{
				result = tagNodeCompound;
				break;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList lfQSScEZ96T(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		for (int num = P_0.Count - 1; num >= 0; num--)
		{
			TagNodeCompound tagNodeCompound = P_0[num] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				string text = (TagNodeString)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
				if (TileEntityLookup.Names.ContainsKey(text))
				{
					string key = TileEntityLookup.Names[text];
					if (TileEntityLookup.BedrockToJava.ContainsKey(key))
					{
						string hexString = TileEntityLookup.BedrockToJava[key];
						byte[] array = Utils.ConvertHexStringToByteArray(hexString);
						if (array != null && array.Length > 0)
						{
							NbtTree nbtTree = new NbtTree();
							nbtTree.UseBigEndian = false;
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
							TagNodeCompound root = nbtTree.Root;
							tagNodeList.Add(root);
							uCHSSJPsT9H(tagNodeCompound, root);
							if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15604))
							{
								Ne2SSo60wtE(tagNodeCompound, root);
							}
							if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14496))
							{
								c4lSSugvLc5(tagNodeCompound, root);
							}
							if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)))
							{
								TagNodeCompound tagNodeCompound2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)].Copy() as TagNodeCompound;
								SiYSS7Zs4Du.ProcessItem(tagNodeCompound2);
								root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] = tagNodeCompound2;
							}
							if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)))
							{
								TagNodeList tagNodeList2 = (TagNodeList)(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] as TagNodeList).Copy();
								SiYSS7Zs4Du.ProcessItems(tagNodeList2);
								root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] = tagNodeList2;
							}
						}
					}
				}
			}
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uCHSSJPsT9H(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] as TagNodeInt;
		int num2 = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] as TagNodeInt;
		if (v0nSSdDkyMx.ConvertParameters.UseConvertOffsets)
		{
			num = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num, v0nSSdDkyMx.ConvertParameters.XRegionOffset) + (num - num);
			num2 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num2, v0nSSdDkyMx.ConvertParameters.ZRegionOffset) + (num2 - num2);
		}
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] = new TagNodeInt(num);
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] as TagNodeInt;
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] = new TagNodeInt(num2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void c4lSSugvLc5(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(0)))
		{
			num = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(0)] as TagNodeInt;
		}
		num = 15 - num;
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(0)] = new TagNodeInt(num);
		if (!P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)) || !(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)] is TagNodeList))
		{
			return;
		}
		TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)] as TagNodeList;
		for (int i = 0; i < tagNodeList.Count; i++)
		{
			TagNodeCompound tagNodeCompound = tagNodeList[i] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14360)))
			{
				int num2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14360)] as TagNodeInt;
				num2 = 15 - num2;
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14360)] = new TagNodeInt(num2);
			}
		}
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)] = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ne2SSo60wtE(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = null;
		try
		{
			if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10946)))
			{
				array = (P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10946)] as TagNodeString).Data.Split('\n');
				string d = umuSSQVgO7Y((array.Length > 0) ? array[0] : "");
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66224)] = new TagNodeString(d);
				d = umuSSQVgO7Y((array.Length > 1) ? array[1] : "");
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66244)] = new TagNodeString(d);
				d = umuSSQVgO7Y((array.Length > 2) ? array[2] : "");
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66258)] = new TagNodeString(d);
				d = umuSSQVgO7Y((array.Length > 3) ? array[3] : "");
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66272)] = new TagNodeString(d);
			}
			else if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66224)))
			{
				string d2 = umuSSQVgO7Y(P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66224)) ? ((TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66224)]).Data : "");
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66224)] = new TagNodeString(d2);
				d2 = umuSSQVgO7Y(P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66244)) ? ((TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66244)]).Data : "");
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66244)] = new TagNodeString(d2);
				d2 = umuSSQVgO7Y(P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66258)) ? ((TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66258)]).Data : "");
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66258)] = new TagNodeString(d2);
				d2 = umuSSQVgO7Y(P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66272)) ? ((TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66272)]).Data : "");
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66272)] = new TagNodeString(d2);
			}
		}
		catch (Exception)
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66224)] = new TagNodeString(umuSSQVgO7Y(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70238)));
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66244)] = new TagNodeString(umuSSQVgO7Y(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70238)));
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66258)] = new TagNodeString(umuSSQVgO7Y(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70238)));
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66272)] = new TagNodeString(umuSSQVgO7Y(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70238)));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string umuSSQVgO7Y(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (string.IsNullOrWhiteSpace(P_0))
		{
			P_0 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70238);
		}
		if (P_0.Trim().StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63862)))
		{
			JSONText jSONText = new JSONText();
			P_0 = jSONText.ParseJSONText(P_0);
		}
		return string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70244), P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList zBxSSOyTtMw(TagNodeList P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = null;
		try
		{
			PE2PCEntityConversion pE2PCEntityConversion = new PE2PCEntityConversion();
			return pE2PCEntityConversion.ConvertEntities(P_0, P_1);
		}
		catch
		{
			return new TagNodeList(TagType.TAG_COMPOUND);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConvertToPCFromPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		SiYSS7Zs4Du = new JavaFromBedrockItemConverter();
		UbmSSA9v1UZ = new Dictionary<int, List<int>>();
		S07SSHOEy4p = new EntityLookup();
		cTPSSFpkKVb = new TileEntityLookup();
		toJavaFunctions = new Dictionary<string, ToJavaFunction>();
	}
}
