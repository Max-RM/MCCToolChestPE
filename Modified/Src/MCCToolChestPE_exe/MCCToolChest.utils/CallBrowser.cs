using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public class CallBrowser
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Call(string target)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			Process.Start(target);
		}
		catch (Win32Exception ex)
		{
			if (ex.ErrorCode == -2147467259)
			{
				MessageBox.Show(ex.Message);
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CallBrowser()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
