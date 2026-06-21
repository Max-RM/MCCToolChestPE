using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[TypeLibType(2)]
[ClassInterface(0)]
[Guid("F7C0039A-4762-488A-B4B3-760EF9A1BA9B")]
public class PortableDeviceFTMClass : IPortableDevice, PortableDeviceFTM
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Open([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pClientInfo);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SendCommand([In] uint dwFlags, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Content([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent ppContent);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Capabilities([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceCapabilities ppCapabilities);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Cancel();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Close();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Advise([In] uint dwFlags, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceEventCallback pCallback, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Unadvise([In][MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetPnPDeviceID([MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
}
