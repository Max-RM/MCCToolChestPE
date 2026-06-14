using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("bb722ccb-6ad2-41c6-b780-af9c03ee69f5")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptSiteDebugEx
{
	void OnCanNotJITScriptErrorDebug([In][MarshalAs(UnmanagedType.Interface)] IActiveScriptErrorDebug errorDebug, [MarshalAs(UnmanagedType.Bool)] out bool callOnScriptErrorWhenContinuing);
}
