using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[InterfaceType(1)]
[Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
public interface IPortableDevice
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Open([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pClientInfo);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SendCommand([In] uint dwFlags, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Content([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent ppContent);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Capabilities([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceCapabilities ppCapabilities);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Cancel();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Close();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Advise([In] uint dwFlags, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceEventCallback pCallback, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Unadvise([In][MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetPnPDeviceID([MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
}
