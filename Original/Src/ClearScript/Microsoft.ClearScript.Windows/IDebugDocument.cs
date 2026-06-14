using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c21-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugDocument
{
	[PreserveSig]
	uint GetName([In] DocumentNameType type, [MarshalAs(UnmanagedType.BStr)] out string name);

	void GetDocumentClassId(out Guid clsid);
}
