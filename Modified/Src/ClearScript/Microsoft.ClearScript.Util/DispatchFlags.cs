using System;

namespace Microsoft.ClearScript.Util;

[Flags]
internal enum DispatchFlags : ushort
{
	Method = 1,
	PropertyGet = 2,
	PropertyPut = 4,
	PropertyPutRef = 8,
	Construct = 0x4000
}
