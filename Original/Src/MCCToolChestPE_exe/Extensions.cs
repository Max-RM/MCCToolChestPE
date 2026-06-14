using System;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;

public static class Extensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ulong NextULong(this Random rng)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[8];
		rng.NextBytes(array);
		return BitConverter.ToUInt64(array, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ulong NextULong(this Random rng, ulong max, bool inclusiveUpperBound = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return rng.NextULong(0uL, max, inclusiveUpperBound);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ulong NextULong(this Random rng, ulong min, ulong max, bool inclusiveUpperBound = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ulong num = max - min;
		if (inclusiveUpperBound)
		{
			if (num == ulong.MaxValue)
			{
				return rng.NextULong();
			}
			num++;
		}
		if (num == 0)
		{
			throw new ArgumentOutOfRangeException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34792), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35000));
		}
		ulong num2 = ulong.MaxValue - ulong.MaxValue % num;
		ulong num3;
		do
		{
			num3 = rng.NextULong();
		}
		while (num3 > num2);
		return num3 % num + min;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static long NextLong(this Random rng)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[8];
		rng.NextBytes(array);
		return BitConverter.ToInt64(array, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static long NextLong(this Random rng, long max, bool inclusiveUpperBound = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return rng.NextLong(long.MinValue, max, inclusiveUpperBound);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static long NextLong(this Random rng, long min, long max, bool inclusiveUpperBound = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ulong num = (ulong)(max - min);
		if (inclusiveUpperBound)
		{
			if (num == ulong.MaxValue)
			{
				return rng.NextLong();
			}
			num++;
		}
		if (num == 0)
		{
			throw new ArgumentOutOfRangeException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34792), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35000));
		}
		ulong num2 = ulong.MaxValue - ulong.MaxValue % num;
		ulong num3;
		do
		{
			num3 = rng.NextULong();
		}
		while (num3 > num2);
		return (long)(num3 % num) + min;
	}
}
