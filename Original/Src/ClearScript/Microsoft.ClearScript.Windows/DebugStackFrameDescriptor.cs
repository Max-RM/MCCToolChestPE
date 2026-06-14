using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

internal struct DebugStackFrameDescriptor
{
	[MarshalAs(UnmanagedType.Interface)]
	public IDebugStackFrame Frame;

	public uint Minimum;

	public uint Limit;

	[MarshalAs(UnmanagedType.Bool)]
	public bool IsFinal;

	public IntPtr pFinalObject;
}
