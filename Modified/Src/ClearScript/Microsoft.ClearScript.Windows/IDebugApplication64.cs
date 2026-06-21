using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("4dedc754-04c7-4f10-9e60-16a390fe6e62")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugApplication64
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

	void SetName([In][MarshalAs(UnmanagedType.LPWStr)] string name);

	void StepOutComplete();

	void DebugOutput([In][MarshalAs(UnmanagedType.LPWStr)] string str);

	void StartDebugSession();

	void HandleBreakPoint([In] BreakReason reason, out BreakResumeAction resumeAction);

	void Close();

	void GetBreakFlags(out AppBreakFlags flags, [MarshalAs(UnmanagedType.Interface)] out IRemoteDebugApplicationThread thread);

	void GetCurrentThread([MarshalAs(UnmanagedType.Interface)] out IDebugApplicationThread thread);

	void CreateAsyncDebugOperation([In][MarshalAs(UnmanagedType.Interface)] IDebugSyncOperation syncOperation, [MarshalAs(UnmanagedType.Interface)] out IDebugAsyncOperation asyncOperation);

	void AddStackFrameSniffer([In][MarshalAs(UnmanagedType.Interface)] IDebugStackFrameSniffer sniffer, out uint cookie);

	void RemoveStackFrameSniffer([In] uint cookie);

	[PreserveSig]
	uint QueryCurrentThreadIsDebuggerThread();

	void SynchronousCallInDebuggerThread([In][MarshalAs(UnmanagedType.Interface)] IDebugThreadCall64 call, [In] ulong param1, [In] ulong param2, [In] ulong param3);

	void CreateApplicationNode([MarshalAs(UnmanagedType.Interface)] out IDebugApplicationNode node);

	void FireDebuggerEvent([In] ref Guid iid, [In][MarshalAs(UnmanagedType.IUnknown)] object eventObject);

	void HandleRuntimeError([In][MarshalAs(UnmanagedType.Interface)] IActiveScriptErrorDebug errorDebug, [In][MarshalAs(UnmanagedType.Interface)] IActiveScriptSite scriptSite, out BreakResumeAction breakResumeAction, out ErrorResumeAction errorResumeAction, [MarshalAs(UnmanagedType.Bool)] out bool callOnScriptError);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.Bool)]
	bool FCanJitDebug();

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.Bool)]
	bool FIsAutoJitDebugEnabled();

	void AddGlobalExpressionContextProvider([In][MarshalAs(UnmanagedType.Interface)] IProvideExpressionContexts provider, out uint cookie);

	void RemoveGlobalExpressionContextProvider([In] uint cookie);
}
