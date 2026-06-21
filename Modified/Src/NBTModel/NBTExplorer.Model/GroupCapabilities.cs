using System;

namespace NBTExplorer.Model;

[Flags]
public enum GroupCapabilities
{
	Single = 0,
	SiblingSameType = 1,
	SiblingMixedType = 3,
	MultiSameType = 5,
	MultiMixedType = 0xF,
	ElideChildren = 0x10,
	All = 0x1F
}
