using System;

namespace Microsoft.ClearScript;

[Flags]
public enum ScriptMemberFlags
{
	None = 0,
	ExposeRuntimeType = 1,
	WrapNullResult = 2
}
