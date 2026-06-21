using System;

namespace Substrate;

public struct SpawnPoint : IEquatable<SpawnPoint>
{
	private readonly int _x;

	private readonly int _y;

	private readonly int _z;

	public int X => _x;

	public int Y => _y;

	public int Z => _z;

	public SpawnPoint(int x, int y, int z)
	{
		_x = x;
		_y = y;
		_z = z;
	}

	public bool Equals(SpawnPoint spawn)
	{
		if (_x == spawn._x && _y == spawn._y)
		{
			return _z == spawn._z;
		}
		return false;
	}

	public override bool Equals(object o)
	{
		if (o is SpawnPoint)
		{
			return this == (SpawnPoint)o;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 23;
		num = num * 37 + _x;
		num = num * 37 + _y;
		return num * 37 + _z;
	}

	public static bool operator ==(SpawnPoint k1, SpawnPoint k2)
	{
		if (k1._x == k2._x && k1._y == k2._y)
		{
			return k1._z == k2._z;
		}
		return false;
	}

	public static bool operator !=(SpawnPoint k1, SpawnPoint k2)
	{
		if (k1._x == k2._x && k1._y == k2._y)
		{
			return k1._z != k2._z;
		}
		return true;
	}

	public override string ToString()
	{
		return "(" + _x + ", " + _y + ", " + _z + ")";
	}
}
