using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[TypeIdentifier]
[Guid("A1567595-4C2F-4574-A6FA-ECEF917B9A40")]
[CompilerGenerated]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IPortableDeviceManager
{
	void GetDevices([In][Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs, [In][Out] ref uint pcPnPDeviceIDs);

	void RefreshDeviceList();
}
