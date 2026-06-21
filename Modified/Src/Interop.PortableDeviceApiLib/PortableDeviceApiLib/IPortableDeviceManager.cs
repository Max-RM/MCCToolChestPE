using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("A1567595-4C2F-4574-A6FA-ECEF917B9A40")]
[InterfaceType(1)]
public interface IPortableDeviceManager
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetDevices([In][Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs, [In][Out] ref uint pcPnPDeviceIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RefreshDeviceList();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetDeviceFriendlyName([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][Out] ref ushort pDeviceFriendlyName, [In][Out] ref uint pcchDeviceFriendlyName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetDeviceDescription([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][Out] ref ushort pDeviceDescription, [In][Out] ref uint pcchDeviceDescription);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetDeviceManufacturer([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][Out] ref ushort pDeviceManufacturer, [In][Out] ref uint pcchDeviceManufacturer);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetDeviceProperty([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][MarshalAs(UnmanagedType.LPWStr)] string pszDevicePropertyName, [In][Out] ref byte pData, [In][Out] ref uint pcbData, [In][Out] ref uint pdwType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetPrivateDevices([In][Out][MarshalAs(UnmanagedType.LPWStr)] ref string pPnPDeviceIDs, [In][Out] ref uint pcPnPDeviceIDs);
}
