using System;

namespace Substrate.Core;

public struct RegionKey : IEquatable<RegionKey>
{
	public static RegionKey InvalidRegion = new RegionKey(int.MinValue, int.MinValue);

	private readonly int rx;

	private readonly int rz;

	public int X => rx;

	public int Z => rz;

	public RegionKey(int _rx, int _rz)
	{
		rx = _rx;
		rz = _rz;
	}

	public bool Equals(RegionKey ck)
	{
		if (rx == ck.rx)
		{
			return rz == ck.rz;
		}
		return false;
	}

	public override bool Equals(object o)
	{
		try
		{
			return this == (RegionKey)o;
		}
		catch
		{
			return false;
		}
	}

	public override int GetHashCode()
	{
		int num = 23;
		num = num * 37 + rx;
		return num * 37 + rz;
	}

	public static bool operator ==(RegionKey k1, RegionKey k2)
	{
		if (k1.rx == k2.rx)
		{
			return k1.rz == k2.rz;
		}
		return false;
	}

	public static bool operator !=(RegionKey k1, RegionKey k2)
	{
		if (k1.rx == k2.rx)
		{
			return k1.rz != k2.rz;
		}
		return true;
	}

	public override string ToString()
	{
		return "(" + rx + ", " + rz + ")";
	}
}
