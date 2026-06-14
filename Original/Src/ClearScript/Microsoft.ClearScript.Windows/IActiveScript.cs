using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("bb1a2ae1-a4f9-11cf-8f20-00805f2cd064")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScript
{
	void SetScriptSite([In] IActiveScriptSite site);

	void GetScriptSite([In] ref Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object site);

	void SetScriptState([In] ScriptState state);

	void GetScriptState(out ScriptState state);

	void Close();

	void AddNamedItem([In][MarshalAs(UnmanagedType.LPWStr)] string name, [In] ScriptItemFlags flags);

	void AddTypeLib([In] ref Guid libid, [In] uint major, [In] uint minor, [In] ScriptTypeLibFlags flags);

	void GetScriptDispatch([In][MarshalAs(UnmanagedType.LPWStr)] string itemName, [MarshalAs(UnmanagedType.IDispatch)] out object dispatch);

	void GetCurrentScriptThreadID(out uint scriptThreadID);

	void GetScriptThreadID([In] uint win32ThreadID, out uint scriptThreadID);

	void GetScriptThreadState([In] uint scriptThreadID, out ScriptThreadState state);

	void InterruptScriptThread([In] uint scriptThreadID, [In] ref System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo, [In] ScriptInterruptFlags flags);

	void Clone([MarshalAs(UnmanagedType.Interface)] out IActiveScript script);
}
