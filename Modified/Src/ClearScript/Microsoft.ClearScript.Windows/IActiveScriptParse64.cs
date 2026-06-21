using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("c7ef7658-e1ee-480e-97ea-d52cb4d76d17")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptParse64
{
	void InitNew();

	void AddScriptlet([In][MarshalAs(UnmanagedType.LPWStr)] string defaultName, [In][MarshalAs(UnmanagedType.LPWStr)] string code, [In][MarshalAs(UnmanagedType.LPWStr)] string itemName, [In][MarshalAs(UnmanagedType.LPWStr)] string subItemName, [In][MarshalAs(UnmanagedType.LPWStr)] string eventName, [In][MarshalAs(UnmanagedType.LPWStr)] string delimiter, [In] ulong sourceContext, [In] uint startingLineNumber, [In] ScriptTextFlags flags, [MarshalAs(UnmanagedType.BStr)] out string name, out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo);

	void ParseScriptText([In][MarshalAs(UnmanagedType.LPWStr)] string code, [In][MarshalAs(UnmanagedType.LPWStr)] string itemName, [In][MarshalAs(UnmanagedType.IUnknown)] object context, [In][MarshalAs(UnmanagedType.LPWStr)] string delimiter, [In] ulong sourceContext, [In] uint startingLineNumber, [In] ScriptTextFlags flags, [In] IntPtr pVarResult, out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo);
}
