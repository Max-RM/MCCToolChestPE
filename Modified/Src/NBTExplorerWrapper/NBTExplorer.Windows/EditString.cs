using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NBTExplorer.Windows;

public class EditString : Form
{
	private string _string;

	private IContainer components;

	private TextBox _stringField;

	private Button _buttonCancel;

	private Button _buttonOK;

	public string StringValue => _string;

	public EditString(string stringVal)
	{
		InitializeComponent();
		_string = stringVal;
		_stringField.Text = _string;
	}

	private void Apply()
	{
		if (ValidateInput())
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private bool ValidateInput()
	{
		return ValidateStringInput();
	}

	private bool ValidateStringInput()
	{
		_string = _stringField.Text.Trim();
		return true;
	}

	private void _buttonOK_Click(object sender, EventArgs e)
	{
		Apply();
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
		this._stringField = new System.Windows.Forms.TextBox();
		this._buttonCancel = new System.Windows.Forms.Button();
		this._buttonOK = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this._stringField.Location = new System.Drawing.Point(12, 12);
		this._stringField.Multiline = true;
		this._stringField.Name = "_stringField";
		this._stringField.Size = new System.Drawing.Size(331, 116);
		this._stringField.TabIndex = 4;
		this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._buttonCancel.Location = new System.Drawing.Point(187, 134);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(75, 23);
		this._buttonCancel.TabIndex = 9;
		this._buttonCancel.Text = "Cancel";
		this._buttonCancel.UseVisualStyleBackColor = true;
		this._buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonOK.Location = new System.Drawing.Point(268, 134);
		this._buttonOK.Name = "_buttonOK";
		this._buttonOK.Size = new System.Drawing.Size(75, 23);
		this._buttonOK.TabIndex = 8;
		this._buttonOK.Text = "OK";
		this._buttonOK.UseVisualStyleBackColor = true;
		this._buttonOK.Click += new System.EventHandler(_buttonOK_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this._buttonCancel;
		base.ClientSize = new System.Drawing.Size(355, 169);
		base.Controls.Add(this._buttonCancel);
		base.Controls.Add(this._buttonOK);
		base.Controls.Add(this._stringField);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditString";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Edit String...";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
