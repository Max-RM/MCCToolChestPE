using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Substrate.Nbt;

namespace NBTExplorer.Windows;

public class EditValue : Form
{
	private TagNode _tag;

	private IContainer components;

	private TextBox textBox1;

	private Button _buttonCancel;

	private Button _buttonOK;

	public TagNode NodeTag => _tag;

	public EditValue(TagNode tag)
	{
		InitializeComponent();
		_tag = tag;
		if (tag == null)
		{
			base.DialogResult = DialogResult.Abort;
			Close();
		}
		else
		{
			textBox1.Text = _tag.ToString();
		}
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
		return ValidateValueInput();
	}

	private bool ValidateValueInput()
	{
		try
		{
			switch (_tag.GetTagType())
			{
			case TagType.TAG_BYTE:
				_tag.ToTagByte().Data = (byte)sbyte.Parse(textBox1.Text);
				break;
			case TagType.TAG_SHORT:
				_tag.ToTagShort().Data = short.Parse(textBox1.Text);
				break;
			case TagType.TAG_INT:
				_tag.ToTagInt().Data = int.Parse(textBox1.Text);
				break;
			case TagType.TAG_LONG:
				_tag.ToTagLong().Data = long.Parse(textBox1.Text);
				break;
			case TagType.TAG_FLOAT:
				_tag.ToTagFloat().Data = float.Parse(textBox1.Text);
				break;
			case TagType.TAG_DOUBLE:
				_tag.ToTagDouble().Data = double.Parse(textBox1.Text);
				break;
			case TagType.TAG_STRING:
				_tag.ToTagString().Data = textBox1.Text;
				break;
			case TagType.TAG_BYTE_ARRAY:
				break;
			}
		}
		catch (FormatException)
		{
			MessageBox.Show("The value is formatted incorrectly for the given type.");
			return false;
		}
		catch (OverflowException)
		{
			MessageBox.Show("The value is outside the acceptable range for the given type.");
			return false;
		}
		catch
		{
			return false;
		}
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
		this.textBox1 = new System.Windows.Forms.TextBox();
		this._buttonCancel = new System.Windows.Forms.Button();
		this._buttonOK = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.textBox1.Location = new System.Drawing.Point(12, 10);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(196, 20);
		this.textBox1.TabIndex = 0;
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
		base.Controls.Add(this.textBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditValue";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Edit Value...";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
