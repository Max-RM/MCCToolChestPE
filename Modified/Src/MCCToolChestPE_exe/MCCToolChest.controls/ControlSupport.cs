using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class ControlSupport
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsInRuntimeMode(IComponent component)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = IsInDesignMode(component);
		return !flag;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsInDesignMode(IComponent component)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		if (component != null)
		{
			ISite site = component.Site;
			if (site != null)
			{
				result = site.DesignMode;
			}
			else if (component is Control)
			{
				IComponent parent = ((Control)component).Parent;
				result = IsInDesignMode(parent);
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ControlSupport()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
