using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct tagTYPEDESC
{
	public __MIDL_IOleAutomationTypes_0005 DUMMYUNIONNAME;

	public ushort vt;
}
