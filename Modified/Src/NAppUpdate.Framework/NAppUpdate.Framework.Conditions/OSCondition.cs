using System;
using System.Runtime.InteropServices;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Tasks;

namespace NAppUpdate.Framework.Conditions;

[Serializable]
public class OSCondition : IUpdateCondition, INauFieldsHolder
{
	[NauField("bit", "File size to compare with (in bytes)", true)]
	public int OsBits { get; set; }

	public bool IsMet(IUpdateTask task)
	{
		bool flag = Is64BitOperatingSystem();
		if (OsBits == 32 && OsBits != 64)
		{
			return true;
		}
		if (OsBits == 32 && flag)
		{
			return false;
		}
		if (OsBits == 64 && !flag)
		{
			return false;
		}
		return true;
	}

	public static bool Is64BitOperatingSystem()
	{
		if (IntPtr.Size == 8)
		{
			return true;
		}
		if (DoesWin32MethodExist("kernel32.dll", "IsWow64Process") && IsWow64Process(GetCurrentProcess(), out var wow64Process))
		{
			return wow64Process;
		}
		return false;
	}

	private static bool DoesWin32MethodExist(string moduleName, string methodName)
	{
		IntPtr moduleHandle = GetModuleHandle(moduleName);
		if (moduleHandle == IntPtr.Zero)
		{
			return false;
		}
		return GetProcAddress(moduleHandle, methodName) != IntPtr.Zero;
	}

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetCurrentProcess();

	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr GetModuleHandle(string moduleName);

	[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string procName);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);
}
