using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class PostProcessingSRGUI : UserControl
{
	public PostProcessingSRG postProcessingSRG;

	private IContainer ExFaAGBWA0;

	private CheckBox lQHadDgQy8;

	private CheckBox oyqaHENCtQ;

	private CheckBox kWEaFGXOBI;

	private CheckBox NSGajZGJMm;

	private Label gLRa8gMocX;

	private Label mtma9kLBZ5;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PostProcessingSRGUI(PostProcessingSRG postProcessingSRG)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		nMca765JRE();
		this.postProcessingSRG = postProcessingSRG;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void k89aCCMxDl(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lQHadDgQy8.Text = postProcessingSRG.name;
		lQHadDgQy8.Checked = postProcessingSRG.active;
		oyqaHENCtQ.Checked = postProcessingSRG.overworld;
		NSGajZGJMm.Checked = postProcessingSRG.nether;
		kWEaFGXOBI.Checked = postProcessingSRG.theEnd;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PostProcessingSRG UpdatePostProcessingSRG()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		postProcessingSRG.active = lQHadDgQy8.Checked;
		postProcessingSRG.overworld = oyqaHENCtQ.Checked;
		postProcessingSRG.nether = NSGajZGJMm.Checked;
		postProcessingSRG.theEnd = kWEaFGXOBI.Checked;
		return postProcessingSRG;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && ExFaAGBWA0 != null)
		{
			ExFaAGBWA0.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nMca765JRE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lQHadDgQy8 = new CheckBox();
		oyqaHENCtQ = new CheckBox();
		kWEaFGXOBI = new CheckBox();
		NSGajZGJMm = new CheckBox();
		gLRa8gMocX = new Label();
		mtma9kLBZ5 = new Label();
		SuspendLayout();
		lQHadDgQy8.AutoSize = true;
		lQHadDgQy8.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lQHadDgQy8.Location = new Point(40, 4);
		lQHadDgQy8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28626);
		lQHadDgQy8.Size = new Size(94, 21);
		lQHadDgQy8.TabIndex = 0;
		lQHadDgQy8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28648);
		lQHadDgQy8.UseVisualStyleBackColor = true;
		oyqaHENCtQ.AutoSize = true;
		oyqaHENCtQ.Location = new Point(54, 25);
		oyqaHENCtQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28666);
		oyqaHENCtQ.Size = new Size(74, 17);
		oyqaHENCtQ.TabIndex = 1;
		oyqaHENCtQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28692);
		oyqaHENCtQ.UseVisualStyleBackColor = true;
		kWEaFGXOBI.AutoSize = true;
		kWEaFGXOBI.Location = new Point(220, 25);
		kWEaFGXOBI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28714);
		kWEaFGXOBI.Size = new Size(67, 17);
		kWEaFGXOBI.TabIndex = 2;
		kWEaFGXOBI.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28734);
		kWEaFGXOBI.UseVisualStyleBackColor = true;
		NSGajZGJMm.AutoSize = true;
		NSGajZGJMm.Location = new Point(145, 25);
		NSGajZGJMm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28752);
		NSGajZGJMm.Size = new Size(58, 17);
		NSGajZGJMm.TabIndex = 3;
		NSGajZGJMm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28772);
		NSGajZGJMm.UseVisualStyleBackColor = true;
		gLRa8gMocX.AutoSize = true;
		gLRa8gMocX.Location = new Point(3, 26);
		gLRa8gMocX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		gLRa8gMocX.Size = new Size(45, 13);
		gLRa8gMocX.TabIndex = 4;
		gLRa8gMocX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28788);
		mtma9kLBZ5.AutoSize = true;
		mtma9kLBZ5.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		mtma9kLBZ5.Location = new Point(3, 4);
		mtma9kLBZ5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		mtma9kLBZ5.Size = new Size(34, 17);
		mtma9kLBZ5.TabIndex = 5;
		mtma9kLBZ5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28806);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(mtma9kLBZ5);
		base.Controls.Add(gLRa8gMocX);
		base.Controls.Add(NSGajZGJMm);
		base.Controls.Add(kWEaFGXOBI);
		base.Controls.Add(oyqaHENCtQ);
		base.Controls.Add(lQHadDgQy8);
		base.Margin = new Padding(3, 1, 3, 1);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28816);
		base.Size = new Size(307, 45);
		base.Load += k89aCCMxDl;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
