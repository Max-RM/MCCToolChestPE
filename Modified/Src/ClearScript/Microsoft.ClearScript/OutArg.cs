using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class OutArg<T> : ByRefArg<T>, IOutArg, IByRefArg
{
	public OutArg(HostVariable<T> target)
		: base(target)
	{
	}

	public OutArg(T initValue)
		: this(new HostVariable<T>(initValue))
	{
	}

	public override string ToString()
	{
		return MiscHelpers.FormatInvariant("out {0}", Type.GetFriendlyName());
	}
}
