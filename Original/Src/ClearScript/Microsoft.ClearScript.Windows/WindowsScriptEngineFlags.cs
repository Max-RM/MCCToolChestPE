using System;

namespace Microsoft.ClearScript.Windows;

[Flags]
public enum WindowsScriptEngineFlags
{
	None = 0,
	EnableDebugging = 1,
	EnableJITDebugging = 2,
	DisableSourceManagement = 4,
	EnableStandardsMode = 8,
	MarshalNullAsDispatch = 0x10,
	MarshalDecimalAsCurrency = 0x20,
	MarshalArraysByValue = 0x40,
	DoNotEnableVTablePatching = 0x80
}
