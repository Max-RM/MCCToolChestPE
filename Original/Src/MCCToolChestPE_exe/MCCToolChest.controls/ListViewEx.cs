using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class ListViewEx : ListView
{
	private int AbABb5mnl8;

	private int PDQBvKdEJg;

	public int LineBefore
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return AbABb5mnl8;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			AbABb5mnl8 = value;
		}
	}

	public int LineAfter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return PDQBvKdEJg;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			PDQBvKdEJg = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ListViewEx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		AbABb5mnl8 = -1;
		PDQBvKdEJg = -1;
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void WndProc(ref Message m)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.WndProc(ref m);
		if (m.Msg == 15)
		{
			if (LineBefore >= 0 && LineBefore < base.Items.Count)
			{
				Rectangle bounds = base.Items[LineBefore].GetBounds(ItemBoundsPortion.Entire);
				yC0BGmXLjC(bounds.Left, bounds.Right, bounds.Top);
			}
			if (LineAfter >= 0 && LineBefore < base.Items.Count)
			{
				Rectangle bounds2 = base.Items[LineAfter].GetBounds(ItemBoundsPortion.Entire);
				yC0BGmXLjC(bounds2.Left, bounds2.Right, bounds2.Bottom);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yC0BGmXLjC(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using Graphics graphics = CreateGraphics();
		graphics.DrawLine(Pens.Red, P_0, P_2, P_1 - 1, P_2);
		Point[] points = new Point[3]
		{
			new Point(P_0, P_2 - 4),
			new Point(P_0 + 7, P_2),
			new Point(P_0, P_2 + 4)
		};
		Point[] points2 = new Point[3]
		{
			new Point(P_1, P_2 - 4),
			new Point(P_1 - 8, P_2),
			new Point(P_1, P_2 + 4)
		};
		graphics.FillPolygon(Brushes.Red, points);
		graphics.FillPolygon(Brushes.Red, points2);
	}
}
