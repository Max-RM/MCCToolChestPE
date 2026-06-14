using System;

namespace Microsoft.ClearScript.V8;

[Flags]
public enum V8ScriptEngineFlags
{
	None = 0,
	EnableDebugging = 1,
	DisableGlobalMembers = 2,
	EnableRemoteDebugging = 4,
	AwaitDebuggerAndPauseOnStart = 8,
	EnableDateTimeConversion = 0x10,
	EnableDynamicModuleImports = 0x20
}
