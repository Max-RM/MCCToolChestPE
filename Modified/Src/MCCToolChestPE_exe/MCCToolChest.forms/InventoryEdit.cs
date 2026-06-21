using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.Properties;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class InventoryEdit : Form
{
	private TagNodeCompound rQGAuX3gwE;

	private InventoryType rcHAoOcTjX;

	private IContainer H3VAQP4JWX;

	private InventoryEditor tEXAO8KiJI;

	private Button u2bACiZ8lP;

	private Button yYZA7TkmF7;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventoryEdit(TagNodeCompound node, InventoryType inventoryType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		BayAJmAMix();
		rcHAoOcTjX = inventoryType;
		rQGAuX3gwE = node;
		if (node != null)
		{
			TagNodeList tagNodeList = null;
			string key = ((inventoryType == InventoryType.PlayerInventory) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18452) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59198));
			tagNodeList = ((!node.ContainsKey(key)) ? new TagNodeList(TagType.TAG_COMPOUND) : (node[key] as TagNodeList));
			tEXAO8KiJI.LoadInventory(tagNodeList, inventoryType);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void m4jANoEh4k(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Q4AADOV6yY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mSiAcoJK6U(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.OK;
		TagNodeList tagNodeList = null;
		string key = ((rcHAoOcTjX == InventoryType.PlayerInventory) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18452) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59198));
		if (rQGAuX3gwE.ContainsKey(key))
		{
			tagNodeList = rQGAuX3gwE[key] as TagNodeList;
		}
		else
		{
			tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
			rQGAuX3gwE[key] = tagNodeList;
		}
		tEXAO8KiJI.Save(tagNodeList);
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && H3VAQP4JWX != null)
		{
			H3VAQP4JWX.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BayAJmAMix()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tEXAO8KiJI = new InventoryEditor();
		u2bACiZ8lP = new Button();
		yYZA7TkmF7 = new Button();
		SuspendLayout();
		tEXAO8KiJI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tEXAO8KiJI.Location = new Point(0, 0);
		tEXAO8KiJI.Margin = new Padding(0);
		tEXAO8KiJI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14112);
		tEXAO8KiJI.Size = new Size(798, 498);
		tEXAO8KiJI.TabIndex = 0;
		u2bACiZ8lP.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		u2bACiZ8lP.DialogResult = DialogResult.Cancel;
		u2bACiZ8lP.Location = new Point(706, 506);
		u2bACiZ8lP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53508);
		u2bACiZ8lP.Size = new Size(75, 23);
		u2bACiZ8lP.TabIndex = 16;
		u2bACiZ8lP.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		u2bACiZ8lP.UseVisualStyleBackColor = true;
		u2bACiZ8lP.Click += Q4AADOV6yY;
		yYZA7TkmF7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		yYZA7TkmF7.Location = new Point(619, 506);
		yYZA7TkmF7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35742);
		yYZA7TkmF7.Size = new Size(75, 23);
		yYZA7TkmF7.TabIndex = 17;
		yYZA7TkmF7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53536);
		yYZA7TkmF7.Click += mSiAcoJK6U;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(798, 536);
		base.Controls.Add(u2bACiZ8lP);
		base.Controls.Add(yYZA7TkmF7);
		base.Controls.Add(tEXAO8KiJI);
		base.HelpButton = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59240);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59270);
		base.Load += m4jANoEh4k;
		ResumeLayout(performLayout: false);
	}
}
