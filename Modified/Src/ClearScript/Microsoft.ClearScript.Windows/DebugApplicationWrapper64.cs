namespace Microsoft.ClearScript.Windows;

internal sealed class DebugApplicationWrapper64 : DebugApplicationWrapper
{
	private readonly IDebugApplication64 debugApplication;

	public DebugApplicationWrapper64(IDebugApplication64 debugApplication)
	{
		this.debugApplication = debugApplication;
	}

	public static IDebugApplication64 Unwrap(DebugApplicationWrapper wrapper)
	{
		if (!(wrapper is DebugApplicationWrapper64 debugApplicationWrapper))
		{
			return null;
		}
		return debugApplicationWrapper.debugApplication;
	}

	public override void SetName(string name)
	{
		debugApplication.SetName(name);
	}

	public override void GetRootNode(out IDebugApplicationNode node)
	{
		debugApplication.GetRootNode(out node);
	}

	public override void CreateApplicationNode(out IDebugApplicationNode node)
	{
		debugApplication.CreateApplicationNode(out node);
	}

	public override uint GetDebugger(out IApplicationDebugger debugger)
	{
		return debugApplication.GetDebugger(out debugger);
	}

	public override void Close()
	{
		debugApplication.Close();
	}
}
