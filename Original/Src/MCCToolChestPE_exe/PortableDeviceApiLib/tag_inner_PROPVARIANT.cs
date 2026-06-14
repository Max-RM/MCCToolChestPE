using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
[TypeIdentifier("1f001332-1a57-4934-be31-affc99f4ee0a", "PortableDeviceApiLib.tag_inner_PROPVARIANT")]
[CompilerGenerated]
public struct tag_inner_PROPVARIANT
{
	public ushort vt;

	public byte wReserved1;

	public byte wReserved2;

	public uint wReserved3;

	public __MIDL___MIDL_itf_PortableDeviceApi_0001_0000_0001 __MIDL____MIDL_itf_PortableDeviceApi_0001_00000001;
}
