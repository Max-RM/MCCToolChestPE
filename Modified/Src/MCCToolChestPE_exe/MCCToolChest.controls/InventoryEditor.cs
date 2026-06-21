using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using HaI2p2xMqxTADue2UA;
using jWBDofdcGMieH0qfdS;
using MCCToolChest.model;
using MCCToolChest.Properties;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class InventoryEditor : UserControl
{
	private InventoryItemInfo qOSloC1puN;

	private InventoryType M03lQotlSB;

	public Dictionary<byte, InventorySlot> slots;

	private NumericUpDown yh1lOgphe1;

	private NumericUpDown Q22lCNujxP;

	private Jlxk34F1xl7DbN5CrR cNtl7BeZx9;

	private static Image qPalAAlebc;

	private static Image K8PldKuGrE;

	private static Image WbClHhdZhx;

	private static Image wEulFme8MQ;

	public InventorySlot selected;

	public bool changed;

	private Action<InventorySlot> VZ1ljHRHi7;

	private EnchantForm mK6l8HjpOH;

	private IContainer mBpl9yqbIK;

	private Panel bnTlISntCC;

	private Button G4xlzuOtfC;

	private ItemListUI RQB2TPDTOl;

	public InventoryType InventoryType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return M03lQotlSB;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			M03lQotlSB = value;
			Csblke9B3a();
		}
	}

	public event Action<InventorySlot> Changed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Action<InventorySlot> action = VZ1ljHRHi7;
			Action<InventorySlot> action2;
			do
			{
				action2 = action;
				Action<InventorySlot> value2 = (Action<InventorySlot>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref VZ1ljHRHi7, value2, action2);
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
			Action<InventorySlot> action = VZ1ljHRHi7;
			Action<InventorySlot> action2;
			do
			{
				action2 = action;
				Action<InventorySlot> value2 = (Action<InventorySlot>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref VZ1ljHRHi7, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventoryEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		qOSloC1puN = new InventoryItemInfo();
		slots = new Dictionary<byte, InventorySlot>();
		cNtl7BeZx9 = new Jlxk34F1xl7DbN5CrR();
		cRnlc3caLB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Csblke9B3a()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Button g4xlzuOtfC = G4xlzuOtfC;
		bnTlISntCC.Controls.Clear();
		bnTlISntCC.Controls.Add(g4xlzuOtfC);
		slots = new Dictionary<byte, InventorySlot>();
		bnTlISntCC.Controls.Add(new Label
		{
			Location = new Point(287, 19),
			Size = new Size(54, 20),
			Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21380),
			TextAlign = ContentAlignment.MiddleRight
		});
		bnTlISntCC.Controls.Add(new Label
		{
			Location = new Point(287, 44),
			Size = new Size(54, 20),
			Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21398),
			TextAlign = ContentAlignment.MiddleRight
		});
		yh1lOgphe1 = new NumericUpDown();
		yh1lOgphe1.Location = new Point(344, 21);
		yh1lOgphe1.Size = new Size(57, 20);
		yh1lOgphe1.Minimum = -32768m;
		yh1lOgphe1.Maximum = 32767m;
		yh1lOgphe1.TextAlign = HorizontalAlignment.Right;
		yh1lOgphe1.Enabled = false;
		bnTlISntCC.Controls.Add(yh1lOgphe1);
		Q22lCNujxP = new NumericUpDown();
		Q22lCNujxP.Location = new Point(344, 46);
		Q22lCNujxP.Size = new Size(57, 20);
		Q22lCNujxP.Minimum = 0m;
		Q22lCNujxP.Maximum = 255m;
		Q22lCNujxP.TextAlign = HorizontalAlignment.Right;
		Q22lCNujxP.Enabled = false;
		bnTlISntCC.Controls.Add(Q22lCNujxP);
		if (M03lQotlSB == InventoryType.PlayerInventory)
		{
			Na8lYljBti(103, 7, 19, qPalAAlebc);
			Na8lYljBti(102, 57, 19, K8PldKuGrE);
			Na8lYljBti(101, 107, 19, WbClHhdZhx);
			Na8lYljBti(100, 157, 19, wEulFme8MQ);
			for (int i = 0; i < 9; i++)
			{
				Na8lYljBti((byte)(36 + i), 7 + i * 50, -100);
			}
			for (int j = 0; j < 9; j++)
			{
				Na8lYljBti((byte)(9 + j), 7 + j * 50, 75);
			}
			for (int k = 0; k < 9; k++)
			{
				Na8lYljBti((byte)(18 + k), 7 + k * 50, 125);
			}
			for (int l = 0; l < 9; l++)
			{
				Na8lYljBti((byte)(27 + l), 7 + l * 50, 175);
			}
			for (int m = 0; m < 9; m++)
			{
				Na8lYljBti((byte)m, 7 + m * 50, 235);
			}
		}
		else if (M03lQotlSB == InventoryType.PlayerEnderInventory || M03lQotlSB == InventoryType.Standard)
		{
			for (int n = 0; n < 9; n++)
			{
				Na8lYljBti((byte)n, 7 + n * 50, 75);
			}
			for (int num = 0; num < 9; num++)
			{
				Na8lYljBti((byte)(9 + num), 7 + num * 50, 125);
			}
			for (int num2 = 0; num2 < 9; num2++)
			{
				Na8lYljBti((byte)(18 + num2), 7 + num2 * 50, 175);
			}
		}
		else if (M03lQotlSB == InventoryType.Medium)
		{
			for (int num3 = 0; num3 < 3; num3++)
			{
				Na8lYljBti((byte)num3, 7 + num3 * 50, 75);
			}
			for (int num4 = 0; num4 < 3; num4++)
			{
				Na8lYljBti((byte)(3 + num4), 7 + num4 * 50, 125);
			}
			for (int num5 = 0; num5 < 3; num5++)
			{
				Na8lYljBti((byte)(6 + num5), 7 + num5 * 50, 175);
			}
		}
		else if (M03lQotlSB == InventoryType.Small)
		{
			for (int num6 = 0; num6 < 5; num6++)
			{
				Na8lYljBti((byte)num6, 7 + num6 * 50, 75);
			}
		}
		else if (M03lQotlSB == InventoryType.Tiny)
		{
			for (int num7 = 0; num7 < 4; num7++)
			{
				Na8lYljBti((byte)num7, 7 + num7 * 50, 75);
			}
		}
		else if (M03lQotlSB == InventoryType.Armor)
		{
			Na8lYljBti(1, 70, 20, qPalAAlebc);
			Na8lYljBti(2, 70, 70, K8PldKuGrE);
			Na8lYljBti(3, 70, 120, WbClHhdZhx);
			Na8lYljBti(4, 70, 170, wEulFme8MQ);
			Na8lYljBti(0, 20, 70);
			Na8lYljBti(5, 120, 70);
		}
		InventorySlotDelete inventorySlotDelete = new InventorySlotDelete(Resources.DTAS1NDjxa4(), Resources.gG5S1cViOeK());
		inventorySlotDelete.Location = new Point(407, 19);
		inventorySlotDelete.UseVisualStyleBackColor = true;
		InventorySlotDelete inventorySlotDelete2 = inventorySlotDelete;
		bnTlISntCC.Controls.Add(inventorySlotDelete2);
		inventorySlotDelete2.DeleteDone += [MethodImpl(MethodImplOptions.NoInlining)] (InventorySlot P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			yh1lOgphe1.Enabled = false;
			Q22lCNujxP.Enabled = false;
			yh1lOgphe1.Value = 0m;
			Q22lCNujxP.Minimum = 0m;
			Q22lCNujxP.Value = 0m;
		};
		yh1lOgphe1.LostFocus += EGxl3Eq4jV;
		Q22lCNujxP.LostFocus += EGxl3Eq4jV;
		yh1lOgphe1.ValueChanged += ntKl18txfW;
		Q22lCNujxP.ValueChanged += ntKl18txfW;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Na8lYljBti(byte P_0, int P_1, int P_2, Image P_3 = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		InventorySlot inventorySlot = new InventorySlot(P_0, qOSloC1puN);
		inventorySlot.Location = new Point(P_1, P_2);
		inventorySlot.Default = P_3;
		inventorySlot.UseVisualStyleBackColor = false;
		InventorySlot inventorySlot2 = inventorySlot;
		inventorySlot2.GotFocus += XS7lEPsPXY;
		bnTlISntCC.Controls.Add(inventorySlot2);
		slots.Add(P_0, inventorySlot2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EGxl3Eq4jV(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ntKl18txfW(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (selected.InventoryItem != null)
		{
			NumericUpDown numericUpDown = (NumericUpDown)P_0;
			if (numericUpDown == yh1lOgphe1)
			{
				selected.InventoryItem.Damage = (short)numericUpDown.Value;
			}
			if (numericUpDown == Q22lCNujxP)
			{
				selected.InventoryItem.Count = (byte)numericUpDown.Value;
			}
			selected.Refresh();
			if (!changed)
			{
				changed = true;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XS7lEPsPXY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (selected != null)
		{
			selected.Selected = false;
			selected.Refresh();
		}
		selected = (InventorySlot)P_0;
		selected.Selected = true;
		yh1lOgphe1.ValueChanged -= ntKl18txfW;
		Q22lCNujxP.ValueChanged -= ntKl18txfW;
		bool flag = selected.InventoryItem != null;
		yh1lOgphe1.Enabled = flag;
		Q22lCNujxP.Enabled = flag;
		yh1lOgphe1.Value = (flag ? selected.InventoryItem.Damage : 0);
		Q22lCNujxP.Minimum = (flag ? 1 : 0);
		Q22lCNujxP.Value = (flag ? selected.InventoryItem.Count : 0);
		yh1lOgphe1.ValueChanged += ntKl18txfW;
		Q22lCNujxP.ValueChanged += ntKl18txfW;
		if (VZ1ljHRHi7 != null)
		{
			VZ1ljHRHi7(selected);
		}
		if (mK6l8HjpOH != null)
		{
			mK6l8HjpOH.Update(selected);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ItemChanged(bool change, bool enchantment = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (selected != null)
		{
			if (enchantment)
			{
				selected.Refresh();
			}
			yh1lOgphe1.ValueChanged -= ntKl18txfW;
			Q22lCNujxP.ValueChanged -= ntKl18txfW;
			bool flag = selected.InventoryItem != null;
			yh1lOgphe1.Enabled = flag;
			Q22lCNujxP.Enabled = flag;
			yh1lOgphe1.Value = (flag ? selected.InventoryItem.Damage : 0);
			Q22lCNujxP.Minimum = (flag ? 1 : 0);
			Q22lCNujxP.Value = (flag ? selected.InventoryItem.Count : 0);
			yh1lOgphe1.ValueChanged += ntKl18txfW;
			Q22lCNujxP.ValueChanged += ntKl18txfW;
			VZ1ljHRHi7(selected);
		}
		if (!changed && change)
		{
			changed = true;
			Text += Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10366);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadInventory(TagNodeList inventory, InventoryType inventoryType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		InventoryType = inventoryType;
		try
		{
			for (int i = 0; i < inventory.Count; i++)
			{
				TagNodeCompound tagNodeCompound = inventory[i] as TagNodeCompound;
				byte b = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] as TagNodeByte;
				if ((byte)(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] as TagNodeByte) != 0)
				{
					if (!slots.ContainsKey(b))
					{
						MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21414) + b + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21446), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18098), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						continue;
					}
					InventorySlot inventorySlot = slots[b];
					inventorySlot.InventoryItem = new InventoryItem(tagNodeCompound);
				}
			}
		}
		finally
		{
			foreach (InventorySlot value in slots.Values)
			{
				value.Refresh();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Save(TagNodeList container)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		container.Clear();
		container.ChangeValueType(TagType.TAG_COMPOUND);
		foreach (InventorySlot value in slots.Values)
		{
			if (value.InventoryItem != null)
			{
				container.Add(value.InventoryItem.GetProcessedNode());
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eYOlrkVhCq(object P_0, ItemDragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Button == MouseButtons.Left)
		{
			jLK03d0ZSlci2XsVe6 jLK03d0ZSlci2XsVe7 = (jLK03d0ZSlci2XsVe6)((ListViewItem)P_1.Item).Tag;
			MasterBlock itemBase = BlockMaster.Blocks[jLK03d0ZSlci2XsVe7.Name];
			MasterBlockItem bedrock = BlockMaster.Blocks[jLK03d0ZSlci2XsVe7.Name].bedrock;
			byte count = (byte)(Constants.InventoryMaxCount.ContainsKey(bedrock.id.Value) ? Constants.InventoryMaxCount[bedrock.id.Value] : 64);
			InventoryItem data = new InventoryItem((short)bedrock.id.Value, count, 0, (short)bedrock.data.Value, jLK03d0ZSlci2XsVe7.Name, itemBase);
			DoDragDrop(data, DragDropEffects.Copy | DragDropEffects.Move);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hkEl5wEljP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mK6l8HjpOH = new EnchantForm();
		G4xlzuOtfC.Enabled = false;
		mK6l8HjpOH.Closed += [MethodImpl(MethodImplOptions.NoInlining)] (object obj, EventArgs e) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			G4xlzuOtfC.Enabled = true;
			mK6l8HjpOH = null;
		};
		if (selected != null)
		{
			mK6l8HjpOH.Update(selected);
		}
		mK6l8HjpOH.Show(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SBkl69LThh(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jQ5lNUjcFC(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LeUlD0dFaX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && mBpl9yqbIK != null)
		{
			mBpl9yqbIK.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cRnlc3caLB()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(InventoryEditor));
		bnTlISntCC = new Panel();
		G4xlzuOtfC = new Button();
		RQB2TPDTOl = new ItemListUI();
		bnTlISntCC.SuspendLayout();
		SuspendLayout();
		bnTlISntCC.Controls.Add(G4xlzuOtfC);
		bnTlISntCC.Location = new Point(0, 0);
		bnTlISntCC.Margin = new Padding(0);
		bnTlISntCC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21486);
		bnTlISntCC.Size = new Size(471, 380);
		bnTlISntCC.TabIndex = 0;
		G4xlzuOtfC.BackgroundImage = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21524));
		G4xlzuOtfC.BackgroundImageLayout = ImageLayout.Stretch;
		G4xlzuOtfC.FlatAppearance.BorderColor = SystemColors.Control;
		G4xlzuOtfC.FlatAppearance.BorderSize = 0;
		G4xlzuOtfC.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
		G4xlzuOtfC.FlatStyle = FlatStyle.Flat;
		G4xlzuOtfC.Location = new Point(250, 26);
		G4xlzuOtfC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18634);
		G4xlzuOtfC.Size = new Size(40, 40);
		G4xlzuOtfC.TabIndex = 0;
		G4xlzuOtfC.UseVisualStyleBackColor = true;
		G4xlzuOtfC.Click += hkEl5wEljP;
		RQB2TPDTOl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		RQB2TPDTOl.Location = new Point(478, 17);
		RQB2TPDTOl.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18658);
		RQB2TPDTOl.Size = new Size(264, 363);
		RQB2TPDTOl.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(RQB2TPDTOl);
		base.Controls.Add(bnTlISntCC);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21580);
		base.Size = new Size(750, 384);
		bnTlISntCC.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private void YqdlJAR06q(InventorySlot P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yh1lOgphe1.Enabled = false;
		Q22lCNujxP.Enabled = false;
		yh1lOgphe1.Value = 0m;
		Q22lCNujxP.Minimum = 0m;
		Q22lCNujxP.Value = 0m;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private void hh4luxGqK3(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		G4xlzuOtfC.Enabled = true;
		mK6l8HjpOH = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static InventoryEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		qPalAAlebc = Resources.XBlSEyfSTbl();
		K8PldKuGrE = Resources.chest;
		WbClHhdZhx = Resources.CAkSE5EjhFf();
		wEulFme8MQ = Resources.bFYS1tLQe4I();
	}
}
