using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using DekWW8jSE3fVOo1d5ao;
using MCCToolChest.events;
using MCCToolChest.MCSBCode.searchReplace;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.PECode.model;
using MCCToolChest.utils;
using MCPELevelDBI.model;
using NBTExplorer.Model;
using PdZ7Q5ulfs6I7OgARis;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCPELevelDBI.workers;

public class PEProcessWorker
{
	private BackgroundWorker coMSZaLfyWK;

	private EntityLookup BIYSZXJusQM;

	[CompilerGenerated]
	private static Func<PERegion, int> NWGSZxbcwEE;

	[CompilerGenerated]
	private static Func<PERegion, int> VDCSZeBUvi1;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEProcessWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		BIYSZXJusQM = new EntityLookup();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEProcessWorker(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		BIYSZXJusQM = new EntityLookup();
		coMSZaLfyWK = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoPEStaging(string filePath, string folderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		try
		{
			try
			{
				Directory.CreateDirectory(Path.Combine(folderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
				FileUtils.CopyFoldersAndFiles(Path.Combine(filePath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)), Path.Combine(folderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
			}
			catch (Exception ex)
			{
				throw new Exception(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86084) + Environment.NewLine + ex.Message);
			}
			try
			{
				byte[] source = FileUtils.pURSg6Zk53A(Path.Combine(filePath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)));
				source = source.Skip(8).ToArray();
				FileUtils.WriteFile(source, folderPath + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516));
			}
			catch (Exception ex2)
			{
				throw new Exception(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86170) + Environment.NewLine + ex2.Message);
			}
			try
			{
				if (File.Exists(Path.Combine(filePath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810))))
				{
					aQPuvouUn6uQnBG85CL aQPuvouUn6uQnBG85CL2 = new aQPuvouUn6uQnBG85CL();
					aQPuvouUn6uQnBG85CL2.sDXSYEhsqao(Path.Combine(filePath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810)), Path.Combine(folderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810)));
				}
			}
			catch (Exception ex3)
			{
				throw new Exception(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86270) + Environment.NewLine + ex3.Message);
			}
			try
			{
				tTiSpQKljP1(folderPath);
			}
			catch (Exception ex4)
			{
				if (ex4.Message == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86378))
				{
					throw new Exception(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86482) + Environment.NewLine + Environment.NewLine + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86698));
				}
				throw new Exception(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86924) + Environment.NewLine + ex4.Message);
			}
			try
			{
				GetMaps(folderPath);
			}
			catch (Exception ex5)
			{
				throw new Exception(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87016) + Environment.NewLine + ex5.Message);
			}
			try
			{
				WriteWildCardRecords(folderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87116), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436));
				WriteWildCardRecords(folderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87132), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206));
				WriteWildCardRecords(folderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87152), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206));
				WriteWildCardRecords(folderPath, "structuretemplate_", Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206));
				WriteExactRecords(folderPath, new string[4]
				{
					"DedicatedServerForcedCorruption",
					"SST_SALOG",
					"SST_WORD",
					"SST_WORD_"
				}, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206));
			}
			catch (Exception ex6)
			{
				throw new Exception(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87180) + Environment.NewLine + ex6.Message);
			}
		}
		catch (Exception ex7)
		{
			MessageBox.Show(ex7.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87276));
			result = false;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tTiSpQKljP1(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_0);
		string[] peFiles = PEConsts.peFiles;
		foreach (string text in peFiles)
		{
			string[] array = text.Split('\\');
			byte[] array2 = levelDBWorker.ReadDbValue(array[1]);
			Directory.CreateDirectory(P_0 + array[0]);
			if (array2 != null && array2.Length > 0)
			{
				string text2 = (PEConsts.txtFiles.Contains(array[1]) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69582) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554));
				FileUtils.WriteFile(array2, P_0 + text + text2);
			}
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetMaps(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		levelDBWorker.GetMaps(path);
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteWildCardRecords(string path, string wildcard, string folder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		List<DBRecord> wildCardRecords = levelDBWorker.GetWildCardRecords(wildcard);
		foreach (DBRecord item in wildCardRecords)
		{
			string text = FileUtils.LdbKeyFromBytes(item.Key);
			string path2 = FileUtils.EncodeLdbKeyFileName(text);
			string filename = Path.Combine(path, folder, path2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554));
			FileUtils.WriteFile(item.Value, filename);
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteExactRecords(string path, string[] keys, string folder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		foreach (string key in keys)
		{
			byte[] array = levelDBWorker.ReadDbValue(FileUtils.LdbKeyToBytes(key));
			if (array == null || array.Length == 0)
			{
				array = levelDBWorker.ReadDbValue(key);
			}
			if (array != null && array.Length > 0)
			{
				string path2 = FileUtils.EncodeLdbKeyFileName(key);
				string filename = Path.Combine(path, folder, path2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554));
				FileUtils.WriteFile(array, filename);
			}
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<PEDimension> GetAvailableChunks(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		List<PEDimension> availableChunks = levelDBWorker.GetAvailableChunks();
		levelDBWorker.CloseDB();
		for (int i = 0; i < availableChunks.Count; i++)
		{
			if (availableChunks[i].Region.Count == 0)
			{
				continue;
			}
			List<PERegion> source = availableChunks[i].Region.Values.ToList();
			source = source.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (PERegion P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.RX;
			}).ThenBy([MethodImpl(MethodImplOptions.NoInlining)] (PERegion P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.RZ;
			}).ToList();
			availableChunks[i].Region.Clear();
			foreach (PERegion item in source)
			{
				availableChunks[i].Region.Add(item.RX + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + item.RZ, item);
			}
		}
		return availableChunks;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWorldChunks ReadPEChunk(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		PEWorldChunks worldChunks = levelDBWorker.GetWorldChunks();
		levelDBWorker.CloseDB();
		return worldChunks;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWorldChunks GetWorldChunks(string path, GeneratePCFilesFromPE generatePCFiles, bool useFastConversion)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEWorldChunks pEWorldChunks = null;
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		pEWorldChunks = ((!useFastConversion) ? levelDBWorker.GetWorldChunksForConversion(generatePCFiles) : levelDBWorker.GetWorldChunks());
		levelDBWorker.CloseDB();
		return pEWorldChunks;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNodeCompound GetChunk(string path, int dim, int x, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		tagNodeCompound = jMaSpO3clr2(dim, x, z, levelDBWorker);
		levelDBWorker.CloseDB();
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound jMaSpO3clr2(int P_0, int P_1, int P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		byte[] array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 0);
		TagNodeList tagNodeList = UNKSp7hw8MR(array, P_3);
		if (tagNodeList.Count == 0)
		{
			tagNodeList = iU8SpCLpm3I(array, P_3);
		}
		TagNodeByteArray tagNodeByteArray = new TagNodeByteArray(new byte[256]);
		TagNodeIntArray tagNodeIntArray = new TagNodeIntArray(new int[256]);
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeList tagNodeList3 = new TagNodeList(TagType.TAG_COMPOUND);
		new TagNodeList(TagType.TAG_COMPOUND);
		array[array.Length - 1] = 45;
		byte[] array2 = P_3.ReadDbValue(array);
		if (array2 != null)
		{
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					int index = (j << 4) | i;
					int num = (j << 4) | (i + 512);
					tagNodeByteArray[index] = array2[num];
				}
			}
			for (int k = 0; k < 256; k++)
			{
				tagNodeIntArray[k] = BitConverter.ToInt16(array2, k * 2);
			}
		}
		array[array.Length - 1] = 49;
		byte[] array3 = P_3.ReadDbValue(array);
		try
		{
			if (array3 != null)
			{
				MemoryStream memoryStream = new MemoryStream(array3);
				while (memoryStream.Position < memoryStream.Length)
				{
					NbtTree nbtTree = new NbtTree(memoryStream);
					if (nbtTree.Root != null)
					{
						tagNodeList2.Add(nbtTree.Root);
					}
				}
			}
		}
		catch (Exception)
		{
			throw;
		}
		array[array.Length - 1] = 50;
		byte[] array4 = P_3.ReadDbValue(array);
		try
		{
			if (array4 != null)
			{
				MemoryStream memoryStream2 = new MemoryStream(array4);
				while (memoryStream2.Position < memoryStream2.Length)
				{
					NbtTree nbtTree2 = new NbtTree(memoryStream2);
					if (nbtTree2.Root != null)
					{
						tagNodeList3.Add(nbtTree2.Root);
					}
				}
			}
		}
		catch (Exception)
		{
		}
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548), tagNodeList);
		tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65008), tagNodeIntArray);
		tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992), tagNodeByteArray);
		tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124), tagNodeList3);
		tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796), tagNodeList2);
		tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984), new TagNodeInt(P_1));
		tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996), new TagNodeInt(P_2));
		array[array.Length - 1] = 51;
		byte[] array5 = P_3.ReadDbValue(array);
		if (array5 != null)
		{
			MemoryStream memoryStream3 = new MemoryStream(array5);
			while (memoryStream3.Position < memoryStream3.Length)
			{
				NbtTree nbtTree3 = new NbtTree(memoryStream3);
				if (nbtTree3.Root != null)
				{
					tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87318), nbtTree3.Root);
				}
			}
		}
		array[array.Length - 1] = 52;
		byte[] array6 = P_3.ReadDbValue(array);
		array[array.Length - 1] = 53;
		byte[] array7 = P_3.ReadDbValue(array);
		if (array7 != null)
		{
			tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87346), new TagNodeByteArray(array7));
		}
		array[array.Length - 1] = 54;
		byte[] array8 = P_3.ReadDbValue(array);
		if (array8 != null)
		{
			int d = BitConverter.ToInt32(array8, 0);
			tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87370), new TagNodeInt(d));
		}
		array[array.Length - 1] = 118;
		byte[] array9 = P_3.ReadDbValue(array);
		if (array9 != null)
		{
			tagNodeCompound2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604), new TagNodeByte(array9[0]));
		}
		tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] = tagNodeCompound2;
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList iU8SpCLpm3I(byte[] P_0, LevelDBWorker P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		P_0[P_0.Length - 1] = 48;
		byte[] array = P_1.ReadDbValue(P_0);
		if (array == null)
		{
			return tagNodeList;
		}
		byte[] data = array.Skip(32768).Take(16384).ToArray();
		byte[] array2 = new byte[32768];
		byte[] array3 = new byte[16384];
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 128; k++)
				{
					int num = i * 2048 + j * 128 + k;
					byte b = array[num];
					int val = nibbleSetters.TU17GetFast(data, num);
					int num2 = k * 256 + j * 16 + i;
					array2[num2] = b;
					nibbleSetters.TU17SetFast(array3, num2, val);
				}
			}
		}
		for (byte b2 = 0; b2 < 8; b2++)
		{
			TagNodeCompound tagNodeCompound = new TagNodeCompound();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte(b2);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] = new TagNodeByteArray(array2.Skip(4096 * b2).Take(4096).ToArray());
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] = new TagNodeByteArray(array3.Skip(2048 * b2).Take(2048).ToArray());
			tagNodeList.Add(tagNodeCompound);
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList UNKSp7hw8MR(byte[] P_0, LevelDBWorker P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NibbleSetters nibbleSetters = new NibbleSetters();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		P_0[P_0.Length - 1] = 47;
		List<byte> list = P_0.ToList();
		list.Add(0);
		P_0 = list.ToArray();
		for (byte b = 0; b < 16; b++)
		{
			P_0[P_0.Length - 1] = b;
			byte[] array = P_1.ReadDbValue(P_0);
			if (array != null)
			{
				if (array[0] != 1 && array[0] < 8 && array.Length >= 6145)
				{
					byte[] data = array.Skip(4097).Take(2048).ToArray();
					byte[] array2 = new byte[4096];
					byte[] array3 = new byte[2048];
					for (int i = 0; i < 16; i++)
					{
						for (int j = 0; j < 16; j++)
						{
							for (int k = 0; k < 16; k++)
							{
								int num = i * 256 + j * 16 + k + 1;
								int num2 = array[num];
								num--;
								int val = nibbleSetters.TU17GetFast(data, num);
								int num3 = k * 256 + j * 16 + i;
								array2[num3] = (byte)num2;
								nibbleSetters.TU17SetFast(array3, num3, val);
							}
						}
					}
					TagNodeCompound tagNodeCompound = new TagNodeCompound();
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte(b);
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] = new TagNodeByteArray(array2);
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] = new TagNodeByteArray(array3);
					tagNodeList.Add(tagNodeCompound);
				}
				else if (array[0] == 1 || array[0] == 8)
				{
					TagNodeCompound item = JaOSpA8YEiU(array, b);
					tagNodeList.Add(item);
				}
			}
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound JaOSpA8YEiU(byte[] P_0, byte P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList value = PEUtility.BlockStorageSection(P_0);
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] = value;
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = new TagNodeByte(P_0[0]);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte(P_1);
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveFromStaging(List<ModifiedFile> modifiedFiles, string originalWorldPath, string workingWorldPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		I6XSpHSXkyD(originalWorldPath, workingWorldPath);
		g8LSpjgjY58(modifiedFiles, workingWorldPath);
		dwySp8Q21Vx(modifiedFiles, workingWorldPath);
		CJkSp9EP9t3(modifiedFiles, workingWorldPath);
		cKySZSy8MkI(originalWorldPath, workingWorldPath);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bGeSpdoOFnO(DirectoryInfo P_0, DirectoryInfo P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DirectoryInfo[] directories = P_0.GetDirectories();
		foreach (DirectoryInfo directoryInfo in directories)
		{
			bGeSpdoOFnO(directoryInfo, P_1.CreateSubdirectory(directoryInfo.Name));
		}
		FileInfo[] files = P_0.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			fileInfo.CopyTo(Path.Combine(P_1.FullName, fileInfo.Name));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I6XSpHSXkyD(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = FileUtils.pURSg6Zk53A(P_1 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516));
		memoryStream.Write(BitConverter.GetBytes(8), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(array.Length), 0, 4);
		memoryStream.Write(array, 0, array.Length);
		Directory.CreateDirectory(P_0);
		FileUtils.WriteFile(memoryStream.ToArray(), Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)));
		if (File.Exists(Path.Combine(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810))))
		{
			File.Copy(Path.Combine(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810)), Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810)), overwrite: true);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IBrSpFQHvmB(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_0);
		string[] peFiles = PEConsts.peFiles;
		foreach (string text in peFiles)
		{
			string[] array = text.Split('\\');
			string text2 = (PEConsts.txtFiles.Contains(array[1]) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69582) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554));
			string text3 = Path.Combine(P_0, text + text2);
			if (File.Exists(text3))
			{
				byte[] value = FileUtils.pURSg6Zk53A(text3);
				byte[] bytes = Encoding.ASCII.GetBytes(array[1]);
				levelDBWorker.Put(bytes, value);
			}
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void g8LSpjgjY58(List<ModifiedFile> P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_1);
		foreach (ModifiedFile item in P_0)
		{
			if (item.FileState == FileStateType.ADDED)
			{
				item.FileState = FileStateType.PINNED;
			}
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dwySp8Q21Vx(List<ModifiedFile> P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<ChunkData> list = new List<ChunkData>();
		foreach (ModifiedFile item in P_0)
		{
			if (item.Tag is ChunkData && item.FileState == FileStateType.DELETED && item.Tag is ChunkData)
			{
				list.Add(item.Tag as ChunkData);
			}
		}
		DeleteRegionChunks(list, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CJkSp9EP9t3(List<ModifiedFile> P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_1);
		foreach (string pendingLdbDeletion in Working.PendingLdbDeletions)
		{
			levelDBWorker.Delete(FileUtils.LdbKeyToBytes(pendingLdbDeletion));
		}
		Working.ClearPendingLdbDeletions();
		foreach (ModifiedFile item in P_0)
		{
			if (item.Tag is ChunkData)
			{
				_ = item.Tag;
				if (item.FileState == FileStateType.MODIFIED)
				{
					AM5SpzUKDgK(item, levelDBWorker);
				}
			}
			else if (item.Tag is IndexEntry indexEntry)
			{
				if (item.FileState == FileStateType.DELETED)
				{
					levelDBWorker.Delete(FileUtils.LdbKeyToBytes(indexEntry.FileName));
				}
				else if (indexEntry.FileName != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516))
				{
					Pb0SpIiwyWH(indexEntry.FileName, indexEntry.FilePath, P_1, levelDBWorker);
				}
			}
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Pb0SpIiwyWH(string P_0, string P_1, string P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Path.Combine(P_2, P_1);
		if (File.Exists(text))
		{
			byte[] value = FileUtils.pURSg6Zk53A(text);
			P_3.Put(FileUtils.LdbKeyToBytes(P_0), value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessModifiedChunk(ModifiedFile chunkFile, string workingWorldPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(workingWorldPath);
		try
		{
			AM5SpzUKDgK(chunkFile, levelDBWorker);
		}
		catch (Exception)
		{
		}
		finally
		{
			levelDBWorker.CloseDB();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AM5SpzUKDgK(ModifiedFile P_0, LevelDBWorker P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null && P_0.FileNode is NbtFileDataNode nbtFileDataNode)
		{
			TagNodeCompound root = nbtFileDataNode.Tree.Root;
			if (root != null)
			{
				ChunkData chunkData = P_0.Tag as ChunkData;
				WMNSZTvh5k7(chunkData.Dimension, root, P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessModifiedChunk(int dimension, TagNodeCompound chunkNode, string workingWorldPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(workingWorldPath);
		try
		{
			WMNSZTvh5k7(dimension, chunkNode, levelDBWorker);
		}
		catch (Exception)
		{
		}
		finally
		{
			levelDBWorker.CloseDB();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WMNSZTvh5k7(int P_0, TagNodeCompound P_1, LevelDBWorker P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 != null)
		{
			PEChunkWorker pEChunkWorker = new PEChunkWorker();
			pEChunkWorker.WriteModifiedChunk(P_0, P_1, 256, P_2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cKySZSy8MkI(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270));
		Directory.CreateDirectory(path);
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			fileInfo.Delete();
		}
		string path2 = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270));
		string[] files2 = Directory.GetFiles(Path.Combine(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
		foreach (string text in files2)
		{
			File.Copy(text, Path.Combine(path2, Path.GetFileName(text)));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteAllRegionsInDimension(string dimensionName, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = PEUtility.GetPEDimension(dimensionName);
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		foreach (PERegion value in pEDimension.Region.Values)
		{
			levelDBWorker.DeleteRegionChunks(value);
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteRegionChunks(PERegion regionData, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		levelDBWorker.DeleteRegionChunks(regionData);
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteRegionChunks(List<ChunkData> deletedChunks, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		levelDBWorker.DeleteRegionChunks(deletedChunks);
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteChunks(int dimension, int[] coords, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		levelDBWorker.DeleteChunks(dimension, coords);
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<EntitySearchResult> SearchEntities(PEDimension peDimension, List<NodeSearchcriterion> searchCriteria, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		List<EntitySearchResult> list = new List<EntitySearchResult>();
		int count = peDimension.Region.Values.Count;
		int num = 0;
		foreach (PERegion value in peDimension.Region.Values)
		{
			string text = value.ToString();
			EyWSZ0ppiYV(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64314) + text, (int)((float)num / (float)count * 100f));
			kiOSZG1e76N(peDimension, value, searchCriteria, list, levelDBWorker);
			num++;
		}
		levelDBWorker.CloseDB();
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kiOSZG1e76N(PEDimension P_0, PERegion P_1, List<NodeSearchcriterion> P_2, List<EntitySearchResult> P_3, LevelDBWorker P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EntitySearchResult entitySearchResult = new EntitySearchResult();
		entitySearchResult.Dimension = Constants.GetDimensionFolderName(P_0.Dimension);
		entitySearchResult.Region = P_1.ToString();
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 32; j++)
			{
				pQnSZbAhxxm(P_1, P_2, entitySearchResult, P_3, P_4, lxe7hMuSirBXGUQugsD.QdsSP76hcgY(i, P_1.RX), lxe7hMuSirBXGUQugsD.QdsSP76hcgY(j, P_1.RZ));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pQnSZbAhxxm(PERegion P_0, List<NodeSearchcriterion> P_1, EntitySearchResult P_2, List<EntitySearchResult> P_3, LevelDBWorker P_4, int P_5, int P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_5, P_0.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_6, P_0.RZ);
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		if (P_0.Chunks[num3] == 1)
		{
			byte[] array = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 49);
			byte[] array2 = P_4.ReadDbValue(array);
			P_2.ChunkIndex = num3;
			if (array2 != null)
			{
				P_2.EntityType = EntityType.TileEntity;
				xpESZv4ioDa(array2, P_1, P_2, P_3);
			}
			array[array.Length - 1] = 50;
			array2 = P_4.ReadDbValue(array);
			if (array2 != null)
			{
				P_2.EntityType = EntityType.Entity;
				xpESZv4ioDa(array2, P_1, P_2, P_3);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xpESZv4ioDa(byte[] P_0, List<NodeSearchcriterion> P_1, EntitySearchResult P_2, List<EntitySearchResult> P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream(P_0);
		while (memoryStream.Position < memoryStream.Length)
		{
			NbtTree nbtTree = new NbtTree(memoryStream);
			if (nbtTree.Root != null)
			{
				fd4SZ4THOuT(P_1, nbtTree.Root, P_2, P_3);
				if (P_2.EntityType == EntityType.Entity)
				{
					Rw7SZw32PCM(P_1, nbtTree.Root, P_2, P_3, "");
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Rw7SZw32PCM(List<NodeSearchcriterion> P_0, TagNodeCompound P_1, EntitySearchResult P_2, List<EntitySearchResult> P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58844));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fd4SZ4THOuT(List<NodeSearchcriterion> P_0, TagNodeCompound P_1, EntitySearchResult P_2, List<EntitySearchResult> P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = "";
		if (P_2.EntityType != EntityType.Entity)
		{
			text = ((P_2.EntityType != EntityType.TileEntity || !P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634))) ? "" : ((string)(P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString)));
		}
		else if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeInt)
		{
			int key = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeInt;
			if (hvd0XujpavSpj5UhiI6.eCfSVZfnEaD().ContainsKey(key))
			{
				text = hvd0XujpavSpj5UhiI6.eCfSVZfnEaD()[key].Name;
			}
			else if (hvd0XujpavSpj5UhiI6.WBHSVsHEOJC().ContainsKey(key))
			{
				text = hvd0XujpavSpj5UhiI6.WBHSVsHEOJC()[key].Name;
			}
			if (BIYSZXJusQM.PCEntities.ContainsKey(text))
			{
				text = BIYSZXJusQM.PCEntities[text].PCOldName;
			}
		}
		else if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
		{
			text = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
			if (text.IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974)) >= 0 && BIYSZXJusQM.PCEntities.ContainsKey(text))
			{
				text = BIYSZXJusQM.PCEntities[text].ConsoleName;
			}
		}
		else if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15828)) && P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15828)] is TagNodeString)
		{
			text = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15828)] as TagNodeString;
			if (text.IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974)) >= 0 && BIYSZXJusQM.PCEntities.ContainsKey(text))
			{
				text = BIYSZXJusQM.PCEntities[text].ConsoleName;
			}
		}
		if (CWVSZWH8TO6(text, P_1, P_0))
		{
			P_2.EntityId = text;
			iqFSZVr1OW5(P_1, P_2, P_3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iqFSZVr1OW5(TagNodeCompound P_0, EntitySearchResult P_1, List<EntitySearchResult> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EntitySearchResult entitySearchResult = P_1.Copy();
		if (P_1.EntityType == EntityType.Entity)
		{
			if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)))
			{
				TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
				entitySearchResult.X = (int)(float)(TagNodeFloat)tagNodeList[0];
				entitySearchResult.Y = (int)(float)(TagNodeFloat)tagNodeList[1];
				entitySearchResult.Z = (int)(float)(TagNodeFloat)tagNodeList[2];
			}
		}
		else if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)))
		{
			entitySearchResult.X = (TagNodeInt)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)];
			entitySearchResult.Y = (TagNodeInt)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)];
			entitySearchResult.Z = (TagNodeInt)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)];
		}
		P_2.Add(entitySearchResult);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CWVSZWH8TO6(string P_0, TagNodeCompound P_1, List<NodeSearchcriterion> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (NodeSearchcriterion item in P_2)
		{
			if (!(item.Value == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10366)) && !P_0.ToLower().Contains(item.Value.ToLower()))
			{
				continue;
			}
			bool flag = true;
			foreach (NodeSearchcriterion nodeCondition in item.NodeConditions)
			{
				if (!w8USZp3QxxQ(P_1, nodeCondition.Node, nodeCondition))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool w8USZp3QxxQ(TagNodeCompound P_0, string P_1, NodeSearchcriterion P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		TagNode tagNode = null;
		string[] array = P_1.Split('.');
		if (array.Length > 0)
		{
			string text = array[0];
			if (array[0].Contains('['))
			{
				string text2 = text.Substring(0, text.IndexOf('[')).Trim();
				if (P_0.ContainsKey(text2) && P_0[text2] is TagNodeList tagNodeList)
				{
					string text3 = aETSZZW8UaL(text);
					if (text3 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10366))
					{
						for (int i = 0; i < tagNodeList.Count; i++)
						{
							string text4 = text2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850) + i + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542);
							for (int j = 1; j < array.Length; j++)
							{
								if (text4.Length > 0)
								{
									text4 += Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710);
								}
								text4 += array[j];
							}
							if (w8USZp3QxxQ(P_0, text4, P_2))
							{
								result = true;
							}
						}
					}
					else
					{
						int.TryParse(text3, out var result2);
						if (result2 < tagNodeList.Count)
						{
							tagNode = tagNodeList[result2];
						}
					}
				}
			}
			else if (P_0 != null && P_0.ContainsKey(text))
			{
				tagNode = P_0[text];
			}
			if (array.Length > 1 && tagNode != null && tagNode is TagNodeCompound)
			{
				string text5 = string.Empty;
				for (int k = 1; k < array.Length; k++)
				{
					if (text5.Length > 0)
					{
						text5 += Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710);
					}
					text5 += array[k];
				}
				result = w8USZp3QxxQ(tagNode as TagNodeCompound, text5, P_2);
			}
			else if (tagNode != null)
			{
				if (P_2.Value.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31676))
				{
					if (P_2.Condition == SearchCondition.NotEqual)
					{
						result = true;
					}
				}
				else if (lHcSZfrp6aK(tagNode, P_2))
				{
					result = true;
				}
			}
			else if (tagNode == null && P_2.Value.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31676) && P_2.Condition == SearchCondition.Equal)
			{
				result = true;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string aETSZZW8UaL(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = "";
		int num = P_0.IndexOf('[') + 1;
		int num2 = P_0.IndexOf(']');
		if (num2 > num)
		{
			result = P_0.Substring(num, num2 - num).Trim();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool lHcSZfrp6aK(TagNode P_0, NodeSearchcriterion P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		if (P_0 != null)
		{
			if (P_0 is TagNodeByte)
			{
				result = TlKSZiH9IAR(((TagNodeByte)P_0).Data, P_1);
			}
			else if (P_0 is TagNodeInt)
			{
				result = TlKSZiH9IAR(((TagNodeInt)P_0).Data, P_1);
			}
			else if (P_0 is TagNodeDouble)
			{
				result = TlKSZiH9IAR(((TagNodeDouble)P_0).Data, P_1);
			}
			else if (P_0 is TagNodeFloat)
			{
				result = TlKSZiH9IAR(((TagNodeFloat)P_0).Data, P_1);
			}
			else if (P_0 is TagNodeLong)
			{
				result = TlKSZiH9IAR(((TagNodeLong)P_0).Data, P_1);
			}
			else if (P_0 is TagNodeShort)
			{
				result = TlKSZiH9IAR(((TagNodeShort)P_0).Data, P_1);
			}
			else if (P_0 is TagNodeString)
			{
				result = TlKSZiH9IAR(((TagNodeString)P_0).Data, P_1);
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TlKSZiH9IAR<XKdypYjZfgZyYfeWUmF>(XKdypYjZfgZyYfeWUmF sCU8T4jm7ldEkwNND6u, NodeSearchcriterion P_1) where XKdypYjZfgZyYfeWUmF : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		XKdypYjZfgZyYfeWUmF val = SR_VariableBuilder.ConvertVariableString<XKdypYjZfgZyYfeWUmF>(P_1.Value);
		if (P_1.Condition == SearchCondition.Equal)
		{
			result = ohPSZsO4OeM(sCU8T4jm7ldEkwNND6u, val);
		}
		if (P_1.Condition == SearchCondition.NotEqual)
		{
			result = xTjSZqUBWhJ(sCU8T4jm7ldEkwNND6u, val);
		}
		if (P_1.Condition == SearchCondition.LessThan)
		{
			result = zmiSZK3mPDw(sCU8T4jm7ldEkwNND6u, val);
		}
		if (P_1.Condition == SearchCondition.GreaterThan)
		{
			result = bLxSZhwQQ1d(sCU8T4jm7ldEkwNND6u, val);
		}
		if (P_1.Condition == SearchCondition.LessThanEqual)
		{
			result = buZSZmoUF72(sCU8T4jm7ldEkwNND6u, val);
		}
		if (P_1.Condition == SearchCondition.GreaterThanEqual)
		{
			result = wE4SZn6WEG2(sCU8T4jm7ldEkwNND6u, val);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ohPSZsO4OeM<YiC0pljqc6590chnqbi>(YiC0pljqc6590chnqbi jl93IKj8TtfV5xslpu2, YiC0pljqc6590chnqbi VtxXjvjDm2d07baNi6D) where YiC0pljqc6590chnqbi : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return jl93IKj8TtfV5xslpu2.CompareTo(VtxXjvjDm2d07baNi6D) == 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool xTjSZqUBWhJ<MEnLqKjIFl5EZ3D5ing>(MEnLqKjIFl5EZ3D5ing QEaHspjyACeD1LklF46, MEnLqKjIFl5EZ3D5ing kkJHgXjQjO16llIetU0) where MEnLqKjIFl5EZ3D5ing : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return QEaHspjyACeD1LklF46.CompareTo(kkJHgXjQjO16llIetU0) != 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool zmiSZK3mPDw<CLteFUj9MW5YjOWJHiQ>(CLteFUj9MW5YjOWJHiQ DkrtXPjO0tuRUb3KaU3, CLteFUj9MW5YjOWJHiQ ncLlTBjgnrtINJ0aUAR) where CLteFUj9MW5YjOWJHiQ : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return DkrtXPjO0tuRUb3KaU3.CompareTo(ncLlTBjgnrtINJ0aUAR) < 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool bLxSZhwQQ1d<nK5PsJjNwRUOyuB9koX>(nK5PsJjNwRUOyuB9koX g5dxocj7ov4CEIrGZXs, nK5PsJjNwRUOyuB9koX hbmDaDjtQQdXjibWVwP) where nK5PsJjNwRUOyuB9koX : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return g5dxocj7ov4CEIrGZXs.CompareTo(hbmDaDjtQQdXjibWVwP) > 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool buZSZmoUF72<yLCJQTjkRCAgIlAbpks>(yLCJQTjkRCAgIlAbpks gZofcujUuAlhIx32got, yLCJQTjkRCAgIlAbpks OWXpn9jlIfo7pbongLS) where yLCJQTjkRCAgIlAbpks : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return gZofcujUuAlhIx32got.CompareTo(OWXpn9jlIfo7pbongLS) <= 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool wE4SZn6WEG2<AxNbosjP3UsO4U0M4GA>(AxNbosjP3UsO4U0M4GA qACClQj6XmeRA9nPnV4, AxNbosjP3UsO4U0M4GA CITDxljwntfEQDHl5Vb) where AxNbosjP3UsO4U0M4GA : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return qACClQj6XmeRA9nPnV4.CompareTo(CITDxljwntfEQDHl5Vb) >= 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReplaceBiomes(PEDimension peDimension, List<BiomeChange> replacementBiomeList, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		bool result = false;
		int count = peDimension.Region.Values.Count;
		int num = 0;
		foreach (PERegion value in peDimension.Region.Values)
		{
			num++;
			string text = value.ToString();
			EyWSZ0ppiYV(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64314) + text, (int)((float)num / (float)count * 100f));
			if (j1lSZlNLRyI(peDimension, value, replacementBiomeList, levelDBWorker))
			{
				result = true;
			}
		}
		levelDBWorker.CloseDB();
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool j1lSZlNLRyI(PEDimension P_0, PERegion P_1, List<BiomeChange> P_2, LevelDBWorker P_3)
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
				result = VtCSZ2ueXH4(P_1, P_2, lxe7hMuSirBXGUQugsD.QdsSP76hcgY(i, P_1.RX), lxe7hMuSirBXGUQugsD.QdsSP76hcgY(j, P_1.RZ), P_3);
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VtCSZ2ueXH4(PERegion P_0, List<BiomeChange> P_1, int P_2, int P_3, LevelDBWorker P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = false;
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_2, P_0.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_3, P_0.RZ);
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		if (P_0.Chunks[num3] == 1)
		{
			byte[] key = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 45);
			byte[] array = P_4.ReadDbValue(key);
			if (array != null)
			{
				byte[] array2 = array.Skip(512).Take(256).ToArray();
				flag = VZMSZy0Pwrj(array2, P_1);
				if (flag)
				{
					MemoryStream memoryStream = new MemoryStream();
					memoryStream.Write(array, 0, 512);
					memoryStream.Write(array2, 0, 256);
					P_4.Put(key, memoryStream.ToArray());
				}
			}
		}
		return flag;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool VZMSZy0Pwrj(byte[] P_0, List<BiomeChange> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		if (P_0 != null)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				for (int j = 0; j < P_1.Count; j++)
				{
					if (P_1[j].FromBiome == 1000 || P_0[i] == P_1[j].FromBiome)
					{
						P_0[i] = (byte)P_1[j].ToBiome;
						result = true;
						break;
					}
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeleteRecord(string key, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		levelDBWorker.Delete(FileUtils.LdbKeyToBytes(key));
		levelDBWorker.CloseDB();
		Working.QueueLdbDeletion(key);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EyWSZ0ppiYV(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (coMSZaLfyWK != null)
		{
			coMSZaLfyWK.ReportProgress(P_1, P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int tYbSZBrf6WF(PERegion P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RX;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int vamSZteHLJ6(PERegion P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RZ;
	}
}
