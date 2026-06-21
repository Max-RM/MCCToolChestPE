using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class ExtensionMethodSummary
{
	public Type[] Types { get; private set; }

	public MethodInfo[] Methods { get; private set; }

	public string[] MethodNames { get; private set; }

	public ExtensionMethodSummary()
	{
		Types = ArrayHelpers.GetEmptyArray<Type>();
		Methods = ArrayHelpers.GetEmptyArray<MethodInfo>();
		MethodNames = ArrayHelpers.GetEmptyArray<string>();
	}

	public ExtensionMethodSummary(Dictionary<Type, MethodInfo[]> table)
	{
		Types = table.Keys.ToArray();
		Methods = table.SelectMany((KeyValuePair<Type, MethodInfo[]> pair) => pair.Value).ToArray();
		MethodNames = Methods.Select((MethodInfo method) => method.GetScriptName()).ToArray();
	}
}
