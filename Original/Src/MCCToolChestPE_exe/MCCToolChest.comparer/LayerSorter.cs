using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.comparer;

public class LayerSorter : IComparer
{
	public int Column;

	public SortOrder Order;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int Compare(object x, object y)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!(x is ListViewItem))
		{
			return 0;
		}
		if (!(y is ListViewItem))
		{
			return 0;
		}
		ListViewItem listViewItem = (ListViewItem)x;
		ListViewItem listViewItem2 = (ListViewItem)y;
		float value = float.Parse(listViewItem.SubItems[Column].Text);
		float value2 = float.Parse(listViewItem2.SubItems[Column].Text);
		if (Order == SortOrder.Ascending)
		{
			return value.CompareTo(value2);
		}
		return value2.CompareTo(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LayerSorter()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Order = SortOrder.Descending;
	}
}
