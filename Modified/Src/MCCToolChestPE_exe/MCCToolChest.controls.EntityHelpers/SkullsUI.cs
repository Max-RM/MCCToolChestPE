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

public class SkullsUI : UserControl
{
	private int hANftr00u9;

	private TagNodeCompound unufaijHvG;

	private EntityHelperChanged L2WfXn3e6f;

	private IContainer UhWfxpw88F;

	private EntityHelperHeader iktfeQ1sTb;

	private Panel DaOfMxJ6aU;

	public byte SkullType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return unufaijHvG[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17354)] as TagNodeByte;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			unufaijHvG[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17354)] = new TagNodeByte(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SkullsUI(TagNodeCompound entity, EntityHelperChanged onChange)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		UGcfBFMZ8F();
		unufaijHvG = entity;
		L2WfXn3e6f = onChange;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TFVflVOfh0(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ushf2nSC15();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ushf2nSC15()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int left = 10;
		int num = 0;
		foreach (MobImageData skullImage in SkullImagesDefinition.skullImages)
		{
			SkullUI skullUI = new SkullUI(skullImage.ImageId, Htrf06Ea9H);
			skullUI.Top = num * 75;
			skullUI.Left = left;
			skullUI.Height = 70;
			skullUI.Width = 260;
			DaOfMxJ6aU.Controls.Add(skullUI);
			num++;
			if (num == 3)
			{
				num = 0;
				left = 300;
			}
		}
		((SkullUI)DaOfMxJ6aU.Controls[SkullType]).SetState(active: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iFXfyvEXBL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (iktfeQ1sTb.ViewState == EntityHelperViewState.Contracted)
		{
			hANftr00u9 = base.Height;
			base.Height = iktfeQ1sTb.Top + iktfeQ1sTb.Height;
		}
		else
		{
			base.Height = hANftr00u9;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Htrf06Ea9H(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < DaOfMxJ6aU.Controls.Count; i++)
		{
			((SkullUI)DaOfMxJ6aU.Controls[i]).SetState(P_0 == i);
		}
		SkullType = (byte)P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && UhWfxpw88F != null)
		{
			UhWfxpw88F.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UGcfBFMZ8F()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		iktfeQ1sTb = new EntityHelperHeader();
		DaOfMxJ6aU = new Panel();
		SuspendLayout();
		iktfeQ1sTb.BackColor = Color.Silver;
		iktfeQ1sTb.Dock = DockStyle.Top;
		iktfeQ1sTb.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		iktfeQ1sTb.ForeColor = Color.Black;
		iktfeQ1sTb.Location = new Point(0, 0);
		iktfeQ1sTb.Margin = new Padding(4);
		iktfeQ1sTb.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		iktfeQ1sTb.Size = new Size(578, 35);
		iktfeQ1sTb.TabIndex = 0;
		iktfeQ1sTb.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(2564);
		iktfeQ1sTb.ViewState = EntityHelperViewState.Expanded;
		iktfeQ1sTb.ChangeViewState += iFXfyvEXBL;
		DaOfMxJ6aU.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DaOfMxJ6aU.Location = new Point(3, 42);
		DaOfMxJ6aU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17376);
		DaOfMxJ6aU.Size = new Size(572, 494);
		DaOfMxJ6aU.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(DaOfMxJ6aU);
		base.Controls.Add(iktfeQ1sTb);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17398);
		base.Size = new Size(578, 539);
		base.Load += TFVflVOfh0;
		ResumeLayout(performLayout: false);
	}
}
