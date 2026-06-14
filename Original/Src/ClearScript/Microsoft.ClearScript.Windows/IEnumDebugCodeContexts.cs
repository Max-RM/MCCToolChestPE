using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c1d-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IEnumDebugCodeContexts
{
	void Next([In] uint count, [MarshalAs(UnmanagedType.Interface)] out IDebugCodeContext context, out uint countFetched);

	void Skip([In] uint count);

	void Reset();

	void Clone([MarshalAs(UnmanagedType.Interface)] out IEnumDebugCodeContexts enumContexts);
}
