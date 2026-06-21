using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class ReplaceBlockGlobalWorkerPE
{
	private BackgroundWorker Q3fSiNIngBl;

	private int tMSSiD1j9Wg;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceBlockGlobalWorkerPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceBlockGlobalWorkerPE(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Q3fSiNIngBl = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoReplace(string dimension, List<BlockChange> replacementBlockList, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (replacementBlockList.Count != 0)
		{
			PEDimension pEDimension = PEUtility.GetPEDimension(dimension);
			IfVSiryCoZX(dimension);
			ReplaceBlocksGlobal replaceBlocksGlobal = new ReplaceBlocksGlobal(Q3fSiNIngBl);
			if (replaceBlocksGlobal.DoSearchReplace(pEDimension, replacementBlockList, outFolderPath))
			{
				Working.DataChanged = true;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IfVSiryCoZX(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		tMSSiD1j9Wg = num * 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WG4Si5BSbgw(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)tMSSiD1j9Wg * 100f);
		HqSSi6GuvYo(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HqSSi6GuvYo(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Q3fSiNIngBl != null)
		{
			Q3fSiNIngBl.ReportProgress(P_1, P_0);
		}
	}
}
