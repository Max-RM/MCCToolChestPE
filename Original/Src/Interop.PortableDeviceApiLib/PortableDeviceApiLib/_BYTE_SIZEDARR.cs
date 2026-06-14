using System;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct _BYTE_SIZEDARR
{
	public uint clSize;

	[ComConversionLoss]
	public IntPtr pData;
}
