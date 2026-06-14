using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct tagIDLDESC
{
	[ComAliasName("PortableDeviceApiLib.ULONG_PTR")]
	public uint dwReserved;

	public ushort wIDLFlags;
}
