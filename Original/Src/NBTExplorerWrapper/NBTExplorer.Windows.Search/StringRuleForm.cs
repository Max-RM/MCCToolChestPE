using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NBTExplorer.Model.Search;

namespace NBTExplorer.Windows.Search;

public class StringRuleForm : Form
{
	private IContainer components;

	private Label label1;

	private TextBox _textName;

	private TextBox _textValue;

	private ComboBox _selectOperator;

	private GroupBox _ruleGroup;

	private Label label2;

	private Button _buttonOK;

	private Button _buttonCancel;

	public string RuleGroupName
	{
		get
		{
			return _ruleGroup.Text;
		}
		set
		{
			_ruleGroup.Text = value;
		}
	}

	public string TagName
	{
		get
		{
			return _textName.Text;
		}
		set
		{
			_textName.Text = value;
		}
	}

	public string TagValue
	{
		get
		{
			return _textValue.Text;
		}
		set
		{
			_textValue.Text = value;
		}
	}

	public StringOperator Operator
	{
		get
		{
			return (StringOperator)_selectOperator.SelectedItem;
		}
		set
		{
			_selectOperator.SelectedItem = value;
		}
	}

	public StringRuleForm(Dictionary<StringOperator, string> operators)
	{
		InitializeComponent();
		foreach (KeyValuePair<StringOperator, string> @operator in operators)
		{
			_selectOperator.Items.Add(@operator.Key);
		}
		_selectOperator.SelectedIndex = 0;
	}

	private void _buttonOK_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(TagName))
		{
			MessageBox.Show(this, "Rule missing name");
			return;
		}
		base.DialogResult = DialogResult.OK;
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
		this.label1 = new System.Windows.Forms.Label();
		this._textName = new System.Windows.Forms.TextBox();
		this._textValue = new System.Windows.Forms.TextBox();
		this._selectOperator = new System.Windows.Forms.ComboBox();
		this._ruleGroup = new System.Windows.Forms.GroupBox();
		this.label2 = new System.Windows.Forms.Label();
		this._buttonOK = new System.Windows.Forms.Button();
		this._buttonCancel = new System.Windows.Forms.Button();
		this._ruleGroup.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(6, 22);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(60, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Tag Name:";
		this._textName.Location = new System.Drawing.Point(102, 19);
		this._textName.Name = "_textName";
		this._textName.Size = new System.Drawing.Size(142, 20);
		this._textName.TabIndex = 1;
		this._textValue.Location = new System.Drawing.Point(102, 72);
		this._textValue.Name = "_textValue";
		this._textValue.Size = new System.Drawing.Size(142, 20);
		this._textValue.TabIndex = 2;
		this._selectOperator.FormattingEnabled = true;
		this._selectOperator.Location = new System.Drawing.Point(102, 45);
		this._selectOperator.Name = "_selectOperator";
		this._selectOperator.Size = new System.Drawing.Size(142, 21);
		this._selectOperator.TabIndex = 3;
		this._ruleGroup.Controls.Add(this.label2);
		this._ruleGroup.Controls.Add(this._textName);
		this._ruleGroup.Controls.Add(this._selectOperator);
		this._ruleGroup.Controls.Add(this.label1);
		this._ruleGroup.Controls.Add(this._textValue);
		this._ruleGroup.Location = new System.Drawing.Point(12, 12);
		this._ruleGroup.Name = "_ruleGroup";
		this._ruleGroup.Size = new System.Drawing.Size(250, 98);
		this._ruleGroup.TabIndex = 4;
		this._ruleGroup.TabStop = false;
		this._ruleGroup.Text = "Rule";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 75);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(59, 13);
		this.label2.TabIndex = 5;
		this.label2.Text = "Tag Value:";
		this._buttonOK.Location = new System.Drawing.Point(186, 116);
		this._buttonOK.Name = "_buttonOK";
		this._buttonOK.Size = new System.Drawing.Size(75, 23);
		this._buttonOK.TabIndex = 5;
		this._buttonOK.Text = "OK";
		this._buttonOK.UseVisualStyleBackColor = true;
		this._buttonOK.Click += new System.EventHandler(_buttonOK_Click);
		this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._buttonCancel.Location = new System.Drawing.Point(105, 116);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(75, 23);
		this._buttonCancel.TabIndex = 6;
		this._buttonCancel.Text = "Cancel";
		this._buttonCancel.UseVisualStyleBackColor = true;
		base.AcceptButton = this._buttonOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this._buttonCancel;
		base.ClientSize = new System.Drawing.Size(273, 151);
		base.Controls.Add(this._buttonCancel);
		base.Controls.Add(this._buttonOK);
		base.Controls.Add(this._ruleGroup);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "StringRuleForm";
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Edit Value Rule";
		base.TopMost = true;
		this._ruleGroup.ResumeLayout(false);
		this._ruleGroup.PerformLayout();
		base.ResumeLayout(false);
	}
}
