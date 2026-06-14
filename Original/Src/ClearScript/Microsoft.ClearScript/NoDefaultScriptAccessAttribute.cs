using System;

namespace Microsoft.ClearScript;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
public sealed class NoDefaultScriptAccessAttribute : DefaultScriptUsageAttribute
{
	public NoDefaultScriptAccessAttribute()
		: base(ScriptAccess.None)
	{
	}
}
