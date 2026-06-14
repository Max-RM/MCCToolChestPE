using System;
using System.Diagnostics;
using System.IO;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Tasks;
using NAppUpdate.Framework.Utils;

namespace NAppUpdate.Framework.Conditions;

[Serializable]
[UpdateConditionAlias("version")]
public class FileVersionCondition : IUpdateCondition, INauFieldsHolder
{
	[NauField("localPath", "The local path of the file to check. If not set but set under a FileUpdateTask, the LocalPath of the task will be used. Otherwise this condition will be ignored.", false)]
	public string LocalPath { get; set; }

	[NauField("version", "Version string to check against", true)]
	public string Version { get; set; }

	[NauField("what", "Comparison action to perform. Accepted values: above, is, below. Default: below.", false)]
	public string ComparisonType { get; set; }

	public bool IsMet(IUpdateTask task)
	{
		string text = ((!string.IsNullOrEmpty(LocalPath)) ? LocalPath : (Reflection.GetNauAttribute(task, "LocalPath") as string));
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		if (!File.Exists(text))
		{
			return ComparisonType.Equals("below", StringComparison.InvariantCultureIgnoreCase);
		}
		FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(text);
		if (versionInfo.FileVersion == null)
		{
			return true;
		}
		Version version = new Version(versionInfo.FileMajorPart, versionInfo.FileMinorPart, versionInfo.FileBuildPart, versionInfo.FilePrivatePart);
		Version version2 = ((Version != null) ? new Version(Version) : new Version());
		return ComparisonType switch
		{
			"above" => version2 < version, 
			"is" => version2 == version, 
			_ => version2 > version, 
		};
	}
}
