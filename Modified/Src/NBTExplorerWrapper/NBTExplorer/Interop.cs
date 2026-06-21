using System;

namespace NBTExplorer;

internal static class Interop
{
	public static bool WinInteropAvailable
	{
		get
		{
			if (IsWindows)
			{
				return Type.GetType("Mono.Runtime") == null;
			}
			return false;
		}
	}

	public static bool IsWindows => Environment.OSVersion.Platform == PlatformID.Win32NT;

	public static bool IsWinXP
	{
		get
		{
			OperatingSystem oSVersion = Environment.OSVersion;
			if (oSVersion.Platform == PlatformID.Win32NT)
			{
				if (oSVersion.Version.Major <= 5)
				{
					if (oSVersion.Version.Major == 5)
					{
						return oSVersion.Version.Minor == 1;
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public static bool IsWinVista
	{
		get
		{
			OperatingSystem oSVersion = Environment.OSVersion;
			if (oSVersion.Platform == PlatformID.Win32NT)
			{
				return oSVersion.Version.Major >= 6;
			}
			return false;
		}
	}

	public static IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
	{
		if (WinInteropAvailable)
		{
			return NativeInterop.SendMessage(hWnd, msg, wParam, lParam);
		}
		return IntPtr.Zero;
	}
}
