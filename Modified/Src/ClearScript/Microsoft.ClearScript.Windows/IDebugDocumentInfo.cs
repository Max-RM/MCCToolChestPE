using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c1f-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugDocumentInfo
{
	[PreserveSig]
	uint GetName([In] DocumentNameType type, [MarshalAs(UnmanagedType.BStr)] out string name);

	void GetDocumentClassId(out Guid clsid);
}
