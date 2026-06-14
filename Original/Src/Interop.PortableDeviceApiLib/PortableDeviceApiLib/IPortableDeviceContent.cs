using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("6A96ED84-7C73-4480-9938-BF5AF477D426")]
[InterfaceType(1)]
public interface IPortableDeviceContent
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void EnumObjects([In] uint dwFlags, [In][MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pFilter, [MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppenum);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Properties([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceProperties ppProperties);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Transfer([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceResources ppResources);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CreateObjectWithPropertiesOnly([In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues, [In][Out][MarshalAs(UnmanagedType.LPWStr)] ref string ppszObjectID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CreateObjectWithPropertiesAndData([In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues, [MarshalAs(UnmanagedType.Interface)] out IStream ppData, [In][Out] ref uint pdwOptimalWriteBufferSize, [In][Out][MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Delete([In] uint dwOptions, [In][MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs, [In][Out][MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetObjectIDsFromPersistentUniqueIDs([In][MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pPersistentUniqueIDs, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Cancel();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Move([In][MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs, [In][MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID, [In][Out][MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Copy([In][MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs, [In][MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID, [In][Out][MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);
}
