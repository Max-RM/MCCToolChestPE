using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using D2t6j95OCnJPcFVdhd;
using DynamicExpresso.Visitors;
using IyRZn8ZYGEub6tLA5J;
using kiViqdlGgYQnwgUP6M;
using PwbOVPRWhl0aTUy3q9;
using QEsfVoh9ZZXn5mNuWN;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

public class Interpreter
{
	private readonly JfIdFKont95njV0rOs CVaMhR7Qbl;

	private readonly ISet<ExpressionVisitor> hASMmT4bsA;

	[CompilerGenerated]
	private static Func<KeyValuePair<string, ReferenceType>, ReferenceType> mcpMnm23s6;

	[CompilerGenerated]
	private static Func<KeyValuePair<string, Identifier>, Identifier> n09Ml7KTgY;

	[CompilerGenerated]
	private static Func<ExpressionVisitor, bool> mYqM29I4sS;

	public bool CaseInsensitive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return CVaMhR7Qbl.NqRg464DJS();
		}
	}

	public IEnumerable<ReferenceType> ReferencedTypes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return CVaMhR7Qbl.mgEgTeQk8H().Select([MethodImpl(MethodImplOptions.NoInlining)] (KeyValuePair<string, ReferenceType> P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.Value;
			}).ToList();
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
			return CVaMhR7Qbl.uwigGmJeK2().Select([MethodImpl(MethodImplOptions.NoInlining)] (KeyValuePair<string, Identifier> P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.Value;
			}).ToList();
		}
	}

	public AssignmentOperators AssignmentOperators
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return CVaMhR7Qbl.mbXgKVHT7l();
		}
	}

	public ISet<ExpressionVisitor> Visitors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return hASMmT4bsA;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter() : this(InterpreterOptions.Default)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter(InterpreterOptions options)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		hASMmT4bsA = new HashSet<ExpressionVisitor>();
		bool flag = options.HasFlag(InterpreterOptions.CaseInsensitive);
		CVaMhR7Qbl = new JfIdFKont95njV0rOs(flag);
		if ((options & InterpreterOptions.SystemKeywords) == InterpreterOptions.SystemKeywords)
		{
			SetIdentifiers(LanguageConstants.Literals);
		}
		if ((options & InterpreterOptions.PrimitiveTypes) == InterpreterOptions.PrimitiveTypes)
		{
			Reference(LanguageConstants.PrimitiveTypes);
			Reference(LanguageConstants.CSharpPrimitiveTypes);
		}
		if ((options & InterpreterOptions.CommonTypes) == InterpreterOptions.CommonTypes)
		{
			Reference(LanguageConstants.CommonTypes);
		}
		hASMmT4bsA.Add(new DisableReflectionVisitor());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter EnableAssignment(AssignmentOperators assignmentOperators)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CVaMhR7Qbl.HKNgh8D5Hd(assignmentOperators);
		return this;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter EnableReflection()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ExpressionVisitor expressionVisitor = Visitors.FirstOrDefault([MethodImpl(MethodImplOptions.NoInlining)] (ExpressionVisitor P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0 is DisableReflectionVisitor;
		});
		if (expressionVisitor != null)
		{
			Visitors.Remove(expressionVisitor);
		}
		return this;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter SetFunction(string name, Delegate value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return SetVariable(name, value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter SetVariable(string name, object value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862));
		}
		return SetExpression(name, Expression.Constant(value));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter SetVariable(string name, object value, Type type)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (type == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31412));
		}
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862));
		}
		return SetExpression(name, Expression.Constant(value, type));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter SetExpression(string name, Expression expression)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return SetIdentifier(new Identifier(name, expression));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter SetIdentifiers(IEnumerable<Identifier> identifiers)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (Identifier identifier in identifiers)
		{
			SetIdentifier(identifier);
		}
		return this;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter SetIdentifier(Identifier identifier)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (identifier == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15828));
		}
		CVaMhR7Qbl.uwigGmJeK2()[identifier.Name] = identifier;
		return this;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter Reference(Type type)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (type == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31412));
		}
		return Reference(type, type.Name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter Reference(IEnumerable<ReferenceType> types)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (types == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31424));
		}
		foreach (ReferenceType type in types)
		{
			Reference(type);
		}
		return this;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter Reference(Type type, string typeName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Reference(new ReferenceType(typeName, type));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Interpreter Reference(ReferenceType type)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (type == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31412));
		}
		CVaMhR7Qbl.mgEgTeQk8H()[type.Name] = type;
		foreach (MethodInfo extensionMethod in type.ExtensionMethods)
		{
			CVaMhR7Qbl.x3IgvxyMcS().Add(extensionMethod);
		}
		return this;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Lambda Parse(string expressionText, params Parameter[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Parse(expressionText, typeof(void), parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Lambda Parse(string expressionText, Type expressionType, params Parameter[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ef9MiI4Qy8(expressionText, expressionType, parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Obsolete("Use ParseAsDelegate<TDelegate>(string, params string[])")]
	public TDelegate Parse<TDelegate>(string expressionText, params string[] parametersNames)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return ParseAsDelegate<TDelegate>(expressionText, parametersNames);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TDelegate ParseAsDelegate<TDelegate>(string expressionText, params string[] parametersNames)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Lambda lambda = ParseAs<TDelegate>(expressionText, parametersNames);
		return lambda.Compile<TDelegate>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Expression<TDelegate> ParseAsExpression<TDelegate>(string expressionText, params string[] parametersNames)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Lambda lambda = ParseAs<TDelegate>(expressionText, parametersNames);
		return lambda.LambdaExpression<TDelegate>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Lambda ParseAs<TDelegate>(string expressionText, params string[] parametersNames)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FLS0VqUVBIcgvM5JG4.c5hrXrP9xsiA1SeJTA c5hrXrP9xsiA1SeJTA = FLS0VqUVBIcgvM5JG4.jbdgRwRBjc(typeof(TDelegate), parametersNames);
		return Ef9MiI4Qy8(expressionText, c5hrXrP9xsiA1SeJTA.LZkg1CCdJw(), c5hrXrP9xsiA1SeJTA.RbVg5S5gkh());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Eval(string expressionText, params Parameter[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Eval(expressionText, typeof(void), parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T Eval<T>(string expressionText, params Parameter[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (T)Eval(expressionText, typeof(T), parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Eval(string expressionText, Type expressionType, params Parameter[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Parse(expressionText, expressionType, parameters).Invoke(parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IdentifiersInfo DetectIdentifiers(string expression)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		xwcp5bEiNDpToylLF0 xwcp5bEiNDpToylLF1 = new xwcp5bEiNDpToylLF0(CVaMhR7Qbl);
		return xwcp5bEiNDpToylLF1.wYye5lCMkb(expression);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Lambda Ef9MiI4Qy8(string P_0, Type P_1, Parameter[] P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		sPZ7OS3SmSHIXwVxPF sPZ7OS3SmSHIXwVxPF2 = new sPZ7OS3SmSHIXwVxPF(P_0, CVaMhR7Qbl, P_1, P_2);
		Expression expression = bjj0vXnxxHOSafmVvJ.bBtUW6KdWi(sPZ7OS3SmSHIXwVxPF2);
		foreach (ExpressionVisitor visitor in Visitors)
		{
			expression = visitor.Visit(expression);
		}
		return new Lambda(expression, sPZ7OS3SmSHIXwVxPF2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static ReferenceType IUFMs9LYfR(KeyValuePair<string, ReferenceType> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static Identifier RxOMq82X3L(KeyValuePair<string, Identifier> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static bool RtTMKXW7jW(ExpressionVisitor P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0 is DisableReflectionVisitor;
	}
}
