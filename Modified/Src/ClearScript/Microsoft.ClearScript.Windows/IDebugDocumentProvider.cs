using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c20-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugDocumentProvider
{
	[PreserveSig]
	uint GetName([In] DocumentNameType type, [MarshalAs(UnmanagedType.BStr)] out string name);

	void GetDocumentClassId(out Guid clsid);

	void GetDocument([MarshalAs(UnmanagedType.Interface)] out IDebugDocument document);
}
