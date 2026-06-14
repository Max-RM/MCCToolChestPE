using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DekWW8jSE3fVOo1d5ao;
using MCCToolChest.model;
using NBTExplorer.Model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class EntityHelperContainer : UserControl
{
	private delegate void Jw5CD7VFGuXsbCtY13(TagNodeCompound entity, FlowLayoutPanel flp);

	private int qg6ZhVwLl4;

	private int ttTZmf9pBE;

	private List<ChunkYLayer> fu5Zn828fZ;

	private EntityLookup kuGZlT4WEA;

	private TagNodeCompound qaWZ2XmomN;

	private EventHandler XFLZyfg9Pw;

	private List<string> C29Z0kMqEn;

	private List<string> aKNZBWGys4;

	private IContainer jwRZtGsrXO;

	private TabControl PURZa6XNsQ;

	private TabPage usbZXt0S9T;

	private FlowLayoutPanel m6HZxlGB7m;

	private TabPage pxrZeBhLWw;

	private NBTFrame GLbZMynVp2;

	public int ChunkX
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return qg6ZhVwLl4;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			qg6ZhVwLl4 = value;
		}
	}

	public int ChunkZ
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ttTZmf9pBE;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ttTZmf9pBE = value;
		}
	}

	public List<ChunkYLayer> Layers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return fu5Zn828fZ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			fu5Zn828fZ = value;
		}
	}

	public TagNodeCompound ActiveEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return qaWZ2XmomN;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			qaWZ2XmomN = value;
			if (value != null)
			{
				SetNBT(value);
				SetEntityDisplay(value);
			}
		}
	}

	public event EventHandler EntityChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = XFLZyfg9Pw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref XFLZyfg9Pw, value2, eventHandler2);
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
			EventHandler eventHandler = XFLZyfg9Pw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref XFLZyfg9Pw, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntityHelperContainer()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		kuGZlT4WEA = new EntityLookup();
		C29Z0kMqEn = new List<string>
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6490),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14850),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6534),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14886),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(2508),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14936),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6412),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14974),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7614),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15014)
		};
		aKNZBWGys4 = new List<string>
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6056),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15068),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6256),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15120),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15174),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15188),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15222),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15246),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15292),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15308),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15344),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15362),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15400),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15422),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15464),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15488)
		};
		b70ZKOyZaj();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNBT(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (entity != null)
		{
			TagCompoundDataNode node = new TagCompoundDataNode(entity);
			GLbZMynVp2.OpenExistingNode(node);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResizeEntityHelpers()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TabPage tabPage = PURZa6XNsQ.TabPages[0];
		if (tabPage != null && tabPage.Controls.Count > 0)
		{
			Control control = tabPage.Controls[0];
			int num = control.ClientSize.Width - 10;
			for (int i = 0; i < control.Controls.Count; i++)
			{
				control.Controls[i].Width = num;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void W4cZGdCSMQ(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SaveEntityChanges();
		FlowLayoutPanel flowLayoutPanel = PURZa6XNsQ.TabPages[0].Controls[0] as FlowLayoutPanel;
		flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
		flowLayoutPanel.WrapContents = false;
		flowLayoutPanel.Controls.Clear();
		string iDName = GetIDName(P_0);
		if (iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7448) || iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15534))
		{
			a5vZ4RHPgR(iDName, P_0, flowLayoutPanel);
		}
		else if (aKNZBWGys4.Contains(iDName))
		{
			H3UZvA5u49(iDName, P_0, flowLayoutPanel);
		}
		else if ((kuGZlT4WEA.ConsoleEntities.ContainsKey(iDName) && kuGZlT4WEA.ConsoleEntities[iDName].EntityCategory == EntityCategory.MOB) || (kuGZlT4WEA.PCEntities.ContainsKey(iDName) && kuGZlT4WEA.PCEntities[iDName].EntityCategory == EntityCategory.MOB))
		{
			DV0ZwqYT2f(iDName, P_0, flowLayoutPanel);
		}
		if (iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14546) || iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15574))
		{
			gQrZVsaeyo(iDName, P_0, flowLayoutPanel);
		}
		if (iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15604) || iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15616))
		{
			I2lZWhnXm8(iDName, P_0, flowLayoutPanel);
		}
		if (iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(2564) || iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15648))
		{
			VlvZp7oHX9(iDName, P_0, flowLayoutPanel);
		}
		if (iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15682) || iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15706))
		{
			hliZZRD8hN(iDName, P_0, flowLayoutPanel);
		}
		if (iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14496) || iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15752))
		{
			ncVZfjN58A(iDName, P_0, flowLayoutPanel);
		}
		if (iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14806) || iDName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15788))
		{
			V5fZi0IAb6(iDName, P_0, flowLayoutPanel);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearDisplay()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlowLayoutPanel flowLayoutPanel = PURZa6XNsQ.TabPages[0].Controls[0] as FlowLayoutPanel;
		flowLayoutPanel.Controls.Clear();
		GLbZMynVp2.ClearDisplay();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetIDName(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = string.Empty;
		if (entity != null)
		{
			if (entity.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && entity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				text = (TagNodeString)entity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
			}
			else if (entity.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && entity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				int key = entity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeInt;
				if (hvd0XujpavSpj5UhiI6.eCfSVZfnEaD().ContainsKey(key))
				{
					text = hvd0XujpavSpj5UhiI6.eCfSVZfnEaD()[key].Name;
				}
				else if (hvd0XujpavSpj5UhiI6.WBHSVsHEOJC().ContainsKey(key))
				{
					text = hvd0XujpavSpj5UhiI6.WBHSVsHEOJC()[key].Name;
				}
				if (kuGZlT4WEA.PCEntities.ContainsKey(text))
				{
					text = kuGZlT4WEA.PCEntities[text].PCOldName;
				}
			}
			else if (entity.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15828)) && entity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15828)] is TagNodeString)
			{
				text = (TagNodeString)entity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15828)];
			}
		}
		return text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HeyZb7E4yQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEntityChanged(this, new EventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void H3UZvA5u49(string P_0, TagNodeCompound P_1, FlowLayoutPanel P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CustomName customName = new CustomName(P_1, HeyZb7E4yQ);
		P_2.Controls.Add(customName);
		InventoryUI inventoryUI = new InventoryUI(P_1);
		P_2.Controls.Add(inventoryUI);
		customName.Width = P_2.ClientSize.Width - 10;
		inventoryUI.Width = P_2.ClientSize.Width - 10;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DV0ZwqYT2f(string P_0, TagNodeCompound P_1, FlowLayoutPanel P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CustomName customName = new CustomName(P_1, HeyZb7E4yQ);
		P_2.Controls.Add(customName);
		ArmorUI armorUI = new ArmorUI(P_1);
		if (C29Z0kMqEn.Contains(P_0))
		{
			P_2.Controls.Add(armorUI);
		}
		PositionUI positionUI = new PositionUI(P_1, fu5Zn828fZ, qg6ZhVwLl4, ttTZmf9pBE);
		P_2.Controls.Add(positionUI);
		customName.Width = P_2.ClientSize.Width - 10;
		armorUI.Width = P_2.ClientSize.Width - 10;
		positionUI.Width = P_2.ClientSize.Width - 10;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void a5vZ4RHPgR(string P_0, TagNodeCompound P_1, FlowLayoutPanel P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CustomName customName = new CustomName(P_1, HeyZb7E4yQ);
		P_2.Controls.Add(customName);
		VillagerProfessionUI villagerProfessionUI = new VillagerProfessionUI(P_1);
		P_2.Controls.Add(villagerProfessionUI);
		OfferEditorUI offerEditorUI = new OfferEditorUI(P_1);
		P_2.Controls.Add(offerEditorUI);
		ArmorUI armorUI = new ArmorUI(P_1);
		P_2.Controls.Add(armorUI);
		PositionUI positionUI = new PositionUI(P_1, fu5Zn828fZ, qg6ZhVwLl4, ttTZmf9pBE);
		P_2.Controls.Add(positionUI);
		customName.Width = P_2.ClientSize.Width - 10;
		villagerProfessionUI.Width = P_2.ClientSize.Width - 10;
		offerEditorUI.Width = P_2.ClientSize.Width - 10;
		armorUI.Width = P_2.ClientSize.Width - 10;
		positionUI.Width = P_2.ClientSize.Width - 10;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gQrZVsaeyo(string P_0, TagNodeCompound P_1, FlowLayoutPanel P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BedsUI bedsUI = new BedsUI(P_1, HeyZb7E4yQ);
		P_2.Controls.Add(bedsUI);
		bedsUI.Width = P_2.ClientSize.Width - 10;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I2lZWhnXm8(string P_0, TagNodeCompound P_1, FlowLayoutPanel P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SignUI signUI = new SignUI(P_1);
		P_2.Controls.Add(signUI);
		signUI.Width = P_2.ClientSize.Width - 10;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VlvZp7oHX9(string P_0, TagNodeCompound P_1, FlowLayoutPanel P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SkullsUI skullsUI = new SkullsUI(P_1, HeyZb7E4yQ);
		P_2.Controls.Add(skullsUI);
		skullsUI.Width = P_2.ClientSize.Width - 10;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hliZZRD8hN(string P_0, TagNodeCompound P_1, FlowLayoutPanel P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MobSpawnerUI mobSpawnerUI = new MobSpawnerUI(P_1);
		P_2.Controls.Add(mobSpawnerUI);
		mobSpawnerUI.Width = P_2.ClientSize.Width - 10;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ncVZfjN58A(string P_0, TagNodeCompound P_1, FlowLayoutPanel P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BannerUI bannerUI = new BannerUI(P_1);
		P_2.Controls.Add(bannerUI);
		bannerUI.Width = P_2.ClientSize.Width - 10;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void V5fZi0IAb6(string P_0, TagNodeCompound P_1, FlowLayoutPanel P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CauldronUI cauldronUI = new CauldronUI(P_1);
		P_2.Controls.Add(cauldronUI);
		cauldronUI.Width = P_2.ClientSize.Width - 10;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveEntityChanges()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlowLayoutPanel flowLayoutPanel = PURZa6XNsQ.TabPages[0].Controls[0] as FlowLayoutPanel;
		for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
		{
			if (flowLayoutPanel.Controls[i] is InventoryUI)
			{
				(flowLayoutPanel.Controls[i] as InventoryUI).SaveInventory();
			}
			if (flowLayoutPanel.Controls[i] is ArmorUI)
			{
				(flowLayoutPanel.Controls[i] as ArmorUI).SaveArmor();
			}
			if (flowLayoutPanel.Controls[i] is OfferEditorUI)
			{
				(flowLayoutPanel.Controls[i] as OfferEditorUI).UpdateInventory();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nw8ZsLv1Gv(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (PURZa6XNsQ.SelectedIndex == 0)
		{
			SetEntityDisplay(qaWZ2XmomN);
		}
		else if (PURZa6XNsQ.SelectedIndex == 1)
		{
			SetNBT(qaWZ2XmomN);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEntityDisplay(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string iDName = GetIDName(entity);
		PURZa6XNsQ.TabPages[0].Text = iDName;
		W4cZGdCSMQ(entity);
		PURZa6XNsQ.TabPages[0].Controls[0].Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YGoZqN1RVe(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = (TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
		PURZa6XNsQ.TabPages.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15852), text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnEntityChanged(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XFLZyfg9Pw?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && jwRZtGsrXO != null)
		{
			jwRZtGsrXO.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void b70ZKOyZaj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PURZa6XNsQ = new TabControl();
		usbZXt0S9T = new TabPage();
		m6HZxlGB7m = new FlowLayoutPanel();
		pxrZeBhLWw = new TabPage();
		GLbZMynVp2 = new NBTFrame();
		PURZa6XNsQ.SuspendLayout();
		usbZXt0S9T.SuspendLayout();
		pxrZeBhLWw.SuspendLayout();
		SuspendLayout();
		PURZa6XNsQ.Controls.Add(usbZXt0S9T);
		PURZa6XNsQ.Controls.Add(pxrZeBhLWw);
		PURZa6XNsQ.Dock = DockStyle.Fill;
		PURZa6XNsQ.Location = new Point(0, 0);
		PURZa6XNsQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15868);
		PURZa6XNsQ.SelectedIndex = 0;
		PURZa6XNsQ.Size = new Size(698, 629);
		PURZa6XNsQ.TabIndex = 1;
		PURZa6XNsQ.SelectedIndexChanged += nw8ZsLv1Gv;
		usbZXt0S9T.Controls.Add(m6HZxlGB7m);
		usbZXt0S9T.Location = new Point(4, 22);
		usbZXt0S9T.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15898);
		usbZXt0S9T.Padding = new Padding(3);
		usbZXt0S9T.Size = new Size(690, 603);
		usbZXt0S9T.TabIndex = 1;
		usbZXt0S9T.UseVisualStyleBackColor = true;
		m6HZxlGB7m.AutoScroll = true;
		m6HZxlGB7m.Dock = DockStyle.Fill;
		m6HZxlGB7m.Location = new Point(3, 3);
		m6HZxlGB7m.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15918);
		m6HZxlGB7m.Size = new Size(684, 597);
		m6HZxlGB7m.TabIndex = 0;
		pxrZeBhLWw.Controls.Add(GLbZMynVp2);
		pxrZeBhLWw.Location = new Point(4, 22);
		pxrZeBhLWw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15954);
		pxrZeBhLWw.Padding = new Padding(3);
		pxrZeBhLWw.Size = new Size(690, 603);
		pxrZeBhLWw.TabIndex = 0;
		pxrZeBhLWw.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15976);
		pxrZeBhLWw.UseVisualStyleBackColor = true;
		GLbZMynVp2.Dock = DockStyle.Fill;
		GLbZMynVp2.Location = new Point(3, 3);
		GLbZMynVp2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15986);
		GLbZMynVp2.Size = new Size(684, 597);
		GLbZMynVp2.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(PURZa6XNsQ);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16008);
		base.Size = new Size(698, 629);
		PURZa6XNsQ.ResumeLayout(performLayout: false);
		usbZXt0S9T.ResumeLayout(performLayout: false);
		pxrZeBhLWw.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
