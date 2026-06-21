using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class ReplaceForm : Form
{
	private FastColoredTextBox tb;

	private bool firstSearch = true;

	private Place startPlace;

	private IContainer components = null;

	private Button btClose;

	private Button btFindNext;

	private CheckBox cbRegex;

	private CheckBox cbMatchCase;

	private Label label1;

	private CheckBox cbWholeWord;

	private Button btReplace;

	private Button btReplaceAll;

	private Label label2;

	public TextBox tbFind;

	public TextBox tbReplace;

	public ReplaceForm(FastColoredTextBox tb)
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
		try
		{
			if (!Find(tbFind.Text))
			{
				MessageBox.Show("Not found");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public List<Range> FindAll(string pattern)
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
		Range range = (tb.Selection.IsEmpty ? tb.Range.Clone() : tb.Selection.Clone());
		List<Range> list = new List<Range>();
		foreach (Range rangesByLine in range.GetRangesByLines(pattern, options))
		{
			list.Add(rangesByLine);
		}
		return list;
	}

	public bool Find(string pattern)
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
				tb.Selection.Start = current.Start;
				tb.Selection.End = current.End;
				tb.DoSelectionVisible();
				tb.Invalidate();
				return true;
			}
		}
		if (range.Start >= startPlace && startPlace > Place.Empty)
		{
			tb.Selection.Start = new Place(0, 0);
			return Find(pattern);
		}
		return false;
	}

	private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			btFindNext_Click(sender, null);
		}
		if (e.KeyChar == '\u001b')
		{
			Hide();
		}
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

	private void ReplaceForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
			Hide();
		}
		tb.Focus();
	}

	private void btReplace_Click(object sender, EventArgs e)
	{
		try
		{
			if (tb.SelectionLength != 0 && !tb.Selection.ReadOnly)
			{
				tb.InsertText(tbReplace.Text);
			}
			btFindNext_Click(sender, null);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void btReplaceAll_Click(object sender, EventArgs e)
	{
		try
		{
			tb.Selection.BeginUpdate();
			List<Range> list = FindAll(tbFind.Text);
			bool flag = false;
			foreach (Range item in list)
			{
				if (item.ReadOnly)
				{
					flag = true;
					break;
				}
			}
			if (!flag && list.Count > 0)
			{
				tb.TextSource.Manager.ExecuteCommand(new ReplaceTextCommand(tb.TextSource, list, tbReplace.Text));
				tb.Selection.Start = new Place(0, 0);
			}
			tb.Invalidate();
			MessageBox.Show(list.Count + " occurrence(s) replaced");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		tb.Selection.EndUpdate();
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
		this.btReplace = new System.Windows.Forms.Button();
		this.btReplaceAll = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.tbReplace = new System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.btClose.Location = new System.Drawing.Point(273, 153);
		this.btClose.Name = "btClose";
		this.btClose.Size = new System.Drawing.Size(75, 23);
		this.btClose.TabIndex = 8;
		this.btClose.Text = "Close";
		this.btClose.UseVisualStyleBackColor = true;
		this.btClose.Click += new System.EventHandler(btClose_Click);
		this.btFindNext.Location = new System.Drawing.Point(111, 124);
		this.btFindNext.Name = "btFindNext";
		this.btFindNext.Size = new System.Drawing.Size(75, 23);
		this.btFindNext.TabIndex = 5;
		this.btFindNext.Text = "Find next";
		this.btFindNext.UseVisualStyleBackColor = true;
		this.btFindNext.Click += new System.EventHandler(btFindNext_Click);
		this.tbFind.Location = new System.Drawing.Point(62, 12);
		this.tbFind.Name = "tbFind";
		this.tbFind.Size = new System.Drawing.Size(286, 20);
		this.tbFind.TabIndex = 0;
		this.tbFind.TextChanged += new System.EventHandler(cbMatchCase_CheckedChanged);
		this.tbFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbFind_KeyPress);
		this.cbRegex.AutoSize = true;
		this.cbRegex.Location = new System.Drawing.Point(273, 38);
		this.cbRegex.Name = "cbRegex";
		this.cbRegex.Size = new System.Drawing.Size(57, 17);
		this.cbRegex.TabIndex = 3;
		this.cbRegex.Text = "Regex";
		this.cbRegex.UseVisualStyleBackColor = true;
		this.cbRegex.CheckedChanged += new System.EventHandler(cbMatchCase_CheckedChanged);
		this.cbMatchCase.AutoSize = true;
		this.cbMatchCase.Location = new System.Drawing.Point(66, 38);
		this.cbMatchCase.Name = "cbMatchCase";
		this.cbMatchCase.Size = new System.Drawing.Size(82, 17);
		this.cbMatchCase.TabIndex = 1;
		this.cbMatchCase.Text = "Match case";
		this.cbMatchCase.UseVisualStyleBackColor = true;
		this.cbMatchCase.CheckedChanged += new System.EventHandler(cbMatchCase_CheckedChanged);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(23, 14);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(33, 13);
		this.label1.TabIndex = 5;
		this.label1.Text = "Find: ";
		this.cbWholeWord.AutoSize = true;
		this.cbWholeWord.Location = new System.Drawing.Point(154, 38);
		this.cbWholeWord.Name = "cbWholeWord";
		this.cbWholeWord.Size = new System.Drawing.Size(113, 17);
		this.cbWholeWord.TabIndex = 2;
		this.cbWholeWord.Text = "Match whole word";
		this.cbWholeWord.UseVisualStyleBackColor = true;
		this.cbWholeWord.CheckedChanged += new System.EventHandler(cbMatchCase_CheckedChanged);
		this.btReplace.Location = new System.Drawing.Point(192, 124);
		this.btReplace.Name = "btReplace";
		this.btReplace.Size = new System.Drawing.Size(75, 23);
		this.btReplace.TabIndex = 6;
		this.btReplace.Text = "Replace";
		this.btReplace.UseVisualStyleBackColor = true;
		this.btReplace.Click += new System.EventHandler(btReplace_Click);
		this.btReplaceAll.Location = new System.Drawing.Point(273, 124);
		this.btReplaceAll.Name = "btReplaceAll";
		this.btReplaceAll.Size = new System.Drawing.Size(75, 23);
		this.btReplaceAll.TabIndex = 7;
		this.btReplaceAll.Text = "Replace all";
		this.btReplaceAll.UseVisualStyleBackColor = true;
		this.btReplaceAll.Click += new System.EventHandler(btReplaceAll_Click);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 81);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(50, 13);
		this.label2.TabIndex = 9;
		this.label2.Text = "Replace:";
		this.tbReplace.Location = new System.Drawing.Point(62, 78);
		this.tbReplace.Name = "tbReplace";
		this.tbReplace.Size = new System.Drawing.Size(286, 20);
		this.tbReplace.TabIndex = 0;
		this.tbReplace.TextChanged += new System.EventHandler(cbMatchCase_CheckedChanged);
		this.tbReplace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbFind_KeyPress);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(360, 191);
		base.Controls.Add(this.tbFind);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.tbReplace);
		base.Controls.Add(this.btReplaceAll);
		base.Controls.Add(this.btReplace);
		base.Controls.Add(this.cbWholeWord);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.cbMatchCase);
		base.Controls.Add(this.cbRegex);
		base.Controls.Add(this.btFindNext);
		base.Controls.Add(this.btClose);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "ReplaceForm";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Find and replace";
		base.TopMost = true;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ReplaceForm_FormClosing);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
