using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers.converterHelpers;

public class JavaFromBedrockItemConverter
{
	private Dictionary<string, string> WSRSk1XSXjA;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessItems(TagNodeList list, int version = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (list == null)
		{
			return;
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			TagNodeCompound item = list[num] as TagNodeCompound;
			bool flag = false;
			try
			{
				flag = ProcessItem(item, version);
			}
			catch (Exception)
			{
			}
			if (!flag)
			{
				list.Remove(item);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ProcessItem(TagNodeCompound item, int version = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short num = -1;
		short num2 = 0;
		string text = null;
		string text2 = null;
		if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)))
		{
			num2 = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] as TagNodeShort;
		}
		if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)))
		{
			text2 = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] as TagNodeString;
		}
		else if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
		{
			if (item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				text2 = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
			}
			else if (item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeShort)
			{
				num = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeShort;
				if (BlockMaster.PEBlocksById.ContainsKey(num))
				{
					text2 = BlockMaster.PEBlocksById[num].bedrock.name;
				}
				else if (ItemTranslations.BedrockItemsById.ContainsKey(num))
				{
					text2 = ItemTranslations.BedrockItemsById[num].BedrockName;
				}
			}
		}
		if (BlockMaster.PEBlocksByName.ContainsKey(text2))
		{
			text = BlockMaster.GetBedrockBlockState(text2, num2).masterBlock.Name;
		}
		else if (ItemTranslations.BedrockItemsByName.ContainsKey(text2))
		{
			ItemTranslate itemTranslate = ItemTranslations.cw0SB9KIOKd(text2, num2);
			text = itemTranslate.JavaName;
		}
		bool flag = text != null;
		if (!flag)
		{
			item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] = new TagNodeByte(0);
		}
		item.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196));
		if (version >= 1628)
		{
			item.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096));
		}
		item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeString(text);
		if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
		{
			TagNodeCompound tagNodeCompound = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
			AWGSk3DQ402(tagNodeCompound);
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243580)))
			{
				byte d = 1;
				if (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243580)] is TagNodeByte)
				{
					d = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243580)] as TagNodeByte;
				}
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243580)] = new TagNodeInt(d);
			}
		}
		if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606)) && item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606)] is TagNodeList)
		{
			TagNodeCompound tagNodeCompound2 = rXvSkRvY4x1(item);
			TagNodeList tagNodeList = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606)] as TagNodeList;
			uWBSkkVxcNm(tagNodeList);
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606)] = tagNodeList;
			item.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606));
		}
		if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630)) && item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630)] is TagNodeList)
		{
			TagNodeCompound tagNodeCompound3 = rXvSkRvY4x1(item);
			TagNodeList tagNodeList2 = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630)] as TagNodeList;
			uWBSkkVxcNm(tagNodeList2);
			tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630)] = tagNodeList2;
			item.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630));
		}
		if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(196432))
		{
			KQfSkYwWcej(item);
		}
		return flag;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound rXvSkRvY4x1(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
		{
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] = new TagNodeCompound();
		}
		return P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uWBSkkVxcNm(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			TagNodeString tagNodeString = P_0[i] as TagNodeString;
			tagNodeString.Data = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974) + tagNodeString.Data;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KQfSkYwWcej(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
		{
			return;
		}
		TagNodeCompound tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
		if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210128)))
		{
			long num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210128)] as TagNodeLong;
			if (Working.MapIds.ContainsKey(num))
			{
				num = Working.MapIds[num];
			}
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210128)] = new TagNodeInt((int)num);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AWGSk3DQ402(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<string> list = new List<string>();
		foreach (string key in P_0.Keys)
		{
			if (WSRSk1XSXjA.ContainsKey(key))
			{
				list.Add(key);
			}
		}
		foreach (string item in list)
		{
			P_0[WSRSk1XSXjA[item]] = P_0[item];
			P_0.Remove(item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JavaFromBedrockItemConverter()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		WSRSk1XSXjA = new Dictionary<string, string> { 
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243654),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210128)
		} };
	}
}
