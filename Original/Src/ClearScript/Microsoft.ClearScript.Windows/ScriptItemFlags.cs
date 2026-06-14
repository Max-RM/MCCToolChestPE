using System;

namespace Microsoft.ClearScript.Windows;

[Flags]
internal enum ScriptItemFlags : uint
{
	None = 0u,
	IsVisible = 2u,
	IsSource = 4u,
	GlobalMembers = 8u,
	IsPersistent = 0x40u,
	CodeOnly = 0x200u,
	NoCode = 0x400u
}
