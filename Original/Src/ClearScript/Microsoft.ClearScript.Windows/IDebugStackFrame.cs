using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c17-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugStackFrame
{
	void GetCodeContext([MarshalAs(UnmanagedType.Interface)] out IDebugCodeContext context);

	void GetDescriptionString([In][MarshalAs(UnmanagedType.Bool)] bool longString, [MarshalAs(UnmanagedType.BStr)] out string description);

	void GetLanguageString([In][MarshalAs(UnmanagedType.Bool)] bool longString, [MarshalAs(UnmanagedType.BStr)] out string language);

	void GetThread([MarshalAs(UnmanagedType.Interface)] out IDebugApplicationThread thread);

	void GetDebugProperty([MarshalAs(UnmanagedType.Interface)] out IDebugProperty property);
}
