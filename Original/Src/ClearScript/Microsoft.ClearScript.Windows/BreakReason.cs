namespace Microsoft.ClearScript.Windows;

internal enum BreakReason
{
	Step,
	Breakpoint,
	DebuggerBlock,
	HostInitiated,
	LanguageInitiated,
	DebuggerHalt,
	Error,
	JIT
}
