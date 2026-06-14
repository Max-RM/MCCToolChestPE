using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class PEDimension
{
	private int e3BSWdOYMa4;

	private Dictionary<string, PERegion> nDASWHijWjY;

	public int Dimension
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return e3BSWdOYMa4;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			e3BSWdOYMa4 = value;
		}
	}

	public Dictionary<string, PERegion> Region
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return nDASWHijWjY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			nDASWHijWjY = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEDimension()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		nDASWHijWjY = new Dictionary<string, PERegion>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEDimension(int dimension)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		nDASWHijWjY = new Dictionary<string, PERegion>();
		e3BSWdOYMa4 = dimension;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddChunkEntryToRegion(int x, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int x2 = (int)Math.Floor((double)x / 32.0);
		int z2 = (int)Math.Floor((double)z / 32.0);
		int num = (x & 0x1F) + (z & 0x1F) * 32;
		string key = x2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + z2;
		if (!nDASWHijWjY.ContainsKey(key))
		{
			nDASWHijWjY[key] = new PERegion(e3BSWdOYMa4, x2, z2);
		}
		nDASWHijWjY[key].Chunks[num] = 1;
	}
}
