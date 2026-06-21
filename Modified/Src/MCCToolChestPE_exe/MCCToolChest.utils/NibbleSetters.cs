using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public class NibbleSetters
{
	private int YM6SRnPlFxb;

	private int eo8SRlLK07V;

	private int soxSR2prFLC;

	private int IooSRyfwued;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int RegionGet(byte[] data, int x, int y, int z, int offset)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (x << eo8SRlLK07V) | (z << YM6SRnPlFxb) | y;
		int num2 = num >> 1;
		int num3 = num & 1;
		num2 += offset;
		if (num3 == 0)
		{
			return data[num2] & 0xF;
		}
		return (data[num2] >> 4) & 0xF;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegionSet(byte[] data, int x, int y, int z, int val, int offset)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (x << eo8SRlLK07V) | (z << YM6SRnPlFxb) | y;
		int num2 = num >> 1;
		int num3 = num & 1;
		num2 += offset;
		if (num3 == 0)
		{
			data[num2] = (byte)((data[num2] & 0xF0) | (val & 0xF));
		}
		else
		{
			data[num2] = (byte)((data[num2] & 0xF) | ((val & 0xF) << 4));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AnvilGet(byte[] data, int x, int y, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (y << IooSRyfwued) | (z << soxSR2prFLC) | x;
		int num2 = num >> 1;
		if ((num & 1) == 0)
		{
			return data[num2] & 0xF;
		}
		return (data[num2] >> 4) & 0xF;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AnvilSet(byte[] data, int x, int y, int z, int val)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (y << IooSRyfwued) | (z << soxSR2prFLC) | x;
		int num2 = num >> 1;
		if ((num & 1) == 0)
		{
			data[num2] = (byte)((data[num2] & 0xF0) | (val & 0xF));
		}
		else
		{
			data[num2] = (byte)((data[num2] & 0xF) | ((val & 0xF) << 4));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int TU17Get(byte[] data, int x, int y, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (x * 16) | (y * 256) | z;
		int num2 = num >> 1;
		if ((num & 1) == 0)
		{
			return data[num2] & 0xF;
		}
		return (data[num2] >> 4) & 0xF;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int TU17GetFast(byte[] data, int pos)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = pos >> 1;
		if ((pos & 1) == 0)
		{
			return data[num] & 0xF;
		}
		return (data[num] >> 4) & 0xF;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TU17Set(byte[] data, int x, int y, int z, int val)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (x * 16) | (y * 256) | z;
		int num2 = num >> 1;
		if ((num & 1) == 0)
		{
			data[num2] = (byte)((data[num2] & 0xF0) | (val & 0xF));
		}
		else
		{
			data[num2] = (byte)((data[num2] & 0xF) | ((val & 0xF) << 4));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TU17SetFast(byte[] data, int pos, int val)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = pos >> 1;
		if ((pos & 1) == 0)
		{
			data[num] = (byte)((data[num] & 0xF0) | (val & 0xF));
		}
		else
		{
			data[num] = (byte)((data[num] & 0xF) | ((val & 0xF) << 4));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NibbleSetters()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		YM6SRnPlFxb = 7;
		eo8SRlLK07V = 11;
		soxSR2prFLC = 4;
		IooSRyfwued = 8;
	}
}
