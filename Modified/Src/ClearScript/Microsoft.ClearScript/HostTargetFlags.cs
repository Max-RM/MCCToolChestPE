using System;

namespace Microsoft.ClearScript;

[Flags]
internal enum HostTargetFlags
{
	None = 0,
	AllowStaticMembers = 1,
	AllowInstanceMembers = 2,
	AllowExtensionMethods = 4
}
