using System;
using System.IO;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Sources;
using NAppUpdate.Framework.Utils;

namespace NAppUpdate.Framework.Tasks;

[Serializable]
[UpdateTaskAlias("fileUpdate")]
public class FileUpdateTask : UpdateTaskBase
{
	private string _destinationFile;

	private string _backupFile;

	private string _tempFile;

	[NauField("localPath", "The local path of the file to update", true)]
	public string LocalPath { get; set; }

	[NauField("updateTo", "File name on the remote location; same name as local path will be used if left blank", false)]
	public string UpdateTo { get; set; }

	[NauField("sha256-checksum", "SHA-256 checksum to validate the file after download (optional)", false)]
	public string Sha256Checksum { get; set; }

	[NauField("hotswap", "Default update action is a cold update; check here if a hot file swap should be attempted", false)]
	public bool CanHotSwap { get; set; }

	public override void Prepare(IUpdateSource source)
	{
		if (string.IsNullOrEmpty(LocalPath))
		{
			UpdateManager.Instance.Logger.Log(Logger.SeverityLevel.Warning, "FileUpdateTask: LocalPath is empty, task is a noop");
			return;
		}
		string text = (string.IsNullOrEmpty(UpdateTo) ? LocalPath : UpdateTo);
		_tempFile = null;
		string baseUrl = UpdateManager.Instance.BaseUrl;
		string tempLocation = Path.Combine(UpdateManager.Instance.Config.TempFolder, Guid.NewGuid().ToString());
		UpdateManager.Instance.Logger.Log("FileUpdateTask: Downloading {0} with BaseUrl of {1} to {2}", text, baseUrl, tempLocation);
		if (!source.GetData(text, baseUrl, OnProgress, ref tempLocation))
		{
			throw new UpdateProcessFailedException("FileUpdateTask: Failed to get file from source");
		}
		_tempFile = tempLocation;
		if (_tempFile == null)
		{
			throw new UpdateProcessFailedException("FileUpdateTask: Failed to get file from source");
		}
		if (!string.IsNullOrEmpty(Sha256Checksum))
		{
			string sHA256Checksum = FileChecksum.GetSHA256Checksum(_tempFile);
			if (!sHA256Checksum.Equals(Sha256Checksum))
			{
				throw new UpdateProcessFailedException($"FileUpdateTask: Checksums do not match; expected {Sha256Checksum} but got {sHA256Checksum}");
			}
		}
		_destinationFile = Path.Combine(Path.GetDirectoryName(UpdateManager.Instance.ApplicationPath), LocalPath);
		UpdateManager.Instance.Logger.Log("FileUpdateTask: Prepared successfully; destination file: {0}", _destinationFile);
	}

	public override TaskExecutionStatus Execute(bool coldRun)
	{
		if (string.IsNullOrEmpty(LocalPath))
		{
			UpdateManager.Instance.Logger.Log(Logger.SeverityLevel.Warning, "FileUpdateTask: LocalPath is empty, task is a noop");
			return TaskExecutionStatus.Successful;
		}
		string directoryName = Path.GetDirectoryName(_destinationFile);
		if (!Directory.Exists(directoryName))
		{
			FileSystem.CreateDirectoryStructure(directoryName, pathIncludeFile: false);
		}
		if (_backupFile == null && File.Exists(_destinationFile))
		{
			if (!Directory.Exists(Path.GetDirectoryName(Path.Combine(UpdateManager.Instance.Config.BackupFolder, LocalPath))))
			{
				FileSystem.CreateDirectoryStructure(Path.GetDirectoryName(Path.Combine(UpdateManager.Instance.Config.BackupFolder, LocalPath)), pathIncludeFile: false);
			}
			_backupFile = Path.Combine(UpdateManager.Instance.Config.BackupFolder, LocalPath);
			File.Copy(_destinationFile, _backupFile, overwrite: true);
		}
		if (CanHotSwap || coldRun)
		{
			if (File.Exists(_destinationFile) && !PermissionsCheck.HaveWritePermissionsForFileOrFolder(_destinationFile))
			{
				if (coldRun)
				{
					UpdateManager.Instance.Logger.Log(Logger.SeverityLevel.Warning, "Don't have permissions to touch {0}", _destinationFile);
					File.Delete(_destinationFile);
				}
				CanHotSwap = false;
			}
			try
			{
				if (File.Exists(_destinationFile))
				{
					File.Delete(_destinationFile);
				}
				File.Move(_tempFile, _destinationFile);
				_tempFile = null;
			}
			catch (Exception ex)
			{
				if (coldRun)
				{
					base.ExecutionStatus = TaskExecutionStatus.Failed;
					throw new UpdateProcessFailedException("Could not replace the file", ex);
				}
				CanHotSwap = false;
			}
		}
		if (coldRun || CanHotSwap)
		{
			return TaskExecutionStatus.Successful;
		}
		if (File.Exists(_destinationFile) && !PermissionsCheck.HaveWritePermissionsForFileOrFolder(_destinationFile))
		{
			return TaskExecutionStatus.RequiresPrivilegedAppRestart;
		}
		return TaskExecutionStatus.RequiresAppRestart;
	}

	public override bool Rollback()
	{
		if (string.IsNullOrEmpty(_destinationFile))
		{
			return true;
		}
		if (File.Exists(_destinationFile))
		{
			File.Delete(_destinationFile);
		}
		File.Copy(_backupFile, _destinationFile, overwrite: true);
		return true;
	}
}
