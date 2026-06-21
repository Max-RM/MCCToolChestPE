using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using HaI2p2xMqxTADue2UA;
using HiT3kduFNLtRQIR37JV;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class InventoryItem
{
	private List<string> q4DSZjiHJvT;

	private object OkeSZ8vcadf;

	private Image KpgSZ9LRvae;

	private bool AiuSZIMwCxu;

	private TagNodeCompound IsuSZzwub6X;

	public object ItemBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return OkeSZ8vcadf;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			OkeSZ8vcadf = value;
		}
	}

	public TagNodeCompound Tag
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return XqYSZHuoENj();
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			IsuSZzwub6X = value;
		}
	}

	public short ID
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			short result = 0;
			if (IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				string key = IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
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
				result = IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeShort;
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
			IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeShort(value);
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
			if (KpgSZ9LRvae == null)
			{
				if (ItemBase != null && ItemBase is MasterBlock)
				{
					MasterBlock masterBlock = ItemBase as MasterBlock;
					KpgSZ9LRvae = Jlxk34F1xl7DbN5CrR.zNmSWSvkA8(masterBlock.Name);
				}
				if (KpgSZ9LRvae == null && ItemBase != null && ItemBase is ItemTranslate)
				{
					ItemTranslate itemTranslate = ItemBase as ItemTranslate;
					KpgSZ9LRvae = Jlxk34F1xl7DbN5CrR.zNmSWSvkA8(itemTranslate.JavaName);
				}
				if (KpgSZ9LRvae == null)
				{
					KpgSZ9LRvae = Jlxk34F1xl7DbN5CrR.zNmSWSvkA8(Name);
					if (KpgSZ9LRvae == null && BlockMaster.PEBlocksByName.ContainsKey(Name))
					{
						KpgSZ9LRvae = Jlxk34F1xl7DbN5CrR.zNmSWSvkA8(BlockMaster.PEBlocksByName[Name].Name);
					}
				}
			}
			return KpgSZ9LRvae;
		}
	}

	public byte Slot
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] as TagNodeByte;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] = new TagNodeByte(value);
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
			return IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] as TagNodeByte;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] = new TagNodeByte(value);
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
			return IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] as TagNodeShort;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] = new TagNodeShort(value);
		}
	}

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!IsuSZzwub6X.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)))
			{
				return "";
			}
			return IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] as TagNodeString;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] = new TagNodeString(value);
		}
	}

	public short MaxDamage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (Constants.itemDamageValues.ContainsKey(ID))
			{
				return Constants.itemDamageValues[ID];
			}
			return 0;
		}
	}

	public bool Alternative
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return AiuSZIMwCxu;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			AiuSZIMwCxu = value;
		}
	}

	public byte Stack
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (Constants.InventoryMaxCount.ContainsKey(ID))
			{
				return Constants.InventoryMaxCount[ID];
			}
			return 64;
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
			if (IsuSZzwub6X.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
			{
				return ((TagNodeCompound)IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)]).ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992));
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

	public bool Known
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
	public InventoryItem()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		q4DSZjiHJvT = new List<string> { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15574) };
		IsuSZzwub6X = N5lSZFntvE7(0, 0, 0, 0, "");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventoryItem(short id, byte count = 1, byte slot = 0, short damage = 0, string name = "", object itemBase = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		q4DSZjiHJvT = new List<string> { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15574) };
		OkeSZ8vcadf = itemBase;
		IsuSZzwub6X = N5lSZFntvE7(id, count, slot, damage, name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventoryItem(TagNodeCompound item)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		q4DSZjiHJvT = new List<string> { Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15574) };
		_ = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974).Length;
		IsuSZzwub6X = (TagNodeCompound)item.Copy();
		if (IsuSZzwub6X.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
		{
			return;
		}
		short iD = 0;
		if (IsuSZzwub6X.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)))
		{
			string name = Name;
			short num = 0;
			if (IsuSZzwub6X.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)))
			{
				num = IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] as TagNodeShort;
			}
			if (BlockMaster.PEBlocksByName.ContainsKey(name) && !q4DSZjiHJvT.Contains(name))
			{
				OkeSZ8vcadf = BlockMaster.PEBlocksByName[name];
				if (IsuSZzwub6X.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11032)))
				{
					TagNodeCompound tagNodeCompound = IsuSZzwub6X[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11032)] as TagNodeCompound;
					TagNodeCompound values = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892)] as TagNodeCompound;
					OkeSZ8vcadf = BlockMaster.GetBedrockBlockState(name, values).masterBlock;
				}
				if (BlockMaster.PEBlocksByName[name].bedrock.id.HasValue)
				{
					iD = (short)BlockMaster.PEBlocksByName[name].bedrock.id.Value;
				}
			}
			else if (ItemTranslations.BedrockItemsByName.ContainsKey(name))
			{
				iD = (short)((ItemTranslate)(OkeSZ8vcadf = ItemTranslations.cw0SB9KIOKd(name, num))).BedrockId;
			}
		}
		ID = iD;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound XqYSZHuoENj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (IsuSZzwub6X == null || IsuSZzwub6X == null)
		{
			IsuSZzwub6X = N5lSZFntvE7(0, 0, 0, 0, "");
		}
		return IsuSZzwub6X;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound N5lSZFntvE7(short P_0, byte P_1, byte P_2, short P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] = new TagNodeByte(P_1);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] = new TagNodeShort(P_3);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeShort(P_0);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] = new TagNodeByte(P_2);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] = new TagNodeString(P_4);
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNodeCompound GetProcessedNode()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = (TagNodeCompound)Tag.Copy();
		tagNodeCompound.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634));
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string Description()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ItemBase != null && ItemBase is MasterBlock)
		{
			return (ItemBase as MasterBlock).Name;
		}
		if (ItemBase != null && ItemBase is ItemTranslate)
		{
			return (ItemBase as ItemTranslate).JavaName;
		}
		return Name;
	}
}
