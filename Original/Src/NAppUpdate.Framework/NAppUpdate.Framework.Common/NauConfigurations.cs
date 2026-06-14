using System;
using System.Collections.Generic;
using System.IO;

namespace NAppUpdate.Framework.Common;

[Serializable]
public class NauConfigurations
{
	internal string _backupFolder;

	public string TempFolder { get; set; }

	public string BackupFolder
	{
		get
		{
			return _backupFolder;
		}
		set
		{
			if (UpdateManager.Instance.State == UpdateManager.UpdateProcessState.NotChecked || UpdateManager.Instance.State == UpdateManager.UpdateProcessState.Checked)
			{
				string text = value.TrimEnd(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
				_backupFolder = (Path.IsPathRooted(text) ? text : Path.Combine(TempFolder, text));
				return;
			}
			throw new ArgumentException("BackupFolder can only be specified before update has started");
		}
	}

	public string UpdateProcessName { get; set; }

	public string UpdateExecutableName { get; set; }

	public List<string> DependenciesForColdUpdate { get; set; }
}
