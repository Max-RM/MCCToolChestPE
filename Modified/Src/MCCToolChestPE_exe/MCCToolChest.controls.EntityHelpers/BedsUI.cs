using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.ConfigData;
using MCCToolChest.events;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class BedsUI : UserControl
{
	private int WdPpgUc5uR;

	private TagNodeCompound nbjpP8ADNo;

	private EntityHelperChanged b7HpRHW7rR;

	private IContainer XoApkmH5L7;

	private EntityHelperHeader E9ApYLnifb;

	private Panel Keop3G3dqD;

	public byte Color
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return nbjpP8ADNo[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14532)] as TagNodeByte;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			nbjpP8ADNo[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14532)] = new TagNodeByte(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BedsUI(TagNodeCompound entity, EntityHelperChanged onChange)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		eHcpLyIVFt();
		nbjpP8ADNo = entity;
		b7HpRHW7rR = onChange;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FEgpxmqm12(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RlapeXF3xp();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RlapeXF3xp()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int left = 10;
		int num = 0;
		foreach (MobImageData bedImage in BedImagesDefinition.bedImages)
		{
			BedUI bedUI = new BedUI(bedImage.ImageId, Rx8pUvlpP5);
			bedUI.Top = num * 45;
			bedUI.Left = left;
			bedUI.Height = 40;
			bedUI.Width = 200;
			Keop3G3dqD.Controls.Add(bedUI);
			num++;
			if (num == 8)
			{
				num = 0;
				left = 240;
			}
		}
		((BedUI)Keop3G3dqD.Controls[Color]).SetState(active: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void poYpMLYLBr(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (E9ApYLnifb.ViewState == EntityHelperViewState.Contracted)
		{
			WdPpgUc5uR = base.Height;
			base.Height = E9ApYLnifb.Top + E9ApYLnifb.Height;
		}
		else
		{
			base.Height = WdPpgUc5uR;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Rx8pUvlpP5(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < Keop3G3dqD.Controls.Count; i++)
		{
			((BedUI)Keop3G3dqD.Controls[i]).SetState(P_0 == i);
		}
		Color = (byte)P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && XoApkmH5L7 != null)
		{
			XoApkmH5L7.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eHcpLyIVFt()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		E9ApYLnifb = new EntityHelperHeader();
		Keop3G3dqD = new Panel();
		SuspendLayout();
		E9ApYLnifb.BackColor = System.Drawing.Color.Silver;
		E9ApYLnifb.Dock = DockStyle.Top;
		E9ApYLnifb.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		E9ApYLnifb.ForeColor = System.Drawing.Color.Black;
		E9ApYLnifb.Location = new Point(0, 0);
		E9ApYLnifb.Margin = new Padding(4);
		E9ApYLnifb.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		E9ApYLnifb.Size = new Size(578, 35);
		E9ApYLnifb.TabIndex = 0;
		E9ApYLnifb.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14546);
		E9ApYLnifb.ViewState = EntityHelperViewState.Expanded;
		E9ApYLnifb.ChangeViewState += poYpMLYLBr;
		Keop3G3dqD.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Keop3G3dqD.Location = new Point(3, 42);
		Keop3G3dqD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14556);
		Keop3G3dqD.Size = new Size(572, 494);
		Keop3G3dqD.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(Keop3G3dqD);
		base.Controls.Add(E9ApYLnifb);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14574);
		base.Size = new Size(578, 539);
		base.Load += FEgpxmqm12;
		ResumeLayout(performLayout: false);
	}
}
