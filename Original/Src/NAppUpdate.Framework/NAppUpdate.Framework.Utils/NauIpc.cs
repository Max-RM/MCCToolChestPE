using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Tasks;

namespace NAppUpdate.Framework.Utils;

internal static class NauIpc
{
	[Serializable]
	internal class NauDto
	{
		public NauConfigurations Configs { get; set; }

		public IList<IUpdateTask> Tasks { get; set; }

		public List<Logger.LogItem> LogItems { get; set; }

		public string AppPath { get; set; }

		public string WorkingDirectory { get; set; }

		public bool RelaunchApplication { get; set; }
	}

	private class State
	{
		public readonly EventWaitHandle eventWaitHandle;

		public int result { get; set; }

		public SafeFileHandle clientPipeHandle { get; set; }

		public State()
		{
			eventWaitHandle = new ManualResetEvent(initialState: false);
		}
	}

	private const uint WRITE_ONLY = 2u;

	private const uint FILE_FLAG_OVERLAPPED = 1073741824u;

	private const uint GENERIC_READ = 2147483648u;

	private const uint OPEN_EXISTING = 3u;

	private const uint ERROR_PIPE_CONNECTED = 535u;

	internal static uint BUFFER_SIZE = 4096u;

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern SafeFileHandle CreateNamedPipe(string pipeName, uint dwOpenMode, uint dwPipeMode, uint nMaxInstances, uint nOutBufferSize, uint nInBufferSize, uint nDefaultTimeOut, IntPtr lpSecurityAttributes);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern int ConnectNamedPipe(SafeFileHandle hNamedPipe, IntPtr lpOverlapped);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern SafeFileHandle CreateFile(string pipeName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplate);

	internal static string GetPipeName(string syncProcessName)
	{
		return $"\\\\.\\pipe\\{syncProcessName}";
	}

	public static Process LaunchProcessAndSendDto(NauDto dto, ProcessStartInfo processStartInfo, string syncProcessName)
	{
		State state = new State();
		SafeFileHandle safeFileHandle = (state.clientPipeHandle = CreateNamedPipe(GetPipeName(syncProcessName), 1073741826u, 0u, 1u, BUFFER_SIZE, BUFFER_SIZE, 0u, IntPtr.Zero));
		using (safeFileHandle)
		{
			if (state.clientPipeHandle.IsInvalid)
			{
				throw new Exception("Launch process client: Failed to create named pipe, handle is invalid.");
			}
			Process result = Process.Start(processStartInfo);
			ThreadPool.QueueUserWorkItem(ConnectPipe, state);
			state.eventWaitHandle.WaitOne(10000);
			if (state.result == 0)
			{
				throw new Exception("Launch process client: Failed to connect to named pipe");
			}
			using FileStream fileStream = new FileStream(state.clientPipeHandle, FileAccess.Write, (int)BUFFER_SIZE, isAsync: true);
			new BinaryFormatter().Serialize(fileStream, dto);
			fileStream.Flush();
			fileStream.Close();
			return result;
		}
	}

	internal static void ConnectPipe(object stateObject)
	{
		if (stateObject != null)
		{
			State state = (State)stateObject;
			try
			{
				state.result = ConnectNamedPipe(state.clientPipeHandle, IntPtr.Zero);
			}
			catch
			{
			}
			if ((long)Marshal.GetLastWin32Error() == 535)
			{
				state.result = 1;
			}
			state.eventWaitHandle.Set();
		}
	}

	internal static object ReadDto(string syncProcessName)
	{
		using SafeFileHandle safeFileHandle = CreateFile(GetPipeName(syncProcessName), 2147483648u, 0u, IntPtr.Zero, 3u, 1073741824u, IntPtr.Zero);
		if (safeFileHandle.IsInvalid)
		{
			return null;
		}
		using FileStream serializationStream = new FileStream(safeFileHandle, FileAccess.Read, (int)BUFFER_SIZE, isAsync: true);
		return new BinaryFormatter().Deserialize(serializationStream);
	}

	internal static void ExtractUpdaterFromResource(string updaterPath, string hostExeName)
	{
		if (!Directory.Exists(updaterPath))
		{
			Directory.CreateDirectory(updaterPath);
		}
		using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(Path.Combine(updaterPath, hostExeName), FileMode.Create)))
		{
			binaryWriter.Write(Resources.updater);
		}
		string location = typeof(NauIpc).Assembly.Location;
		File.Copy(location, Path.Combine(updaterPath, "NAppUpdate.Framework.dll"), overwrite: true);
		string path = Path.GetDirectoryName(location) ?? string.Empty;
		if (UpdateManager.Instance.Config.DependenciesForColdUpdate == null)
		{
			return;
		}
		foreach (string item in UpdateManager.Instance.Config.DependenciesForColdUpdate)
		{
			string text = Path.Combine(path, item);
			if (File.Exists(text))
			{
				string path2 = Path.Combine(updaterPath, item);
				FileSystem.CreateDirectoryStructure(path2);
				File.Copy(text, Path.Combine(updaterPath, item), overwrite: true);
			}
		}
	}
}
