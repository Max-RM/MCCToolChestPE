using System;

namespace Microsoft.ClearScript.Util;

[Flags]
internal enum DispatchNameFlags : uint
{
	CaseSensitive = 1u,
	Ensure = 2u,
	Implicit = 4u,
	CaseInsensitive = 8u,
	Internal = 0x10u,
	NoDynamicProperties = 0x20u
}
