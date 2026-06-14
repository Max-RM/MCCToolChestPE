using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using jWBDofdcGMieH0qfdS;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace HaI2p2xMqxTADue2UA;

internal class Jlxk34F1xl7DbN5CrR
{
	private static ImageUtils K6XSmQBBoV;

	private static ImageList BCOSnDiwmQ;

	private static ImageList AOESlpwcAx;

	private static ImageList d4sS2R3kjG;

	private static Dictionary<string, jLK03d0ZSlci2XsVe6> hjVSytlIY5;

	private static Dictionary<string, jLK03d0ZSlci2XsVe6> ocnS0QJyT8;

	private static Dictionary<string, jLK03d0ZSlci2XsVe6> d85SBVEUY2;

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public static ImageList fSYSfLeSaU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (BCOSnDiwmQ == null)
		{
			LmcSG4kM0t();
		}
		return BCOSnDiwmQ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public static void jCOSigXhFo(ImageList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BCOSnDiwmQ = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static Dictionary<string, jLK03d0ZSlci2XsVe6> B95SqDoBaf()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (hjVSytlIY5 == null)
		{
			LmcSG4kM0t();
		}
		return hjVSytlIY5;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal static void l1aSKPLPxu(Dictionary<string, jLK03d0ZSlci2XsVe6> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hjVSytlIY5 = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LmcSG4kM0t()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hjVSytlIY5 = new Dictionary<string, jLK03d0ZSlci2XsVe6>();
		BCOSnDiwmQ = new ImageList();
		BCOSnDiwmQ.ColorDepth = ColorDepth.Depth32Bit;
		BCOSnDiwmQ.TransparentColor = Color.Transparent;
		BCOSnDiwmQ.ImageSize = new Size(32, 32);
		string text = AppDomain.CurrentDomain.BaseDirectory + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9642);
		string text2 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9722);
		string text3 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9746);
		DoFSbohqCO(text3, text2, true);
		string text4 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9770);
		string text5 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9792);
		DoFSbohqCO(text5, text4, false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void DoFSbohqCO(string P_0, string P_1, bool P_2)
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
			jLK03d0ZSlci2XsVe6 jLK03d0ZSlci2XsVe7 = WcySvMoiFP(text, num, image, P_2);
			if (jLK03d0ZSlci2XsVe7 != null)
			{
				string key = jLK03d0ZSlci2XsVe7.Name;
				if (!hjVSytlIY5.ContainsKey(key))
				{
					Image image2 = jLK03d0ZSlci2XsVe7.zpZdYKFdC();
					BCOSnDiwmQ.Images.Add(key, image2);
					hjVSytlIY5.Add(key, jLK03d0ZSlci2XsVe7);
				}
			}
			num++;
		}
		streamReader.Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static jLK03d0ZSlci2XsVe6 WcySvMoiFP(string P_0, int P_1, Image P_2, bool P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = P_0.Split(',');
		jLK03d0ZSlci2XsVe6 jLK03d0ZSlci2XsVe7 = null;
		fC9SVLIR9R(array[0]);
		jLK03d0ZSlci2XsVe7 = new jLK03d0ZSlci2XsVe6();
		jLK03d0ZSlci2XsVe7.Name = array[0];
		int result = 0;
		int.TryParse(array[1], out result);
		if (array.Length == 3)
		{
			jLK03d0ZSlci2XsVe7.Damage = (short)result;
		}
		if (array.Length == 2)
		{
			jLK03d0ZSlci2XsVe7.Description = array[1];
		}
		else
		{
			jLK03d0ZSlci2XsVe7.Description = array[2];
		}
		jLK03d0ZSlci2XsVe7.rLdHdywf9(f8BS4U7JJt(P_1, P_2));
		return jLK03d0ZSlci2XsVe7;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int E6oSwXuVDe(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 >= 256)
		{
			return (P_0 - 255) * -1;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Image f8BS4U7JJt(int P_0, Image P_1)
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
	private static int fC9SVLIR9R(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(P_0, out var result);
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Image zNmSWSvkA8(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image result = null;
		if (B95SqDoBaf().ContainsKey(P_0))
		{
			result = hjVSytlIY5[P_0].zpZdYKFdC();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Image YOTSpprXb7(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image result = null;
		string key = P_0.ToString();
		string key2 = P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9814) + P_1;
		if (B95SqDoBaf().ContainsKey(key2))
		{
			result = hjVSytlIY5[key2].zpZdYKFdC();
		}
		else if (B95SqDoBaf().ContainsKey(key))
		{
			result = hjVSytlIY5[key].zpZdYKFdC();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool uMFSZdMM4C(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string key = P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9814) + P_1;
		return hjVSytlIY5.ContainsKey(key);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Jlxk34F1xl7DbN5CrR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Jlxk34F1xl7DbN5CrR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		K6XSmQBBoV = new ImageUtils();
		BCOSnDiwmQ = null;
		AOESlpwcAx = null;
		d4sS2R3kjG = null;
		hjVSytlIY5 = null;
		ocnS0QJyT8 = null;
		d85SBVEUY2 = null;
	}
}
