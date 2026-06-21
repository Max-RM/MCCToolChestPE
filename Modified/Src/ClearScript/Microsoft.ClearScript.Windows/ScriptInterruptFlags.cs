using System;

namespace Microsoft.ClearScript.Windows;

[Flags]
internal enum ScriptInterruptFlags : uint
{
	None = 0u,
	Debug = 1u,
	RaiseException = 2u
}
