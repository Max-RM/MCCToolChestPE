using System;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class TileEntityConversion
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound CreatePEBlockEntityFromPC(string id, int x, int y, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		if (!string.IsNullOrWhiteSpace(id) && Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME.ContainsKey(id))
		{
			try
			{
				int key = Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME[id];
				string text = Constants.peEntityDefaults[key];
				tagNodeCompound = (TagNodeCompound)lxe7hMuSirBXGUQugsD.v4fSPe0WJtV(text);
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] = new TagNodeInt(x);
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] = new TagNodeInt(y);
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] = new TagNodeInt(z);
			}
			catch (Exception)
			{
			}
		}
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TileEntityConversion()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
