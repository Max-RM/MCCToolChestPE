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

public class SkullUI : UserControl
{
	private int wbyfsQdD4p;

	private SkullPicked nmWfq2KomN;

	private IContainer M2MfKVBl9X;

	private PictureBox AJufhH8K92;

	private RadioButton UdpfmuZgrA;

	private Label V24fn1QPA8;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SkullUI(int skullIndex, SkullPicked skullPicked)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		RSMfiU3Okl();
		wbyfsQdD4p = skullIndex;
		nmWfq2KomN = skullPicked;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gStfVUGCOU(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AJufhH8K92.Image = SkullImageManager.SkullImages.Images[wbyfsQdD4p];
		V24fn1QPA8.Text = SkullImagesDefinition.skullImages[wbyfsQdD4p].Caption;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sXtfWXg8Fl(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		nmWfq2KomN(wbyfsQdD4p);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetState(bool active)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UdpfmuZgrA.Checked = active;
		VGJffwJQ5a(active ? Color.LightBlue : Color.White);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wOrfpLxvIY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!UdpfmuZgrA.Checked)
		{
			VGJffwJQ5a(Color.LightBlue);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void W2EfZml2Si(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!UdpfmuZgrA.Checked)
		{
			VGJffwJQ5a(Color.White);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VGJffwJQ5a(Color P_0)
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
		if (disposing && M2MfKVBl9X != null)
		{
			M2MfKVBl9X.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RSMfiU3Okl()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UdpfmuZgrA = new RadioButton();
		V24fn1QPA8 = new Label();
		AJufhH8K92 = new PictureBox();
		((ISupportInitialize)AJufhH8K92).BeginInit();
		SuspendLayout();
		UdpfmuZgrA.AutoSize = true;
		UdpfmuZgrA.Location = new Point(7, 31);
		UdpfmuZgrA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14590);
		UdpfmuZgrA.Size = new Size(14, 13);
		UdpfmuZgrA.TabIndex = 1;
		UdpfmuZgrA.TabStop = true;
		UdpfmuZgrA.UseVisualStyleBackColor = true;
		UdpfmuZgrA.Click += sXtfWXg8Fl;
		UdpfmuZgrA.MouseEnter += wOrfpLxvIY;
		UdpfmuZgrA.MouseLeave += W2EfZml2Si;
		V24fn1QPA8.AutoSize = true;
		V24fn1QPA8.Location = new Point(106, 32);
		V24fn1QPA8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14610);
		V24fn1QPA8.Size = new Size(35, 13);
		V24fn1QPA8.TabIndex = 2;
		V24fn1QPA8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		V24fn1QPA8.Click += sXtfWXg8Fl;
		V24fn1QPA8.MouseEnter += wOrfpLxvIY;
		V24fn1QPA8.MouseLeave += W2EfZml2Si;
		AJufhH8K92.Location = new Point(31, 4);
		AJufhH8K92.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17310);
		AJufhH8K92.Size = new Size(64, 64);
		AJufhH8K92.SizeMode = PictureBoxSizeMode.Zoom;
		AJufhH8K92.TabIndex = 0;
		AJufhH8K92.TabStop = false;
		AJufhH8K92.Click += sXtfWXg8Fl;
		AJufhH8K92.MouseEnter += wOrfpLxvIY;
		AJufhH8K92.MouseLeave += W2EfZml2Si;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(V24fn1QPA8);
		base.Controls.Add(UdpfmuZgrA);
		base.Controls.Add(AJufhH8K92);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17336);
		base.Size = new Size(236, 73);
		base.Load += gStfVUGCOU;
		base.Click += sXtfWXg8Fl;
		base.MouseEnter += wOrfpLxvIY;
		base.MouseLeave += W2EfZml2Si;
		((ISupportInitialize)AJufhH8K92).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
