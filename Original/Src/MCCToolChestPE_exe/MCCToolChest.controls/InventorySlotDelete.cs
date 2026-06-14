using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class InventorySlotDelete : InventorySlot
{
	private Image nHp2gaD5Vw;

	private Image gDj2PPkhZn;

	private Action<InventorySlot> cMl2Ru7FF5;

	private IContainer LRX2koeRu7;

	[CompilerGenerated]
	private static Action<InventorySlot> pDR2YsYh0h;

	public event Action<InventorySlot> DeleteDone
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Action<InventorySlot> action = cMl2Ru7FF5;
			Action<InventorySlot> action2;
			do
			{
				action2 = action;
				Action<InventorySlot> value2 = (Action<InventorySlot>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref cMl2Ru7FF5, value2, action2);
			}
			while ((object)action != action2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Action<InventorySlot> action = cMl2Ru7FF5;
			Action<InventorySlot> action2;
			do
			{
				action2 = action;
				Action<InventorySlot> value2 = (Action<InventorySlot>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref cMl2Ru7FF5, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventorySlotDelete(Image enabled, Image disabled) : base(byte.MaxValue, null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		cMl2Ru7FF5 = [MethodImpl(MethodImplOptions.NoInlining)] (InventorySlot P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
		};
		nHp2gaD5Vw = enabled;
		gDj2PPkhZn = disabled;
		base.Enabled = false;
		InventorySlot.DragBegin += [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			base.Enabled = true;
			Refresh();
		};
		InventorySlot.DragEnd += [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			base.Enabled = false;
			Refresh();
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEnabledChanged(EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnEnabledChanged(e);
		base.Default = (base.Enabled ? nHp2gaD5Vw : gDj2PPkhZn);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDragOver(DragEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnDragOver(e);
		if (e.Effect != DragDropEffects.Move)
		{
			e.Effect = DragDropEffects.Move;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDragDrop(DragEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		InventorySlot.other = null;
		cMl2Ru7FF5(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && LRX2koeRu7 != null)
		{
			LRX2koeRu7.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void x3f2eo0u5K()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LRX2koeRu7 = new Container();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static void k812MchgDM(InventorySlot P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private void L132UeM5iL()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Enabled = true;
		Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private void JWG2LQo3bg()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Enabled = false;
		Refresh();
	}
}
