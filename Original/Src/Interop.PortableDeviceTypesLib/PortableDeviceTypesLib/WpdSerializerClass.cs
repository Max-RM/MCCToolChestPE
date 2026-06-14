using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[Guid("0B91A74B-AD7C-4A9D-B563-29EEF9167172")]
[ClassInterface(0)]
[TypeLibType(2)]
[ComConversionLoss]
public class WpdSerializerClass : IWpdSerializer, WpdSerializer
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetIPortableDeviceValuesFromBuffer([In] ref byte pBuffer, [In] uint dwInputBufferLength, [MarshalAs(UnmanagedType.Interface)] out PortableDeviceValues ppParams);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void WriteIPortableDeviceValuesToBuffer([In] uint dwOutputBufferLength, [In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValues pResults, out byte pBuffer, out uint pdwBytesWritten);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetBufferFromIPortableDeviceValues([In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValues pSource, [Out] IntPtr ppBuffer, out uint pdwBufferSize);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetSerializedSize([In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValues pSource, out uint pdwSize);
}
