using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c28-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugDocumentContext
{
	void GetDocument([MarshalAs(UnmanagedType.Interface)] out IDebugDocument document);

	void EnumCodeContexts([MarshalAs(UnmanagedType.Interface)] out IEnumDebugCodeContexts enumContexts);
}
