using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.PECode.model;

public class PERegionChunks
{
	private Dictionary<string, PEChunkData> LuNSWJ1mq7I;

	private int FF0SWu3mnwy;

	private int yR0SWorY8xD;

	private int EY3SWQlkLWV;

	public int Dimension
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return FF0SWu3mnwy;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			FF0SWu3mnwy = value;
		}
	}

	public int RX
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return yR0SWorY8xD;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			yR0SWorY8xD = value;
		}
	}

	public int RZ
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return EY3SWQlkLWV;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EY3SWQlkLWV = value;
		}
	}

	internal Dictionary<string, PEChunkData> Chunks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return LuNSWJ1mq7I;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			LuNSWJ1mq7I = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PERegionChunks()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		LuNSWJ1mq7I = new Dictionary<string, PEChunkData>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PERegionChunks(int dimension, int rx, int rz)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		LuNSWJ1mq7I = new Dictionary<string, PEChunkData>();
		FF0SWu3mnwy = dimension;
		yR0SWorY8xD = rx;
		EY3SWQlkLWV = rz;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRecord(int x, int z, int tag, int section, byte[] value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string key = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85446), x, z);
		if (!LuNSWJ1mq7I.ContainsKey(key))
		{
			LuNSWJ1mq7I[key] = new PEChunkData(FF0SWu3mnwy, x, z);
		}
		LuNSWJ1mq7I[key].AddRecord(tag, section, value);
	}
}
