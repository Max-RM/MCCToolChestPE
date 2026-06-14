using System;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagBLOB
{
	public uint cbSize;

	[ComConversionLoss]
	public IntPtr pBlobData;
}
