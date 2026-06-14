using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("7F6D695C-03DF-4439-A809-59266BEEE3A6")]
[InterfaceType(1)]
public interface IPortableDeviceProperties
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedProperties([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetPropertyAttributes([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetValues([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetValues([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Delete([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Cancel();
}
