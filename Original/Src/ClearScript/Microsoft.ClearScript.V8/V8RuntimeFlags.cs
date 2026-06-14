using System;

namespace Microsoft.ClearScript.V8;

[Flags]
public enum V8RuntimeFlags
{
	None = 0,
	EnableDebugging = 1,
	EnableRemoteDebugging = 2,
	EnableDynamicModuleImports = 4
}
