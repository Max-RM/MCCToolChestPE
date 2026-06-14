using System;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagCACLSID
{
	public uint cElems;

	[ComConversionLoss]
	public IntPtr pElems;
}
