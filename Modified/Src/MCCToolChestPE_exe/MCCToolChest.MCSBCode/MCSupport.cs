using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.events;
using MCCToolChest.MCSBCode.Workers;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.PECode.model;
using MCCToolChest.utils;
using MCCToolChest.workers;
using MCPELevelDBI.workers;
using OAxWrWumnobfHyEL9yr;
using Substrate;
using Substrate.Core;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class MCSupport
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1
	{
		public LevelDBWorker dbWorker;

		public MCSupport _003C_003E4__this;

		public MergeParameters mergeParameters;

		public ConvertStatus convertStatus;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass1()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _003CMergeWorlds_003Eb__0(PEWorldChunks chunks)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			_003C_003E4__this.XSTSGWW5cbu(chunks, dbWorker, mergeParameters, convertStatus);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6
	{
		public MCSupport _003C_003E4__this;

		public string outFolderPath;

		public ConvertParameters convertParameters;

		public ConvertStatus convertStatus;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass6()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _003CGeneratePCWorld_003Eb__5(PEWorldChunks chunks)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			_003C_003E4__this.tZHSGrH1LR0(chunks, outFolderPath, convertParameters, convertStatus);
			MasterChunkList.worldChunks = chunks;
			_003C_003E4__this.EBYSbWOeOyB.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70304));
		}
	}

	private LevelDBWorker jPnSbwj8Ib5;

	private int Vc0Sb4PbBAJ;

	private string TwqSbVN044e;

	private BackgroundWorker EBYSbWOeOyB;

	private int tg8Sbpuo1Wi;

	private int re8SbZwEFw0;

	[CompilerGenerated]
	private static Func<IndexEntry, string> T01SbfS7am0;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ConvertStatus qXfSG4PMkbM(string P_0, MergeParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ConvertStatus convertStatus = new ConvertStatus();
		convertStatus.LabelType = LabelType.MERGE;
		try
		{
			w8USGVVA1kv(P_0, P_1, convertStatus);
			Thread.Sleep(500);
		}
		catch (Exception ex)
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55812) + Environment.NewLine + ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55870));
		}
		return convertStatus;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void w8USGVVA1kv(string P_0, MergeParameters P_1, ConvertStatus P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003C_003Ec__DisplayClass1 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass1();
		CS_0024_003C_003E8__locals15.mergeParameters = P_1;
		CS_0024_003C_003E8__locals15.convertStatus = P_2;
		CS_0024_003C_003E8__locals15._003C_003E4__this = this;
		CS_0024_003C_003E8__locals15.dbWorker = new LevelDBWorker();
		CS_0024_003C_003E8__locals15.dbWorker.OpenDB(Path.Combine(Working.T92StMGt1p4(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
		Vc0Sb4PbBAJ = 0;
		EBYSbWOeOyB.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70304));
		GeneratePCFilesFromPE generatePCFiles = [MethodImpl(MethodImplOptions.NoInlining)] (PEWorldChunks chunks) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			CS_0024_003C_003E8__locals15._003C_003E4__this.XSTSGWW5cbu(chunks, CS_0024_003C_003E8__locals15.dbWorker, CS_0024_003C_003E8__locals15.mergeParameters, CS_0024_003C_003E8__locals15.convertStatus);
		};
		PEProcessWorker pEProcessWorker = new PEProcessWorker(EBYSbWOeOyB);
		PEWorldChunks worldChunks = pEProcessWorker.GetWorldChunks(CS_0024_003C_003E8__locals15.mergeParameters.MergeWorldFolder, generatePCFiles, useFastConversion: false);
		XSTSGWW5cbu(worldChunks, CS_0024_003C_003E8__locals15.dbWorker, CS_0024_003C_003E8__locals15.mergeParameters, CS_0024_003C_003E8__locals15.convertStatus);
		fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70344), 100);
		CS_0024_003C_003E8__locals15.dbWorker.CloseDB();
		CS_0024_003C_003E8__locals15.convertStatus.ProcessedChunkCount = Vc0Sb4PbBAJ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XSTSGWW5cbu(PEWorldChunks P_0, LevelDBWorker P_1, MergeParameters P_2, ConvertStatus P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EBYSbWOeOyB.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70390));
		byte[] array = null;
		foreach (int key in P_0.NS3SWObVTQd().Keys)
		{
			if ((key != 0 || !P_2.ConvertOverworld) && (key != 1 || !P_2.ConvertNether) && (key != 2 || !P_2.ConvertTheEnd))
			{
				continue;
			}
			foreach (string key2 in P_0.NS3SWObVTQd()[key].Keys)
			{
				PERegionChunks pERegionChunks = P_0.NS3SWObVTQd()[key][key2];
				IntPtr batch = P_1.CreateWriteBatch();
				foreach (PEChunkData value in pERegionChunks.Chunks.Values)
				{
					Vc0Sb4PbBAJ++;
					cbnSbGsPWK5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70430) + Vc0Sb4PbBAJ);
					int num = value.X;
					int num2 = value.Z;
					if (P_2.ReplaceBiomes && value.ChunkData.ContainsKey(45))
					{
						byte[] array2 = value.ChunkData[45].Take(256).ToArray();
						array2 = W8ISGptsRCU(array2, P_2);
						MemoryStream memoryStream = new MemoryStream();
						memoryStream.Write(array2, 0, array2.Length);
						memoryStream.Write(value.ChunkData[45], 256, value.ChunkData[45].Length - 256);
						value.ChunkData[45] = memoryStream.ToArray();
					}
					if (P_2.UseConvertOffsets)
					{
						num = lxe7hMuSirBXGUQugsD.vADSPFUS622(num, P_2.XRegionOffset);
						num2 = lxe7hMuSirBXGUQugsD.vADSPFUS622(num2, P_2.ZRegionOffset);
					}
					foreach (int key3 in value.BlockSections.Keys)
					{
						array = PEUtility.BuildChunkKey(value.Dimension, num, num2, 47, (byte)key3);
						P_1.WriteBatchPut(batch, array, value.BlockSections[key3]);
					}
					foreach (int key4 in value.ChunkData.Keys)
					{
						byte[] array3 = value.ChunkData[key4];
						if (P_2.UseConvertOffsets && key4 == 49)
						{
							array3 = nl4SGfMpufy(array3, P_2);
						}
						if (P_2.UseConvertOffsets && key4 == 50)
						{
							array3 = pJFSGZFfm6x(array3, P_2);
						}
						array = PEUtility.BuildChunkKey(value.Dimension, num, num2, (byte)key4);
						P_1.WriteBatchPut(batch, array, array3);
					}
				}
				P_1.WriteBatch(batch);
				P_1.DestroyWriteBatch(batch);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] W8ISGptsRCU(byte[] P_0, MergeParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new NJVJiCuZKORGPYB1Y4v(false);
		byte[] array = new byte[256];
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num = (j << 4) | i;
				int num2 = (j << 4) | i;
				byte b = P_0[num];
				if (b >= 44 && b <= 50)
				{
					b -= 4;
				}
				if (P_1.ReplaceBiomes)
				{
					for (int k = 0; k < P_1.BiomeChanges.Count; k++)
					{
						if (P_1.BiomeChanges[k].FromBiome == 1000 || P_1.BiomeChanges[k].FromBiome == b)
						{
							b = (byte)P_1.BiomeChanges[k].ToBiome;
							break;
						}
					}
				}
				array[num2] = b;
			}
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] pJFSGZFfm6x(byte[] P_0, MergeParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = PEUtility.ExtractTileEntities(P_0);
		for (int num = tagNodeList.Count - 1; num >= 0; num--)
		{
			TagNodeCompound tagNodeCompound = tagNodeList[num] as TagNodeCompound;
			TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
			float num2 = tagNodeList2[0] as TagNodeFloat;
			float num3 = tagNodeList2[2] as TagNodeFloat;
			if (P_1.UseConvertOffsets)
			{
				num2 = (float)lxe7hMuSirBXGUQugsD.KmDSPjYqJTp((int)num2, P_1.XRegionOffset) + (num2 - (float)(int)num2);
				num3 = (float)lxe7hMuSirBXGUQugsD.KmDSPjYqJTp((int)num3, P_1.ZRegionOffset) + (num3 - (float)(int)num3);
			}
			tagNodeList2[0] = new TagNodeFloat(num2);
			tagNodeList2[2] = new TagNodeFloat(num3);
		}
		return YcASGis0OQw(tagNodeList);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] nl4SGfMpufy(byte[] P_0, MergeParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = PEUtility.ExtractTileEntities(P_0);
		for (int num = tagNodeList.Count - 1; num >= 0; num--)
		{
			TagNodeCompound tagNodeCompound = tagNodeList[num] as TagNodeCompound;
			int num2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] as TagNodeInt;
			int num3 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] as TagNodeInt;
			if (P_1.UseConvertOffsets)
			{
				num2 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num2, P_1.XRegionOffset) + (num2 - num2);
				num3 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num3, P_1.ZRegionOffset) + (num3 - num3);
			}
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] = new TagNodeInt(num2);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] = new TagNodeInt(num3);
		}
		return YcASGis0OQw(tagNodeList);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] YcASGis0OQw(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < P_0.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = P_0[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void qhPSGsrgvZn(string P_0, List<ModifiedFile> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			P_0 = FileUtils.CheckFolderSep(P_0);
			if (Working.RXpStXcJiRk() == PlatformType.PE)
			{
				mvKSGqMsKwF(P_0, P_1);
			}
			if (Working.RXpStXcJiRk() == PlatformType.PC)
			{
				cuhSGKJM7X7(P_0, P_1);
			}
			fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70462));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mvKSGqMsKwF(string P_0, List<ModifiedFile> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEProcessWorker pEProcessWorker = new PEProcessWorker();
		pEProcessWorker.SaveFromStaging(P_1, Working.OriginalFolder, P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cuhSGKJM7X7(string P_0, List<ModifiedFile> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void nWYSGhQ0PhI(string P_0, bool P_1 = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			P_0 = FileUtils.CheckFolderSep(P_0);
			KuqSGmVKOg8(P_0, P_1);
			fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70462));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KuqSGmVKOg8(string P_0, bool P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = P_0 ?? "";
		string text2 = P_0 ?? "";
		byte[] array = new byte[12];
		List<IndexEntry> list = null;
		if (File.Exists(text))
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(text, FileMode.Open));
			binaryReader.Read(array, 0, array.Length);
			list = lxe7hMuSirBXGUQugsD.a2jSgARJtVq(binaryReader);
		}
		if (P_1)
		{
			array[9] = 7;
			array[11] = 9;
		}
		if (list != null)
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text2, FileMode.Create)))
			{
				binaryWriter.Write(array, 0, array.Length);
			}
			for (int i = 0; i < list.Count; i++)
			{
				IndexEntry indexEntry = list[i];
				int num = (int)((float)(i + 1) / (float)list.Count * 100f);
				fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70506) + indexEntry.FilePath, num);
				if (indexEntry.FilePath.EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70546)))
				{
					wstSGXcsAOR(indexEntry, P_0);
				}
				else
				{
					Q53SGt2Tr27(indexEntry, P_0);
				}
			}
			long num2 = PbpSG0LymYw(list, P_0);
			fDVSG2TaKpn(num2, array, list, P_0);
		}
		FileUtils.DeleteFile(text);
		FileUtils.HONSgOivHYv(text2, text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void tdqSGnRue3a(string P_0, string P_1, PlatformType P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = "";
		string text2 = "";
		string text3 = "";
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			switch (P_2)
			{
			case PlatformType.PC:
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70558);
				text2 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70602);
				text3 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70638);
				break;
			case PlatformType.PE:
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70666);
				text2 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70702);
				text3 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70730);
				break;
			}
			P_0 = FileUtils.CheckFolderSep(P_0);
			FileUtils.tDGSgCpUGpC(P_0 ?? "", P_0 + text);
			Eg6SGlkxSNu(P_0, text, text2, text3, P_1, P_2);
			fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70750));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Eg6SGlkxSNu(string P_0, string P_1, string P_2, string P_3, string P_4, PlatformType P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = "";
		string text2 = P_0 + P_1;
		string text3 = P_0 + P_2;
		string filePath = P_0 + P_3;
		byte[] array = new byte[12];
		List<IndexEntry> list = null;
		List<IndexEntry> list2 = new List<IndexEntry>();
		if (File.Exists(text2))
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(text2, FileMode.Open));
			binaryReader.Read(array, 0, array.Length);
			list = lxe7hMuSirBXGUQugsD.a2jSgARJtVq(binaryReader);
		}
		if (list != null)
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text3, FileMode.Create)))
			{
				binaryWriter.Write(array, 0, array.Length);
			}
			for (int i = 0; i < list.Count; i++)
			{
				IndexEntry indexEntry = list[i];
				if ((indexEntry.ParentName == null || indexEntry.ParentName.ToLower() != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436)) && !indexEntry.FileName.StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70796)) && !indexEntry.FileName.StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70804)))
				{
					int num = (int)((float)(i + 1) / (float)list.Count * 100f);
					fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70506) + indexEntry.FilePath, num);
					if (indexEntry.FilePath.EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70546)))
					{
						uNUSGxWXYrX(indexEntry, P_0, P_2, text);
					}
					else
					{
						vK9SGaK34kW(indexEntry, P_0, P_2, text);
					}
					list2.Add(indexEntry);
				}
			}
			list = list2;
			long num2 = WJHSGBrfkZd(list, P_0, P_2);
			kfaSGy3UucJ(num2, array, list, P_0, P_2);
		}
		FileUtils.DeleteFile(filePath);
		FileUtils.DeleteFile(text3);
		FileUtils.DeleteFile(text2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fDVSG2TaKpn(long P_0, byte[] P_1, List<IndexEntry> P_2, string P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kfaSGy3UucJ(P_0, P_1, P_2, P_3, "");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kfaSGy3UucJ(long P_0, byte[] P_1, List<IndexEntry> P_2, string P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = P_3 + P_4;
		if (File.Exists(path))
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open)))
			{
				binaryWriter.Seek(0, SeekOrigin.Begin);
				FileUtils.WriteUInt32(binaryWriter, (uint)P_0, FileUtils.ByteOrder.BigEndian);
				FileUtils.WriteUInt32(binaryWriter, (uint)P_2.Count, FileUtils.ByteOrder.BigEndian);
				binaryWriter.Write(P_1[8]);
				binaryWriter.Write(P_1[9]);
				binaryWriter.Write(P_1[10]);
				binaryWriter.Write(P_1[11]);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long PbpSG0LymYw(List<IndexEntry> P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return WJHSGBrfkZd(P_0, P_1, "");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long WJHSGBrfkZd(List<IndexEntry> P_0, string P_1, string P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = P_1 + P_2;
		long result = 0L;
		if (File.Exists(path))
		{
			using BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Append));
			binaryWriter.Seek(0, SeekOrigin.End);
			result = binaryWriter.BaseStream.Position;
			foreach (IndexEntry item in P_0)
			{
				item.UpdateRawData();
				binaryWriter.Write(item.RawData, 0, item.RawData.Length);
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Q53SGt2Tr27(IndexEntry P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vK9SGaK34kW(P_0, P_1, "", Working.WorkFolder);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vK9SGaK34kW(IndexEntry P_0, string P_1, string P_2, string P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = P_1 + P_2;
		string path2 = P_1 + P_3 + P_0.FilePath;
		if (!File.Exists(path))
		{
			return;
		}
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Append));
		binaryWriter.Seek(0, SeekOrigin.End);
		P_0.FileOffset = (uint)binaryWriter.BaseStream.Position;
		using BinaryReader binaryReader = new BinaryReader(File.Open(path2, FileMode.Open));
		long length = binaryReader.BaseStream.Length;
		P_0.FileLength = (uint)length;
		binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
		for (int i = 0; i < length; i++)
		{
			binaryWriter.Write(binaryReader.ReadByte());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wstSGXcsAOR(IndexEntry P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uNUSGxWXYrX(P_0, P_1, "", Working.WorkFolder);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uNUSGxWXYrX(IndexEntry P_0, string P_1, string P_2, string P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = P_1 + P_2;
		string path2 = P_1 + P_3 + P_0.FilePath;
		if (!File.Exists(path))
		{
			return;
		}
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open));
		binaryWriter.Seek(0, SeekOrigin.End);
		P_0.FileOffset = (uint)binaryWriter.BaseStream.Position;
		if (!File.Exists(path2))
		{
			return;
		}
		using BinaryReader binaryReader = new BinaryReader(File.Open(path2, FileMode.Open));
		long length = binaryReader.BaseStream.Length;
		P_0.FileLength = (uint)length;
		binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
		for (int i = 0; i < length; i++)
		{
			binaryWriter.Write(binaryReader.ReadByte());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal List<IndexEntry> uweSGe9x7n9(string P_0, string P_1, bool P_2 = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<IndexEntry> result = null;
		if (!string.IsNullOrWhiteSpace(P_0) && !string.IsNullOrWhiteSpace(P_1))
		{
			fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70812));
			P_1 = FileUtils.CheckFolderSep(P_1);
			KCdSGM8ARD9(P_0, P_1);
			result = qF8SGUyhSQJ(P_1, P_2);
			fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70854), 100);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KCdSGM8ARD9(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (File.Exists(P_0))
		{
			FileUtils.TTSSgQ9uTyR(P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<IndexEntry> qF8SGUyhSQJ(string P_0, bool P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<IndexEntry> list = new List<IndexEntry>();
		string path = P_0 ?? "";
		if (File.Exists(path))
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));
			List<IndexEntry> list2 = lxe7hMuSirBXGUQugsD.a2jSgARJtVq(binaryReader).OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (IndexEntry indexEntry2) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return indexEntry2.FileExt;
			}).ToList();
			for (int num = 0; num < list2.Count; num++)
			{
				IndexEntry indexEntry = list2[num];
				int num2 = (int)((float)(num + 1) / (float)list2.Count * 100f);
				fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70904) + indexEntry.FilePath, num2);
				bclSGLDUNt2(binaryReader, indexEntry, P_0 + Working.WorkFolder);
				if (indexEntry.FilePath.EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70546)))
				{
					list.Add(indexEntry);
				}
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bclSGLDUNt2(BinaryReader P_0, IndexEntry P_1, string P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = P_2 + P_1.FilePath;
		qpOSGzwrG3B(text);
		P_0.BaseStream.Seek(P_1.FileOffset, SeekOrigin.Begin);
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Create));
		for (int i = 0; i < P_1.FileLength; i++)
		{
			binaryWriter.Write(P_0.ReadByte());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ConvertStatus aW2SGgNVxI5(string P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ConvertStatus convertStatus = new ConvertStatus();
		try
		{
			x4WSGR25FOv();
			qr1SG8OLIip(P_1);
			N5cSGPSJRZg(P_0, P_1.PCWorldFolder, P_1);
			ploSGkr9Quf(P_0, P_1, convertStatus);
			string path = Path.Combine(P_1.PCWorldFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516));
			if (P_1.UpdateLevelData || !File.Exists(path))
			{
				SKJSG3CXKlr(P_1.PCWorldFolder, P_0, P_1);
			}
			Thread.Sleep(500);
		}
		catch (Exception ex)
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55812) + Environment.NewLine + ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55870));
		}
		return convertStatus;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void N5cSGPSJRZg(string P_0, string P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EBYSbWOeOyB.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70944));
		try
		{
			MapWorker mapWorker = new MapWorker();
			if (P_2.ConvertInto == ConvertIntoType.EmptyWorld)
			{
				mapWorker.TayS3S371Vv(P_1);
			}
			Working.MapIds = mapWorker.yogSYCr7kCn(P_0, P_1, EBYSbWOeOyB);
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void x4WSGR25FOv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EBYSbWOeOyB.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70990));
		JavaAssetManager.CheckAssets();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ploSGkr9Quf(string P_0, ConvertParameters P_1, ConvertStatus P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003C_003Ec__DisplayClass6 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass6();
		CS_0024_003C_003E8__locals14.outFolderPath = P_0;
		CS_0024_003C_003E8__locals14.convertParameters = P_1;
		CS_0024_003C_003E8__locals14.convertStatus = P_2;
		CS_0024_003C_003E8__locals14._003C_003E4__this = this;
		EBYSbWOeOyB.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71058));
		FPKSGYcTBXq(CS_0024_003C_003E8__locals14.convertParameters);
		EBYSbWOeOyB.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70304));
		GeneratePCFilesFromPE generatePCFiles = [MethodImpl(MethodImplOptions.NoInlining)] (PEWorldChunks chunks) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			CS_0024_003C_003E8__locals14._003C_003E4__this.tZHSGrH1LR0(chunks, CS_0024_003C_003E8__locals14.outFolderPath, CS_0024_003C_003E8__locals14.convertParameters, CS_0024_003C_003E8__locals14.convertStatus);
			MasterChunkList.worldChunks = chunks;
			CS_0024_003C_003E8__locals14._003C_003E4__this.EBYSbWOeOyB.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70304));
		};
		PEProcessWorker pEProcessWorker = new PEProcessWorker(EBYSbWOeOyB);
		tZHSGrH1LR0(MasterChunkList.worldChunks = pEProcessWorker.GetWorldChunks(Working.T92StMGt1p4(), generatePCFiles, CS_0024_003C_003E8__locals14.convertParameters.UseFastConversion), CS_0024_003C_003E8__locals14.outFolderPath, CS_0024_003C_003E8__locals14.convertParameters, CS_0024_003C_003E8__locals14.convertStatus);
		fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70344), 100);
		MasterChunkList.worldChunks = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FPKSGYcTBXq(ConvertParameters P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if ((P_0.ConvertOverworld && P_0.ConvertInto == ConvertIntoType.EmptyDimension) || P_0.ConvertInto == ConvertIntoType.EmptyWorld)
		{
			KMXSGD1uUel(Constants.dimensionFolderNames[0], P_0);
		}
		if ((P_0.ConvertNether && P_0.ConvertInto == ConvertIntoType.EmptyDimension) || P_0.ConvertInto == ConvertIntoType.EmptyWorld)
		{
			KMXSGD1uUel(Constants.dimensionFolderNames[1], P_0);
		}
		if ((P_0.ConvertTheEnd && P_0.ConvertInto == ConvertIntoType.EmptyDimension) || P_0.ConvertInto == ConvertIntoType.EmptyWorld)
		{
			KMXSGD1uUel(Constants.dimensionFolderNames[2], P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SKJSG3CXKlr(string P_0, string P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = P_2.ModifiedLevelNode;
		string path = P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516);
		if (tagNodeCompound == null)
		{
			TagNodeCompound tagNodeCompound2 = xTjSGcOSfFO(P_0);
			if (tagNodeCompound2 == null)
			{
				tagNodeCompound2 = xoBSGJvJUoq(P_2.ConvertToFormat);
			}
			TagNodeCompound tagNodeCompound3 = PEUtility.LoadPELevel(P_1 + Working.WorkFolder);
			tagNodeCompound = erFSG1R4KfQ(tagNodeCompound2, tagNodeCompound3, P_2.ConvertToFormat, P_1, P_2.FlatworldLayers);
		}
		SavePCLevel(tagNodeCompound, path);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TagNodeCompound erFSG1R4KfQ(TagNodeCompound P_0, TagNodeCompound P_1, ConversionFormat P_2, string P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			TagNodeCompound tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeCompound;
			if (P_1 != null)
			{
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)] = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)].Copy();
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71116)))
				{
					string d = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71138);
					int num = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71116)] as TagNodeInt;
					if (num == 2)
					{
						d = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71156);
						tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44612)] = new TagNodeString(P_4);
					}
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71168)] = new TagNodeString(d);
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71198)) && P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71248)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71282)] = (TagNodeByte)(byte)(((int)(TagNodeByte)P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71248)] != 0) ? 1u : 0u);
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71312)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71312)] = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71312)].Copy();
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71332)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71332)] = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71332)].Copy();
				}
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71344)] = new TagNodeLong(Utils.DateTimeToUnixTimestamp());
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71368)))
				{
					byte d2 = (((float)(TagNodeFloat)P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71368)] != 0f) ? ((byte)1) : ((byte)0));
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71390)] = new TagNodeByte(d2);
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71408)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71408)] = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71408)].Copy();
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71428)))
				{
					byte d3 = (((float)(TagNodeFloat)P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71428)] != 0f) ? ((byte)1) : ((byte)0));
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71460)] = new TagNodeByte(d3);
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71484)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71514)] = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71484)].Copy();
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20568)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20568)] = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20568)].Copy();
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20584)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20584)] = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20584)].Copy();
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20600)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20600)] = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20600)].Copy();
				}
			}
			TagNodeList tagNodeList = BMtSG65i4xo(P_3);
			if (tagNodeList != null && tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71540)))
			{
				((TagNodeCompound)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71540)])[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] = tagNodeList;
			}
			TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
			switch (P_2)
			{
			case ConversionFormat.PreAquatic:
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770)] = new TagNodeInt(1343);
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] = new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71556));
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71572)] = new TagNodeByte(0);
				break;
			case ConversionFormat.Aquatic113:
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770)] = new TagNodeInt(1631);
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] = new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71592));
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71572)] = new TagNodeByte(0);
				break;
			default:
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770)] = new TagNodeInt(1976);
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] = new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71608));
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71572)] = new TagNodeByte(0);
				break;
			}
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = tagNodeCompound2;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FP2SGESlbcL(TagNodeCompound P_0, string P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		string path = Path.Combine(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71624));
		if (File.Exists(path))
		{
			string text = File.ReadAllText(path);
			if (!string.IsNullOrWhiteSpace(text) && text != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71686))
			{
				text = text.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850), "").Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542), "");
				string[] array = text.Split(',');
				int num = 0;
				for (int i = 0; i < array.Length; i++)
				{
					num++;
					string text2 = array[i];
					if (i != array.Length - 1 && !(text2 != array[i + 1]))
					{
						continue;
					}
					int result = 0;
					int.TryParse(text2.Trim(), out result);
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(',');
					}
					result = IvsSGHfklpm(result, i, P_2);
					if (INYifyudg3hCpcrleHt.EVJS0flQIhs().ContainsKey(result))
					{
						if (num > 1)
						{
							stringBuilder.Append(num);
							stringBuilder.Append('*');
						}
						stringBuilder.Append(INYifyudg3hCpcrleHt.EVJS0flQIhs()[result].qkOSyYT9Kd5());
					}
					num = 0;
				}
			}
		}
		if (stringBuilder.Length > 0)
		{
			string d = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71708) + stringBuilder.ToString();
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44612)] = new TagNodeString(d);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tZHSGrH1LR0(PEWorldChunks P_0, string P_1, ConvertParameters P_2, ConvertStatus P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		re8SbZwEFw0 = 0;
		List<ConvertToPCParameters> list = new List<ConvertToPCParameters>();
		List<ConvertToPCParameters> list2 = new List<ConvertToPCParameters>();
		List<ConvertToPCParameters> list3 = new List<ConvertToPCParameters>();
		Dictionary<int, MCCoordinate> chests = null;
		Dictionary<int, string> chestConnections = new Dictionary<int, string>();
		foreach (int key in P_0.NS3SWObVTQd().Keys)
		{
			if ((key != 0 || !P_2.ConvertOverworld) && (key != 1 || !P_2.ConvertNether) && (key != 2 || !P_2.ConvertTheEnd))
			{
				continue;
			}
			if (P_2.ConvertToFormat != ConversionFormat.PreAquatic)
			{
				chests = AVKSG5j2LkV(P_0, key);
			}
			foreach (string key2 in P_0.NS3SWObVTQd()[key].Keys)
			{
				PERegionChunks pERegionChunks = P_0.NS3SWObVTQd()[key][key2];
				ManualResetEvent doneEvent = new ManualResetEvent(initialState: false);
				ConvertToPCParameters convertToPCParameters = new ConvertToPCParameters(pERegionChunks, key2, P_1, P_2, doneEvent);
				convertToPCParameters.Chests = chests;
				convertToPCParameters.ChestConnections = chestConnections;
				list.Add(convertToPCParameters);
				re8SbZwEFw0 += pERegionChunks.Chunks.Count;
			}
		}
		bool flag = false;
		while (!flag)
		{
			tg8Sbpuo1Wi = 0;
			if (list2.Count < 7 && list.Count > 0)
			{
				ConvertToPCParameters convertToPCParameters2 = list[0];
				list.RemoveAt(0);
				list2.Add(convertToPCParameters2);
				ConvertToPCFromPE convertToPCFromPE = new ConvertToPCFromPE();
				ThreadPool.QueueUserWorkItem(convertToPCFromPE.ConvertRegionFileToPC, convertToPCParameters2);
			}
			for (int num = list2.Count - 1; num >= 0; num--)
			{
				ConvertToPCParameters convertToPCParameters3 = list2[num];
				if (convertToPCParameters3.Done)
				{
					list2.RemoveAt(num);
					list3.Add(convertToPCParameters3);
				}
			}
			for (int i = 0; i < list2.Count; i++)
			{
				tg8Sbpuo1Wi += list2[i].ProcessedChunkCount;
			}
			for (int j = 0; j < list3.Count; j++)
			{
				tg8Sbpuo1Wi += list3[j].ProcessedChunkCount;
			}
			cbnSbGsPWK5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71716) + tg8Sbpuo1Wi + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71754) + re8SbZwEFw0);
			flag = list.Count == 0 && list2.Count == 0;
			if (!flag)
			{
				Thread.Sleep(100);
			}
		}
		for (int k = 0; k < list3.Count; k++)
		{
			ConvertToPCParameters convertToPCParameters4 = list3[k];
			P_3.ProcessedChunkCount += convertToPCParameters4.ProcessedChunkCount;
			P_3.MissingChunkCount += convertToPCParameters4.MissingChunkCount;
			P_3.InvalidChunkCount += convertToPCParameters4.InvalidChunkCount;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<int, MCCoordinate> AVKSG5j2LkV(PEWorldChunks P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<int, MCCoordinate> dictionary = new Dictionary<int, MCCoordinate>();
		List<ChestConnectioExtractnParameters> list = new List<ChestConnectioExtractnParameters>();
		foreach (string key in P_0.NS3SWObVTQd()[P_1].Keys)
		{
			PERegionChunks peRegion = P_0.NS3SWObVTQd()[P_1][key];
			ChestConnectioExtractnParameters chestConnectioExtractnParameters = new ChestConnectioExtractnParameters();
			chestConnectioExtractnParameters.PeRegion = peRegion;
			list.Add(chestConnectioExtractnParameters);
			JavaChestConnections javaChestConnections = new JavaChestConnections();
			ThreadPool.QueueUserWorkItem(javaChestConnections.CreateChestsList, chestConnectioExtractnParameters);
		}
		bool flag = false;
		while (!flag)
		{
			flag = true;
			foreach (ChestConnectioExtractnParameters item in list)
			{
				if (!item.Done)
				{
					flag = false;
				}
			}
		}
		foreach (ChestConnectioExtractnParameters item2 in list)
		{
			foreach (int key2 in item2.Chests.Keys)
			{
				dictionary[key2] = item2.Chests[key2];
			}
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TagNodeList BMtSG65i4xo(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = null;
		TagNodeCompound tagNodeCompound = rB9SGuB2MhB(P_0);
		if (tagNodeCompound != null)
		{
			TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
			float num = tagNodeList2[0] as TagNodeFloat;
			float num2 = tagNodeList2[1] as TagNodeFloat;
			float num3 = tagNodeList2[2] as TagNodeFloat;
			tagNodeList = new TagNodeList(TagType.TAG_DOUBLE);
			tagNodeList.Add(new TagNodeDouble(num));
			tagNodeList.Add(new TagNodeDouble(num2));
			tagNodeList.Add(new TagNodeDouble(num3));
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sguSGNNs3L3(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, TagNodeCompound> dictionary = DjbSGoWcIGk(P_1);
		TagNodeCompound tagNodeCompound = rB9SGuB2MhB(P_0);
		if (tagNodeCompound != null)
		{
			TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
			float num = tagNodeList[0] as TagNodeFloat;
			float num2 = tagNodeList[1] as TagNodeFloat;
			float num3 = tagNodeList[2] as TagNodeFloat;
			TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_DOUBLE);
			tagNodeList2.Add(new TagNodeDouble(num));
			tagNodeList2.Add(new TagNodeDouble(num2));
			tagNodeList2.Add(new TagNodeDouble(num3));
			foreach (string key in dictionary.Keys)
			{
				TagNodeCompound tagNodeCompound2 = dictionary[key];
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] = tagNodeList2.Copy();
			}
		}
		ukbSGQ1GptT(dictionary);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KMXSGD1uUel(string P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Path.Combine(P_1.PCWorldFolder, P_0);
		FileUtils.TTSSgQ9uTyR(text);
		FileUtils.mNASgoolwl6(text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SavePCLevel(TagNodeCompound level, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			NBTFile nBTFile = new NBTFile(path);
			Stream dataOutputStream = nBTFile.GetDataOutputStream();
			if (dataOutputStream == null)
			{
				NbtIOException ex = new NbtIOException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71766));
				ex.Data[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] = level;
				throw ex;
			}
			NbtTree nbtTree = new NbtTree(level);
			nbtTree.UseBigEndian = true;
			nbtTree.WriteTo(dataOutputStream);
			dataOutputStream.Close();
			return true;
		}
		catch (Exception innerException)
		{
			LevelIOException ex2 = new LevelIOException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71876), innerException);
			ex2.Data[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] = level;
			throw ex2;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TagNodeCompound xTjSGcOSfFO(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516));
		if (File.Exists(path))
		{
			NBTFile nBTFile = new NBTFile(path);
			Stream dataInputStream = nBTFile.GetDataInputStream();
			if (dataInputStream != null)
			{
				NbtTree nbtTree = new NbtTree();
				nbtTree.UseBigEndian = true;
				nbtTree.ReadFrom(dataInputStream);
				result = nbtTree.Root;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TagNodeCompound xoBSGJvJUoq(ConversionFormat P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		string fileName = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71932);
		if (P_0 == ConversionFormat.Aquatic)
		{
			fileName = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71984);
		}
		if (P_0 == ConversionFormat.Aquatic113)
		{
			fileName = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72036);
		}
		byte[] resourceBytes = EmbeddedUtils.GetResourceBytes(fileName);
		if (resourceBytes != null)
		{
			resourceBytes = lxe7hMuSirBXGUQugsD.RacSP6aHwsa(resourceBytes);
			MemoryStream memoryStream = new MemoryStream(resourceBytes);
			NbtTree nbtTree = new NbtTree();
			nbtTree.UseBigEndian = true;
			nbtTree.ReadFrom(memoryStream);
			result = nbtTree.Root;
			memoryStream.Close();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TagNodeCompound rB9SGuB2MhB(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_0);
		byte[] array = levelDBWorker.ReadDbValue(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72088));
		levelDBWorker.CloseDB();
		if (array != null)
		{
			MemoryStream s = new MemoryStream(array);
			NbtTree nbtTree = new NbtTree(s);
			if (nbtTree.Root != null)
			{
				result = nbtTree.Root;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, TagNodeCompound> DjbSGoWcIGk(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, TagNodeCompound> dictionary = new Dictionary<string, TagNodeCompound>();
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72118));
		string[] files = Directory.GetFiles(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28454));
		string[] array = files;
		foreach (string text in array)
		{
			NBTFile nBTFile = new NBTFile(text);
			Stream dataInputStream = nBTFile.GetDataInputStream();
			if (dataInputStream != null)
			{
				NbtTree nbtTree = new NbtTree();
				nbtTree.UseBigEndian = true;
				nbtTree.ReadFrom(dataInputStream);
				dictionary.Add(text, nbtTree.Root);
			}
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ukbSGQ1GptT(Dictionary<string, TagNodeCompound> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (string key in P_0.Keys)
		{
			try
			{
				NBTFile nBTFile = new NBTFile(key);
				Stream dataOutputStream = nBTFile.GetDataOutputStream();
				if (dataOutputStream == null)
				{
					NbtIOException ex = new NbtIOException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71766));
					throw ex;
				}
				NbtTree nbtTree = new NbtTree(P_0[key]);
				nbtTree.UseBigEndian = true;
				nbtTree.WriteTo(dataOutputStream);
				dataOutputStream.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ConvertStatus Dk6SGO7M1kw(string P_0, string P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ConvertStatus convertStatus = new ConvertStatus();
		try
		{
			PEEntityConverters.ResetUniqueID();
			gyASGCx4pBt(P_1, P_0, P_2);
			InitPCConversion(P_0, P_1, P_2, convertStatus);
			if (P_2.UpdateLevelData)
			{
				zDSSGALiw7o(P_0, P_1, P_2);
			}
			nWYSGhQ0PhI(P_1);
			if (string.IsNullOrWhiteSpace(Working.OriginalFolder))
			{
				string name = new DirectoryInfo(P_0).Name;
				Working.OriginalFolder = Path.Combine(Utils.GetGetMCPESaveFolder(), name);
				File.WriteAllText(Path.Combine(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810)), name);
			}
			Thread.Sleep(500);
		}
		catch (Exception ex)
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55812) + Environment.NewLine + ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55870));
		}
		return convertStatus;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gyASGCx4pBt(string P_0, string P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EBYSbWOeOyB.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70944));
		try
		{
			MapWorker mapWorker = new MapWorker();
			if (P_2.ConvertInto == ConvertIntoType.EmptyWorld)
			{
				mapWorker.ixeS3TpoUsZ(P_0);
			}
			Working.MapIds = mapWorker.Rt6SYdPfIFx(P_0, P_1, EBYSbWOeOyB);
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitPCConversion(string pcPath, string workingFolder, ConvertParameters convertParameters, ConvertStatus convertStatus)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Path.Combine(workingFolder, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270));
		if (convertParameters.ConvertInto == ConvertIntoType.EmptyWorld)
		{
			text = Path.Combine(workingFolder, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72142));
			Directory.CreateDirectory(text);
		}
		else if (convertParameters.ConvertInto == ConvertIntoType.EmptyDimension)
		{
			PEProcessWorker pEProcessWorker = new PEProcessWorker();
			if (convertParameters.ConvertOverworld)
			{
				pEProcessWorker.DeleteAllRegionsInDimension(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936), Working.T92StMGt1p4());
			}
			if (convertParameters.ConvertNether)
			{
				pEProcessWorker.DeleteAllRegionsInDimension(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780), Working.T92StMGt1p4());
			}
			if (convertParameters.ConvertTheEnd)
			{
				pEProcessWorker.DeleteAllRegionsInDimension(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794), Working.T92StMGt1p4());
			}
		}
		string[] dimensionFolderNames = Constants.dimensionFolderNames;
		foreach (string text2 in dimensionFolderNames)
		{
			if ((text2.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936) && convertParameters.ConvertOverworld) || (text2.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60336) && convertParameters.ConvertNether) || (text2.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60350) && convertParameters.ConvertTheEnd))
			{
				InitPCConversion(text2, pcPath, text, workingFolder, convertParameters, convertStatus);
			}
		}
		if (convertParameters.ConvertInto == ConvertIntoType.EmptyWorld)
		{
			string randomFileName = Path.GetRandomFileName();
			Directory.Move(Path.Combine(workingFolder, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)), Path.Combine(workingFolder, randomFileName));
			Directory.Move(Path.Combine(workingFolder, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72142)), Path.Combine(workingFolder, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
			Directory.Delete(Path.Combine(workingFolder, randomFileName), recursive: true);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitPCConversion(string dimensionName, string pcPath, string peDBPath, string workingFolder, ConvertParameters convertParameters, ConvertStatus convertStatus)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = daLSG7b539Q(pcPath, dimensionName);
		LevelDBWorker levelDBWorker = new LevelDBWorker();
		levelDBWorker.OpenDB(peDBPath, createIfNotExist: true);
		int num = 0;
		if (!FileUtils.CheckFolderExists(text))
		{
			return;
		}
		ConvertToPEFromPC.activeChests = new List<ConversionChest>();
		string[] files = Directory.GetFiles(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40696));
		List<ManualResetEvent> list = new List<ManualResetEvent>();
		List<ConvertToPEParameters> list2 = new List<ConvertToPEParameters>();
		List<ConvertToPEParameters> list3 = new List<ConvertToPEParameters>();
		List<ConvertToPEParameters> list4 = new List<ConvertToPEParameters>();
		List<ConvertToPEParameters> list5 = new List<ConvertToPEParameters>();
		ConvertToPEParameters convertToPEParameters = null;
		string[] array = files;
		foreach (string path in array)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
			ManualResetEvent manualResetEvent = new ManualResetEvent(initialState: false);
			list.Add(manualResetEvent);
			ConvertToPEParameters item = new ConvertToPEParameters(dimensionName, fileNameWithoutExtension, text, workingFolder, convertParameters, levelDBWorker, manualResetEvent);
			list2.Add(item);
		}
		bool flag = false;
		while (!flag)
		{
			if (convertToPEParameters == null && list4.Count > 0)
			{
				ConvertToPEParameters convertToPEParameters2 = list4[0];
				list4.RemoveAt(0);
				convertToPEParameters2.Done = false;
				convertToPEParameters = convertToPEParameters2;
				ConvertToPEFromPC convertToPEFromPC = new ConvertToPEFromPC();
				ThreadPool.QueueUserWorkItem(convertToPEFromPC.WritePEBatch, convertToPEParameters2);
			}
			if (list2.Count > 0 && list3.Count < 3)
			{
				ConvertToPEParameters convertToPEParameters3 = list2[0];
				list2.RemoveAt(0);
				list3.Add(convertToPEParameters3);
				ConvertToPEFromPC convertToPEFromPC2 = new ConvertToPEFromPC();
				ThreadPool.QueueUserWorkItem(convertToPEFromPC2.ExtractPCRegion, convertToPEParameters3);
			}
			num = 0;
			for (int num2 = list3.Count - 1; num2 >= 0; num2--)
			{
				ConvertToPEParameters convertToPEParameters4 = list3[num2];
				if (convertToPEParameters4.Done && list4.Count < 3)
				{
					list3.RemoveAt(num2);
					list4.Add(convertToPEParameters4);
					tg8Sbpuo1Wi += convertToPEParameters4.ProcessedChunkCount;
				}
				else
				{
					num += convertToPEParameters4.ProcessedChunkCount;
				}
			}
			fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72158) + (num + tg8Sbpuo1Wi));
			Thread.Sleep(50);
			if (convertToPEParameters != null && convertToPEParameters.Done)
			{
				list5.Add(convertToPEParameters);
				convertToPEParameters = null;
			}
			flag = list3.Count == 0 && list2.Count == 0 && list4.Count == 0 && convertToPEParameters == null;
		}
		BedrockChestConnections bedrockChestConnections = new BedrockChestConnections();
		int dimension = 0;
		if (Constants.dimensionByName.ContainsKey(dimensionName.ToLower()))
		{
			dimension = Constants.dimensionByName[dimensionName.ToLower()];
		}
		bedrockChestConnections.ProcessChests(dimension, ConvertToPEFromPC.activeChests, levelDBWorker);
		levelDBWorker.CloseDB();
		for (int j = 0; j < list.Count; j++)
		{
			list[j].WaitOne();
		}
		for (int k = 0; k < list5.Count; k++)
		{
			ConvertToPEParameters convertToPEParameters5 = list5[k];
			convertStatus.ProcessedChunkCount += convertToPEParameters5.ProcessedChunkCount;
			convertStatus.MissingChunkCount += convertToPEParameters5.MissingChunkCount;
			convertStatus.InvalidChunkCount += convertToPEParameters5.InvalidChunkCount;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string daLSG7b539Q(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = P_0 + P_1;
		if (P_1.ToLower() != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936) && Utils.GetRegionFileCount(text) == 0)
		{
			int regionFileCount = Utils.GetRegionFileCount(text + TwqSbVN044e);
			if (regionFileCount > 0)
			{
				text += TwqSbVN044e;
			}
		}
		return FileUtils.CheckFolderSep(text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zDSSGALiw7o(string P_0, string P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = P_2.ModifiedLevelNode;
		if (tagNodeCompound == null)
		{
			TagNodeCompound tagNodeCompound2 = PEUtility.LoadPELevel(P_1 + Working.WorkFolder);
			TagNodeCompound tagNodeCompound3 = xTjSGcOSfFO(P_0);
			tagNodeCompound = t5dSGdITJ6h(tagNodeCompound2, tagNodeCompound3, P_2.ConvertInto, P_2.FlatworldLayers);
		}
		string text = P_1 + Working.WorkFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516);
		lxe7hMuSirBXGUQugsD.EAISPUuIyGd(tagNodeCompound, text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TagNodeCompound t5dSGdITJ6h(TagNodeCompound P_0, TagNodeCompound P_1, ConvertIntoType P_2, string P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		if (P_1 != null)
		{
			tagNodeCompound = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeCompound;
		}
		if (P_0 != null && tagNodeCompound != null)
		{
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)] = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)].Copy();
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71168)))
			{
				int d = 1;
				string text = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71168)] as TagNodeString;
				if ((text.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71156) || !string.IsNullOrWhiteSpace(P_3)) && (P_2 == ConvertIntoType.EmptyWorld || P_2 == ConvertIntoType.EmptyDimension))
				{
					d = 2;
					P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41840)] = new TagNodeString(P_3);
				}
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71116)] = new TagNodeInt(d);
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71282)))
			{
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71198)] = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71282)].Copy();
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71248)] = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71282)].Copy();
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71312)))
			{
				int num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71312)] as TagNodeInt;
				if (num > 1)
				{
					num = 0;
				}
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71312)] = new TagNodeInt(num);
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71332)))
			{
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71332)] = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71332)].Copy();
			}
			long d2 = Utils.DateTimeToUnixTimestamp() / 1000;
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71344)] = new TagNodeLong(d2);
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71390)))
			{
				byte b = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71390)] as TagNodeByte;
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71368)] = new TagNodeFloat((int)b);
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71408)))
			{
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71408)] = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71408)].Copy();
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71460)))
			{
				byte b2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71460)] as TagNodeByte;
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71428)] = new TagNodeFloat((int)b2);
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71514)))
			{
				P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71484)] = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71514)].Copy();
			}
			int d3 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20568)] as TagNodeInt;
			int d4 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20584)] as TagNodeInt;
			int d5 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20600)] as TagNodeInt;
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20568)] = new TagNodeInt(d3);
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20584)] = new TagNodeInt(d4);
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20600)] = new TagNodeInt(d5);
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int IvsSGHfklpm(int P_0, int P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveFiles(string workingFolder, Dictionary<string, ModifiedFile> modifiedFiles)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fKhSbbZ4owL(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72196));
		BpqSGFeVDZf(workingFolder, modifiedFiles);
		L1dSGj5dFLW(modifiedFiles);
		qhPSGsrgvZn(workingFolder, modifiedFiles.Values.ToList());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BpqSGFeVDZf(string P_0, Dictionary<string, ModifiedFile> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<ModifiedFile> list = new List<ModifiedFile>();
		foreach (string key in P_1.Keys)
		{
			ModifiedFile modifiedFile = P_1[key];
			if (modifiedFile.FileState == FileStateType.PINNED)
			{
				continue;
			}
			if (modifiedFile.Tag is ChunkData)
			{
				if (modifiedFile.FileState == FileStateType.MODIFIED)
				{
					modifiedFile.FileNode.Save();
				}
				list.Add(modifiedFile);
			}
			else if (modifiedFile.FileState == FileStateType.MODIFIED && modifiedFile.FileNode != null)
			{
				modifiedFile.FileNode.Save();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void L1dSGj5dFLW(Dictionary<string, ModifiedFile> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<string> list = new List<string>();
		foreach (string key in P_0.Keys)
		{
			if (P_0[key].FileState == FileStateType.DELETED)
			{
				list.Add(key);
			}
			else if (P_0[key].FileState == FileStateType.MODIFIED)
			{
				P_0[key].FileState = FileStateType.PINNED;
			}
		}
		foreach (string item in list)
		{
			P_0.Remove(item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCSupport()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		TwqSbVN044e = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64928);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCSupport(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		TwqSbVN044e = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64928);
		EBYSbWOeOyB = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qr1SG8OLIip(ConvertParameters P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		if (P_0.ConvertOverworld)
		{
			num += Constants.regionSizes[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936)];
		}
		if (P_0.ConvertNether)
		{
			num += Constants.regionSizes[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780)];
		}
		if (P_0.ConvertTheEnd)
		{
			num += Constants.regionSizes[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794)];
		}
		re8SbZwEFw0 = num * 4;
		tg8Sbpuo1Wi = 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ss8SG9VEEqg(string P_0, bool P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num = ((!P_1) ? (num + Constants.regionSizes[P_0]) : (num + Constants.regionSizesExt[P_0]));
		re8SbZwEFw0 = num * 4;
		tg8Sbpuo1Wi = 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FSbSGIi11uE(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		re8SbZwEFw0 = num;
		tg8Sbpuo1Wi = 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qpOSGzwrG3B(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100)) > 0)
		{
			string text = P_0.Substring(0, P_0.LastIndexOf('\\'));
			FileUtils.TTSSgQ9uTyR(text);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void G1MSbTP4UwV(IndexEntry P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qpOSGzwrG3B(P_1 + P_0.FilePath);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nWfSbS8IZYO(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DateTime now = DateTime.Now;
		string text = P_0 + string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72238), now.Month, now.Day, now.Year, now.Hour, now.Minute, now.Second);
		if (File.Exists(P_0))
		{
			FileUtils.HONSgOivHYv(P_0, text);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cbnSbGsPWK5(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tg8Sbpuo1Wi++;
		int num = (int)((float)(tg8Sbpuo1Wi + 1) / (float)re8SbZwEFw0 * 100f);
		fKhSbbZ4owL(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fKhSbbZ4owL(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (EBYSbWOeOyB != null)
		{
			EBYSbWOeOyB.ReportProgress(P_1, P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static string NZ9Sbvnr1e2(IndexEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.FileExt;
	}
}
