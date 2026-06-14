using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagCLIPDATA
{
	public uint cbSize;

	public int ulClipFmt;

	[ComConversionLoss]
	public IntPtr pClipData;
}
