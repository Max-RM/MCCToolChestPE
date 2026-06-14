using System;

namespace Microsoft.ClearScript.Windows;

[Flags]
internal enum ScriptTextFlags : uint
{
	None = 0u,
	DelayExecution = 1u,
	IsVisible = 2u,
	IsExpression = 0x20u,
	IsPersistent = 0x40u,
	HostManagesSource = 0x80u,
	IsXDomain = 0x100u
}
