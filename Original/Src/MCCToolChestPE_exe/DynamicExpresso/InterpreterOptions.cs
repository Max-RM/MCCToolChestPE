using System;

namespace DynamicExpresso;

[Flags]
public enum InterpreterOptions
{
	None = 0,
	PrimitiveTypes = 1,
	SystemKeywords = 2,
	CommonTypes = 4,
	CaseInsensitive = 8,
	Default = 7,
	DefaultCaseInsensitive = 0xF
}
