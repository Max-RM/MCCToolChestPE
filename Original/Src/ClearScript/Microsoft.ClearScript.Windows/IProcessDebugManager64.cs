using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("56b9fc1c-63a9-4cc1-ac21-087d69a17fab")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IProcessDebugManager64
{
	void CreateApplication([MarshalAs(UnmanagedType.Interface)] out IDebugApplication64 application);

	void GetDefaultApplication([MarshalAs(UnmanagedType.Interface)] out IDebugApplication64 application);

	[PreserveSig]
	uint AddApplication([In][MarshalAs(UnmanagedType.Interface)] IDebugApplication64 application, out uint appCookie);

	void RemoveApplication([In] uint appCookie);

	void CreateDebugDocumentHelper([In][MarshalAs(UnmanagedType.IUnknown)] object outer, [MarshalAs(UnmanagedType.Interface)] out IDebugDocumentHelper64 helper);
}
