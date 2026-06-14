using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class InventoryUI : UserControl
{
	private int Ftnsq8hxd3;

	private TagNodeCompound yQnsKyLUIT;

	private Dictionary<string, InventoryType> kijshKmeDA;

	private IContainer WJism8XtiI;

	private EntityHelperHeader dhysnENcto;

	private InventoryEditor BpWslYv3jS;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventoryUI(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		kijshKmeDA = new Dictionary<string, InventoryType>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6256),
				InventoryType.Tiny
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15120),
				InventoryType.Tiny
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15292),
				InventoryType.Medium
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15308),
				InventoryType.Medium
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15344),
				InventoryType.Medium
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15362),
				InventoryType.Medium
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15400),
				InventoryType.Medium
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15422),
				InventoryType.Medium
			}
		};
		j6OssccDVa();
		yQnsKyLUIT = entity;
		ejMsfuNMP4();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList iirsZY2fsn()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!yQnsKyLUIT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)))
		{
			yQnsKyLUIT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] = new TagNodeList(TagType.TAG_COMPOUND);
		}
		return yQnsKyLUIT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] as TagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ejMsfuNMP4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		InventoryType inventoryType = InventoryType.Standard;
		string text = null;
		if (yQnsKyLUIT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && yQnsKyLUIT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
		{
			text = yQnsKyLUIT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] as TagNodeString;
		}
		if (text != null && kijshKmeDA.ContainsKey(text))
		{
			inventoryType = kijshKmeDA[text];
		}
		TagNodeList inventory = iirsZY2fsn();
		BpWslYv3jS.LoadInventory(inventory, inventoryType);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveInventory()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList container = iirsZY2fsn();
		BpWslYv3jS.Save(container);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qQ7si81sj1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (dhysnENcto.ViewState == EntityHelperViewState.Contracted)
		{
			Ftnsq8hxd3 = base.Height;
			base.Height = dhysnENcto.Top + dhysnENcto.Height;
		}
		else
		{
			base.Height = Ftnsq8hxd3;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && WJism8XtiI != null)
		{
			WJism8XtiI.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void j6OssccDVa()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BpWslYv3jS = new InventoryEditor();
		dhysnENcto = new EntityHelperHeader();
		SuspendLayout();
		BpWslYv3jS.Dock = DockStyle.Fill;
		BpWslYv3jS.InventoryType = InventoryType.Standard;
		BpWslYv3jS.Location = new Point(0, 35);
		BpWslYv3jS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14112);
		BpWslYv3jS.Size = new Size(727, 342);
		BpWslYv3jS.TabIndex = 1;
		dhysnENcto.BackColor = Color.Silver;
		dhysnENcto.Dock = DockStyle.Top;
		dhysnENcto.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dhysnENcto.ForeColor = Color.Black;
		dhysnENcto.Location = new Point(0, 0);
		dhysnENcto.Margin = new Padding(4);
		dhysnENcto.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		dhysnENcto.Size = new Size(727, 35);
		dhysnENcto.TabIndex = 0;
		dhysnENcto.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18452);
		dhysnENcto.ViewState = EntityHelperViewState.Expanded;
		dhysnENcto.ChangeViewState += qQ7si81sj1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(BpWslYv3jS);
		base.Controls.Add(dhysnENcto);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18474);
		base.Size = new Size(727, 377);
		ResumeLayout(performLayout: false);
	}
}
