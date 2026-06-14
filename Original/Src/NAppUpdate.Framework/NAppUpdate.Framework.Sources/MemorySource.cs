using System;
using System.Collections.Generic;
using NAppUpdate.Framework.Common;

namespace NAppUpdate.Framework.Sources;

public class MemorySource : IUpdateSource
{
	private readonly Dictionary<Uri, string> tempFiles;

	public string Feed { get; set; }

	public MemorySource(string feedString)
	{
		Feed = feedString;
		tempFiles = new Dictionary<Uri, string>();
	}

	public void AddTempFile(Uri uri, string path)
	{
		tempFiles.Add(uri, path);
	}

	public string GetUpdatesFeed()
	{
		return Feed;
	}

	public bool GetData(string filePath, string basePath, Action<UpdateProgressInfo> onProgress, ref string tempFile)
	{
		Uri uri = null;
		if (Uri.IsWellFormedUriString(filePath, UriKind.Absolute))
		{
			uri = new Uri(filePath);
		}
		else if (Uri.IsWellFormedUriString(basePath, UriKind.Absolute))
		{
			uri = new Uri(new Uri(basePath, UriKind.Absolute), filePath);
		}
		if (uri == null || !tempFiles.ContainsKey(uri))
		{
			return false;
		}
		tempFile = tempFiles[uri];
		return true;
	}
}
