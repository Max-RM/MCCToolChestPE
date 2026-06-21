namespace Microsoft.ClearScript.Util;

internal sealed class Nonexistent
{
	public static readonly Nonexistent Value = new Nonexistent();

	private Nonexistent()
	{
	}
}
