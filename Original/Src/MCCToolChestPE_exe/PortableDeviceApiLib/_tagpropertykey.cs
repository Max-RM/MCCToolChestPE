using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[TypeIdentifier("1f001332-1a57-4934-be31-affc99f4ee0a", "PortableDeviceApiLib._tagpropertykey")]
[CompilerGenerated]
public struct _tagpropertykey
{
	public Guid fmtid;

	public uint pid;
}
