using System.Collections.Generic;
using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.PECode.model;

public class PEChunkData
{
	private int wOiSWEb6VPx;

	private int AcmSWrbxm6o;

	private int INJSW5wjcgM;

	private Dictionary<int, byte[]> vgaSW6TLFWf;

	private Dictionary<int, byte[]> w5eSWNnkIIY;

	public int Dimension
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return INJSW5wjcgM;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			INJSW5wjcgM = value;
		}
	}

	public int Z
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return AcmSWrbxm6o;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			AcmSWrbxm6o = value;
		}
	}

	public int X
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wOiSWEb6VPx;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			wOiSWEb6VPx = value;
		}
	}

	public Dictionary<int, byte[]> ChunkData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return w5eSWNnkIIY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			w5eSWNnkIIY = value;
		}
	}

	public Dictionary<int, byte[]> BlockSections
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return vgaSW6TLFWf;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			vgaSW6TLFWf = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEChunkData()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		vgaSW6TLFWf = new Dictionary<int, byte[]>();
		w5eSWNnkIIY = new Dictionary<int, byte[]>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEChunkData(int dimension, int x, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		vgaSW6TLFWf = new Dictionary<int, byte[]>();
		w5eSWNnkIIY = new Dictionary<int, byte[]>();
		INJSW5wjcgM = dimension;
		wOiSWEb6VPx = x;
		AcmSWrbxm6o = z;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRecord(int tag, int section, byte[] value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (tag == 47)
		{
			vgaSW6TLFWf[section] = value;
		}
		else
		{
			w5eSWNnkIIY[tag] = value;
		}
	}
}
