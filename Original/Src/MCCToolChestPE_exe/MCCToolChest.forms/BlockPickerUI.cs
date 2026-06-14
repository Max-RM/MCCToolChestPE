using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.events;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class BlockPickerUI : Form
{
	public string blockName;

	private BlockSelected anhRNl8Kk7;

	private IContainer X6yRDrV3cx;

	private BlockPicker EKRRcaGBZs;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockPickerUI(BlockSelected blockSelected)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		EYER6u7ZmI();
		anhRNl8Kk7 = blockSelected;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yRvRrU8dh4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void A1cR5CXMH7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockSelectedEventArgs e = P_1 as BlockSelectedEventArgs;
		blockName = e.BlockName;
		base.DialogResult = DialogResult.OK;
		anhRNl8Kk7(blockName);
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && X6yRDrV3cx != null)
		{
			X6yRDrV3cx.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EYER6u7ZmI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EKRRcaGBZs = new BlockPicker();
		SuspendLayout();
		EKRRcaGBZs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		EKRRcaGBZs.Location = new Point(0, 0);
		EKRRcaGBZs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36952);
		EKRRcaGBZs.Size = new Size(367, 335);
		EKRRcaGBZs.TabIndex = 0;
		EKRRcaGBZs.BlockSelected += A1cR5CXMH7;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(367, 335);
		base.Controls.Add(EKRRcaGBZs);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36980);
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.Manual;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36980);
		base.Deactivate += yRvRrU8dh4;
		ResumeLayout(performLayout: false);
	}
}
