using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class RefArg<T> : ByRefArg<T>, IRefArg, IByRefArg
{
	public RefArg(HostVariable<T> target)
		: base(target)
	{
	}

	public RefArg(T initValue)
		: this(new HostVariable<T>(initValue))
	{
	}

	public override string ToString()
	{
		return MiscHelpers.FormatInvariant("ref {0}", Type.GetFriendlyName());
	}
}
