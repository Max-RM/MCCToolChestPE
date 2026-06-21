using System;
using System.IO;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Tasks;
using NAppUpdate.Framework.Utils;

namespace NAppUpdate.Framework.Conditions;

[Serializable]
public class FileDateCondition : IUpdateCondition, INauFieldsHolder
{
	[NauField("localPath", "The local path of the file to check. If not set but set under a FileUpdateTask, the LocalPath of the task will be used. Otherwise this condition will be ignored.", false)]
	public string LocalPath { get; set; }

	[NauField("timestamp", "Date-time to compare with", true)]
	public DateTime Timestamp { get; set; }

	[NauField("what", "Comparison action to perform. Accepted values: newer, is, older. Default: older.", false)]
	public string ComparisonType { get; set; }

	public FileDateCondition()
	{
		Timestamp = DateTime.MinValue;
	}

	public bool IsMet(IUpdateTask task)
	{
		if (Timestamp == DateTime.MinValue)
		{
			return true;
		}
		string text = ((!string.IsNullOrEmpty(LocalPath)) ? LocalPath : (Reflection.GetNauAttribute(task, "LocalPath") as string));
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		if (!File.Exists(text))
		{
			return ComparisonType.Equals("older", StringComparison.InvariantCultureIgnoreCase);
		}
		DateTime lastWriteTime = File.GetLastWriteTime(text);
		long num = lastWriteTime.AddSeconds(2.0).ToFileTimeUtc();
		long num2 = lastWriteTime.AddSeconds(-2.0).ToFileTimeUtc();
		long num3 = Timestamp.ToFileTimeUtc();
		return ComparisonType switch
		{
			"newer" => num2 > num3, 
			"is" => num2 <= num3 && num3 <= num, 
			_ => num < num3, 
		};
	}
}
