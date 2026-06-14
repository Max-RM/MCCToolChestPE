using System;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagCAUB
{
	public uint cElems;

	[ComConversionLoss]
	public IntPtr pElems;
}
