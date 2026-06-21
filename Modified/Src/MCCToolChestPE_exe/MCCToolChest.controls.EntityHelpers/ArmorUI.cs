using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class ArmorUI : UserControl
{
	private int CgTWRvlQhW;

	private TagNodeCompound wvPWkpsuHT;

	private IContainer LfvWY16wCG;

	private EntityHelperHeader pFkW3EoyML;

	private InventoryEditor UwIW1B4nef;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArmorUI(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		N1TWPgX6hj();
		wvPWkpsuHT = entity;
		qndWUGkiHR();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qndWUGkiHR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		if (wvPWkpsuHT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13950)))
		{
			TagNodeList tagNodeList2 = wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13950)] as TagNodeList;
			for (int i = 0; i < tagNodeList2.Count; i++)
			{
				TagNodeCompound tagNodeCompound = tagNodeList2[i].Copy() as TagNodeCompound;
				if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
				{
					tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] = new TagNodeByte((byte)i);
					tagNodeList.Add(tagNodeCompound);
				}
			}
		}
		else if (wvPWkpsuHT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13984)))
		{
			TagNodeList tagNodeList3 = wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13984)] as TagNodeList;
			for (int j = 0; j < tagNodeList3.Count; j++)
			{
				TagNodeCompound tagNodeCompound2 = tagNodeList3[j].Copy() as TagNodeCompound;
				if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
				{
					tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] = new TagNodeByte((byte)(j + 1));
					tagNodeList.Add(tagNodeCompound2);
				}
			}
		}
		if (wvPWkpsuHT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13998)))
		{
			TagNodeList tagNodeList4 = wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13998)] as TagNodeList;
			for (int k = 0; k < tagNodeList4.Count; k++)
			{
				TagNodeCompound tagNodeCompound3 = tagNodeList4[k].Copy() as TagNodeCompound;
				if (tagNodeCompound3.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
				{
					byte d = (byte)((k == 0) ? ((uint)k) : 5u);
					tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] = new TagNodeByte(d);
					tagNodeList.Add(tagNodeCompound3);
				}
			}
		}
		if (wvPWkpsuHT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14020)))
		{
			TagNodeList tagNodeList5 = wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14020)] as TagNodeList;
			if (tagNodeList5.Count > 0)
			{
				TagNodeCompound tagNodeCompound4 = tagNodeList5[0].Copy() as TagNodeCompound;
				if (tagNodeCompound4.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
				{
					byte d2 = 0;
					tagNodeCompound4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] = new TagNodeByte(d2);
					tagNodeList.Add(tagNodeCompound4);
				}
			}
		}
		if (wvPWkpsuHT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14040)))
		{
			TagNodeList tagNodeList6 = wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14040)] as TagNodeList;
			if (tagNodeList6.Count > 0)
			{
				TagNodeCompound tagNodeCompound5 = tagNodeList6[0].Copy() as TagNodeCompound;
				if (tagNodeCompound5.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
				{
					byte d3 = 5;
					tagNodeCompound5[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] = new TagNodeByte(d3);
					tagNodeList.Add(tagNodeCompound5);
				}
			}
		}
		UwIW1B4nef.LoadInventory(tagNodeList, InventoryType.Armor);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveArmor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		UwIW1B4nef.Save(tagNodeList);
		wvPWkpsuHT.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13950));
		if (!wvPWkpsuHT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13984)))
		{
			TagNodeList value = new TagNodeList(TagType.TAG_COMPOUND);
			wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13984)] = value;
		}
		if (!wvPWkpsuHT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14020)))
		{
			TagNodeList value2 = new TagNodeList(TagType.TAG_COMPOUND);
			wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14020)] = value2;
		}
		if (!wvPWkpsuHT.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14040)))
		{
			TagNodeList value3 = new TagNodeList(TagType.TAG_COMPOUND);
			wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14040)] = value3;
		}
		TagNodeList tagNodeList2 = wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13984)] as TagNodeList;
		TagNodeList tagNodeList3 = wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14020)] as TagNodeList;
		TagNodeList tagNodeList4 = wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14040)] as TagNodeList;
		wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14058)] = qhAWLMTCbX();
		tagNodeList2.Clear();
		for (int i = tagNodeList2.Count; i < 4; i++)
		{
			tagNodeList2.Add(qhAWLMTCbX());
		}
		tagNodeList3.Clear();
		tagNodeList3.Add(qhAWLMTCbX());
		tagNodeList4.Clear();
		tagNodeList4.Add(qhAWLMTCbX());
		for (int j = 0; j < tagNodeList.Count; j++)
		{
			TagNodeCompound tagNodeCompound = tagNodeList[j] as TagNodeCompound;
			byte b = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972)] as TagNodeByte;
			switch (b)
			{
			case 0:
			{
				tagNodeList3[0] = tagNodeCompound;
				TagNodeCompound tagNodeCompound2 = tagNodeCompound.Copy() as TagNodeCompound;
				tagNodeCompound2.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972));
				wvPWkpsuHT[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14058)] = tagNodeCompound2;
				break;
			}
			case 5:
				tagNodeList4[0] = tagNodeCompound;
				break;
			default:
				tagNodeList2[b - 1] = tagNodeCompound;
				break;
			}
			tagNodeCompound.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13972));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound qhAWLMTCbX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14082)] = new TagNodeByte(0);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14096)] = new TagNodeShort(0);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] = new TagNodeShort(0);
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bZcWgtLMMk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (pFkW3EoyML.ViewState == EntityHelperViewState.Contracted)
		{
			CgTWRvlQhW = base.Height;
			base.Height = pFkW3EoyML.Top + pFkW3EoyML.Height;
		}
		else
		{
			base.Height = CgTWRvlQhW;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && LfvWY16wCG != null)
		{
			LfvWY16wCG.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void N1TWPgX6hj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UwIW1B4nef = new InventoryEditor();
		pFkW3EoyML = new EntityHelperHeader();
		SuspendLayout();
		UwIW1B4nef.Dock = DockStyle.Fill;
		UwIW1B4nef.InventoryType = InventoryType.Armor;
		UwIW1B4nef.Location = new Point(0, 35);
		UwIW1B4nef.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14112);
		UwIW1B4nef.Size = new Size(727, 342);
		UwIW1B4nef.TabIndex = 1;
		pFkW3EoyML.BackColor = Color.Silver;
		pFkW3EoyML.Dock = DockStyle.Top;
		pFkW3EoyML.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		pFkW3EoyML.ForeColor = Color.Black;
		pFkW3EoyML.Location = new Point(0, 0);
		pFkW3EoyML.Margin = new Padding(4);
		pFkW3EoyML.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		pFkW3EoyML.Size = new Size(727, 35);
		pFkW3EoyML.TabIndex = 0;
		pFkW3EoyML.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13984);
		pFkW3EoyML.ViewState = EntityHelperViewState.Expanded;
		pFkW3EoyML.ChangeViewState += bZcWgtLMMk;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(UwIW1B4nef);
		base.Controls.Add(pFkW3EoyML);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14190);
		base.Size = new Size(727, 377);
		ResumeLayout(performLayout: false);
	}
}
