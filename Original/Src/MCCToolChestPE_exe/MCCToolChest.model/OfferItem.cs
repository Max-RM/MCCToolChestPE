using System.Drawing;
using System.Runtime.CompilerServices;
using HaI2p2xMqxTADue2UA;
using HiT3kduFNLtRQIR37JV;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class OfferItem
{
	private TagNodeCompound bfGSwHBMpQd;

	public TagNodeCompound Tag
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return bfGSwHBMpQd;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			bfGSwHBMpQd = value;
		}
	}

	public short Id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			short result = 0;
			if (bfGSwHBMpQd[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				string key = bfGSwHBMpQd[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
				if (INYifyudg3hCpcrleHt.mXTS0yn6FgU().ContainsKey(key))
				{
					result = (short)INYifyudg3hCpcrleHt.mXTS0yn6FgU()[key].Id;
				}
				else if (ItemTranslations.BedrockItemsByName.ContainsKey(key))
				{
					result = (short)ItemTranslations.BedrockItemsByName[key].BedrockId;
				}
			}
			else
			{
				result = bfGSwHBMpQd[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeShort;
			}
			return result;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			bfGSwHBMpQd[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeShort(value);
		}
	}

	public byte Count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return WB8SwA1RgmB()[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] as TagNodeByte;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			bfGSwHBMpQd[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] = new TagNodeByte(value);
		}
	}

	public short Damage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return WB8SwA1RgmB()[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] as TagNodeShort;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			bfGSwHBMpQd[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] = new TagNodeShort(value);
		}
	}

	public Image Image
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Jlxk34F1xl7DbN5CrR.YOTSpprXb7(Id, Damage);
		}
	}

	public bool Enchanted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (bfGSwHBMpQd.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
			{
				return ((TagNodeCompound)bfGSwHBMpQd[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)]).ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992));
			}
			return false;
		}
	}

	public bool Enchantable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OfferItem()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		WB8SwA1RgmB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OfferItem(TagNodeCompound tag)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		bfGSwHBMpQd = tag;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound WB8SwA1RgmB()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (bfGSwHBMpQd == null || bfGSwHBMpQd == null)
		{
			bfGSwHBMpQd = sZUSwdI1VYu(0, 0, 0);
		}
		return bfGSwHBMpQd;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TagNodeCompound sZUSwdI1VYu(short P_0, byte P_1, short P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] = new TagNodeByte(P_1);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] = new TagNodeShort(P_2);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeShort(P_0);
		return tagNodeCompound;
	}
}
