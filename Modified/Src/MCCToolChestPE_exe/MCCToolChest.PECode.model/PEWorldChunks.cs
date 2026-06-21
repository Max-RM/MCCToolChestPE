using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.PECode.model;

public class PEWorldChunks
{
	private Dictionary<int, Dictionary<string, PERegionChunks>> nmUSWA1fKRE;

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal Dictionary<int, Dictionary<string, PERegionChunks>> NS3SWObVTQd()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return nmUSWA1fKRE;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void HRUSWC0oqhq(Dictionary<int, Dictionary<string, PERegionChunks>> value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		nmUSWA1fKRE = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRecord(int dimension, int x, int z, int tag, int section, byte[] value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!nmUSWA1fKRE.ContainsKey(dimension))
		{
			nmUSWA1fKRE[dimension] = new Dictionary<string, PERegionChunks>();
		}
		int num = (int)Math.Floor((double)x / 32.0);
		int num2 = (int)Math.Floor((double)z / 32.0);
		string key = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69594), num, num2);
		if (!nmUSWA1fKRE[dimension].ContainsKey(key))
		{
			nmUSWA1fKRE[dimension].Add(key, new PERegionChunks(dimension, num, num2));
		}
		nmUSWA1fKRE[dimension][key].AddRecord(x, z, tag, section, value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWorldChunks()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		nmUSWA1fKRE = new Dictionary<int, Dictionary<string, PERegionChunks>>();
	}
}
