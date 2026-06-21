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

public class ReplaceEntry : UserControl
{
	private ReplaceEntryActive SxwxLeqKaM;

	private IContainer r8kxgtxj4J;

	private TextBox vCbxPo9HqP;

	private ComboBox qFVxRUtaf8;

	private TextBox cAhxkSv9T1;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceEntry(ReplaceEntryActive replaceEntryActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		gw9xUdaKF8();
		SxwxLeqKaM = replaceEntryActive;
		J99xXTdV1C();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceEntry(ReplaceEntryActive replaceEntryActive, ReplaceValue replaceValue) : this(replaceEntryActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		cAhxkSv9T1.Text = replaceValue.NodeSelector;
		qFVxRUtaf8.SelectedValue = replaceValue.NodeType;
		vCbxPo9HqP.Text = replaceValue.Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void J99xXTdV1C()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qFVxRUtaf8.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		qFVxRUtaf8.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		qFVxRUtaf8.DataSource = new BindingSource(Constants.replaceNodeTypeValues, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wOIxxn5ys5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = base.Width;
		num = (num - (qFVxRUtaf8.Width + 20)) / 2;
		cAhxkSv9T1.Width = num;
		qFVxRUtaf8.Left = cAhxkSv9T1.Left + cAhxkSv9T1.Width + 5;
		vCbxPo9HqP.Width = num;
		vCbxPo9HqP.Left = qFVxRUtaf8.Left + qFVxRUtaf8.Width + 5;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceValue GetReplacement()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new ReplaceValue(cAhxkSv9T1.Text, qFVxRUtaf8.SelectedValue as string, vCbxPo9HqP.Text);
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
	private void pg9xeVFmNs(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SxwxLeqKaM(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void IKpxM8RMda()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SxwxLeqKaM(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && r8kxgtxj4J != null)
		{
			r8kxgtxj4J.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gw9xUdaKF8()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vCbxPo9HqP = new TextBox();
		qFVxRUtaf8 = new ComboBox();
		cAhxkSv9T1 = new TextBox();
		SuspendLayout();
		vCbxPo9HqP.Location = new Point(285, 3);
		vCbxPo9HqP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23526);
		vCbxPo9HqP.Size = new Size(253, 20);
		vCbxPo9HqP.TabIndex = 6;
		vCbxPo9HqP.Enter += pg9xeVFmNs;
		qFVxRUtaf8.DropDownStyle = ComboBoxStyle.DropDownList;
		qFVxRUtaf8.FormattingEnabled = true;
		qFVxRUtaf8.Location = new Point(189, 2);
		qFVxRUtaf8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29902);
		qFVxRUtaf8.Size = new Size(90, 21);
		qFVxRUtaf8.TabIndex = 5;
		qFVxRUtaf8.Enter += pg9xeVFmNs;
		cAhxkSv9T1.Location = new Point(4, 3);
		cAhxkSv9T1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23480);
		cAhxkSv9T1.Size = new Size(179, 20);
		cAhxkSv9T1.TabIndex = 4;
		cAhxkSv9T1.Enter += pg9xeVFmNs;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Control;
		base.Controls.Add(vCbxPo9HqP);
		base.Controls.Add(qFVxRUtaf8);
		base.Controls.Add(cAhxkSv9T1);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29926);
		base.Size = new Size(542, 26);
		base.Resize += wOIxxn5ys5;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
