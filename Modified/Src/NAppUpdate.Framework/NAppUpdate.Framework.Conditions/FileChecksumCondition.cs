using System;
using System.IO;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Tasks;
using NAppUpdate.Framework.Utils;

namespace NAppUpdate.Framework.Conditions;

[Serializable]
public class FileChecksumCondition : IUpdateCondition, INauFieldsHolder
{
	[NauField("localPath", "The local path of the file to check. If not set but set under a FileUpdateTask, the LocalPath of the task will be used. Otherwise this condition will be ignored.", false)]
	public string LocalPath { get; set; }

	[NauField("checksum", "Checksum expected from the file", true)]
	public string Checksum { get; set; }

	[NauField("checksumType", "Type of checksum to calculate", true)]
	public string ChecksumType { get; set; }

	public bool IsMet(IUpdateTask task)
	{
		string text = ((!string.IsNullOrEmpty(LocalPath)) ? LocalPath : (Reflection.GetNauAttribute(task, "LocalPath") as string));
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		if (!File.Exists(text))
		{
			return false;
		}
		if ("sha256".Equals(ChecksumType, StringComparison.InvariantCultureIgnoreCase))
		{
			string sHA256Checksum = FileChecksum.GetSHA256Checksum(text);
			if (!string.IsNullOrEmpty(sHA256Checksum) && sHA256Checksum.Equals(Checksum, StringComparison.InvariantCultureIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}
}
