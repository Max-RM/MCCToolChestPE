using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode.Workers;

public class MapConverterWorker
{
	private ImageUtils lCXSwTs2jgN;

	private BackgroundWorker vflSwSLxEnh;

	private int JdqSwGlfAFL;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapConverterWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		lCXSwTs2jgN = new ImageUtils();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapConverterWorker(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		lCXSwTs2jgN = new ImageUtils();
		vflSwSLxEnh = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConvertImage(int width, int height, Bitmap inImage, SortedDictionary<long, MCMap> mapList, long index, bool retainPerspective, bool interpolate)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)Math.Ceiling((decimal)width / 128m);
		int num2 = (int)Math.Ceiling((decimal)height / 128m);
		int num3 = num * 128 - width;
		int num4 = num2 * 128 - height;
		JdqSwGlfAFL = num * num2;
		Bitmap image = ((!retainPerspective) ? new Bitmap(inImage, width, height) : lCXSwTs2jgN.ResizeWithPerspective(inImage, width, height, interpolate));
		if (num * 128 != width || num2 * 128 != height)
		{
			Bitmap bitmap = lCXSwTs2jgN.NewMapImage(num * 128, num2 * 128);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(image, num3 / 2, num4 / 2);
			graphics.Dispose();
			image = bitmap;
		}
		int num5 = 0;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				Bitmap bitmap2 = lCXSwTs2jgN.NewMapImage();
				Graphics graphics2 = Graphics.FromImage(bitmap2);
				Rectangle srcRect = new Rectangle(j * 128, i * 128, 128, 128);
				Rectangle destRect = new Rectangle(0, 0, 128, 128);
				graphics2.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
				graphics2.Dispose();
				long num6 = index + num5;
				if (!mapList.ContainsKey(num6))
				{
					mapList.Add(num6, new MCMap(num6));
				}
				FromImage(mapList[num6].Map, bitmap2);
				if (mapList[num6].MapStatus != MapStatusType.New)
				{
					mapList[num6].MapStatus = MapStatusType.Changed;
				}
				mapList[num6].Map[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] = new TagNodeByte(byte.MaxValue);
				num5++;
				cONSvI5Dk6e(num5);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FromImage(TagNodeCompound map, Bitmap bmp)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[65536];
		int num = 0;
		for (int i = 0; i < 128; i++)
		{
			for (int j = 0; j < 128; j++)
			{
				Color pixel = bmp.GetPixel(j, i);
				array[num++] = pixel.R;
				array[num++] = pixel.G;
				array[num++] = pixel.B;
				array[num++] = pixel.A;
			}
		}
		map[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73608)] = new TagNodeByteArray(array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap ToImage(TagNodeCompound map)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short num = (short)(map.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23136)) ? ((TagNodeShort)map[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23136)]).Data : 128);
		short num2 = (short)(map.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73624)) ? ((TagNodeShort)map[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73624)]).Data : 128);
		byte[] array = map[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73608)] as TagNodeByteArray;
		Bitmap bitmap = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
		if (array.Length == 16384)
		{
			MapConverterII mapConverterII = new MapConverterII();
			bitmap = mapConverterII.MapToBitmap(map);
		}
		else
		{
			int num3 = 0;
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					byte red = array[num3++];
					byte green = array[num3++];
					byte blue = array[num3++];
					byte alpha = array[num3++];
					Color color = Color.FromArgb(alpha, red, green, blue);
					bitmap.SetPixel(j, i, color);
				}
			}
		}
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveImage(TagNodeCompound map, string imagePath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = map[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73608)] as TagNodeByteArray;
		if (array.Length == 16384)
		{
			ImageUtils imageUtils = new ImageUtils();
			imageUtils.SaveImage(map, imagePath);
		}
		else if (!string.IsNullOrWhiteSpace(imagePath))
		{
			Bitmap bitmap = ToImage(map);
			bitmap.Save(imagePath, ImageFormat.Png);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cONSvI5Dk6e(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_0 / (float)JdqSwGlfAFL * 100f);
		string text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73640), P_0, JdqSwGlfAFL);
		QHtSvzRJ29v(text, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QHtSvzRJ29v(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (vflSwSLxEnh != null)
		{
			vflSwSLxEnh.ReportProgress(P_1, P_0);
		}
	}
}
