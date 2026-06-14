using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BlockReplaceUI : UserControl
{
	private BlockTranslateDefinition PVuvnwdn1Z;

	private IContainer Kwhvl0ylMd;

	private BlockStateReplaceUI bBTv2V1Bak;

	private BlockStateReplaceUI Yv6vyGQate;

	private CheckBox x3Dv0aTENN;

	private Label tILvBpS1Mq;

	private ComboBox hHuvtA12rA;

	private Label HIhvaUhKM0;

	private TextBox p4cvXUli9E;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockReplaceUI(BlockTranslateDefinition btd)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		JuZvmLnrx9();
		bBTv2V1Bak.toFromType = BlockStateReplaceUI.ToFromType.FROM;
		Yv6vyGQate.toFromType = BlockStateReplaceUI.ToFromType.TO;
		PVuvnwdn1Z = btd;
		bBTv2V1Bak.BuildBlockStateReplace(btd.fromBlock);
		Yv6vyGQate.BuildBlockStateReplace(btd.toBlock);
		x3Dv0aTENN.Checked = btd.translationActive;
		hHuvtA12rA.Text = btd.blockTranslationFunction;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockTranslateDefinition BuildBlockTranslateDefinition()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockTranslateDefinition blockTranslateDefinition = new BlockTranslateDefinition();
		blockTranslateDefinition.fromBlock = bBTv2V1Bak.BuildBlockStateReplace();
		blockTranslateDefinition.toBlock = Yv6vyGQate.BuildBlockStateReplace();
		blockTranslateDefinition.translationActive = x3Dv0aTENN.Checked;
		blockTranslateDefinition.blockTranslationFunction = hHuvtA12rA.Text;
		return blockTranslateDefinition;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && Kwhvl0ylMd != null)
		{
			Kwhvl0ylMd.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JuZvmLnrx9()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		x3Dv0aTENN = new CheckBox();
		tILvBpS1Mq = new Label();
		hHuvtA12rA = new ComboBox();
		Yv6vyGQate = new BlockStateReplaceUI();
		bBTv2V1Bak = new BlockStateReplaceUI();
		HIhvaUhKM0 = new Label();
		p4cvXUli9E = new TextBox();
		SuspendLayout();
		x3Dv0aTENN.AutoSize = true;
		x3Dv0aTENN.Location = new Point(6, 274);
		x3Dv0aTENN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11488);
		x3Dv0aTENN.Size = new Size(56, 17);
		x3Dv0aTENN.TabIndex = 2;
		x3Dv0aTENN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11530);
		x3Dv0aTENN.UseVisualStyleBackColor = true;
		tILvBpS1Mq.AutoSize = true;
		tILvBpS1Mq.Location = new Point(248, 275);
		tILvBpS1Mq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		tILvBpS1Mq.Size = new Size(34, 13);
		tILvBpS1Mq.TabIndex = 3;
		tILvBpS1Mq.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11546);
		hHuvtA12rA.FormattingEnabled = true;
		hHuvtA12rA.Location = new Point(287, 271);
		hHuvtA12rA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11562);
		hHuvtA12rA.Size = new Size(260, 21);
		hHuvtA12rA.TabIndex = 4;
		Yv6vyGQate.BorderStyle = BorderStyle.FixedSingle;
		Yv6vyGQate.Location = new Point(287, 8);
		Yv6vyGQate.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11618);
		Yv6vyGQate.Size = new Size(260, 259);
		Yv6vyGQate.TabIndex = 1;
		bBTv2V1Bak.BorderStyle = BorderStyle.FixedSingle;
		bBTv2V1Bak.Location = new Point(6, 8);
		bBTv2V1Bak.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11632);
		bBTv2V1Bak.Size = new Size(260, 259);
		bBTv2V1Bak.TabIndex = 0;
		HIhvaUhKM0.AutoSize = true;
		HIhvaUhKM0.Location = new Point(64, 275);
		HIhvaUhKM0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		HIhvaUhKM0.Size = new Size(38, 13);
		HIhvaUhKM0.TabIndex = 5;
		HIhvaUhKM0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11650);
		p4cvXUli9E.Location = new Point(106, 272);
		p4cvXUli9E.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11278);
		p4cvXUli9E.Size = new Size(122, 20);
		p4cvXUli9E.TabIndex = 14;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(p4cvXUli9E);
		base.Controls.Add(HIhvaUhKM0);
		base.Controls.Add(hHuvtA12rA);
		base.Controls.Add(tILvBpS1Mq);
		base.Controls.Add(x3Dv0aTENN);
		base.Controls.Add(Yv6vyGQate);
		base.Controls.Add(bBTv2V1Bak);
		base.Margin = new Padding(6, 3, 3, 3);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11666);
		base.Size = new Size(554, 298);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
