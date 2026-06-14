using System;

namespace Substrate.Nbt;

[Flags]
public enum SchemaOptions
{
	OPTIONAL = 1,
	CREATE_ON_MISSING = 2
}
