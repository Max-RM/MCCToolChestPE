using System;
using System.Linq;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.ScriptExtensions;

public class ScriptExtensionMethods
{
	private static Random X1ASUv8IcNl;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int RandomInt(int startInt, int endInt)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return X1ASUv8IcNl.Next(startInt, endInt);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public double RandomDouble(int startInt, int endInt)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return X1ASUv8IcNl.NextDouble();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNode FillChest(TagNode node, int[] availableItems, int count, bool clearExisting)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return GenItems(node);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNode FillChest(TagNode node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return GenItems(node);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNode GenItems(TagNode node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			if (node is TagNodeCompound)
			{
				TagNodeList tagNodeList = ofZSUbqf1jZ(node);
				int num = kbbSUTnfEYw(node as TagNodeCompound);
				XueSUSn6Jv0(tagNodeList, num);
			}
		}
		catch (Exception)
		{
		}
		return node;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int kbbSUTnfEYw(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)].GetTagType() == TagType.TAG_STRING)
		{
			string data = ((TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)]).Data;
			if (data == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15174))
			{
				result = 27;
			}
			if (data == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15222))
			{
				result = 27;
			}
			if (data == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15344))
			{
				result = 9;
			}
			if (data == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15292))
			{
				result = 9;
			}
			if (data == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6056))
			{
				result = 27;
			}
			if (data == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6256))
			{
				result = 9;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XueSUSn6Jv0(TagNodeList P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ItemTranslate[] array = ItemTranslations.BedrockItemsByName.Values.ToArray();
		Random random = new Random();
		int maxValue = array.Length;
		if (P_0.Count == 0)
		{
			P_0.ChangeValueType(TagType.TAG_COMPOUND);
		}
		for (int i = 0; i < P_1; i++)
		{
			int num = random.Next(0, maxValue);
			_ = array[num];
			if (i >= P_0.Count)
			{
				P_0.Add(GQvSUGS640Y());
			}
			TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeString(array[num].BedrockName);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] = new TagNodeByte((byte)i);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] = new TagNodeByte((byte)random.Next(1, 65));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound GQvSUGS640Y()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeString();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] = new TagNodeByte();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] = new TagNodeByte();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] = new TagNodeShort();
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNode ItemIdToShort(TagNode node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			TagNodeList tagNodeList = ofZSUbqf1jZ(node);
			for (int i = 0; i < tagNodeList.Count; i++)
			{
				if (tagNodeList[i] is TagNodeCompound tagNodeCompound && tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)].GetTagType() == TagType.TAG_STRING)
				{
					string data = ((TagNodeString)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)]).Data;
					if (ItemTranslations.BedrockItemsByName.ContainsKey(data))
					{
						tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeShort((short)ItemTranslations.BedrockItemsByName[data].BedrockId);
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return node;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNode ItemIdToString(TagNode node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			TagNodeList tagNodeList = ofZSUbqf1jZ(node);
			for (int i = 0; i < tagNodeList.Count; i++)
			{
				if (tagNodeList[i] is TagNodeCompound tagNodeCompound && tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)].GetTagType() == TagType.TAG_SHORT)
				{
					int data = ((TagNodeShort)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)]).Data;
					if (ItemTranslations.BedrockItemsById.ContainsKey(data))
					{
						tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeString(ItemTranslations.BedrockItemsById[data].BedrockName);
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return node;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList ofZSUbqf1jZ(TagNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList result = null;
		if (P_0 is TagNodeCompound)
		{
			if (((TagNodeCompound)P_0).ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)))
			{
				result = ((TagNodeCompound)P_0)[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] as TagNodeList;
			}
		}
		else if (P_0 is TagNodeList && ((TagNodeList)P_0).ValueType == TagType.TAG_COMPOUND)
		{
			result = P_0 as TagNodeList;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNode SetRidingPosition(TagNode entity, string posNbt)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = entity as TagNodeCompound;
		if (tagNodeCompound != null)
		{
			while (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58844)))
			{
				tagNodeCompound = (TagNodeCompound)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58844)];
			}
		}
		TagNode tagNode = lxe7hMuSirBXGUQugsD.v4fSPe0WJtV(posNbt);
		if (tagNode is TagNodeList && tagNodeCompound != null)
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] = (TagNodeList)tagNode;
		}
		return entity;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public long GetUniqueId()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Random rng = new Random();
		long num = rng.NextLong(long.MinValue, long.MaxValue);
		if (num > 0)
		{
			num *= -1;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptExtensionMethods()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptExtensionMethods()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		X1ASUv8IcNl = new Random();
	}
}
