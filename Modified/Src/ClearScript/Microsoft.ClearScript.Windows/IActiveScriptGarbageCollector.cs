using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("6aa2c4a0-2b53-11d4-a2a0-00104bd35090")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IActiveScriptGarbageCollector
{
	void CollectGarbage([In] ScriptGCType type);
}
