using System;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class ChunkLookup
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoesChunkExist(int dimension, int x, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)Math.Floor((double)x / 32.0);
		int num2 = (int)Math.Floor((double)z / 32.0);
		string key = num + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + num2;
		if (Working.PEDimensions != null && Working.PEDimensions[dimension].Region.ContainsKey(key))
		{
			return lxe7hMuSirBXGUQugsD.zNZSPALhXMG(Working.PEDimensions[dimension].Region[key].Chunks, x, z);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkLookup()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
