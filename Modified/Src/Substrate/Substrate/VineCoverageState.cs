using System;

namespace Substrate;

[Flags]
public enum VineCoverageState
{
	TOP = 0,
	WEST = 1,
	NORTH = 2,
	EAST = 4,
	SOUTH = 8
}
