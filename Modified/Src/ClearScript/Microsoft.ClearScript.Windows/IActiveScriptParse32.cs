using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("bb1a2ae2-a4f9-11cf-8f20-00805f2cd064")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptParse32
{
	void InitNew();

	void AddScriptlet([In][MarshalAs(UnmanagedType.LPWStr)] string defaultName, [In][MarshalAs(UnmanagedType.LPWStr)] string code, [In][MarshalAs(UnmanagedType.LPWStr)] string itemName, [In][MarshalAs(UnmanagedType.LPWStr)] string subItemName, [In][MarshalAs(UnmanagedType.LPWStr)] string eventName, [In][MarshalAs(UnmanagedType.LPWStr)] string delimiter, [In] uint sourceContext, [In] uint startingLineNumber, [In] ScriptTextFlags flags, [MarshalAs(UnmanagedType.BStr)] out string name, out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo);

	void ParseScriptText([In][MarshalAs(UnmanagedType.LPWStr)] string code, [In][MarshalAs(UnmanagedType.LPWStr)] string itemName, [In][MarshalAs(UnmanagedType.IUnknown)] object context, [In][MarshalAs(UnmanagedType.LPWStr)] string delimiter, [In] uint sourceContext, [In] uint startingLineNumber, [In] ScriptTextFlags flags, [In] IntPtr pVarResult, out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo);
}
