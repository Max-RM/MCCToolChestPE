using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("4954e0d0-fbc7-11d1-8410-006008c3fbfc")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptProperty
{
	void GetProperty([In] ScriptProp property, [In] IntPtr pVarIndex, [MarshalAs(UnmanagedType.Struct)] out object value);

	void SetProperty([In] ScriptProp property, [In] IntPtr pVarIndex, [In][MarshalAs(UnmanagedType.Struct)] ref object value);
}
