using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("FD8878AC-D841-4D17-891C-E6829CDB6934")]
[InterfaceType(1)]
public interface IPortableDeviceResources
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedResources([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetResourceAttributes([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResourceAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetStream([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In] ref _tagpropertykey key, [In] uint dwMode, [In][Out] ref uint pdwOptimalBufferSize, [MarshalAs(UnmanagedType.Interface)] out IStream ppStream);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Delete([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Cancel();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CreateResource([In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pResourceAttributes, [MarshalAs(UnmanagedType.Interface)] out IStream ppData, [In][Out] ref uint pdwOptimalWriteBufferSize, [In][Out][MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);
}
