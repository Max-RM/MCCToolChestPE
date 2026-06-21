using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.events;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class EnchantOfferForm : Form
{
	private OfferItem jMSiIGmBJw;

	private Dictionary<short, Tuple<TagNodeCompound, ListViewItem>> hlMizqewoD;

	private EnchantmentChanged XLcsTdUieM;

	private Enchantment PW2sSr4qEM;

	private IContainer REEsGVjiTt;

	private CheckBox iujsbJZ62B;

	private NumericUpDown xY2svQvm53;

	private NumericUpDown D3bswUhUZx;

	private ComboBox eiCs4DwWd6;

	private ColumnHeader WfAsVJxbPy;

	private ColumnHeader cm7sWlDhkQ;

	private ListView bwrspQVJDi;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EnchantOfferForm(EnchantmentChanged enchantmentChanged)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		hlMizqewoD = new Dictionary<short, Tuple<TagNodeCompound, ListViewItem>>();
		pehi9tPvhx();
		XLcsTdUieM = enchantmentChanged;
		xY2svQvm53.Text = "";
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
	public void Update(OfferItem offerItem)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bwrspQVJDi.ItemSelectionChanged -= stfidKmwmr;
		xY2svQvm53.ValueChanged -= kT7i7cSJun;
		eiCs4DwWd6.SelectedIndexChanged -= HwpiAs6l7N;
		D3bswUhUZx.ValueChanged -= AtEiHer4wV;
		jMSiIGmBJw = offerItem;
		bwrspQVJDi.Items.Clear();
		xY2svQvm53.Text = "";
		eiCs4DwWd6.Items.Clear();
		D3bswUhUZx.Enabled = false;
		D3bswUhUZx.Value = 0m;
		if (offerItem == null || offerItem == null || (!offerItem.Enchantable && !offerItem.Enchanted && !iujsbJZ62B.Checked))
		{
			xY2svQvm53.Enabled = false;
			eiCs4DwWd6.Enabled = false;
		}
		else
		{
			xY2svQvm53.Enabled = iujsbJZ62B.Checked;
			eiCs4DwWd6.Enabled = offerItem.Enchantable || iujsbJZ62B.Checked;
			TagNodeCompound tag = offerItem.Tag;
			short item = lxe7hMuSirBXGUQugsD.rLoSPdg2uBc(tag);
			foreach (KeyValuePair<int, Enchantment> enchantment in Constants.enchantments)
			{
				Enchantment value = enchantment.Value;
				if (iujsbJZ62B.Checked || value.Items.Contains(item))
				{
					eiCs4DwWd6.Items.Add(value);
				}
			}
			hlMizqewoD.Clear();
			if (tag.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
			{
				TagNodeCompound tagNodeCompound = tag[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
				if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)))
				{
					TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17992)] as TagNodeList;
					foreach (TagNodeCompound item2 in tagNodeList)
					{
						short num = lxe7hMuSirBXGUQugsD.rLoSPdg2uBc(item2);
						if (hlMizqewoD.ContainsKey(num))
						{
							MessageBox.Show(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18004), offerItem, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18070)), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18098), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						string text = ((!Constants.enchantments.ContainsKey(num)) ? (Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18116) + num) : Constants.enchantments[num].Name);
						int num2 = item2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18160)] as TagNodeShort;
						ListViewItem listViewItem = new ListViewItem(new string[2]
						{
							text,
							num2.ToString()
						});
						listViewItem.Tag = num;
						bwrspQVJDi.Items.Add(listViewItem);
						hlMizqewoD.Add(num, Tuple.Create(item2, listViewItem));
					}
				}
			}
		}
		bwrspQVJDi.ItemSelectionChanged += stfidKmwmr;
		xY2svQvm53.ValueChanged += kT7i7cSJun;
		eiCs4DwWd6.SelectedIndexChanged += HwpiAs6l7N;
		D3bswUhUZx.ValueChanged += AtEiHer4wV;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HnqiQtiOgr(short P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bwrspQVJDi.ItemSelectionChanged -= stfidKmwmr;
		xY2svQvm53.ValueChanged -= kT7i7cSJun;
		eiCs4DwWd6.SelectedIndexChanged -= HwpiAs6l7N;
		D3bswUhUZx.ValueChanged -= AtEiHer4wV;
		Enchantment enchantment = null;
		if (Constants.enchantments.ContainsKey(P_0))
		{
			enchantment = Constants.enchantments[P_0];
		}
		TagNodeCompound tagNodeCompound = null;
		if (hlMizqewoD.ContainsKey(P_0))
		{
			tagNodeCompound = hlMizqewoD[P_0].Item1;
		}
		bwrspQVJDi.SelectedItems.Clear();
		if (hlMizqewoD.ContainsKey(P_0))
		{
			hlMizqewoD[P_0].Item2.Selected = true;
		}
		xY2svQvm53.Value = P_0;
		xY2svQvm53.Text = P_0.ToString();
		if (PW2sSr4qEM != null)
		{
			eiCs4DwWd6.Items.Remove(PW2sSr4qEM);
		}
		if (enchantment == null)
		{
			PW2sSr4qEM = new Enchantment(P_0, P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18116) + P_0, 0, new List<short>());
			eiCs4DwWd6.SelectedIndex = eiCs4DwWd6.Items.Add(PW2sSr4qEM);
		}
		else if (!eiCs4DwWd6.Items.Contains(enchantment))
		{
			eiCs4DwWd6.SelectedIndex = eiCs4DwWd6.Items.Add(enchantment);
		}
		else
		{
			eiCs4DwWd6.Text = enchantment.Name;
		}
		short num = 0;
		if (tagNodeCompound != null && tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18160)))
		{
			num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18160)] as TagNodeShort;
		}
		D3bswUhUZx.Enabled = iujsbJZ62B.Checked || (enchantment != null && enchantment.Items.Contains(jMSiIGmBJw.Id) && (tagNodeCompound == null || (num >= 0 && num <= enchantment.MaxLevel)));
		bool flag = iujsbJZ62B.Checked || enchantment == null || (tagNodeCompound != null && num < 0) || num > enchantment.MaxLevel;
		D3bswUhUZx.Minimum = (flag ? (-32768) : 0);
		D3bswUhUZx.Maximum = (flag ? 32767 : enchantment.MaxLevel);
		D3bswUhUZx.Value = (short)((tagNodeCompound != null) ? num : 0);
		bwrspQVJDi.ItemSelectionChanged += stfidKmwmr;
		xY2svQvm53.ValueChanged += kT7i7cSJun;
		eiCs4DwWd6.SelectedIndexChanged += HwpiAs6l7N;
		D3bswUhUZx.ValueChanged += AtEiHer4wV;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DtDiO7r9DM()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bwrspQVJDi.ItemSelectionChanged -= stfidKmwmr;
		xY2svQvm53.ValueChanged -= kT7i7cSJun;
		eiCs4DwWd6.SelectedIndexChanged -= HwpiAs6l7N;
		D3bswUhUZx.ValueChanged -= AtEiHer4wV;
		bwrspQVJDi.SelectedItems.Clear();
		xY2svQvm53.Value = 0m;
		xY2svQvm53.Text = "";
		eiCs4DwWd6.SelectedItem = null;
		D3bswUhUZx.Enabled = false;
		D3bswUhUZx.Value = 0m;
		bwrspQVJDi.ItemSelectionChanged += stfidKmwmr;
		xY2svQvm53.ValueChanged += kT7i7cSJun;
		eiCs4DwWd6.SelectedIndexChanged += HwpiAs6l7N;
		D3bswUhUZx.ValueChanged += AtEiHer4wV;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void X1diCGuEEs(short P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bwrspQVJDi.ItemSelectionChanged -= stfidKmwmr;
		xY2svQvm53.ValueChanged -= kT7i7cSJun;
		eiCs4DwWd6.SelectedIndexChanged -= HwpiAs6l7N;
		D3bswUhUZx.ValueChanged -= AtEiHer4wV;
		D3bswUhUZx.Value = P_0;
		Enchantment enchantment = (Enchantment)eiCs4DwWd6.SelectedItem;
		if (P_0 != 0)
		{
			if (!jMSiIGmBJw.Tag.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
			{
				jMSiIGmBJw.Tag[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] = new TagNodeCompound();
			}
			TagNodeCompound tagNodeCompound = jMSiIGmBJw.Tag[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
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
					D3bswUhUZx.Value.ToString()
				});
				listViewItem.Tag = enchantment.BedrockId;
				bwrspQVJDi.Items.Add(listViewItem);
				listViewItem.Selected = true;
				hlMizqewoD.Add(enchantment.BedrockId, Tuple.Create(tagNodeCompound2, listViewItem));
			}
			else
			{
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18160)] = new TagNodeShort(P_0);
				foreach (ListViewItem item2 in bwrspQVJDi.Items)
				{
					if ((short)item2.Tag == enchantment.BedrockId)
					{
						item2.SubItems[1].Text = D3bswUhUZx.Value.ToString();
					}
				}
			}
		}
		else
		{
			TagNodeCompound tagNodeCompound4 = null;
			if (jMSiIGmBJw.Tag.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)))
			{
				TagNodeCompound tagNodeCompound5 = jMSiIGmBJw.Tag[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)] as TagNodeCompound;
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
						hlMizqewoD.Remove(enchantment.BedrockId);
						foreach (ListViewItem item4 in bwrspQVJDi.Items)
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
								jMSiIGmBJw.Tag.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982));
							}
						}
					}
				}
			}
		}
		XLcsTdUieM();
		bwrspQVJDi.ItemSelectionChanged += stfidKmwmr;
		xY2svQvm53.ValueChanged += kT7i7cSJun;
		eiCs4DwWd6.SelectedIndexChanged += HwpiAs6l7N;
		D3bswUhUZx.ValueChanged += AtEiHer4wV;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kT7i7cSJun(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		HnqiQtiOgr((short)xY2svQvm53.Value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HwpiAs6l7N(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (eiCs4DwWd6.SelectedItem != null)
		{
			HnqiQtiOgr(((Enchantment)eiCs4DwWd6.SelectedItem).BedrockId);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void stfidKmwmr(object P_0, ListViewItemSelectionChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.IsSelected)
		{
			HnqiQtiOgr((short)P_1.Item.Tag);
		}
		else
		{
			DtDiO7r9DM();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AtEiHer4wV(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		X1diCGuEEs((short)D3bswUhUZx.Value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XiJiFK8WUL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (jMSiIGmBJw == null)
		{
			return;
		}
		Enchantment enchantment = null;
		if (Constants.enchantments.ContainsKey((short)xY2svQvm53.Value))
		{
			enchantment = Constants.enchantments[(short)xY2svQvm53.Value];
		}
		xY2svQvm53.Enabled = iujsbJZ62B.Checked;
		if (enchantment == null && D3bswUhUZx.Value == 0m)
		{
			DtDiO7r9DM();
			return;
		}
		eiCs4DwWd6.Enabled = jMSiIGmBJw.Enchantable || iujsbJZ62B.Checked;
		foreach (KeyValuePair<int, Enchantment> enchantment2 in Constants.enchantments)
		{
			Enchantment value = enchantment2.Value;
			if (iujsbJZ62B.Checked || value.Items.Contains(jMSiIGmBJw.Id))
			{
				if (!eiCs4DwWd6.Items.Contains(value))
				{
					eiCs4DwWd6.Items.Add(value);
				}
			}
			else if (eiCs4DwWd6.Items.Contains(value) && eiCs4DwWd6.SelectedItem != value)
			{
				eiCs4DwWd6.Items.Remove(value);
			}
		}
		if (eiCs4DwWd6.SelectedItem != null)
		{
			D3bswUhUZx.Enabled = iujsbJZ62B.Checked || (enchantment != null && enchantment.Items.Contains(jMSiIGmBJw.Id) && D3bswUhUZx.Value >= 0m && D3bswUhUZx.Value <= (decimal)enchantment.MaxLevel);
			bool flag = iujsbJZ62B.Checked || enchantment == null || D3bswUhUZx.Value < 0m || D3bswUhUZx.Value > (decimal)enchantment.MaxLevel;
			D3bswUhUZx.Minimum = (flag ? (-32768) : 0);
			D3bswUhUZx.Maximum = (flag ? 32767 : enchantment.MaxLevel);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DTXijlITOH(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if ((P_1.KeyCode & Keys.Delete) == Keys.Delete && jMSiIGmBJw != null && eiCs4DwWd6.SelectedItem != null)
		{
			X1diCGuEEs(0);
			DtDiO7r9DM();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void W8hi8R6N5G(object P_0, ColumnWidthChangingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.Cancel = true;
		P_1.NewWidth = bwrspQVJDi.Columns[P_1.ColumnIndex].Width;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && REEsGVjiTt != null)
		{
			REEsGVjiTt.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pehi9tPvhx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new ComponentResourceManager(typeof(EnchantForm));
		bwrspQVJDi = new ListView();
		cm7sWlDhkQ = new ColumnHeader();
		WfAsVJxbPy = new ColumnHeader();
		eiCs4DwWd6 = new ComboBox();
		D3bswUhUZx = new NumericUpDown();
		xY2svQvm53 = new NumericUpDown();
		iujsbJZ62B = new CheckBox();
		((ISupportInitialize)D3bswUhUZx).BeginInit();
		((ISupportInitialize)xY2svQvm53).BeginInit();
		SuspendLayout();
		bwrspQVJDi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		bwrspQVJDi.Columns.AddRange(new ColumnHeader[2] { cm7sWlDhkQ, WfAsVJxbPy });
		bwrspQVJDi.FullRowSelect = true;
		bwrspQVJDi.GridLines = true;
		bwrspQVJDi.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		bwrspQVJDi.HideSelection = false;
		bwrspQVJDi.Location = new Point(6, 6);
		bwrspQVJDi.MultiSelect = false;
		bwrspQVJDi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18170);
		bwrspQVJDi.Size = new Size(302, 138);
		bwrspQVJDi.TabIndex = 0;
		bwrspQVJDi.UseCompatibleStateImageBehavior = false;
		bwrspQVJDi.View = View.Details;
		bwrspQVJDi.ColumnWidthChanging += W8hi8R6N5G;
		bwrspQVJDi.ItemSelectionChanged += stfidKmwmr;
		bwrspQVJDi.KeyDown += DTXijlITOH;
		cm7sWlDhkQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		cm7sWlDhkQ.Width = 235;
		WfAsVJxbPy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204);
		WfAsVJxbPy.TextAlign = HorizontalAlignment.Center;
		WfAsVJxbPy.Width = 46;
		eiCs4DwWd6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		eiCs4DwWd6.DropDownStyle = ComboBoxStyle.DropDownList;
		eiCs4DwWd6.Enabled = false;
		eiCs4DwWd6.FormattingEnabled = true;
		eiCs4DwWd6.Location = new Point(72, 151);
		eiCs4DwWd6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18218);
		eiCs4DwWd6.Size = new Size(170, 21);
		eiCs4DwWd6.TabIndex = 2;
		eiCs4DwWd6.SelectedIndexChanged += HwpiAs6l7N;
		D3bswUhUZx.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		D3bswUhUZx.Enabled = false;
		D3bswUhUZx.Location = new Point(246, 151);
		D3bswUhUZx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18236);
		D3bswUhUZx.Size = new Size(62, 20);
		D3bswUhUZx.TabIndex = 3;
		D3bswUhUZx.TextAlign = HorizontalAlignment.Right;
		D3bswUhUZx.ValueChanged += AtEiHer4wV;
		xY2svQvm53.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		xY2svQvm53.Enabled = false;
		xY2svQvm53.Location = new Point(6, 151);
		xY2svQvm53.Maximum = new decimal(new int[4] { 32767, 0, 0, 0 });
		xY2svQvm53.Minimum = new decimal(new int[4] { 32768, 0, 0, -2147483648 });
		xY2svQvm53.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18258);
		xY2svQvm53.Size = new Size(62, 20);
		xY2svQvm53.TabIndex = 1;
		xY2svQvm53.TextAlign = HorizontalAlignment.Right;
		xY2svQvm53.ValueChanged += kT7i7cSJun;
		iujsbJZ62B.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		iujsbJZ62B.Location = new Point(8, 176);
		iujsbJZ62B.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18274);
		iujsbJZ62B.Size = new Size(298, 18);
		iujsbJZ62B.TabIndex = 4;
		iujsbJZ62B.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18294);
		iujsbJZ62B.UseVisualStyleBackColor = true;
		iujsbJZ62B.CheckedChanged += XiJiFK8WUL;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(314, 199);
		base.Controls.Add(iujsbJZ62B);
		base.Controls.Add(xY2svQvm53);
		base.Controls.Add(D3bswUhUZx);
		base.Controls.Add(eiCs4DwWd6);
		base.Controls.Add(bwrspQVJDi);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18372);
		base.ShowInTaskbar = false;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18398);
		((ISupportInitialize)D3bswUhUZx).EndInit();
		((ISupportInitialize)xY2svQvm53).EndInit();
		ResumeLayout(performLayout: false);
	}
}
