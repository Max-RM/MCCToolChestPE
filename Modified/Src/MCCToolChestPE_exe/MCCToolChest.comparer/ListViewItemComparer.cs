using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.comparer;

public class ListViewItemComparer : IComparer
{
	private int d1sqn5mju;

	private SortOrder iUjKdXi4d;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ListViewItemComparer()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		d1sqn5mju = 0;
		iUjKdXi4d = SortOrder.Ascending;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ListViewItemComparer(int column, SortOrder order)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		d1sqn5mju = column;
		iUjKdXi4d = order;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int Compare(object x, object y)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = -1;
		num = string.Compare(((ListViewItem)x).SubItems[d1sqn5mju].Text, ((ListViewItem)y).SubItems[d1sqn5mju].Text);
		if (iUjKdXi4d == SortOrder.Descending)
		{
			num *= -1;
		}
		return num;
	}
}
