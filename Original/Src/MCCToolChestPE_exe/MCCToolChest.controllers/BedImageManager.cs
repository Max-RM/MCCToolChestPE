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

public class BedImageManager
{
	private static ImageUtils iS8PHlBHO;

	private static ImageList jPlRwgovD;

	private static Dictionary<string, MobImageData> rrak2H5mi;

	public static ImageList BedImages
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (jPlRwgovD == null)
			{
				Init();
			}
			return jPlRwgovD;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			jPlRwgovD = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static Dictionary<string, MobImageData> xquUjmlkM()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (rrak2H5mi == null)
		{
			Init();
		}
		return rrak2H5mi;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static void H4gLYg0F8(Dictionary<string, MobImageData> value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rrak2H5mi = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Init()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		jPlRwgovD = new ImageList();
		jPlRwgovD.ColorDepth = ColorDepth.Depth32Bit;
		jPlRwgovD.TransparentColor = Color.Transparent;
		jPlRwgovD.ImageSize = new Size(64, 64);
		rrak2H5mi = new Dictionary<string, MobImageData>();
		string text = AppDomain.CurrentDomain.BaseDirectory + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9642);
		string text2 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9662);
		bKHeS2Vl3(text2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void bKHeS2Vl3(string P_0)
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
		foreach (MobImageData bedImage in BedImagesDefinition.bedImages)
		{
			bedImage.Image = plrMU40UR(bedImage.ImageId, image);
			jPlRwgovD.Images.Add(bedImage.Name, bedImage.Image);
			rrak2H5mi.Add(bedImage.Name, bedImage);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Image plrMU40UR(int P_0, Image P_1)
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
	public BedImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BedImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		iS8PHlBHO = new ImageUtils();
		jPlRwgovD = null;
		rrak2H5mi = null;
	}
}
