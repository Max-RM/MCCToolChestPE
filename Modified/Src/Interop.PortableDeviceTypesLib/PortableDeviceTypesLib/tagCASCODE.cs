using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagCASCODE
{
	public uint cElems;

	[ComConversionLoss]
	public IntPtr pElems;
}
