using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.FeedReaders;
using NAppUpdate.Framework.Sources;
using NAppUpdate.Framework.Tasks;
using NAppUpdate.Framework.Utils;

namespace NAppUpdate.Framework;

public sealed class UpdateManager
{
	[Serializable]
	public enum UpdateProcessState
	{
		NotChecked,
		Checked,
		Prepared,
		AfterRestart,
		AppliedSuccessfully,
		RollbackRequired
	}

	private static readonly UpdateManager instance;

	private static Mutex _shutdownMutex;

	internal readonly string ApplicationPath;

	internal volatile bool ShouldStop;

	private volatile bool _isWorking;

	public static UpdateManager Instance => instance;

	public NauConfigurations Config { get; set; }

	internal string BaseUrl { get; set; }

	internal IList<IUpdateTask> UpdatesToApply { get; private set; }

	public int UpdatesAvailable
	{
		get
		{
			if (UpdatesToApply != null)
			{
				return UpdatesToApply.Count;
			}
			return 0;
		}
	}

	public UpdateProcessState State { get; private set; }

	public IUpdateSource UpdateSource { get; set; }

	public IUpdateFeedReader UpdateFeedReader { get; set; }

	public Logger Logger { get; private set; }

	public IEnumerable<IUpdateTask> Tasks => UpdatesToApply;

	public bool IsWorking
	{
		get
		{
			return _isWorking;
		}
		private set
		{
			_isWorking = value;
		}
	}

	public event ReportProgressDelegate ReportProgress;

	private UpdateManager()
	{
		IsWorking = false;
		State = UpdateProcessState.NotChecked;
		UpdatesToApply = new List<IUpdateTask>();
		ApplicationPath = Process.GetCurrentProcess().MainModule.FileName;
		UpdateFeedReader = new NauXmlFeedReader();
		Logger = new Logger();
		Config = new NauConfigurations
		{
			TempFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()),
			UpdateProcessName = "NAppUpdateProcess",
			UpdateExecutableName = "MCMC.exe"
		};
		string text = Path.Combine(Path.GetDirectoryName(ApplicationPath) ?? string.Empty, "Backup" + DateTime.Now.Ticks);
		text = text.TrimEnd(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
		Config._backupFolder = (Path.IsPathRooted(text) ? text : Path.Combine(Config.TempFolder, text));
	}

	static UpdateManager()
	{
		instance = new UpdateManager();
	}

	private void TaskProgressCallback(UpdateProgressInfo currentStatus, IUpdateTask task)
	{
		if (this.ReportProgress != null)
		{
			currentStatus.TaskDescription = task.Description;
			currentStatus.TaskId = UpdatesToApply.IndexOf(task) + 1;
			float num = 100f / (float)UpdatesToApply.Count;
			currentStatus.Percentage = (int)Math.Round((float)currentStatus.Percentage * num / 100f + (float)(currentStatus.TaskId - 1) * num);
			this.ReportProgress(currentStatus);
		}
	}

	public void CheckForUpdates()
	{
		CheckForUpdates(UpdateSource);
	}

	public void CheckForUpdates(IUpdateSource source)
	{
		if (IsWorking)
		{
			throw new InvalidOperationException("Another update process is already in progress");
		}
		using (WorkScope.New(delegate(bool isWorking)
		{
			IsWorking = isWorking;
		}))
		{
			if (UpdateFeedReader == null)
			{
				throw new ArgumentException("An update feed reader is required; please set one before checking for updates");
			}
			if (source == null)
			{
				throw new ArgumentException("An update source was not specified");
			}
			if (State != UpdateProcessState.NotChecked)
			{
				throw new InvalidOperationException("Already checked for updates; to reset the current state call CleanUp()");
			}
			lock (UpdatesToApply)
			{
				UpdatesToApply.Clear();
				IList<IUpdateTask> list = UpdateFeedReader.Read(source.GetUpdatesFeed());
				foreach (IUpdateTask item in list)
				{
					if (ShouldStop)
					{
						throw new UserAbortException();
					}
					if (item.UpdateConditions == null || item.UpdateConditions.IsMet(item))
					{
						UpdatesToApply.Add(item);
					}
				}
			}
			State = UpdateProcessState.Checked;
		}
	}

	public IAsyncResult BeginCheckForUpdates(IUpdateSource source, AsyncCallback callback, object state)
	{
		UpdateProcessAsyncResult ar = new UpdateProcessAsyncResult(callback, state);
		ThreadPool.QueueUserWorkItem(delegate
		{
			try
			{
				CheckForUpdates(source ?? UpdateSource);
				ar.SetAsCompleted(null, completedSynchronously: false);
			}
			catch (Exception exception)
			{
				ar.SetAsCompleted(exception, completedSynchronously: false);
			}
		}, ar);
		return ar;
	}

	public IAsyncResult BeginCheckForUpdates(AsyncCallback callback, object state)
	{
		return BeginCheckForUpdates(UpdateSource, callback, state);
	}

	public void EndCheckForUpdates(IAsyncResult asyncResult)
	{
		UpdateProcessAsyncResult updateProcessAsyncResult = (UpdateProcessAsyncResult)asyncResult;
		updateProcessAsyncResult.EndInvoke();
	}

	public void PrepareUpdates()
	{
		if (IsWorking)
		{
			throw new InvalidOperationException("Another update process is already in progress");
		}
		using (WorkScope.New(delegate(bool isWorking)
		{
			IsWorking = isWorking;
		}))
		{
			lock (UpdatesToApply)
			{
				if (State != UpdateProcessState.Checked)
				{
					throw new InvalidOperationException("Invalid state when calling PrepareUpdates(): " + State);
				}
				if (UpdatesToApply.Count == 0)
				{
					throw new InvalidOperationException("No updates to prepare");
				}
				if (!Directory.Exists(Config.TempFolder))
				{
					Logger.Log("Creating Temp directory {0}", Config.TempFolder);
					Directory.CreateDirectory(Config.TempFolder);
				}
				else
				{
					Logger.Log("Using existing Temp directory {0}", Config.TempFolder);
				}
				foreach (IUpdateTask item in UpdatesToApply)
				{
					if (ShouldStop)
					{
						throw new UserAbortException();
					}
					IUpdateTask t = item;
					item.ProgressDelegate += delegate(UpdateProgressInfo status)
					{
						TaskProgressCallback(status, t);
					};
					try
					{
						item.Prepare(UpdateSource);
					}
					catch (Exception ex)
					{
						item.ExecutionStatus = TaskExecutionStatus.FailedToPrepare;
						Logger.Log(ex);
						throw new UpdateProcessFailedException("Failed to prepare task: " + item.Description, ex);
					}
					item.ExecutionStatus = TaskExecutionStatus.Prepared;
				}
				State = UpdateProcessState.Prepared;
			}
		}
	}

	public IAsyncResult BeginPrepareUpdates(AsyncCallback callback, object state)
	{
		UpdateProcessAsyncResult ar = new UpdateProcessAsyncResult(callback, state);
		ThreadPool.QueueUserWorkItem(delegate
		{
			try
			{
				PrepareUpdates();
				ar.SetAsCompleted(null, completedSynchronously: false);
			}
			catch (Exception exception)
			{
				ar.SetAsCompleted(exception, completedSynchronously: false);
			}
		}, ar);
		return ar;
	}

	public void EndPrepareUpdates(IAsyncResult asyncResult)
	{
		UpdateProcessAsyncResult updateProcessAsyncResult = (UpdateProcessAsyncResult)asyncResult;
		updateProcessAsyncResult.EndInvoke();
	}

	public void ApplyUpdates()
	{
		ApplyUpdates(relaunchApplication: true);
	}

	public void ApplyUpdates(bool relaunchApplication)
	{
		ApplyUpdates(relaunchApplication, updaterDoLogging: false, updaterShowConsole: false);
	}

	public void ApplyUpdates(bool relaunchApplication, bool updaterDoLogging, bool updaterShowConsole)
	{
		if (IsWorking)
		{
			throw new InvalidOperationException("Another update process is already in progress");
		}
		lock (UpdatesToApply)
		{
			using (WorkScope.New(delegate(bool isWorking)
			{
				IsWorking = isWorking;
			}))
			{
				bool flag = true;
				Environment.CurrentDirectory = Path.GetDirectoryName(ApplicationPath);
				string path = Path.GetDirectoryName(Config.BackupFolder) ?? string.Empty;
				if (Directory.Exists(path) && PermissionsCheck.HaveWritePermissionsForFolder(path))
				{
					try
					{
						if (Directory.Exists(Config.BackupFolder))
						{
							FileSystem.DeleteDirectory(Config.BackupFolder);
						}
						flag = false;
					}
					catch (UnauthorizedAccessException)
					{
					}
					try
					{
						Directory.CreateDirectory(Config.BackupFolder);
						if (!PermissionsCheck.HaveWritePermissionsForFolder(Config.BackupFolder))
						{
							flag = true;
						}
					}
					catch (UnauthorizedAccessException)
					{
						flag = true;
					}
				}
				if (flag)
				{
					Config._backupFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Config.UpdateProcessName + "UpdateBackups" + DateTime.UtcNow.Ticks);
					try
					{
						Directory.CreateDirectory(Config.BackupFolder);
					}
					catch (UnauthorizedAccessException ex3)
					{
						throw new UpdateProcessFailedException("Could not create backup folder " + Config.BackupFolder, ex3);
					}
				}
				bool flag2 = false;
				bool flag3 = false;
				State = UpdateProcessState.RollbackRequired;
				foreach (IUpdateTask item in UpdatesToApply)
				{
					IUpdateTask t = item;
					item.ProgressDelegate += delegate(UpdateProgressInfo status)
					{
						TaskProgressCallback(status, t);
					};
					try
					{
						item.ExecutionStatus = item.Execute(coldRun: false);
					}
					catch (Exception ex4)
					{
						item.ExecutionStatus = TaskExecutionStatus.Failed;
						throw new UpdateProcessFailedException("Update task execution failed: " + item.Description, ex4);
					}
					if (item.ExecutionStatus == TaskExecutionStatus.RequiresAppRestart || item.ExecutionStatus == TaskExecutionStatus.RequiresPrivilegedAppRestart)
					{
						flag2 = flag2 || item.ExecutionStatus == TaskExecutionStatus.RequiresPrivilegedAppRestart;
						flag3 = true;
					}
					else if (item.ExecutionStatus != TaskExecutionStatus.Successful)
					{
						throw new UpdateProcessFailedException("Update task execution failed: " + item.Description);
					}
				}
				if (flag3)
				{
					NauIpc.NauDto nauDto = new NauIpc.NauDto();
					nauDto.Configs = Instance.Config;
					nauDto.Tasks = Instance.UpdatesToApply;
					nauDto.AppPath = ApplicationPath;
					nauDto.WorkingDirectory = Environment.CurrentDirectory;
					nauDto.RelaunchApplication = relaunchApplication;
					nauDto.LogItems = Logger.LogItems;
					NauIpc.NauDto dto = nauDto;
					NauIpc.ExtractUpdaterFromResource(Config.TempFolder, Instance.Config.UpdateExecutableName);
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.UseShellExecute = true;
					processStartInfo.WorkingDirectory = Environment.CurrentDirectory;
					processStartInfo.FileName = Path.Combine(Config.TempFolder, Instance.Config.UpdateExecutableName);
					processStartInfo.Arguments = string.Format("\"{0}\" {1} {2}", Config.UpdateProcessName, updaterShowConsole ? "-showConsole" : string.Empty, updaterDoLogging ? "-log" : string.Empty);
					ProcessStartInfo processStartInfo2 = processStartInfo;
					if (!updaterShowConsole)
					{
						processStartInfo2.WindowStyle = ProcessWindowStyle.Hidden;
						processStartInfo2.CreateNoWindow = true;
					}
					if (flag2 || !PermissionsCheck.HaveWritePermissionsForFolder(Environment.CurrentDirectory))
					{
						processStartInfo2.Verb = "runas";
					}
					_shutdownMutex = new Mutex(initiallyOwned: true, Config.UpdateProcessName + "Mutex", out var _);
					try
					{
						NauIpc.LaunchProcessAndSendDto(dto, processStartInfo2, Config.UpdateProcessName);
					}
					catch (Exception ex5)
					{
						throw new UpdateProcessFailedException("Could not launch cold update process", ex5);
					}
					Environment.Exit(0);
				}
				State = UpdateProcessState.AppliedSuccessfully;
				UpdatesToApply.Clear();
			}
		}
	}

	public void ReinstateIfRestarted()
	{
		lock (UpdatesToApply)
		{
			if (NauIpc.ReadDto(Config.UpdateProcessName) is NauIpc.NauDto nauDto)
			{
				Config = nauDto.Configs;
				UpdatesToApply = nauDto.Tasks;
				Logger = new Logger(nauDto.LogItems);
				State = UpdateProcessState.AfterRestart;
			}
		}
	}

	public void RollbackUpdates()
	{
		if (IsWorking)
		{
			return;
		}
		lock (UpdatesToApply)
		{
			foreach (IUpdateTask item in UpdatesToApply)
			{
				item.Rollback();
			}
			State = UpdateProcessState.NotChecked;
		}
	}

	public void Abort()
	{
		Abort(waitForTermination: false);
	}

	public void Abort(bool waitForTermination)
	{
		ShouldStop = true;
	}

	public void CleanUp()
	{
		Abort(waitForTermination: true);
		lock (UpdatesToApply)
		{
			UpdatesToApply.Clear();
			State = UpdateProcessState.NotChecked;
			try
			{
				if (Directory.Exists(Config.TempFolder))
				{
					FileSystem.DeleteDirectory(Config.TempFolder);
				}
			}
			catch
			{
			}
			try
			{
				if (Directory.Exists(Config.BackupFolder))
				{
					FileSystem.DeleteDirectory(Config.BackupFolder);
				}
			}
			catch
			{
			}
			ShouldStop = false;
		}
	}
}
