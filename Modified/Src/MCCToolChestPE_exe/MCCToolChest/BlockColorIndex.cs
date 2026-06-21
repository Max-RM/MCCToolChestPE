using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Substrate.Data;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest;

public class BlockColorIndex
{
	private Dictionary<int, ColorGroup> nUbSvC2rUnk;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockColorIndex()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		nUbSvC2rUnk = new Dictionary<int, ColorGroup>();
		nUbSvC2rUnk.Add(0, ColorGroup.Other);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ColorGroup GetColorIndex(int data)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ColorGroup colorGroup = ColorGroup.Other;
		if (nUbSvC2rUnk.ContainsKey(data))
		{
			return nUbSvC2rUnk[data];
		}
		return nUbSvC2rUnk[0];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void jVNSvOn9cu8(int P_0, ColorGroup P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		nUbSvC2rUnk[P_0] = P_1;
	}
}
