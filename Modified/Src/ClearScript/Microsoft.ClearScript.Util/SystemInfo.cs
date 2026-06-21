using System;

namespace Microsoft.ClearScript.Util;

internal struct SystemInfo
{
	public ushort ProcessorArchitecture;

	public ushort Reserved;

	public uint PageSize;

	public IntPtr MinimumApplicationAddress;

	public IntPtr MaximumApplicationAddress;

	public IntPtr ActiveProcessorMask;

	public uint NumberOfProcessors;

	public uint ProcessorType;

	public uint AllocationGranularity;

	public ushort ProcessorLevel;

	public ushort ProcessorRevision;
}
