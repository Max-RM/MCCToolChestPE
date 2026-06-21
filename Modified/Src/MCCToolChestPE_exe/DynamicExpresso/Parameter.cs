using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

public class Parameter
{
	[CompilerGenerated]
	private string E7uM1kKj3Y;

	[CompilerGenerated]
	private Type eHAMEUYnFC;

	[CompilerGenerated]
	private object ECsMrwneSF;

	[CompilerGenerated]
	private ParameterExpression ThxM5NZmVf;

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
			return E7uM1kKj3Y;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			E7uM1kKj3Y = value;
		}
	}

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
			return eHAMEUYnFC;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			eHAMEUYnFC = value;
		}
	}

	public object Value
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ECsMrwneSF;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ECsMrwneSF = value;
		}
	}

	public ParameterExpression Expression
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ThxM5NZmVf;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ThxM5NZmVf = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Parameter(string name, object value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		if (value == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31688));
		}
		Name = name;
		Type = value.GetType();
		Value = value;
		Expression = System.Linq.Expressions.Expression.Parameter(Type, name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Parameter(string name, Type type, object value = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Name = name;
		Type = type;
		Value = value;
		Expression = System.Linq.Expressions.Expression.Parameter(type, name);
	}
}
