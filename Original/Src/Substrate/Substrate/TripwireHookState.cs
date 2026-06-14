using System;

namespace Substrate;

[Flags]
public enum TripwireHookState
{
	READY = 4,
	ACTIVATED = 8
}
