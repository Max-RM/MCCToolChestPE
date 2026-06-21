using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct _wireSAFEARR_VARIANT
{
	public uint Size;

	[ComConversionLoss]
	public IntPtr aVariant;
}
