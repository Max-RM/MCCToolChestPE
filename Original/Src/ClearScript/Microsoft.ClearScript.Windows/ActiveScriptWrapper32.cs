using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.Windows;

internal sealed class ActiveScriptWrapper32 : ActiveScriptWrapper
{
	private delegate uint RawInterruptScriptThread([In] IntPtr pThis, [In] uint scriptThreadID, [In] ref System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo, [In] ScriptInterruptFlags flags);

	private delegate uint RawEnumCodeContextsOfPosition([In] IntPtr pThis, [In] uint sourceContext, [In] uint offset, [In] uint length, [MarshalAs(UnmanagedType.Interface)] out IEnumDebugCodeContexts enumContexts);

	private IntPtr pActiveScript;

	private IntPtr pActiveScriptParse;

	private IntPtr pActiveScriptDebug;

	private IntPtr pActiveScriptGarbageCollector;

	private IntPtr pDebugStackFrameSniffer;

	private IActiveScript activeScript;

	private IActiveScriptParse32 activeScriptParse;

	private IActiveScriptDebug32 activeScriptDebug;

	private IActiveScriptGarbageCollector activeScriptGarbageCollector;

	private IDebugStackFrameSnifferEx32 debugStackFrameSniffer;

	public ActiveScriptWrapper32(string progID, WindowsScriptEngineFlags flags)
	{
		pActiveScript = RawCOMHelpers.CreateInstance<IActiveScript>(progID);
		pActiveScriptParse = RawCOMHelpers.QueryInterface<IActiveScriptParse32>(pActiveScript);
		pActiveScriptDebug = RawCOMHelpers.QueryInterface<IActiveScriptDebug32>(pActiveScript);
		pActiveScriptGarbageCollector = RawCOMHelpers.QueryInterfaceNoThrow<IActiveScriptGarbageCollector>(pActiveScript);
		pDebugStackFrameSniffer = RawCOMHelpers.QueryInterfaceNoThrow<IDebugStackFrameSnifferEx32>(pActiveScript);
		activeScript = (IActiveScript)Marshal.GetObjectForIUnknown(pActiveScript);
		activeScriptParse = (IActiveScriptParse32)activeScript;
		activeScriptDebug = (IActiveScriptDebug32)activeScript;
		activeScriptGarbageCollector = activeScript as IActiveScriptGarbageCollector;
		debugStackFrameSniffer = activeScript as IDebugStackFrameSnifferEx32;
		if (!flags.HasFlag(WindowsScriptEngineFlags.EnableStandardsMode))
		{
			return;
		}
		if (activeScript is IActiveScriptProperty activeScriptProperty)
		{
			activeScriptProperty.GetProperty(ScriptProp.Name, IntPtr.Zero, out var value);
			if (object.Equals(value, "JScript"))
			{
				object value2 = ScriptLanguageVersion.Standards;
				activeScriptProperty.SetProperty(ScriptProp.InvokeVersioning, IntPtr.Zero, ref value2);
			}
		}
		if (!flags.HasFlag(WindowsScriptEngineFlags.DoNotEnableVTablePatching) && MiscHelpers.IsX86InstructionSet())
		{
			HostItem.EnableVTablePatching = true;
		}
	}

	public override void SetScriptSite(IActiveScriptSite site)
	{
		activeScript.SetScriptSite(site);
	}

	public override void SetScriptState(ScriptState state)
	{
		activeScript.SetScriptState(state);
	}

	public override void GetScriptState(out ScriptState state)
	{
		activeScript.GetScriptState(out state);
	}

	public override void InitNew()
	{
		activeScriptParse.InitNew();
	}

	public override void GetScriptDispatch(string itemName, out object dispatch)
	{
		activeScript.GetScriptDispatch(itemName, out dispatch);
	}

	public override void AddNamedItem(string name, ScriptItemFlags flags)
	{
		activeScript.AddNamedItem(name, flags);
	}

	public override void ParseScriptText(string code, string itemName, object context, string delimiter, UIntPtr sourceContext, uint startingLineNumber, ScriptTextFlags flags, IntPtr pVarResult, out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo)
	{
		activeScriptParse.ParseScriptText(code, itemName, context, delimiter, sourceContext.ToUInt32(), startingLineNumber, flags, pVarResult, out excepInfo);
	}

	public override void InterruptScriptThread(uint scriptThreadID, ref System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo, ScriptInterruptFlags flags)
	{
		RawInterruptScriptThread methodDelegate = RawCOMHelpers.GetMethodDelegate<RawInterruptScriptThread>(pActiveScript, 14);
		methodDelegate(pActiveScript, scriptThreadID, ref excepInfo, flags);
	}

	public override void EnumCodeContextsOfPosition(UIntPtr sourceContext, uint offset, uint length, out IEnumDebugCodeContexts enumContexts)
	{
		RawEnumCodeContextsOfPosition methodDelegate = RawCOMHelpers.GetMethodDelegate<RawEnumCodeContextsOfPosition>(pActiveScriptDebug, 5);
		RawCOMHelpers.HResult.Check(methodDelegate(pActiveScriptDebug, sourceContext.ToUInt32(), offset, length, out enumContexts));
	}

	public override void EnumStackFrames(out IEnumDebugStackFrames enumFrames)
	{
		if (debugStackFrameSniffer != null)
		{
			debugStackFrameSniffer.EnumStackFrames(out enumFrames);
		}
		else
		{
			enumFrames = new DummyEnumDebugStackFrames();
		}
	}

	public override void CollectGarbage(ScriptGCType type)
	{
		if (activeScriptGarbageCollector != null)
		{
			activeScriptGarbageCollector.CollectGarbage(type);
		}
	}

	public override void Close()
	{
		debugStackFrameSniffer = null;
		activeScriptGarbageCollector = null;
		activeScriptDebug = null;
		activeScriptParse = null;
		RawCOMHelpers.ReleaseAndEmpty(ref pDebugStackFrameSniffer);
		RawCOMHelpers.ReleaseAndEmpty(ref pActiveScriptGarbageCollector);
		RawCOMHelpers.ReleaseAndEmpty(ref pActiveScriptDebug);
		RawCOMHelpers.ReleaseAndEmpty(ref pActiveScriptParse);
		RawCOMHelpers.ReleaseAndEmpty(ref pActiveScript);
		activeScript.Close();
		Marshal.FinalReleaseComObject(activeScript);
		activeScript = null;
	}
}
