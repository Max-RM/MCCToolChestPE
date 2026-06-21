using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct _wireBRECORD
{
	public uint fFlags;

	public uint clSize;

	[MarshalAs(UnmanagedType.Interface)]
	public IRecordInfo pRecInfo;

	[ComConversionLoss]
	public IntPtr pRecord;
}
