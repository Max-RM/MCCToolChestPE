using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[TypeIdentifier]
[CompilerGenerated]
[Guid("7F6D695C-03DF-4439-A809-59266BEEE3A6")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IPortableDeviceProperties
{
	void GetSupportedProperties([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

	void _VtblGap1_1();

	void GetValues([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);
}
