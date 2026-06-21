using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c13-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugCodeContext
{
	void GetDocumentContext([MarshalAs(UnmanagedType.Interface)] out IDebugDocumentContext context);

	void SetBreakPoint([In] BreakpointState state);
}
