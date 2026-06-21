using System;

namespace Microsoft.ClearScript;

internal sealed class SharedHostObjectMemberData : HostTargetMemberData
{
	public readonly Type AccessContext;

	public readonly ScriptAccess DefaultAccess;

	public SharedHostObjectMemberData(Type accessContext, ScriptAccess defaultAccess)
	{
		AccessContext = accessContext;
		DefaultAccess = defaultAccess;
	}
}
