using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("b21fb2a1-5b8f-4963-8c21-21450f84ed7f")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptError64
{
	void GetExceptionInfo(out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo);

	void GetSourcePosition(out uint sourceContext, out uint lineNumber, out int position);

	void GetSourceLineText([MarshalAs(UnmanagedType.BStr)] out string sourceLine);

	void GetSourcePosition64(out ulong sourceContext, out uint lineNumber, out int position);
}
