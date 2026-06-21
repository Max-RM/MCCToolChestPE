using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class GoToForm : Form
{
	private IContainer components = null;

	private Label label;

	private TextBox tbLineNumber;

	private Button btnOk;

	private Button btnCancel;

	public int SelectedLineNumber { get; set; }

	public int TotalLineCount { get; set; }

	public GoToForm()
	{
		InitializeComponent();
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		tbLineNumber.Text = SelectedLineNumber.ToString();
		label.Text = $"Line number (1 - {TotalLineCount}):";
	}

	protected override void OnShown(EventArgs e)
	{
		base.OnShown(e);
		tbLineNumber.Focus();
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		if (int.TryParse(tbLineNumber.Text, out var result))
		{
			result = Math.Min(result, TotalLineCount);
			result = Math.Max(1, result);
			SelectedLineNumber = result;
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
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
		this.label = new System.Windows.Forms.Label();
		this.tbLineNumber = new System.Windows.Forms.TextBox();
		this.btnOk = new System.Windows.Forms.Button();
		this.btnCancel = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.label.AutoSize = true;
		this.label.Location = new System.Drawing.Point(12, 9);
		this.label.Name = "label";
		this.label.Size = new System.Drawing.Size(96, 13);
		this.label.TabIndex = 0;
		this.label.Text = "Line Number (1/1):";
		this.tbLineNumber.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbLineNumber.Location = new System.Drawing.Point(12, 29);
		this.tbLineNumber.Name = "tbLineNumber";
		this.tbLineNumber.Size = new System.Drawing.Size(296, 20);
		this.tbLineNumber.TabIndex = 1;
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.Location = new System.Drawing.Point(152, 71);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(75, 23);
		this.btnOk.TabIndex = 2;
		this.btnOk.Text = "OK";
		this.btnOk.UseVisualStyleBackColor = true;
		this.btnOk.Click += new System.EventHandler(btnOk_Click);
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(233, 71);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(75, 23);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = true;
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		base.AcceptButton = this.btnOk;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.btnCancel;
		base.ClientSize = new System.Drawing.Size(320, 106);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnOk);
		base.Controls.Add(this.tbLineNumber);
		base.Controls.Add(this.label);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "GoToForm";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Go To Line";
		base.TopMost = true;
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
