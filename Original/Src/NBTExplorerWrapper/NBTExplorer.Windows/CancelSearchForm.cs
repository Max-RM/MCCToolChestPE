using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NBTExplorer.Windows;

public class CancelSearchForm : Form
{
	private IContainer components;

	private Button _buttonCancel;

	private Label _searchPathLabel;

	public string SearchPathLabel
	{
		get
		{
			return _searchPathLabel.Text;
		}
		set
		{
			_searchPathLabel.Text = value;
		}
	}

	public CancelSearchForm()
	{
		InitializeComponent();
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
		this._buttonCancel = new System.Windows.Forms.Button();
		this._searchPathLabel = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._buttonCancel.Location = new System.Drawing.Point(232, 45);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(75, 23);
		this._buttonCancel.TabIndex = 0;
		this._buttonCancel.Text = "Cancel";
		this._buttonCancel.UseVisualStyleBackColor = true;
		this._searchPathLabel.Location = new System.Drawing.Point(12, 19);
		this._searchPathLabel.Name = "_searchPathLabel";
		this._searchPathLabel.Size = new System.Drawing.Size(514, 23);
		this._searchPathLabel.TabIndex = 1;
		this._searchPathLabel.Text = "...";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this._buttonCancel;
		base.ClientSize = new System.Drawing.Size(538, 84);
		base.Controls.Add(this._searchPathLabel);
		base.Controls.Add(this._buttonCancel);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CancelSearchForm";
		this.Text = "Searching...";
		base.ResumeLayout(false);
	}
}
