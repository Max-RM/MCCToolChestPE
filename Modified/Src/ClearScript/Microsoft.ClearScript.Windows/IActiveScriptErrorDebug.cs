using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c12-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptErrorDebug
{
	void GetExceptionInfo(out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo);

	void GetSourcePosition(out uint sourceContext, out uint lineNumber, out int position);

	void GetSourceLineText([MarshalAs(UnmanagedType.BStr)] out string sourceLine);
}
