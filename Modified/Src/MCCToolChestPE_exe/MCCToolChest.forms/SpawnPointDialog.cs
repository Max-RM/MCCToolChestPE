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

public class SpawnPointDialog : Form
{
	private IContainer CGm8hYnkHG;

	private Button tne8mx2peV;

	private Button hv88nTy4vx;

	private PositionUI rFa8litK8S;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpawnPointDialog(TagNodeCompound entity, List<ChunkYLayer> layers, int chunkx, int chunkz)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Sua8Kxvfg1();
		rFa8litK8S.InitUI(entity, layers, chunkx, chunkz);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RBH8qEggWn(object P_0, EventArgs P_1)
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
		if (disposing && CGm8hYnkHG != null)
		{
			CGm8hYnkHG.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Sua8Kxvfg1()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tne8mx2peV = new Button();
		hv88nTy4vx = new Button();
		rFa8litK8S = new PositionUI();
		SuspendLayout();
		tne8mx2peV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tne8mx2peV.DialogResult = DialogResult.Cancel;
		tne8mx2peV.Location = new Point(463, 423);
		tne8mx2peV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		tne8mx2peV.Size = new Size(50, 23);
		tne8mx2peV.TabIndex = 7;
		tne8mx2peV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		tne8mx2peV.UseVisualStyleBackColor = true;
		hv88nTy4vx.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		hv88nTy4vx.DialogResult = DialogResult.OK;
		hv88nTy4vx.Location = new Point(404, 423);
		hv88nTy4vx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		hv88nTy4vx.Size = new Size(50, 23);
		hv88nTy4vx.TabIndex = 6;
		hv88nTy4vx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		hv88nTy4vx.UseVisualStyleBackColor = true;
		rFa8litK8S.Location = new Point(12, 12);
		rFa8litK8S.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54084);
		rFa8litK8S.Size = new Size(501, 398);
		rFa8litK8S.TabIndex = 5;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(525, 458);
		base.Controls.Add(tne8mx2peV);
		base.Controls.Add(hv88nTy4vx);
		base.Controls.Add(rFa8litK8S);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62362);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62398);
		ResumeLayout(performLayout: false);
	}
}
