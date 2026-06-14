using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("E20333C9-FD34-412D-A381-CC6F2D820DF7")]
[InterfaceType(1)]
public interface IPortableDeviceServiceMethods
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Invoke([In] ref Guid Method, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters, [In][Out][MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppResults);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void InvokeAsync([In] ref Guid Method, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceServiceMethodCallback pCallback);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Cancel([In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceServiceMethodCallback pCallback);
}
