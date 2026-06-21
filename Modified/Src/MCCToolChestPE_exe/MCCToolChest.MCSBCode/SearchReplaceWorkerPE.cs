using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.model.SearchReplace;
using MCCToolChest.PECode;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class SearchReplaceWorkerPE
{
	private BackgroundWorker XyNSZgCRgbF;

	private int KeaSZPblLTp;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchReplaceWorkerPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchReplaceWorkerPE(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		XyNSZgCRgbF = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<string, SearchReplaceResult> DoSearchReplace(string dimension, SearchReplaceGroup searchReplaceGroup, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = PEUtility.GetPEDimension(dimension);
		SearchReplaceChunksPE searchReplaceChunksPE = new SearchReplaceChunksPE(XyNSZgCRgbF);
		SearchReplaceResult value = searchReplaceChunksPE.Search(pEDimension, searchReplaceGroup, outFolderPath);
		Dictionary<string, SearchReplaceResult> dictionary = new Dictionary<string, SearchReplaceResult>();
		dictionary.Add(dimension, value);
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void otKSZMaJNJX(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		KeaSZPblLTp = num * 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void S3CSZUnLApq(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)KeaSZPblLTp * 100f);
		VtTSZLZ3bIG(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VtTSZLZ3bIG(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (XyNSZgCRgbF != null)
		{
			XyNSZgCRgbF.ReportProgress(P_1, P_0);
		}
	}
}
