using System;

namespace Microsoft.ClearScript;

[Flags]
public enum DocumentAccessFlags
{
	None = 0,
	EnableFileLoading = 1,
	EnableWebLoading = 2,
	EnableAllLoading = 3,
	EnforceRelativePrefix = 4
}
