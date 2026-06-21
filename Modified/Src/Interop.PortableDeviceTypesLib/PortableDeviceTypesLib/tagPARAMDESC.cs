using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagPARAMDESC
{
	[ComConversionLoss]
	public IntPtr pparamdescex;

	public ushort wParamFlags;
}
