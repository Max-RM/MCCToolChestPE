using System;

namespace Microsoft.ClearScript;

internal interface IByRefArg
{
	Type Type { get; }

	object Value { get; set; }
}
