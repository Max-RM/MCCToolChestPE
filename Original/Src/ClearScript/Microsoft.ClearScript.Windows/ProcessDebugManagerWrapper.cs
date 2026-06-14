using System;

namespace Microsoft.ClearScript.Windows;

internal abstract class ProcessDebugManagerWrapper
{
	public static bool TryCreate(out ProcessDebugManagerWrapper wrapper)
	{
		if (Environment.Is64BitProcess)
		{
			return ProcessDebugManagerWrapper64.TryCreate(out wrapper);
		}
		return ProcessDebugManagerWrapper32.TryCreate(out wrapper);
	}

	public abstract void CreateApplication(out DebugApplicationWrapper applicationWrapper);

	public abstract bool TryAddApplication(DebugApplicationWrapper applicationWrapper, out uint cookie);

	public abstract void RemoveApplication(uint cookie);
}
