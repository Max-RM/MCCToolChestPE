using System;

namespace Microsoft.ClearScript.Windows;

[Flags]
internal enum SourceTextAttrs : ushort
{
	None = 0,
	Keyword = 1,
	Comment = 2,
	NonSource = 4,
	Operator = 8,
	Number = 0x10,
	String = 0x20,
	FunctionStart = 0x40
}
