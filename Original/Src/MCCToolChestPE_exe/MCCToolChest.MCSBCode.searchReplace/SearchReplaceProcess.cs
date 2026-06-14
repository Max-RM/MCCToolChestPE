using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using DynamicExpresso;
using MCCToolChest.model;
using MCCToolChest.model.SearchReplace;
using MCCToolChest.ScriptExtensions;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode.searchReplace;

public class SearchReplaceProcess
{
	private Interpreter Fh9SvTEhVhV;

	private int j8pSvSH54ag;

	private int wIJSvGl8VdG;

	private string hPTSvbRFIcM;

	private List<TagNode> vb5SvvE3PAk;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchReplaceProcess(int chunkX, int chunkZ)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Fh9SvTEhVhV = new Interpreter();
		hPTSvbRFIcM = string.Empty;
		j8pSvSH54ag = chunkX;
		wIJSvGl8VdG = chunkZ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jTiSbesNiSn(List<TagNode> P_0, SearchReplaceCriteria P_1, Dictionary<string, object> P_2, SearchReplaceResult P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vb5SvvE3PAk = P_0;
		for (int i = 0; i < P_1.Values.Count; i++)
		{
			ReplaceValue replaceValue = P_1.Values[i];
			if (P_2.ContainsKey(replaceValue.NodeSelector))
			{
				BKQSbP68uPL(replaceValue, P_2, P_0);
				P_3.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72406) + replaceValue.NodeSelector + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72448) + hPTSvbRFIcM);
				continue;
			}
			string[] array = replaceValue.NodeSelector.Split('.');
			hH0SbMn7GbW(replaceValue, P_2, P_0, array);
			if (array.Length > 0)
			{
				P_3.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72458) + array[array.Length - 1] + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72448) + hPTSvbRFIcM);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hH0SbMn7GbW(ReplaceValue P_0, Dictionary<string, object> P_1, List<TagNode> P_2, string[] P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNode tagNode = P_2[P_2.Count - 1];
		TagNode tagNode2 = null;
		int num = P_2.Count - 1;
		string text = "";
		int i;
		for (i = 0; i < P_3.Length; i++)
		{
			text = P_3[i].Trim();
			if (tagNode2 != null)
			{
				tagNode = tagNode2;
				tagNode2 = null;
			}
			if (text.Contains('['))
			{
				string text2 = text.Substring(0, text.IndexOf('[')).Trim();
				kGxSbUiO9T7(P_2, num, text2, tagNode, tagNode2, out num, out tagNode, out tagNode2);
				if (tagNode2 is TagNodeList tagNodeList)
				{
					tagNode = tagNodeList;
					tagNode2 = null;
					string text3 = VsaSbcvhVbj(text);
					int result;
					if (text3.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(32342))
					{
						result = tagNodeList.Count;
					}
					else if (text3.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35000))
					{
						result = ((tagNodeList.Count > 0) ? (tagNodeList.Count - 1) : 0);
					}
					else
					{
						int.TryParse(text3, out result);
					}
					if (result < tagNodeList.Count)
					{
						tagNode2 = tagNodeList[result];
					}
				}
			}
			else
			{
				kGxSbUiO9T7(P_2, num, text, tagNode, tagNode2, out num, out tagNode, out tagNode2);
			}
			if (tagNode2 == null && i != P_3.Length - 1)
			{
				break;
			}
		}
		if (i == P_3.Length)
		{
			if (P_0.Value.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72492))
			{
				ibeSbL6vNWh(text, tagNode, tagNode2);
			}
			else
			{
				KGoSbgeHOT6(P_0, P_1, text, tagNode, tagNode2, P_2[1]);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kGxSbUiO9T7(List<TagNode> P_0, int P_1, string P_2, TagNode P_3, TagNode P_4, out int P_5, out TagNode P_6, out TagNode P_7)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_2 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72508))
		{
			P_4 = P_0[P_0.Count - 1];
			P_3 = P_0[P_0.Count - 2];
		}
		else if (P_2.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72520))
		{
			if (P_1 > 0)
			{
				P_1--;
			}
			P_4 = P_0[P_1];
			P_3 = ((P_1 > 0) ? P_0[P_1 - 1] : P_0[P_1]);
		}
		else if (P_2.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72536))
		{
			P_1 = 0;
			P_4 = P_0[0];
			P_3 = P_0[0];
		}
		else if (P_3 is TagNodeCompound && ((TagNodeCompound)P_3).ContainsKey(P_2))
		{
			P_4 = ((TagNodeCompound)P_3)[P_2];
		}
		P_5 = P_1;
		P_6 = P_3;
		P_7 = P_4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ibeSbL6vNWh(string P_0, TagNode P_1, TagNode P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 is TagNodeCompound)
		{
			((TagNodeCompound)P_1).Remove(P_0);
		}
		else if (P_1 is TagNodeList)
		{
			((TagNodeList)P_1).Remove(P_2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KGoSbgeHOT6(ReplaceValue P_0, Dictionary<string, object> P_1, string P_2, TagNode P_3, TagNode P_4, TagNode P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		object obj = Fe8Sbk2M6ee(P_0, P_4);
		object obj2 = oDGSbJ3oIFe(P_0.Value, P_1, obj, P_4, P_3, P_5);
		if (P_3 is TagNodeCompound)
		{
			GUqSb5V25jF(P_0, P_2, P_3 as TagNodeCompound, P_4, obj2);
		}
		else if (P_3 is TagNodeList)
		{
			pF9Sb3FCMdH(P_0, P_2, P_3 as TagNodeList, P_4, obj2);
		}
		else
		{
			CdrSbN3btR0(P_4, obj2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BKQSbP68uPL(ReplaceValue P_0, Dictionary<string, object> P_1, List<TagNode> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNode tagNode = null;
		if (P_2.Count > 1)
		{
			tagNode = P_2[P_2.Count - 2];
		}
		else if (P_2.Count > 0)
		{
			tagNode = P_2[0];
		}
		TagNode tagNode2 = ((P_2.Count > 0) ? P_2[P_2.Count - 1] : null);
		TagNode tagNode3 = ((P_2.Count > 0) ? P_2[0] : null);
		object obj = Fe8Sbk2M6ee(P_0, tagNode2);
		object obj2 = oDGSbJ3oIFe(P_0.Value, P_1, obj, tagNode2, tagNode, tagNode3);
		if (P_0.NodeType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30176) && obj2 is TagNode)
		{
			obj2 = lxe7hMuSirBXGUQugsD.R1tSPxItoCC(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72548), (TagNode)obj2);
		}
		else if (obj2 is TagNode)
		{
			obj2 = HFqSbR6Z4Ak(obj2 as TagNode);
		}
		P_1[P_0.NodeSelector] = obj2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private object HFqSbR6Z4Ak(TagNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		object result = P_0;
		switch (P_0.GetTagType())
		{
		case TagType.TAG_BYTE:
			result = ((TagNodeByte)P_0).Data;
			break;
		case TagType.TAG_SHORT:
			result = ((TagNodeShort)P_0).Data;
			break;
		case TagType.TAG_INT:
			result = ((TagNodeInt)P_0).Data;
			break;
		case TagType.TAG_LONG:
			result = ((TagNodeLong)P_0).Data;
			break;
		case TagType.TAG_FLOAT:
			result = ((TagNodeFloat)P_0).Data;
			break;
		case TagType.TAG_DOUBLE:
			result = ((TagNodeDouble)P_0).Data;
			break;
		case TagType.TAG_STRING:
			result = ((TagNodeString)P_0).Data;
			break;
		case TagType.TAG_COMPOUND:
			result = P_0;
			break;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private object Fe8Sbk2M6ee(ReplaceValue P_0, TagNode P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		object result = KvaSbYwNjkq(P_0);
		if (P_1 != null)
		{
			switch (P_1.GetTagType())
			{
			case TagType.TAG_BYTE:
				result = ((TagNodeByte)P_1).Data;
				break;
			case TagType.TAG_SHORT:
				result = ((TagNodeShort)P_1).Data;
				break;
			case TagType.TAG_INT:
				result = ((TagNodeInt)P_1).Data;
				break;
			case TagType.TAG_LONG:
				result = ((TagNodeLong)P_1).Data;
				break;
			case TagType.TAG_FLOAT:
				result = ((TagNodeFloat)P_1).Data;
				break;
			case TagType.TAG_DOUBLE:
				result = ((TagNodeDouble)P_1).Data;
				break;
			case TagType.TAG_STRING:
				result = ((TagNodeString)P_1).Data;
				break;
			case TagType.TAG_COMPOUND:
				result = P_1;
				break;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private object KvaSbYwNjkq(ReplaceValue P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		object result = null;
		Enum.TryParse<ReplaceValueTagType>(P_0.NodeType, out var result2);
		switch (result2)
		{
		case ReplaceValueTagType.TAG_BYTE:
			result = (byte)0;
			break;
		case ReplaceValueTagType.TAG_SHORT:
			result = (short)0;
			break;
		case ReplaceValueTagType.TAG_INT:
			result = 0;
			break;
		case ReplaceValueTagType.TAG_LONG:
			result = 0L;
			break;
		case ReplaceValueTagType.TAG_FLOAT:
			result = 0f;
			break;
		case ReplaceValueTagType.TAG_DOUBLE:
			result = 0.0;
			break;
		case ReplaceValueTagType.TAG_STRING:
			result = string.Empty;
			break;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pF9Sb3FCMdH(ReplaceValue P_0, string P_1, TagNodeList P_2, TagNode P_3, object P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_3 != null && OM1Sbr4MYYX(P_0.NodeType, P_3.GetTagType()))
		{
			CdrSbN3btR0(P_3, P_4);
		}
		else
		{
			if (P_2 == null)
			{
				return;
			}
			TagNode tagNode = SIKSb667Qg3(P_0, P_3, P_4);
			if (tagNode != null)
			{
				int num = I89SbE9QNdj(P_2, P_3);
				if (num >= 0 && num < P_2.Count)
				{
					EQhSb144GHP(P_3, tagNode);
					P_2[num] = tagNode;
				}
				else
				{
					P_2.Add(tagNode);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EQhSb144GHP(TagNode P_0, TagNode P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < vb5SvvE3PAk.Count; i++)
		{
			if (vb5SvvE3PAk[i] == P_0)
			{
				vb5SvvE3PAk[i] = P_1;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int I89SbE9QNdj(TagNodeList P_0, TagNode P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 != null)
		{
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i] == P_1)
				{
					return i;
				}
			}
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool OM1Sbr4MYYX(string P_0, TagType P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			TagType tagType = (TagType)Enum.Parse(typeof(TagType), P_0, ignoreCase: true);
			return P_1 == tagType;
		}
		catch (Exception)
		{
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GUqSb5V25jF(ReplaceValue P_0, string P_1, TagNodeCompound P_2, TagNode P_3, object P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_2 != null)
		{
			TagNode tagNode = SIKSb667Qg3(P_0, P_3, P_4);
			if (tagNode != null)
			{
				P_2[P_1] = tagNode;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNode SIKSb667Qg3(ReplaceValue P_0, TagNode P_1, object P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Enum.TryParse<ReplaceValueTagType>(P_0.NodeType, out var result);
		TagNode result2 = null;
		switch (result)
		{
		case ReplaceValueTagType.TAG_BYTE:
		{
			byte.TryParse(P_2.ToString(), out var result3);
			result2 = new TagNodeByte(result3);
			break;
		}
		case ReplaceValueTagType.TAG_SHORT:
		{
			short.TryParse(P_2.ToString(), out var result4);
			result2 = new TagNodeShort(result4);
			break;
		}
		case ReplaceValueTagType.TAG_INT:
		{
			int.TryParse(P_2.ToString(), out var result8);
			result2 = new TagNodeInt(result8);
			break;
		}
		case ReplaceValueTagType.TAG_LONG:
		{
			long.TryParse(P_2.ToString(), out var result7);
			result2 = new TagNodeLong(result7);
			break;
		}
		case ReplaceValueTagType.TAG_FLOAT:
		{
			float.TryParse(P_2.ToString(), out var result6);
			result2 = new TagNodeFloat(result6);
			break;
		}
		case ReplaceValueTagType.TAG_DOUBLE:
		{
			double.TryParse(P_2.ToString(), out var result5);
			result2 = new TagNodeDouble(result5);
			break;
		}
		case ReplaceValueTagType.TAG_BYTE_ARRAY:
		{
			byte[] d2 = P_2 as byte[];
			result2 = new TagNodeByteArray(d2);
			break;
		}
		case ReplaceValueTagType.TAG_STRING:
			result2 = new TagNodeString(P_2.ToString());
			break;
		case ReplaceValueTagType.TAG_COMPOUND:
			if (P_1 == null || !(P_1 is TagNodeCompound))
			{
				result2 = new TagNodeCompound();
			}
			break;
		case ReplaceValueTagType.TAG_INT_ARRAY:
		{
			int[] d = P_2 as int[];
			result2 = new TagNodeIntArray(d);
			break;
		}
		case ReplaceValueTagType.NBT_STRING:
			result2 = lxe7hMuSirBXGUQugsD.v4fSPe0WJtV(P_2.ToString());
			break;
		case ReplaceValueTagType.TAG_LIST:
			result2 = new TagNodeList(TagType.TAG_COMPOUND);
			break;
		}
		return result2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CdrSbN3btR0(TagNode P_0, object P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			switch (P_0.GetTagType())
			{
			case TagType.TAG_BYTE:
			{
				byte.TryParse(P_1.ToString(), out var result6);
				((TagNodeByte)P_0).Data = result6;
				break;
			}
			case TagType.TAG_SHORT:
			{
				short.TryParse(P_1.ToString(), out var result5);
				((TagNodeShort)P_0).Data = result5;
				break;
			}
			case TagType.TAG_INT:
			{
				int.TryParse(P_1.ToString(), out var result4);
				((TagNodeInt)P_0).Data = result4;
				break;
			}
			case TagType.TAG_LONG:
			{
				long.TryParse(P_1.ToString(), out var result3);
				((TagNodeLong)P_0).Data = result3;
				break;
			}
			case TagType.TAG_FLOAT:
			{
				float.TryParse(P_1.ToString(), out var result2);
				((TagNodeFloat)P_0).Data = result2;
				break;
			}
			case TagType.TAG_DOUBLE:
			{
				double.TryParse(P_1.ToString(), out var result);
				((TagNodeDouble)P_0).Data = result;
				break;
			}
			case TagType.TAG_BYTE_ARRAY:
			{
				byte[] data2 = P_1 as byte[];
				((TagNodeByteArray)P_0).Data = data2;
				break;
			}
			case TagType.TAG_STRING:
				((TagNodeString)P_0).Data = P_1.ToString();
				break;
			case TagType.TAG_INT_ARRAY:
			{
				int[] data = P_1 as int[];
				((TagNodeIntArray)P_0).Data = data;
				break;
			}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int[] MgpSbDbN7jl(TagNode P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<int> list = new List<int>();
		string intstring = VsaSbcvhVbj(P_1);
		list = IntSringConverter.ConvertFromString(intstring);
		return list.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string VsaSbcvhVbj(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = "";
		int num = P_0.IndexOf('[') + 1;
		int num2 = P_0.IndexOf(']');
		if (num2 > num)
		{
			result = P_0.Substring(num, num2 - num).Trim();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private object oDGSbJ3oIFe(string P_0, Dictionary<string, object> P_1, object P_2, TagNode P_3, TagNode P_4, TagNode P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		object obj = string.Empty;
		ScriptExtensionMethods value = new ScriptExtensionMethods();
		List<Parameter> list = new List<Parameter>();
		list.Add(new Parameter(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984), j8pSvSH54ag));
		list.Add(new Parameter(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996), wIJSvGl8VdG));
		list.Add(new Parameter(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72566), value));
		if (P_2 != null)
		{
			list.Add(new Parameter(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31688), P_2));
		}
		THmSbo17cR0(P_3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72508), list);
		THmSbo17cR0(P_4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72520), list);
		THmSbo17cR0(P_5, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72536), list);
		OFoSbQfkSSH(P_5, list);
		z5RSbuUfFos(list, P_1);
		Parameter[] parameters = list.ToArray();
		try
		{
			object obj2 = Fh9SvTEhVhV.Eval(P_0, parameters);
			if (obj2 != null)
			{
				obj = obj2;
			}
			hPTSvbRFIcM = obj.ToString();
		}
		catch (Exception ex)
		{
			if (ex != null)
			{
				hPTSvbRFIcM = ex.Message;
			}
		}
		return obj;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void z5RSbuUfFos(List<Parameter> P_0, Dictionary<string, object> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (string key in P_1.Keys)
		{
			if (P_1[key] != null)
			{
				P_0.Add(new Parameter(key, P_1[key].GetType(), P_1[key]));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void THmSbo17cR0(TagNode P_0, string P_1, List<Parameter> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			if (P_0.GetTagType() == TagType.TAG_COMPOUND)
			{
				P_2.Add(new Parameter(P_1, typeof(TagNodeCompound), P_0));
			}
			else if (P_0.GetTagType() == TagType.TAG_LIST)
			{
				P_2.Add(new Parameter(P_1, typeof(TagNodeList), P_0));
			}
			else if (P_0.GetTagType() == TagType.TAG_STRING)
			{
				P_2.Add(new Parameter(P_1, typeof(string), ((TagNodeString)P_0).Data));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OFoSbQfkSSH(TagNode P_0, List<Parameter> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		object value = 0;
		object value2 = 0;
		object value3 = 0;
		if (P_0.GetTagType() == TagType.TAG_COMPOUND)
		{
			TagNodeCompound tagNodeCompound = P_0 as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)))
			{
				value = ((TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)]).Data;
				value2 = ((TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)]).Data;
				value3 = ((TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)]).Data;
			}
			else if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)))
			{
				TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
				if (tagNodeList[0] is TagNodeDouble)
				{
					value = ((TagNodeDouble)tagNodeList[0]).Data;
					value2 = ((TagNodeDouble)tagNodeList[1]).Data;
					value3 = ((TagNodeDouble)tagNodeList[2]).Data;
				}
				else if (tagNodeList[0] is TagNodeFloat)
				{
					value = ((TagNodeFloat)tagNodeList[0]).Data;
					value2 = ((TagNodeFloat)tagNodeList[1]).Data;
					value3 = ((TagNodeFloat)tagNodeList[2]).Data;
				}
			}
		}
		P_1.Add(new Parameter(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786), value));
		P_1.Add(new Parameter(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886), value2));
		P_1.Add(new Parameter(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792), value3));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool C1ZSbOq7nOg(List<TagNode> P_0, SearchReplaceCriteria P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Last();
		bool result = true;
		foreach (MatchCondition condition in P_1.Conditions)
		{
			string[] array = condition.NodeSelector.Split('.');
			ParentChildResult parentChildResult = OsQSbCQFr7v(P_0, array);
			if (parentChildResult.Completed)
			{
				if (FNlSb7g9BT2(condition, parentChildResult))
				{
					result = true;
					if (P_1.MatchType == ConditionMatchType.ANY)
					{
						break;
					}
				}
				else
				{
					result = false;
					if (P_1.MatchType == ConditionMatchType.ALL)
					{
						break;
					}
				}
				continue;
			}
			throw new Exception(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72574) + condition.NodeSelector);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ParentChildResult OsQSbCQFr7v(List<TagNode> P_0, string[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNode tagNode = P_0.Last();
		TagNode tagNode2 = null;
		int num = P_0.Count - 1;
		int i;
		for (i = 0; i < P_1.Length; i++)
		{
			string text = P_1[i].Trim();
			if (tagNode2 != null)
			{
				tagNode = tagNode2;
				tagNode2 = null;
			}
			if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72620))
			{
				if (num > 0)
				{
					num--;
					tagNode2 = P_0[num];
				}
			}
			else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72636))
			{
				if (num > 0)
				{
					tagNode2 = P_0[0];
				}
			}
			else if (text.Contains('['))
			{
				string key = text.Substring(0, text.IndexOf('[')).Trim();
				if (((TagNodeCompound)tagNode).ContainsKey(key) && ((TagNodeCompound)tagNode)[key] is TagNodeList tagNodeList)
				{
					string text2 = VsaSbcvhVbj(text);
					int result;
					if (text2.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35000))
					{
						result = ((tagNodeList.Count > 0) ? (tagNodeList.Count - 1) : 0);
					}
					else
					{
						int.TryParse(text2, out result);
					}
					tagNode = tagNodeList;
					if (result < tagNodeList.Count)
					{
						tagNode2 = tagNodeList[result];
					}
				}
			}
			else if (tagNode is TagNodeCompound && ((TagNodeCompound)tagNode).ContainsKey(text))
			{
				tagNode2 = ((TagNodeCompound)tagNode)[text];
			}
			if (tagNode2 == null && i != P_1.Length - 1)
			{
				break;
			}
		}
		bool completed = i == P_1.Length;
		return new ParentChildResult(tagNode, tagNode2, completed);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool FNlSb7g9BT2(MatchCondition P_0, ParentChildResult P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Enum.TryParse<ConditionValueType>(P_0.Condition, out var result);
		string text = P_0.Value.Trim();
		if (result == ConditionValueType.EQUAL || result == ConditionValueType.NOT_EQUAL)
		{
			string[] array = text.Split(',');
			bool result2 = ((result != ConditionValueType.EQUAL) ? true : false);
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i].Trim();
				bool flag = rKrSbA1hg9x(result, text2, P_1);
				switch (result)
				{
				case ConditionValueType.EQUAL:
					if (flag)
					{
						result2 = true;
					}
					break;
				case ConditionValueType.NOT_EQUAL:
					if (!flag)
					{
						result2 = true;
					}
					break;
				}
			}
			return result2;
		}
		return rKrSbA1hg9x(result, text, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool rKrSbA1hg9x(ConditionValueType P_0, string P_1, ParentChildResult P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		_ = P_2.Parent;
		TagNode child = P_2.Child;
		if (P_0 == ConditionValueType.EXIST && child != null)
		{
			return true;
		}
		if (P_0 == ConditionValueType.NOT_EXIST && child == null)
		{
			return true;
		}
		if (child != null)
		{
			switch (child.GetTagType())
			{
			case TagType.TAG_BYTE:
			{
				byte.TryParse(P_1, out var result7);
				byte data7 = ((TagNodeByte)child).Data;
				result = IU8SbdFwdLT(P_0, data7, result7);
				break;
			}
			case TagType.TAG_SHORT:
			{
				short.TryParse(P_1, out var result6);
				short data6 = ((TagNodeShort)child).Data;
				result = IU8SbdFwdLT(P_0, data6, result6);
				break;
			}
			case TagType.TAG_INT:
			{
				int.TryParse(P_1, out var result5);
				int data5 = ((TagNodeInt)child).Data;
				result = IU8SbdFwdLT(P_0, data5, result5);
				break;
			}
			case TagType.TAG_LONG:
			{
				long.TryParse(P_1, out var result4);
				long data4 = ((TagNodeLong)child).Data;
				result = IU8SbdFwdLT(P_0, data4, result4);
				break;
			}
			case TagType.TAG_FLOAT:
			{
				float.TryParse(P_1, out var result3);
				float data3 = ((TagNodeFloat)child).Data;
				result = IU8SbdFwdLT(P_0, data3, result3);
				break;
			}
			case TagType.TAG_DOUBLE:
			{
				double.TryParse(P_1, out var result2);
				double data2 = ((TagNodeDouble)child).Data;
				result = IU8SbdFwdLT(P_0, data2, result2);
				break;
			}
			case TagType.TAG_STRING:
			{
				string data = ((TagNodeString)child).Data;
				result = IU8SbdFwdLT(P_0, data, P_1);
				break;
			}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IU8SbdFwdLT<qElnkuj0y19gMtThYBD>(ConditionValueType P_0, qElnkuj0y19gMtThYBD LYkUSgjdwn6Y4tq1ktv, qElnkuj0y19gMtThYBD fr3k7DjFSFgVxpESitE) where qElnkuj0y19gMtThYBD : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0 switch
		{
			ConditionValueType.EQUAL => ibtSbH53Yrh(LYkUSgjdwn6Y4tq1ktv, fr3k7DjFSFgVxpESitE), 
			ConditionValueType.NOT_EQUAL => fs7SbFXfQma(LYkUSgjdwn6Y4tq1ktv, fr3k7DjFSFgVxpESitE), 
			ConditionValueType.LESS_THAN => zY7SbjgEWfx(LYkUSgjdwn6Y4tq1ktv, fr3k7DjFSFgVxpESitE), 
			ConditionValueType.GREATER_THAN => Kp8Sb8OpO10(LYkUSgjdwn6Y4tq1ktv, fr3k7DjFSFgVxpESitE), 
			_ => false, 
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ibtSbH53Yrh<WiYuV2jxwfLIxDschxK>(WiYuV2jxwfLIxDschxK eYO7l5j2cPJw9uwjV5v, WiYuV2jxwfLIxDschxK Cknt0YjT6m2tX7iaWwk) where WiYuV2jxwfLIxDschxK : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return eYO7l5j2cPJw9uwjV5v.CompareTo(Cknt0YjT6m2tX7iaWwk) == 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool fs7SbFXfQma<qcxSLejLPlcNLlPOBew>(qcxSLejLPlcNLlPOBew zC7GxhjJOJ9WapOyatv, qcxSLejLPlcNLlPOBew YMGsDAjHnl0DceMLjNg) where qcxSLejLPlcNLlPOBew : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return zC7GxhjJOJ9WapOyatv.CompareTo(YMGsDAjHnl0DceMLjNg) != 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool zY7SbjgEWfx<A4aOtAjMu27hWlo4BmH>(A4aOtAjMu27hWlo4BmH ebUAuCjVjXK5jmVOSAL, A4aOtAjMu27hWlo4BmH QJOxFEjEWplKtt9Xc1A) where A4aOtAjMu27hWlo4BmH : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return ebUAuCjVjXK5jmVOSAL.CompareTo(QJOxFEjEWplKtt9Xc1A) < 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool Kp8Sb8OpO10<LagM6pjRyu18gN45d3d>(LagM6pjRyu18gN45d3d QCBGH1jipVy53KpMvq9, LagM6pjRyu18gN45d3d AhgO5njvmMbA41wNxKu) where LagM6pjRyu18gN45d3d : IComparable
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return QCBGH1jipVy53KpMvq9.CompareTo(AhgO5njvmMbA41wNxKu) > 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool InitSRProcess(List<TagNode> pList, string[] nodeSelectors, SearchReplaceCriteria criteria, Dictionary<string, object> variables, SearchReplaceResult regionResults)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		try
		{
			regionResults.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72648) + criteria.Name);
			regionResults.TabCount++;
			result = IlASbzc2SY7(pList, nodeSelectors, criteria, variables, regionResults);
			regionResults.TabCount--;
			regionResults.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72682));
		}
		catch (Exception)
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool uWvSb9AHbEy(List<TagNode> P_0, SearchReplaceCriteria P_1, Dictionary<string, object> P_2, SearchReplaceResult P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = null;
		if (!string.IsNullOrWhiteSpace(P_1.NodeSelector))
		{
			array = P_1.NodeSelector.Split('.');
		}
		List<TagNode> list = P_0.ToList();
		P_3.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72648) + P_1.Name);
		P_3.TabCount++;
		bool result = IlASbzc2SY7(list, array, P_1, P_2, P_3);
		P_3.TabCount--;
		P_3.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72682));
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ve6SbIUGoVl(string P_0, List<TagNode> P_1, string[] P_2, SearchReplaceCriteria P_3, Dictionary<string, object> P_4, SearchReplaceResult P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		TagNode tagNode = P_1.Last();
		List<int> list = new List<int>();
		string text = VsaSbcvhVbj(P_0);
		P_0 = P_0.Substring(0, P_0.IndexOf('['));
		if (((TagNodeCompound)tagNode).ContainsKey(P_0))
		{
			_ = ((TagNodeCompound)tagNode)[P_0];
			if (((TagNodeCompound)tagNode)[P_0] is TagNodeList tagNodeList)
			{
				if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10366))
				{
					list.Clear();
					for (int i = 0; i < tagNodeList.Count; i++)
					{
						list.Add(i);
					}
				}
				else
				{
					list = IntSringConverter.ConvertFromString(text);
				}
				list.Sort();
				for (int num = list.Count - 1; num >= 0; num--)
				{
					int num2 = list[num];
					if (num2 < tagNodeList.Count)
					{
						List<TagNode> list2 = P_1.ToList();
						list2.Add(tagNodeList);
						list2.Add(tagNodeList[num2]);
						if (IlASbzc2SY7(list2, P_2, P_3, P_4, P_5))
						{
							result = true;
						}
					}
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IlASbzc2SY7(List<TagNode> P_0, string[] P_1, SearchReplaceCriteria P_2, Dictionary<string, object> P_3, SearchReplaceResult P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		TagNode tagNode = P_0.Last();
		TagNode tagNode2 = null;
		int i = 0;
		if (P_1 != null)
		{
			for (i = 0; i < P_1.Length; i++)
			{
				string text = P_1[i].Trim();
				if (text.Contains('['))
				{
					List<string> list = P_1.Skip(i + 1).ToList();
					if (ve6SbIUGoVl(text, P_0, list.ToArray(), P_2, P_3, P_4))
					{
						result = true;
					}
				}
				else if (tagNode is TagNodeCompound && ((TagNodeCompound)tagNode).ContainsKey(text))
				{
					tagNode2 = ((TagNodeCompound)tagNode)[text];
				}
				if (tagNode2 == null && i != P_1.Length - 1)
				{
					break;
				}
				tagNode = tagNode2;
				tagNode2 = null;
				P_0.Add(tagNode);
			}
		}
		if (P_1 == null || i == P_1.Length)
		{
			if (C1ZSbOq7nOg(P_0.ToList(), P_2))
			{
				P_4.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72710));
				try
				{
					jTiSbesNiSn(P_0.ToList(), P_2, P_3, P_4);
					if (P_2.Children != null)
					{
						foreach (SearchReplaceCriteria child in P_2.Children)
						{
							if (child.Active)
							{
								uWvSb9AHbEy(P_0.ToList(), child, P_3, P_4);
							}
						}
					}
					result = true;
				}
				catch (Exception ex)
				{
					P_4.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72766) + ex.Message);
				}
			}
			else
			{
				P_4.AddResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72824));
			}
		}
		return result;
	}
}
