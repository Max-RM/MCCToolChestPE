using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCPELevelDBI.workers;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class ReplacePEBiomeGlobalWorker
{
	private BackgroundWorker zS6Si1Hrm4d;

	private int nfWSiEb4jYN;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplacePEBiomeGlobalWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplacePEBiomeGlobalWorker(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		zS6Si1Hrm4d = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoReplace(string dimension, List<BiomeChange> replacementBiomeList, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		xcDSikyqw1K(dimension);
		if (replacementBiomeList.Count != 0)
		{
			PEDimension pEDimension = PEUtility.GetPEDimension(dimension);
			PEProcessWorker pEProcessWorker = new PEProcessWorker(zS6Si1Hrm4d);
			if (pEProcessWorker.ReplaceBiomes(pEDimension, replacementBiomeList, outFolderPath))
			{
				Working.DataChanged = true;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xcDSikyqw1K(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		nfWSiEb4jYN = num * 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mfMSiYSv9m7(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)nfWSiEb4jYN * 100f);
		MMKSi3hmqL7(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MMKSi3hmqL7(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (zS6Si1Hrm4d != null)
		{
			zS6Si1Hrm4d.ReportProgress(P_1, P_0);
		}
	}
}
