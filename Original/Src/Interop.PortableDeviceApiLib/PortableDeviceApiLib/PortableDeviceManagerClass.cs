using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[ClassInterface(0)]
[TypeLibType(2)]
[Guid("0AF10CEC-2ECD-4B92-9581-34F6AE0637F3")]
public class PortableDeviceManagerClass : IPortableDeviceManager, PortableDeviceManager
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetDevices([In][Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs, [In][Out] ref uint pcPnPDeviceIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void RefreshDeviceList();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetDeviceFriendlyName([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][Out] ref ushort pDeviceFriendlyName, [In][Out] ref uint pcchDeviceFriendlyName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetDeviceDescription([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][Out] ref ushort pDeviceDescription, [In][Out] ref uint pcchDeviceDescription);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetDeviceManufacturer([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][Out] ref ushort pDeviceManufacturer, [In][Out] ref uint pcchDeviceManufacturer);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetDeviceProperty([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][MarshalAs(UnmanagedType.LPWStr)] string pszDevicePropertyName, [In][Out] ref byte pData, [In][Out] ref uint pcbData, [In][Out] ref uint pdwType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetPrivateDevices([In][Out][MarshalAs(UnmanagedType.LPWStr)] ref string pPnPDeviceIDs, [In][Out] ref uint pcPnPDeviceIDs);
}
