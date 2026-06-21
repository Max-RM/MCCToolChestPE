using System.Drawing;
using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public class GraphicHelpers
{
	private static Font XymSRvBc27o;

	private static Font EdMSRwPQ9dy;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DrawString(Graphics g, Color color, int x, int y, string text)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		g.DrawString(text, XymSRvBc27o, new SolidBrush(color), x + 2, y + 1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DrawString2(Graphics g, Color color, int x, int y, string text)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Far;
		stringFormat.LineAlignment = StringAlignment.Far;
		StringFormat format = stringFormat;
		g.DrawString(text, EdMSRwPQ9dy, new SolidBrush(color), 44 - x, 44 - y, format);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DrawString3(Graphics g, Color color, int x, int y, string text)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		StringFormat format = stringFormat;
		g.DrawString(text, XymSRvBc27o, new SolidBrush(color), x, 10 + y, format);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GraphicHelpers()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GraphicHelpers()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		XymSRvBc27o = new Font(FontFamily.GenericMonospace, 14f, FontStyle.Bold);
		EdMSRwPQ9dy = new Font(FontFamily.GenericMonospace, 16f, FontStyle.Bold);
	}
}
