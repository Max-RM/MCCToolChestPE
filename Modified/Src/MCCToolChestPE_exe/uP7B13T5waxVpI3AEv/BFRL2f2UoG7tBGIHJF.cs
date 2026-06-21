using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using jWBDofdcGMieH0qfdS;
using MCCToolChest.model;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace uP7B13T5waxVpI3AEv;

internal class BFRL2f2UoG7tBGIHJF
{
	private static ImageUtils HGcS3PASBu;

	private static ImageList p7WS1XSXum;

	private static Dictionary<string, jLK03d0ZSlci2XsVe6> LicSEuxVMZ;

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public static ImageList fyLSLwvej3()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (p7WS1XSXum == null)
		{
			isBStTVY0s();
		}
		return p7WS1XSXum;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public static void KR5Sg9gH5H(ImageList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		p7WS1XSXum = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static Dictionary<string, jLK03d0ZSlci2XsVe6> mAVSRPT1qd()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (LicSEuxVMZ == null)
		{
			isBStTVY0s();
		}
		return LicSEuxVMZ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static void UnKSkgMbpR(Dictionary<string, jLK03d0ZSlci2XsVe6> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LicSEuxVMZ = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void isBStTVY0s()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LicSEuxVMZ = new Dictionary<string, jLK03d0ZSlci2XsVe6>();
		p7WS1XSXum = new ImageList();
		p7WS1XSXum.ColorDepth = ColorDepth.Depth32Bit;
		p7WS1XSXum.TransparentColor = Color.Transparent;
		p7WS1XSXum.ImageSize = new Size(32, 32);
		string text = AppDomain.CurrentDomain.BaseDirectory + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9642);
		string text2 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9722);
		string text3 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9746);
		l7BSaHgRTl(text3, text2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void l7BSaHgRTl(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		if (!File.Exists(P_1) || !File.Exists(P_0))
		{
			return;
		}
		Image image = Image.FromFile(P_0);
		StreamReader streamReader = new StreamReader(P_1);
		string text;
		while ((text = streamReader.ReadLine()) != null)
		{
			jLK03d0ZSlci2XsVe6 jLK03d0ZSlci2XsVe7 = QkRSX97pHM(text, num, image);
			if (jLK03d0ZSlci2XsVe7 != null)
			{
				string key = jLK03d0ZSlci2XsVe7.Name;
				LicSEuxVMZ.ContainsKey(key);
				Image image2 = jLK03d0ZSlci2XsVe7.zpZdYKFdC();
				p7WS1XSXum.Images.Add(key, image2);
				LicSEuxVMZ.Add(key, jLK03d0ZSlci2XsVe7);
			}
			num++;
		}
		streamReader.Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static jLK03d0ZSlci2XsVe6 QkRSX97pHM(string P_0, int P_1, Image P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = P_0.Split(',');
		jLK03d0ZSlci2XsVe6 jLK03d0ZSlci2XsVe7 = null;
		ItsSeuuPW5(array[0]);
		jLK03d0ZSlci2XsVe7 = new jLK03d0ZSlci2XsVe6();
		jLK03d0ZSlci2XsVe7.Name = array[0].Trim();
		jLK03d0ZSlci2XsVe7.Description = array[1].Trim();
		jLK03d0ZSlci2XsVe7.rLdHdywf9(jgeSx52AX8(P_1, P_2));
		return jLK03d0ZSlci2XsVe7;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Image jgeSx52AX8(int P_0, Image P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int x = P_0 % 16 * 32;
		int y = P_0 / 16 * 32;
		Bitmap bitmap = new Bitmap(32, 32);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(P_1, new Rectangle(0, 0, 32, 32), new Rectangle(x, y, 32, 32), GraphicsUnit.Pixel);
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int ItsSeuuPW5(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(P_0, out var result);
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Image xRoSMGJq48(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image result = null;
		string name = BlockMaster.GetBedrockBlockState(P_0, (short)P_1).masterBlock.name;
		if (mAVSRPT1qd().ContainsKey(name))
		{
			result = LicSEuxVMZ[name].zpZdYKFdC();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Image iWMSUEyuJn(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image result = null;
		string name = BlockMaster.GetBedrockBlockState(P_0, (short)P_1).masterBlock.name;
		if (mAVSRPT1qd().ContainsKey(name))
		{
			result = LicSEuxVMZ[name].zpZdYKFdC();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BFRL2f2UoG7tBGIHJF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BFRL2f2UoG7tBGIHJF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		HGcS3PASBu = new ImageUtils();
		p7WS1XSXum = null;
		LicSEuxVMZ = null;
	}
}
