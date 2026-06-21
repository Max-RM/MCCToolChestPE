using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DekWW8jSE3fVOo1d5ao;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class BedrockFromJavaItemConverter
{
	private Dictionary<string, int> AP3S3Xly1SA;

	private PETileEntityConverters qsMS3xMn3SP;

	private bool nI0S3eFD95Y;

	private Dictionary<string, string> c6aS3Mi5Mle;

	public bool UseItemIdString
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return nI0S3eFD95Y;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			nI0S3eFD95Y = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessItems(TagNodeList list)
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
			TagNodeCompound tagNodeCompound = list[num] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
			{
				bool flag = false;
				try
				{
					flag = ProcessItem(tagNodeCompound);
				}
				catch (Exception)
				{
				}
				if (!flag)
				{
					list.Remove(tagNodeCompound);
				}
				if (flag && tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] is TagNodeCompound tagNodeCompound2)
				{
					if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247522)))
					{
						TagNodeCompound tagNodeCompound3 = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247522)] as TagNodeCompound;
						string text = "";
						if (tagNodeCompound3.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
						{
							text = tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
						}
						if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(121382) || text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15706))
						{
							TagNodeCompound tagNodeCompound4 = TileEntityConversion.CreatePEBlockEntityFromPC(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15682), 0, 0, 0);
							qsMS3xMn3SP.ProcessMobSpawner(tagNodeCompound3, tagNodeCompound4);
							tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247522)] = tagNodeCompound4;
						}
						if (tagNodeCompound3 != null && tagNodeCompound3.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)))
						{
							ProcessItems(tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] as TagNodeList);
						}
					}
					tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253998));
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ProcessItem(TagNodeCompound item, bool checkTradeValue = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short num = -1;
		short d = 0;
		string text = null;
		if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
		{
			if (item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				text = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
			}
			else if (item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeShort)
			{
				num = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeShort;
				if (BlockMaster.PCBlocksById.ContainsKey(num))
				{
					text = BlockMaster.PCBlocksById[num].java.name;
				}
				else if (ItemTranslations.JavaItemsById.ContainsKey(num))
				{
					text = ItemTranslations.JavaItemsById[num].JavaName;
				}
			}
		}
		if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)))
		{
			text = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] as TagNodeString;
		}
		if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)))
		{
			d = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] as TagNodeShort;
		}
		if (BlockMaster.PCBlocksByName.ContainsKey(text) && BlockMaster.PCBlocksByName[text].bedrock != null)
		{
			MasterBlockItem bedrock = BlockMaster.PCBlocksByName[text].bedrock;
			text = bedrock.name;
			d = (short)(bedrock.data.HasValue ? bedrock.data.Value : 0);
		}
		else if (BlockMaster.PCBlocksByNameOld.ContainsKey(text) && BlockMaster.PCBlocksByNameOld[text].bedrock != null)
		{
			MasterBlockItem bedrock2 = BlockMaster.PCBlocksByNameOld[text].bedrock;
			text = bedrock2.name;
			d = (short)(bedrock2.data.HasValue ? bedrock2.data.Value : 0);
		}
		else if (ItemTranslations.JavaItemsByName.ContainsKey(text))
		{
			if (ItemTranslations.JavaItemsByName[text].BedrockDamage > 0)
			{
				d = (short)ItemTranslations.JavaItemsByName[text].BedrockDamage;
			}
			text = ItemTranslations.JavaItemsByName[text].BedrockName;
		}
		else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65298))
		{
			MasterBlockItem bedrock3 = BlockMaster.PEBlocksByName[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65386)].bedrock;
			text = bedrock3.name;
			d = (short)(bedrock3.data.HasValue ? bedrock3.data.Value : 0);
		}
		else
		{
			text = null;
		}
		item.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634));
		item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] = new TagNodeString(text);
		item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] = new TagNodeShort(d);
		bool result = text != null;
		if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(198052) || text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(197970))
		{
			HJUS3tLphvO(item);
		}
		else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(199082))
		{
			HnWS3aHyWsN(item);
		}
		if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
		{
			TagNodeCompound tagNodeCompound = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
			vwVS3ybcqRe(tagNodeCompound);
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606)] is TagNodeList)
			{
				TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606)] as TagNodeList;
				HQTS3lpWvME(tagNodeList);
				item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606)] = tagNodeList;
				tagNodeCompound.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243606));
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630)] is TagNodeList)
			{
				TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630)] as TagNodeList;
				HQTS3lpWvME(tagNodeList2);
				item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630)] = tagNodeList2;
				tagNodeCompound.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243630));
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243580)))
			{
				byte d2 = 1;
				if (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243580)] is TagNodeInt)
				{
					d2 = (byte)(int)(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243580)] as TagNodeInt);
				}
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243580)] = new TagNodeByte(d2);
			}
		}
		if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(196476))
		{
			Sd4S32trww8(item);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HQTS3lpWvME(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			TagNodeString tagNodeString = P_0[i] as TagNodeString;
			tagNodeString.Data = tagNodeString.Data.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974), "");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Sd4S32trww8(TagNodeCompound P_0)
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
		if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243654)))
		{
			long num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243654)] as TagNodeInt;
			if (Working.MapIds.ContainsKey(num))
			{
				num = Working.MapIds[num];
			}
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243654)] = new TagNodeLong(num);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vwVS3ybcqRe(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<string> list = new List<string>();
		foreach (string key in P_0.Keys)
		{
			if (c6aS3Mi5Mle.ContainsKey(key))
			{
				list.Add(key);
			}
		}
		foreach (string item in list)
		{
			P_0[c6aS3Mi5Mle[item]] = P_0[item];
			P_0.Remove(item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QlKS30mqGBl(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short d = 10;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
		{
			if (P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] is TagNodeCompound tagNodeCompound && tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253998)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253998)] is TagNodeCompound)
			{
				TagNodeCompound tagNodeCompound2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253998)] as TagNodeCompound;
				if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
				{
					string key = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
					if (hvd0XujpavSpj5UhiI6.lfnSVhSnc0q().ContainsKey(key))
					{
						d = (short)hvd0XujpavSpj5UhiI6.lfnSVhSnc0q()[key].LZES4IdKb9J();
					}
				}
				tagNodeCompound.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253998));
			}
			P_0.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982));
		}
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] = new TagNodeShort(d);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private short nWHS3BkbIJp(TagNodeCompound P_0, short P_1, bool P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short num = 0;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)))
		{
			num = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] as TagNodeShort;
		}
		if (!P_2)
		{
			if (P_1 <= 0 || P_1 >= 256)
			{
				P_1 = (short)(ItemTranslations.JavaItemsById.ContainsKey(P_1) ? ((short)ItemTranslations.JavaItemsById[P_1].BedrockId) : 0);
			}
			else
			{
				BlockConversionDefinition blockConversionDefinition = BlockMaster.JavaFromBedrockBlock(P_1, num);
				P_1 = (short)blockConversionDefinition.id;
				num = (short)blockConversionDefinition.data;
			}
		}
		P_0.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634));
		if (nI0S3eFD95Y)
		{
			string d = "";
			if (ItemTranslations.JavaItemsById.ContainsKey(P_1))
			{
				d = ItemTranslations.JavaItemsById[P_1].JavaName;
			}
			else if (INYifyudg3hCpcrleHt.zhkS0lPoAGR().ContainsKey(P_1))
			{
				d = INYifyudg3hCpcrleHt.zhkS0lPoAGR()[P_1].qkOSyYT9Kd5();
			}
			P_0.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634), new TagNodeString(d));
		}
		else
		{
			P_0.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634), new TagNodeShort(P_1));
		}
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] = new TagNodeShort(num);
		return P_1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HJUS3tLphvO(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		if (P_0 == null || !P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
		{
			return;
		}
		TagNodeCompound tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
		if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254020)))
		{
			TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254020)] as TagNodeList;
			for (int i = 0; i < tagNodeList2.Count; i++)
			{
				string text = (TagNodeString)tagNodeList2[i];
				text = text.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254034), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66238));
				text = CheckColorCodes(text);
				TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254042)] = new TagNodeString();
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254064)] = new TagNodeString(text);
				tagNodeList.Add(tagNodeCompound2);
			}
		}
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254020)] = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HnWS3aHyWsN(TagNodeCompound P_0)
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
		if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254076)))
		{
			return;
		}
		TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254076)] as TagNodeList;
		tagNodeCompound.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254076));
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)] = tagNodeList;
		for (int i = 0; i < tagNodeList.Count; i++)
		{
			TagNodeCompound tagNodeCompound2 = tagNodeList[i] as TagNodeCompound;
			int num = 0;
			string text = "";
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				text = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
				if (AP3S3Xly1SA.ContainsKey(text))
				{
					num = AP3S3Xly1SA[text];
				}
			}
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeShort((short)num);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string CheckColorCodes(string inText)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		string text = string.Empty;
		bool flag = false;
		try
		{
			for (int i = 0; i < inText.Length; i++)
			{
				char c = inText[i];
				if (c == '\\' && !flag && inText[i + 1] == 'u')
				{
					flag = true;
				}
				if (flag)
				{
					if (c != '\\')
					{
						text += c;
					}
					if (text.Length == 5)
					{
						byte[] bytes = Utils.ConvertHexStringToByteArray(text.Substring(3));
						string value = Encoding.ASCII.GetString(bytes);
						stringBuilder.Append(value);
						flag = false;
						text = string.Empty;
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
		}
		catch (Exception)
		{
			return inText;
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BedrockFromJavaItemConverter()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		AP3S3Xly1SA = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254116),
				8
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254166),
				11
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254226),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254282),
				32
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254326),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254376),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254430),
				7
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254480),
				15
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254524),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254578),
				13
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254624),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254678),
				21
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254712),
				18
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254750),
				25
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254798),
				29
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254838),
				22
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254878),
				12
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254920),
				14
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254958),
				31
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(254996),
				23
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255050),
				24
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255082),
				26
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255120),
				33
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255162),
				34
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255202),
				19
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255236),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255302),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255346),
				20
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255380),
				35
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255428),
				6
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255474),
				30
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255512),
				9
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255554),
				16
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255598),
				10
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255632),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255672),
				5
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255708),
				17
			}
		};
		qsMS3xMn3SP = new PETileEntityConverters();
		c6aS3Mi5Mle = new Dictionary<string, string> { 
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210128),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243654)
		} };
	}
}
