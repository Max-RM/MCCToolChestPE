using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("0dc38853-c1b0-4176-a984-b298361027af")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IEnumDebugStackFrames64
{
	void Next([In] uint count, out DebugStackFrameDescriptor descriptor, out uint countFetched);

	void Skip([In] uint count);

	void Reset();

	void Clone([MarshalAs(UnmanagedType.Interface)] out IEnumDebugStackFrames enumFrames);

	void Next64([In] uint count, out DebugStackFrameDescriptor64 descriptor, out uint countFetched);
}
