using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct tagSAFEARRAYBOUND
{
	public uint cElements;

	public int lLbound;
}
