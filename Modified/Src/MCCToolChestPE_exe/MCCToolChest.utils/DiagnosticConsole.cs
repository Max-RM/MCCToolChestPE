using System;
using System.IO;
using System.Runtime.InteropServices;

namespace MCCToolChest.utils;

internal static class DiagnosticConsole
{
	private static bool _attached;

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool AllocConsole();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool AttachConsole(int dwProcessId);

	private const int AttachParentProcess = -1;

	internal static void TryAttach(string[] args)
	{
		if (_attached || args == null)
		{
			return;
		}
		for (int i = 0; i < args.Length; i++)
		{
			if (string.Equals(args[i], "-console", StringComparison.OrdinalIgnoreCase))
			{
				Attach();
				return;
			}
		}
	}

	internal static void Attach()
	{
		if (_attached)
		{
			return;
		}
		if (!AttachConsole(AttachParentProcess))
		{
			AllocConsole();
		}
		Console.Out.WriteLine("MCCToolChestPE diagnostic console enabled.");
		Console.Out.Flush();
		_attached = true;
	}

	internal static void WriteLine(string message)
	{
		if (!_attached)
		{
			return;
		}
		Console.Out.WriteLine(message);
		Console.Out.Flush();
	}

	internal static void WriteException(Exception ex, string context)
	{
		string text = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + context + Environment.NewLine + ex;
		try
		{
			W7XEw1ukTn4yRrm2wV4.VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(text);
		}
		catch
		{
		}
		WriteLine(text);
	}
}
