using System;

namespace Microsoft.ClearScript;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event)]
public sealed class ScriptMemberAttribute : ScriptUsageAttribute
{
	public string Name { get; set; }

	public ScriptMemberFlags Flags { get; set; }

	public ScriptMemberAttribute()
	{
	}

	public ScriptMemberAttribute(string name)
	{
		Name = name;
	}

	public ScriptMemberAttribute(ScriptAccess access)
		: base(access)
	{
	}

	public ScriptMemberAttribute(string name, ScriptAccess access)
		: base(access)
	{
		Name = name;
	}

	public ScriptMemberAttribute(ScriptMemberFlags flags)
	{
		Flags = flags;
	}

	public ScriptMemberAttribute(string name, ScriptMemberFlags flags)
	{
		Name = name;
		Flags = flags;
	}

	public ScriptMemberAttribute(ScriptAccess access, ScriptMemberFlags flags)
		: base(access)
	{
		Flags = flags;
	}

	public ScriptMemberAttribute(string name, ScriptAccess access, ScriptMemberFlags flags)
		: base(access)
	{
		Name = name;
		Flags = flags;
	}
}
