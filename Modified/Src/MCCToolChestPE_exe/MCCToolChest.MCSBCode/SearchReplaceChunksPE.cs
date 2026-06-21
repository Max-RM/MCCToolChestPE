using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.MCSBCode.searchReplace;
using MCCToolChest.model;
using MCCToolChest.model.SearchReplace;
using MCCToolChest.PECode;
using MCPELevelDBI.workers;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class SearchReplaceChunksPE
{
	private int bcISby6wfka;

	private int gaLSb002Btx;

	private MCNBTTreeSupport HsSSbBCpuUv;

	private BackgroundWorker IYVSbtkQPTq;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchReplaceChunksPE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		HsSSbBCpuUv = new MCNBTTreeSupport();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchReplaceChunksPE(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		HsSSbBCpuUv = new MCNBTTreeSupport();
		IYVSbtkQPTq = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchReplaceResult Search(PEDimension peDimension, SearchReplaceGroup group, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		SearchReplaceResult searchReplaceResult = new SearchReplaceResult();
		int count = peDimension.Region.Values.Count;
		int num = 0;
		foreach (PERegion value in peDimension.Region.Values)
		{
			string text = value.ToString();
			pYMSb2ml2d9(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64314) + text, (int)((float)num / (float)count * 100f));
			wCbSbiNdTKi(peDimension, value, group, searchReplaceResult, levelDBWorker);
			num++;
		}
		levelDBWorker.CloseDB();
		return searchReplaceResult;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool wCbSbiNdTKi(PEDimension P_0, PERegion P_1, SearchReplaceGroup P_2, SearchReplaceResult P_3, LevelDBWorker P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 32; j++)
			{
				if (yTSSbsb30Jh(P_0, P_1, P_2, P_3, lxe7hMuSirBXGUQugsD.QdsSP76hcgY(i, P_1.RX), lxe7hMuSirBXGUQugsD.QdsSP76hcgY(j, P_1.RZ), P_4))
				{
					result = true;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool yTSSbsb30Jh(PEDimension P_0, PERegion P_1, SearchReplaceGroup P_2, SearchReplaceResult P_3, int P_4, int P_5, LevelDBWorker P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_4, P_1.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_5, P_1.RZ);
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		TagNodeList tagNodeList = null;
		TagNodeList tagNodeList2 = null;
		if (P_1.Chunks[num3] == 1)
		{
			P_3.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72312) + num + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72344) + num2);
			P_3.TabCount++;
			bcISby6wfka = num;
			gaLSb002Btx = num2;
			byte[] array = PEUtility.BuildChunkKey(P_1.Dimension, num, num2, 49);
			byte[] array2 = P_6.ReadDbValue(array);
			if (array2 != null)
			{
				tagNodeList = jn5SbK3Bk60(array2);
			}
			array[array.Length - 1] = 50;
			array2 = P_6.ReadDbValue(array);
			if (array2 != null)
			{
				tagNodeList2 = jn5SbK3Bk60(array2);
			}
			foreach (SearchReplaceCriteria item in P_2.Items)
			{
				Dictionary<string, object> dictionary = ngISblJvjl5(P_2.Variables, item.Variables);
				if (!item.Active)
				{
					continue;
				}
				if (tagNodeList != null && o0cSbhOLxuT(tagNodeList, EntityType.TileEntity, item, dictionary, P_3))
				{
					result = true;
					array[array.Length - 1] = 49;
					S0kSbqQgHrA(array, tagNodeList, P_6);
				}
				if (tagNodeList2 != null)
				{
					PEUtility.ConvertIDsToPC(tagNodeList2);
					if (o0cSbhOLxuT(tagNodeList2, EntityType.Entity, item, dictionary, P_3))
					{
						result = true;
						PEUtility.ConvertIDsToPE(tagNodeList2);
						array[array.Length - 1] = 50;
						S0kSbqQgHrA(array, tagNodeList2, P_6);
					}
				}
			}
			P_3.TabCount--;
			P_3.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72356));
			P_3.AddResult("");
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void S0kSbqQgHrA(byte[] P_0, TagNodeList P_1, LevelDBWorker P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < P_1.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = P_1[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		P_2.Put(P_0, memoryStream.ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList jn5SbK3Bk60(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream(P_0);
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		while (memoryStream.Position < memoryStream.Length)
		{
			NbtTree nbtTree = new NbtTree(memoryStream);
			if (nbtTree.Root != null)
			{
				TagNodeCompound root = nbtTree.Root;
				tagNodeList.Add(root);
			}
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool o0cSbhOLxuT(TagNodeList P_0, EntityType P_1, SearchReplaceCriteria P_2, Dictionary<string, object> P_3, SearchReplaceResult P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		string[] array = P_2.NodeSelector.Split(',');
		List<string> list = new List<string>();
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i].Trim().ToLower();
			if (!string.IsNullOrWhiteSpace(text))
			{
				list.Add(text);
			}
		}
		for (int num = P_0.Count - 1; num >= 0; num--)
		{
			string[] array2 = new string[0];
			TagNodeCompound item = P_0[num] as TagNodeCompound;
			List<TagNode> list2 = new List<TagNode>();
			list2.Add(P_0);
			list2.Add(item);
			List<TagNode> list3 = list2;
			if (P_1 == EntityType.Entity && (list.Count == 0 || list.Contains(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54980))))
			{
				if (RggSbmdtGV2(list3, array2, P_2, P_3, P_4, ""))
				{
					result = true;
				}
			}
			else if (P_1 == EntityType.TileEntity && (list.Count == 0 || list.Contains(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72378))) && z9LSbnykK7q(list3, array2, P_2, P_3, P_4))
			{
				result = true;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool RggSbmdtGV2(List<TagNode> P_0, string[] P_1, SearchReplaceCriteria P_2, Dictionary<string, object> P_3, SearchReplaceResult P_4, string P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SearchReplaceProcess searchReplaceProcess = new SearchReplaceProcess(bcISby6wfka, gaLSb002Btx);
		return searchReplaceProcess.InitSRProcess(P_0, P_1, P_2, P_3, P_4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool z9LSbnykK7q(List<TagNode> P_0, string[] P_1, SearchReplaceCriteria P_2, Dictionary<string, object> P_3, SearchReplaceResult P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SearchReplaceProcess searchReplaceProcess = new SearchReplaceProcess(bcISby6wfka, gaLSb002Btx);
		return searchReplaceProcess.InitSRProcess(P_0, P_1, P_2, P_3, P_4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, object> ngISblJvjl5(List<SearchReplaceVariable> P_0, List<SearchReplaceVariable> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (SearchReplaceVariable item in P_0)
		{
			dictionary[item.Name] = item.ToVariable();
		}
		foreach (SearchReplaceVariable item2 in P_1)
		{
			dictionary[item2.Name] = item2.ToVariable();
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pYMSb2ml2d9(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (IYVSbtkQPTq != null)
		{
			IYVSbtkQPTq.ReportProgress(P_1, P_0);
		}
	}
}
