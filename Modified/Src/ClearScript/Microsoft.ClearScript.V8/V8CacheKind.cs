using System;

namespace Microsoft.ClearScript.V8;

public enum V8CacheKind
{
	None,
	[Obsolete("V8 no longer supports parser caching. This option is now equivalent to Code.")]
	Parser,
	Code
}
