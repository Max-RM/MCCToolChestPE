using System;
using System.IO;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Tasks;
using NAppUpdate.Framework.Utils;

namespace NAppUpdate.Framework.Conditions;

[Serializable]
public class FileSizeCondition : IUpdateCondition, INauFieldsHolder
{
	[NauField("localPath", "The local path of the file to check. If not set but set under a FileUpdateTask, the LocalPath of the task will be used. Otherwise this condition will be ignored.", false)]
	public string LocalPath { get; set; }

	[NauField("size", "File size to compare with (in bytes)", true)]
	public long FileSize { get; set; }

	[NauField("what", "Comparison action to perform. Accepted values: above, is, below. Default: below.", false)]
	public string ComparisonType { get; set; }

	public bool IsMet(IUpdateTask task)
	{
		if (FileSize <= 0)
		{
			return true;
		}
		string text = ((!string.IsNullOrEmpty(LocalPath)) ? LocalPath : (Reflection.GetNauAttribute(task, "LocalPath") as string));
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		long num = 0L;
		if (File.Exists(text))
		{
			FileInfo fileInfo = new FileInfo(text);
			num = fileInfo.Length;
		}
		return ComparisonType switch
		{
			"above" => FileSize < num, 
			"is" => FileSize == num, 
			_ => FileSize > num, 
		};
	}
}
