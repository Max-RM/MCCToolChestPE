using System;

namespace Microsoft.ClearScript.V8;

[Flags]
public enum V8CpuProfileFlags
{
	None = 0,
	EnableSampleCollection = 1
}
