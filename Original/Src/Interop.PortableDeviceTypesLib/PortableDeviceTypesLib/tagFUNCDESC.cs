using System;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct tagFUNCDESC
{
	public int memid;

	[ComConversionLoss]
	public IntPtr lprgscode;

	[ComConversionLoss]
	public IntPtr lprgelemdescParam;

	public tagFUNCKIND funckind;

	public tagINVOKEKIND invkind;

	public tagCALLCONV callconv;

	public short cParams;

	public short cParamsOpt;

	public short oVft;

	public short cScodes;

	public tagELEMDESC elemdescFunc;

	public ushort wFuncFlags;
}
