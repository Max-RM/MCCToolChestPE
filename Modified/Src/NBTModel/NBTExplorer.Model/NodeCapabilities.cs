using System;

namespace NBTExplorer.Model;

[Flags]
public enum NodeCapabilities
{
	None = 0,
	Cut = 1,
	Copy = 2,
	PasteInto = 4,
	Rename = 8,
	Edit = 0x10,
	Delete = 0x20,
	CreateTag = 0x40,
	Search = 0x80,
	Reorder = 0x100,
	Refresh = 0x200
}
