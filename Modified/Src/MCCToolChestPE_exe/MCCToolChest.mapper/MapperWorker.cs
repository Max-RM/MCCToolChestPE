using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.mapper;

public class MapperWorker
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] ReadRegionEntries(string name)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IntPtr regionCount;
		IntPtr regions = MapperInterop.GetRegions(name, out regionCount);
		if (regions != IntPtr.Zero)
		{
			try
			{
				byte[] array = new byte[(long)regionCount * 1036];
				Marshal.Copy(regions, array, 0, array.Length);
				return array;
			}
			finally
			{
				MapperInterop.freeMem(regions);
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapperWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
