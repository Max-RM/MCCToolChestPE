using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagCAUH
{
	public uint cElems;

	[ComConversionLoss]
	public IntPtr pElems;
}
