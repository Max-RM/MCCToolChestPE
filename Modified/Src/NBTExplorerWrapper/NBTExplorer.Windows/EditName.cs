using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NBTExplorer.Windows;

public class EditName : Form
{
	private string _originalName;

	private string _name;

	private List<string> _invalidNames = new List<string>();

	private IContainer components;

	private TextBox _nameField;

	private Button _buttonCancel;

	private Button _buttonOK;

	public string TagName => _name;

	public List<string> InvalidNames => _invalidNames;

	public bool AllowEmpty { get; set; }

	public bool IsModified => _name != _originalName;

	public EditName(string name)
	{
		InitializeComponent();
		_originalName = name;
		_name = name;
		_nameField.Text = _name;
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
		return ValidateNameInput();
	}

	private bool ValidateNameInput()
	{
		string text = _nameField.Text.Trim();
		if (string.IsNullOrEmpty(text) && !AllowEmpty)
		{
			MessageBox.Show("You must provide a nonempty name.");
			return false;
		}
		if (text != _originalName && _invalidNames.Contains(text))
		{
			MessageBox.Show("Duplicate name provided.");
			return false;
		}
		_name = _nameField.Text.Trim();
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
		this._nameField = new System.Windows.Forms.TextBox();
		this._buttonCancel = new System.Windows.Forms.Button();
		this._buttonOK = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this._nameField.Location = new System.Drawing.Point(12, 10);
		this._nameField.Name = "_nameField";
		this._nameField.Size = new System.Drawing.Size(196, 20);
		this._nameField.TabIndex = 0;
		this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._buttonCancel.Location = new System.Drawing.Point(52, 37);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(75, 23);
		this._buttonCancel.TabIndex = 11;
		this._buttonCancel.Text = "Cancel";
		this._buttonCancel.UseVisualStyleBackColor = true;
		this._buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonOK.Location = new System.Drawing.Point(133, 37);
		this._buttonOK.Name = "_buttonOK";
		this._buttonOK.Size = new System.Drawing.Size(75, 23);
		this._buttonOK.TabIndex = 10;
		this._buttonOK.Text = "OK";
		this._buttonOK.UseVisualStyleBackColor = true;
		this._buttonOK.Click += new System.EventHandler(_buttonOK_Click);
		base.AcceptButton = this._buttonOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this._buttonCancel;
		base.ClientSize = new System.Drawing.Size(220, 72);
		base.Controls.Add(this._buttonCancel);
		base.Controls.Add(this._buttonOK);
		base.Controls.Add(this._nameField);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditName";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Edit Name...";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
