using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using DynamicExpresso;
using IyRZn8ZYGEub6tLA5J;
using YBh7EaXMWmkFRJOX37M;

namespace QEsfVoh9ZZXn5mNuWN;

internal class sPZ7OS3SmSHIXwVxPF
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1
	{
		public string methodName;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass1()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _003CGetExtensionMethods_003Eb__0(MethodInfo p)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return p.Name == methodName;
		}
	}

	private readonly Dictionary<string, Parameter> RVaUSpbGUm;

	private readonly HashSet<Parameter> mvCUG1wkfh;

	private readonly HashSet<ReferenceType> xZOUbsfLFp;

	private readonly HashSet<Identifier> njVUvtYC8e;

	[CompilerGenerated]
	private JfIdFKont95njV0rOs IJSUw7WSsl;

	[CompilerGenerated]
	private string LjCU466PIl;

	[CompilerGenerated]
	private Type Va8UV2GYJG;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sPZ7OS3SmSHIXwVxPF(string P_0, JfIdFKont95njV0rOs P_1, Type P_2, IEnumerable<Parameter> P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		mvCUG1wkfh = new HashSet<Parameter>();
		xZOUbsfLFp = new HashSet<ReferenceType>();
		njVUvtYC8e = new HashSet<Identifier>();
		aetMOHjecc(P_0);
		C6pMAOG6sM(P_2);
		iLPMumsoCX(P_1);
		RVaUSpbGUm = new Dictionary<string, Parameter>(P_1.ONGgiTwrV7());
		foreach (Parameter item in P_3)
		{
			try
			{
				RVaUSpbGUm.Add(item.Name, item);
			}
			catch (ArgumentException)
			{
				throw new DuplicateParameterException(item.Name);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	public JfIdFKont95njV0rOs T3XMJgN6ti()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return IJSUw7WSsl;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	private void iLPMumsoCX(JfIdFKont95njV0rOs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IJSUw7WSsl = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	public string VrHMQkCS2i()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return LjCU466PIl;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	private void aetMOHjecc(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LjCU466PIl = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	public Type tS0M7M02Dr()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Va8UV2GYJG;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	private void C6pMAOG6sM(Type P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Va8UV2GYJG = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public IEnumerable<Parameter> bH2MHNKOKO()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return RVaUSpbGUm.Values;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public IEnumerable<Parameter> Qr9Mjrr17d()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return mvCUG1wkfh;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public IEnumerable<ReferenceType> TMaM9M4WdH()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return xZOUbsfLFp;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public IEnumerable<Identifier> IvtMzJRQ7C()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return njVUvtYC8e;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool I3HM6vFyb3(string P_0, out Type P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (T3XMJgN6ti().mgEgTeQk8H().TryGetValue(P_0, out var value))
		{
			xZOUbsfLFp.Add(value);
			P_1 = value.Type;
			return true;
		}
		P_1 = null;
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool j0TMNE5ynh(string P_0, out Expression P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (T3XMJgN6ti().uwigGmJeK2().TryGetValue(P_0, out var value))
		{
			njVUvtYC8e.Add(value);
			P_1 = value.Expression;
			return true;
		}
		P_1 = null;
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool VaBMDFNjkd(string P_0, out ParameterExpression P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (RVaUSpbGUm.TryGetValue(P_0, out var value))
		{
			mvCUG1wkfh.Add(value);
			P_1 = value.Expression;
			return true;
		}
		P_1 = null;
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<MethodInfo> N6mMcyEYHj(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003C_003Ec__DisplayClass1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass1();
		CS_0024_003C_003E8__locals2.methodName = P_0;
		return T3XMJgN6ti().x3IgvxyMcS().Where([MethodImpl(MethodImplOptions.NoInlining)] (MethodInfo p) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return p.Name == CS_0024_003C_003E8__locals2.methodName;
		});
	}
}
