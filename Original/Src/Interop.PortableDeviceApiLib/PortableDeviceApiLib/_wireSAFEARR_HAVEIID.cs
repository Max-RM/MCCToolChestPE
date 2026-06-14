using System;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct _wireSAFEARR_HAVEIID
{
	public uint Size;

	[ComConversionLoss]
	public IntPtr apUnknown;

	public Guid iid;
}
