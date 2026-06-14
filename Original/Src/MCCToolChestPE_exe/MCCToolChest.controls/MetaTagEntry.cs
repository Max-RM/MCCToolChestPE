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

public class MetaTagEntry : UserControl
{
	private MetaTagEntryActive f4q29qEWjm;

	private IContainer iL52IdDmW8;

	private TextBox iI52zk542o;

	private ComboBox lEIyT0mKV7;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaTagEntry(MetaTagEntryActive metaTagEntryActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		bKQ288nWFp();
		f4q29qEWjm = metaTagEntryActive;
		IRV2d2OEi8();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaTagEntry(MetaTagEntryActive metaTagEntryActive, SearchReplaceVariable variableValue) : this(metaTagEntryActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IRV2d2OEi8()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lEIyT0mKV7.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		lEIyT0mKV7.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		lEIyT0mKV7.DataSource = new BindingSource(Constants.replaceNodeTypeValues, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void X7c2HLcV8j(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = base.Width;
		num = (num - 20) / 2;
		lEIyT0mKV7.Left = 10;
		lEIyT0mKV7.Width = num;
		iI52zk542o.Left = num + 20;
		iI52zk542o.Width = num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchReplaceVariable GetVariable()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new SearchReplaceVariable();
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
	private void wOw2Fk1Yxp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		f4q29qEWjm(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void GJh2jNIAIb()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		f4q29qEWjm(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && iL52IdDmW8 != null)
		{
			iL52IdDmW8.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bKQ288nWFp()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		iI52zk542o = new TextBox();
		lEIyT0mKV7 = new ComboBox();
		SuspendLayout();
		iI52zk542o.Location = new Point(285, 3);
		iI52zk542o.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21860);
		iI52zk542o.Size = new Size(253, 20);
		iI52zk542o.TabIndex = 9;
		lEIyT0mKV7.DropDownStyle = ComboBoxStyle.DropDownList;
		lEIyT0mKV7.FormattingEnabled = true;
		lEIyT0mKV7.Location = new Point(3, 2);
		lEIyT0mKV7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21886);
		lEIyT0mKV7.Size = new Size(276, 21);
		lEIyT0mKV7.TabIndex = 8;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(iI52zk542o);
		base.Controls.Add(lEIyT0mKV7);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21908);
		base.Size = new Size(542, 26);
		base.Resize += X7c2HLcV8j;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
