using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using YBh7EaXMWmkFRJOX37M;

public class ListViewColumnSorter : IComparer
{
	private int xVvSRquYeWG;

	private SortOrder et4SRKEnXxL;

	private CaseInsensitiveComparer SajSRhXlQDr;

	public int SortColumn
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return xVvSRquYeWG;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			xVvSRquYeWG = value;
		}
	}

	public SortOrder Order
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return et4SRKEnXxL;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			et4SRKEnXxL = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ListViewColumnSorter()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		xVvSRquYeWG = 0;
		et4SRKEnXxL = SortOrder.None;
		SajSRhXlQDr = new CaseInsensitiveComparer();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int Compare(object x, object y)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewItem listViewItem = (ListViewItem)x;
		ListViewItem listViewItem2 = (ListViewItem)y;
		int num = SajSRhXlQDr.Compare(listViewItem.SubItems[xVvSRquYeWG].Text, listViewItem2.SubItems[xVvSRquYeWG].Text);
		if (et4SRKEnXxL == SortOrder.Ascending)
		{
			return num;
		}
		if (et4SRKEnXxL == SortOrder.Descending)
		{
			return -num;
		}
		return 0;
	}
}
