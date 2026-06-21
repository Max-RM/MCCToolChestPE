using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

internal struct DebugStackFrameDescriptor64
{
	[MarshalAs(UnmanagedType.Interface)]
	public IDebugStackFrame Frame;

	public ulong Minimum;

	public ulong Limit;

	[MarshalAs(UnmanagedType.Bool)]
	public bool IsFinal;

	public IntPtr pFinalObject;
}
