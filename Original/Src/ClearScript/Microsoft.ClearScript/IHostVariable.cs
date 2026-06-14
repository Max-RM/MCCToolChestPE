using System;

namespace Microsoft.ClearScript;

internal interface IHostVariable
{
	Type Type { get; }

	object Value { get; set; }
}
