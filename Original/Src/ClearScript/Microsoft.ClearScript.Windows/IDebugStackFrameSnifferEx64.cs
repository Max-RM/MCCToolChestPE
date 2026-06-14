using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("8cd12af4-49c1-4d52-8d8a-c146f47581aa")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugStackFrameSnifferEx64
{
	void EnumStackFrames([MarshalAs(UnmanagedType.Interface)] out IEnumDebugStackFrames enumFrames);

	void EnumStackFramesEx64([In] ulong minimum, [MarshalAs(UnmanagedType.Interface)] out IEnumDebugStackFrames enumFrames);
}
