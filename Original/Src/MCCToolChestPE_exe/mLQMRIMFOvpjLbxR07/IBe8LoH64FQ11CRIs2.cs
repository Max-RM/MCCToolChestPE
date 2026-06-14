using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using YBh7EaXMWmkFRJOX37M;

namespace mLQMRIMFOvpjLbxR07;

internal class IBe8LoH64FQ11CRIs2 : ComboBox
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public IBe8LoH64FQ11CRIs2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		base.DrawMode = DrawMode.OwnerDrawFixed;
		base.DropDownStyle = ComboBoxStyle.DropDownList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDrawItem(DrawItemEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.DrawBackground();
		P_0.DrawFocusRectangle();
		if (P_0.Index >= 0 && P_0.Index < base.Items.Count)
		{
			DropDownItem dropDownItem = (DropDownItem)base.Items[P_0.Index];
			P_0.Graphics.DrawImage(dropDownItem.Image, P_0.Bounds.Left, P_0.Bounds.Top);
			P_0.Graphics.DrawString(dropDownItem.Text, P_0.Font, new SolidBrush(P_0.ForeColor), P_0.Bounds.Left + dropDownItem.Image.Width, P_0.Bounds.Top + 2);
		}
		base.OnDrawItem(P_0);
	}
}
