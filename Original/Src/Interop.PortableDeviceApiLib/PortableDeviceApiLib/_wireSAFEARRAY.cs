using System;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[ComConversionLoss]
public struct _wireSAFEARRAY
{
	public ushort cDims;

	public ushort fFeatures;

	public uint cbElements;

	public uint cLocks;

	public _wireSAFEARRAY_UNION uArrayStructs;

	[ComConversionLoss]
	public IntPtr rgsabound;
}
