using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct tag_inner_PROPVARIANT
{
	public ushort vt;

	public byte wReserved1;

	public byte wReserved2;

	public uint wReserved3;

	public __MIDL___MIDL_itf_PortableDeviceTypes_0003_0015_0001 __MIDL____MIDL_itf_PortableDeviceTypes_0003_00150001;
}
