using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.utils;

namespace MCCToolChest.controls;

public class PeDataManagerUI : UserControl
{
	private readonly PeManagedDataKind _kind;

	private TreeView _treeView;

	private ListView _listView;

	private Button _exportButton;

	private Button _browseImportButton;

	private Button _confirmImportButton;

	private Button _addButton;

	private TextBox _importKeyTextBox;

	private Label _importKeyLabel;

	private Label _multiImportWarningLabel;

	private Label _pendingImportLabel;

	private string[] _pendingImportFiles;

	public event EventHandler<PeDataEntriesChangedEventArgs> EntriesChanged;

	public bool AllowAdd { get; set; }

	public string SelectedLdbKey { get; set; }

	public PeDataManagerUI(PeManagedDataKind kind)
	{
		_kind = kind;
		InitializeComponent();
	}

	public void Initialize(TreeView treeView, bool allowAdd, string selectedLdbKey = null)
	{
		_treeView = treeView;
		AllowAdd = allowAdd;
		SelectedLdbKey = selectedLdbKey;
		_addButton.Visible = allowAdd;
		_addButton.Enabled = allowAdd;
		_importKeyLabel.Text = (_kind == PeManagedDataKind.Structure) ? "Structure LDB key:" : "Tickingarea LDB key:";
		ClearPendingImport();
		if (!string.IsNullOrWhiteSpace(selectedLdbKey))
		{
			_importKeyTextBox.Text = selectedLdbKey;
		}
		else if (_kind == PeManagedDataKind.Structure)
		{
			_importKeyTextBox.Text = PeTreeTags.StructureTemplatePrefix + "mystructure:";
		}
		ReloadList();
	}

	public void ReloadList()
	{
		_listView.Items.Clear();
		if (string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			return;
		}
		List<PeManagedDataEntry> list = PeLdbDataHelper.ListEntries(Working.T92StMGt1p4(), _kind, _treeView);
		foreach (PeManagedDataEntry item in list)
		{
			ListViewItem listViewItem = new ListViewItem(item.DisplayName)
			{
				Tag = item
			};
			_listView.Items.Add(listViewItem);
			if (!string.IsNullOrWhiteSpace(SelectedLdbKey) && string.Equals(item.LdbKey, SelectedLdbKey, StringComparison.Ordinal))
			{
				listViewItem.Selected = true;
				listViewItem.Focused = true;
			}
		}
		if (_listView.SelectedItems.Count == 0 && _listView.Items.Count > 0)
		{
			_listView.Items[0].Selected = true;
		}
	}

	private void InitializeComponent()
	{
		_listView = new ListView
		{
			Dock = DockStyle.Fill,
			FullRowSelect = true,
			HideSelection = false,
			View = View.List,
			MultiSelect = true
		};
		Panel panel = new Panel
		{
			Dock = DockStyle.Top,
			Height = 168
		};
		_exportButton = new Button
		{
			Text = "Export",
			Location = new Point(8, 8),
			Size = new Size(90, 28)
		};
		_exportButton.Click += ExportButtonClick;
		_browseImportButton = new Button
		{
			Text = "Import",
			Location = new Point(104, 8),
			Size = new Size(90, 28)
		};
		_browseImportButton.Click += BrowseImportButtonClick;
		_confirmImportButton = new Button
		{
			Text = "Apply",
			Location = new Point(200, 8),
			Size = new Size(90, 28),
			Enabled = false
		};
		_confirmImportButton.Click += ConfirmImportButtonClick;
		_addButton = new Button
		{
			Text = "Add New",
			Location = new Point(296, 8),
			Size = new Size(90, 28),
			Visible = false
		};
		_addButton.Click += AddButtonClick;
		_importKeyLabel = new Label
		{
			Text = "LDB key:",
			Location = new Point(8, 44),
			AutoSize = true
		};
		_importKeyTextBox = new TextBox
		{
			Location = new Point(8, 64),
			Width = 500,
			Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
		};
		_pendingImportLabel = new Label
		{
			Location = new Point(8, 92),
			AutoSize = true,
			ForeColor = SystemColors.GrayText
		};
		_multiImportWarningLabel = new Label
		{
			Text = "Multiple import: key editing is disabled.",
			Location = new Point(8, 112),
			AutoSize = true,
			ForeColor = SystemColors.GrayText,
			Visible = false
		};
		panel.Controls.Add(_exportButton);
		panel.Controls.Add(_browseImportButton);
		panel.Controls.Add(_confirmImportButton);
		panel.Controls.Add(_addButton);
		panel.Controls.Add(_importKeyLabel);
		panel.Controls.Add(_importKeyTextBox);
		panel.Controls.Add(_pendingImportLabel);
		panel.Controls.Add(_multiImportWarningLabel);
		base.Controls.Add(_listView);
		base.Controls.Add(panel);
	}

	private void ClearPendingImport()
	{
		_pendingImportFiles = null;
		_confirmImportButton.Enabled = false;
		_importKeyTextBox.Enabled = true;
		_multiImportWarningLabel.Visible = false;
		_pendingImportLabel.Text = "No files selected for import.";
	}

	private void BrowseImportButtonClick(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Multiselect = true,
			Filter = (_kind == PeManagedDataKind.Structure) ? "Structure files (*.mcstructure)|*.mcstructure|All files (*.*)|*.*" : "NBT files (*.nbt)|*.nbt|All files (*.*)|*.*",
			DefaultExt = (_kind == PeManagedDataKind.Structure) ? "mcstructure" : "nbt"
		};
		if (openFileDialog.ShowDialog(FindForm()) != DialogResult.OK)
		{
			return;
		}
		_pendingImportFiles = openFileDialog.FileNames;
		bool multi = _pendingImportFiles.Length > 1;
		_confirmImportButton.Enabled = true;
		_importKeyTextBox.Enabled = !multi;
		_multiImportWarningLabel.Visible = multi;
		_pendingImportLabel.Text = (multi ? ("Selected " + _pendingImportFiles.Length + " files.") : ("Selected: " + Path.GetFileName(_pendingImportFiles[0])));
		if (!multi)
		{
			_importKeyTextBox.Text = PeLdbDataHelper.SuggestImportKey(_pendingImportFiles[0], _kind);
		}
	}

	private void ConfirmImportButtonClick(object sender, EventArgs e)
	{
		if (_pendingImportFiles == null || _pendingImportFiles.Length == 0)
		{
			return;
		}
		bool multi = _pendingImportFiles.Length > 1;
		string singleKey = multi ? null : _importKeyTextBox.Text;
		List<string> importedKeys = PeLdbDataHelper.ImportFiles(Working.T92StMGt1p4(), _kind, _pendingImportFiles, singleKey, _treeView);
		if (importedKeys.Count > 0)
		{
			OnEntriesChanged(importedKeys);
			ReloadList();
			ClearPendingImport();
		}
	}

	private void ExportButtonClick(object sender, EventArgs e)
	{
		if (_listView.SelectedItems.Count == 0)
		{
			MessageBox.Show(FindForm(), "Select one or more entries to export.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}
		if (_listView.SelectedItems.Count == 1 && _listView.SelectedItems[0].Tag is PeManagedDataEntry peManagedDataEntry)
		{
			string fileName = (_kind == PeManagedDataKind.Structure) ? PeLdbDataHelper.StructureExportFileName(peManagedDataEntry.LdbKey) : PeLdbDataHelper.TickingareaExportFileName(peManagedDataEntry.LdbKey, peManagedDataEntry.StagingFilePath);
			using SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				FileName = fileName,
				Filter = (_kind == PeManagedDataKind.Structure) ? "Structure files (*.mcstructure)|*.mcstructure|All files (*.*)|*.*" : "NBT files (*.nbt)|*.nbt|All files (*.*)|*.*",
				DefaultExt = (_kind == PeManagedDataKind.Structure) ? "mcstructure" : "nbt"
			};
			if (saveFileDialog.ShowDialog(FindForm()) == DialogResult.OK)
			{
				PeLdbDataHelper.ExportEntry(peManagedDataEntry, _kind, saveFileDialog.FileName);
			}
			return;
		}
		using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
		{
			Description = "Choose export folder"
		};
		if (folderBrowserDialog.ShowDialog(FindForm()) != DialogResult.OK)
		{
			return;
		}
		foreach (ListViewItem selectedItem in _listView.SelectedItems)
		{
			if (!(selectedItem.Tag is PeManagedDataEntry entry))
			{
				continue;
			}
			string fileName2 = (_kind == PeManagedDataKind.Structure) ? PeLdbDataHelper.StructureExportFileName(entry.LdbKey) : PeLdbDataHelper.TickingareaExportFileName(entry.LdbKey, entry.StagingFilePath);
			string targetFilePath = Path.Combine(folderBrowserDialog.SelectedPath, fileName2);
			PeLdbDataHelper.ExportEntry(entry, _kind, targetFilePath);
		}
	}

	private void AddButtonClick(object sender, EventArgs e)
	{
		if (_kind == PeManagedDataKind.Tickingarea)
		{
			using Form form = new Form
			{
				Text = "New tickingarea",
				FormBorderStyle = FormBorderStyle.FixedDialog,
				StartPosition = FormStartPosition.CenterParent,
				ClientSize = new Size(280, 120),
				MaximizeBox = false,
				MinimizeBox = false
			};
			Button circleButton = new Button
			{
				Text = "Circular area",
				Location = new Point(20, 20),
				Size = new Size(110, 32)
			};
			Button boxButton = new Button
			{
				Text = "Box area",
				Location = new Point(150, 20),
				Size = new Size(110, 32)
			};
			circleButton.Click += delegate
			{
				form.DialogResult = DialogResult.Yes;
			};
			boxButton.Click += delegate
			{
				form.DialogResult = DialogResult.No;
			};
			form.Controls.Add(circleButton);
			form.Controls.Add(boxButton);
			if (form.ShowDialog(FindForm()) == DialogResult.Cancel)
			{
				return;
			}
			bool circle = form.DialogResult == DialogResult.Yes;
			List<string> keys = PeLdbDataHelper.AddEmptyEntry(Working.T92StMGt1p4(), _kind, circle, _treeView);
			if (keys.Count > 0)
			{
				OnEntriesChanged(keys);
				ReloadList();
			}
			return;
		}
		List<string> keys2 = PeLdbDataHelper.AddEmptyEntry(Working.T92StMGt1p4(), _kind, circleTickingarea: false, _treeView);
		if (keys2.Count > 0)
		{
			OnEntriesChanged(keys2);
			ReloadList();
		}
	}

	protected virtual void OnEntriesChanged(List<string> importedKeys)
	{
		EntriesChanged?.Invoke(this, new PeDataEntriesChangedEventArgs(importedKeys));
	}
}

public class PeDataEntriesChangedEventArgs : EventArgs
{
	public List<string> ImportedKeys { get; }

	public PeDataEntriesChangedEventArgs(List<string> importedKeys)
	{
		ImportedKeys = importedKeys ?? new List<string>();
	}
}
