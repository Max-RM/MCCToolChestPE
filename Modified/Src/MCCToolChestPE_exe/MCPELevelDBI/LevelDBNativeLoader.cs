using System;
using System.IO;

namespace MCPELevelDBI;

internal static class LevelDBNativeLoader
{
	private static bool _initialized;

	internal static void EnsureLoaded()
	{
		if (_initialized)
		{
			return;
		}
		_initialized = true;
		try
		{
			string baseDir = AppDomain.CurrentDomain.BaseDirectory;
			if (IsArm64Process())
			{
				CopyNativeDll(baseDir, "LevelDB-MCPE-ARM64.dll", "LevelDB-MCPE-64.dll");
			}
			else if (IsArm32Process())
			{
				CopyNativeDll(baseDir, "LevelDB-MCPE-ARM32.dll", "LevelDB-MCPE-32.dll");
				CopyNativeDll(baseDir, "zlib-arm32.dll", "zlib.dll");
			}
		}
		catch
		{
		}
	}

	private static void CopyNativeDll(string baseDir, string sourceName, string targetName)
	{
		string sourceDll = Path.Combine(baseDir, sourceName);
		string targetDll = Path.Combine(baseDir, targetName);
		if (File.Exists(sourceDll))
		{
			File.Copy(sourceDll, targetDll, overwrite: true);
		}
	}

	private static bool IsArm64Process()
	{
		return IntPtr.Size == 8 && string.Equals(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"), "ARM64", StringComparison.OrdinalIgnoreCase);
	}

	private static bool IsArm32Process()
	{
		return IntPtr.Size == 4 && string.Equals(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"), "ARM", StringComparison.OrdinalIgnoreCase);
	}
}
