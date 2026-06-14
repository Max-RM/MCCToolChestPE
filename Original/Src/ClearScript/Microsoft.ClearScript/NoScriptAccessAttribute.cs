using System;

namespace Microsoft.ClearScript;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface)]
public sealed class NoScriptAccessAttribute : ScriptUsageAttribute
{
	public NoScriptAccessAttribute()
		: base(ScriptAccess.None)
	{
	}
}
