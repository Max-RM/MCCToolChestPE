using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class FlatWorld
{
	public static string layersTemplate;

	public static string javaLayersTemplate;

	public int biome_id;

	public FlatWorldBlockLayer[] block_layers;

	public int encoding_version;

	public string structure_options;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ToBedrock()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		FlatWorldBlockLayer[] source = block_layers;
		source = source.Reverse().ToArray();
		FlatWorldBlockLayer[] array = source;
		foreach (FlatWorldBlockLayer flatWorldBlockLayer in array)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			stringBuilder.Append(flatWorldBlockLayer.ToString());
		}
		return string.Format(layersTemplate, biome_id, stringBuilder.ToString());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ToJava()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		FlatWorldBlockLayer[] array = block_layers;
		foreach (FlatWorldBlockLayer flatWorldBlockLayer in array)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			if (flatWorldBlockLayer.count > 1)
			{
				stringBuilder.Append(flatWorldBlockLayer.count + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10366) + flatWorldBlockLayer.block_name);
			}
			else
			{
				stringBuilder.Append(flatWorldBlockLayer.block_name);
			}
		}
		return string.Format(javaLayersTemplate, 3, stringBuilder.ToString(), biome_id);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FlatWorld()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FlatWorld()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		layersTemplate = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80856);
		javaLayersTemplate = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81056);
	}
}
