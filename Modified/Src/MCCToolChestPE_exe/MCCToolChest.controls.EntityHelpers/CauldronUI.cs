using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class CauldronUI : UserControl
{
	private int saQpHyVq0K;

	private TagNodeCompound XvMpFe1TJp;

	private bool zlApjjJ5oc;

	private IContainer xDnp8EGGD6;

	private EntityHelperHeader zTip9CVnDG;

	private ComboBox eQXpICpNvl;

	private Label fd1pzbWXbO;

	private Label vPmZTWOM21;

	private TextBox UHfZShMYl0;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CauldronUI(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		yMepdY5KRj();
		XvMpFe1TJp = entity;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tJspOEWNiZ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		htnpCmYqeB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void htnpCmYqeB()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zlApjjJ5oc = true;
		eQXpICpNvl.DataSource = new BindingSource(Constants.xpSS0dKndLy, null);
		eQXpICpNvl.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		eQXpICpNvl.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		UHfZShMYl0.Text = TagNodeUtils.ReadShort(XvMpFe1TJp, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14670)).ToString();
		int num = XvMpFe1TJp[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14694)] as TagNodeShort;
		eQXpICpNvl.SelectedValue = num;
		zlApjjJ5oc = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SEDp7Q7Qvg(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!zlApjjJ5oc)
		{
			int num = -1;
			if (eQXpICpNvl.SelectedValue is int)
			{
				num = (int)eQXpICpNvl.SelectedValue;
				XvMpFe1TJp[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14694)] = new TagNodeShort((short)num);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ft7pAZJnrC(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!zlApjjJ5oc)
		{
			short result = 0;
			short.TryParse(UHfZShMYl0.Text, out result);
			XvMpFe1TJp[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14670)] = new TagNodeShort(result);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && xDnp8EGGD6 != null)
		{
			xDnp8EGGD6.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yMepdY5KRj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		eQXpICpNvl = new ComboBox();
		fd1pzbWXbO = new Label();
		vPmZTWOM21 = new Label();
		UHfZShMYl0 = new TextBox();
		zTip9CVnDG = new EntityHelperHeader();
		SuspendLayout();
		eQXpICpNvl.DropDownStyle = ComboBoxStyle.DropDownList;
		eQXpICpNvl.FormattingEnabled = true;
		eQXpICpNvl.Location = new Point(24, 62);
		eQXpICpNvl.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14714);
		eQXpICpNvl.Size = new Size(331, 21);
		eQXpICpNvl.TabIndex = 2;
		eQXpICpNvl.SelectedIndexChanged += SEDp7Q7Qvg;
		fd1pzbWXbO.AutoSize = true;
		fd1pzbWXbO.Location = new Point(23, 47);
		fd1pzbWXbO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		fd1pzbWXbO.Size = new Size(37, 13);
		fd1pzbWXbO.TabIndex = 3;
		fd1pzbWXbO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14736);
		vPmZTWOM21.AutoSize = true;
		vPmZTWOM21.Location = new Point(23, 100);
		vPmZTWOM21.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		vPmZTWOM21.Size = new Size(64, 13);
		vPmZTWOM21.TabIndex = 4;
		vPmZTWOM21.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14752);
		UHfZShMYl0.Location = new Point(24, 117);
		UHfZShMYl0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14778);
		UHfZShMYl0.Size = new Size(100, 20);
		UHfZShMYl0.TabIndex = 5;
		UHfZShMYl0.TextChanged += ft7pAZJnrC;
		zTip9CVnDG.BackColor = Color.Silver;
		zTip9CVnDG.Dock = DockStyle.Top;
		zTip9CVnDG.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		zTip9CVnDG.ForeColor = Color.Black;
		zTip9CVnDG.Location = new Point(0, 0);
		zTip9CVnDG.Margin = new Padding(4);
		zTip9CVnDG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		zTip9CVnDG.Size = new Size(378, 35);
		zTip9CVnDG.TabIndex = 1;
		zTip9CVnDG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14806);
		zTip9CVnDG.ViewState = EntityHelperViewState.Expanded;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(UHfZShMYl0);
		base.Controls.Add(vPmZTWOM21);
		base.Controls.Add(fd1pzbWXbO);
		base.Controls.Add(eQXpICpNvl);
		base.Controls.Add(zTip9CVnDG);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14826);
		base.Size = new Size(378, 158);
		base.Load += tJspOEWNiZ;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
