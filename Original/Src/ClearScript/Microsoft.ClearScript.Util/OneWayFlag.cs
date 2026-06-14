namespace Microsoft.ClearScript.Util;

internal sealed class OneWayFlag
{
	private bool isSet;

	public bool IsSet => isSet;

	public bool Set()
	{
		return !MiscHelpers.Exchange(ref isSet, value: true);
	}
}
