using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.model;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class InventorySlot : CheckBox
{
	private InventoryItemInfo KKw2q2rafM;

	private static Font Hn92KcRThS;

	private static Font Re62hGy15O;

	protected static InventoryItem other;

	private static Action VhE2mSrim3;

	private static Action VZj2nwFfmg;

	private InventoryItem lLy2lrbWs9;

	private Action<bool> y5D22SiKTn;

	private IContainer iHv2yFOMRH;

	[CompilerGenerated]
	private bool sDr20piIIi;

	[CompilerGenerated]
	private byte MNF2BBGMaO;

	[CompilerGenerated]
	private Image axB2tLfx5e;

	[CompilerGenerated]
	private static Action<bool> aeT2avW33Y;

	[CompilerGenerated]
	private static Action kqH2XfnqtI;

	[CompilerGenerated]
	private static Action crD2xhSpDH;

	public InventoryItem InventoryItem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return lLy2lrbWs9;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			lLy2lrbWs9 = value;
		}
	}

	public bool Selected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return sDr20piIIi;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			sDr20piIIi = value;
		}
	}

	public byte Slot
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return MNF2BBGMaO;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			MNF2BBGMaO = value;
		}
	}

	public Image Default
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return axB2tLfx5e;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			axB2tLfx5e = value;
		}
	}

	protected static event Action DragBegin
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Action action = VhE2mSrim3;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref VhE2mSrim3, value2, action2);
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
			Action action = VhE2mSrim3;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref VhE2mSrim3, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	protected static event Action DragEnd
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Action action = VZj2nwFfmg;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref VZj2nwFfmg, value2, action2);
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
			Action action = VZj2nwFfmg;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref VZj2nwFfmg, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public event Action<bool> Changed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Action<bool> action = y5D22SiKTn;
			Action<bool> action2;
			do
			{
				action2 = action;
				Action<bool> value2 = (Action<bool>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref y5D22SiKTn, value2, action2);
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
			Action<bool> action = y5D22SiKTn;
			Action<bool> action2;
			do
			{
				action2 = action;
				Action<bool> value2 = (Action<bool>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref y5D22SiKTn, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventorySlot(byte slot, InventoryItemInfo itemInfo)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		y5D22SiKTn = [MethodImpl(MethodImplOptions.NoInlining)] (bool P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
		};
		Slot = slot;
		base.Size = new Size(48, 48);
		base.Appearance = Appearance.Button;
		BackColor = Color.WhiteSmoke;
		KKw2q2rafM = itemInfo;
		AllowDrop = true;
		base.TabStop = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void N062wIcgD9()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		y5D22SiKTn(obj: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseDown(MouseEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.LostFocus += YCM24GuMlY;
		if (InventoryItem == null)
		{
			return;
		}
		switch (e.Button)
		{
		case MouseButtons.Left:
		{
			base.Checked = true;
			VhE2mSrim3();
			other = InventoryItem;
			DragDropEffects dragDropEffects = DoDragDrop(InventoryItem, DragDropEffects.Copy | DragDropEffects.Move | DragDropEffects.Link);
			VZj2nwFfmg();
			if (dragDropEffects == DragDropEffects.Move)
			{
				InventoryItem = other;
				y5D22SiKTn(obj: false);
			}
			base.Checked = false;
			break;
		}
		case MouseButtons.Right:
			InventoryItem.Count = InventoryItem.Stack;
			break;
		}
		Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YCM24GuMlY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.LostFocus -= YCM24GuMlY;
		Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnKeyDown(KeyEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if ((e.KeyCode & Keys.Delete) == Keys.Delete && InventoryItem != null)
		{
			InventoryItem = null;
			y5D22SiKTn(obj: false);
			Refresh();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDragOver(DragEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (e.Data.GetDataPresent(typeof(InventoryItem)))
		{
			InventoryItem inventoryItem = (InventoryItem)e.Data.GetData(typeof(InventoryItem));
			if (InventoryItem != inventoryItem)
			{
				if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
				{
					if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
					{
						e.Effect = DragDropEffects.Copy;
					}
					else if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt && inventoryItem.Count > 1)
					{
						if (InventoryItem != null)
						{
							if (InventoryItem.ID == inventoryItem.ID && InventoryItem.Count <= inventoryItem.Stack)
							{
								e.Effect = DragDropEffects.Link;
							}
							else
							{
								e.Effect = DragDropEffects.None;
							}
						}
						else
						{
							e.Effect = DragDropEffects.Link;
						}
					}
					else if (InventoryItem != null && InventoryItem.ID == inventoryItem.ID && InventoryItem.Damage == inventoryItem.Damage && InventoryItem.Count >= InventoryItem.Stack)
					{
						e.Effect = DragDropEffects.None;
					}
					else
					{
						e.Effect = DragDropEffects.Move;
					}
				}
				else
				{
					e.Effect = DragDropEffects.Copy;
				}
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDragDrop(DragEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnDragOver(e);
		if (e.Effect == DragDropEffects.None)
		{
			return;
		}
		InventoryItem inventoryItem = (InventoryItem)e.Data.GetData(typeof(InventoryItem));
		if (e.Effect == DragDropEffects.Link)
		{
			if (InventoryItem == null)
			{
				InventoryItem = new InventoryItem(inventoryItem.Tag);
				InventoryItem.Slot = Slot;
				InventoryItem.Count -= (byte)(inventoryItem.Count / 2);
				inventoryItem.Count -= InventoryItem.Count;
			}
			else
			{
				byte count = InventoryItem.Count;
				InventoryItem.Count = Math.Min((byte)(count + inventoryItem.Count / 2), (byte)64);
				inventoryItem.Count -= (byte)(InventoryItem.Count - count);
			}
		}
		else if (e.Effect == DragDropEffects.Move && InventoryItem != null && inventoryItem.ID == InventoryItem.ID && InventoryItem.Damage == inventoryItem.Damage)
		{
			byte count2 = (byte)Math.Min(InventoryItem.Count + inventoryItem.Count, inventoryItem.Stack);
			byte b = (byte)Math.Max(InventoryItem.Count + inventoryItem.Count - inventoryItem.Stack, 0);
			InventoryItem = new InventoryItem(InventoryItem.Tag);
			InventoryItem.Slot = Slot;
			InventoryItem.Count = count2;
			if (b > 0)
			{
				other.Count = b;
			}
			else
			{
				other = null;
			}
		}
		else
		{
			other = InventoryItem;
			InventoryItem = inventoryItem;
			if (e.Effect == DragDropEffects.Copy)
			{
				InventoryItem = new InventoryItem(InventoryItem.Tag);
				InventoryItem.Slot = Slot;
			}
			else
			{
				InventoryItem.Slot = Slot;
			}
		}
		base.LostFocus += YCM24GuMlY;
		try
		{
			y5D22SiKTn(obj: false);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
		Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseWheel(MouseEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (InventoryItem == null)
		{
			return;
		}
		int num = (((Control.ModifierKeys & Keys.Control) != Keys.Control) ? 1 : 4) * Math.Sign(e.Delta);
		if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
		{
			int damage = InventoryItem.Damage;
			if (InventoryItem.MaxDamage > 0)
			{
				InventoryItem.Damage = (short)Math.Min(Math.Max(InventoryItem.Damage + Math.Max(Math.Abs(num * InventoryItem.MaxDamage / 32), 1) * -Math.Sign(num), 0), InventoryItem.MaxDamage);
			}
			else if (InventoryItem.Alternative)
			{
				Dictionary<short, InventoryItem> dictionary = new Dictionary<short, InventoryItem>();
				List<short> list = new List<short>(dictionary.Keys);
				int num2 = list.IndexOf(InventoryItem.Damage);
				if (num2 == -1)
				{
					return;
				}
				if (num > 0)
				{
					if (num2 < list.Count - 1)
					{
						InventoryItem.Damage = list[num2 + 1];
					}
				}
				else if (num2 > 0)
				{
					InventoryItem.Damage = list[num2 - 1];
				}
			}
			if (damage == InventoryItem.Damage)
			{
				return;
			}
		}
		else
		{
			if (InventoryItem.Stack == 1)
			{
				return;
			}
			int count = InventoryItem.Count;
			if (InventoryItem.Count == 1 && num == 4)
			{
				num = 3;
			}
			InventoryItem.Count = (byte)Math.Min(Math.Max(InventoryItem.Count + num, 1), InventoryItem.Stack);
			if (count == InventoryItem.Count)
			{
				return;
			}
		}
		y5D22SiKTn(obj: false);
		Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		if (Selected)
		{
			using Pen pen = new Pen(Color.Black);
			graphics.DrawRectangle(pen, 4, 4, base.Width - 9, base.Height - 9);
		}
		Image image = Default;
		if (InventoryItem != null)
		{
			image = InventoryItem.Image;
		}
		if (image == null)
		{
			return;
		}
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		graphics.PixelOffsetMode = PixelOffsetMode.Half;
		if (InventoryItem != null && InventoryItem.Enchanted)
		{
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, Color.SlateBlue)), 5, 5, base.Width - 10, base.Height - 10);
		}
		graphics.DrawImage(image, base.ClientSize.Width / 2 - 16, base.ClientSize.Height / 2 - 16, 32, 32);
		if (InventoryItem == null)
		{
			return;
		}
		if (!InventoryItem.Known)
		{
			string text = InventoryItem.ID.ToString();
			Color black = Color.Black;
			Color white = Color.White;
			HRd2p9Etoh(graphics, black, 0, -1, text);
			HRd2p9Etoh(graphics, black, 1, -1, text);
			HRd2p9Etoh(graphics, black, -1, 0, text);
			HRd2p9Etoh(graphics, black, 2, 0, text);
			HRd2p9Etoh(graphics, black, 0, 1, text);
			HRd2p9Etoh(graphics, black, 1, 1, text);
			HRd2p9Etoh(graphics, white, 0, 0, text);
			HRd2p9Etoh(graphics, white, 1, 0, text);
		}
		if (InventoryItem.Count > 1)
		{
			string text2 = InventoryItem.Count.ToString();
			Color color = Color.Black;
			Color white2 = Color.White;
			if (InventoryItem.Count > InventoryItem.Stack)
			{
				color = Color.FromArgb(172, 0, 0);
			}
			gJP2WCakI3(graphics, color, 3, 1, text2);
			gJP2WCakI3(graphics, color, 4, 1, text2);
			gJP2WCakI3(graphics, color, 2, 2, text2);
			gJP2WCakI3(graphics, color, 5, 2, text2);
			gJP2WCakI3(graphics, color, 3, 3, text2);
			gJP2WCakI3(graphics, color, 4, 3, text2);
			gJP2WCakI3(graphics, white2, 3, 2, text2);
			gJP2WCakI3(graphics, white2, 4, 2, text2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DD42VTo8JZ(Graphics P_0, Color P_1, int P_2, int P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.DrawString(P_4, Hn92KcRThS, new SolidBrush(P_1), P_2 + 2, P_3 + 1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gJP2WCakI3(Graphics P_0, Color P_1, int P_2, int P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Far;
		stringFormat.LineAlignment = StringAlignment.Far;
		StringFormat format = stringFormat;
		P_0.DrawString(P_4, Re62hGy15O, new SolidBrush(P_1), base.ClientSize.Width - P_2, base.ClientSize.Width - P_3, format);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HRd2p9Etoh(Graphics P_0, Color P_1, int P_2, int P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		StringFormat format = stringFormat;
		P_0.DrawString(P_4, Hn92KcRThS, new SolidBrush(P_1), base.ClientSize.Width / 2 + P_2, base.ClientSize.Width / 2 + P_3, format);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseEnter(EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseHover(EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseLeave(EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		KKw2q2rafM.Hide();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseMove(MouseEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (lLy2lrbWs9 != null)
		{
			KKw2q2rafM.Left = Cursor.Position.X;
			KKw2q2rafM.Top = Cursor.Position.Y + 16;
			KKw2q2rafM.showInfo(lLy2lrbWs9.Description());
			KKw2q2rafM.Show();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && iHv2yFOMRH != null)
		{
			iHv2yFOMRH.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IVx2Zuork5()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		iHv2yFOMRH = new Container();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static void P692f17Pyc(bool P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static InventorySlot()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Hn92KcRThS = new Font(FontFamily.GenericMonospace, 8f, FontStyle.Bold);
		Re62hGy15O = new Font(FontFamily.GenericMonospace, 10f, FontStyle.Bold);
		other = null;
		VhE2mSrim3 = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
		};
		VZj2nwFfmg = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static void qQM2ibF6Sv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static void NSY2sI9pD0()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}
}
