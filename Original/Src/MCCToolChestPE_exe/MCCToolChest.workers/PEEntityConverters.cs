using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using DekWW8jSE3fVOo1d5ao;
using MCCToolChest.events;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class PEEntityConverters
{
	private static long SgfS3sJouRX;

	private static BedrockFromJavaItemConverter M2KS3qveXtK;

	private static EntityLookup rMCS3KJkK8T;

	private static Dictionary<string, string[]> Gk7S3hluuoO;

	private static Dictionary<string, PCEntityConverter> CmMS3mimW6L;

	private static Dictionary<string, string> MxVS3nD5iEI;

	public static long UniqueID
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return SgfS3sJouRX++;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ResetUniqueID()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SgfS3sJouRX = -2147483648L;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound EntityConverter(TagNodeCompound pcEntity, ConvertParameters convertParameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string key = (TagNodeString)pcEntity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
		if (rMCS3KJkK8T.PCEntities.ContainsKey(key))
		{
			EntityItem entityItem = rMCS3KJkK8T.PCEntities[key];
			string pCName = entityItem.PCName;
			string text = pCName.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974), "");
			if (hvd0XujpavSpj5UhiI6.lfnSVhSnc0q().ContainsKey(pCName))
			{
				TagNodeCompound tagNodeCompound = cUcS34OVVk5(pCName);
				if (Gk7S3hluuoO.ContainsKey(text))
				{
					geYS3V1Vf39(text, pcEntity, tagNodeCompound, Gk7S3hluuoO[text]);
				}
				UDHS3Wosm6u(pcEntity, tagNodeCompound, convertParameters);
				AykS3puJfED(pcEntity, tagNodeCompound);
				MG2S3ZnINPp(pcEntity, tagNodeCompound, convertParameters);
				if (CmMS3mimW6L.ContainsKey(text))
				{
					CmMS3mimW6L[text](pcEntity, tagNodeCompound);
				}
				return tagNodeCompound;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TagNodeCompound cUcS34OVVk5(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		if (P_0 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83286))
		{
			tagNodeCompound = (TagNodeCompound)lxe7hMuSirBXGUQugsD.v4fSPe0WJtV(Constants.PE_Painting_Template);
		}
		else
		{
			tagNodeCompound = (TagNodeCompound)lxe7hMuSirBXGUQugsD.v4fSPe0WJtV(Constants.PE_Entity_Template);
			int d = hvd0XujpavSpj5UhiI6.lfnSVhSnc0q()[P_0].YhxSVSwIOdw();
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeInt(d);
		}
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27938)] = new TagNodeLong(UniqueID);
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void geYS3V1Vf39(string P_0, TagNodeCompound P_1, TagNodeCompound P_2, string[] P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_STRING);
		try
		{
			for (int i = 0; i < P_3.Length; i++)
			{
				tagNodeList.Add(new TagNodeString(P_3[i]));
			}
			if (P_0 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247478))
			{
				int num = 0;
				int num2 = 0;
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19344)))
				{
					num = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19344)] as TagNodeInt;
				}
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19388)))
				{
					num2 = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19388)] as TagNodeInt;
				}
				if (Constants.professionNames.Count < num)
				{
					num = 0;
				}
				if (Constants.professionNames[num].Length <= num2)
				{
					num2 = 0;
				}
				tagNodeList.Add(new TagNodeString(Constants.professionNames[num][num2]));
				int num3 = 0;
				if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19506)))
				{
					num3 = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19506)] as TagNodeInt;
				}
				if (num3 < 0)
				{
					tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18986)));
					tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19000)));
				}
				else
				{
					tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19016)));
					tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19032)));
				}
				TagNodeList value = (TagNodeList)lxe7hMuSirBXGUQugsD.v4fSPe0WJtV(Constants.PE_Villager_Attributes);
				P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27958)] = value;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19130)] = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void UDHS3Wosm6u(TagNodeCompound P_0, TagNodeCompound P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_FLOAT);
		float num = (float)(double)(tagNodeList[0] as TagNodeDouble);
		float d = (float)(double)(tagNodeList[1] as TagNodeDouble);
		float num2 = (float)(double)(tagNodeList[2] as TagNodeDouble);
		if (P_2.UseConvertOffsets)
		{
			try
			{
				num = (float)lxe7hMuSirBXGUQugsD.KmDSPjYqJTp((int)num, P_2.XRegionOffset) + (num - (float)(int)num);
				num2 = (float)lxe7hMuSirBXGUQugsD.KmDSPjYqJTp((int)num2, P_2.ZRegionOffset) + (num2 - (float)(int)num2);
			}
			catch (Exception)
			{
				throw;
			}
		}
		tagNodeList2.Add(new TagNodeFloat(num));
		tagNodeList2.Add(new TagNodeFloat(d));
		tagNodeList2.Add(new TagNodeFloat(num2));
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] = tagNodeList2;
		TagNodeList tagNodeList3 = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244370)] as TagNodeList;
		TagNodeList tagNodeList4 = new TagNodeList(TagType.TAG_FLOAT);
		for (int i = 0; i < 2; i++)
		{
			tagNodeList4.Add(new TagNodeFloat(tagNodeList3[i] as TagNodeFloat));
		}
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244370)] = tagNodeList4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AykS3puJfED(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716)].Copy();
			if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17718)))
			{
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17718)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17718)].Copy();
			}
			else
			{
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17718)] = new TagNodeByte(0);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void MG2S3ZnINPp(TagNodeCompound P_0, TagNodeCompound P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = (string)(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString);
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247498)))
		{
			TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247498)] as TagNodeList;
			M2KS3qveXtK.ProcessItems(tagNodeList);
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13984)] = tagNodeList;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CopyOfferNodes(TagNodeCompound pcEntity, TagNodeCompound peEntity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!pcEntity.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)))
		{
			return;
		}
		TagNodeCompound tagNodeCompound = pcEntity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)] as TagNodeCompound;
		if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)))
		{
			TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18516)] as TagNodeList;
			foreach (TagNodeCompound item in tagNodeList)
			{
				if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81094)))
				{
					V9dS3fIGt22(item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81094)] as TagNodeCompound);
				}
				if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81104)))
				{
					V9dS3fIGt22(item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81104)] as TagNodeCompound);
				}
				if (item.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81116)))
				{
					V9dS3fIGt22(item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81116)] as TagNodeCompound);
				}
			}
		}
		peEntity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18500)] = tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void V9dS3fIGt22(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = false;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
		{
			flag = M2KS3qveXtK.ProcessItem(P_0, checkTradeValue: true);
		}
		if (flag && P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)) && P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] is TagNodeCompound tagNodeCompound && tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247522)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247522)] is TagNodeCompound tagNodeCompound2 && tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)))
		{
			M2KS3qveXtK.ProcessItems(tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] as TagNodeList);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void twgS3i3a8Wd(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte b = 0;
		byte d = 2;
		float num = 180f;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65370)))
		{
			b = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65370)] as TagNodeByte;
		}
		else if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247554)))
		{
			b = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247554)] as TagNodeByte;
		}
		else if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247576)))
		{
			b = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247576)] as TagNodeByte;
		}
		int num2 = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244420)] as TagNodeInt;
		int d2 = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244434)] as TagNodeInt;
		int num3 = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244448)] as TagNodeInt;
		if (b == 0)
		{
			num3--;
			d = 2;
			num = 180f;
		}
		if (b == 1)
		{
			num2++;
			d = 1;
			num = 90f;
		}
		if (b == 2)
		{
			num3++;
			d = 0;
			num = 0f;
		}
		if (b == 3)
		{
			num2--;
			d = 3;
			num = 270f;
		}
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247554)] = new TagNodeByte(b);
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247576)] = new TagNodeByte(d);
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244420)] = new TagNodeInt(num2);
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244434)] = new TagNodeInt(d2);
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244448)] = new TagNodeInt(num3);
		string key = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247586)] as TagNodeString;
		key = ((!MxVS3nD5iEI.ContainsKey(key)) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247602) : MxVS3nD5iEI[key]);
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247586)] = new TagNodeString(key);
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_FLOAT);
		tagNodeList.Add(new TagNodeFloat(num));
		tagNodeList.Add(new TagNodeFloat(0f));
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244370)] = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEEntityConverters()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PEEntityConverters()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		SgfS3sJouRX = 0L;
		M2KS3qveXtK = new BedrockFromJavaItemConverter();
		rMCS3KJkK8T = new EntityLookup();
		Gk7S3hluuoO = new Dictionary<string, string[]>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247616),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247626) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247658),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247672) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247708),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247734) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247782),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247800) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247840),
				new string[2]
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247850),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247882)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247926),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247944) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247984),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248000) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248038),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248070) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248124),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248152) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248202),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248222) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248264),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248286) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248330),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248368) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248428),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248442) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248478),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248498) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248540),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248554) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248590),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248602) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248636),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248650) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248686),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248710) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248756),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248778) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248822),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248834) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248868),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248884) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248922),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248938) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248976),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(248992) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249030),
				new string[3]
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249040),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249072),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249116)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249168),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249192) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249238),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249254) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249292),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249306) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249342),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249360) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249400),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249424) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249470),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249490) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249532),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249564) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(144498),
				new string[2]
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249618),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249654)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249700),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249718) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249758),
				new string[3]
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249774),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249812),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249866)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249920),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249934) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249970),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(249984) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250020),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250030) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247478),
				new string[2]
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18944),
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19084)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250062),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250094) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250148),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250190) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250254),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250268) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250304),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250320) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250358),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250392) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250448),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250460) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250494),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250510) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250548),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250576) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250626),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250656) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250708),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250742) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250798),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250810) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250844),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250876) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250930),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(250964) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251020),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251040) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251082),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251110) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251160),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251198) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251258),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251272) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251308),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251342) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63322),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251398) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251430),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251456) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251504),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251528) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251574),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251590) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251628),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251660) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251714),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251746) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251800),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251820) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251862),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251890) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251940),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(251962) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252006),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252036) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(140718),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252088) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252120),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252146) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(120822),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252194) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252246),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252276) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252328),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252362) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252418),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252460) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252524),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252536) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252570),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252594) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252640),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252660) }
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252702),
				new string[1] { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252718) }
			}
		};
		CmMS3mimW6L = new Dictionary<string, PCEntityConverter> { 
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252640),
			twgS3i3a8Wd
		} };
		MxVS3nD5iEI = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252756),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252790)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252804),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247602)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252838),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252874)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252890),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252922)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252934),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252968)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252982),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253024)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253046),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253086)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253106),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253142)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253158),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253190)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253202),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253240)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253258),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253294)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253310),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253340)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253350),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253388)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253406),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253440)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253454),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253486)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253498),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253532)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253546),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253578)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253590),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253644)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84616),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6818)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253674),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253714)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14974),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6412)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253734),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253780)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253804),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253842)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253860),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253900)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253920),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253970)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252790),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252790)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247602),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247602)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252874),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252874)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252922),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252922)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252968),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(252968)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253024),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253024)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253086),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253086)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253142),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253142)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253190),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253190)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253240),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253240)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253294),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253294)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253340),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253340)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253388),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253388)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253440),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253440)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253486),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253486)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253532),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253532)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253578),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253578)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253644),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253644)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6818),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6818)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253714),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253714)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6412),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6412)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253780),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253780)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253842),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253842)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253900),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253900)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253970),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(253970)
			}
		};
	}
}
