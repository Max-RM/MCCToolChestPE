using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using afNMf7uWOyq6L7IHxiu;
using DekWW8jSE3fVOo1d5ao;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers.converterHelpers;

public class PE2PCEntityConversion
{
	private static string cDtSYp5WJK3;

	private JavaFromBedrockItemConverter gNESYZKFW7y;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNodeCompound CreateItemFrame(TagNodeCompound bedrockItemFrame, int bedrockDirection, ConvertParameters convertParameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = (TagNodeCompound)lxe7hMuSirBXGUQugsD.v4fSPe0WJtV(cDtSYp5WJK3);
		if (bedrockItemFrame.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)))
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)] = bedrockItemFrame[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)];
		}
		sEwSY4HB0w5(tagNodeCompound, bedrockItemFrame, bedrockDirection, convertParameters);
		X8aSYVgl3OJ(tagNodeCompound, bedrockItemFrame);
		tbfSYWwuECL(tagNodeCompound);
		if (bedrockItemFrame.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)))
		{
			TagNodeCompound tagNodeCompound2 = bedrockItemFrame[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)].Copy() as TagNodeCompound;
			gNESYZKFW7y.ProcessItem(tagNodeCompound2);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] = tagNodeCompound2;
		}
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNodeList ConvertEntities(TagNodeList inEntities, ConvertParameters convertParameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		for (int num = inEntities.Count - 1; num >= 0; num--)
		{
			if (inEntities[num] is TagNodeCompound && inEntities[num] is TagNodeCompound tagNodeCompound)
			{
				string text = PtnSYvMQaNW(tagNodeCompound);
				string path = Path.Combine(Utils.ConversionPath(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243674));
				string path2 = Path.Combine(path, text.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12654), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710)) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69582));
				if (File.Exists(path2))
				{
					string text2 = File.ReadAllText(path2);
					TagNodeCompound tagNodeCompound2 = (TagNodeCompound)lxe7hMuSirBXGUQugsD.v4fSPe0WJtV(text2);
					if (tagNodeCompound2 != null)
					{
						kr8SYwvTCWP(tagNodeCompound2, tagNodeCompound, convertParameters);
						X8aSYVgl3OJ(tagNodeCompound2, tagNodeCompound);
						tbfSYWwuECL(tagNodeCompound2);
						if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)))
						{
							TagNodeCompound tagNodeCompound3 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)].Copy() as TagNodeCompound;
							gNESYZKFW7y.ProcessItem(tagNodeCompound3);
							tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] = tagNodeCompound3;
						}
						if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)))
						{
							TagNodeList tagNodeList2 = (TagNodeList)(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] as TagNodeList).Copy();
							gNESYZKFW7y.ProcessItems(tagNodeList2);
							tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] = tagNodeList2;
						}
						tagNodeList.Add(tagNodeCompound2);
					}
				}
			}
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void A2CSYbtSchI(TagNodeCompound P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			string text = P_1.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12654), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710));
			string text2 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244282);
			string path = Path.Combine(text2, text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69582));
			if (!File.Exists(path))
			{
				Directory.CreateDirectory(text2);
				string contents = lxe7hMuSirBXGUQugsD.R1tSPxItoCC(P_1, P_0);
				File.WriteAllText(path, contents, Encoding.UTF8);
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string PtnSYvMQaNW(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = string.Empty;
		if (P_0 != null)
		{
			if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15828)))
			{
				result = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15828)] as TagNodeString;
			}
			else if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeInt)
			{
				int key = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeInt;
				if (hvd0XujpavSpj5UhiI6.eCfSVZfnEaD().ContainsKey(key))
				{
					result = hvd0XujpavSpj5UhiI6.eCfSVZfnEaD()[key].Name;
				}
				else if (hvd0XujpavSpj5UhiI6.WBHSVsHEOJC().ContainsKey(key))
				{
					result = hvd0XujpavSpj5UhiI6.WBHSVsHEOJC()[key].Name;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kr8SYwvTCWP(TagNodeCompound P_0, TagNodeCompound P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
		double num = tagNodeList[0] as TagNodeFloat;
		double d = tagNodeList[1] as TagNodeFloat;
		double num2 = tagNodeList[2] as TagNodeFloat;
		if (P_2.UseConvertOffsets)
		{
			try
			{
				num = (double)lxe7hMuSirBXGUQugsD.KmDSPjYqJTp((int)num, P_2.XRegionOffset) + (num - (double)(int)num);
				num2 = (double)lxe7hMuSirBXGUQugsD.KmDSPjYqJTp((int)num2, P_2.ZRegionOffset) + (num2 - (double)(int)num2);
			}
			catch (Exception)
			{
				throw;
			}
		}
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_DOUBLE);
		tagNodeList2.Add(new TagNodeDouble(num));
		tagNodeList2.Add(new TagNodeDouble(d));
		tagNodeList2.Add(new TagNodeDouble(num2));
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] = tagNodeList2;
		TagNodeList tagNodeList3 = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244370)] as TagNodeList;
		TagNodeList tagNodeList4 = new TagNodeList(TagType.TAG_FLOAT);
		for (int i = 0; i < 2; i++)
		{
			tagNodeList4.Add(new TagNodeFloat(tagNodeList3[i] as TagNodeFloat));
		}
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244370)] = tagNodeList4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sEwSY4HB0w5(TagNodeCompound P_0, TagNodeCompound P_1, int P_2, ConvertParameters P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] as TagNodeInt;
		int num2 = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] as TagNodeInt;
		int num3 = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] as TagNodeInt;
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244390)] = new TagNodeByte(1);
		if (P_3.UseConvertOffsets)
		{
			try
			{
				num = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num, P_3.XRegionOffset) + (num - num);
				num3 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num3, P_3.ZRegionOffset) + (num3 - num3);
			}
			catch (Exception)
			{
				throw;
			}
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_DOUBLE);
		tagNodeList.Add(new TagNodeDouble(num));
		tagNodeList.Add(new TagNodeDouble(num2));
		tagNodeList.Add(new TagNodeDouble(num3));
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] = tagNodeList;
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244420)] = new TagNodeInt(num);
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244434)] = new TagNodeInt(num2);
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244448)] = new TagNodeInt(num3);
		byte d = 0;
		switch (P_2)
		{
		case 2:
		case 6:
			d = 3;
			break;
		case 1:
		case 5:
			d = 4;
			break;
		case 3:
		case 7:
			d = 2;
			break;
		case 0:
		case 4:
			d = 5;
			break;
		}
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65370)] = new TagNodeByte(d);
		float d2 = 0f;
		if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)) && P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)] is TagNodeFloat)
		{
			d2 = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)] as TagNodeFloat;
		}
		else if (P_1.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)) && P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)] is TagNodeByte)
		{
			d2 = (long)(P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)] as TagNodeByte);
		}
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_FLOAT);
		tagNodeList2.Add(new TagNodeFloat(d2));
		tagNodeList2.Add(new TagNodeFloat(0f));
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244370)] = tagNodeList2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void X8aSYVgl3OJ(TagNodeCompound P_0, TagNodeCompound P_1)
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
	private void tbfSYWwuECL(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] value = Guid.NewGuid().ToByteArray();
		long d = BitConverter.ToInt64(value, 0);
		long d2 = BitConverter.ToInt64(value, 8);
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244462)] = new TagNodeLong(d);
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244484)] = new TagNodeLong(d2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PE2PCEntityConversion()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		gNESYZKFW7y = new JavaFromBedrockItemConverter();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PE2PCEntityConversion()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		cDtSYp5WJK3 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244504);
	}
}
