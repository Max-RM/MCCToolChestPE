using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class LayersUI : UserControl
{
	private LayerUI n7qhgKoC1b;

	private IContainer GNyhPSLeVp;

	private FlowLayoutPanel dOKhRLv6JK;

	private Button fqJhkDpd6H;

	private Button dyyhYWOCdh;

	private Button E0dh3f2vkT;

	private Button pHeh1xwCar;

	public FlatWorldBlockLayer[] Layers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			FlatWorldBlockLayer[] array = new FlatWorldBlockLayer[dOKhRLv6JK.Controls.Count];
			for (int i = 0; i < dOKhRLv6JK.Controls.Count; i++)
			{
				LayerUI layerUI = dOKhRLv6JK.Controls[i] as LayerUI;
				array[i] = layerUI.FlatWorldLayer;
			}
			return array;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LayersUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		kX0hL73BVg();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uWjh0qyINb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wg1hBiT3gA();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wg1hBiT3gA()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BuildLayersDisplay(FlatWorldBlockLayer[] layers)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dOKhRLv6JK.Controls.Clear();
		foreach (FlatWorldBlockLayer flatWorldBlockLayer in layers)
		{
			dEthaWo1aY(flatWorldBlockLayer);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KRJht4vHse(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dEthaWo1aY(new FlatWorldBlockLayer());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dEthaWo1aY(FlatWorldBlockLayer P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LayerUI layerUI = new LayerUI(P_0, gSvhUMWEGF, GgthMCndPN);
		dOKhRLv6JK.Controls.Add(layerUI);
		GgthMCndPN(layerUI);
		gSvhUMWEGF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AYZhXHWwRG(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (n7qhgKoC1b != null)
		{
			dOKhRLv6JK.Controls.Remove(n7qhgKoC1b);
			n7qhgKoC1b = null;
			if (dOKhRLv6JK.Controls.Count > 0)
			{
				GgthMCndPN((LayerUI)dOKhRLv6JK.Controls[dOKhRLv6JK.Controls.Count - 1]);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KpmhxjUAto(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (n7qhgKoC1b != null)
		{
			int num = dOKhRLv6JK.Controls.IndexOf(n7qhgKoC1b);
			if (num > 0)
			{
				dOKhRLv6JK.Controls.SetChildIndex(n7qhgKoC1b, num - 1);
				gSvhUMWEGF();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void H3KheMOllR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (n7qhgKoC1b != null)
		{
			int num = dOKhRLv6JK.Controls.IndexOf(n7qhgKoC1b);
			if (num < dOKhRLv6JK.Controls.Count - 1)
			{
				dOKhRLv6JK.Controls.SetChildIndex(n7qhgKoC1b, num + 1);
				gSvhUMWEGF();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GgthMCndPN(LayerUI P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		n7qhgKoC1b = P_0;
		foreach (Control control in dOKhRLv6JK.Controls)
		{
			LayerUI layerUI = control as LayerUI;
			layerUI.SetActiveState(layerUI == P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gSvhUMWEGF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && GNyhPSLeVp != null)
		{
			GNyhPSLeVp.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kX0hL73BVg()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dOKhRLv6JK = new FlowLayoutPanel();
		fqJhkDpd6H = new Button();
		dyyhYWOCdh = new Button();
		E0dh3f2vkT = new Button();
		pHeh1xwCar = new Button();
		SuspendLayout();
		dOKhRLv6JK.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dOKhRLv6JK.AutoScroll = true;
		dOKhRLv6JK.BorderStyle = BorderStyle.FixedSingle;
		dOKhRLv6JK.Location = new Point(3, 0);
		dOKhRLv6JK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14394);
		dOKhRLv6JK.Padding = new Padding(0, 6, 0, 0);
		dOKhRLv6JK.Size = new Size(327, 470);
		dOKhRLv6JK.TabIndex = 3;
		fqJhkDpd6H.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		fqJhkDpd6H.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		fqJhkDpd6H.Image = Resources.GSfSEcQrVsG();
		fqJhkDpd6H.Location = new Point(332, 25);
		fqJhkDpd6H.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14426);
		fqJhkDpd6H.Size = new Size(24, 22);
		fqJhkDpd6H.TabIndex = 6;
		fqJhkDpd6H.UseVisualStyleBackColor = true;
		fqJhkDpd6H.Click += AYZhXHWwRG;
		dyyhYWOCdh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		dyyhYWOCdh.Image = Resources.C61S3HP5IFi();
		dyyhYWOCdh.Location = new Point(332, 0);
		dyyhYWOCdh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14448);
		dyyhYWOCdh.Size = new Size(24, 22);
		dyyhYWOCdh.TabIndex = 5;
		dyyhYWOCdh.UseVisualStyleBackColor = true;
		dyyhYWOCdh.Click += KRJht4vHse;
		E0dh3f2vkT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		E0dh3f2vkT.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		E0dh3f2vkT.Image = Resources.VIUS1sBuy0A();
		E0dh3f2vkT.Location = new Point(332, 83);
		E0dh3f2vkT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14464);
		E0dh3f2vkT.Size = new Size(24, 22);
		E0dh3f2vkT.TabIndex = 9;
		E0dh3f2vkT.UseVisualStyleBackColor = true;
		E0dh3f2vkT.Click += H3KheMOllR;
		pHeh1xwCar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pHeh1xwCar.Image = Resources.h9TS1mr6yVy();
		pHeh1xwCar.Location = new Point(332, 58);
		pHeh1xwCar.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14482);
		pHeh1xwCar.Size = new Size(24, 22);
		pHeh1xwCar.TabIndex = 8;
		pHeh1xwCar.UseVisualStyleBackColor = true;
		pHeh1xwCar.Click += KpmhxjUAto;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(E0dh3f2vkT);
		base.Controls.Add(pHeh1xwCar);
		base.Controls.Add(fqJhkDpd6H);
		base.Controls.Add(dyyhYWOCdh);
		base.Controls.Add(dOKhRLv6JK);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20080);
		base.Size = new Size(355, 474);
		ResumeLayout(performLayout: false);
	}
}
