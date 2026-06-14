using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[CompilerGenerated]
[TypeIdentifier]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("6A96ED84-7C73-4480-9938-BF5AF477D426")]
public interface IPortableDeviceContent
{
	void EnumObjects([In] uint dwFlags, [In][MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pFilter, [MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppenum);

	void Properties([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceProperties ppProperties);

	void Transfer([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceResources ppResources);

	void _VtblGap1_1();

	void CreateObjectWithPropertiesAndData([In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues, [MarshalAs(UnmanagedType.Interface)] out IStream ppData, [In][Out] ref uint pdwOptimalWriteBufferSize, [In][Out][MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);

	void Delete([In] uint dwOptions, [In][MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs, [In][Out][MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);
}
