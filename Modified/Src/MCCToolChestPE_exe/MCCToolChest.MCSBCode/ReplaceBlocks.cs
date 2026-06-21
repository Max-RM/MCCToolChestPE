using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using GKLeKtjBpORrSZSThqN;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class ReplaceBlocks
{
	private ReplaceBlockParameter lqiSixdCYLe;

	private Dictionary<int, TagNodeCompound> ExUSie3QaLI;

	[CompilerGenerated]
	private static Func<ChunkIndexEntry, int> eicSiMDq21w;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Replace(object threadContext)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lqiSixdCYLe = threadContext as ReplaceBlockParameter;
		try
		{
			Replace(lqiSixdCYLe.Dimension, lqiSixdCYLe.Region, lqiSixdCYLe.ReplacementBlock, lqiSixdCYLe.ReplaceChunkBlockList, lqiSixdCYLe.OutFolderPath);
			lqiSixdCYLe.ProcessState = ProcessStateType.Completed;
		}
		catch (Exception ex)
		{
			lqiSixdCYLe.ProcessState = ProcessStateType.Error;
			MessageBox.Show(ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88682));
		}
		lqiSixdCYLe.DoneEvent.Set();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Replace(string dimension, string region, Block replacementBlock, Dictionary<int, List<BlockSearchResult>> replaceChunkBlockList, string workingFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<ChunkIndexEntry> list = null;
		string text = workingFolder + Working.WorkFolder + FileUtils.CheckFolderSep(dimension) + region + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70546);
		string text2 = workingFolder + Working.WorkFolder + FileUtils.CheckFolderSep(dimension) + region + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88718);
		list = lxe7hMuSirBXGUQugsD.kM7SgjjqASt(text);
		if (list == null || list.Count <= 0)
		{
			return;
		}
		list = list.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (ChunkIndexEntry P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.ChunkIndex;
		}).ToList();
		using (BinaryReader binaryReader = new BinaryReader(File.Open(text, FileMode.Open)))
		{
			using BinaryWriter binaryWriter = new BinaryWriter(File.Open(text2, FileMode.Create));
			lxe7hMuSirBXGUQugsD.wZ4SPffRUG3(binaryWriter);
			List<int> list2 = cbmDOtjrLfpxQy3V0nH.PrNST9KgFDD()[dimension][region];
			for (int num = 0; num < list2.Count; num++)
			{
				ChunkIndexEntry chunkIndexEntry = list[list2[num]];
				if (chunkIndexEntry.OldChunkOffset == 0)
				{
					continue;
				}
				byte[] array = lxe7hMuSirBXGUQugsD.O8ZSPT5V6Yi(binaryReader, chunkIndexEntry);
				if (replaceChunkBlockList.ContainsKey(chunkIndexEntry.ChunkIndex))
				{
					bool flag = false;
					byte[] array2 = null;
					object obj = null;
					if (array2[0] == 10)
					{
						TagNodeCompound tagNodeCompound = lxe7hMuSirBXGUQugsD.KgPSP2NfV9O(array2);
						flag = gJUSitCMUcQ(tagNodeCompound, replaceChunkBlockList[chunkIndexEntry.ChunkIndex], replacementBlock);
						obj = tagNodeCompound;
					}
					if (flag)
					{
						ChunkData chunkData = new ChunkData();
						chunkData.WxMS0gYhqtY(chunkIndexEntry);
						if (array2 != null && array2.Length > 0)
						{
							array2 = lxe7hMuSirBXGUQugsD.XHFSP1WaY70(obj, chunkData);
							lxe7hMuSirBXGUQugsD.kJ1SPGSfj2q(array2, chunkIndexEntry, binaryWriter);
						}
					}
					else
					{
						lxe7hMuSirBXGUQugsD.kJ1SPGSfj2q(array, chunkIndexEntry, binaryWriter);
					}
					if (lqiSixdCYLe != null)
					{
						lqiSixdCYLe.ChunkProcessedCount++;
					}
				}
				else
				{
					lxe7hMuSirBXGUQugsD.kJ1SPGSfj2q(array, chunkIndexEntry, binaryWriter);
				}
			}
			lxe7hMuSirBXGUQugsD.rjsSPmBeBNR(binaryWriter, list);
		}
		FileUtils.DeleteFile(text);
		FileUtils.HONSgOivHYv(text2, text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool gJUSitCMUcQ(TagNodeCompound P_0, List<BlockSearchResult> P_1, Block P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		NibbleSetters nibbleSetters = new NibbleSetters();
		TagNodeCompound tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
		TagNodeByteArray tagNodeByteArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] as TagNodeByteArray;
		TagNodeByteArray tagNodeByteArray2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeByteArray;
		_ = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70018)];
		TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)] as TagNodeList;
		foreach (BlockSearchResult item in P_1)
		{
			int num = ((item.Y >= 128) ? 32768 : 0);
			int offset = num / 2;
			int num2 = ((item.Y < 128) ? item.Y : (item.Y - 128));
			int localX = item.LocalX;
			int localZ = item.LocalZ;
			int index = (localX << 11) | (localZ << 7) | (num2 + num);
			if (tagNodeByteArray[index] == item.Id)
			{
				tagNodeByteArray[index] = (byte)P_2.Id;
				if (P_2.Data != -1)
				{
					nibbleSetters.RegionSet(tagNodeByteArray2, localX, num2, localZ, P_2.Data, offset);
				}
				if (lxe7hMuSirBXGUQugsD.XySSPyn1o7b(item.Id))
				{
					lxe7hMuSirBXGUQugsD.gagSPBRJius(P_0, item.X, item.Y, item.Z);
				}
				if (lxe7hMuSirBXGUQugsD.XySSPyn1o7b((byte)P_2.Id))
				{
					lxe7hMuSirBXGUQugsD.uOuSPX05suh((byte)P_2.Id, tagNodeList, item.X, item.Y, item.Z, ExUSie3QaLI);
				}
			}
			else
			{
				result = false;
			}
		}
		if (lqiSixdCYLe != null)
		{
			lqiSixdCYLe.BlockProcessedCount += P_1.Count;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool zcDSiaXs3l8(TU17ChunkData P_0, List<BlockSearchResult> P_1, Block P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		NibbleSetters nibbleSetters = new NibbleSetters();
		byte[] blocks = P_0.Blocks;
		byte[] blockData = P_0.BlockData;
		_ = P_0.BlockLight;
		TagNodeList tagNodeList = P_0.NBTData[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)] as TagNodeList;
		_ = P_0.X;
		_ = P_0.Z;
		foreach (BlockSearchResult item in P_1)
		{
			int localX = item.LocalX;
			int y = item.Y;
			int localZ = item.LocalZ;
			int num = (localX * 16) | localZ | (y * 256);
			if (blocks[num] == item.Id)
			{
				blocks[num] = (byte)P_2.Id;
				if (P_2.Data != -1)
				{
					nibbleSetters.TU17SetFast(blockData, num, P_2.Data);
				}
				if (lxe7hMuSirBXGUQugsD.XySSPyn1o7b(item.Id))
				{
					lxe7hMuSirBXGUQugsD.gagSPBRJius(P_0.NBTData, item.X, item.Y, item.Z);
				}
				if (lxe7hMuSirBXGUQugsD.XySSPyn1o7b((byte)P_2.Id))
				{
					lxe7hMuSirBXGUQugsD.uOuSPX05suh((byte)P_2.Id, tagNodeList, item.X, item.Y, item.Z, ExUSie3QaLI);
				}
			}
			else
			{
				result = false;
			}
		}
		if (lqiSixdCYLe != null)
		{
			lqiSixdCYLe.BlockProcessedCount += P_1.Count;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceBlocks()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ExUSie3QaLI = new Dictionary<int, TagNodeCompound>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int zRfSiXrN2DN(ChunkIndexEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkIndex;
	}
}
