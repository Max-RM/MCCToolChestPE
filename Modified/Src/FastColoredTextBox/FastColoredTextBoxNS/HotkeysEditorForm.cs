using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class HotkeysEditorForm : Form
{
	private BindingList<HotkeyWrapper> wrappers = new BindingList<HotkeyWrapper>();

	private IContainer components = null;

	private DataGridView dgv;

	private Button btAdd;

	private Button btRemove;

	private Button btCancel;

	private Button btOk;

	private Label label1;

	private Button btResore;

	private DataGridViewComboBoxColumn cbModifiers;

	private DataGridViewComboBoxColumn cbKey;

	private DataGridViewComboBoxColumn cbAction;

	public HotkeysEditorForm(HotkeysMapping hotkeys)
	{
		InitializeComponent();
		BuildWrappers(hotkeys);
		dgv.DataSource = wrappers;
	}

	private int CompereKeys(Keys key1, Keys key2)
	{
		int num = ((int)(key1 & (Keys.F16 | Keys.F17))).CompareTo((int)(key2 & (Keys.F16 | Keys.F17)));
		if (num == 0)
		{
			num = key1.CompareTo(key2);
		}
		return num;
	}

	private void BuildWrappers(HotkeysMapping hotkeys)
	{
		List<Keys> list = new List<Keys>(hotkeys.Keys);
		list.Sort(CompereKeys);
		wrappers.Clear();
		foreach (Keys item in list)
		{
			wrappers.Add(new HotkeyWrapper(item, hotkeys[item]));
		}
	}

	public HotkeysMapping GetHotkeys()
	{
		HotkeysMapping hotkeysMapping = new HotkeysMapping();
		foreach (HotkeyWrapper wrapper in wrappers)
		{
			hotkeysMapping[wrapper.ToKeyData()] = wrapper.Action;
		}
		return hotkeysMapping;
	}

	private void btAdd_Click(object sender, EventArgs e)
	{
		wrappers.Add(new HotkeyWrapper(Keys.None, FCTBAction.None));
	}

	private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		DataGridViewComboBoxCell dataGridViewComboBoxCell = dgv[0, e.RowIndex] as DataGridViewComboBoxCell;
		if (dataGridViewComboBoxCell.Items.Count == 0)
		{
			string[] array = new string[8] { "", "Ctrl", "Ctrl + Shift", "Ctrl + Alt", "Shift", "Shift + Alt", "Alt", "Ctrl + Shift + Alt" };
			foreach (string item in array)
			{
				dataGridViewComboBoxCell.Items.Add(item);
			}
		}
		dataGridViewComboBoxCell = dgv[1, e.RowIndex] as DataGridViewComboBoxCell;
		if (dataGridViewComboBoxCell.Items.Count == 0)
		{
			foreach (object value in Enum.GetValues(typeof(Keys)))
			{
				dataGridViewComboBoxCell.Items.Add(value);
			}
		}
		dataGridViewComboBoxCell = dgv[2, e.RowIndex] as DataGridViewComboBoxCell;
		if (dataGridViewComboBoxCell.Items.Count != 0)
		{
			return;
		}
		foreach (object value2 in Enum.GetValues(typeof(FCTBAction)))
		{
			dataGridViewComboBoxCell.Items.Add(value2);
		}
	}

	private void btResore_Click(object sender, EventArgs e)
	{
		HotkeysMapping hotkeysMapping = new HotkeysMapping();
		hotkeysMapping.InitDefault();
		BuildWrappers(hotkeysMapping);
	}

	private void btRemove_Click(object sender, EventArgs e)
	{
		for (int num = dgv.RowCount - 1; num >= 0; num--)
		{
			if (dgv.Rows[num].Selected)
			{
				dgv.Rows.RemoveAt(num);
			}
		}
	}

	private void HotkeysEditorForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			string unAssignedActions = GetUnAssignedActions();
			if (!string.IsNullOrEmpty(unAssignedActions) && MessageBox.Show("Some actions are not assigned!\r\nActions: " + unAssignedActions + "\r\nPress Yes to save and exit, press No to continue editing", "Some actions is not assigned", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
			{
				e.Cancel = true;
			}
		}
	}

	private string GetUnAssignedActions()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Dictionary<FCTBAction, FCTBAction> dictionary = new Dictionary<FCTBAction, FCTBAction>();
		foreach (HotkeyWrapper wrapper in wrappers)
		{
			dictionary[wrapper.Action] = wrapper.Action;
		}
		foreach (object value in Enum.GetValues(typeof(FCTBAction)))
		{
			if ((FCTBAction)value != FCTBAction.None && !((FCTBAction)value/*cast due to constrained. prefix*/).ToString().StartsWith("CustomAction") && !dictionary.ContainsKey((FCTBAction)value))
			{
				stringBuilder.Append(string.Concat(value, ", "));
			}
		}
		return stringBuilder.ToString().TrimEnd(' ', ',');
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		this.dgv = new System.Windows.Forms.DataGridView();
		this.cbModifiers = new System.Windows.Forms.DataGridViewComboBoxColumn();
		this.cbKey = new System.Windows.Forms.DataGridViewComboBoxColumn();
		this.cbAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
		this.btAdd = new System.Windows.Forms.Button();
		this.btRemove = new System.Windows.Forms.Button();
		this.btCancel = new System.Windows.Forms.Button();
		this.btOk = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.btResore = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.dgv).BeginInit();
		base.SuspendLayout();
		this.dgv.AllowUserToAddRows = false;
		this.dgv.AllowUserToDeleteRows = false;
		this.dgv.AllowUserToResizeColumns = false;
		this.dgv.AllowUserToResizeRows = false;
		this.dgv.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
		this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv.Columns.AddRange(this.cbModifiers, this.cbKey, this.cbAction);
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Window;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dgv.DefaultCellStyle = dataGridViewCellStyle;
		this.dgv.GridColor = System.Drawing.SystemColors.Control;
		this.dgv.Location = new System.Drawing.Point(12, 28);
		this.dgv.Name = "dgv";
		this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		this.dgv.RowHeadersVisible = false;
		this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgv.Size = new System.Drawing.Size(525, 278);
		this.dgv.TabIndex = 0;
		this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(dgv_RowsAdded);
		this.cbModifiers.DataPropertyName = "Modifiers";
		this.cbModifiers.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
		this.cbModifiers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cbModifiers.HeaderText = "Modifiers";
		this.cbModifiers.Name = "cbModifiers";
		this.cbKey.DataPropertyName = "Key";
		this.cbKey.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
		this.cbKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cbKey.HeaderText = "Key";
		this.cbKey.Name = "cbKey";
		this.cbKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.cbKey.Width = 120;
		this.cbAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.cbAction.DataPropertyName = "Action";
		this.cbAction.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
		this.cbAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cbAction.HeaderText = "Action";
		this.cbAction.Name = "cbAction";
		this.btAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btAdd.Location = new System.Drawing.Point(13, 322);
		this.btAdd.Name = "btAdd";
		this.btAdd.Size = new System.Drawing.Size(75, 23);
		this.btAdd.TabIndex = 1;
		this.btAdd.Text = "Add";
		this.btAdd.UseVisualStyleBackColor = true;
		this.btAdd.Click += new System.EventHandler(btAdd_Click);
		this.btRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btRemove.Location = new System.Drawing.Point(103, 322);
		this.btRemove.Name = "btRemove";
		this.btRemove.Size = new System.Drawing.Size(75, 23);
		this.btRemove.TabIndex = 2;
		this.btRemove.Text = "Remove";
		this.btRemove.UseVisualStyleBackColor = true;
		this.btRemove.Click += new System.EventHandler(btRemove_Click);
		this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btCancel.Location = new System.Drawing.Point(460, 322);
		this.btCancel.Name = "btCancel";
		this.btCancel.Size = new System.Drawing.Size(75, 23);
		this.btCancel.TabIndex = 4;
		this.btCancel.Text = "Cancel";
		this.btCancel.UseVisualStyleBackColor = true;
		this.btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btOk.Location = new System.Drawing.Point(379, 322);
		this.btOk.Name = "btOk";
		this.btOk.Size = new System.Drawing.Size(75, 23);
		this.btOk.TabIndex = 3;
		this.btOk.Text = "OK";
		this.btOk.UseVisualStyleBackColor = true;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label1.Location = new System.Drawing.Point(12, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(114, 16);
		this.label1.TabIndex = 5;
		this.label1.Text = "Hotkeys mapping";
		this.btResore.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btResore.Location = new System.Drawing.Point(194, 322);
		this.btResore.Name = "btResore";
		this.btResore.Size = new System.Drawing.Size(105, 23);
		this.btResore.TabIndex = 6;
		this.btResore.Text = "Restore default";
		this.btResore.UseVisualStyleBackColor = true;
		this.btResore.Click += new System.EventHandler(btResore_Click);
		base.AcceptButton = this.btOk;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.btCancel;
		base.ClientSize = new System.Drawing.Size(549, 357);
		base.Controls.Add(this.btResore);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.btCancel);
		base.Controls.Add(this.btOk);
		base.Controls.Add(this.btRemove);
		base.Controls.Add(this.btAdd);
		base.Controls.Add(this.dgv);
		this.MaximumSize = new System.Drawing.Size(565, 700);
		this.MinimumSize = new System.Drawing.Size(565, 395);
		base.Name = "HotkeysEditorForm";
		base.ShowIcon = false;
		this.Text = "Hotkeys Editor";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(HotkeysEditorForm_FormClosing);
		((System.ComponentModel.ISupportInitialize)this.dgv).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
