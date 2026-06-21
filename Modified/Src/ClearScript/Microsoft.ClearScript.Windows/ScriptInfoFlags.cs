using System;

namespace Microsoft.ClearScript.Windows;

[Flags]
internal enum ScriptInfoFlags : uint
{
	None = 0u,
	IUnknown = 1u,
	ITypeInfo = 2u
}
