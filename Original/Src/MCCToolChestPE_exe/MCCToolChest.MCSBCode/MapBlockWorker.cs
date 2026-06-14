using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using MCPELevelDBI.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class MapBlockWorker
{
	private int jwKSv6XhLTj;

	private BackgroundWorker jWPSvNZlrWx;

	private string sb9SvDD7Nin;

	private int LEaSvc6EcH4;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapBlockWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		jwKSv6XhLTj = 512;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapBlockWorker(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		jwKSv6XhLTj = 512;
		jWPSvNZlrWx = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool MapBlocks(string dimension, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Working.MapsGenerated.ContainsKey(dimension) && Working.MapsGenerated[dimension])
		{
			return true;
		}
		MapBlocksPE.BuildColorLookupTable();
		Working.MapsGenerated[dimension] = true;
		sb9SvDD7Nin = Path.Combine(outFolderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20428), dimension);
		Directory.CreateDirectory(sb9SvDD7Nin);
		PEDimension pEDimension = PEUtility.GetPEDimension(dimension);
		k8eSvPpNpPU(outFolderPath);
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(Path.Combine(outFolderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20428)));
		bool result = GAbSvRCJEhE(pEDimension, outFolderPath, levelDBWorker);
		levelDBWorker.CloseDB();
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void k8eSvPpNpPU(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Directory.CreateDirectory(Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20428), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
		FileUtils.CopyFoldersAndFiles(Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)), Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20428), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GAbSvRCJEhE(PEDimension P_0, string P_1, LevelDBWorker P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = Environment.ProcessorCount;
		if (num > 1)
		{
			num--;
		}
		int count = P_0.Region.Values.Count;
		ManualResetEvent[] array = new ManualResetEvent[count];
		List<MapBlockPEParameter> list = new List<MapBlockPEParameter>();
		int num2 = 0;
		foreach (PERegion value in P_0.Region.Values)
		{
			array[num2] = new ManualResetEvent(initialState: false);
			MapBlockPEParameter item = new MapBlockPEParameter("", value, P_2, array[num2]);
			list.Add(item);
			num2++;
		}
		new List<MapBlockPEParameter>();
		List<MapBlockPEParameter> list2 = new List<MapBlockPEParameter>();
		while (list.Count > 0 || list2.Count > 0)
		{
			if (list2.Count < num && list.Count > 0)
			{
				MapBlockPEParameter mapBlockPEParameter = list[0];
				list.Remove(mapBlockPEParameter);
				list2.Add(mapBlockPEParameter);
				MapBlocksPE mapBlocksPE = new MapBlocksPE();
				ThreadPool.QueueUserWorkItem(mapBlocksPE.MapRegion, mapBlockPEParameter);
			}
			for (int num3 = list2.Count - 1; num3 >= 0; num3--)
			{
				MapBlockPEParameter mapBlockPEParameter2 = list2[num3];
				if (mapBlockPEParameter2.Completed)
				{
					list2.Remove(mapBlockPEParameter2);
					RMcSvkBZX7g(mapBlockPEParameter2, sb9SvDD7Nin);
				}
			}
			Thread.Sleep(100);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RMcSvkBZX7g(MapBlockPEParameter P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			Image image = LPlSv1nLuL1(P_0.BlockImage.Bitmap, P_0.BiomeImage.Bitmap);
			string filename = Path.Combine(P_1, P_0.PERegion.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72944));
			image.Save(filename, ImageFormat.Png);
			image.Dispose();
			image = null;
			filename = Path.Combine(P_1, P_0.PERegion.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722));
			P_0.BlockImage.Bitmap.Save(filename, ImageFormat.Png);
			P_0.BlockImage.Dispose();
			P_0.BlockImage = null;
			filename = Path.Combine(P_1, P_0.PERegion.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72970));
			P_0.BiomeImage.Bitmap.Save(filename, ImageFormat.Png);
			P_0.BiomeImage.Dispose();
			P_0.BiomeImage = null;
			filename = Path.Combine(P_1, P_0.PERegion.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72994));
			P_0.HeightImage.Bitmap.Save(filename, ImageFormat.Png);
			P_0.HeightImage.Dispose();
			P_0.HeightImage = null;
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Bitmap MXrSvY6VnbV(List<PERegion> P_0, out int P_1, out int P_2, out int P_3, out int P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		int num2 = 0;
		P_1 = 0;
		P_2 = 0;
		P_3 = 0;
		P_4 = 0;
		foreach (PERegion item in P_0)
		{
			if (item.RX < P_1)
			{
				P_1 = item.RX;
			}
			if (item.RX > P_2)
			{
				P_2 = item.RX;
			}
			if (item.RZ < P_3)
			{
				P_3 = item.RZ;
			}
			if (item.RZ > P_4)
			{
				P_4 = item.RZ;
			}
		}
		num = P_2 - P_1;
		num2 = P_4 - P_3;
		return new Bitmap(num * 512 + 512, num2 * 512 + 512);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Bitmap nuJSv3jrWbm(PEDimension P_0, Dictionary<string, Image> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num;
		int num2;
		int num3;
		int num4;
		Bitmap bitmap = MXrSvY6VnbV(P_0.Region.Values.ToList(), out num, out num2, out num3, out num4);
		int num5 = 0;
		using Graphics graphics = Graphics.FromImage(bitmap);
		foreach (PERegion value in P_0.Region.Values)
		{
			Image image = P_1[value.ToString()];
			int num6 = value.RX - num;
			int num7 = value.RZ - num3;
			graphics.DrawImage(image, num6 * 512, num7 * 512);
			num5++;
		}
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Image LPlSv1nLuL1(Image P_0, Image P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image image = (Image)P_0.Clone();
		float matrix = (float)Settings.Default.HrybridOpacity / 100f;
		ColorMatrix colorMatrix = new ColorMatrix();
		colorMatrix.Matrix33 = matrix;
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		Rectangle destRect = new Rectangle(0, 0, 1024, 1024);
		using Graphics graphics = Graphics.FromImage(image);
		graphics.DrawImage(P_1, destRect, 0, 0, 1024, 1024, GraphicsUnit.Pixel, imageAttributes);
		return image;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeleteRegionImage(string dimension, string region, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Path.Combine(outFolderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20428), dimension);
		try
		{
			string path2 = Path.Combine(path, region + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722));
			File.Delete(path2);
			path2 = Path.Combine(path, region + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72970));
			File.Delete(path2);
			path2 = Path.Combine(path, region + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72994));
			File.Delete(path2);
			path2 = Path.Combine(path, region + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72944));
			File.Delete(path2);
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegenRegionImage(string dimension, string regionName, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			string text = Path.Combine(outFolderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20428), dimension);
			Directory.CreateDirectory(text);
			PEDimension pEDimension = PEUtility.GetPEDimension(dimension);
			if (pEDimension != null)
			{
				PERegion pERegion = pEDimension.Region[regionName.Remove(0, 2)];
				if (pERegion != null)
				{
					LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(outFolderPath);
					MapBlockPEParameter mapBlockPEParameter = new MapBlockPEParameter(dimension, pERegion, levelDBWorker, null);
					MapBlocksPE mapBlocksPE = new MapBlocksPE();
					mapBlocksPE.MapRegion(mapBlockPEParameter);
					levelDBWorker.CloseDB();
					RMcSvkBZX7g(mapBlockPEParameter, text);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap GetChunkImage(int dimension, int x, int z, string outFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(outFolderPath);
		MapBlocksPE mapBlocksPE = new MapBlocksPE();
		Bitmap result = mapBlocksPE.MapJavaChunk(dimension, x, z, levelDBWorker);
		levelDBWorker.CloseDB();
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mhXSvERR0dT(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		num += Constants.regionSizes[P_0];
		LEaSvc6EcH4 = num * 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lcbSvrvubuq(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)((float)P_1 / (float)LEaSvc6EcH4 * 100f);
		yA5Sv5kol1Q(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yA5Sv5kol1Q(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (jWPSvNZlrWx != null)
		{
			jWPSvNZlrWx.ReportProgress(P_1, P_0);
		}
	}
}
