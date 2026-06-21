using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class DeletePruneEntry : Form
{
	public AreaActionType areaAction;

	public int c1x;

	public int c1z;

	public int c2x;

	public int c2z;

	private IContainer UCpN0mVt4d;

	private Button UN3NBqZn0n;

	private Label R6YNtcKfFa;

	private Label Sk0NaM1kSu;

	private Button ll0NXTNF4p;

	private Button cujNxClFxJ;

	private TextBox ApcNeu5jCK;

	private TextBox x3FNMq4FOw;

	private TextBox xwtNUhbF0f;

	private TextBox bvZNL2g1xs;

	private Label pmJNgp3qW8;

	private Label iRlNPpeHvn;

	private Label EHTNR8blZ9;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DeletePruneEntry()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		utPNy2RQ7D();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sobNq0Ef9I(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void v2cNKNIHEE(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XVfNm4w1uY(AreaActionType.DELETE);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SBxNhs5aWd(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XVfNm4w1uY(AreaActionType.PRUNE);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XVfNm4w1uY(AreaActionType P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (fEUNn2s4ZQ(out c1x, out c1z, out c2x, out c2z))
		{
			areaAction = P_0;
			RigN2BP3gU();
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool fEUNn2s4ZQ(out int P_0, out int P_1, out int P_2, out int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		P_0 = 0;
		P_1 = 0;
		P_2 = 0;
		P_3 = 0;
		if (int.TryParse(bvZNL2g1xs.Text.Trim(), out P_0) && int.TryParse(xwtNUhbF0f.Text.Trim(), out P_1) && int.TryParse(x3FNMq4FOw.Text.Trim(), out P_2) && int.TryParse(ApcNeu5jCK.Text.Trim(), out P_3))
		{
			result = true;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FhpNlV5U8Q(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bvZNL2g1xs.Text = "";
		xwtNUhbF0f.Text = "";
		x3FNMq4FOw.Text = "";
		ApcNeu5jCK.Text = "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RigN2BP3gU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (c1x > c2x)
		{
			int num = c1x;
			c1x = c2x;
			c2x = num;
		}
		if (c1z > c2z)
		{
			int num2 = c1z;
			c1z = c2z;
			c2z = num2;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && UCpN0mVt4d != null)
		{
			UCpN0mVt4d.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void utPNy2RQ7D()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UN3NBqZn0n = new Button();
		R6YNtcKfFa = new Label();
		Sk0NaM1kSu = new Label();
		ll0NXTNF4p = new Button();
		cujNxClFxJ = new Button();
		ApcNeu5jCK = new TextBox();
		x3FNMq4FOw = new TextBox();
		xwtNUhbF0f = new TextBox();
		bvZNL2g1xs = new TextBox();
		pmJNgp3qW8 = new Label();
		iRlNPpeHvn = new Label();
		EHTNR8blZ9 = new Label();
		SuspendLayout();
		UN3NBqZn0n.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		UN3NBqZn0n.Location = new Point(132, 133);
		UN3NBqZn0n.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45590);
		UN3NBqZn0n.Size = new Size(46, 23);
		UN3NBqZn0n.TabIndex = 37;
		UN3NBqZn0n.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29636);
		UN3NBqZn0n.UseVisualStyleBackColor = true;
		UN3NBqZn0n.Visible = false;
		UN3NBqZn0n.Click += FhpNlV5U8Q;
		R6YNtcKfFa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		R6YNtcKfFa.AutoSize = true;
		R6YNtcKfFa.Location = new Point(37, 112);
		R6YNtcKfFa.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		R6YNtcKfFa.Size = new Size(14, 13);
		R6YNtcKfFa.TabIndex = 36;
		R6YNtcKfFa.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45618);
		Sk0NaM1kSu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Sk0NaM1kSu.AutoSize = true;
		Sk0NaM1kSu.Location = new Point(38, 87);
		Sk0NaM1kSu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		Sk0NaM1kSu.Size = new Size(14, 13);
		Sk0NaM1kSu.TabIndex = 35;
		Sk0NaM1kSu.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45624);
		ll0NXTNF4p.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		ll0NXTNF4p.Location = new Point(116, 141);
		ll0NXTNF4p.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45630);
		ll0NXTNF4p.Size = new Size(46, 23);
		ll0NXTNF4p.TabIndex = 34;
		ll0NXTNF4p.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45658);
		ll0NXTNF4p.UseVisualStyleBackColor = true;
		ll0NXTNF4p.Click += SBxNhs5aWd;
		cujNxClFxJ.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		cujNxClFxJ.Location = new Point(54, 141);
		cujNxClFxJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45672);
		cujNxClFxJ.Size = new Size(46, 23);
		cujNxClFxJ.TabIndex = 33;
		cujNxClFxJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326);
		cujNxClFxJ.UseVisualStyleBackColor = true;
		cujNxClFxJ.Click += v2cNKNIHEE;
		ApcNeu5jCK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		ApcNeu5jCK.Location = new Point(120, 107);
		ApcNeu5jCK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45702);
		ApcNeu5jCK.Size = new Size(46, 20);
		ApcNeu5jCK.TabIndex = 32;
		x3FNMq4FOw.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		x3FNMq4FOw.Location = new Point(120, 83);
		x3FNMq4FOw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45728);
		x3FNMq4FOw.Size = new Size(46, 20);
		x3FNMq4FOw.TabIndex = 31;
		xwtNUhbF0f.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		xwtNUhbF0f.Location = new Point(55, 107);
		xwtNUhbF0f.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45754);
		xwtNUhbF0f.Size = new Size(46, 20);
		xwtNUhbF0f.TabIndex = 30;
		bvZNL2g1xs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		bvZNL2g1xs.Location = new Point(56, 83);
		bvZNL2g1xs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45780);
		bvZNL2g1xs.Size = new Size(46, 20);
		bvZNL2g1xs.TabIndex = 29;
		pmJNgp3qW8.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		pmJNgp3qW8.Location = new Point(10, 8);
		pmJNgp3qW8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		pmJNgp3qW8.Size = new Size(234, 47);
		pmJNgp3qW8.TabIndex = 38;
		pmJNgp3qW8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45806);
		iRlNPpeHvn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		iRlNPpeHvn.AutoSize = true;
		iRlNPpeHvn.Location = new Point(56, 70);
		iRlNPpeHvn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12846);
		iRlNPpeHvn.Size = new Size(47, 13);
		iRlNPpeHvn.TabIndex = 39;
		iRlNPpeHvn.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46030);
		EHTNR8blZ9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		EHTNR8blZ9.AutoSize = true;
		EHTNR8blZ9.Location = new Point(120, 70);
		EHTNR8blZ9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11162);
		EHTNR8blZ9.Size = new Size(47, 13);
		EHTNR8blZ9.TabIndex = 40;
		EHTNR8blZ9.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46050);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(249, 175);
		base.Controls.Add(EHTNR8blZ9);
		base.Controls.Add(iRlNPpeHvn);
		base.Controls.Add(pmJNgp3qW8);
		base.Controls.Add(UN3NBqZn0n);
		base.Controls.Add(R6YNtcKfFa);
		base.Controls.Add(Sk0NaM1kSu);
		base.Controls.Add(ll0NXTNF4p);
		base.Controls.Add(cujNxClFxJ);
		base.Controls.Add(ApcNeu5jCK);
		base.Controls.Add(x3FNMq4FOw);
		base.Controls.Add(xwtNUhbF0f);
		base.Controls.Add(bvZNL2g1xs);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46070);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46106);
		base.Load += sobNq0Ef9I;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
