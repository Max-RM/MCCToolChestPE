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

public class ProfessionImageManager
{
	private static ImageUtils nSuGPaooBM;

	private static ImageList ymXGR6G8O7;

	private static Dictionary<string, MobImageData> mMkGk4hEUB;

	public static ImageList ProfessionImages
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (ymXGR6G8O7 == null)
			{
				Init();
			}
			return ymXGR6G8O7;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ymXGR6G8O7 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static Dictionary<string, MobImageData> UmfGU2CYr0()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (mMkGk4hEUB == null)
		{
			Init();
		}
		return mMkGk4hEUB;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static void cBZGLVu2KE(Dictionary<string, MobImageData> value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mMkGk4hEUB = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Init()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ymXGR6G8O7 = new ImageList();
		ymXGR6G8O7.ColorDepth = ColorDepth.Depth32Bit;
		ymXGR6G8O7.TransparentColor = Color.Transparent;
		ymXGR6G8O7.ImageSize = new Size(40, 80);
		mMkGk4hEUB = new Dictionary<string, MobImageData>();
		string text = AppDomain.CurrentDomain.BaseDirectory + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9642);
		string text2 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10042);
		LmuGeFdowq(text2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void LmuGeFdowq(string P_0)
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
		foreach (MobImageData professionImage in MobImagesDefinition.professionImages)
		{
			professionImage.Image = YnPGMVTexn(professionImage.ImageId, image);
			ymXGR6G8O7.Images.Add(professionImage.Name, professionImage.Image);
			mMkGk4hEUB.Add(professionImage.Name, professionImage);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Image YnPGMVTexn(int P_0, Image P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int x = 0;
		int y = P_0 * 80;
		Bitmap bitmap = new Bitmap(40, 80);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(P_1, new Rectangle(0, 0, 40, 80), new Rectangle(x, y, 40, 80), GraphicsUnit.Pixel);
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ProfessionImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ProfessionImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		nSuGPaooBM = new ImageUtils();
		ymXGR6G8O7 = null;
		mMkGk4hEUB = null;
	}
}
