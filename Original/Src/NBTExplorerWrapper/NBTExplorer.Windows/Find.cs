using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NBTExplorer.Windows;

public class Find : Form
{
	private IContainer components;

	private CheckBox _cbName;

	private CheckBox _cbValue;

	private TextBox _textName;

	private TextBox _textValue;

	private Button _buttonFind;

	private Button _buttonCancel;

	public bool MatchName => _cbName.Checked;

	public bool MatchValue => _cbValue.Checked;

	public string NameToken => _textName.Text;

	public string ValueToken => _textValue.Text;

	public Find()
	{
		InitializeComponent();
	}

	private void _buttonFind_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void _buttonCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void _textName_TextChanged(object sender, EventArgs e)
	{
		_cbName.Checked = true;
	}

	private void _textValue_TextChanged(object sender, EventArgs e)
	{
		_cbValue.Checked = true;
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
		this._cbName = new System.Windows.Forms.CheckBox();
		this._cbValue = new System.Windows.Forms.CheckBox();
		this._textName = new System.Windows.Forms.TextBox();
		this._textValue = new System.Windows.Forms.TextBox();
		this._buttonFind = new System.Windows.Forms.Button();
		this._buttonCancel = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this._cbName.AutoSize = true;
		this._cbName.Location = new System.Drawing.Point(13, 13);
		this._cbName.Name = "_cbName";
		this._cbName.Size = new System.Drawing.Size(57, 17);
		this._cbName.TabIndex = 0;
		this._cbName.Text = "Name:";
		this._cbName.UseVisualStyleBackColor = true;
		this._cbValue.AutoSize = true;
		this._cbValue.Location = new System.Drawing.Point(13, 37);
		this._cbValue.Name = "_cbValue";
		this._cbValue.Size = new System.Drawing.Size(56, 17);
		this._cbValue.TabIndex = 1;
		this._cbValue.Text = "Value:";
		this._cbValue.UseVisualStyleBackColor = true;
		this._textName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this._textName.Location = new System.Drawing.Point(76, 12);
		this._textName.Name = "_textName";
		this._textName.Size = new System.Drawing.Size(273, 20);
		this._textName.TabIndex = 2;
		this._textName.TextChanged += new System.EventHandler(_textName_TextChanged);
		this._textValue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this._textValue.Location = new System.Drawing.Point(76, 34);
		this._textValue.Name = "_textValue";
		this._textValue.Size = new System.Drawing.Size(273, 20);
		this._textValue.TabIndex = 3;
		this._textValue.TextChanged += new System.EventHandler(_textValue_TextChanged);
		this._buttonFind.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonFind.Location = new System.Drawing.Point(274, 65);
		this._buttonFind.Name = "_buttonFind";
		this._buttonFind.Size = new System.Drawing.Size(75, 23);
		this._buttonFind.TabIndex = 4;
		this._buttonFind.Text = "Find";
		this._buttonFind.UseVisualStyleBackColor = true;
		this._buttonFind.Click += new System.EventHandler(_buttonFind_Click);
		this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._buttonCancel.Location = new System.Drawing.Point(193, 65);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(75, 23);
		this._buttonCancel.TabIndex = 5;
		this._buttonCancel.Text = "Cancel";
		this._buttonCancel.UseVisualStyleBackColor = true;
		this._buttonCancel.Click += new System.EventHandler(_buttonCancel_Click);
		base.AcceptButton = this._buttonFind;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this._buttonCancel;
		base.ClientSize = new System.Drawing.Size(361, 100);
		base.Controls.Add(this._buttonCancel);
		base.Controls.Add(this._buttonFind);
		base.Controls.Add(this._textValue);
		base.Controls.Add(this._textName);
		base.Controls.Add(this._cbValue);
		base.Controls.Add(this._cbName);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Find";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Find";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
