using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("eae1ba61-a4ed-11cf-8f20-00805f2cd064")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptError
{
	void GetExceptionInfo(out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo);

	void GetSourcePosition(out uint sourceContext, out uint lineNumber, out int position);

	void GetSourceLineText([MarshalAs(UnmanagedType.BStr)] out string sourceLine);
}
