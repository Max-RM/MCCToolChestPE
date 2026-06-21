using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct _wireSAFEARR_UNKNOWN
{
	public uint Size;

	[ComConversionLoss]
	public IntPtr apUnknown;
}
