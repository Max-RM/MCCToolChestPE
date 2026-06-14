using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public class ImageUtils
{
	[CompilerGenerated]
	private static Comparison<FileInfo> MwDSRWKTDFo;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap ResizeWithPerspective(Bitmap image, bool interpolate)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int boxHeight = 128;
		int boxWidth = 128;
		return ResizeWithPerspective(image, boxWidth, boxHeight, interpolate);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap ResizeWithPerspective(Bitmap image, int boxWidth, int boxHeight, bool interpolate)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		double num = (double)image.Width / (double)image.Height;
		if ((int)((double)boxHeight * num) <= boxWidth)
		{
			if (interpolate)
			{
				return ShrinkImage(image, (int)((double)boxHeight * num), boxHeight);
			}
			return new Bitmap(image, (int)((double)boxHeight * num), boxHeight);
		}
		if (interpolate)
		{
			return ShrinkImage(image, boxWidth, (int)((double)boxWidth / num));
		}
		return new Bitmap(image, boxWidth, (int)((double)boxWidth / num));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap EnlargeImage(Bitmap original, int width, int height)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Bitmap bitmap = new Bitmap(width, height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.InterpolationMode = InterpolationMode.Bicubic;
		graphics.DrawImage(original, new Rectangle(Point.Empty, bitmap.Size));
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap ShrinkImage(Bitmap original, int width, int height)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Bitmap bitmap = new Bitmap(width, height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphics.DrawImage(original, new Rectangle(Point.Empty, bitmap.Size));
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap CopySmallerImage(Bitmap resizedImage)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Bitmap bitmap = NewMapImage();
		if (resizedImage.Width <= 128 || resizedImage.Height <= 128)
		{
			int num = (128 - resizedImage.Width) / 2;
			int num2 = (128 - resizedImage.Height) / 2;
			for (int i = 0; i < resizedImage.Width; i++)
			{
				for (int j = 0; j < resizedImage.Height; j++)
				{
					Color pixel = resizedImage.GetPixel(i, j);
					bitmap.SetPixel(i + num, j + num2, pixel);
				}
			}
		}
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap NewMapImage()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 128;
		return NewMapImage(num, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap NewMapImage(int x, int y)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Color color = Color.FromArgb(0, 0, 0, 0);
		Bitmap bitmap = new Bitmap(x, y);
		Brush brush = new SolidBrush(color);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveImage(TagNodeCompound map, string imagePath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(imagePath))
		{
			MapConverterII mapConverterII = new MapConverterII();
			Bitmap bitmap = mapConverterII.MapToBitmap(map);
			Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppPArgb);
			using (Graphics graphics = Graphics.FromImage(bitmap2))
			{
				graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height));
			}
			bitmap2.MakeTransparent(Color.Black);
			Image image = bitmap2;
			image.Save(imagePath, ImageFormat.Png);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SortedDictionary<long, MCMap> LoadMaps()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(Working.T92StMGt1p4() + Working.WorkFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206));
		FileInfo[] files = directoryInfo.GetFiles(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214606));
		SortedDictionary<long, MCMap> sortedDictionary = new SortedDictionary<long, MCMap>();
		Array.Sort(files, [MethodImpl(MethodImplOptions.NoInlining)] (FileInfo P_0, FileInfo P_1) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(P_0.Name);
			string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(P_1.Name);
			int.TryParse(fileNameWithoutExtension.Substring(4), out var result);
			int.TryParse(fileNameWithoutExtension2.Substring(4), out var result2);
			int result3 = 0;
			if (result < result2)
			{
				result3 = -1;
			}
			else if (result > result2)
			{
				result3 = 1;
			}
			return result3;
		});
		FileInfo[] array = files;
		foreach (FileInfo fileInfo in array)
		{
			MCMap mCMap = LoadMap(fileInfo.FullName);
			sortedDictionary.Add(mCMap.Index, mCMap);
		}
		return sortedDictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCMap LoadMap(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
		byte[] buffer = FileUtils.pURSg6Zk53A(path);
		MemoryStream s = new MemoryStream(buffer);
		NbtTree nbtTree = new NbtTree(s);
		TagNodeCompound root = nbtTree.Root;
		long index = OEoSR4IBJYJ(fileNameWithoutExtension);
		return new MCMap(index, fileNameWithoutExtension, root);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long OEoSR4IBJYJ(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		long result = 0L;
		long.TryParse(P_0.Substring(4), out result);
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ImageUtils()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int BmaSRVnXN32(FileInfo P_0, FileInfo P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(P_0.Name);
		string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(P_1.Name);
		int.TryParse(fileNameWithoutExtension.Substring(4), out var result);
		int.TryParse(fileNameWithoutExtension2.Substring(4), out var result2);
		int result3 = 0;
		if (result < result2)
		{
			result3 = -1;
		}
		else if (result > result2)
		{
			result3 = 1;
		}
		return result3;
	}
}
