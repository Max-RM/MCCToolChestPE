using System;

namespace Substrate.Core;

public struct ChunkKey(int _cx, int _cz) : IEquatable<ChunkKey>
{
	public readonly int cx = _cx;

	public readonly int cz = _cz;

	public bool Equals(ChunkKey ck)
	{
		if (cx == ck.cx)
		{
			return cz == ck.cz;
		}
		return false;
	}

	public override bool Equals(object o)
	{
		try
		{
			return this == (ChunkKey)o;
		}
		catch
		{
			return false;
		}
	}

	public override int GetHashCode()
	{
		int num = 23;
		num = num * 37 + cx;
		return num * 37 + cz;
	}

	public static bool operator ==(ChunkKey k1, ChunkKey k2)
	{
		if (k1.cx == k2.cx)
		{
			return k1.cz == k2.cz;
		}
		return false;
	}

	public static bool operator !=(ChunkKey k1, ChunkKey k2)
	{
		if (k1.cx == k2.cx)
		{
			return k1.cz != k2.cz;
		}
		return true;
	}

	public override string ToString()
	{
		return "(" + cx + ", " + cz + ")";
	}
}
