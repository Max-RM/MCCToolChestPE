using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("d10f6761-83e9-11cf-8f20-00805f2cd064")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptSiteWindow
{
	void GetWindow(out IntPtr hwnd);

	void EnableModeless([In][MarshalAs(UnmanagedType.Bool)] bool enable);
}
