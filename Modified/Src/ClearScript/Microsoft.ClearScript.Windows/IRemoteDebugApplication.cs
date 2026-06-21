using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c30-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IRemoteDebugApplication
{
	void ResumeFromBreakPoint([In][MarshalAs(UnmanagedType.Interface)] IRemoteDebugApplicationThread thread, [In] BreakResumeAction breakResumeAction, [In] ErrorResumeAction errorResumeAction);

	void CauseBreak();

	void ConnectDebugger([In][MarshalAs(UnmanagedType.Interface)] IApplicationDebugger debugger);

	void DisconnectDebugger();

	[PreserveSig]
	uint GetDebugger([MarshalAs(UnmanagedType.Interface)] out IApplicationDebugger debugger);

	void CreateInstanceAtApplication([In] ref Guid clsid, [In][MarshalAs(UnmanagedType.IUnknown)] object outer, [In] uint clsContext, [In] ref Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object instance);

	void QueryAlive();

	void EnumThreads([MarshalAs(UnmanagedType.Interface)] out IEnumRemoteDebugApplicationThreads enumThreads);

	void GetName([MarshalAs(UnmanagedType.BStr)] out string name);

	void GetRootNode([MarshalAs(UnmanagedType.Interface)] out IDebugApplicationNode node);

	void EnumGlobalExpressionContexts([MarshalAs(UnmanagedType.Interface)] out IEnumDebugExpressionContexts enumContexts);
}
