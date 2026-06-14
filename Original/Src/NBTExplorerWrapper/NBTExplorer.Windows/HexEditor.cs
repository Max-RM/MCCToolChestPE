using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace NBTExplorer.Windows;

public class HexEditor : Form
{
	private abstract class EditView
	{
		public int BytesPerElem { get; set; }

		public StatusStrip StatusBar { get; set; }

		public abstract TabPage TabPage { get; }

		public event EventHandler Modified;

		protected EditView(StatusStrip statusBar, int bytesPerElem)
		{
			BytesPerElem = bytesPerElem;
			StatusBar = statusBar;
		}

		public abstract void Initialize();

		public abstract void Activate();

		public abstract byte[] GetRawData();

		public abstract void SetRawData(byte[] data);

		protected virtual void OnModified()
		{
			this.Modified?.Invoke(this, EventArgs.Empty);
		}
	}

	private class TextView(StatusStrip statusBar, int bytesPerElem) : EditView(statusBar, bytesPerElem)
	{
		private TabPage _tabPage;

		private TextBox _textBox;

		private ToolStripStatusLabel _elementLabel;

		private ToolStripStatusLabel _spaceLabel;

		private Dictionary<int, int> _elemIndex = new Dictionary<int, int>();

		public override TabPage TabPage => _tabPage;

		public override void Initialize()
		{
			_textBox = new TextBox
			{
				Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right),
				Font = new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Point, 0),
				Location = new Point(0, 0),
				Margin = new Padding(0),
				Multiline = true,
				ScrollBars = ScrollBars.Vertical,
				Size = new Size(500, 263),
				TabIndex = 0,
				MaxLength = 0
			};
			_tabPage = new TabPage
			{
				Location = new Point(4, 22),
				Padding = new Padding(3),
				Size = new Size(500, 263),
				TabIndex = 1,
				Text = "Text View",
				UseVisualStyleBackColor = true
			};
			_tabPage.Controls.Add(_textBox);
			_textBox.TextChanged += delegate
			{
				OnModified();
				RebuildElementIndex();
			};
			_textBox.PreviewKeyDown += delegate(object s, PreviewKeyDownEventArgs e)
			{
				e.IsInputKey = true;
			};
			_textBox.KeyUp += delegate
			{
				UpdateElementLabel();
			};
			_textBox.MouseClick += delegate
			{
				UpdateElementLabel();
			};
			InitializeStatusBar();
		}

		private void InitializeStatusBar()
		{
			_elementLabel = new ToolStripStatusLabel
			{
				Size = new Size(100, 17),
				Text = "Element 0",
				TextAlign = ContentAlignment.MiddleLeft
			};
			_spaceLabel = new ToolStripStatusLabel
			{
				Spring = true
			};
		}

		public override void Activate()
		{
			base.StatusBar.Items.Clear();
			base.StatusBar.Items.AddRange(new ToolStripItem[2] { _elementLabel, _spaceLabel });
		}

		public override byte[] GetRawData()
		{
			return TextToRaw(_textBox.Text, base.BytesPerElem);
		}

		public override void SetRawData(byte[] data)
		{
			_textBox.Text = RawToText(data, base.BytesPerElem);
			RebuildElementIndex();
		}

		private void RebuildElementIndex()
		{
			_elemIndex.Clear();
			int num = 0;
			string text = _textBox.Text;
			bool flag = true;
			for (int i = 0; i < text.Length; i++)
			{
				bool flag2 = IsWhiteSpace(text[i]);
				if (flag && !flag2)
				{
					_elemIndex[i] = num++;
				}
				flag = flag2;
			}
		}

		private bool IsWhiteSpace(char c)
		{
			if (c != ' ' && c != '\n' && c != '\r')
			{
				return c == '\t';
			}
			return true;
		}

		private void UpdateElementLabel()
		{
			int num = _textBox.SelectionStart;
			int value = 0;
			while (num >= 0 && !_elemIndex.TryGetValue(num, out value))
			{
				num--;
			}
			_elementLabel.Text = "Element " + value;
		}
	}

	private class HexView : EditView
	{
		private TabPage _tabPage;

		private HexBox _hexBox;

		private ToolStripStatusLabel _positionLabel;

		private ToolStripStatusLabel _elementLabel;

		private ToolStripStatusLabel _spaceLabel;

		private ToolStripStatusLabel _insertLabel;

		private DynamicByteProvider _byteProvider;

		public override TabPage TabPage => _tabPage;

		public HexView(StatusStrip statusBar, int bytesPerElem)
			: base(statusBar, bytesPerElem)
		{
		}

		public override void Initialize()
		{
			_byteProvider = new DynamicByteProvider(new byte[0]);
			_byteProvider.Changed += delegate
			{
				OnModified();
			};
			_hexBox = new HexBox
			{
				Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right),
				Font = new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Point, 0),
				LineInfoForeColor = Color.Empty,
				LineInfoVisible = true,
				Location = new Point(0, 0),
				ShadowSelectionColor = Color.FromArgb(100, 60, 188, 255),
				Size = new Size(500, 263),
				TabIndex = 0,
				VScrollBarVisible = true,
				ByteProvider = _byteProvider
			};
			_tabPage = new TabPage
			{
				Location = new Point(4, 22),
				Padding = new Padding(3),
				Size = new Size(500, 263),
				TabIndex = 0,
				Text = "Hex View",
				UseVisualStyleBackColor = true
			};
			_tabPage.Controls.Add(_hexBox);
			_hexBox.HorizontalByteCountChanged += delegate
			{
				UpdatePosition();
			};
			_hexBox.CurrentLineChanged += delegate
			{
				UpdatePosition();
			};
			_hexBox.CurrentPositionInLineChanged += delegate
			{
				UpdatePosition();
			};
			_hexBox.InsertActiveChanged += delegate
			{
				_insertLabel.Text = (_hexBox.InsertActive ? "Insert" : "Overwrite");
			};
			InitializeStatusBar();
		}

		private void InitializeStatusBar()
		{
			_positionLabel = new ToolStripStatusLabel
			{
				AutoSize = false,
				Size = new Size(100, 17),
				Text = "0000"
			};
			_elementLabel = new ToolStripStatusLabel
			{
				Size = new Size(59, 17),
				Text = "Element 0",
				TextAlign = ContentAlignment.MiddleLeft
			};
			_spaceLabel = new ToolStripStatusLabel
			{
				Size = new Size(300, 17),
				Spring = true
			};
			_insertLabel = new ToolStripStatusLabel
			{
				Size = new Size(58, 17),
				Text = (_hexBox.InsertActive ? "Insert" : "Overwrite")
			};
		}

		public override void Activate()
		{
			base.StatusBar.Items.Clear();
			base.StatusBar.Items.AddRange(new ToolStripItem[4] { _positionLabel, _elementLabel, _spaceLabel, _insertLabel });
			UpdatePosition();
		}

		public override byte[] GetRawData()
		{
			byte[] array = new byte[_byteProvider.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _byteProvider.Bytes[i];
			}
			return array;
		}

		public override void SetRawData(byte[] data)
		{
			_byteProvider = new DynamicByteProvider(data);
			_byteProvider.Changed += delegate
			{
				OnModified();
			};
			_hexBox.ByteProvider = _byteProvider;
		}

		private void UpdatePosition()
		{
			long num = (_hexBox.CurrentLine - 1) * _hexBox.HorizontalByteCount + _hexBox.CurrentPositionInLine - 1;
			_positionLabel.Text = "0x" + num.ToString("X4");
			_elementLabel.Text = "Element " + num / base.BytesPerElem;
		}
	}

	private class FixedByteProvider : DynamicByteProvider
	{
		public FixedByteProvider(byte[] data)
			: base(data)
		{
		}

		public override bool SupportsInsertBytes()
		{
			return false;
		}
	}

	private TabPage _previousPage;

	private int _bytesPerElem;

	private byte[] _data;

	private bool _modified;

	private Dictionary<TabPage, EditView> _views = new Dictionary<TabPage, EditView>();

	private IContainer components;

	private StatusStrip statusStrip1;

	private Button _buttonCancel;

	private Button _buttonOK;

	private Button _buttonImport;

	private Button _buttonExport;

	private TabControl viewTabs;

	public byte[] Data => _data;

	public bool Modified => _modified;

	public HexEditor(string tagName, byte[] data, int bytesPerElem)
	{
		InitializeComponent();
		EditView editView = new TextView(statusStrip1, bytesPerElem);
		editView.Initialize();
		editView.SetRawData(data);
		EventHandler value = delegate
		{
			_modified = true;
		};
		editView.Modified += value;
		_views.Add(editView.TabPage, editView);
		viewTabs.TabPages.Add(editView.TabPage);
		EditView editView2 = null;
		if (!IsMono())
		{
			editView2 = new HexView(statusStrip1, bytesPerElem);
			editView2.Initialize();
			editView2.SetRawData(data);
			editView2.Modified += delegate
			{
				_modified = true;
			};
			_views.Add(editView2.TabPage, editView2);
			viewTabs.TabPages.Add(editView2.TabPage);
		}
		if (bytesPerElem > 1 || IsMono())
		{
			editView.Activate();
			viewTabs.SelectedTab = editView.TabPage;
		}
		else
		{
			editView2.Activate();
			viewTabs.SelectedTab = editView2.TabPage;
		}
		viewTabs.Deselected += delegate(object o, TabControlEventArgs e)
		{
			_previousPage = e.TabPage;
		};
		viewTabs.Selecting += HandleTabChanged;
		Text = "Editing: " + tagName;
		_bytesPerElem = bytesPerElem;
		_data = new byte[data.Length];
		Array.Copy(data, _data, data.Length);
	}

	private bool IsMono()
	{
		return Type.GetType("Mono.Runtime") != null;
	}

	private void HandleTabChanged(object sender, TabControlCancelEventArgs e)
	{
		if (e.Action == TabControlAction.Selecting && e.TabPage != _previousPage)
		{
			EditView editView = _views[_previousPage];
			EditView editView2 = _views[e.TabPage];
			byte[] rawData = editView.GetRawData();
			editView2.SetRawData(rawData);
			editView2.Activate();
		}
	}

	private void Apply()
	{
		EditView editView = _views[viewTabs.SelectedTab];
		_data = editView.GetRawData();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private string RawToText(byte[] data)
	{
		return RawToText(data, _bytesPerElem);
	}

	private static string RawToText(byte[] data, int bytesPerElem)
	{
		return bytesPerElem switch
		{
			1 => RawToText(data, bytesPerElem, 16), 
			2 => RawToText(data, bytesPerElem, 8), 
			4 => RawToText(data, bytesPerElem, 4), 
			8 => RawToText(data, bytesPerElem, 2), 
			_ => RawToText(data, bytesPerElem, 1), 
		};
	}

	private static string RawToText(byte[] data, int bytesPerElem, int elementsPerLine)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < data.Length && data.Length - i >= bytesPerElem; i += bytesPerElem)
		{
			switch (bytesPerElem)
			{
			case 1:
				stringBuilder.Append(((sbyte)data[i]).ToString());
				break;
			case 2:
				stringBuilder.Append(BitConverter.ToInt16(data, i).ToString());
				break;
			case 4:
				stringBuilder.Append(BitConverter.ToInt32(data, i).ToString());
				break;
			case 8:
				stringBuilder.Append(BitConverter.ToInt64(data, i).ToString());
				break;
			}
			if (i / bytesPerElem % elementsPerLine == elementsPerLine - 1)
			{
				stringBuilder.AppendLine();
			}
			else
			{
				stringBuilder.Append("  ");
			}
		}
		return stringBuilder.ToString();
	}

	private byte[] TextToRaw(string text)
	{
		return TextToRaw(text, _bytesPerElem);
	}

	private static byte[] TextToRaw(string text, int bytesPerElem)
	{
		string[] array = text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
		byte[] array2 = new byte[bytesPerElem * array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			int num = i * bytesPerElem;
			switch (bytesPerElem)
			{
			case 1:
			{
				if (sbyte.TryParse(array[i], out var result4))
				{
					array2[num] = (byte)result4;
				}
				break;
			}
			case 2:
			{
				if (short.TryParse(array[i], out var result2))
				{
					byte[] bytes2 = BitConverter.GetBytes(result2);
					Array.Copy(bytes2, 0, array2, num, 2);
				}
				break;
			}
			case 4:
			{
				if (int.TryParse(array[i], out var result3))
				{
					byte[] bytes3 = BitConverter.GetBytes(result3);
					Array.Copy(bytes3, 0, array2, num, 4);
				}
				break;
			}
			case 8:
			{
				if (long.TryParse(array[i], out var result))
				{
					byte[] bytes = BitConverter.GetBytes(result);
					Array.Copy(bytes, 0, array2, num, 8);
				}
				break;
			}
			}
		}
		return array2;
	}

	private void ImportRaw(string path)
	{
		try
		{
			using FileStream fileStream = File.OpenRead(path);
			_data = new byte[fileStream.Length];
			fileStream.Read(_data, 0, (int)fileStream.Length);
			EditView editView = _views[viewTabs.SelectedTab];
			editView.SetRawData(_data);
			_modified = true;
		}
		catch (Exception ex)
		{
			MessageBox.Show("Failed to import data from \"" + path + "\"\n\nException: " + ex.Message);
		}
	}

	private void ImportText(string path)
	{
		try
		{
			using FileStream fileStream = File.OpenRead(path);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, (int)fileStream.Length);
			string text = Encoding.UTF8.GetString(array, 0, array.Length);
			_data = TextToRaw(text);
			EditView editView = _views[viewTabs.SelectedTab];
			editView.SetRawData(_data);
			_modified = true;
		}
		catch (Exception ex)
		{
			MessageBox.Show("Failed to import data from \"" + path + "\"\n\nException: " + ex.Message);
		}
	}

	private void ExportRaw(string path)
	{
		try
		{
			using FileStream fileStream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
			EditView editView = _views[viewTabs.SelectedTab];
			byte[] rawData = editView.GetRawData();
			fileStream.Write(rawData, 0, rawData.Length);
		}
		catch (Exception ex)
		{
			MessageBox.Show("Failed to export data to \"" + path + "\"\n\nException: " + ex.Message);
		}
	}

	private void ExportText(string path)
	{
		try
		{
			using FileStream fileStream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
			EditView editView = _views[viewTabs.SelectedTab];
			string s = RawToText(editView.GetRawData());
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			fileStream.Write(bytes, 0, bytes.Length);
		}
		catch (Exception ex)
		{
			MessageBox.Show("Failed to export data to \"" + path + "\"\n\nException: " + ex.Message);
		}
	}

	private void _buttonOK_Click(object sender, EventArgs e)
	{
		Apply();
	}

	private void _buttonImport_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.RestoreDirectory = true;
		openFileDialog.Multiselect = false;
		openFileDialog.Filter = "Binary Data|*|Text Data (*.txt)|*.txt";
		openFileDialog.FilterIndex = 0;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			if (Path.GetExtension(openFileDialog.FileName) == ".txt")
			{
				ImportText(openFileDialog.FileName);
			}
			else
			{
				ImportRaw(openFileDialog.FileName);
			}
		}
	}

	private void _buttonExport_Click(object sender, EventArgs e)
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.RestoreDirectory = true;
		saveFileDialog.Filter = "Binary Data|*|Text Data (*.txt)|*.txt";
		saveFileDialog.FilterIndex = 0;
		saveFileDialog.OverwritePrompt = true;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			if (Path.GetExtension(saveFileDialog.FileName) == ".txt")
			{
				ExportText(saveFileDialog.FileName);
			}
			else
			{
				ExportRaw(saveFileDialog.FileName);
			}
		}
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
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this._buttonCancel = new System.Windows.Forms.Button();
		this._buttonOK = new System.Windows.Forms.Button();
		this._buttonImport = new System.Windows.Forms.Button();
		this._buttonExport = new System.Windows.Forms.Button();
		this.viewTabs = new System.Windows.Forms.TabControl();
		base.SuspendLayout();
		this.statusStrip1.Location = new System.Drawing.Point(0, 333);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(532, 22);
		this.statusStrip1.TabIndex = 1;
		this.statusStrip1.Text = "statusStrip1";
		this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._buttonCancel.Location = new System.Drawing.Point(364, 307);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(75, 23);
		this._buttonCancel.TabIndex = 13;
		this._buttonCancel.Text = "Cancel";
		this._buttonCancel.UseVisualStyleBackColor = true;
		this._buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonOK.Location = new System.Drawing.Point(445, 307);
		this._buttonOK.Name = "_buttonOK";
		this._buttonOK.Size = new System.Drawing.Size(75, 23);
		this._buttonOK.TabIndex = 12;
		this._buttonOK.Text = "OK";
		this._buttonOK.UseVisualStyleBackColor = true;
		this._buttonOK.Click += new System.EventHandler(_buttonOK_Click);
		this._buttonImport.Location = new System.Drawing.Point(12, 307);
		this._buttonImport.Name = "_buttonImport";
		this._buttonImport.Size = new System.Drawing.Size(75, 23);
		this._buttonImport.TabIndex = 14;
		this._buttonImport.Text = "Import";
		this._buttonImport.UseVisualStyleBackColor = true;
		this._buttonImport.Click += new System.EventHandler(_buttonImport_Click);
		this._buttonExport.Location = new System.Drawing.Point(93, 307);
		this._buttonExport.Name = "_buttonExport";
		this._buttonExport.Size = new System.Drawing.Size(75, 23);
		this._buttonExport.TabIndex = 15;
		this._buttonExport.Text = "Export";
		this._buttonExport.UseVisualStyleBackColor = true;
		this._buttonExport.Click += new System.EventHandler(_buttonExport_Click);
		this.viewTabs.Location = new System.Drawing.Point(12, 12);
		this.viewTabs.Name = "viewTabs";
		this.viewTabs.SelectedIndex = 0;
		this.viewTabs.Size = new System.Drawing.Size(508, 289);
		this.viewTabs.TabIndex = 16;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this._buttonCancel;
		base.ClientSize = new System.Drawing.Size(532, 355);
		base.Controls.Add(this.viewTabs);
		base.Controls.Add(this._buttonExport);
		base.Controls.Add(this._buttonImport);
		base.Controls.Add(this._buttonCancel);
		base.Controls.Add(this._buttonOK);
		base.Controls.Add(this.statusStrip1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Name = "HexEditor";
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "HexEditor";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
