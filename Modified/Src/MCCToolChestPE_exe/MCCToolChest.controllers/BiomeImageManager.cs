using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controllers;

public class BiomeImageManager
{
	private static ImageList v6YxbKuC5;

	public static ImageList BiomeImages
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (v6YxbKuC5 == null)
			{
				lCaXrI1Su();
			}
			return v6YxbKuC5;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			v6YxbKuC5 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void lCaXrI1Su()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		v6YxbKuC5 = new ImageList();
		v6YxbKuC5.ColorDepth = ColorDepth.Depth32Bit;
		v6YxbKuC5.TransparentColor = Color.Transparent;
		v6YxbKuC5.ImageSize = new Size(25, 25);
		foreach (Biome value in BiomeLookup.bedrockId.Values)
		{
			Bitmap image = new Bitmap(25, 25);
			using (Graphics graphics = Graphics.FromImage(image))
			{
				using SolidBrush brush = new SolidBrush(Color.FromArgb(-16777216 + (int)value.Color));
				graphics.FillRectangle(brush, 0, 0, 25, 25);
			}
			v6YxbKuC5.Images.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634) + value.BedrockId, image);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BiomeImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
