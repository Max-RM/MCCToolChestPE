using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using DynamicExpresso;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace kiViqdlGgYQnwgUP6M;

internal static class FLS0VqUVBIcgvM5JG4
{
	public class c5hrXrP9xsiA1SeJTA
	{
		[CompilerGenerated]
		private Type ilbgDrr3IE;

		[CompilerGenerated]
		private Parameter[] afagc2KY6l;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public c5hrXrP9xsiA1SeJTA(Type P_0, Parameter[] P_1)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
			LyTgE4Y9PQ(P_0);
			Vvvg6oZN1H(P_1);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public Type LZkg1CCdJw()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ilbgDrr3IE;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		private void LyTgE4Y9PQ(Type P_0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ilbgDrr3IE = P_0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public Parameter[] RbVg5S5gkh()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return afagc2KY6l;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		private void Vvvg6oZN1H(Parameter[] P_0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			afagc2KY6l = P_0;
		}
	}

	[CompilerGenerated]
	private static Func<MethodInfo, bool> ltSg37B0rd;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static c5hrXrP9xsiA1SeJTA jbdgRwRBjc(Type P_0, params string[] parametersNames)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MethodInfo method = P_0.GetMethod(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(33232));
		if (method == null)
		{
			throw new ArgumentException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34304));
		}
		ParameterInfo[] parameters = method.GetParameters();
		Parameter[] array = new Parameter[parameters.Length];
		bool flag = parametersNames != null && parametersNames.Length > 0;
		if (flag && parametersNames.Length != array.Length)
		{
			throw new ArgumentException(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34380), array.Length));
		}
		for (int i = 0; i < array.Length; i++)
		{
			string name = (flag ? parametersNames[i] : parameters[i].Name);
			Type parameterType = parameters[i].ParameterType;
			array[i] = new Parameter(name, parameterType);
		}
		return new c5hrXrP9xsiA1SeJTA(method.ReturnType, array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<MethodInfo> Pl3gkkH9qT(Type P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.IsSealed && P_0.IsAbstract && !P_0.IsGenericType && !P_0.IsNested)
		{
			return P_0.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where([MethodImpl(MethodImplOptions.NoInlining)] (MethodInfo methodInfo) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return methodInfo.IsDefined(typeof(ExtensionAttribute), inherit: false);
			});
		}
		return Enumerable.Empty<MethodInfo>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static bool XvhgYgFQ93(MethodInfo P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.IsDefined(typeof(ExtensionAttribute), inherit: false);
	}
}
