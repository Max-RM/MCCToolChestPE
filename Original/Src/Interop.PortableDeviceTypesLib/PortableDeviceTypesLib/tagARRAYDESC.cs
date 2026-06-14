using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagARRAYDESC
{
	public tagTYPEDESC tdescElem;

	public ushort cDims;

	[ComConversionLoss]
	public IntPtr rgbounds;
}
