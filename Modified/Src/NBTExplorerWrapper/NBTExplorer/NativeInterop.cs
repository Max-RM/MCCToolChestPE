using System;
using System.Runtime.InteropServices;

namespace NBTExplorer;

internal static class NativeInterop
{
	public const int WM_PRINTCLIENT = 792;

	public const int PRF_CLIENT = 4;

	public const int TV_FIRST = 4352;

	public const int TVM_SETBKCOLOR = 4381;

	public const int TVM_SETEXTENDEDSTYLE = 4396;

	public const int TVS_EX_DOUBLEBUFFER = 4;

	[DllImport("user32.dll")]
	public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
}
