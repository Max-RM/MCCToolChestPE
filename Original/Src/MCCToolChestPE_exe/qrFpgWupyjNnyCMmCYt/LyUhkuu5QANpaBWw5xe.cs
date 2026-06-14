using System.Collections.Generic;
using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace qrFpgWupyjNnyCMmCYt;

internal static class LyUhkuu5QANpaBWw5xe
{
	private static readonly int[] YlLSg5PkTRM;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int[] pZ9Sg1QQyeI(this byte[] P_0, byte[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (kiPSgrZ1Bve(P_0, P_1))
		{
			return YlLSg5PkTRM;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < P_0.Length; i++)
		{
			if (LFCSgEGT57Z(P_0, i, P_1))
			{
				list.Add(i);
			}
		}
		if (list.Count != 0)
		{
			return list.ToArray();
		}
		return YlLSg5PkTRM;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool LFCSgEGT57Z(byte[] P_0, int P_1, byte[] P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_2.Length > P_0.Length - P_1)
		{
			return false;
		}
		for (int i = 0; i < P_2.Length; i++)
		{
			if (P_0[P_1 + i] != P_2[i])
			{
				return false;
			}
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool kiPSgrZ1Bve(byte[] P_0, byte[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null && P_1 != null && P_0.Length != 0 && P_1.Length != 0)
		{
			return P_1.Length > P_0.Length;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LyUhkuu5QANpaBWw5xe()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		YlLSg5PkTRM = new int[0];
	}
}
