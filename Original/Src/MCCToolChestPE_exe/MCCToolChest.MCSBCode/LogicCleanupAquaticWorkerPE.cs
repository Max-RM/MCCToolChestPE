using System.ComponentModel;
using System.Runtime.CompilerServices;
using MCCToolChest.forms;
using MCCToolChest.model;
using MCCToolChest.PECode;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class LogicCleanupAquaticWorkerPE
{
	private BackgroundWorker OK4IYFnsZR;

	private int v5iI34W7C9;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LogicCleanupAquaticWorkerPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LogicCleanupAquaticWorkerPE(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		OK4IYFnsZR = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoReplace(string dimension, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = PEUtility.GetPEDimension(dimension);
		JPnIP5hQbC(dimension);
		LogicCleanupAquatic logicCleanupAquatic = new LogicCleanupAquatic(OK4IYFnsZR);
		if (logicCleanupAquatic.DoSearchReplace(pEDimension, outFolderPath))
		{
			string changedChunkList = logicCleanupAquatic.chunkChanges.ToString();
			BlockReplaceResults blockReplaceResults = new BlockReplaceResults(changedChunkList);
			blockReplaceResults.ShowDialog();
			Working.DataChanged = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JPnIP5hQbC(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		v5iI34W7C9 = num * 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JMdIRSbdGP(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)v5iI34W7C9 * 100f);
		YsEIk6kJaP(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YsEIk6kJaP(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (OK4IYFnsZR != null)
		{
			OK4IYFnsZR.ReportProgress(P_1, P_0);
		}
	}
}
