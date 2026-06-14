using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using HaI2p2xMqxTADue2UA;
using MCCToolChest.forms;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BlockStateReplaceUI : UserControl
{
	public enum ToFromType
	{
		TO,
		FROM
	}

	private MasterBlock dlnv9Q5Ajw;

	private BlockStateReplace GQ5vIe2uPF;

	public ToFromType toFromType;

	private IContainer kP1vzsi2JN;

	private PictureBoxWithInterpolationMode XN4wTVOmKl;

	private Label kgRwSEtFcf;

	private Label D1VwGcioR4;

	private Label aiewbe9kMv;

	private FlowLayoutPanel wpewv2wFT5;

	private Label d1CwwsSZGA;

	private Label NRdw4AyZAO;

	private Label FHjwVHtcrc;

	private Label RoTwWvg1wM;

	private Label RI4wpNo89V;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockStateReplaceUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		toFromType = ToFromType.FROM;
		FnJv8VWnNX();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GM5v7ai2xi(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Button == MouseButtons.Right)
		{
			base.Parent.PointToScreen(Cursor.Position);
			BlockPickerUI blockPickerUI = new BlockPickerUI(N2dvds8Fuy);
			blockPickerUI.Left = Cursor.Position.X;
			blockPickerUI.Top = Cursor.Position.Y;
			blockPickerUI.Show();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void et5vA1WmlR(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Parent.PointToScreen(Cursor.Position);
		BlockPickerUI blockPickerUI = new BlockPickerUI(N2dvds8Fuy);
		blockPickerUI.Left = Cursor.Position.X;
		blockPickerUI.Top = Cursor.Position.Y;
		blockPickerUI.Show();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void N2dvds8Fuy(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int hashCode = P_0.GetHashCode();
		if (BlockMaster.MasterBlocksByHash != null && BlockMaster.MasterBlocksByHash.ContainsKey(hashCode))
		{
			dlnv9Q5Ajw = BlockMaster.MasterBlocksByHash[hashCode];
			NRdw4AyZAO.Text = dlnv9Q5Ajw.Label;
			kgRwSEtFcf.Text = dlnv9Q5Ajw.java.name;
			D1VwGcioR4.Text = dlnv9Q5Ajw.java.nameOld;
			RI4wpNo89V.Text = dlnv9Q5Ajw.java.id + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + dlnv9Q5Ajw.java.data;
			aiewbe9kMv.Text = dlnv9Q5Ajw.bedrock.name;
			List<MasterBlockItemProperty> properties = dlnv9Q5Ajw.bedrock.properties;
			FHjwVHtcrc.Text = rZYvFuAN1e(properties);
			RoTwWvg1wM.Text = dlnv9Q5Ajw.bedrock.id + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + dlnv9Q5Ajw.bedrock.data;
			XN4wTVOmKl.Image = Jlxk34F1xl7DbN5CrR.B95SqDoBaf()[P_0].zpZdYKFdC();
			dRIvHQvXxu(dlnv9Q5Ajw);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dRIvHQvXxu(MasterBlock P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wpewv2wFT5.Controls.Clear();
		if (string.IsNullOrWhiteSpace(P_0.blockStates) || !BlockMaster.DataStates.ContainsKey(P_0.blockStates))
		{
			return;
		}
		BlockStateGroup blockStateGroup = BlockMaster.DataStates[P_0.blockStates];
		foreach (BlockStateDefinition blockState in blockStateGroup.blockStates)
		{
			BlockReplaceStateGroup brsg = null;
			if (GQ5vIe2uPF != null && GQ5vIe2uPF.blockStateGroups.ContainsKey(blockState.name))
			{
				brsg = GQ5vIe2uPF.blockStateGroups[blockState.name];
			}
			BlockStateGroupUI value = new BlockStateGroupUI(blockState, toFromType, brsg);
			wpewv2wFT5.Controls.Add(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string rZYvFuAN1e(List<MasterBlockItemProperty> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (P_0 != null)
		{
			foreach (MasterBlockItemProperty item in P_0)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952));
				}
				stringBuilder.Append(item.name + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11960) + item.value);
			}
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YyfvjqFMTa(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BuildBlockStateReplace(BlockStateReplace bsr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		GQ5vIe2uPF = bsr;
		N2dvds8Fuy(bsr.blockName);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockStateReplace BuildBlockStateReplace()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockStateReplace blockStateReplace = new BlockStateReplace();
		if (dlnv9Q5Ajw != null)
		{
			blockStateReplace.blockName = dlnv9Q5Ajw.Name;
			for (int i = 0; i < wpewv2wFT5.Controls.Count; i++)
			{
				BlockStateGroupUI blockStateGroupUI = wpewv2wFT5.Controls[i] as BlockStateGroupUI;
				BlockReplaceStateGroup blockReplaceStateGroup = blockStateGroupUI.vO5ve5TU6u();
				blockStateReplace.blockStateGroups.Add(blockReplaceStateGroup.groupName, blockReplaceStateGroup);
			}
		}
		return blockStateReplace;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && kP1vzsi2JN != null)
		{
			kP1vzsi2JN.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FnJv8VWnNX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kgRwSEtFcf = new Label();
		D1VwGcioR4 = new Label();
		aiewbe9kMv = new Label();
		wpewv2wFT5 = new FlowLayoutPanel();
		d1CwwsSZGA = new Label();
		NRdw4AyZAO = new Label();
		FHjwVHtcrc = new Label();
		RoTwWvg1wM = new Label();
		RI4wpNo89V = new Label();
		XN4wTVOmKl = new PictureBoxWithInterpolationMode();
		((ISupportInitialize)XN4wTVOmKl).BeginInit();
		SuspendLayout();
		kgRwSEtFcf.AutoSize = true;
		kgRwSEtFcf.Location = new Point(73, 29);
		kgRwSEtFcf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11968);
		kgRwSEtFcf.Size = new Size(35, 13);
		kgRwSEtFcf.TabIndex = 3;
		kgRwSEtFcf.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		kgRwSEtFcf.MouseUp += GM5v7ai2xi;
		D1VwGcioR4.AutoSize = true;
		D1VwGcioR4.Location = new Point(73, 43);
		D1VwGcioR4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11994);
		D1VwGcioR4.Size = new Size(35, 13);
		D1VwGcioR4.TabIndex = 4;
		D1VwGcioR4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		D1VwGcioR4.MouseUp += GM5v7ai2xi;
		aiewbe9kMv.AutoSize = true;
		aiewbe9kMv.Location = new Point(73, 65);
		aiewbe9kMv.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12026);
		aiewbe9kMv.Size = new Size(35, 13);
		aiewbe9kMv.TabIndex = 5;
		aiewbe9kMv.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		aiewbe9kMv.MouseUp += GM5v7ai2xi;
		wpewv2wFT5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		wpewv2wFT5.AutoScroll = true;
		wpewv2wFT5.BorderStyle = BorderStyle.FixedSingle;
		wpewv2wFT5.Location = new Point(6, 114);
		wpewv2wFT5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12058);
		wpewv2wFT5.Size = new Size(244, 124);
		wpewv2wFT5.TabIndex = 6;
		wpewv2wFT5.MouseUp += GM5v7ai2xi;
		d1CwwsSZGA.AutoSize = true;
		d1CwwsSZGA.Location = new Point(5, 101);
		d1CwwsSZGA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		d1CwwsSZGA.Size = new Size(67, 13);
		d1CwwsSZGA.TabIndex = 7;
		d1CwwsSZGA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12090);
		d1CwwsSZGA.MouseUp += GM5v7ai2xi;
		NRdw4AyZAO.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		NRdw4AyZAO.BackColor = Color.Gainsboro;
		NRdw4AyZAO.BorderStyle = BorderStyle.FixedSingle;
		NRdw4AyZAO.Location = new Point(-2, -1);
		NRdw4AyZAO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12118);
		NRdw4AyZAO.Padding = new Padding(4, 3, 0, 0);
		NRdw4AyZAO.Size = new Size(260, 23);
		NRdw4AyZAO.TabIndex = 8;
		NRdw4AyZAO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11214);
		NRdw4AyZAO.MouseUp += GM5v7ai2xi;
		FHjwVHtcrc.AutoSize = true;
		FHjwVHtcrc.Location = new Point(73, 78);
		FHjwVHtcrc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12140);
		FHjwVHtcrc.Size = new Size(35, 13);
		FHjwVHtcrc.TabIndex = 9;
		FHjwVHtcrc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		FHjwVHtcrc.MouseUp += GM5v7ai2xi;
		RoTwWvg1wM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		RoTwWvg1wM.Location = new Point(201, 65);
		RoTwWvg1wM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12176);
		RoTwWvg1wM.Size = new Size(50, 13);
		RoTwWvg1wM.TabIndex = 10;
		RoTwWvg1wM.TextAlign = ContentAlignment.MiddleRight;
		RI4wpNo89V.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		RI4wpNo89V.Location = new Point(201, 29);
		RI4wpNo89V.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12204);
		RI4wpNo89V.Size = new Size(50, 13);
		RI4wpNo89V.TabIndex = 11;
		RI4wpNo89V.TextAlign = ContentAlignment.MiddleRight;
		XN4wTVOmKl.BackgroundImageLayout = ImageLayout.None;
		XN4wTVOmKl.BorderStyle = BorderStyle.FixedSingle;
		XN4wTVOmKl.InterpolationMode = InterpolationMode.Bicubic;
		XN4wTVOmKl.Location = new Point(6, 29);
		XN4wTVOmKl.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11872);
		XN4wTVOmKl.Size = new Size(64, 64);
		XN4wTVOmKl.SizeMode = PictureBoxSizeMode.CenterImage;
		XN4wTVOmKl.TabIndex = 2;
		XN4wTVOmKl.TabStop = false;
		XN4wTVOmKl.MouseUp += et5vA1WmlR;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(FHjwVHtcrc);
		base.Controls.Add(NRdw4AyZAO);
		base.Controls.Add(d1CwwsSZGA);
		base.Controls.Add(wpewv2wFT5);
		base.Controls.Add(aiewbe9kMv);
		base.Controls.Add(D1VwGcioR4);
		base.Controls.Add(kgRwSEtFcf);
		base.Controls.Add(XN4wTVOmKl);
		base.Controls.Add(RI4wpNo89V);
		base.Controls.Add(RoTwWvg1wM);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12226);
		base.Size = new Size(257, 244);
		base.Load += YyfvjqFMTa;
		base.MouseUp += GM5v7ai2xi;
		((ISupportInitialize)XN4wTVOmKl).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
