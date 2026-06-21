using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class BlockAssign : Form
{
	private BlockChange VnmRBSPTxQ;

	private BlockReplaceType sSXRtySRRu;

	private IContainer mlIRa2wdCm;

	private Button wHyRXJYG30;

	private Button Di5Rx40Whj;

	private TextBox zd8ReUkmEu;

	private BlockReplace Ud0RMI92Wj;

	private BlockReplaceII WaPRUGD0Jr;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockAssign(BlockChange blockChange, BlockReplaceType blockReplaceType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		e7jR04kUor();
		sSXRtySRRu = blockReplaceType;
		VnmRBSPTxQ = blockChange;
		Ud0RMI92Wj.Visible = blockReplaceType != BlockReplaceType.ReplacePE;
		WaPRUGD0Jr.Visible = blockReplaceType == BlockReplaceType.ReplacePE;
		if (blockReplaceType == BlockReplaceType.ReplacePE)
		{
			WaPRUGD0Jr.SetBlocks(blockReplaceType);
			WaPRUGD0Jr.BlockChange = blockChange;
		}
		else
		{
			Ud0RMI92Wj.SetBlocks(blockReplaceType);
			Ud0RMI92Wj.BlockChange = blockChange;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dKcR2LPIbO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (sSXRtySRRu != BlockReplaceType.ReplacePE && Ud0RMI92Wj.IsValid())
		{
			VnmRBSPTxQ = Ud0RMI92Wj.BlockChange;
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else if (sSXRtySRRu == BlockReplaceType.ReplacePE && WaPRUGD0Jr.IsValid())
		{
			VnmRBSPTxQ = WaPRUGD0Jr.BlockChange;
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36606), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36676));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Vp3RyArSLr(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		_ = sSXRtySRRu;
		_ = 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && mlIRa2wdCm != null)
		{
			mlIRa2wdCm.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e7jR04kUor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wHyRXJYG30 = new Button();
		Di5Rx40Whj = new Button();
		zd8ReUkmEu = new TextBox();
		Ud0RMI92Wj = new BlockReplace();
		WaPRUGD0Jr = new BlockReplaceII();
		SuspendLayout();
		wHyRXJYG30.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		wHyRXJYG30.DialogResult = DialogResult.Cancel;
		wHyRXJYG30.Location = new Point(650, 119);
		wHyRXJYG30.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		wHyRXJYG30.Size = new Size(50, 23);
		wHyRXJYG30.TabIndex = 2;
		wHyRXJYG30.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		wHyRXJYG30.UseVisualStyleBackColor = true;
		Di5Rx40Whj.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Di5Rx40Whj.Location = new Point(591, 119);
		Di5Rx40Whj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		Di5Rx40Whj.Size = new Size(50, 23);
		Di5Rx40Whj.TabIndex = 1;
		Di5Rx40Whj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		Di5Rx40Whj.UseVisualStyleBackColor = true;
		Di5Rx40Whj.Click += dKcR2LPIbO;
		zd8ReUkmEu.Location = new Point(44, 77);
		zd8ReUkmEu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19976);
		zd8ReUkmEu.Size = new Size(188, 20);
		zd8ReUkmEu.TabIndex = 5;
		Ud0RMI92Wj.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Ud0RMI92Wj.Location = new Point(2, 11);
		Ud0RMI92Wj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36728);
		Ud0RMI92Wj.Size = new Size(649, 101);
		Ud0RMI92Wj.TabIndex = 0;
		WaPRUGD0Jr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		WaPRUGD0Jr.Location = new Point(2, 11);
		WaPRUGD0Jr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36758);
		WaPRUGD0Jr.Size = new Size(704, 101);
		WaPRUGD0Jr.TabIndex = 3;
		WaPRUGD0Jr.Visible = false;
		base.AcceptButton = Di5Rx40Whj;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = wHyRXJYG30;
		base.ClientSize = new Size(709, 150);
		base.Controls.Add(WaPRUGD0Jr);
		base.Controls.Add(Ud0RMI92Wj);
		base.Controls.Add(wHyRXJYG30);
		base.Controls.Add(Di5Rx40Whj);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36792);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36818);
		base.Load += Vp3RyArSLr;
		ResumeLayout(performLayout: false);
	}
}
