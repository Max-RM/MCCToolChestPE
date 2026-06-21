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

public class VariableEntry : UserControl
{
	private VariableEntryActive PaUeh44fWJ;

	private IContainer v8SemYMf6c;

	private TextBox dUienMdJPK;

	private ComboBox aJXelN3Rtf;

	private TextBox N5Je23Imw3;

	private ComboBox g4rey6TKkR;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VariableEntry(VariableEntryActive variableEntryActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		BbMeKqXocf();
		PaUeh44fWJ = variableEntryActive;
		jhVeWEOfZj();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VariableEntry(VariableEntryActive variableEntryActive, SearchReplaceVariable variableValue) : this(variableEntryActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		N5Je23Imw3.Text = variableValue.Name;
		aJXelN3Rtf.SelectedValue = variableValue.DataType;
		if (variableValue.ListType != null)
		{
			g4rey6TKkR.SelectedValue = variableValue.ListType;
		}
		dUienMdJPK.Text = variableValue.Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jhVeWEOfZj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		aJXelN3Rtf.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		aJXelN3Rtf.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		aJXelN3Rtf.DataSource = new BindingSource(Constants.variableDataTypes, null);
		g4rey6TKkR.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		g4rey6TKkR.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		g4rey6TKkR.DataSource = new BindingSource(Constants.variableListTypes, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NlpepLu4sc(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		nBfeZbLliS();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nBfeZbLliS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		N5Je23Imw3.Width = 160;
		aJXelN3Rtf.Left = N5Je23Imw3.Left + N5Je23Imw3.Width + 5;
		g4rey6TKkR.Left = aJXelN3Rtf.Left + aJXelN3Rtf.Width + 5;
		string text = aJXelN3Rtf.SelectedValue as string;
		int left = aJXelN3Rtf.Left + aJXelN3Rtf.Width + 5;
		int num = base.Width - (N5Je23Imw3.Width + aJXelN3Rtf.Width + 20);
		if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30156))
		{
			left = g4rey6TKkR.Left + g4rey6TKkR.Width + 5;
			num -= g4rey6TKkR.Width + 5;
		}
		dUienMdJPK.Width = num;
		dUienMdJPK.Left = left;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchReplaceVariable GetVariable()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new SearchReplaceVariable(N5Je23Imw3.Text, dUienMdJPK.Text, aJXelN3Rtf.SelectedValue as string, g4rey6TKkR.SelectedValue as string);
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
	private void bdMefQBwxE(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PaUeh44fWJ(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ajqeir3JnU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PaUeh44fWJ(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rUyesJxbGR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		nBfeZbLliS();
		FO7eqynUhC();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FO7eqynUhC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = aJXelN3Rtf.SelectedValue as string;
		g4rey6TKkR.Visible = text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30156);
		if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30176) || text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30200) || text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30232) || text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30262) || text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30156))
		{
			dUienMdJPK.Multiline = true;
			dUienMdJPK.ScrollBars = ScrollBars.Vertical;
			base.Height = 92;
			dUienMdJPK.Height = 86;
		}
		else
		{
			base.Height = 26;
			dUienMdJPK.Height = 20;
			dUienMdJPK.ScrollBars = ScrollBars.None;
			dUienMdJPK.Multiline = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && v8SemYMf6c != null)
		{
			v8SemYMf6c.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BbMeKqXocf()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dUienMdJPK = new TextBox();
		aJXelN3Rtf = new ComboBox();
		N5Je23Imw3 = new TextBox();
		g4rey6TKkR = new ComboBox();
		SuspendLayout();
		dUienMdJPK.Location = new Point(335, 3);
		dUienMdJPK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30290);
		dUienMdJPK.Size = new Size(203, 20);
		dUienMdJPK.TabIndex = 9;
		dUienMdJPK.Enter += bdMefQBwxE;
		aJXelN3Rtf.DropDownStyle = ComboBoxStyle.DropDownList;
		aJXelN3Rtf.FormattingEnabled = true;
		aJXelN3Rtf.Location = new Point(189, 2);
		aJXelN3Rtf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30324);
		aJXelN3Rtf.Size = new Size(75, 21);
		aJXelN3Rtf.TabIndex = 8;
		aJXelN3Rtf.SelectedIndexChanged += rUyesJxbGR;
		aJXelN3Rtf.Enter += bdMefQBwxE;
		N5Je23Imw3.Location = new Point(4, 3);
		N5Je23Imw3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30348);
		N5Je23Imw3.Size = new Size(179, 20);
		N5Je23Imw3.TabIndex = 7;
		N5Je23Imw3.Enter += bdMefQBwxE;
		g4rey6TKkR.DropDownStyle = ComboBoxStyle.DropDownList;
		g4rey6TKkR.FormattingEnabled = true;
		g4rey6TKkR.Location = new Point(276, 3);
		g4rey6TKkR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30380);
		g4rey6TKkR.Size = new Size(60, 21);
		g4rey6TKkR.TabIndex = 10;
		g4rey6TKkR.Enter += bdMefQBwxE;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(g4rey6TKkR);
		base.Controls.Add(dUienMdJPK);
		base.Controls.Add(aJXelN3Rtf);
		base.Controls.Add(N5Je23Imw3);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30404);
		base.Size = new Size(542, 26);
		base.Enter += bdMefQBwxE;
		base.Resize += NlpepLu4sc;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
