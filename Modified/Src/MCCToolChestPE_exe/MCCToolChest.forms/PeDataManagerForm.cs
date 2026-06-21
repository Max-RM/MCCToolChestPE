using System;
using System.Drawing;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.model;
using MCCToolChest.utils;

namespace MCCToolChest.forms;

public class PeDataManagerForm : Form
{
	private readonly PeManagedDataKind _kind;

	private readonly TreeView _treeView;

	private readonly bool _allowAdd;

	private readonly string _selectedLdbKey;

	private PeDataManagerUI _managerUi;

	public event EventHandler<PeDataEntriesChangedEventArgs> EntriesChanged;

	public PeDataManagerForm(PeManagedDataKind kind, TreeView treeView, bool allowAdd, string selectedLdbKey = null)
	{
		_kind = kind;
		_treeView = treeView;
		_allowAdd = allowAdd;
		_selectedLdbKey = selectedLdbKey;
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		_managerUi = new PeDataManagerUI(_kind);
		SuspendLayout();
		_managerUi.Dock = DockStyle.Fill;
		_managerUi.EntriesChanged += ManagerUiEntriesChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(720, 560);
		base.Controls.Add(_managerUi);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = (_kind == PeManagedDataKind.Structure) ? "Structure Manager" : "Tickingarea Manager";
		Load += FormLoad;
		ResumeLayout(performLayout: false);
	}

	private void FormLoad(object sender, EventArgs e)
	{
		_managerUi.Initialize(_treeView, _allowAdd, _selectedLdbKey);
	}

	private void ManagerUiEntriesChanged(object sender, PeDataEntriesChangedEventArgs e)
	{
		EntriesChanged?.Invoke(this, e);
	}
}
