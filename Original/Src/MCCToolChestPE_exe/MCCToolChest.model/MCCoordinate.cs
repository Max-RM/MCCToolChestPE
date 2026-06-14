using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class MCCoordinate
{
	public int x;

	public int y;

	public int z;

	public int val;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MCCoordinate(int x, int y, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		this.x = x;
		this.y = y;
		this.z = z;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MCCoordinate(int x, int y, int z, int val)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		this.x = x;
		this.y = y;
		this.z = z;
		this.val = val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool ax9Sw78H4rf(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (x == P_0 && y == P_1)
		{
			return z == P_2;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return x + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + y + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + z;
	}
}
