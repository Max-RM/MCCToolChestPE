using System;

namespace Microsoft.ClearScript.Windows;

[Flags]
internal enum ScriptTypeLibFlags : uint
{
	None = 0u,
	IsControl = 0x10u,
	IsPersistent = 0x40u
}
