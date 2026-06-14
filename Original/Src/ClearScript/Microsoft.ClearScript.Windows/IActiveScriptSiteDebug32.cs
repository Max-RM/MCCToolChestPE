using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c11-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptSiteDebug32
{
	void GetDocumentContextFromPosition([In] uint sourceContext, [In] uint offset, [In] uint length, [MarshalAs(UnmanagedType.Interface)] out IDebugDocumentContext context);

	void GetApplication([MarshalAs(UnmanagedType.Interface)] out IDebugApplication32 application);

	void GetRootApplicationNode([MarshalAs(UnmanagedType.Interface)] out IDebugApplicationNode node);

	void OnScriptErrorDebug([In][MarshalAs(UnmanagedType.Interface)] IActiveScriptErrorDebug errorDebug, [MarshalAs(UnmanagedType.Bool)] out bool enterDebugger, [MarshalAs(UnmanagedType.Bool)] out bool callOnScriptErrorWhenContinuing);
}
