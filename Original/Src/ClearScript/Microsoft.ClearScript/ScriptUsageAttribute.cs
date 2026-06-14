using System;

namespace Microsoft.ClearScript;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface)]
public class ScriptUsageAttribute : Attribute
{
	private readonly ScriptAccess access;

	public ScriptAccess Access => access;

	public ScriptUsageAttribute()
	{
	}

	public ScriptUsageAttribute(ScriptAccess access)
	{
		this.access = access;
	}
}
