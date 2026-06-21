using System.Diagnostics;

namespace Be.Windows.Forms;

internal static class Util
{
	private static bool _designMode;

	public static bool DesignMode => _designMode;

	static Util()
	{
		_designMode = Process.GetCurrentProcess().ProcessName.ToLower() == "devenv";
	}
}
