using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.ConfigData;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controllers;

public class BannerImageManager
{
	private static ImageUtils V0I6OJmaq;

	private static ImageList RZZN1RnYY;

	private static Dictionary<string, BannerDefinition> sNPD2YTA7;

	private static int upbcNE26h;

	private static int yfqJMQM5P;

	public static ImageList BannerImages
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (RZZN1RnYY == null)
			{
				Init();
			}
			return RZZN1RnYY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			RZZN1RnYY = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static Dictionary<string, BannerDefinition> qajEg1seF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (sNPD2YTA7 == null)
		{
			Init();
		}
		return sNPD2YTA7;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static void dsQr5iar7(Dictionary<string, BannerDefinition> value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		sNPD2YTA7 = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Init()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RZZN1RnYY = new ImageList();
		RZZN1RnYY.ColorDepth = ColorDepth.Depth32Bit;
		RZZN1RnYY.TransparentColor = Color.Transparent;
		RZZN1RnYY.ImageSize = new Size(30, 60);
		sNPD2YTA7 = new Dictionary<string, BannerDefinition>();
		string text = AppDomain.CurrentDomain.BaseDirectory + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9642);
		string text2 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9682);
		I5wYmhg14(text2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void I5wYmhg14(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		if (!File.Exists(P_0))
		{
			return;
		}
		Image image = Image.FromFile(P_0);
		foreach (BannerDefinition bannerImage in BannerImagesDefinition.bannerImages)
		{
			try
			{
				bannerImage.Image = oRa1L1wKy(num, image);
				RZZN1RnYY.Images.Add(bannerImage.Code, io23w6uFA(num, image));
				sNPD2YTA7.Add(bannerImage.Code, bannerImage);
				num++;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Image io23w6uFA(int P_0, Image P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int x = 0;
		int y = P_0 * yfqJMQM5P;
		Bitmap bitmap = new Bitmap(30, 60);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		graphics.DrawImage(P_1, new Rectangle(0, 0, 30, 60), new Rectangle(x, y, upbcNE26h, yfqJMQM5P), GraphicsUnit.Pixel);
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Image oRa1L1wKy(int P_0, Image P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int x = 0;
		int y = P_0 * yfqJMQM5P;
		Bitmap bitmap = new Bitmap(upbcNE26h, yfqJMQM5P);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		graphics.DrawImage(P_1, new Rectangle(0, 0, upbcNE26h, yfqJMQM5P), new Rectangle(x, y, upbcNE26h, yfqJMQM5P), GraphicsUnit.Pixel);
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BannerImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BannerImageManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		V0I6OJmaq = new ImageUtils();
		RZZN1RnYY = null;
		sNPD2YTA7 = null;
		upbcNE26h = 165;
		yfqJMQM5P = 330;
	}
}
