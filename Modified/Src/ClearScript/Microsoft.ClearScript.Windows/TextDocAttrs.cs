using System;

namespace Microsoft.ClearScript.Windows;

[Flags]
internal enum TextDocAttrs : uint
{
	None = 0u,
	ReadOnly = 1u
}
