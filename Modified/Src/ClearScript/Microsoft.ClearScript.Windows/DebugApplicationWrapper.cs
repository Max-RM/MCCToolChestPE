namespace Microsoft.ClearScript.Windows;

internal abstract class DebugApplicationWrapper
{
	public static DebugApplicationWrapper Create(IDebugApplication64 debugApplication)
	{
		return new DebugApplicationWrapper64(debugApplication);
	}

	public static DebugApplicationWrapper Create(IDebugApplication32 debugApplication)
	{
		return new DebugApplicationWrapper32(debugApplication);
	}

	public abstract void SetName(string name);

	public abstract void GetRootNode(out IDebugApplicationNode node);

	public abstract void CreateApplicationNode(out IDebugApplicationNode node);

	public abstract uint GetDebugger(out IApplicationDebugger debugger);

	public abstract void Close();
}
