using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class PostProcessing : Form
{
	private IContainer al1PRqw5kM;

	private Button BBcPkCNGd5;

	private Button QGDPYHY31t;

	private PostProcessingSRGListUI Cr2P3dWFXD;

	private Label mS1P1qgtXS;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PostProcessing()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		GtiPPFK0hy();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xhqPLIsPm4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		Cr2P3dWFXD.DisplayList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KQXPg9UnXh(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cr2P3dWFXD.SavePostProcessingList();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && al1PRqw5kM != null)
		{
			al1PRqw5kM.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GtiPPFK0hy()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BBcPkCNGd5 = new Button();
		QGDPYHY31t = new Button();
		mS1P1qgtXS = new Label();
		Cr2P3dWFXD = new PostProcessingSRGListUI();
		SuspendLayout();
		BBcPkCNGd5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BBcPkCNGd5.DialogResult = DialogResult.Cancel;
		BBcPkCNGd5.Location = new Point(308, 505);
		BBcPkCNGd5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		BBcPkCNGd5.Size = new Size(50, 23);
		BBcPkCNGd5.TabIndex = 11;
		BBcPkCNGd5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		BBcPkCNGd5.UseVisualStyleBackColor = true;
		QGDPYHY31t.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		QGDPYHY31t.Location = new Point(249, 505);
		QGDPYHY31t.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		QGDPYHY31t.Size = new Size(50, 23);
		QGDPYHY31t.TabIndex = 10;
		QGDPYHY31t.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		QGDPYHY31t.UseVisualStyleBackColor = true;
		QGDPYHY31t.Click += KQXPg9UnXh;
		mS1P1qgtXS.AutoSize = true;
		mS1P1qgtXS.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		mS1P1qgtXS.Location = new Point(12, 4);
		mS1P1qgtXS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		mS1P1qgtXS.Size = new Size(64, 17);
		mS1P1qgtXS.TabIndex = 13;
		mS1P1qgtXS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34654);
		Cr2P3dWFXD.BorderStyle = BorderStyle.FixedSingle;
		Cr2P3dWFXD.Location = new Point(13, 24);
		Cr2P3dWFXD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34674);
		Cr2P3dWFXD.Size = new Size(345, 474);
		Cr2P3dWFXD.TabIndex = 12;
		base.AcceptButton = QGDPYHY31t;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = BBcPkCNGd5;
		base.ClientSize = new Size(371, 534);
		base.Controls.Add(mS1P1qgtXS);
		base.Controls.Add(Cr2P3dWFXD);
		base.Controls.Add(BBcPkCNGd5);
		base.Controls.Add(QGDPYHY31t);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34726);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34758);
		base.Load += xhqPLIsPm4;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
