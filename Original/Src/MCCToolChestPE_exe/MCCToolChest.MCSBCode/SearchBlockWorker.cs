using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class SearchBlockWorker
{
	private BackgroundWorker qe3Si8rAGho;

	private int sI6Si9GfwFs;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchBlockWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchBlockWorker(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		qe3Si8rAGho = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<string, List<BlockSearchResult>> DoSearch(Block searchBlock, string region, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Search(searchBlock, region, outFolderPath);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<string, List<BlockSearchResult>> Search(Block searchBlock, string dimension, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		C8YSiHrvcKo(dimension);
		Dictionary<string, List<BlockSearchResult>> dictionary = new Dictionary<string, List<BlockSearchResult>>();
		ManualResetEvent[] array = new ManualResetEvent[4];
		SearchBlockParameter[] array2 = new SearchBlockParameter[4];
		int num = 0;
		string[] regionFileNames = Constants.regionFileNames;
		foreach (string region in regionFileNames)
		{
			array[num] = new ManualResetEvent(initialState: false);
			SearchBlockParameter searchBlockParameter = new SearchBlockParameter(searchBlock, dimension, region, outFolderPath, array[num]);
			SearchBlocks searchBlocks = new SearchBlocks();
			ThreadPool.QueueUserWorkItem(searchBlocks.SearchRegion, searchBlockParameter);
			array2[num] = searchBlockParameter;
			num++;
		}
		bool flag = false;
		while (!flag)
		{
			int num2 = 0;
			flag = true;
			for (int j = 0; j < 4; j++)
			{
				if (!array2[j].Completed)
				{
					flag = false;
				}
				num2 += array2[j].ChunkProcessedCount;
			}
			pV8SiF3U2Ze(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88772) + num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71754) + sI6Si9GfwFs + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88754), num2);
			Thread.Sleep(100);
		}
		WaitHandle.WaitAll(array);
		for (int k = 0; k < 4; k++)
		{
			dictionary.Add(array2[k].Region, array2[k].Result);
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void C8YSiHrvcKo(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		sI6Si9GfwFs = num * 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pV8SiF3U2Ze(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)sI6Si9GfwFs * 100f);
		tSjSijTt420(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tSjSijTt420(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (qe3Si8rAGho != null)
		{
			qe3Si8rAGho.ReportProgress(P_1, P_0);
		}
	}
}
