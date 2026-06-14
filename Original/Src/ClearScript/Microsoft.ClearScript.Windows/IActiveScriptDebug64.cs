using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("bc437e23-f5b8-47f4-bb79-7d1ce5483b86")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptDebug64
{
	void GetScriptTextAttributes([In][MarshalAs(UnmanagedType.LPWStr)] string code, [In] uint length, [In][MarshalAs(UnmanagedType.LPWStr)] string delimiter, [In] ScriptTextFlags flags, [In] IntPtr pAttrs);

	void GetScriptletTextAttributes([In][MarshalAs(UnmanagedType.LPWStr)] string code, [In] uint length, [In][MarshalAs(UnmanagedType.LPWStr)] string delimiter, [In] ScriptTextFlags flags, [In] IntPtr pAttrs);

	void EnumCodeContextsOfPosition([In] ulong sourceContext, [In] uint offset, [In] uint length, [MarshalAs(UnmanagedType.Interface)] out IEnumDebugCodeContexts enumContexts);
}
