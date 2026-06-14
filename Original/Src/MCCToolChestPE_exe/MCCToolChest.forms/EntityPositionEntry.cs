using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls.EntityHelpers;
using MCCToolChest.model;
using MCCToolChest.Properties;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class EntityPositionEntry : Form
{
	private IContainer qkJuc8ac2l;

	private PositionUI R68uJyK0kB;

	private PositionUI t7yuuU4V41;

	private Button Mpkuo5cv2F;

	private Button XxIuQxm8Bm;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntityPositionEntry(TagNodeCompound entity, List<ChunkYLayer> layers, int chunkx, int chunkz)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Wu9uDLgqrX();
		R68uJyK0kB.InitUI(entity, layers, chunkx, chunkz);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hZxuNDbJ7L(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && qkJuc8ac2l != null)
		{
			qkJuc8ac2l.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Wu9uDLgqrX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Mpkuo5cv2F = new Button();
		XxIuQxm8Bm = new Button();
		R68uJyK0kB = new PositionUI();
		t7yuuU4V41 = new PositionUI();
		SuspendLayout();
		Mpkuo5cv2F.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Mpkuo5cv2F.DialogResult = DialogResult.Cancel;
		Mpkuo5cv2F.Location = new Point(463, 423);
		Mpkuo5cv2F.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		Mpkuo5cv2F.Size = new Size(50, 23);
		Mpkuo5cv2F.TabIndex = 4;
		Mpkuo5cv2F.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		Mpkuo5cv2F.UseVisualStyleBackColor = true;
		XxIuQxm8Bm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		XxIuQxm8Bm.DialogResult = DialogResult.OK;
		XxIuQxm8Bm.Location = new Point(404, 423);
		XxIuQxm8Bm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		XxIuQxm8Bm.Size = new Size(50, 23);
		XxIuQxm8Bm.TabIndex = 3;
		XxIuQxm8Bm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		XxIuQxm8Bm.UseVisualStyleBackColor = true;
		R68uJyK0kB.Location = new Point(12, 12);
		R68uJyK0kB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54084);
		R68uJyK0kB.Size = new Size(501, 398);
		R68uJyK0kB.TabIndex = 0;
		t7yuuU4V41.Location = new Point(12, 12);
		t7yuuU4V41.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54108);
		t7yuuU4V41.Size = new Size(501, 448);
		t7yuuU4V41.TabIndex = 0;
		base.AcceptButton = XxIuQxm8Bm;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = Mpkuo5cv2F;
		base.ClientSize = new Size(525, 458);
		base.Controls.Add(Mpkuo5cv2F);
		base.Controls.Add(XxIuQxm8Bm);
		base.Controls.Add(R68uJyK0kB);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54134);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54176);
		base.Load += hZxuNDbJ7L;
		ResumeLayout(performLayout: false);
	}
}
