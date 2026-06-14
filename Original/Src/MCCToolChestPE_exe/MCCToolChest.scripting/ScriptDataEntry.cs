using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class ScriptDataEntry : Form
{
	private ScriptUI gmVSLJpEigC;

	public UIResult uiResult;

	private List<Control> jgTSLu33kpR;

	private IContainer dFGSLo3VC8E;

	private Button FtISLQnS8Y6;

	private Button CZmSLOctu40;

	private Panel KEZSLCwDSJ7;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptDataEntry(ScriptUI scriptUI)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		uiResult = new UIResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213180));
		jgTSLu33kpR = new List<Control>();
		z9NSLc1PeVq();
		gmVSLJpEigC = scriptUI;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nv7SL1pBW6M(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		dHgSLEc6WIF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dHgSLEc6WIF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		jgTSLu33kpR = new List<Control>();
		int num = 10;
		foreach (UIItem uiItem in gmVSLJpEigC.uiItems)
		{
			if (uiItem.uiType != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213196) && uiItem.uiType != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66388) && uiItem.uiType != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213216))
			{
				Label label = new Label();
				label.Text = uiItem.label;
				label.Height = 16;
				CZGSLruOMPt(label, num);
				num += 16;
			}
			Control control = null;
			if (uiItem.uiType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213216))
			{
				Label label2 = new Label();
				label2.Text = uiItem.label;
				Font font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12898), 20f, FontStyle.Bold);
				label2.Font = font;
				label2.AutoSize = true;
				CZGSLruOMPt(label2, num);
				num += label2.Height + 4;
			}
			else if (uiItem.uiType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213232))
			{
				TextBox textBox = new TextBox();
				textBox.Text = uiItem.value;
				textBox.Width = 400;
				control = textBox;
			}
			else if (uiItem.uiType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213250))
			{
				ComboBox comboBox = new ComboBox();
				comboBox.DropDownStyle = ComboBoxStyle.DropDown;
				comboBox.Width = 400;
				comboBox.DataSource = uiItem.list;
				comboBox.Text = uiItem.value;
				control = comboBox;
			}
			else if (uiItem.uiType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213270))
			{
				ListBox listBox = new ListBox();
				listBox.Width = 400;
				int num2 = uiItem.list.Count * 17;
				listBox.Height = ((num2 < 200) ? num2 : 200);
				listBox.DataSource = uiItem.list;
				control = listBox;
			}
			else if (uiItem.uiType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213196))
			{
				CheckBox checkBox = new CheckBox();
				checkBox.Checked = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650) == uiItem.value;
				checkBox.Text = uiItem.label;
				control = checkBox;
			}
			else if (uiItem.uiType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213288))
			{
				Panel panel = new Panel();
				panel.Width = 400;
				int num3 = uiItem.list.Count * 17;
				panel.Height = ((num3 < 200) ? num3 : 200);
				panel.BorderStyle = BorderStyle.FixedSingle;
				panel.AutoScroll = true;
				for (int i = 0; i < uiItem.list.Count; i++)
				{
					RadioButton radioButton = new RadioButton();
					radioButton.Text = uiItem.list[i];
					if (uiItem.value == uiItem.list[i])
					{
						radioButton.Checked = true;
					}
					radioButton.Height = 16;
					panel.Controls.Add(radioButton);
					radioButton.SetBounds(4, i * radioButton.Height, radioButton.Width, radioButton.Height);
				}
				control = panel;
			}
			else if (uiItem.uiType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66388))
			{
				Button button = new Button();
				button.Text = uiItem.label;
				button.Click += VeuSL6oMfds;
				control = button;
			}
			if (control == null)
			{
				continue;
			}
			jgTSLu33kpR.Add(control);
			control.Tag = uiItem;
			CZGSLruOMPt(control, num);
			num += control.Height + 10;
			if (uiItem.uiType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213250))
			{
				ComboBox comboBox2 = control as ComboBox;
				comboBox2.Text = uiItem.value;
			}
			if (!(uiItem.uiType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213270)))
			{
				continue;
			}
			ListBox listBox2 = control as ListBox;
			for (int j = 0; j < listBox2.Items.Count; j++)
			{
				listBox2.SetSelected(j, value: false);
			}
			for (int k = 0; k < listBox2.Items.Count; k++)
			{
				if (listBox2.Items[k].ToString() == uiItem.value)
				{
					listBox2.SetSelected(k, value: true);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CZGSLruOMPt(Control P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		KEZSLCwDSJ7.Controls.Add(P_0);
		P_0.SetBounds(20, P_1, P_0.Width, P_0.Height);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zccSL5p9w25()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uiResult = new UIResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213308));
		foreach (Control control in KEZSLCwDSJ7.Controls)
		{
			if (control.Tag is UIItem uIItem)
			{
				UIResultItem uIResultItem = new UIResultItem();
				uIResultItem.id = uIItem.id;
				if (control is TextBox)
				{
					uIResultItem.value = ((TextBox)control).Text;
				}
				else if (control is ComboBox)
				{
					uIResultItem.value = ((ComboBox)control).Text;
				}
				else if (control is CheckBox)
				{
					uIResultItem.value = ((CheckBox)control).Checked.ToString().ToLower();
				}
				else if (control is ListBox)
				{
					uIResultItem.value = ((ListBox)control).GetItemText(((ListBox)control).SelectedItem);
				}
				else if (control is Button)
				{
					uIResultItem.value = uIItem.value;
				}
				uiResult.items.Add(uIResultItem);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VeuSL6oMfds(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UIItem uIItem = ((Button)P_0).Tag as UIItem;
		uIItem.value = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213316);
		zccSL5p9w25();
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void llbSLNywV8w(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zccSL5p9w25();
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xFaSLDXwHBf(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uiResult = new UIResult(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213180));
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && dFGSLo3VC8E != null)
		{
			dFGSLo3VC8E.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void z9NSLc1PeVq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FtISLQnS8Y6 = new Button();
		CZmSLOctu40 = new Button();
		KEZSLCwDSJ7 = new Panel();
		SuspendLayout();
		FtISLQnS8Y6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		FtISLQnS8Y6.DialogResult = DialogResult.Cancel;
		FtISLQnS8Y6.Location = new Point(442, 545);
		FtISLQnS8Y6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		FtISLQnS8Y6.Size = new Size(50, 23);
		FtISLQnS8Y6.TabIndex = 4;
		FtISLQnS8Y6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		FtISLQnS8Y6.UseVisualStyleBackColor = true;
		FtISLQnS8Y6.Visible = false;
		FtISLQnS8Y6.Click += xFaSLDXwHBf;
		CZmSLOctu40.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		CZmSLOctu40.Location = new Point(383, 545);
		CZmSLOctu40.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		CZmSLOctu40.Size = new Size(50, 23);
		CZmSLOctu40.TabIndex = 3;
		CZmSLOctu40.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		CZmSLOctu40.UseVisualStyleBackColor = true;
		CZmSLOctu40.Visible = false;
		CZmSLOctu40.Click += llbSLNywV8w;
		KEZSLCwDSJ7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		KEZSLCwDSJ7.AutoScroll = true;
		KEZSLCwDSJ7.Location = new Point(13, 13);
		KEZSLCwDSJ7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23398);
		KEZSLCwDSJ7.Size = new Size(479, 555);
		KEZSLCwDSJ7.TabIndex = 5;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(504, 580);
		base.Controls.Add(KEZSLCwDSJ7);
		base.Controls.Add(FtISLQnS8Y6);
		base.Controls.Add(CZmSLOctu40);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213334);
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213368);
		base.Load += nv7SL1pBW6M;
		ResumeLayout(performLayout: false);
	}
}
