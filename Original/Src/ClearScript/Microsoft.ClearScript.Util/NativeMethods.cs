using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal static class NativeMethods
{
	[DllImport("kernel32", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr LoadLibraryW([In][MarshalAs(UnmanagedType.LPWStr)] string path);

	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FreeLibrary([In] IntPtr hLibrary);

	[DllImport("ole32.dll", ExactSpelling = true)]
	public static extern uint CLSIDFromProgID([In][MarshalAs(UnmanagedType.LPWStr)] string progID, out Guid clsid);

	[DllImport("ole32.dll", ExactSpelling = true)]
	public static extern uint CoCreateInstance([In] ref Guid clsid, [In] IntPtr pOuter, [In] uint clsContext, [In] ref Guid iid, out IntPtr pInterface);

	[DllImport("oleaut32.dll", ExactSpelling = true)]
	public static extern void VariantInit([In] IntPtr pVariant);

	[DllImport("oleaut32.dll", ExactSpelling = true)]
	public static extern uint VariantClear([In] IntPtr pVariant);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr HeapCreate([In] uint options, [In] UIntPtr initialSize, [In] UIntPtr maximumSize);

	[DllImport("kernel32.dll")]
	public static extern IntPtr HeapAlloc([In] IntPtr hHeap, [In] uint flags, [In] UIntPtr size);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool HeapFree([In] IntPtr hHeap, [In] uint flags, [In] IntPtr pBlock);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool HeapDestroy([In] IntPtr hHeap);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool VirtualProtect([In] IntPtr pBlock, [In] UIntPtr size, [In] uint newProtect, out uint oldProtect);

	[DllImport("kernel32.dll")]
	public static extern void GetSystemInfo(out SystemInfo info);

	[DllImport("kernel32.dll")]
	public static extern void GetNativeSystemInfo(out SystemInfo info);
}
