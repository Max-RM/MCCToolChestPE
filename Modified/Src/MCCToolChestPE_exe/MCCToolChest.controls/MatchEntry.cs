using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using MCCToolChest.model.SearchReplace;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class MatchEntry : UserControl
{
	private MatchEntryActive mBJ06wv3GZ;

	private IContainer NS40Ny75Nn;

	private TextBox Lwo0DG9uGo;

	private ComboBox DuX0cktKF8;

	private TextBox I9p0J5TFxk;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchEntry(MatchEntryActive matchEntryActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		PbY05GIhEp();
		mBJ06wv3GZ = matchEntryActive;
		vNa03BEj1w();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchEntry(MatchEntryActive matchEntryActive, MatchCondition condition) : this(matchEntryActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Lwo0DG9uGo.Text = condition.NodeSelector;
		DuX0cktKF8.SelectedValue = condition.Condition;
		I9p0J5TFxk.Text = condition.Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vNa03BEj1w()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DuX0cktKF8.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		DuX0cktKF8.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		DuX0cktKF8.DataSource = new BindingSource(Constants.conditionValues, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void M0h01h59RS(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = base.Width;
		num = (num - (DuX0cktKF8.Width + 20)) / 2;
		Lwo0DG9uGo.Width = num;
		DuX0cktKF8.Left = Lwo0DG9uGo.Left + Lwo0DG9uGo.Width + 5;
		I9p0J5TFxk.Width = num;
		I9p0J5TFxk.Left = DuX0cktKF8.Left + DuX0cktKF8.Width + 5;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchCondition GetCondition()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new MatchCondition(Lwo0DG9uGo.Text, DuX0cktKF8.SelectedValue as string, I9p0J5TFxk.Text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActive(bool active)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (active)
		{
			BackColor = Color.LightBlue;
		}
		else
		{
			BackColor = Control.DefaultBackColor;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lmX0EuBnh7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mBJ06wv3GZ(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void rcx0r9vQ0o()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mBJ06wv3GZ(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && NS40Ny75Nn != null)
		{
			NS40Ny75Nn.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PbY05GIhEp()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Lwo0DG9uGo = new TextBox();
		DuX0cktKF8 = new ComboBox();
		I9p0J5TFxk = new TextBox();
		SuspendLayout();
		Lwo0DG9uGo.Location = new Point(5, 3);
		Lwo0DG9uGo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23480);
		Lwo0DG9uGo.Size = new Size(179, 20);
		Lwo0DG9uGo.TabIndex = 0;
		Lwo0DG9uGo.Enter += lmX0EuBnh7;
		DuX0cktKF8.DropDownStyle = ComboBoxStyle.DropDownList;
		DuX0cktKF8.FormattingEnabled = true;
		DuX0cktKF8.Location = new Point(190, 2);
		DuX0cktKF8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23504);
		DuX0cktKF8.Size = new Size(90, 21);
		DuX0cktKF8.TabIndex = 2;
		DuX0cktKF8.Enter += lmX0EuBnh7;
		I9p0J5TFxk.Location = new Point(286, 3);
		I9p0J5TFxk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23526);
		I9p0J5TFxk.Size = new Size(253, 20);
		I9p0J5TFxk.TabIndex = 3;
		I9p0J5TFxk.Enter += lmX0EuBnh7;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(I9p0J5TFxk);
		base.Controls.Add(DuX0cktKF8);
		base.Controls.Add(Lwo0DG9uGo);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23558);
		base.Size = new Size(547, 26);
		base.Resize += M0h01h59RS;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
