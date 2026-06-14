using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Substrate.Nbt;

namespace NBTExplorer.Windows;

public class CreateNodeForm : Form
{
	private string _name;

	private int _size;

	private TagType _type;

	private TagNode _tag;

	private bool _hasName;

	private List<string> _invalidNames = new List<string>();

	private IContainer components;

	private TextBox _sizeField;

	private Label _sizeFieldLabel;

	private Label _nameFieldLabel;

	private TextBox _nameField;

	private Button _buttonCancel;

	private Button _buttonOK;

	public string TagName => _name;

	public TagNode TagNode => _tag;

	public List<string> InvalidNames => _invalidNames;

	public bool HasName => _hasName;

	private bool IsTagSizedType
	{
		get
		{
			switch (_type)
			{
			case TagType.TAG_BYTE_ARRAY:
			case TagType.TAG_INT_ARRAY:
			case TagType.TAG_LONG_ARRAY:
			case TagType.TAG_SHORT_ARRAY:
				return true;
			default:
				return false;
			}
		}
	}

	public CreateNodeForm(TagType tagType)
		: this(tagType, hasName: true)
	{
	}

	public CreateNodeForm(TagType tagType, bool hasName)
	{
		InitializeComponent();
		_type = tagType;
		_hasName = hasName;
		SetNameBoxState();
		SetSizeBoxState();
	}

	private void SetNameBoxState()
	{
		if (HasName)
		{
			_nameFieldLabel.Enabled = true;
			_nameField.Enabled = true;
		}
		else
		{
			_nameFieldLabel.Enabled = false;
			_nameField.Enabled = false;
		}
	}

	private void SetSizeBoxState()
	{
		if (IsTagSizedType)
		{
			_sizeFieldLabel.Enabled = true;
			_sizeField.Enabled = true;
		}
		else
		{
			_sizeFieldLabel.Enabled = false;
			_sizeField.Enabled = false;
		}
	}

	private void Apply()
	{
		if (ValidateInput())
		{
			_tag = CreateTag();
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private TagNode CreateTag()
	{
		return _type switch
		{
			TagType.TAG_BYTE => new TagNodeByte(), 
			TagType.TAG_BYTE_ARRAY => new TagNodeByteArray(new byte[_size]), 
			TagType.TAG_COMPOUND => new TagNodeCompound(), 
			TagType.TAG_DOUBLE => new TagNodeDouble(), 
			TagType.TAG_FLOAT => new TagNodeFloat(), 
			TagType.TAG_INT => new TagNodeInt(), 
			TagType.TAG_INT_ARRAY => new TagNodeIntArray(new int[_size]), 
			TagType.TAG_LIST => new TagNodeList(TagType.TAG_BYTE), 
			TagType.TAG_LONG => new TagNodeLong(), 
			TagType.TAG_LONG_ARRAY => new TagNodeLongArray(new long[_size]), 
			TagType.TAG_SHORT => new TagNodeShort(), 
			TagType.TAG_STRING => new TagNodeString(), 
			_ => new TagNodeByte(), 
		};
	}

	private bool ValidateInput()
	{
		if (ValidateNameInput())
		{
			return ValidateSizeInput();
		}
		return false;
	}

	private bool ValidateNameInput()
	{
		if (!HasName)
		{
			return true;
		}
		string text = _nameField.Text.Trim();
		if (string.IsNullOrEmpty(text))
		{
			MessageBox.Show("You must provide a nonempty name.");
			return false;
		}
		if (_invalidNames.Contains(text))
		{
			MessageBox.Show("Duplicate name provided.");
			return false;
		}
		_name = _nameField.Text.Trim();
		return true;
	}

	private bool ValidateSizeInput()
	{
		if (!IsTagSizedType)
		{
			return true;
		}
		if (!int.TryParse(_sizeField.Text.Trim(), out _size))
		{
			MessageBox.Show("Size must be a valid integer value.");
			return false;
		}
		_size = Math.Max(0, _size);
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
		this._sizeField = new System.Windows.Forms.TextBox();
		this._sizeFieldLabel = new System.Windows.Forms.Label();
		this._nameFieldLabel = new System.Windows.Forms.Label();
		this._nameField = new System.Windows.Forms.TextBox();
		this._buttonCancel = new System.Windows.Forms.Button();
		this._buttonOK = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this._sizeField.Location = new System.Drawing.Point(56, 26);
		this._sizeField.Name = "_sizeField";
		this._sizeField.Size = new System.Drawing.Size(67, 20);
		this._sizeField.TabIndex = 7;
		this._sizeFieldLabel.AutoSize = true;
		this._sizeFieldLabel.Location = new System.Drawing.Point(12, 29);
		this._sizeFieldLabel.Name = "_sizeFieldLabel";
		this._sizeFieldLabel.Size = new System.Drawing.Size(30, 13);
		this._sizeFieldLabel.TabIndex = 6;
		this._sizeFieldLabel.Text = "Size:";
		this._nameFieldLabel.AutoSize = true;
		this._nameFieldLabel.Location = new System.Drawing.Point(12, 9);
		this._nameFieldLabel.Name = "_nameFieldLabel";
		this._nameFieldLabel.Size = new System.Drawing.Size(38, 13);
		this._nameFieldLabel.TabIndex = 5;
		this._nameFieldLabel.Text = "Name:";
		this._nameField.Location = new System.Drawing.Point(56, 6);
		this._nameField.Name = "_nameField";
		this._nameField.Size = new System.Drawing.Size(209, 20);
		this._nameField.TabIndex = 4;
		this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._buttonCancel.Location = new System.Drawing.Point(109, 57);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(75, 23);
		this._buttonCancel.TabIndex = 9;
		this._buttonCancel.Text = "Cancel";
		this._buttonCancel.UseVisualStyleBackColor = true;
		this._buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonOK.Location = new System.Drawing.Point(190, 57);
		this._buttonOK.Name = "_buttonOK";
		this._buttonOK.Size = new System.Drawing.Size(75, 23);
		this._buttonOK.TabIndex = 8;
		this._buttonOK.Text = "OK";
		this._buttonOK.UseVisualStyleBackColor = true;
		this._buttonOK.Click += new System.EventHandler(_buttonOK_Click);
		base.AcceptButton = this._buttonOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this._buttonCancel;
		base.ClientSize = new System.Drawing.Size(277, 92);
		base.Controls.Add(this._buttonCancel);
		base.Controls.Add(this._buttonOK);
		base.Controls.Add(this._sizeField);
		base.Controls.Add(this._sizeFieldLabel);
		base.Controls.Add(this._nameFieldLabel);
		base.Controls.Add(this._nameField);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CreateNode";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "Create Tag...";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
