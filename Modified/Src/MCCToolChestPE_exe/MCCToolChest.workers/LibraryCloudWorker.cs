using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using MCCToolChest.utils;
using MCCToolChestDB.Model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class LibraryCloudWorker
{
	private BackgroundWorker MShSYNZsIQx;

	private static List<NBTLibraryItem> VjRSYDZmikK;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LibraryCloudWorker(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		MShSYNZsIQx = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<NBTLibraryItem> CallLibrary(string category, string platform, string nbtType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<NBTLibraryItem> list = new List<NBTLibraryItem>();
		bool flag = false;
		if (VjRSYDZmikK == null)
		{
			VjRSYDZmikK = NplSY6twXy2(category, platform, nbtType);
			flag = true;
		}
		foreach (NBTLibraryItem item in VjRSYDZmikK)
		{
			string path = Path.Combine(Utils.LibraryImagePath(), item.ID.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722));
			if (flag && !File.Exists(path))
			{
				list.Add(item);
			}
			MShSYNZsIQx.ReportProgress(0, item);
		}
		if (flag)
		{
			foreach (NBTLibraryItem item2 in list)
			{
				string path2 = Path.Combine(Utils.LibraryImagePath(), item2.ID.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722));
				DownloadImageFile(item2, path2);
				MShSYNZsIQx.ReportProgress(0, item2.ID);
			}
		}
		return VjRSYDZmikK;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<NBTLibraryItem> NplSY6twXy2(string P_0, string P_1, string P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246384), P_0, P_1, P_2);
		Uri requestUri = new Uri(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246464) + text);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
		httpWebRequest.Method = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246570);
		httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		string json = string.Empty;
		using (Stream stream = httpWebResponse.GetResponseStream())
		{
			using StreamReader streamReader = new StreamReader(stream);
			json = streamReader.ReadToEnd();
		}
		VjRSYDZmikK = JsonDataConversion.Deserialize<List<NBTLibraryItem>>(json);
		return VjRSYDZmikK;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DownloadImageFile(NBTLibraryItem nbtLibraryItem, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string address = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246580), nbtLibraryItem.ID.ToString());
		WebClient webClient = new WebClient();
		try
		{
			byte[] array = webClient.DownloadData(address);
			if (array.Length > 0)
			{
				FileUtils.WriteFile(array, path);
			}
		}
		catch (Exception)
		{
		}
		webClient.Dispose();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LibraryCloudWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
