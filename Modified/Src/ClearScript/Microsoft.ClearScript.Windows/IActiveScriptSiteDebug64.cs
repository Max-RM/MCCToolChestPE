using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("d6b96b0a-7463-402c-92ac-89984226942f")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptSiteDebug64
{
	void GetDocumentContextFromPosition([In] ulong sourceContext, [In] uint offset, [In] uint length, [MarshalAs(UnmanagedType.Interface)] out IDebugDocumentContext context);

	void GetApplication([MarshalAs(UnmanagedType.Interface)] out IDebugApplication64 application);

	void GetRootApplicationNode([MarshalAs(UnmanagedType.Interface)] out IDebugApplicationNode node);

	void OnScriptErrorDebug([In][MarshalAs(UnmanagedType.Interface)] IActiveScriptErrorDebug errorDebug, [MarshalAs(UnmanagedType.Bool)] out bool enterDebugger, [MarshalAs(UnmanagedType.Bool)] out bool callOnScriptErrorWhenContinuing);
}
