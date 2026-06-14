using System;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct _wireSAFEARR_BRECORD
{
	public uint Size;

	[ComConversionLoss]
	public IntPtr aRecord;
}
