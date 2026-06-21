using System;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagCABOOL
{
	public uint cElems;

	[ComConversionLoss]
	public IntPtr pElems;
}
