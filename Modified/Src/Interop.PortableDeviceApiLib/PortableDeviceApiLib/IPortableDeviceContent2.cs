using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("9B4ADD96-F6BF-4034-8708-ECA72BF10554")]
[InterfaceType(1)]
public interface IPortableDeviceContent2 : IPortableDeviceContent
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void EnumObjects([In] uint dwFlags, [In][MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pFilter, [MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppenum);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Properties([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceProperties ppProperties);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Transfer([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceResources ppResources);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void CreateObjectWithPropertiesOnly([In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues, [In][Out][MarshalAs(UnmanagedType.LPWStr)] ref string ppszObjectID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void CreateObjectWithPropertiesAndData([In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues, [MarshalAs(UnmanagedType.Interface)] out IStream ppData, [In][Out] ref uint pdwOptimalWriteBufferSize, [In][Out][MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Delete([In] uint dwOptions, [In][MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs, [In][Out][MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void GetObjectIDsFromPersistentUniqueIDs([In][MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pPersistentUniqueIDs, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Cancel();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Move([In][MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs, [In][MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID, [In][Out][MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Copy([In][MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs, [In][MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID, [In][Out][MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void UpdateObjectWithPropertiesAndData([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pProperties, [MarshalAs(UnmanagedType.Interface)] out IStream ppData, [In][Out] ref uint pdwOptimalWriteBufferSize);
}
