using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using DynamicExpresso;
using IyRZn8ZYGEub6tLA5J;
using qKu0ijWwCUEywjMLLp;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace PwbOVPRWhl0aTUy3q9;

internal class xwcp5bEiNDpToylLF0
{
	private readonly JfIdFKont95njV0rOs uHSeuEGl2a;

	private static readonly Regex LNeeocOm9l;

	private static readonly Regex jxQeQhwK6u;

	private static readonly Regex C8leOUcpMZ;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public xwcp5bEiNDpToylLF0(JfIdFKont95njV0rOs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		uHSeuEGl2a = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IdentifiersInfo wYye5lCMkb(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0 = uYke654IVP(P_0);
		HashSet<string> hashSet = new HashSet<string>(uHSeuEGl2a.ONGgiTwrV7());
		HashSet<Identifier> hashSet2 = new HashSet<Identifier>();
		HashSet<ReferenceType> hashSet3 = new HashSet<ReferenceType>();
		foreach (Match item in LNeeocOm9l.Matches(P_0))
		{
			string value = item.Groups[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)].Value;
			if (!alZecLa6Je(value))
			{
				ReferenceType value3;
				if (uHSeuEGl2a.uwigGmJeK2().TryGetValue(value, out var value2))
				{
					hashSet2.Add(value2);
				}
				else if (uHSeuEGl2a.mgEgTeQk8H().TryGetValue(value, out value3))
				{
					hashSet3.Add(value3);
				}
				else
				{
					hashSet.Add(value);
				}
			}
		}
		return new IdentifiersInfo(hashSet, hashSet2, hashSet3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string uYke654IVP(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0 = P_0 ?? string.Empty;
		P_0 = VB2eNCQQOU(P_0);
		P_0 = Fd3eDt34sJ(P_0);
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string VB2eNCQQOU(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return jxQeQhwK6u.Replace(P_0, "");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string Fd3eDt34sJ(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return C8leOUcpMZ.Replace(P_0, "");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool alZecLa6Je(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return EDoCLYSxsUAlj0LLek.TbZLzS7xMm.Contains(P_0, uHSeuEGl2a.ONGgiTwrV7());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool mg2eJcOwo3(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!uHSeuEGl2a.uwigGmJeK2().ContainsKey(P_0))
		{
			return uHSeuEGl2a.mgEgTeQk8H().ContainsKey(P_0);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static xwcp5bEiNDpToylLF0()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		LNeeocOm9l = new Regex(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30526), RegexOptions.Compiled);
		jxQeQhwK6u = new Regex(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30594), RegexOptions.Compiled);
		C8leOUcpMZ = new Regex(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30638), RegexOptions.Compiled);
	}
}
