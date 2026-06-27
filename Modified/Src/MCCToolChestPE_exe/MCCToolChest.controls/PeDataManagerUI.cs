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

	private Button _deleteButton;

	private Button _renameButton;

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
		_deleteButton = new Button
		{
			Text = "Delete",
			Location = new Point(392, 8),
			Size = new Size(90, 28)
		};
		_deleteButton.Click += DeleteButtonClick;
		_renameButton = new Button
		{
			Text = "Rename",
			Location = new Point(488, 8),
			Size = new Size(90, 28)
		};
		_renameButton.Click += RenameButtonClick;
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
		panel.Controls.Add(_deleteButton);
		panel.Controls.Add(_renameButton);
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

	private void DeleteButtonClick(object sender, EventArgs e)
	{
		if (_listView.SelectedItems.Count == 0)
		{
			MessageBox.Show(FindForm(), "Select one or more entries to delete.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}
		string typeName = (_kind == PeManagedDataKind.Structure) ? "structure(s)" : "tickingarea(s)";
		if (MessageBox.Show(FindForm(), "Delete selected " + typeName + " from the world staging data?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
		{
			return;
		}
		List<string> deletedKeys = new List<string>();
		List<ListViewItem> selectedItems = new List<ListViewItem>();
		foreach (ListViewItem selectedItem in _listView.SelectedItems)
		{
			selectedItems.Add(selectedItem);
		}
		foreach (ListViewItem selectedItem in selectedItems)
		{
			if (selectedItem.Tag is PeManagedDataEntry entry && PeLdbDataHelper.DeleteEntry(Working.T92StMGt1p4(), entry.LdbKey, _treeView))
			{
				deletedKeys.Add(entry.LdbKey);
			}
		}
		if (deletedKeys.Count > 0)
		{
			OnEntriesChanged(deletedKeys);
			ReloadList();
		}
	}

	private void RenameButtonClick(object sender, EventArgs e)
	{
		if (_listView.SelectedItems.Count != 1 || !(_listView.SelectedItems[0].Tag is PeManagedDataEntry entry))
		{
			MessageBox.Show(FindForm(), "Select exactly one entry to rename.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}
		using Form form = new Form
		{
			Text = (_kind == PeManagedDataKind.Structure) ? "Rename Structure" : "Rename Tickingarea",
			FormBorderStyle = FormBorderStyle.FixedDialog,
			StartPosition = FormStartPosition.CenterParent,
			ClientSize = new Size(460, 120),
			MaximizeBox = false,
			MinimizeBox = false
		};
		Label label = new Label
		{
			Text = "LDB key:",
			Location = new Point(12, 16),
			AutoSize = true
		};
		TextBox textBox = new TextBox
		{
			Location = new Point(12, 40),
			Width = 430,
			Text = entry.LdbKey
		};
		Button button = new Button
		{
			Text = "Rename",
			Location = new Point(286, 72),
			Size = new Size(75, 28)
		};
		Button button2 = new Button
		{
			Text = "Cancel",
			DialogResult = DialogResult.Cancel,
			Location = new Point(367, 72),
			Size = new Size(75, 28)
		};
		button.Click += delegate
		{
			form.DialogResult = DialogResult.OK;
		};
		form.Controls.Add(label);
		form.Controls.Add(textBox);
		form.Controls.Add(button);
		form.Controls.Add(button2);
		form.CancelButton = button2;
		form.AcceptButton = button;
		if (form.ShowDialog(FindForm()) != DialogResult.OK)
		{
			return;
		}
		string newKey = textBox.Text.Trim();
		if (string.IsNullOrWhiteSpace(newKey) || string.Equals(newKey, entry.LdbKey, StringComparison.Ordinal))
		{
			return;
		}
		string oldKey = entry.LdbKey;
		if (!PeLdbDataHelper.RenameEntry(Working.T92StMGt1p4(), oldKey, newKey, _treeView, _kind))
		{
			MessageBox.Show(FindForm(), "Could not rename entry. The new key may already exist or the file is missing.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}
		OnEntriesChanged(new List<string> { newKey });
		SelectedLdbKey = newKey;
		ReloadList();
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
				ClientSize = new Size(360, 210),
				MaximizeBox = false,
				MinimizeBox = false
			};
			RadioButton manualRadio = new RadioButton
			{
				Text = "Manual name",
				Location = new Point(16, 16),
				AutoSize = true,
				Checked = true
			};
			RadioButton autoRadio = new RadioButton
			{
				Text = "Auto-generated ID",
				Location = new Point(140, 16),
				AutoSize = true
			};
			TextBox keyTextBox = new TextBox
			{
				Location = new Point(16, 44),
				Width = 320,
				Text = PeTreeTags.TickingareaPrefix
			};
			manualRadio.CheckedChanged += delegate
			{
				keyTextBox.Enabled = manualRadio.Checked;
			};
			autoRadio.CheckedChanged += delegate
			{
				keyTextBox.Enabled = manualRadio.Checked;
			};
			Button circleButton = new Button
			{
				Text = "Circular area",
				Location = new Point(16, 120),
				Size = new Size(110, 32)
			};
			Button boxButton = new Button
			{
				Text = "Box area",
				Location = new Point(140, 120),
				Size = new Size(110, 32)
			};
			Button cancelButton = new Button
			{
				Text = "Cancel",
				DialogResult = DialogResult.Cancel,
				Location = new Point(264, 120),
				Size = new Size(72, 32)
			};
			bool? circle = null;
			circleButton.Click += delegate
			{
				circle = true;
				form.DialogResult = DialogResult.OK;
			};
			boxButton.Click += delegate
			{
				circle = false;
				form.DialogResult = DialogResult.OK;
			};
			form.Controls.Add(manualRadio);
			form.Controls.Add(autoRadio);
			form.Controls.Add(keyTextBox);
			form.Controls.Add(circleButton);
			form.Controls.Add(boxButton);
			form.Controls.Add(cancelButton);
			form.CancelButton = cancelButton;
			if (form.ShowDialog(FindForm()) != DialogResult.OK || !circle.HasValue)
			{
				return;
			}
			string keyOverride = manualRadio.Checked ? keyTextBox.Text : null;
			List<string> keys = PeLdbDataHelper.AddEmptyEntry(Working.T92StMGt1p4(), _kind, circle.Value, _treeView, ldbKeyOverride: keyOverride);
			if (keys.Count > 0)
			{
				OnEntriesChanged(keys);
				ReloadList();
			}
			return;
		}
		using Form form2 = new Form
		{
			Text = "New structure",
			FormBorderStyle = FormBorderStyle.FixedDialog,
			StartPosition = FormStartPosition.CenterParent,
			ClientSize = new Size(360, 120),
			MaximizeBox = false,
			MinimizeBox = false
		};
		Label label = new Label
		{
			Text = "Structure LDB key:",
			Location = new Point(16, 16),
			AutoSize = true
		};
		TextBox keyTextBox2 = new TextBox
		{
			Location = new Point(16, 36),
			Width = 320,
			Text = PeTreeTags.StructureTemplatePrefix + "mystructure:"
		};
		Button okButton = new Button
		{
			Text = "Create",
			DialogResult = DialogResult.OK,
			Location = new Point(184, 72),
			Size = new Size(72, 28)
		};
		Button cancelButton2 = new Button
		{
			Text = "Cancel",
			DialogResult = DialogResult.Cancel,
			Location = new Point(264, 72),
			Size = new Size(72, 28)
		};
		form2.Controls.Add(label);
		form2.Controls.Add(keyTextBox2);
		form2.Controls.Add(okButton);
		form2.Controls.Add(cancelButton2);
		form2.AcceptButton = okButton;
		form2.CancelButton = cancelButton2;
		if (form2.ShowDialog(FindForm()) != DialogResult.OK)
		{
			return;
		}
		List<string> keys2 = PeLdbDataHelper.AddEmptyEntry(Working.T92StMGt1p4(), _kind, circleTickingarea: false, _treeView, ldbKeyOverride: keyTextBox2.Text);
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
