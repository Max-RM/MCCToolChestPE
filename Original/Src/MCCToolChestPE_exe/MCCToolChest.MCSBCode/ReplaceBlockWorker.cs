using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class ReplaceBlockWorker
{
	private BackgroundWorker E7TSiQtq9Ki;

	private int qJKSiOa6ipK;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceBlockWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceBlockWorker(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		E7TSiQtq9Ki = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoReplace(Block replacementBlock, List<BlockSearchResult> changeBlockList, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (changeBlockList.Count != 0)
		{
			Dictionary<string, Dictionary<int, List<BlockSearchResult>>> changeBlockList2 = ou3SiJF9fV1(changeBlockList);
			if (Replace(replacementBlock, changeBlockList2, outFolderPath))
			{
				hFtSicD9Sdg(outFolderPath);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hFtSicD9Sdg(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MCSupport mCSupport = new MCSupport(E7TSiQtq9Ki);
		mCSupport.nWYSGhQ0PhI(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, Dictionary<int, List<BlockSearchResult>>> ou3SiJF9fV1(List<BlockSearchResult> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, Dictionary<int, List<BlockSearchResult>>> dictionary = new Dictionary<string, Dictionary<int, List<BlockSearchResult>>>();
		foreach (BlockSearchResult item in P_0)
		{
			int chunkIndex = item.ChunkIndex.ChunkIndex;
			string region = item.Region;
			if (!dictionary.ContainsKey(region))
			{
				dictionary[region] = new Dictionary<int, List<BlockSearchResult>>();
			}
			if (!dictionary[region].ContainsKey(chunkIndex))
			{
				dictionary[region][chunkIndex] = new List<BlockSearchResult>();
			}
			dictionary[region][chunkIndex].Add(item);
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Replace(Block replacementBlock, Dictionary<string, Dictionary<int, List<BlockSearchResult>>> changeBlockList, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int count = changeBlockList.Count;
		ManualResetEvent[] array = new ManualResetEvent[count];
		ReplaceBlockParameter[] array2 = new ReplaceBlockParameter[count];
		int num = 0;
		foreach (Dictionary<int, List<BlockSearchResult>> value in changeBlockList.Values)
		{
			qJKSiOa6ipK += value.Count;
			array[num] = new ManualResetEvent(initialState: false);
			ReplaceBlockParameter replaceBlockParameter = new ReplaceBlockParameter(replacementBlock, value, outFolderPath, array[num]);
			ReplaceBlocks replaceBlocks = new ReplaceBlocks();
			ThreadPool.QueueUserWorkItem(replaceBlocks.Replace, replaceBlockParameter);
			array2[num] = replaceBlockParameter;
			num++;
		}
		bool flag = false;
		while (!flag)
		{
			int num2 = 0;
			flag = true;
			for (int i = 0; i < count; i++)
			{
				if (array2[i].ProcessState == ProcessStateType.Processing)
				{
					flag = false;
				}
				num2 += array2[i].ChunkProcessedCount;
			}
			oGUSiuZcZJP(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88730) + num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71754) + qJKSiOa6ipK + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88754), num2);
			Thread.Sleep(100);
		}
		WaitHandle.WaitAll(array);
		bool result = true;
		for (int j = 0; j < count; j++)
		{
			if (array2[j].ProcessState == ProcessStateType.Error)
			{
				result = false;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oGUSiuZcZJP(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)qJKSiOa6ipK * 100f);
		p7uSioOPUH7(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void p7uSioOPUH7(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (E7TSiQtq9Ki != null)
		{
			E7TSiQtq9Ki.ReportProgress(P_1, P_0);
		}
	}
}
