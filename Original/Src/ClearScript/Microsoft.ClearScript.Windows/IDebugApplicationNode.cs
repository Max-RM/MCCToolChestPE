using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c34-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugApplicationNode
{
	[PreserveSig]
	uint GetName([In] DocumentNameType type, [MarshalAs(UnmanagedType.BStr)] out string name);

	void GetDocumentClassId(out Guid clsid);

	void GetDocument([MarshalAs(UnmanagedType.Interface)] out IDebugDocument document);

	void EnumChildren([MarshalAs(UnmanagedType.Interface)] out IEnumDebugApplicationNodes enumNodes);

	void GetParent([MarshalAs(UnmanagedType.Interface)] out IDebugApplicationNode node);

	void SetDocumentProvider([In][MarshalAs(UnmanagedType.Interface)] IDebugDocumentProvider provider);

	void Close();

	void Attach([In][MarshalAs(UnmanagedType.Interface)] IDebugApplicationNode node);

	void Detach();
}
