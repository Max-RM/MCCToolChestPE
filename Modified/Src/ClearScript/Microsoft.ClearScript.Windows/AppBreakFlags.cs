using System;

namespace Microsoft.ClearScript.Windows;

[Flags]
internal enum AppBreakFlags : uint
{
	None = 0u,
	DebuggerBlock = 1u,
	DebuggerHalt = 2u,
	Step = 0x10000u,
	Nested = 0x20000u,
	SteptypeSource = 0u,
	SteptypeBytecode = 0x100000u,
	SteptypeMachine = 0x200000u,
	SteptypeMask = 0xF00000u,
	InBreakpoint = 0x80000000u
}
