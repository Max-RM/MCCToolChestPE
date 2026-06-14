using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.ConfigData;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controllers;

public class SkullImageManager
{
	private static ImageUtils PK3GmbRyVf;

	private static ImageList Ag7Gn3F2Gu;

	private static Dictionary<string, MobImageData> dogGlNdDdN;

	public static ImageList SkullImages
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (Ag7Gn3F2Gu == null)
			{
				Init();
			}
			return Ag7Gn3F2Gu;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Ag7Gn3F2Gu = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static Dictionary<string, MobImageData> zGpGq0Tb12()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (dogGlNdDdN == null)
		{
			Init();
		}
		return dogGlNdDdN;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static void n8xGKWng3K(Dictionary<string, MobImageData> value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dogGlNdDdN = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Init()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ag7Gn3F2Gu = new ImageList();
		Ag7Gn3F2Gu.ColorDepth = ColorDepth.Depth32Bit;
		Ag7Gn3F2Gu.TransparentColor = Color.Transparent;
		Ag7Gn3F2Gu.ImageSize = new Size(64, 64);
		dogGlNdDdN = new Dictionary<string, MobImageData>();
		string text = AppDomain.CurrentDomain.BaseDirectory + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9642);
		string text2 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9998);
		RZ4GirxArN(text2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void RZ4GirxArN(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!File.Exists(P_0))
		{
			return;
		}
		Image image = Image.FromFile(P_0);
		foreach (MobImageData skullImage in SkullImagesDefinition.skullImages)
		{
			skullImage.Image = DDPGsIpsuD(skullImage.ImageId, image);
			Ag7Gn3F2Gu.Images.Add(skullImage.Name, skullImage.Image);
			dogGlNdDdN.Add(skullImage.Name, skullImage);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Image DDPGsIpsuD(int P_0, Image P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int x = 0;
		int y = P_0 * 64;
		Bitmap bitmap = new Bitmap(64, 64);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(P_1, new Rectangle(0, 0, 64, 64), new Rectangle(x, y, 64, 64), GraphicsUnit.Pixel);
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SkullImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SkullImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		PK3GmbRyVf = new ImageUtils();
		Ag7Gn3F2Gu = null;
		dogGlNdDdN = null;
	}
}
