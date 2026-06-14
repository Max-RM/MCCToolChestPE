using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class ConversionStatus : Form
{
	private IContainer TtV1dpBr3Y;

	private Button TfZ1Hq1at4;

	private Label sM41FyYirU;

	private Label bVO1j5NFSU;

	private Label nLt18WZ3vy;

	private Button Maj19oy4fN;

	private Label u8L1IU12i3;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversionStatus(ConvertStatus convertStatus)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		sao1AYi0J7();
		if (convertStatus.LabelType == LabelType.MERGE)
		{
			Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(39990);
			u8L1IU12i3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40018);
			sM41FyYirU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40052) + convertStatus.ProcessedChunkCount;
		}
		else
		{
			sM41FyYirU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40086) + convertStatus.ProcessedChunkCount;
		}
		nLt18WZ3vy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40126) + convertStatus.MissingChunkCount;
		bVO1j5NFSU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40162) + convertStatus.InvalidChunkCount;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void X8A1CLB1Xa(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string target = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40198);
		CallBrowser callBrowser = new CallBrowser();
		callBrowser.Call(target);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SS117EAosS(object P_0, EventArgs P_1)
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
		if (disposing && TtV1dpBr3Y != null)
		{
			TtV1dpBr3Y.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sao1AYi0J7()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TfZ1Hq1at4 = new Button();
		sM41FyYirU = new Label();
		bVO1j5NFSU = new Label();
		nLt18WZ3vy = new Label();
		Maj19oy4fN = new Button();
		u8L1IU12i3 = new Label();
		SuspendLayout();
		TfZ1Hq1at4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TfZ1Hq1at4.DialogResult = DialogResult.Cancel;
		TfZ1Hq1at4.Location = new Point(113, 61);
		TfZ1Hq1at4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38508);
		TfZ1Hq1at4.Size = new Size(75, 23);
		TfZ1Hq1at4.TabIndex = 0;
		TfZ1Hq1at4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38528);
		TfZ1Hq1at4.UseVisualStyleBackColor = true;
		sM41FyYirU.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		sM41FyYirU.Location = new Point(12, 33);
		sM41FyYirU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40302);
		sM41FyYirU.Size = new Size(180, 18);
		sM41FyYirU.TabIndex = 1;
		sM41FyYirU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40342);
		sM41FyYirU.TextAlign = ContentAlignment.MiddleCenter;
		bVO1j5NFSU.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		bVO1j5NFSU.Location = new Point(12, 86);
		bVO1j5NFSU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40378);
		bVO1j5NFSU.Size = new Size(180, 18);
		bVO1j5NFSU.TabIndex = 2;
		bVO1j5NFSU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40414);
		bVO1j5NFSU.TextAlign = ContentAlignment.MiddleCenter;
		bVO1j5NFSU.Visible = false;
		nLt18WZ3vy.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		nLt18WZ3vy.Location = new Point(12, 60);
		nLt18WZ3vy.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40446);
		nLt18WZ3vy.Size = new Size(180, 18);
		nLt18WZ3vy.TabIndex = 3;
		nLt18WZ3vy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40482);
		nLt18WZ3vy.TextAlign = ContentAlignment.MiddleCenter;
		nLt18WZ3vy.Visible = false;
		Maj19oy4fN.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Maj19oy4fN.Location = new Point(18, 61);
		Maj19oy4fN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40514);
		Maj19oy4fN.Size = new Size(75, 23);
		Maj19oy4fN.TabIndex = 4;
		Maj19oy4fN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40532);
		Maj19oy4fN.UseVisualStyleBackColor = true;
		Maj19oy4fN.Click += X8A1CLB1Xa;
		u8L1IU12i3.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 13f, FontStyle.Regular, GraphicsUnit.Point, 0);
		u8L1IU12i3.Location = new Point(6, 3);
		u8L1IU12i3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12118);
		u8L1IU12i3.Size = new Size(195, 28);
		u8L1IU12i3.TabIndex = 5;
		u8L1IU12i3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40544);
		u8L1IU12i3.TextAlign = ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = TfZ1Hq1at4;
		base.ClientSize = new Size(206, 93);
		base.Controls.Add(Maj19oy4fN);
		base.Controls.Add(TfZ1Hq1at4);
		base.Controls.Add(u8L1IU12i3);
		base.Controls.Add(nLt18WZ3vy);
		base.Controls.Add(bVO1j5NFSU);
		base.Controls.Add(sM41FyYirU);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40588);
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40624);
		base.Load += SS117EAosS;
		ResumeLayout(performLayout: false);
	}
}
