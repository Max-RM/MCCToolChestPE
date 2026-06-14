using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NBTExplorer.Model;

namespace NBTExplorer.Windows;

public class FindBlock : Form
{
	private class CoordinateGroup
	{
		public int? Region;

		public int? Chunk;

		public int? Block;

		public int? LocalChunk;

		public int? LocalBlock;

		public WatermarkTextBox RegionBox;

		public WatermarkTextBox ChunkBox;

		public WatermarkTextBox BlockBox;

		public WatermarkTextBox LocalChunkBox;

		public WatermarkTextBox LocalBlockBox;
	}

	private bool _inUpdate;

	private CoordinateGroup _groupX;

	private CoordinateGroup _groupZ;

	private DataNode _searchRoot;

	private DataNode _searchResult;

	private IContainer components;

	private GroupBox groupBox1;

	private TableLayoutPanel tableLayoutPanel1;

	private GroupBox groupBox3;

	private GroupBox groupBox2;

	private Label label2;

	private Label label1;

	private WatermarkTextBox _regionZTextBox;

	private WatermarkTextBox _regionXTextBox;

	private Label label5;

	private Label label6;

	private WatermarkTextBox _blockZTextBox;

	private WatermarkTextBox _blockXTextBox;

	private Label label3;

	private Label label4;

	private WatermarkTextBox _chunkZTextBox;

	private WatermarkTextBox _chunkXTextBox;

	private Button _findButton;

	private GroupBox groupBox4;

	private Label label7;

	private WatermarkTextBox _localChunkXTextBox;

	private Label label8;

	private WatermarkTextBox _localChunkZTextBox;

	private GroupBox groupBox5;

	private Label label9;

	private Label label10;

	private WatermarkTextBox _localBlockZTextBox;

	private WatermarkTextBox _localBlockXTextBox;

	private Button _cancelButton;

	public DataNode Result => _searchResult;

	public FindBlock(DataNode searchRoot)
	{
		InitializeComponent();
		_searchRoot = searchRoot;
		_groupX = new CoordinateGroup
		{
			RegionBox = _regionXTextBox,
			ChunkBox = _chunkXTextBox,
			BlockBox = _blockXTextBox,
			LocalChunkBox = _localChunkXTextBox,
			LocalBlockBox = _localBlockXTextBox
		};
		_groupZ = new CoordinateGroup
		{
			RegionBox = _regionZTextBox,
			ChunkBox = _chunkZTextBox,
			BlockBox = _blockZTextBox,
			LocalChunkBox = _localChunkZTextBox,
			LocalBlockBox = _localBlockZTextBox
		};
		ApplyRegion(_groupX, "0", primary: true);
		ApplyRegion(_groupZ, "0", primary: true);
		Validate();
	}

	private DataNode Search(DataNode node)
	{
		if (node is DirectoryDataNode)
		{
			DirectoryDataNode directoryDataNode = node as DirectoryDataNode;
			if (!directoryDataNode.IsExpanded)
			{
				directoryDataNode.Expand();
			}
			foreach (DataNode node2 in directoryDataNode.Nodes)
			{
				DataNode dataNode = Search(node2);
				if (dataNode != null)
				{
					return dataNode;
				}
			}
			return null;
		}
		if (node is RegionFileDataNode)
		{
			RegionFileDataNode regionFileDataNode = node as RegionFileDataNode;
			if (!RegionFileDataNode.RegionCoordinates(regionFileDataNode.NodePathName, out var rx, out var rz))
			{
				return null;
			}
			if (rx != _groupX.Region.Value || rz != _groupZ.Region.Value)
			{
				return null;
			}
			if (!regionFileDataNode.IsExpanded)
			{
				regionFileDataNode.Expand();
			}
			foreach (DataNode node3 in regionFileDataNode.Nodes)
			{
				DataNode dataNode2 = Search(node3);
				if (dataNode2 != null)
				{
					return dataNode2;
				}
			}
			return null;
		}
		if (node is RegionChunkDataNode)
		{
			RegionChunkDataNode regionChunkDataNode = node as RegionChunkDataNode;
			if (regionChunkDataNode.X != _groupX.LocalChunk.Value || regionChunkDataNode.Z != _groupZ.LocalChunk.Value)
			{
				return null;
			}
			return regionChunkDataNode;
		}
		return null;
	}

	private int Mod(int a, int b)
	{
		return (a % b + b) % b;
	}

	private string RegionFromBlock(int block)
	{
		return (block >> 4 >> 5).ToString();
	}

	private string ChunkFromBlock(int block)
	{
		return (block >> 4).ToString();
	}

	private string LocalChunkFromBlock(int block)
	{
		return Mod(block >> 4, 32).ToString();
	}

	private string LocalBlockFromBlock(int block)
	{
		return Mod(block, 16).ToString();
	}

	private string RegionFromChunk(int chunk)
	{
		return (chunk >> 5).ToString();
	}

	private string BlockFromChunk(int chunk)
	{
		int num = chunk * 16;
		int num2 = (chunk + 1) * 16 - 1;
		return $"({num} to {num2})";
	}

	private string BlockFromChunk(int chunk, int localBlock)
	{
		return (chunk * 16 + localBlock).ToString();
	}

	private string LocalChunkFromChunk(int chunk)
	{
		return Mod(chunk, 32).ToString();
	}

	private string LocalBlockFromChunk(int chunk)
	{
		return "(0 to 15)";
	}

	private string ChunkFromRegion(int region)
	{
		int num = region * 32;
		int num2 = (region + 1) * 32 - 1;
		return $"({num} to {num2})";
	}

	private string BlockFromRegion(int region)
	{
		int num = region * 32 * 16;
		int num2 = (region + 1) * 32 * 16 - 1;
		return $"({num} to {num2})";
	}

	private string LocalChunkFromRegion(int region)
	{
		return "(0 to 31)";
	}

	private string LocalBlockFromRegion(int region)
	{
		return "(0 to 15)";
	}

	private string RegionFromLocalChunk(int localChunk)
	{
		return "(ANY)";
	}

	private string ChunkFromLocalChunk(int localChunk)
	{
		return "(ANY)";
	}

	private string ChunkFromLocalChunk(int region, int localChunk)
	{
		return (region * 32 + localChunk).ToString();
	}

	private string BlockFromLocalChunk(int localChunk)
	{
		return "(ANY)";
	}

	private string BlockFromLocalChunk(int region, int localChunk)
	{
		return BlockFromChunk(region * 32 + localChunk);
	}

	private string LocalBlockFromLocalChunk(int localChunk)
	{
		return "(0 to 15)";
	}

	private string LocalBlockFromLocalChunk(int region, int localChunk)
	{
		return "(0 to 15)";
	}

	private string RegionFromLocalBlock(int localBlock)
	{
		return "(ANY)";
	}

	private string ChunkFromLocalBlock(int localBlock)
	{
		return "(ANY)";
	}

	private string ChunkFromLocalBlock(int region, int localChunk, int localBlock)
	{
		return (region * 32 + localChunk).ToString();
	}

	private string BlockFromLocalBlock(int localBlock)
	{
		return "(ANY)";
	}

	private string BlockFromLocalBlock(int region, int localChunk, int localBlock)
	{
		return (region * 32 * 16 + localChunk * 16 + localBlock).ToString();
	}

	private int? ParseInt(string value)
	{
		if (int.TryParse(value, out var result))
		{
			return result;
		}
		return null;
	}

	private void ApplyValueToTextBox(WatermarkTextBox textBox, string value, bool primary)
	{
		if (primary)
		{
			textBox.ApplyText(value);
		}
		else
		{
			textBox.ApplyWatermark(value);
		}
	}

	private void ApplyRegion(CoordinateGroup group, string value, bool primary)
	{
		group.Region = ParseInt(value);
		ApplyValueToTextBox(group.RegionBox, value, primary);
		if (!primary || !group.Region.HasValue)
		{
			return;
		}
		if (group.LocalChunk.HasValue && !group.LocalChunkBox.WatermarkActive)
		{
			ApplyChunk(group, ChunkFromLocalChunk(group.Region.Value, group.LocalChunk.Value), primary: false);
			if (group.LocalBlock.HasValue && !group.LocalBlockBox.WatermarkActive)
			{
				ApplyBlock(group, BlockFromLocalBlock(group.Region.Value, group.LocalChunk.Value, group.LocalBlock.Value), primary: false);
				return;
			}
			ApplyBlock(group, BlockFromLocalChunk(group.Region.Value, group.LocalChunk.Value), primary: false);
			ApplyLocalBlock(group, LocalBlockFromLocalChunk(group.Region.Value, group.LocalChunk.Value), primary: false);
		}
		else
		{
			ApplyChunk(group, ChunkFromRegion(group.Region.Value), primary: false);
			ApplyBlock(group, BlockFromRegion(group.Region.Value), primary: false);
			ApplyLocalChunk(group, LocalChunkFromRegion(group.Region.Value), primary: false);
			ApplyLocalBlock(group, LocalBlockFromRegion(group.Region.Value), primary: false);
		}
	}

	private void ApplyChunk(CoordinateGroup group, string value, bool primary)
	{
		group.Chunk = ParseInt(value);
		ApplyValueToTextBox(group.ChunkBox, value, primary);
		if (primary && group.Chunk.HasValue)
		{
			ApplyRegion(group, RegionFromChunk(group.Chunk.Value), primary: false);
			ApplyLocalChunk(group, LocalChunkFromChunk(group.Chunk.Value), primary: false);
			if (group.LocalBlock.HasValue && !group.LocalBlockBox.WatermarkActive)
			{
				ApplyBlock(group, BlockFromChunk(group.Chunk.Value, group.LocalBlock.Value), primary: false);
				return;
			}
			ApplyBlock(group, BlockFromChunk(group.Chunk.Value), primary: false);
			ApplyLocalBlock(group, LocalBlockFromChunk(group.Chunk.Value), primary: false);
		}
	}

	private void ApplyBlock(CoordinateGroup group, string value, bool primary)
	{
		group.Block = ParseInt(value);
		ApplyValueToTextBox(group.BlockBox, value, primary);
		if (primary && group.Block.HasValue)
		{
			ApplyRegion(group, RegionFromBlock(group.Block.Value), primary: false);
			ApplyChunk(group, ChunkFromBlock(group.Block.Value), primary: false);
			ApplyLocalChunk(group, LocalChunkFromBlock(group.Block.Value), primary: false);
			ApplyLocalBlock(group, LocalBlockFromBlock(group.Block.Value), primary: false);
		}
	}

	private void ApplyLocalChunk(CoordinateGroup group, string value, bool primary)
	{
		group.LocalChunk = ParseInt(value);
		ApplyValueToTextBox(group.LocalChunkBox, value, primary);
		if (!primary || !group.LocalChunk.HasValue)
		{
			return;
		}
		if (group.Region.HasValue)
		{
			ApplyChunk(group, ChunkFromLocalChunk(group.Region.Value, group.LocalChunk.Value), primary: false);
			if (group.LocalBlock.HasValue && !group.LocalBlockBox.WatermarkActive)
			{
				ApplyBlock(group, BlockFromLocalBlock(group.Region.Value, group.LocalChunk.Value, group.LocalBlock.Value), primary: false);
				return;
			}
			ApplyBlock(group, BlockFromLocalChunk(group.Region.Value, group.LocalChunk.Value), primary: false);
			ApplyLocalBlock(group, LocalBlockFromLocalChunk(group.Region.Value, group.LocalChunk.Value), primary: false);
		}
		else
		{
			ApplyRegion(group, RegionFromLocalChunk(group.LocalChunk.Value), primary: false);
			ApplyChunk(group, ChunkFromLocalChunk(group.LocalChunk.Value), primary: false);
			ApplyBlock(group, BlockFromLocalChunk(group.LocalChunk.Value), primary: false);
			ApplyLocalBlock(group, LocalBlockFromLocalChunk(group.LocalChunk.Value), primary: false);
		}
	}

	private void ApplyLocalBlock(CoordinateGroup group, string value, bool primary)
	{
		group.LocalBlock = ParseInt(value);
		ApplyValueToTextBox(group.LocalBlockBox, value, primary);
		if (primary && group.LocalBlock.HasValue)
		{
			if (group.Region.HasValue && group.LocalChunk.HasValue && !group.LocalChunkBox.WatermarkActive)
			{
				ApplyChunk(group, ChunkFromLocalBlock(group.Region.Value, group.LocalChunk.Value, group.LocalBlock.Value), primary: false);
				ApplyBlock(group, BlockFromLocalBlock(group.Region.Value, group.LocalChunk.Value, group.LocalBlock.Value), primary: false);
			}
			else
			{
				ApplyRegion(group, RegionFromLocalBlock(group.LocalBlock.Value), primary: false);
				ApplyChunk(group, ChunkFromLocalBlock(group.LocalBlock.Value), primary: false);
				ApplyBlock(group, BlockFromLocalBlock(group.LocalBlock.Value), primary: false);
			}
		}
	}

	private new void Validate()
	{
		if (_groupX.LocalChunk.HasValue && _groupZ.LocalChunk.HasValue)
		{
			_findButton.Enabled = true;
		}
		else
		{
			_findButton.Enabled = false;
		}
	}

	private void _regionXTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_regionXTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyRegion(_groupX, _regionXTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _regionZTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_regionZTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyRegion(_groupZ, _regionZTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _chunkXTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_chunkXTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyChunk(_groupX, _chunkXTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _chunkZTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_chunkZTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyChunk(_groupZ, _chunkZTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _blockXTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_blockXTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyBlock(_groupX, _blockXTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _blockZTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_blockZTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyBlock(_groupZ, _blockZTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _localChunkXTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_localChunkXTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyLocalChunk(_groupX, _localChunkXTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _localChunkZTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_localChunkZTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyLocalChunk(_groupZ, _localChunkZTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _localBlockXTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_localBlockXTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyLocalBlock(_groupX, _localBlockXTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _localBlockZTextBox_TextChanged(object sender, EventArgs e)
	{
		int result = 0;
		if (!_inUpdate && int.TryParse(_localBlockZTextBox.Text, out result))
		{
			_inUpdate = true;
			ApplyLocalBlock(_groupZ, _localBlockZTextBox.Text, primary: true);
			_inUpdate = false;
			Validate();
		}
	}

	private void _findButton_Click(object sender, EventArgs e)
	{
		_searchResult = Search(_searchRoot);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void _cancelButton_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
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
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this._regionZTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this._regionXTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this._blockZTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this._blockXTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this._chunkZTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this._chunkXTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.label7 = new System.Windows.Forms.Label();
		this._localChunkXTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this.label8 = new System.Windows.Forms.Label();
		this._localChunkZTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this._localBlockZTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this._localBlockXTextBox = new NBTExplorer.Windows.WatermarkTextBox();
		this._findButton = new System.Windows.Forms.Button();
		this._cancelButton = new System.Windows.Forms.Button();
		this.groupBox1.SuspendLayout();
		this.tableLayoutPanel1.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox4.SuspendLayout();
		this.groupBox5.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this._regionZTextBox);
		this.groupBox1.Controls.Add(this._regionXTextBox);
		this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox1.Location = new System.Drawing.Point(3, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(142, 70);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Region";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 48);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(17, 13);
		this.label2.TabIndex = 3;
		this.label2.Text = "Z:";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(6, 22);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(17, 13);
		this.label1.TabIndex = 2;
		this.label1.Text = "X:";
		this._regionZTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._regionZTextBox.ForeColor = System.Drawing.Color.Gray;
		this._regionZTextBox.Location = new System.Drawing.Point(36, 45);
		this._regionZTextBox.Name = "_regionZTextBox";
		this._regionZTextBox.Size = new System.Drawing.Size(100, 20);
		this._regionZTextBox.TabIndex = 1;
		this._regionZTextBox.Text = "Type here";
		this._regionZTextBox.WatermarkActive = true;
		this._regionZTextBox.WatermarkText = "Type here";
		this._regionZTextBox.TextChanged += new System.EventHandler(_regionZTextBox_TextChanged);
		this._regionXTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._regionXTextBox.ForeColor = System.Drawing.Color.Gray;
		this._regionXTextBox.Location = new System.Drawing.Point(36, 19);
		this._regionXTextBox.Name = "_regionXTextBox";
		this._regionXTextBox.Size = new System.Drawing.Size(100, 20);
		this._regionXTextBox.TabIndex = 0;
		this._regionXTextBox.Text = "Type here";
		this._regionXTextBox.WatermarkActive = true;
		this._regionXTextBox.WatermarkText = "Type here";
		this._regionXTextBox.TextChanged += new System.EventHandler(_regionXTextBox_TextChanged);
		this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tableLayoutPanel1.ColumnCount = 3;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
		this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
		this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 1);
		this.tableLayoutPanel1.Controls.Add(this.groupBox5, 2, 1);
		this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 2;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 152);
		this.tableLayoutPanel1.TabIndex = 1;
		this.groupBox3.Controls.Add(this.label5);
		this.groupBox3.Controls.Add(this.label6);
		this.groupBox3.Controls.Add(this._blockZTextBox);
		this.groupBox3.Controls.Add(this._blockXTextBox);
		this.groupBox3.Location = new System.Drawing.Point(299, 3);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(144, 70);
		this.groupBox3.TabIndex = 2;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Block";
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(6, 48);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(17, 13);
		this.label5.TabIndex = 7;
		this.label5.Text = "Z:";
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(6, 22);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(17, 13);
		this.label6.TabIndex = 6;
		this.label6.Text = "X:";
		this._blockZTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._blockZTextBox.ForeColor = System.Drawing.Color.Gray;
		this._blockZTextBox.Location = new System.Drawing.Point(38, 45);
		this._blockZTextBox.Name = "_blockZTextBox";
		this._blockZTextBox.Size = new System.Drawing.Size(100, 20);
		this._blockZTextBox.TabIndex = 1;
		this._blockZTextBox.Text = "Type here";
		this._blockZTextBox.WatermarkActive = true;
		this._blockZTextBox.WatermarkText = "Type here";
		this._blockZTextBox.TextChanged += new System.EventHandler(_blockZTextBox_TextChanged);
		this._blockXTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._blockXTextBox.ForeColor = System.Drawing.Color.Gray;
		this._blockXTextBox.Location = new System.Drawing.Point(38, 19);
		this._blockXTextBox.Name = "_blockXTextBox";
		this._blockXTextBox.Size = new System.Drawing.Size(100, 20);
		this._blockXTextBox.TabIndex = 0;
		this._blockXTextBox.Text = "Type here";
		this._blockXTextBox.WatermarkActive = true;
		this._blockXTextBox.WatermarkText = "Type here";
		this._blockXTextBox.TextChanged += new System.EventHandler(_blockXTextBox_TextChanged);
		this.groupBox2.Controls.Add(this.label3);
		this.groupBox2.Controls.Add(this.label4);
		this.groupBox2.Controls.Add(this._chunkZTextBox);
		this.groupBox2.Controls.Add(this._chunkXTextBox);
		this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox2.Location = new System.Drawing.Point(151, 3);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(142, 70);
		this.groupBox2.TabIndex = 2;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Chunk";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(6, 48);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(17, 13);
		this.label3.TabIndex = 5;
		this.label3.Text = "Z:";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(6, 22);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(17, 13);
		this.label4.TabIndex = 4;
		this.label4.Text = "X:";
		this._chunkZTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._chunkZTextBox.ForeColor = System.Drawing.Color.Gray;
		this._chunkZTextBox.Location = new System.Drawing.Point(36, 45);
		this._chunkZTextBox.Name = "_chunkZTextBox";
		this._chunkZTextBox.Size = new System.Drawing.Size(100, 20);
		this._chunkZTextBox.TabIndex = 1;
		this._chunkZTextBox.Text = "Type here";
		this._chunkZTextBox.WatermarkActive = true;
		this._chunkZTextBox.WatermarkText = "Type here";
		this._chunkZTextBox.TextChanged += new System.EventHandler(_chunkZTextBox_TextChanged);
		this._chunkXTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._chunkXTextBox.ForeColor = System.Drawing.Color.Gray;
		this._chunkXTextBox.Location = new System.Drawing.Point(36, 19);
		this._chunkXTextBox.Name = "_chunkXTextBox";
		this._chunkXTextBox.Size = new System.Drawing.Size(100, 20);
		this._chunkXTextBox.TabIndex = 0;
		this._chunkXTextBox.Text = "Type here";
		this._chunkXTextBox.WatermarkActive = true;
		this._chunkXTextBox.WatermarkText = "Type here";
		this._chunkXTextBox.TextChanged += new System.EventHandler(_chunkXTextBox_TextChanged);
		this.groupBox4.Controls.Add(this.label7);
		this.groupBox4.Controls.Add(this._localChunkXTextBox);
		this.groupBox4.Controls.Add(this.label8);
		this.groupBox4.Controls.Add(this._localChunkZTextBox);
		this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox4.Location = new System.Drawing.Point(151, 79);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(142, 70);
		this.groupBox4.TabIndex = 3;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Local Chunk";
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(6, 48);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(17, 13);
		this.label7.TabIndex = 9;
		this.label7.Text = "Z:";
		this._localChunkXTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._localChunkXTextBox.ForeColor = System.Drawing.Color.Gray;
		this._localChunkXTextBox.Location = new System.Drawing.Point(36, 19);
		this._localChunkXTextBox.Name = "_localChunkXTextBox";
		this._localChunkXTextBox.Size = new System.Drawing.Size(100, 20);
		this._localChunkXTextBox.TabIndex = 6;
		this._localChunkXTextBox.Text = "Type here";
		this._localChunkXTextBox.WatermarkActive = true;
		this._localChunkXTextBox.WatermarkText = "Type here";
		this._localChunkXTextBox.TextChanged += new System.EventHandler(_localChunkXTextBox_TextChanged);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(6, 22);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(17, 13);
		this.label8.TabIndex = 8;
		this.label8.Text = "X:";
		this._localChunkZTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._localChunkZTextBox.ForeColor = System.Drawing.Color.Gray;
		this._localChunkZTextBox.Location = new System.Drawing.Point(36, 45);
		this._localChunkZTextBox.Name = "_localChunkZTextBox";
		this._localChunkZTextBox.Size = new System.Drawing.Size(100, 20);
		this._localChunkZTextBox.TabIndex = 7;
		this._localChunkZTextBox.Text = "Type here";
		this._localChunkZTextBox.WatermarkActive = true;
		this._localChunkZTextBox.WatermarkText = "Type here";
		this._localChunkZTextBox.TextChanged += new System.EventHandler(_localChunkZTextBox_TextChanged);
		this.groupBox5.Controls.Add(this.label9);
		this.groupBox5.Controls.Add(this.label10);
		this.groupBox5.Controls.Add(this._localBlockZTextBox);
		this.groupBox5.Controls.Add(this._localBlockXTextBox);
		this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox5.Location = new System.Drawing.Point(299, 79);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Size = new System.Drawing.Size(144, 70);
		this.groupBox5.TabIndex = 4;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "Local Block";
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(8, 48);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(17, 13);
		this.label9.TabIndex = 9;
		this.label9.Text = "Z:";
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(8, 22);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(17, 13);
		this.label10.TabIndex = 8;
		this.label10.Text = "X:";
		this._localBlockZTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._localBlockZTextBox.ForeColor = System.Drawing.Color.Gray;
		this._localBlockZTextBox.Location = new System.Drawing.Point(38, 45);
		this._localBlockZTextBox.Name = "_localBlockZTextBox";
		this._localBlockZTextBox.Size = new System.Drawing.Size(100, 20);
		this._localBlockZTextBox.TabIndex = 7;
		this._localBlockZTextBox.Text = "Type here";
		this._localBlockZTextBox.WatermarkActive = true;
		this._localBlockZTextBox.WatermarkText = "Type here";
		this._localBlockZTextBox.TextChanged += new System.EventHandler(_localBlockZTextBox_TextChanged);
		this._localBlockXTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._localBlockXTextBox.ForeColor = System.Drawing.Color.Gray;
		this._localBlockXTextBox.Location = new System.Drawing.Point(38, 19);
		this._localBlockXTextBox.Name = "_localBlockXTextBox";
		this._localBlockXTextBox.Size = new System.Drawing.Size(100, 20);
		this._localBlockXTextBox.TabIndex = 6;
		this._localBlockXTextBox.Text = "Type here";
		this._localBlockXTextBox.WatermarkActive = true;
		this._localBlockXTextBox.WatermarkText = "Type here";
		this._localBlockXTextBox.TextChanged += new System.EventHandler(_localBlockXTextBox_TextChanged);
		this._findButton.Location = new System.Drawing.Point(383, 170);
		this._findButton.Name = "_findButton";
		this._findButton.Size = new System.Drawing.Size(75, 23);
		this._findButton.TabIndex = 2;
		this._findButton.Text = "Find Chunk";
		this._findButton.UseVisualStyleBackColor = true;
		this._findButton.Click += new System.EventHandler(_findButton_Click);
		this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._cancelButton.Location = new System.Drawing.Point(302, 171);
		this._cancelButton.Name = "_cancelButton";
		this._cancelButton.Size = new System.Drawing.Size(75, 23);
		this._cancelButton.TabIndex = 3;
		this._cancelButton.Text = "Cancel";
		this._cancelButton.UseVisualStyleBackColor = true;
		this._cancelButton.Click += new System.EventHandler(_cancelButton_Click);
		base.AcceptButton = this._findButton;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this._cancelButton;
		base.ClientSize = new System.Drawing.Size(470, 206);
		base.Controls.Add(this._cancelButton);
		base.Controls.Add(this._findButton);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Name = "FindBlock";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Chunk Finder";
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.tableLayoutPanel1.ResumeLayout(false);
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox5.PerformLayout();
		base.ResumeLayout(false);
	}
}
