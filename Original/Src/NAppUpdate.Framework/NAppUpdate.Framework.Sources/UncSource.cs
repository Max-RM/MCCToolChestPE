using System;
using System.IO;
using System.Text;
using NAppUpdate.Framework.Common;

namespace NAppUpdate.Framework.Sources;

public class UncSource : IUpdateSource
{
	private readonly string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

	public string FeedUncPath { get; set; }

	public string UncPath { get; set; }

	public UncSource()
	{
	}

	public UncSource(string feedUncPath, string uncPath)
	{
		FeedUncPath = feedUncPath;
		UncPath = uncPath;
	}

	public string GetUpdatesFeed()
	{
		string text = File.ReadAllText(FeedUncPath, Encoding.UTF8);
		if (text.StartsWith(_byteOrderMarkUtf8))
		{
			text = text.Remove(0, _byteOrderMarkUtf8.Length);
		}
		return text;
	}

	public bool GetData(string filePath, string basePath, Action<UpdateProgressInfo> onProgress, ref string tempLocation)
	{
		if (basePath == null)
		{
			basePath = UncPath;
		}
		if (!basePath.EndsWith("\\"))
		{
			basePath += "\\";
		}
		File.Copy(basePath + filePath, tempLocation);
		return true;
	}
}
