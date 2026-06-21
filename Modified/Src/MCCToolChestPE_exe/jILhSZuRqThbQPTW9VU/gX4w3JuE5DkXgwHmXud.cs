using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using hmmDliu9dFdK7umFciM;
using MCCToolChest;
using MCCToolChest.forms;
using MCCToolChest.utils;
using NsF2F1XiJAVBnudIoxZ;
using uL2B6CXB2hZQU16Di7r;
using W7XEw1ukTn4yRrm2wV4;
using YBh7EaXMWmkFRJOX37M;

namespace jILhSZuRqThbQPTW9VU;

internal static class gX4w3JuE5DkXgwHmXud
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	[STAThread]
	private static void Main(string[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yfs8Q5XRDNZPbwaTSae.kLjw4iIsCLsZtxc4lksN0j();
		Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88794);
		DiagnosticConsole.TryAttach(P_0);
		AppDomain.CurrentDomain.FirstChanceException += DAkSMY68qwK;
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		try
		{
			bool flag = true;
			foreach (string text in P_0)
			{
				if (text.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210138))
				{
					flag = false;
				}
			}
			if (flag)
			{
				Application.Run(new MainForm(P_0));
				return;
			}
			VltCOGuQyAkXFfTRwUS vltCOGuQyAkXFfTRwUS = new VltCOGuQyAkXFfTRwUS(P_0);
			vltCOGuQyAkXFfTRwUS.CVXSk0P0Sj1();
		}
		catch (Exception ex)
		{
			dyHSM3O6kN0(ex.Message, ex.StackTrace);
			MessageBox.Show(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void DAkSMY68qwK(object P_0, FirstChanceExceptionEventArgs P_1)
	{
		try
		{
			if (P_1.Exception.Message != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210150))
			{
				string text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210186), AppDomain.CurrentDomain.FriendlyName, P_1.Exception.Message);
				VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(text);
				DiagnosticConsole.WriteLine(text);
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void dyHSM3O6kN0(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210280), AppDomain.CurrentDomain.FriendlyName, P_0, P_1));
			ErrorLogViewer errorLogViewer = new ErrorLogViewer();
			errorLogViewer.ShowDialog();
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static gX4w3JuE5DkXgwHmXud()
	{
		yfs8Q5XRDNZPbwaTSae.kLjw4iIsCLsZtxc4lksN0j();
	}
}
