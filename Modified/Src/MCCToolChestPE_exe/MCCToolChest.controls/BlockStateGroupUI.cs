using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BlockStateGroupUI : UserControl
{
	private BlockStateDefinition pLMvgfKvqc;

	private BlockReplaceStateGroup tfEvPYGteb;

	private IContainer SyFvRQBY8K;

	private Label SpPvks9a67;

	private FlowLayoutPanel DngvY31boQ;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockStateGroupUI(BlockStateDefinition blockState, BlockStateReplaceUI.ToFromType toFromType, BlockReplaceStateGroup brsg)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		esbvLp8X3A();
		pLMvgfKvqc = blockState;
		tfEvPYGteb = brsg;
		SpPvks9a67.Text = blockState.name;
		int num = 0;
		if (toFromType == BlockStateReplaceUI.ToFromType.TO)
		{
			BlockStateValue blockStateValue = new BlockStateValue
			{
				bedrock = -1,
				bedrockPropertyValue = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11698),
				java = -1,
				javaPropertyValue = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11698)
			};
			l1NvUGskVS(blockStateValue, brsg == null || i8yvx82ATU(brsg, blockStateValue));
			num++;
		}
		BlockStateValue[] states = blockState.states;
		foreach (BlockStateValue blockStateValue2 in states)
		{
			if (toFromType == BlockStateReplaceUI.ToFromType.FROM)
			{
				bool flag = brsg == null || i8yvx82ATU(brsg, blockStateValue2);
				BTXvMvEla1(blockStateValue2, flag);
			}
			else
			{
				bool flag2 = brsg != null && i8yvx82ATU(brsg, blockStateValue2);
				l1NvUGskVS(blockStateValue2, flag2);
			}
			num++;
		}
		DngvY31boQ.Height = 18 * num + 10;
		base.Height = 18 * num + 26;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool i8yvx82ATU(BlockReplaceStateGroup P_0, BlockStateValue P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (BlockStateValue item in P_0.stateValue)
		{
			if (item.javaPropertyValue == P_1.javaPropertyValue && item.bedrockPropertyValue == P_1.bedrockPropertyValue)
			{
				return true;
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal BlockReplaceStateGroup vO5ve5TU6u()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockReplaceStateGroup blockReplaceStateGroup = new BlockReplaceStateGroup();
		blockReplaceStateGroup.groupName = pLMvgfKvqc.name;
		for (int i = 0; i < DngvY31boQ.Controls.Count; i++)
		{
			if ((DngvY31boQ.Controls[i] is RadioButton) ? ((RadioButton)DngvY31boQ.Controls[i]).Checked : ((CheckBox)DngvY31boQ.Controls[i]).Checked)
			{
				BlockStateValue item = DngvY31boQ.Controls[i].Tag as BlockStateValue;
				blockReplaceStateGroup.stateValue.Add(item);
			}
		}
		return blockReplaceStateGroup;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BTXvMvEla1(BlockStateValue P_0, bool P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CheckBox checkBox = new CheckBox();
		checkBox.Checked = P_1;
		checkBox.Text = P_0.javaPropertyValue;
		Padding margin = checkBox.Margin;
		margin.Top = 0;
		margin.Bottom = 0;
		margin.Left = 10;
		checkBox.Margin = margin;
		Padding padding = checkBox.Padding;
		padding.All = 0;
		checkBox.Padding = padding;
		checkBox.Height = 18;
		checkBox.Width = 180;
		checkBox.Tag = P_0;
		DngvY31boQ.Controls.Add(checkBox);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l1NvUGskVS(BlockStateValue P_0, bool P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RadioButton radioButton = new RadioButton();
		radioButton.Checked = P_1;
		radioButton.Text = P_0.javaPropertyValue;
		Padding margin = radioButton.Margin;
		margin.Top = 0;
		margin.Bottom = 0;
		margin.Left = 10;
		radioButton.Margin = margin;
		Padding padding = radioButton.Padding;
		padding.All = 0;
		radioButton.Padding = padding;
		radioButton.Height = 18;
		radioButton.Width = 180;
		radioButton.Tag = P_0;
		DngvY31boQ.Controls.Add(radioButton);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && SyFvRQBY8K != null)
		{
			SyFvRQBY8K.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void esbvLp8X3A()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SpPvks9a67 = new Label();
		DngvY31boQ = new FlowLayoutPanel();
		SuspendLayout();
		SpPvks9a67.AutoSize = true;
		SpPvks9a67.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
		SpPvks9a67.Location = new Point(2, 0);
		SpPvks9a67.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11742);
		SpPvks9a67.Size = new Size(46, 18);
		SpPvks9a67.TabIndex = 0;
		SpPvks9a67.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		DngvY31boQ.Location = new Point(0, 21);
		DngvY31boQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11770);
		DngvY31boQ.Size = new Size(230, 96);
		DngvY31boQ.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(DngvY31boQ);
		base.Controls.Add(SpPvks9a67);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11792);
		base.Size = new Size(230, 118);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
