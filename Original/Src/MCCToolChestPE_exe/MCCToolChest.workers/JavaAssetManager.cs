using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class JavaAssetManager
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckAssets()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string assetPath = Path.Combine(Utils.ConversionPath(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243674));
		CheckAssets(assetPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243696));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckAssets(string assetPath, string zipName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (R5qSkrmYS2d(assetPath, zipName))
		{
			try
			{
				Directory.CreateDirectory(assetPath);
				WebClient webClient = new WebClient();
				webClient.DownloadFile(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243732) + zipName, Path.Combine(assetPath, zipName));
				ArchiveWorker archiveWorker = new ArchiveWorker();
				archiveWorker.ExtractZip(assetPath, Path.Combine(assetPath, zipName));
			}
			catch (Exception)
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243808) + Environment.NewLine + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243936), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244062));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool R5qSkrmYS2d(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		if (!Directory.Exists(P_0))
		{
			result = true;
		}
		else if (!File.Exists(Path.Combine(P_0, P_1)))
		{
			WdySk5q8O83(P_0);
			result = true;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void WdySk5q8O83(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(P_0);
		if (directoryInfo == null)
		{
			return;
		}
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		DirectoryInfo[] array = directories;
		foreach (DirectoryInfo directoryInfo2 in array)
		{
			try
			{
				directoryInfo2.Delete(recursive: true);
			}
			catch (Exception)
			{
			}
		}
		FileInfo[] files = directoryInfo.GetFiles();
		FileInfo[] array2 = files;
		foreach (FileInfo fileInfo in array2)
		{
			try
			{
				fileInfo.Delete();
			}
			catch (Exception)
			{
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JavaAssetManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
