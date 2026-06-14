using System;

namespace Substrate.Core;

public struct BlockKey(int _x, int _y, int _z) : IEquatable<BlockKey>
{
	public readonly int x = _x;

	public readonly int y = _y;

	public readonly int z = _z;

	public bool Equals(BlockKey bk)
	{
		if (x == bk.x && y == bk.y)
		{
			return z == bk.z;
		}
		return false;
	}

	public override bool Equals(object o)
	{
		try
		{
			return this == (BlockKey)o;
		}
		catch
		{
			return false;
		}
	}

	public override int GetHashCode()
	{
		int num = 23;
		num = num * 37 + x;
		num = num * 37 + y;
		return num * 37 + z;
	}

	public static bool operator ==(BlockKey k1, BlockKey k2)
	{
		if (k1.x == k2.x && k1.y == k2.y)
		{
			return k1.z == k2.z;
		}
		return false;
	}

	public static bool operator !=(BlockKey k1, BlockKey k2)
	{
		if (k1.x == k2.x && k1.y == k2.y)
		{
			return k1.z != k2.z;
		}
		return true;
	}

	public override string ToString()
	{
		return "(" + x + ", " + y + ", " + z + ")";
	}
}
