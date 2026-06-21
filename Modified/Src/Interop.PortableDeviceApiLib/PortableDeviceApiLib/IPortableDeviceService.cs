using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("D3BD3A44-D7B5-40A9-98B7-2FA4D01DEC08")]
[InterfaceType(1)]
public interface IPortableDeviceService
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Open([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pClientInfo);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Capabilities([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceCapabilities ppCapabilities);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Content([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent2 ppContent);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Methods([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceMethods ppMethods);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Cancel();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Close();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetServiceObjectID([MarshalAs(UnmanagedType.LPWStr)] out string ppszServiceObjectID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetPnPServiceID([MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPServiceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Advise([In] uint dwFlags, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceEventCallback pCallback, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Unadvise([In][MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SendCommand([In] uint dwFlags, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);
}
