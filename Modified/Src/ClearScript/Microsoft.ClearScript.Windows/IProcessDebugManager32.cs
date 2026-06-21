using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c2f-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IProcessDebugManager32
{
	void CreateApplication([MarshalAs(UnmanagedType.Interface)] out IDebugApplication32 application);

	void GetDefaultApplication([MarshalAs(UnmanagedType.Interface)] out IDebugApplication32 application);

	[PreserveSig]
	uint AddApplication([In][MarshalAs(UnmanagedType.Interface)] IDebugApplication32 application, out uint appCookie);

	void RemoveApplication([In] uint appCookie);

	void CreateDebugDocumentHelper([In][MarshalAs(UnmanagedType.IUnknown)] object outer, [MarshalAs(UnmanagedType.Interface)] out IDebugDocumentHelper32 helper);
}
