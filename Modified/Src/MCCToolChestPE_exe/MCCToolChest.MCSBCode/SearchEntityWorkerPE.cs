using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCPELevelDBI.workers;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class SearchEntityWorkerPE
{
	private BackgroundWorker ptqSiPNmKwV;

	private int BYMSiRhbygf;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchEntityWorkerPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchEntityWorkerPE(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ptqSiPNmKwV = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<string, List<EntitySearchResult>> DoSearch(string dimension, List<NodeSearchcriterion> searchCriteria, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, List<EntitySearchResult>> dictionary = new Dictionary<string, List<EntitySearchResult>>();
		PEDimension pEDimension = PEUtility.GetPEDimension(dimension);
		PEProcessWorker pEProcessWorker = new PEProcessWorker(ptqSiPNmKwV);
		List<EntitySearchResult> value = pEProcessWorker.SearchEntities(pEDimension, searchCriteria, Working.T92StMGt1p4());
		dictionary.Add(dimension, value);
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iQDSiUToBBw(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		BYMSiRhbygf = num * 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ImbSiLFGwj1(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)BYMSiRhbygf * 100f);
		JBgSigUlfSE(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JBgSigUlfSE(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ptqSiPNmKwV != null)
		{
			ptqSiPNmKwV.ReportProgress(P_1, P_0);
		}
	}
}
