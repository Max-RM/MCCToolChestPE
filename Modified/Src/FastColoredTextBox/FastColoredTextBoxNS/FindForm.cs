using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class FindForm : Form
{
	private bool firstSearch = true;

	private Place startPlace;

	private FastColoredTextBox tb;

	private IContainer components = null;

	private Button btClose;

	private Button btFindNext;

	private CheckBox cbRegex;

	private CheckBox cbMatchCase;

	private Label label1;

	private CheckBox cbWholeWord;

	public TextBox tbFind;

	public FindForm(FastColoredTextBox tb)
	{
		InitializeComponent();
		this.tb = tb;
	}

	private void btClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btFindNext_Click(object sender, EventArgs e)
	{
		FindNext(tbFind.Text);
	}

	public virtual void FindNext(string pattern)
	{
		try
		{
			RegexOptions options = ((!cbMatchCase.Checked) ? RegexOptions.IgnoreCase : RegexOptions.None);
			if (!cbRegex.Checked)
			{
				pattern = Regex.Escape(pattern);
			}
			if (cbWholeWord.Checked)
			{
				pattern = "\\b" + pattern + "\\b";
			}
			Range range = tb.Selection.Clone();
			range.Normalize();
			if (firstSearch)
			{
				startPlace = range.Start;
				firstSearch = false;
			}
			range.Start = range.End;
			if (range.Start >= startPlace)
			{
				range.End = new Place(tb.GetLineLength(tb.LinesCount - 1), tb.LinesCount - 1);
			}
			else
			{
				range.End = startPlace;
			}
			using (IEnumerator<Range> enumerator = range.GetRangesByLines(pattern, options).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Range current = enumerator.Current;
					tb.Selection = current;
					tb.DoSelectionVisible();
					tb.Invalidate();
					return;
				}
			}
			if (range.Start >= startPlace && startPlace > Place.Empty)
			{
				tb.Selection.Start = new Place(0, 0);
				FindNext(pattern);
			}
			else
			{
				MessageBox.Show("Not found");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			btFindNext.PerformClick();
			e.Handled = true;
		}
		else if (e.KeyChar == '\u001b')
		{
			Hide();
			e.Handled = true;
		}
	}

	private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
			Hide();
		}
		tb.Focus();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (keyData == Keys.Escape)
		{
			Close();
			return true;
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}

	protected override void OnActivated(EventArgs e)
	{
		tbFind.Focus();
		ResetSerach();
	}

	private void ResetSerach()
	{
		firstSearch = true;
	}

	private void cbMatchCase_CheckedChanged(object sender, EventArgs e)
	{
		ResetSerach();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.btClose = new System.Windows.Forms.Button();
		this.btFindNext = new System.Windows.Forms.Button();
		this.tbFind = new System.Windows.Forms.TextBox();
		this.cbRegex = new System.Windows.Forms.CheckBox();
		this.cbMatchCase = new System.Windows.Forms.CheckBox();
		this.label1 = new System.Windows.Forms.Label();
		this.cbWholeWord = new System.Windows.Forms.CheckBox();
		base.SuspendLayout();
		this.btClose.Location = new System.Drawing.Point(273, 73);
		this.btClose.Name = "btClose";
		this.btClose.Size = new System.Drawing.Size(75, 23);
		this.btClose.TabIndex = 5;
		this.btClose.Text = "Close";
		this.btClose.UseVisualStyleBackColor = true;
		this.btClose.Click += new System.EventHandler(btClose_Click);
		this.btFindNext.Location = new System.Drawing.Point(192, 73);
		this.btFindNext.Name = "btFindNext";
		this.btFindNext.Size = new System.Drawing.Size(75, 23);
		this.btFindNext.TabIndex = 4;
		this.btFindNext.Text = "Find next";
		this.btFindNext.UseVisualStyleBackColor = true;
		this.btFindNext.Click += new System.EventHandler(btFindNext_Click);
		this.tbFind.Location = new System.Drawing.Point(42, 12);
		this.tbFind.Name = "tbFind";
		this.tbFind.Size = new System.Drawing.Size(306, 20);
		this.tbFind.TabIndex = 0;
		this.tbFind.TextChanged += new System.EventHandler(cbMatchCase_CheckedChanged);
		this.tbFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbFind_KeyPress);
		this.cbRegex.AutoSize = true;
		this.cbRegex.Location = new System.Drawing.Point(249, 38);
		this.cbRegex.Name = "cbRegex";
		this.cbRegex.Size = new System.Drawing.Size(57, 17);
		this.cbRegex.TabIndex = 3;
		this.cbRegex.Text = "Regex";
		this.cbRegex.UseVisualStyleBackColor = true;
		this.cbRegex.CheckedChanged += new System.EventHandler(cbMatchCase_CheckedChanged);
		this.cbMatchCase.AutoSize = true;
		this.cbMatchCase.Location = new System.Drawing.Point(42, 38);
		this.cbMatchCase.Name = "cbMatchCase";
		this.cbMatchCase.Size = new System.Drawing.Size(82, 17);
		this.cbMatchCase.TabIndex = 1;
		this.cbMatchCase.Text = "Match case";
		this.cbMatchCase.UseVisualStyleBackColor = true;
		this.cbMatchCase.CheckedChanged += new System.EventHandler(cbMatchCase_CheckedChanged);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(6, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(33, 13);
		this.label1.TabIndex = 5;
		this.label1.Text = "Find: ";
		this.cbWholeWord.AutoSize = true;
		this.cbWholeWord.Location = new System.Drawing.Point(130, 38);
		this.cbWholeWord.Name = "cbWholeWord";
		this.cbWholeWord.Size = new System.Drawing.Size(113, 17);
		this.cbWholeWord.TabIndex = 2;
		this.cbWholeWord.Text = "Match whole word";
		this.cbWholeWord.UseVisualStyleBackColor = true;
		this.cbWholeWord.CheckedChanged += new System.EventHandler(cbMatchCase_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(360, 108);
		base.Controls.Add(this.cbWholeWord);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.cbMatchCase);
		base.Controls.Add(this.cbRegex);
		base.Controls.Add(this.tbFind);
		base.Controls.Add(this.btFindNext);
		base.Controls.Add(this.btClose);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "FindForm";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Find";
		base.TopMost = true;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FindForm_FormClosing);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
