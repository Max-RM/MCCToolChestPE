using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class CustomName : UserControl
{
	private int hFkigqaZiF;

	private TagNodeCompound dOfiPaMYEX;

	private EntityHelperChanged PvKiRWQE6G;

	private IContainer hkCiksJIoq;

	private EntityHelperHeader i4fiY4bj4u;

	private Label n9Si3I2DGu;

	private TextBox sERi1OrfCp;

	private CheckBox AEEiEVnqMc;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomName(TagNodeCompound entity, EntityHelperChanged onChange)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		byFiLHxMXY();
		dOfiPaMYEX = entity;
		PvKiRWQE6G = onChange;
		JR3ix3jGIO();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JR3ix3jGIO()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = string.Empty;
		if (dOfiPaMYEX.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716)))
		{
			text = dOfiPaMYEX[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716)] as TagNodeString;
		}
		sERi1OrfCp.Text = text;
		byte b = 0;
		if (dOfiPaMYEX.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17718)))
		{
			b = dOfiPaMYEX[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17718)] as TagNodeByte;
		}
		AEEiEVnqMc.Checked = b > 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NpvieoUKjA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i4fiY4bj4u.ViewState == EntityHelperViewState.Contracted)
		{
			hFkigqaZiF = base.Height;
			base.Height = i4fiY4bj4u.Top + i4fiY4bj4u.Height;
		}
		else
		{
			base.Height = hFkigqaZiF;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GkkiMkI9Fi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (dOfiPaMYEX.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716)))
		{
			dOfiPaMYEX[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17718)] = new TagNodeByte((byte)(AEEiEVnqMc.Checked ? 1u : 0u));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zcwiUx77eJ(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dOfiPaMYEX[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716)] = new TagNodeString(sERi1OrfCp.Text);
		PvKiRWQE6G();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && hkCiksJIoq != null)
		{
			hkCiksJIoq.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void byFiLHxMXY()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		n9Si3I2DGu = new Label();
		sERi1OrfCp = new TextBox();
		AEEiEVnqMc = new CheckBox();
		i4fiY4bj4u = new EntityHelperHeader();
		SuspendLayout();
		n9Si3I2DGu.AutoSize = true;
		n9Si3I2DGu.Location = new Point(19, 55);
		n9Si3I2DGu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		n9Si3I2DGu.Size = new Size(73, 13);
		n9Si3I2DGu.TabIndex = 1;
		n9Si3I2DGu.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17756);
		sERi1OrfCp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		sERi1OrfCp.Location = new Point(98, 52);
		sERi1OrfCp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17782);
		sERi1OrfCp.Size = new Size(466, 20);
		sERi1OrfCp.TabIndex = 2;
		sERi1OrfCp.KeyUp += zcwiUx77eJ;
		AEEiEVnqMc.AutoSize = true;
		AEEiEVnqMc.CheckAlign = ContentAlignment.MiddleRight;
		AEEiEVnqMc.Location = new Point(16, 82);
		AEEiEVnqMc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17810);
		AEEiEVnqMc.Size = new Size(125, 17);
		AEEiEVnqMc.TabIndex = 3;
		AEEiEVnqMc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17844);
		AEEiEVnqMc.UseVisualStyleBackColor = true;
		AEEiEVnqMc.CheckedChanged += GkkiMkI9Fi;
		i4fiY4bj4u.BackColor = Color.Silver;
		i4fiY4bj4u.Dock = DockStyle.Top;
		i4fiY4bj4u.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		i4fiY4bj4u.ForeColor = Color.Black;
		i4fiY4bj4u.Location = new Point(0, 0);
		i4fiY4bj4u.Margin = new Padding(4);
		i4fiY4bj4u.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		i4fiY4bj4u.Size = new Size(581, 35);
		i4fiY4bj4u.TabIndex = 0;
		i4fiY4bj4u.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17756);
		i4fiY4bj4u.ViewState = EntityHelperViewState.Expanded;
		i4fiY4bj4u.ChangeViewState += NpvieoUKjA;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(AEEiEVnqMc);
		base.Controls.Add(sERi1OrfCp);
		base.Controls.Add(n9Si3I2DGu);
		base.Controls.Add(i4fiY4bj4u);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13716);
		base.Size = new Size(581, 118);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
