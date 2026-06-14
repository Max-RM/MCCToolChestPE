using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class EnchantForm : Form
{
	private InventorySlot yVvK3Nslw8;

	private Dictionary<short, Tuple<TagNodeCompound, ListViewItem>> UPvK1woU3o;

	private Enchantment KtoKEnX4By;

	private IContainer bE2KrB6DZx;

	private CheckBox HMJK5aIHYA;

	private NumericUpDown oObK6VbvfQ;

	private NumericUpDown iaPKNa7B4v;

	private ComboBox TUlKDJI0m0;

	private ColumnHeader QkgKcWR9au;

	private ColumnHeader ESpKJOVex6;

	private ListView IfnKu4R2eg;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EnchantForm()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		UPvK1woU3o = new Dictionary<short, Tuple<TagNodeCompound, ListViewItem>>();
		egRKYFcOTm();
		oObK6VbvfQ.Text = "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnShown(EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnShown(e);
		CenterToParent();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update(InventorySlot slot)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IfnKu4R2eg.ItemSelectionChanged -= DnFKLqf8ZT;
		oObK6VbvfQ.ValueChanged -= hDZKMUSHgk;
		TUlKDJI0m0.SelectedIndexChanged -= dYaKUUQPVo;
		iaPKNa7B4v.ValueChanged -= mXEKg3Zkht;
		yVvK3Nslw8 = slot;
		IfnKu4R2eg.Items.Clear();
		oObK6VbvfQ.Text = "";
		TUlKDJI0m0.Items.Clear();
		iaPKNa7B4v.Enabled = false;
		iaPKNa7B4v.Value = 0m;
		if (slot == null || slot.InventoryItem == null || (!slot.InventoryItem.Enchantable && !slot.InventoryItem.Enchanted && !HMJK5aIHYA.Checked))
		{
			oObK6VbvfQ.Enabled = false;
			TUlKDJI0m0.Enabled = false;
		}
		else
		{
			oObK6VbvfQ.Enabled = HMJK5aIHYA.Checked;
			TUlKDJI0m0.Enabled = slot.InventoryItem.Enchantable || HMJK5aIHYA.Checked;
			TagNodeCompound tag = slot.InventoryItem.Tag;
			short iD = slot.InventoryItem.ID;
			foreach (KeyValuePair<int, Enchantment> enchantment in Constants.enchantments)
			{
				Enchantment value = enchantment.Value;
				if (HMJK5aIHYA.Checked || value.Items.Contains(iD))
				{
					TUlKDJI0m0.Items.Add(value);
				}
			}
			UPvK1woU3o.Clear();
			if (tag.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
			{
				TagNodeCompound tagNodeCompound = tag[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
				if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)))
				{
					TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)] as TagNodeList;
					foreach (TagNodeCompound item in tagNodeList)
					{
						short num = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeShort;
						if (UPvK1woU3o.ContainsKey(num))
						{
							MessageBox.Show(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18004), slot, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18070)), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18098), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						string text = ((!Constants.enchantments.ContainsKey(num)) ? (Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18116) + num) : Constants.enchantments[num].Name);
						int num2 = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18160)] as TagNodeShort;
						ListViewItem listViewItem = new ListViewItem(new string[2]
						{
							text,
							num2.ToString()
						});
						listViewItem.Tag = num;
						IfnKu4R2eg.Items.Add(listViewItem);
						UPvK1woU3o.Add(num, Tuple.Create(item, listViewItem));
					}
				}
			}
		}
		IfnKu4R2eg.ItemSelectionChanged += DnFKLqf8ZT;
		oObK6VbvfQ.ValueChanged += hDZKMUSHgk;
		TUlKDJI0m0.SelectedIndexChanged += dYaKUUQPVo;
		iaPKNa7B4v.ValueChanged += mXEKg3Zkht;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vX8KXJPujG(short P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IfnKu4R2eg.ItemSelectionChanged -= DnFKLqf8ZT;
		oObK6VbvfQ.ValueChanged -= hDZKMUSHgk;
		TUlKDJI0m0.SelectedIndexChanged -= dYaKUUQPVo;
		iaPKNa7B4v.ValueChanged -= mXEKg3Zkht;
		Enchantment enchantment = null;
		if (Constants.enchantments.ContainsKey(P_0))
		{
			enchantment = Constants.enchantments[P_0];
		}
		TagNodeCompound tagNodeCompound = null;
		if (UPvK1woU3o.ContainsKey(P_0))
		{
			tagNodeCompound = UPvK1woU3o[P_0].Item1;
		}
		IfnKu4R2eg.SelectedItems.Clear();
		if (UPvK1woU3o.ContainsKey(P_0))
		{
			UPvK1woU3o[P_0].Item2.Selected = true;
		}
		oObK6VbvfQ.Value = P_0;
		oObK6VbvfQ.Text = P_0.ToString();
		if (KtoKEnX4By != null)
		{
			TUlKDJI0m0.Items.Remove(KtoKEnX4By);
		}
		if (enchantment == null)
		{
			KtoKEnX4By = new Enchantment(P_0, P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18116) + P_0, 0, new List<short>());
			TUlKDJI0m0.SelectedIndex = TUlKDJI0m0.Items.Add(KtoKEnX4By);
		}
		else if (!TUlKDJI0m0.Items.Contains(enchantment))
		{
			TUlKDJI0m0.SelectedIndex = TUlKDJI0m0.Items.Add(enchantment);
		}
		else
		{
			TUlKDJI0m0.Text = enchantment.Name;
		}
		short num = 0;
		if (tagNodeCompound != null && tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18160)))
		{
			num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18160)] as TagNodeShort;
		}
		iaPKNa7B4v.Enabled = HMJK5aIHYA.Checked || (enchantment != null && enchantment.Items.Contains(yVvK3Nslw8.InventoryItem.ID) && (tagNodeCompound == null || (num >= 0 && num <= enchantment.MaxLevel)));
		bool flag = HMJK5aIHYA.Checked || enchantment == null || (tagNodeCompound != null && num < 0) || num > enchantment.MaxLevel;
		iaPKNa7B4v.Minimum = (flag ? (-32768) : 0);
		iaPKNa7B4v.Maximum = (flag ? 32767 : enchantment.MaxLevel);
		iaPKNa7B4v.Value = (short)((tagNodeCompound != null) ? num : 0);
		IfnKu4R2eg.ItemSelectionChanged += DnFKLqf8ZT;
		oObK6VbvfQ.ValueChanged += hDZKMUSHgk;
		TUlKDJI0m0.SelectedIndexChanged += dYaKUUQPVo;
		iaPKNa7B4v.ValueChanged += mXEKg3Zkht;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RNhKx0uJMx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IfnKu4R2eg.ItemSelectionChanged -= DnFKLqf8ZT;
		oObK6VbvfQ.ValueChanged -= hDZKMUSHgk;
		TUlKDJI0m0.SelectedIndexChanged -= dYaKUUQPVo;
		iaPKNa7B4v.ValueChanged -= mXEKg3Zkht;
		IfnKu4R2eg.SelectedItems.Clear();
		oObK6VbvfQ.Value = 0m;
		oObK6VbvfQ.Text = "";
		TUlKDJI0m0.SelectedItem = null;
		iaPKNa7B4v.Enabled = false;
		iaPKNa7B4v.Value = 0m;
		IfnKu4R2eg.ItemSelectionChanged += DnFKLqf8ZT;
		oObK6VbvfQ.ValueChanged += hDZKMUSHgk;
		TUlKDJI0m0.SelectedIndexChanged += dYaKUUQPVo;
		iaPKNa7B4v.ValueChanged += mXEKg3Zkht;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xBXKefmIN3(short P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IfnKu4R2eg.ItemSelectionChanged -= DnFKLqf8ZT;
		oObK6VbvfQ.ValueChanged -= hDZKMUSHgk;
		TUlKDJI0m0.SelectedIndexChanged -= dYaKUUQPVo;
		iaPKNa7B4v.ValueChanged -= mXEKg3Zkht;
		iaPKNa7B4v.Value = P_0;
		Enchantment enchantment = (Enchantment)TUlKDJI0m0.SelectedItem;
		if (P_0 != 0)
		{
			if (!yVvK3Nslw8.InventoryItem.Tag.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
			{
				yVvK3Nslw8.InventoryItem.Tag[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] = new TagNodeCompound();
			}
			TagNodeCompound tagNodeCompound = yVvK3Nslw8.InventoryItem.Tag[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
			if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)))
			{
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)] = new TagNodeList(TagType.TAG_COMPOUND);
			}
			TagNodeCompound tagNodeCompound2 = null;
			TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)] as TagNodeList;
			foreach (TagNodeCompound item in tagNodeList)
			{
				short num = item[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeShort;
				if (num == enchantment.BedrockId)
				{
					tagNodeCompound2 = item;
					break;
				}
			}
			if (tagNodeCompound2 == null)
			{
				tagNodeCompound2 = new TagNodeCompound();
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeShort(enchantment.BedrockId);
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18160)] = new TagNodeShort(P_0);
				tagNodeList.Add(tagNodeCompound2);
				ListViewItem listViewItem = new ListViewItem(new string[2]
				{
					enchantment.Name,
					iaPKNa7B4v.Value.ToString()
				});
				listViewItem.Tag = enchantment.BedrockId;
				IfnKu4R2eg.Items.Add(listViewItem);
				listViewItem.Selected = true;
				UPvK1woU3o.Add(enchantment.BedrockId, Tuple.Create(tagNodeCompound2, listViewItem));
			}
			else
			{
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18160)] = new TagNodeShort(P_0);
				foreach (ListViewItem item2 in IfnKu4R2eg.Items)
				{
					if ((short)item2.Tag == enchantment.BedrockId)
					{
						item2.SubItems[1].Text = iaPKNa7B4v.Value.ToString();
					}
				}
			}
		}
		else
		{
			TagNodeCompound tagNodeCompound4 = null;
			if (yVvK3Nslw8.InventoryItem.Tag.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
			{
				TagNodeCompound tagNodeCompound5 = yVvK3Nslw8.InventoryItem.Tag[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
				if (tagNodeCompound5.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)))
				{
					TagNodeList tagNodeList2 = tagNodeCompound5[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)] as TagNodeList;
					foreach (TagNodeCompound item3 in tagNodeList2)
					{
						short num2 = item3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeShort;
						if (num2 == enchantment.BedrockId)
						{
							tagNodeCompound4 = item3;
							break;
						}
					}
					if (tagNodeCompound4 != null)
					{
						tagNodeList2.Remove(tagNodeCompound4);
						UPvK1woU3o.Remove(enchantment.BedrockId);
						foreach (ListViewItem item4 in IfnKu4R2eg.Items)
						{
							if ((short)item4.Tag == enchantment.BedrockId)
							{
								item4.Remove();
								break;
							}
						}
						if (tagNodeList2.Count == 0)
						{
							tagNodeCompound5.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992));
							if (tagNodeCompound5.Count == 0)
							{
								yVvK3Nslw8.InventoryItem.Tag.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982));
							}
						}
					}
				}
			}
		}
		yVvK3Nslw8.N062wIcgD9();
		IfnKu4R2eg.ItemSelectionChanged += DnFKLqf8ZT;
		oObK6VbvfQ.ValueChanged += hDZKMUSHgk;
		TUlKDJI0m0.SelectedIndexChanged += dYaKUUQPVo;
		iaPKNa7B4v.ValueChanged += mXEKg3Zkht;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hDZKMUSHgk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vX8KXJPujG((short)oObK6VbvfQ.Value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dYaKUUQPVo(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (TUlKDJI0m0.SelectedItem != null)
		{
			vX8KXJPujG(((Enchantment)TUlKDJI0m0.SelectedItem).BedrockId);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DnFKLqf8ZT(object P_0, ListViewItemSelectionChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.IsSelected)
		{
			vX8KXJPujG((short)P_1.Item.Tag);
		}
		else
		{
			RNhKx0uJMx();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mXEKg3Zkht(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		xBXKefmIN3((short)iaPKNa7B4v.Value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e3hKPdF9Xw(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (yVvK3Nslw8 == null || yVvK3Nslw8.InventoryItem == null)
		{
			return;
		}
		Enchantment enchantment = null;
		if (Constants.enchantments.ContainsKey((short)oObK6VbvfQ.Value))
		{
			enchantment = Constants.enchantments[(short)oObK6VbvfQ.Value];
		}
		oObK6VbvfQ.Enabled = HMJK5aIHYA.Checked;
		if (enchantment == null && iaPKNa7B4v.Value == 0m)
		{
			RNhKx0uJMx();
			return;
		}
		TUlKDJI0m0.Enabled = yVvK3Nslw8.InventoryItem.Enchantable || HMJK5aIHYA.Checked;
		foreach (KeyValuePair<int, Enchantment> enchantment2 in Constants.enchantments)
		{
			Enchantment value = enchantment2.Value;
			if (HMJK5aIHYA.Checked || value.Items.Contains(yVvK3Nslw8.InventoryItem.ID))
			{
				if (!TUlKDJI0m0.Items.Contains(value))
				{
					TUlKDJI0m0.Items.Add(value);
				}
			}
			else if (TUlKDJI0m0.Items.Contains(value) && TUlKDJI0m0.SelectedItem != value)
			{
				TUlKDJI0m0.Items.Remove(value);
			}
		}
		if (TUlKDJI0m0.SelectedItem != null)
		{
			iaPKNa7B4v.Enabled = HMJK5aIHYA.Checked || (enchantment != null && enchantment.Items.Contains(yVvK3Nslw8.InventoryItem.ID) && iaPKNa7B4v.Value >= 0m && iaPKNa7B4v.Value <= (decimal)enchantment.MaxLevel);
			bool flag = HMJK5aIHYA.Checked || enchantment == null || iaPKNa7B4v.Value < 0m || iaPKNa7B4v.Value > (decimal)enchantment.MaxLevel;
			iaPKNa7B4v.Minimum = (flag ? (-32768) : 0);
			iaPKNa7B4v.Maximum = (flag ? 32767 : enchantment.MaxLevel);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sClKRgflvi(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if ((P_1.KeyCode & Keys.Delete) == Keys.Delete && yVvK3Nslw8 != null && yVvK3Nslw8.InventoryItem != null && TUlKDJI0m0.SelectedItem != null)
		{
			xBXKefmIN3(0);
			RNhKx0uJMx();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l4MKkrqb8v(object P_0, ColumnWidthChangingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.Cancel = true;
		P_1.NewWidth = IfnKu4R2eg.Columns[P_1.ColumnIndex].Width;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && bE2KrB6DZx != null)
		{
			bE2KrB6DZx.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void egRKYFcOTm()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new ComponentResourceManager(typeof(EnchantForm));
		IfnKu4R2eg = new ListView();
		ESpKJOVex6 = new ColumnHeader();
		QkgKcWR9au = new ColumnHeader();
		TUlKDJI0m0 = new ComboBox();
		iaPKNa7B4v = new NumericUpDown();
		oObK6VbvfQ = new NumericUpDown();
		HMJK5aIHYA = new CheckBox();
		((ISupportInitialize)iaPKNa7B4v).BeginInit();
		((ISupportInitialize)oObK6VbvfQ).BeginInit();
		SuspendLayout();
		IfnKu4R2eg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		IfnKu4R2eg.Columns.AddRange(new ColumnHeader[2] { ESpKJOVex6, QkgKcWR9au });
		IfnKu4R2eg.FullRowSelect = true;
		IfnKu4R2eg.GridLines = true;
		IfnKu4R2eg.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		IfnKu4R2eg.HideSelection = false;
		IfnKu4R2eg.Location = new Point(6, 6);
		IfnKu4R2eg.MultiSelect = false;
		IfnKu4R2eg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18170);
		IfnKu4R2eg.Size = new Size(302, 138);
		IfnKu4R2eg.TabIndex = 0;
		IfnKu4R2eg.UseCompatibleStateImageBehavior = false;
		IfnKu4R2eg.View = View.Details;
		IfnKu4R2eg.ColumnWidthChanging += l4MKkrqb8v;
		IfnKu4R2eg.ItemSelectionChanged += DnFKLqf8ZT;
		IfnKu4R2eg.KeyDown += sClKRgflvi;
		ESpKJOVex6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		ESpKJOVex6.Width = 235;
		QkgKcWR9au.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204);
		QkgKcWR9au.TextAlign = HorizontalAlignment.Center;
		QkgKcWR9au.Width = 46;
		TUlKDJI0m0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TUlKDJI0m0.DropDownStyle = ComboBoxStyle.DropDownList;
		TUlKDJI0m0.Enabled = false;
		TUlKDJI0m0.FormattingEnabled = true;
		TUlKDJI0m0.Location = new Point(72, 151);
		TUlKDJI0m0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18218);
		TUlKDJI0m0.Size = new Size(170, 21);
		TUlKDJI0m0.TabIndex = 2;
		TUlKDJI0m0.SelectedIndexChanged += dYaKUUQPVo;
		iaPKNa7B4v.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		iaPKNa7B4v.Enabled = false;
		iaPKNa7B4v.Location = new Point(246, 151);
		iaPKNa7B4v.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18236);
		iaPKNa7B4v.Size = new Size(62, 20);
		iaPKNa7B4v.TabIndex = 3;
		iaPKNa7B4v.TextAlign = HorizontalAlignment.Right;
		iaPKNa7B4v.ValueChanged += mXEKg3Zkht;
		oObK6VbvfQ.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		oObK6VbvfQ.Enabled = false;
		oObK6VbvfQ.Location = new Point(6, 151);
		oObK6VbvfQ.Maximum = new decimal(new int[4] { 32767, 0, 0, 0 });
		oObK6VbvfQ.Minimum = new decimal(new int[4] { 32768, 0, 0, -2147483648 });
		oObK6VbvfQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18258);
		oObK6VbvfQ.Size = new Size(62, 20);
		oObK6VbvfQ.TabIndex = 1;
		oObK6VbvfQ.TextAlign = HorizontalAlignment.Right;
		oObK6VbvfQ.ValueChanged += hDZKMUSHgk;
		HMJK5aIHYA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		HMJK5aIHYA.Location = new Point(8, 176);
		HMJK5aIHYA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18274);
		HMJK5aIHYA.Size = new Size(298, 18);
		HMJK5aIHYA.TabIndex = 4;
		HMJK5aIHYA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18294);
		HMJK5aIHYA.UseVisualStyleBackColor = true;
		HMJK5aIHYA.CheckedChanged += e3hKPdF9Xw;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(314, 199);
		base.Controls.Add(HMJK5aIHYA);
		base.Controls.Add(oObK6VbvfQ);
		base.Controls.Add(iaPKNa7B4v);
		base.Controls.Add(TUlKDJI0m0);
		base.Controls.Add(IfnKu4R2eg);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18372);
		base.ShowInTaskbar = false;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18398);
		((ISupportInitialize)iaPKNa7B4v).EndInit();
		((ISupportInitialize)oObK6VbvfQ).EndInit();
		ResumeLayout(performLayout: false);
	}
}
