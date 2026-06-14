using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c19-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugStackFrameSnifferEx32
{
	void EnumStackFrames([MarshalAs(UnmanagedType.Interface)] out IEnumDebugStackFrames enumFrames);

	void EnumStackFramesEx32([In] uint minimum, [MarshalAs(UnmanagedType.Interface)] out IEnumDebugStackFrames enumFrames);
}
