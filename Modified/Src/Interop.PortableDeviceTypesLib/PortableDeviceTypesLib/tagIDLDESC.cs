using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct tagIDLDESC
{
	[ComAliasName("PortableDeviceTypesLib.ULONG_PTR")]
	public uint dwReserved;

	public ushort wIDLFlags;
}
