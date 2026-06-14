using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using HaI2p2xMqxTADue2UA;
using jWBDofdcGMieH0qfdS;
using MCCToolChest.events;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class ItemListUI : UserControl
{
	private EventHandler BY0KFG4ct6;

	private IContainer GZWKjc6PR3;

	private ListView FiaK8O17Yd;

	private ColumnHeader LL5K9uNiRQ;

	private ColumnHeader QpvKIqBng5;

	private TextBox BdOKzvicld;

	public event EventHandler ItemSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = BY0KFG4ct6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref BY0KFG4ct6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = BY0KFG4ct6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref BY0KFG4ct6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnItemSelected(object sender, InventoryItemEventArg e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BY0KFG4ct6?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemListUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		efTKHIlm2A();
		CMoKo91Z2a(FiaK8O17Yd, Jlxk34F1xl7DbN5CrR.B95SqDoBaf().Values.ToList());
		FiaK8O17Yd.ItemDrag += NqnK7gQCsv;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CMoKo91Z2a(ListView P_0, List<jLK03d0ZSlci2XsVe6> P_1, string P_2 = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.LargeImageList = Jlxk34F1xl7DbN5CrR.fSYSfLeSaU();
		P_0.SmallImageList = Jlxk34F1xl7DbN5CrR.fSYSfLeSaU();
		foreach (jLK03d0ZSlci2XsVe6 item in P_1)
		{
			if (P_2 == null || item.Description.IndexOf(P_2, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.ImageKey = item.Name;
				string text = item.Description;
				listViewItem.SubItems.Add(text);
				listViewItem.Tag = item;
				P_0.Items.Add(listViewItem);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IcVKQjXCHL(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = BdOKzvicld.Text.Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			text = null;
		}
		FiaK8O17Yd.Items.Clear();
		CMoKo91Z2a(FiaK8O17Yd, Jlxk34F1xl7DbN5CrR.B95SqDoBaf().Values.ToList(), text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sJ5KOoGrx3(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (BdOKzvicld.Font.Italic)
		{
			BdOKzvicld.Font = new Font(BdOKzvicld.Font, FontStyle.Regular);
			BdOKzvicld.ForeColor = SystemColors.ControlText;
			BdOKzvicld.Text = "";
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void W6gKChLXlP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!(BdOKzvicld.Text != ""))
		{
			BdOKzvicld.Font = new Font(BdOKzvicld.Font, FontStyle.Italic);
			BdOKzvicld.ForeColor = Color.Gray;
			BdOKzvicld.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19840);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NqnK7gQCsv(object P_0, ItemDragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Button != MouseButtons.Left)
		{
			return;
		}
		InventoryItem inventoryItem = null;
		if (((ListViewItem)P_1.Item).Tag is jLK03d0ZSlci2XsVe6)
		{
			jLK03d0ZSlci2XsVe6 jLK03d0ZSlci2XsVe7 = (jLK03d0ZSlci2XsVe6)((ListViewItem)P_1.Item).Tag;
			string text = jLK03d0ZSlci2XsVe7.Name;
			if (BlockMaster.Blocks.ContainsKey(jLK03d0ZSlci2XsVe7.Name) && BlockMaster.Blocks[jLK03d0ZSlci2XsVe7.Name].bedrock != null)
			{
				text = BlockMaster.Blocks[jLK03d0ZSlci2XsVe7.Name].bedrock.name;
			}
			if (ItemTranslations.BedrockItemsByName.ContainsKey(text))
			{
				ItemTranslate itemTranslate = ItemTranslations.BedrockItemsByName[text];
				inventoryItem = new InventoryItem((short)itemTranslate.BedrockId, 1, 0, (short)itemTranslate.BedrockDamage, text, itemTranslate);
				inventoryItem.Name = itemTranslate.BedrockName;
			}
			else if (BlockMaster.Blocks.ContainsKey(jLK03d0ZSlci2XsVe7.Name))
			{
				MasterBlock masterBlock = BlockMaster.Blocks[jLK03d0ZSlci2XsVe7.Name];
				MasterBlockItem bedrock = masterBlock.bedrock;
				byte count = (byte)(Constants.InventoryMaxCount.ContainsKey(masterBlock.bedrock.id.Value) ? Constants.InventoryMaxCount[masterBlock.bedrock.id.Value] : 64);
				inventoryItem = new InventoryItem((short)bedrock.id.Value, count, 0, 0, text, masterBlock);
				inventoryItem.Tag[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11032)] = xowKAmGvRY(text, masterBlock.bedrock.properties);
			}
		}
		if (inventoryItem != null)
		{
			DoDragDrop(inventoryItem, DragDropEffects.Copy | DragDropEffects.Move);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound xowKAmGvRY(string P_0, List<MasterBlockItemProperty> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] = new TagNodeString(P_0);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19874)] = new TagNodeInt(17760256);
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		if (P_1 != null)
		{
			foreach (MasterBlockItemProperty item in P_1)
			{
				tagNodeCompound2[item.name] = item.GenBlockDataNode();
			}
		}
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892)] = tagNodeCompound2;
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eQfKd0erWO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (FiaK8O17Yd.SelectedItems.Count > 0)
		{
			ListViewItem listViewItem = FiaK8O17Yd.SelectedItems[0];
			jLK03d0ZSlci2XsVe6 jLK03d0ZSlci2XsVe7 = listViewItem.Tag as jLK03d0ZSlci2XsVe6;
			MasterBlockItem bedrock = BlockMaster.Blocks[jLK03d0ZSlci2XsVe7.Name].bedrock;
			InventoryItemEventArg inventoryItemEventArg = new InventoryItemEventArg();
			inventoryItemEventArg.Id = bedrock.id.Value;
			inventoryItemEventArg.Data = (short)bedrock.data.Value;
			OnItemSelected(this, inventoryItemEventArg);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && GZWKjc6PR3 != null)
		{
			GZWKjc6PR3.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void efTKHIlm2A()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FiaK8O17Yd = new ListView();
		LL5K9uNiRQ = new ColumnHeader();
		QpvKIqBng5 = new ColumnHeader();
		BdOKzvicld = new TextBox();
		SuspendLayout();
		FiaK8O17Yd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		FiaK8O17Yd.Columns.AddRange(new ColumnHeader[2] { LL5K9uNiRQ, QpvKIqBng5 });
		FiaK8O17Yd.FullRowSelect = true;
		FiaK8O17Yd.Location = new Point(0, 26);
		FiaK8O17Yd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19908);
		FiaK8O17Yd.Size = new Size(287, 369);
		FiaK8O17Yd.TabIndex = 5;
		FiaK8O17Yd.UseCompatibleStateImageBehavior = false;
		FiaK8O17Yd.View = View.Details;
		FiaK8O17Yd.DoubleClick += eQfKd0erWO;
		LL5K9uNiRQ.Text = "";
		LL5K9uNiRQ.Width = 40;
		QpvKIqBng5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		QpvKIqBng5.Width = 216;
		BdOKzvicld.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		BdOKzvicld.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 8.25f, FontStyle.Italic, GraphicsUnit.Point, 0);
		BdOKzvicld.ForeColor = Color.Gray;
		BdOKzvicld.Location = new Point(0, 0);
		BdOKzvicld.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19932);
		BdOKzvicld.Size = new Size(287, 20);
		BdOKzvicld.TabIndex = 6;
		BdOKzvicld.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19840);
		BdOKzvicld.Enter += sJ5KOoGrx3;
		BdOKzvicld.KeyUp += IcVKQjXCHL;
		BdOKzvicld.Leave += W6gKChLXlP;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(FiaK8O17Yd);
		base.Controls.Add(BdOKzvicld);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19952);
		base.Size = new Size(287, 398);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
