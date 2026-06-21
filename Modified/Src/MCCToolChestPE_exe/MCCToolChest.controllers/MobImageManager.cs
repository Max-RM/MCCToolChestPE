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

public class MobImageManager
{
	private static ImageUtils tCeGaR5tDD;

	private static ImageList IKrGXQEe7B;

	private static Dictionary<string, MobImageData> AteGx9TN1Z;

	public static ImageList MobImages
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (IKrGXQEe7B == null)
			{
				Init();
			}
			return IKrGXQEe7B;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			IKrGXQEe7B = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static Dictionary<string, MobImageData> SOLG0vnEyp()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (AteGx9TN1Z == null)
		{
			Init();
		}
		return AteGx9TN1Z;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static void fZ1GBSKuUd(Dictionary<string, MobImageData> value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AteGx9TN1Z = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Init()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IKrGXQEe7B = new ImageList();
		IKrGXQEe7B.ColorDepth = ColorDepth.Depth32Bit;
		IKrGXQEe7B.TransparentColor = Color.Transparent;
		IKrGXQEe7B.ImageSize = new Size(32, 32);
		AteGx9TN1Z = new Dictionary<string, MobImageData>();
		string text = AppDomain.CurrentDomain.BaseDirectory + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9642);
		string text2 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10022);
		HUTG2NEwPL(text2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HUTG2NEwPL(string P_0)
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
		foreach (MobImageData mobImage in MobImagesDefinition.mobImages)
		{
			mobImage.Image = fDAGyD9KFR(mobImage.ImageId, image);
			IKrGXQEe7B.Images.Add(mobImage.Name, mobImage.Image);
			AteGx9TN1Z.Add(mobImage.Name, mobImage);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Image fDAGyD9KFR(int P_0, Image P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int x = 0;
		int y = P_0 * 32;
		Bitmap bitmap = new Bitmap(32, 32);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(P_1, new Rectangle(0, 0, 32, 32), new Rectangle(x, y, 32, 32), GraphicsUnit.Pixel);
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MobImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MobImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		tCeGaR5tDD = new ImageUtils();
		IKrGXQEe7B = null;
		AteGx9TN1Z = null;
	}
}
