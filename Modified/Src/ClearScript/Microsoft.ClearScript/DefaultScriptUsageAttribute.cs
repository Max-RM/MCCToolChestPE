using System;

namespace Microsoft.ClearScript;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
public class DefaultScriptUsageAttribute : Attribute
{
	private readonly ScriptAccess access;

	public ScriptAccess Access => access;

	public DefaultScriptUsageAttribute()
	{
	}

	public DefaultScriptUsageAttribute(ScriptAccess access)
	{
		this.access = access;
	}
}
