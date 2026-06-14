using System;

namespace Substrate;

[Flags]
public enum TripwireState
{
	UNDER_OBJECT = 1,
	ACTIVATED = 4
}
