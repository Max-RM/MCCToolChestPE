using System;
using System.Globalization;
using System.IO;
using System.Net;
using NAppUpdate.Framework.Common;

namespace NAppUpdate.Framework.Utils;

public sealed class FileDownloader
{
	private const int _bufferSize = 1024;

	private readonly Uri _uri;

	public IWebProxy Proxy { get; set; }

	public FileDownloader()
	{
		Proxy = null;
	}

	public FileDownloader(string url)
	{
		_uri = new Uri(url);
	}

	public FileDownloader(Uri uri)
	{
		_uri = uri;
	}

	public byte[] Download()
	{
		using WebClient webClient = new WebClient();
		return webClient.DownloadData(_uri);
	}

	public bool DownloadToFile(string tempLocation)
	{
		return DownloadToFile(tempLocation, null);
	}

	public bool DownloadToFile(string tempLocation, Action<UpdateProgressInfo> onProgress)
	{
		WebRequest webRequest = WebRequest.Create(_uri);
		webRequest.Proxy = Proxy;
		using WebResponse webResponse = webRequest.GetResponse();
		using FileStream fileStream = File.Create(tempLocation);
		using Stream stream = webResponse.GetResponseStream();
		if (stream == null)
		{
			return false;
		}
		long contentLength = webResponse.ContentLength;
		long num = 0L;
		byte[] array = new byte[1024];
		DateTime value = DateTime.Now.Subtract(new TimeSpan(0, 0, 1));
		int num2;
		do
		{
			num2 = stream.Read(array, 0, array.Length);
			num += num2;
			fileStream.Write(array, 0, num2);
			if (onProgress != null && DateTime.Now.Subtract(value).TotalSeconds >= 1.0)
			{
				ReportProgress(onProgress, num, contentLength);
				value = DateTime.Now;
			}
		}
		while (num2 > 0 && !UpdateManager.Instance.ShouldStop);
		ReportProgress(onProgress, num, contentLength);
		return num == contentLength;
	}

	private void ReportProgress(Action<UpdateProgressInfo> onProgress, long totalBytes, long downloadSize)
	{
		onProgress?.Invoke(new DownloadProgressInfo
		{
			DownloadedInBytes = totalBytes,
			FileSizeInBytes = downloadSize,
			Percentage = (int)((float)totalBytes / (float)downloadSize * 100f),
			Message = $"Downloading... ({ToFileSizeString(totalBytes)} / {ToFileSizeString(downloadSize)} completed)",
			StillWorking = (totalBytes == downloadSize)
		});
	}

	private string ToFileSizeString(long size)
	{
		if (size < 1000)
		{
			return $"{size} bytes";
		}
		if (size < 1000000)
		{
			return $"{size / 1000:F1} KB";
		}
		if (size < 1000000000)
		{
			return $"{size / 1000000:F1} MB";
		}
		if (size < 1000000000000L)
		{
			return $"{size / 1000000000:F1} GB";
		}
		if (size < 1000000000000000L)
		{
			return $"{size / 1000000000000L:F1} TB";
		}
		return size.ToString(CultureInfo.InvariantCulture);
	}
}
