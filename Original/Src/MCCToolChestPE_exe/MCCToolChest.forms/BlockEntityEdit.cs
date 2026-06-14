using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls.EntityHelpers;
using MCCToolChest.model;
using MCCToolChest.Properties;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class BlockEntityEdit : Form
{
	private IContainer K0rRYa0w7Z;

	private Button gWeR3uCBeZ;

	private Button cxuR1BpkBR;

	private EntityHelperContainer djkREOKjpN;

	public TagNodeCompound Entity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return djkREOKjpN.ActiveEntity;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			djkREOKjpN.ActiveEntity = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockEntityEdit(Block block, TagNodeCompound node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		jCNRkM4YjO();
		Entity = node;
		sLGRLvJRoV(node);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sLGRLvJRoV(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null && P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
		{
			Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36862) + P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Y0oRgZSGew(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void seeRPHWLdP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VtnRRv2H5P(object P_0, EventArgs P_1)
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
		if (disposing && K0rRYa0w7Z != null)
		{
			K0rRYa0w7Z.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jCNRkM4YjO()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		gWeR3uCBeZ = new Button();
		cxuR1BpkBR = new Button();
		djkREOKjpN = new EntityHelperContainer();
		SuspendLayout();
		gWeR3uCBeZ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		gWeR3uCBeZ.DialogResult = DialogResult.Cancel;
		gWeR3uCBeZ.Location = new Point(797, 504);
		gWeR3uCBeZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		gWeR3uCBeZ.Size = new Size(50, 23);
		gWeR3uCBeZ.TabIndex = 5;
		gWeR3uCBeZ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		gWeR3uCBeZ.UseVisualStyleBackColor = true;
		gWeR3uCBeZ.Click += seeRPHWLdP;
		cxuR1BpkBR.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		cxuR1BpkBR.Location = new Point(738, 504);
		cxuR1BpkBR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		cxuR1BpkBR.Size = new Size(50, 23);
		cxuR1BpkBR.TabIndex = 4;
		cxuR1BpkBR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		cxuR1BpkBR.UseVisualStyleBackColor = true;
		cxuR1BpkBR.Click += Y0oRgZSGew;
		djkREOKjpN.ActiveEntity = null;
		djkREOKjpN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		djkREOKjpN.ChunkX = 0;
		djkREOKjpN.ChunkZ = 0;
		djkREOKjpN.Layers = null;
		djkREOKjpN.Location = new Point(12, 10);
		djkREOKjpN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13874);
		djkREOKjpN.Size = new Size(835, 486);
		djkREOKjpN.TabIndex = 6;
		base.AcceptButton = cxuR1BpkBR;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = gWeR3uCBeZ;
		base.ClientSize = new Size(857, 532);
		base.Controls.Add(djkREOKjpN);
		base.Controls.Add(gWeR3uCBeZ);
		base.Controls.Add(cxuR1BpkBR);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36892);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36926);
		base.Load += VtnRRv2H5P;
		ResumeLayout(performLayout: false);
	}
}
