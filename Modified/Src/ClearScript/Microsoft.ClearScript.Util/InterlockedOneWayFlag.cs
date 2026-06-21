using System.Threading;

namespace Microsoft.ClearScript.Util;

internal sealed class InterlockedOneWayFlag
{
	private int isSet;

	public bool IsSet => isSet != 0;

	public bool Set()
	{
		return Interlocked.Exchange(ref isSet, 1) == 0;
	}
}
