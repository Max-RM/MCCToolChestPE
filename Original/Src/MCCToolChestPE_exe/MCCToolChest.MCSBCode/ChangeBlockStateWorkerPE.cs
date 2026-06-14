using System.ComponentModel;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class ChangeBlockStateWorkerPE
{
	private BackgroundWorker YrF9nb6W2k;

	private int zVH9l6mbCm;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChangeBlockStateWorkerPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChangeBlockStateWorkerPE(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		YrF9nb6W2k = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoBlockStateFormatChange(BlockStateFormatType formatType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = false;
		foreach (PEDimension pEDimension in Working.PEDimensions)
		{
			ChangeBlockState changeBlockState = new ChangeBlockState(YrF9nb6W2k);
			if (changeBlockState.DoChangeProcess(pEDimension, Working.T92StMGt1p4(), formatType))
			{
				flag = true;
			}
		}
		if (flag)
		{
			Working.DataChanged = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iK89KxyUc8(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		zVH9l6mbCm = num * 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void O1w9hQZ38W(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)zVH9l6mbCm * 100f);
		Pqu9m2i4FC(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Pqu9m2i4FC(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (YrF9nb6W2k != null)
		{
			YrF9nb6W2k.ReportProgress(P_1, P_0);
		}
	}
}
