using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("10ECE955-CF41-4728-BFA0-41EEDF1BBF19")]
[CompilerGenerated]
[TypeIdentifier]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IEnumPortableDeviceObjectIDs
{
	void Next([In] uint cObjects, [MarshalAs(UnmanagedType.LPWStr)] out string pObjIDs, [In][Out] ref uint pcFetched);
}
