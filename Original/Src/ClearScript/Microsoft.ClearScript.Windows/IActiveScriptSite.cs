using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("db01a1e3-a42b-11cf-8f20-00805f2cd064")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptSite
{
	void GetLCID(out uint lcid);

	void GetItemInfo([In][MarshalAs(UnmanagedType.LPWStr)] string name, [In] ScriptInfoFlags mask, [In][Out] ref IntPtr pUnkItem, [In][Out] ref IntPtr pTypeInfo);

	void GetDocVersionString([MarshalAs(UnmanagedType.BStr)] out string version);

	void OnScriptTerminate([In] IntPtr pVarResult, [In] ref System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo);

	void OnStateChange([In] ScriptState state);

	void OnScriptError([In] IActiveScriptError error);

	void OnEnterScript();

	void OnLeaveScript();
}
