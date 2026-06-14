using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class ExtensionMethodTable
{
	private readonly Dictionary<Type, MethodInfo[]> table = new Dictionary<Type, MethodInfo[]>();

	private ExtensionMethodSummary summary = new ExtensionMethodSummary();

	public ExtensionMethodSummary Summary => summary;

	public bool ProcessType(Type type, Type accessContext, ScriptAccess defaultAccess)
	{
		if (!table.ContainsKey(type) && type.HasExtensionMethods())
		{
			table[type] = (from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
				where IsScriptableExtensionMethod(method, accessContext, defaultAccess)
				select method).ToArray();
			RebuildSummary();
			return true;
		}
		return false;
	}

	public void RebuildSummary()
	{
		summary = new ExtensionMethodSummary(table);
	}

	private static bool IsScriptableExtensionMethod(MethodInfo method, Type accessContext, ScriptAccess defaultAccess)
	{
		if (method.IsScriptable(accessContext, defaultAccess))
		{
			return method.IsDefined(typeof(ExtensionAttribute), inherit: false);
		}
		return false;
	}
}
