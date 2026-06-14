using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[ComConversionLoss]
[InterfaceType(1)]
[Guid("B32F4002-BB27-45FF-AF4F-06631C1E8DAD")]
public interface IWpdSerializer
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetIPortableDeviceValuesFromBuffer([In] ref byte pBuffer, [In] uint dwInputBufferLength, [MarshalAs(UnmanagedType.Interface)] out PortableDeviceValues ppParams);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void WriteIPortableDeviceValuesToBuffer([In] uint dwOutputBufferLength, [In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValues pResults, out byte pBuffer, out uint pdwBytesWritten);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetBufferFromIPortableDeviceValues([In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValues pSource, [Out] IntPtr ppBuffer, out uint pdwBufferSize);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSerializedSize([In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValues pSource, out uint pdwSize);
}
