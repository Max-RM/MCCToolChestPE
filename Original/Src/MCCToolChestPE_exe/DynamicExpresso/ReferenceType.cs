using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using kiViqdlGgYQnwgUP6M;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

public class ReferenceType
{
	[CompilerGenerated]
	private Type DAXgLgJY02;

	[CompilerGenerated]
	private string bREggAg2Yr;

	[CompilerGenerated]
	private IList<MethodInfo> wXcgP0pOeQ;

	public Type Type
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return DAXgLgJY02;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			DAXgLgJY02 = value;
		}
	}

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return bREggAg2Yr;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			bREggAg2Yr = value;
		}
	}

	public IList<MethodInfo> ExtensionMethods
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wXcgP0pOeQ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			wXcgP0pOeQ = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReferenceType(string name, Type type)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862));
		}
		if (type == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31412));
		}
		Type = type;
		Name = name;
		ExtensionMethods = FLS0VqUVBIcgvM5JG4.Pl3gkkH9qT(type).ToList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReferenceType(Type type)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		if (type == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31412));
		}
		Type = type;
		Name = type.Name;
		ExtensionMethods = FLS0VqUVBIcgvM5JG4.Pl3gkkH9qT(type).ToList();
	}
}
