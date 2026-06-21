using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MCCToolChest.utils;

public static class NativeMethods
{
	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	internal static extern IntPtr ESISRmnoepe(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Scroll(this Control control)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Point point = control.PointToClient(Cursor.Position);
		if (point.Y + 20 > control.Height)
		{
			ESISRmnoepe(control.Handle, 277u, (IntPtr)1, (IntPtr)0);
		}
		else if (point.Y < 20)
		{
			ESISRmnoepe(control.Handle, 277u, (IntPtr)0, (IntPtr)0);
		}
	}
}
