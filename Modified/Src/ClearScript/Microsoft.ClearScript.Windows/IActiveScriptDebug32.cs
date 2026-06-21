using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c10-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptDebug32
{
	void GetScriptTextAttributes([In][MarshalAs(UnmanagedType.LPWStr)] string code, [In] uint length, [In][MarshalAs(UnmanagedType.LPWStr)] string delimiter, [In] ScriptTextFlags flags, [In] IntPtr pAttrs);

	void GetScriptletTextAttributes([In][MarshalAs(UnmanagedType.LPWStr)] string code, [In] uint length, [In][MarshalAs(UnmanagedType.LPWStr)] string delimiter, [In] ScriptTextFlags flags, [In] IntPtr pAttrs);

	void EnumCodeContextsOfPosition([In] uint sourceContext, [In] uint offset, [In] uint length, [MarshalAs(UnmanagedType.Interface)] out IEnumDebugCodeContexts enumContexts);
}
