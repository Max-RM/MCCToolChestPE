using System;

namespace Substrate;

[Flags]
public enum BrewingStandState
{
	NONE = 0,
	SLOT_EAST = 1,
	SLOT_SOUTHWEST = 2,
	SLOT_NORTHWEST = 4
}
