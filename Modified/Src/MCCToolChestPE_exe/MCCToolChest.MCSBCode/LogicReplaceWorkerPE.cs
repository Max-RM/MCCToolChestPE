using System.ComponentModel;
using System.Runtime.CompilerServices;
using MCCToolChest.forms;
using MCCToolChest.model;
using MCCToolChest.PECode;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class LogicReplaceWorkerPE
{
	private BackgroundWorker viHIN9SgS2;

	private int HgmID4UEmI;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LogicReplaceWorkerPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LogicReplaceWorkerPE(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		viHIN9SgS2 = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoReplace(string dimension, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = PEUtility.GetPEDimension(dimension);
		MpyIr7SsxE(dimension);
		LogicReplace logicReplace = new LogicReplace(viHIN9SgS2);
		if (logicReplace.DoSearchReplace(pEDimension, outFolderPath))
		{
			string changedChunkList = logicReplace.chunkChanges.ToString();
			BlockReplaceResults blockReplaceResults = new BlockReplaceResults(changedChunkList);
			blockReplaceResults.ShowDialog();
			Working.DataChanged = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MpyIr7SsxE(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		HgmID4UEmI = num * 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JlGI5MPXgC(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)HgmID4UEmI * 100f);
		XfUI69ja8s(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XfUI69ja8s(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (viHIN9SgS2 != null)
		{
			viHIN9SgS2.ReportProgress(P_1, P_0);
		}
	}
}
