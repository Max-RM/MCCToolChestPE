using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.ClearScript.Util;

internal sealed class MemberComparer<T> : EqualityComparer<T> where T : MemberInfo
{
	private static readonly MemberComparer<T> instance = new MemberComparer<T>();

	public static MemberComparer<T> Instance => instance;

	public override bool Equals(T x, T y)
	{
		try
		{
			return x.Module == y.Module && x.MetadataToken == y.MetadataToken;
		}
		catch (Exception)
		{
			return x == y;
		}
	}

	public override int GetHashCode(T obj)
	{
		if (!(obj == null))
		{
			return obj.GetHashCode();
		}
		return 0;
	}
}
