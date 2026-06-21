using System;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Windows;

internal abstract class ActiveScriptWrapper
{
	protected class DummyEnumDebugStackFrames : IEnumDebugStackFrames
	{
		public void Next(uint count, out DebugStackFrameDescriptor descriptor, out uint countFetched)
		{
			descriptor = default(DebugStackFrameDescriptor);
			countFetched = 0u;
		}

		public void Skip(uint count)
		{
		}

		public void Reset()
		{
		}

		public void Clone(out IEnumDebugStackFrames enumFrames)
		{
			throw new NotImplementedException();
		}
	}

	public static ActiveScriptWrapper Create(string progID, WindowsScriptEngineFlags flags)
	{
		if (Environment.Is64BitProcess)
		{
			return new ActiveScriptWrapper64(progID, flags);
		}
		return new ActiveScriptWrapper32(progID, flags);
	}

	public abstract void SetScriptSite(IActiveScriptSite site);

	public abstract void SetScriptState(ScriptState state);

	public abstract void GetScriptState(out ScriptState state);

	public abstract void InitNew();

	public abstract void GetScriptDispatch(string itemName, out object dispatch);

	public abstract void AddNamedItem(string name, ScriptItemFlags flags);

	public abstract void ParseScriptText(string code, string itemName, object context, string delimiter, UIntPtr sourceContext, uint startingLineNumber, ScriptTextFlags flags, IntPtr pVarResult, out EXCEPINFO excepInfo);

	public abstract void InterruptScriptThread(uint scriptThreadID, ref EXCEPINFO excepInfo, ScriptInterruptFlags flags);

	public abstract void EnumCodeContextsOfPosition(UIntPtr sourceContext, uint offset, uint length, out IEnumDebugCodeContexts enumContexts);

	public abstract void EnumStackFrames(out IEnumDebugStackFrames enumFrames);

	public abstract void CollectGarbage(ScriptGCType type);

	public abstract void Close();
}
