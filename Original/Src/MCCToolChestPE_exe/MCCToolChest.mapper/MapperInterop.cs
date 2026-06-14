using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.mapper;

public class MapperInterop
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr GetRegions(string name, out IntPtr regionCount)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return NCmzqAJ7sG(name, out regionCount);
		}
		return oTQzKjEJpJ(name, out regionCount);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void freeMem(IntPtr ptr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			freeMem_64(ptr);
		}
		else
		{
			freeMem_32(ptr);
		}
	}

	[DllImport("MCMapper-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "GetRegions")]
	private static extern IntPtr NCmzqAJ7sG(string P_0, out IntPtr P_1);

	[DllImport("MCMapper-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "GetRegions")]
	private static extern IntPtr oTQzKjEJpJ(string P_0, out IntPtr P_1);

	[DllImport("MCMapper-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "FreeMem")]
	public static extern void freeMem_64(IntPtr ptr);

	[DllImport("MCMapper-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "FreeMem")]
	public static extern void freeMem_32(IntPtr ptr);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapperInterop()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
