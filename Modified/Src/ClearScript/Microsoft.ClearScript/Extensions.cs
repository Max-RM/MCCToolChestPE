using System;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public static class Extensions
{
	public static object ToHostType(this Type type)
	{
		return type.ToHostType(ScriptEngine.Current);
	}

	public static object ToHostType(this Type type, ScriptEngine engine)
	{
		MiscHelpers.VerifyNonNullArgument(type, "type");
		MiscHelpers.VerifyNonNullArgument(engine, "engine");
		return HostItem.Wrap(engine, HostType.Wrap(type));
	}

	public static object ToRestrictedHostObject<T>(this T target)
	{
		return target.ToRestrictedHostObject(ScriptEngine.Current);
	}

	public static object ToRestrictedHostObject<T>(this T target, ScriptEngine engine)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		MiscHelpers.VerifyNonNullArgument(engine, "engine");
		return HostItem.Wrap(engine, target, typeof(T));
	}
}
