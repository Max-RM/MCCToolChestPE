using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("539698a0-cdca-11cf-a5eb-00aa0047a063")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptSiteInterruptPoll
{
	[PreserveSig]
	uint QueryContinue();
}
