using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.Windows;

internal sealed class ProcessDebugManagerWrapper64 : ProcessDebugManagerWrapper
{
	private readonly IProcessDebugManager64 processDebugManager;

	public new static bool TryCreate(out ProcessDebugManagerWrapper wrapper)
	{
		if (MiscHelpers.TryCreateCOMObject<IProcessDebugManager64>("ProcessDebugManager", null, out var obj))
		{
			wrapper = new ProcessDebugManagerWrapper64(obj);
			return true;
		}
		wrapper = null;
		return false;
	}

	private ProcessDebugManagerWrapper64(IProcessDebugManager64 processDebugManager)
	{
		this.processDebugManager = processDebugManager;
	}

	public override void CreateApplication(out DebugApplicationWrapper applicationWrapper)
	{
		processDebugManager.CreateApplication(out var application);
		applicationWrapper = DebugApplicationWrapper.Create(application);
	}

	public override bool TryAddApplication(DebugApplicationWrapper applicationWrapper, out uint cookie)
	{
		return RawCOMHelpers.HResult.Succeeded(processDebugManager.AddApplication(DebugApplicationWrapper64.Unwrap(applicationWrapper), out cookie));
	}

	public override void RemoveApplication(uint cookie)
	{
		processDebugManager.RemoveApplication(cookie);
	}
}
