using System;

namespace Substrate;

[Flags]
public enum LeafState
{
	PERMANENT = 4,
	DECAY_CHECK = 8
}
