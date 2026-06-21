using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.ConfigData;
using MCCToolChest.controllers;
using MCCToolChest.events;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class BedUI : UserControl
{
	private int GOQpD2ka7N;

	private BedColorPicked RERpc2tMGB;

	private IContainer p7VpJtr3p3;

	private PictureBox uYlpu40GPu;

	private RadioButton Yjppoau5bA;

	private Label DbopQl7RKk;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BedUI(int bedIndex, BedColorPicked colorPicked)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		WGEpNa5Feu();
		GOQpD2ka7N = bedIndex;
		RERpc2tMGB = colorPicked;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aDrp16m4a3(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uYlpu40GPu.Image = BedImageManager.BedImages.Images[GOQpD2ka7N];
		DbopQl7RKk.Text = BedImagesDefinition.bedImages[GOQpD2ka7N].Caption;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kOhpE4ifmR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RERpc2tMGB(GOQpD2ka7N);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetState(bool active)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Yjppoau5bA.Checked = active;
		INYp6WwgNH(active ? Color.LightBlue : Color.White);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void w9MprWdxFb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Yjppoau5bA.Checked)
		{
			INYp6WwgNH(Color.LightBlue);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NWep5SeAjI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Yjppoau5bA.Checked)
		{
			INYp6WwgNH(Color.White);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void INYp6WwgNH(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && p7VpJtr3p3 != null)
		{
			p7VpJtr3p3.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WGEpNa5Feu()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Yjppoau5bA = new RadioButton();
		DbopQl7RKk = new Label();
		uYlpu40GPu = new PictureBox();
		((ISupportInitialize)uYlpu40GPu).BeginInit();
		SuspendLayout();
		Yjppoau5bA.AutoSize = true;
		Yjppoau5bA.Location = new Point(7, 14);
		Yjppoau5bA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14590);
		Yjppoau5bA.Size = new Size(14, 13);
		Yjppoau5bA.TabIndex = 1;
		Yjppoau5bA.TabStop = true;
		Yjppoau5bA.UseVisualStyleBackColor = true;
		Yjppoau5bA.Click += kOhpE4ifmR;
		Yjppoau5bA.MouseEnter += w9MprWdxFb;
		Yjppoau5bA.MouseLeave += NWep5SeAjI;
		DbopQl7RKk.AutoSize = true;
		DbopQl7RKk.Location = new Point(69, 14);
		DbopQl7RKk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14610);
		DbopQl7RKk.Size = new Size(35, 13);
		DbopQl7RKk.TabIndex = 2;
		DbopQl7RKk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		DbopQl7RKk.Click += kOhpE4ifmR;
		DbopQl7RKk.MouseEnter += w9MprWdxFb;
		DbopQl7RKk.MouseLeave += NWep5SeAjI;
		uYlpu40GPu.Location = new Point(31, 3);
		uYlpu40GPu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14634);
		uYlpu40GPu.Size = new Size(32, 32);
		uYlpu40GPu.SizeMode = PictureBoxSizeMode.Zoom;
		uYlpu40GPu.TabIndex = 0;
		uYlpu40GPu.TabStop = false;
		uYlpu40GPu.Click += kOhpE4ifmR;
		uYlpu40GPu.MouseEnter += w9MprWdxFb;
		uYlpu40GPu.MouseLeave += NWep5SeAjI;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(DbopQl7RKk);
		base.Controls.Add(Yjppoau5bA);
		base.Controls.Add(uYlpu40GPu);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14656);
		base.Size = new Size(236, 38);
		base.Load += aDrp16m4a3;
		base.Click += kOhpE4ifmR;
		base.MouseEnter += w9MprWdxFb;
		base.MouseLeave += NWep5SeAjI;
		((ISupportInitialize)uYlpu40GPu).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
