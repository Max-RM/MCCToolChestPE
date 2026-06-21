namespace Microsoft.ClearScript;

public class Undefined
{
	internal static readonly Undefined Value = new Undefined();

	private Undefined()
	{
	}

	public override string ToString()
	{
		return "[undefined]";
	}
}
