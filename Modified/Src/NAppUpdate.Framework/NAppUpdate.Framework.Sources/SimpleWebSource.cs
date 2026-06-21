using System;
using System.IO;
using System.Net;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Utils;

namespace NAppUpdate.Framework.Sources;

public class SimpleWebSource : IUpdateSource
{
	public IWebProxy Proxy { get; set; }

	public string FeedUrl { get; set; }

	public SimpleWebSource()
	{
		Proxy = null;
	}

	public SimpleWebSource(string feedUrl)
	{
		FeedUrl = feedUrl;
		Proxy = null;
	}

	private void TryResolvingHost()
	{
		Uri uri = new Uri(FeedUrl);
		try
		{
			Dns.GetHostEntry(uri.Host);
		}
		catch (Exception)
		{
			throw new WebException($"Failed to resolve {uri.Host}. Check your connectivity.", WebExceptionStatus.ConnectFailure);
		}
	}

	public string GetUpdatesFeed()
	{
		TryResolvingHost();
		string result = string.Empty;
		WebRequest webRequest = WebRequest.Create(FeedUrl);
		webRequest.Method = "GET";
		webRequest.Proxy = Proxy;
		using (WebResponse webResponse = webRequest.GetResponse())
		{
			Stream responseStream = webResponse.GetResponseStream();
			if (responseStream != null)
			{
				using StreamReader streamReader = new StreamReader(responseStream, detectEncodingFromByteOrderMarks: true);
				result = streamReader.ReadToEnd();
			}
		}
		return result;
	}

	public bool GetData(string url, string baseUrl, Action<UpdateProgressInfo> onProgress, ref string tempLocation)
	{
		if (!string.IsNullOrEmpty(baseUrl) && !baseUrl.EndsWith("/"))
		{
			baseUrl += "/";
		}
		FileDownloader fileDownloader = (Uri.IsWellFormedUriString(url, UriKind.Absolute) ? new FileDownloader(url) : ((!Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute)) ? (string.IsNullOrEmpty(baseUrl) ? new FileDownloader(url) : new FileDownloader(new Uri(new Uri(baseUrl), url))) : new FileDownloader(new Uri(new Uri(baseUrl, UriKind.Absolute), url))));
		fileDownloader.Proxy = Proxy;
		if (string.IsNullOrEmpty(tempLocation) || !Directory.Exists(Path.GetDirectoryName(tempLocation)))
		{
			tempLocation = Path.GetTempFileName();
		}
		return fileDownloader.DownloadToFile(tempLocation, onProgress);
	}
}
