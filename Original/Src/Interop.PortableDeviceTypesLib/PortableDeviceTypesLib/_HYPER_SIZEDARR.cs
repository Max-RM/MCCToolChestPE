using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct _HYPER_SIZEDARR
{
	public uint clSize;

	[ComConversionLoss]
	public IntPtr pData;
}
