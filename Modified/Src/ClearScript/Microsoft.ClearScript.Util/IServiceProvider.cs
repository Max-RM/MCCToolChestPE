using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

[ComImport]
[Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IServiceProvider
{
	void QueryService([In] ref Guid guidService, [In] ref Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object service);
}
