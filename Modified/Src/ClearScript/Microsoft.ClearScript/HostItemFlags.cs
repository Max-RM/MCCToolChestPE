using System;

namespace Microsoft.ClearScript;

[Flags]
public enum HostItemFlags
{
	None = 0,
	GlobalMembers = 1,
	PrivateAccess = 2,
	HideDynamicMembers = 4,
	DirectAccess = 8
}
