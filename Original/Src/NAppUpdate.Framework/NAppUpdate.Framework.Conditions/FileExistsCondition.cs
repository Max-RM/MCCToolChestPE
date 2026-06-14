using System;
using System.Collections.Generic;
using System.IO;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Tasks;
using NAppUpdate.Framework.Utils;

namespace NAppUpdate.Framework.Conditions;

[Serializable]
[UpdateConditionAlias("exists")]
public class FileExistsCondition : IUpdateCondition, INauFieldsHolder
{
	[NauField("localPath", "The local path of the file to check. If not set but set under a FileUpdateTask, the LocalPath of the task will be used. Otherwise this condition will be ignored.", false)]
	public string LocalPath { get; set; }

	public IDictionary<string, string> Attributes { get; private set; }

	public bool IsMet(IUpdateTask task)
	{
		string text = ((!string.IsNullOrEmpty(LocalPath)) ? LocalPath : (Reflection.GetNauAttribute(task, "LocalPath") as string));
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		return File.Exists(text);
	}
}
