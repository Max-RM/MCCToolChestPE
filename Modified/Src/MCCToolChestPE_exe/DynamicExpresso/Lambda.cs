using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using QEsfVoh9ZZXn5mNuWN;
using Ttr0IavoqaYM2p4IQA;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

public class Lambda
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9
	{
		public Lambda _003C_003E4__this;

		public IEnumerable<Parameter> parameters;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass9()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IEnumerable<Parameter> _003CInvoke_003Eb__3(Parameter usedParameter)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return parameters;
		}
	}

	private readonly Expression ed6Me2hqgo;

	private readonly sPZ7OS3SmSHIXwVxPF f7KMMXMA4v;

	private readonly Delegate uRjMUqG3vt;

	public Expression Expression
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ed6Me2hqgo;
		}
	}

	public bool CaseInsensitive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return f7KMMXMA4v.T3XMJgN6ti().NqRg464DJS();
		}
	}

	public string ExpressionText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return f7KMMXMA4v.VrHMQkCS2i();
		}
	}

	public Type ReturnType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return uRjMUqG3vt.Method.ReturnType;
		}
	}

	[Obsolete("Use UsedParameters or DeclaredParameters")]
	public IEnumerable<Parameter> Parameters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return f7KMMXMA4v.Qr9Mjrr17d();
		}
	}

	public IEnumerable<Parameter> UsedParameters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return f7KMMXMA4v.Qr9Mjrr17d();
		}
	}

	public IEnumerable<Parameter> DeclaredParameters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return f7KMMXMA4v.bH2MHNKOKO();
		}
	}

	public IEnumerable<ReferenceType> Types
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return f7KMMXMA4v.TMaM9M4WdH();
		}
	}

	public IEnumerable<Identifier> Identifiers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return f7KMMXMA4v.IvtMzJRQ7C();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Lambda(Expression expression, sPZ7OS3SmSHIXwVxPF parserArguments)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		if (expression == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31388));
		}
		if (parserArguments == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31438));
		}
		ed6Me2hqgo = expression;
		f7KMMXMA4v = parserArguments;
		LambdaExpression lambdaExpression = Expression.Lambda(ed6Me2hqgo, f7KMMXMA4v.Qr9Mjrr17d().Select([MethodImpl(MethodImplOptions.NoInlining)] (Parameter P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.Expression;
		}).ToArray());
		uRjMUqG3vt = lambdaExpression.Compile();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Invoke()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return bE5MysVeJE(new object[0]);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Invoke(params Parameter[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Invoke((IEnumerable<Parameter>)parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Invoke(IEnumerable<Parameter> parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<object> values = new List<object>();
		foreach (Parameter usedParameter in UsedParameters)
		{
			foreach (Parameter actualParameter in parameters)
			{
				if (usedParameter.Name.Equals(actualParameter.Name, f7KMMXMA4v.T3XMJgN6ti().Cl8gpxvqAp()))
				{
					values.Add(actualParameter.Value);
					break;
				}
			}
		}
		return bE5MysVeJE(values.ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Invoke(params object[] args)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<Parameter> list = new List<Parameter>();
		Parameter[] array = DeclaredParameters.ToArray();
		if (args != null)
		{
			if (array.Length != args.Length)
			{
				throw new InvalidOperationException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31472));
			}
			for (int i = 0; i < args.Length; i++)
			{
				Parameter item = new Parameter(array[i].Name, array[i].Type, args[i]);
				list.Add(item);
			}
		}
		return Invoke(list);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private object bE5MysVeJE(object[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			return uRjMUqG3vt.DynamicInvoke(P_0);
		}
		catch (TargetInvocationException ex)
		{
			if (ex.InnerException != null)
			{
				ex.InnerException.DPoej999nG();
				throw ex.InnerException;
			}
			throw;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return ExpressionText;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TDelegate Compile<TDelegate>()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Expression<TDelegate> expression = LambdaExpression<TDelegate>();
		return expression.Compile();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Obsolete("Use Compile<TDelegate>()")]
	public TDelegate Compile<TDelegate>(IEnumerable<Parameter> parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Expression<TDelegate> expression = Expression.Lambda<TDelegate>(ed6Me2hqgo, parameters.Select([MethodImpl(MethodImplOptions.NoInlining)] (Parameter P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.Expression;
		}).ToArray());
		return expression.Compile();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Expression<TDelegate> LambdaExpression<TDelegate>()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Expression.Lambda<TDelegate>(ed6Me2hqgo, DeclaredParameters.Select([MethodImpl(MethodImplOptions.NoInlining)] (Parameter P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.Expression;
		}).ToArray());
	}
}
