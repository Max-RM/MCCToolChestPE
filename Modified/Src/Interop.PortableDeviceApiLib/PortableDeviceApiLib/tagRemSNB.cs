using System;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagRemSNB
{
	public uint ulCntStr;

	public uint ulCntChar;

	[ComConversionLoss]
	public IntPtr rgString;
}
