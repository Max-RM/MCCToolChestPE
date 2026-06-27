using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.utils;

namespace MCCToolChest.forms;

public class FindLdbKeyEntry : Form
{
	private readonly string _stagingRoot;

	private ListView _resultsList;

	private TextBox _searchTextBox;

	private Label _statusLabel;

	public string SelectedLdbKey { get; private set; }

	public FindLdbKeyEntry(string stagingRoot)
	{
		_stagingRoot = stagingRoot;
		InitializeComponent();
		ReloadResults();
	}

	private void InitializeComponent()
	{
		Text = "Find LDB Key";
		FormBorderStyle = FormBorderStyle.Sizable;
		StartPosition = FormStartPosition.CenterParent;
		ClientSize = new Size(560, 420);
		MinimumSize = new Size(420, 320);
		Label label = new Label
		{
			Text = "LDB key prefix or name:",
			Location = new Point(12, 12),
			AutoSize = true
		};
		_searchTextBox = new TextBox
		{
			Location = new Point(12, 32),
			Width = 520,
			Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
		};
		_searchTextBox.TextChanged += SearchTextChanged;
		_statusLabel = new Label
		{
			Location = new Point(12, 58),
			AutoSize = true,
			ForeColor = SystemColors.GrayText
		};
		_resultsList = new ListView
		{
			Location = new Point(12, 82),
			Size = new Size(520, 290),
			Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
			View = View.List,
			FullRowSelect = true,
			HideSelection = false
		};
		_resultsList.DoubleClick += ResultsListDoubleClick;
		Button button = new Button
		{
			Text = "Go To",
			Location = new Point(376, 382),
			Size = new Size(75, 28),
			Anchor = AnchorStyles.Bottom | AnchorStyles.Right
		};
		button.Click += GoToClick;
		Button button2 = new Button
		{
			Text = "Close",
			DialogResult = DialogResult.Cancel,
			Location = new Point(457, 382),
			Size = new Size(75, 28),
			Anchor = AnchorStyles.Bottom | AnchorStyles.Right
		};
		base.Controls.Add(label);
		base.Controls.Add(_searchTextBox);
		base.Controls.Add(_statusLabel);
		base.Controls.Add(_resultsList);
		base.Controls.Add(button);
		base.Controls.Add(button2);
		base.AcceptButton = button;
		base.CancelButton = button2;
	}

	private void SearchTextChanged(object sender, EventArgs e)
	{
		ReloadResults();
	}

	private void ReloadResults()
	{
		_resultsList.Items.Clear();
		List<string> keys = ListMatchingKeys(_searchTextBox.Text);
		foreach (string item in keys)
		{
			_resultsList.Items.Add(new ListViewItem(FileUtils.FormatLdbKeyForDisplay(item))
			{
				Tag = item
			});
		}
		_statusLabel.Text = keys.Count + " matching key(s)";
		if (_resultsList.Items.Count > 0)
		{
			_resultsList.Items[0].Selected = true;
		}
	}

	private List<string> ListMatchingKeys(string filter)
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		string dataFolder = PeStagingPaths.GetDataFolderPath(_stagingRoot);
		if (Directory.Exists(dataFolder))
		{
			string[] files = Directory.GetFiles(dataFolder, "*" + PeStagingPaths.DataFileExtension);
			foreach (string path in files)
			{
				string item = FileUtils.DecodeLdbKeyFileName(Path.GetFileNameWithoutExtension(path));
				hashSet.Add(item);
			}
		}
		List<string> list = hashSet.ToList();
		list.Sort(StringComparer.OrdinalIgnoreCase);
		if (string.IsNullOrWhiteSpace(filter))
		{
			return list;
		}
		return list.Where((string key) => key.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
	}

	private void GoToClick(object sender, EventArgs e)
	{
		SelectCurrentResult();
	}

	private void ResultsListDoubleClick(object sender, EventArgs e)
	{
		SelectCurrentResult();
	}

	private void SelectCurrentResult()
	{
		if (_resultsList.SelectedItems.Count == 0)
		{
			return;
		}
		SelectedLdbKey = _resultsList.SelectedItems[0].Tag as string;
		base.DialogResult = DialogResult.OK;
		Close();
	}
}
