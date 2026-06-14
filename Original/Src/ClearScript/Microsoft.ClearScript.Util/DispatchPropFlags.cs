using System;

namespace Microsoft.ClearScript.Util;

[Flags]
internal enum DispatchPropFlags : uint
{
	CanGet = 1u,
	CannotGet = 2u,
	CanPut = 4u,
	CannotPut = 8u,
	CanPutRef = 0x10u,
	CannotPutRef = 0x20u,
	NoSideEffects = 0x40u,
	DynamicType = 0x80u,
	CanCall = 0x100u,
	CannotCall = 0x200u,
	CanConstruct = 0x400u,
	CannotConstruct = 0x800u,
	CanSourceEvents = 0x1000u,
	CannotSourceEvents = 0x2000u,
	CanAll = 0x1515u,
	CannotAll = 0x2A2Au,
	ExtraAll = 0xC0u,
	All = 0x3FFFu
}
