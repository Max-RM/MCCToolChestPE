using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using NBTExplorer.Controllers;
using NBTExplorer.Model;
using Substrate.Nbt;

namespace NBTExplorer.Windows;

public class FindReplace : Form
{
	private delegate void Action();

	private MainForm _main;

	private NodeTreeController _mainController;

	private DataNode _mainSearchRoot;

	private RuleTreeController _findController;

	private NodeTreeController _replaceController;

	private ExplorerBarController _explorerManager;

	private CancelSearchForm _searchForm;

	private ContainerRuleSearchStateWin _searchState;

	private DataNode _currentFindNode;

	private IContainer components;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private Panel panel1;

	private TreeView treeView1;

	private ToolStrip toolStrip1;

	private ToolStripButton _tbFindDelete;

	private ToolStripSeparator toolStripSeparator1;

	private Panel panel2;

	private TreeView treeView2;

	private ToolStrip toolStrip2;

	private ToolStripButton _tbReplaceDelete;

	private ToolStripSeparator toolStripSeparator2;

	private Button _buttonFind;

	private Button _buttonReplace;

	private Button _buttonReplaceAll;

	private Button _buttonCancel;

	private ToolStripButton _tbFindAny;

	private ToolStripSeparator toolStripSeparator3;

	private ToolStripButton _tbFindByte;

	private ToolStripButton _tbFindShort;

	private ToolStripButton _tbFindInt;

	private ToolStripButton _tbFindLong;

	private ToolStripButton _tbFindFloat;

	private ToolStripButton _tbFindDouble;

	private ToolStripButton _tbFindString;

	private ToolStripButton _tbReplaceByte;

	private ToolStripButton _tbReplaceShort;

	private ToolStripButton _tbReplaceInt;

	private ToolStripButton _tbReplaceLong;

	private ToolStripButton _tbReplaceFloat;

	private ToolStripButton _tbReplaceDouble;

	private ToolStripButton _tbReplaceByteArray;

	private ToolStripButton _tbReplaceIntArray;

	private ToolStripButton _tbReplaceString;

	private ToolStripButton _tbReplaceList;

	private ToolStripButton _tbReplaceCompound;

	private ImageList imageList1;

	private ToolStripButton _tbFindGroupAnd;

	private ToolStripButton _tbFindGroupOr;

	private ToolStripButton _tbFindEdit;

	private ToolStripButton _tbReplaceEdit;

	private ToolStrip _explorerStrip;

	private TableLayoutPanel tableLayoutPanel1;

	private CheckBox _deleteTagsCheckbox;

	private ToolStripButton _tbReplaceLongArray;

	public FindReplace(MainForm main, NodeTreeController controller, DataNode searchRoot)
	{
		InitializeComponent();
		_main = main;
		_mainController = controller;
		_mainSearchRoot = searchRoot;
		_findController = new RuleTreeController(treeView1);
		TreeView treeView = treeView1;
		TreeNodeMouseClickEventHandler value = delegate
		{
			_findController.EditSelection();
		};
		treeView.NodeMouseDoubleClick += value;
		_replaceController = new NodeTreeController(treeView2);
		treeView2.NodeMouseDoubleClick += delegate
		{
			_replaceController.EditSelection();
		};
		_replaceController.VirtualRootDisplay = "Replacement Tags";
		_explorerStrip.Renderer = new ToolStripExplorerRenderer();
		_explorerStrip.ImageList = _mainController.IconList;
		_explorerManager = new ExplorerBarController(_explorerStrip, _mainController.IconRegistry, _mainController.IconList, searchRoot);
		_explorerManager.SearchRootChanged += delegate
		{
			_mainSearchRoot = _explorerManager.SearchRoot;
			Reset();
		};
	}

	private void _tbFindDelete_Click(object sender, EventArgs e)
	{
		_findController.DeleteSelection();
	}

	private void _tbFindGroupAnd_Click(object sender, EventArgs e)
	{
		_findController.CreateIntersectNode();
	}

	private void _tbFindGroupOr_Click(object sender, EventArgs e)
	{
		_findController.CreateUnionNode();
	}

	private void _tbFindAny_Click(object sender, EventArgs e)
	{
		_findController.CreateWildcardNode();
	}

	private void _tbFindByte_Click(object sender, EventArgs e)
	{
		_findController.CreateNode(TagType.TAG_BYTE);
	}

	private void _tbFindShort_Click(object sender, EventArgs e)
	{
		_findController.CreateNode(TagType.TAG_SHORT);
	}

	private void _tbFindInt_Click(object sender, EventArgs e)
	{
		_findController.CreateNode(TagType.TAG_INT);
	}

	private void _tbFindLong_Click(object sender, EventArgs e)
	{
		_findController.CreateNode(TagType.TAG_LONG);
	}

	private void _tbFindFloat_Click(object sender, EventArgs e)
	{
		_findController.CreateNode(TagType.TAG_FLOAT);
	}

	private void _tbFindDouble_Click(object sender, EventArgs e)
	{
		_findController.CreateNode(TagType.TAG_DOUBLE);
	}

	private void _tbFindString_Click(object sender, EventArgs e)
	{
		_findController.CreateNode(TagType.TAG_STRING);
	}

	private void _tbReplaceDelete_Click(object sender, EventArgs e)
	{
		_replaceController.DeleteSelection();
	}

	private void _tbReplaceByte_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_BYTE);
	}

	private void _tbReplaceShort_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_SHORT);
	}

	private void _tbReplaceInt_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_INT);
	}

	private void _tbReplaceLong_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_LONG);
	}

	private void _tbReplaceFloat_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_FLOAT);
	}

	private void _tbReplaceDouble_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_DOUBLE);
	}

	private void _tbReplaceByteArray_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_BYTE_ARRAY);
	}

	private void _tbReplaceIntArray_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_INT_ARRAY);
	}

	private void _tbReplaceLongArray_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_LONG_ARRAY);
	}

	private void _tbReplaceString_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_STRING);
	}

	private void _tbReplaceList_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_LIST);
	}

	private void _tbReplaceCompound_Click(object sender, EventArgs e)
	{
		_replaceController.CreateNode(TagType.TAG_COMPOUND);
	}

	private void Reset()
	{
		_searchForm = null;
		_searchState = null;
	}

	private void _buttonFind_Click(object sender, EventArgs e)
	{
		if (_searchState == null)
		{
			_searchState = new ContainerRuleSearchStateWin(_main)
			{
				RuleTags = _findController.Root,
				RootNode = _mainSearchRoot,
				DiscoverCallback = SearchDiscoveryCallback,
				CollapseCallback = SearchCollapseCallback,
				ProgressCallback = SearchProgressCallback,
				EndCallback = SearchEndCallback
			};
		}
		SearchNextNode();
	}

	private void _buttonReplaceAll_Click(object sender, EventArgs e)
	{
		_searchState = new ContainerRuleSearchStateWin(_main)
		{
			RuleTags = _findController.Root,
			RootNode = _mainSearchRoot,
			DiscoverCallback = SearchDiscoveryReplaceAllCallback,
			CollapseCallback = SearchCollapseCallback,
			ProgressCallback = SearchProgressCallback,
			EndCallback = SearchEndCallback,
			TerminateOnDiscover = false
		};
		SearchNextNodeContinuous();
	}

	private void SearchNextNode()
	{
		if (_searchState != null)
		{
			SearchWorker searchWorker = new SearchWorker(_searchState);
			Thread thread = new Thread(searchWorker.Run);
			thread.IsBackground = true;
			thread.Start();
			_searchForm = new CancelSearchForm();
			if (_searchForm.ShowDialog(this) == DialogResult.Cancel)
			{
				searchWorker.Cancel();
				_searchState = null;
			}
		}
	}

	private void SearchNextNodeContinuous()
	{
		if (_searchState != null)
		{
			SearchWorker searchWorker = new SearchWorker(_searchState);
			Thread thread = new Thread(RunContinuousReplace);
			thread.IsBackground = true;
			thread.Start();
			_searchForm = new CancelSearchForm();
			if (_searchForm.ShowDialog(this) == DialogResult.Cancel)
			{
				searchWorker.Cancel();
				_searchState = null;
			}
		}
	}

	private void RunContinuousReplace()
	{
		SearchWorker searchWorker = new SearchWorker(_searchState);
		searchWorker.Run();
		Invoke((Action)delegate
		{
			Reset();
		});
	}

	private void SearchDiscoveryCallback(DataNode node)
	{
		_mainController.SelectNode(node);
		_mainController.ExpandSelectedNode();
		if (_searchForm != null)
		{
			_searchForm.DialogResult = DialogResult.OK;
			_searchForm = null;
		}
		_currentFindNode = node;
	}

	private void SearchDiscoveryReplaceAllCallback(DataNode node)
	{
		_mainController.SelectNode(node);
		_mainController.ExpandSelectedNode();
		_currentFindNode = node;
		ReplaceCurrent();
	}

	private void SearchProgressCallback(DataNode node)
	{
		try
		{
			_searchForm.SearchPathLabel = node.NodePath;
		}
		catch
		{
		}
	}

	private void SearchCollapseCallback(DataNode node)
	{
		_mainController.CollapseBelow(node);
	}

	private void SearchEndCallback(DataNode node)
	{
		if (_searchForm != null)
		{
			_searchForm.DialogResult = DialogResult.OK;
			_searchForm = null;
		}
		MessageBox.Show("End of Results");
	}

	private void _buttonReplace_Click(object sender, EventArgs e)
	{
		ReplaceCurrent();
	}

	private void ReplaceCurrent()
	{
		if (!(_currentFindNode is TagCompoundDataNode tagCompoundDataNode))
		{
			return;
		}
		List<TagDataNode> list = new List<TagDataNode>();
		_findController.Root.Matches(tagCompoundDataNode, list);
		List<string> list2 = new List<string>();
		foreach (DataNode node in _replaceController.Root.Nodes)
		{
			list2.Add(node.NodeName);
		}
		foreach (TagDataNode item in list)
		{
			if (_deleteTagsCheckbox.Checked || list2.Contains(item.NodeName))
			{
				item.DeleteNode();
			}
		}
		foreach (TagDataNode node2 in _replaceController.Root.Nodes)
		{
			if (node2 != null)
			{
				tagCompoundDataNode.NamedTagContainer.AddTag(node2.Tag, node2.NodeName);
				tagCompoundDataNode.SyncTag();
			}
		}
		_mainController.RefreshTreeNode(tagCompoundDataNode);
	}

	private void _buttonCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void _tbFindEdit_Click(object sender, EventArgs e)
	{
		_findController.EditSelection();
	}

	private void _tbReplaceEdit_Click(object sender, EventArgs e)
	{
		_replaceController.EditSelection();
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NBTExplorer.Windows.FindReplace));
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.panel1 = new System.Windows.Forms.Panel();
		this.treeView1 = new System.Windows.Forms.TreeView();
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		this._tbFindEdit = new System.Windows.Forms.ToolStripButton();
		this._tbFindDelete = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this._tbFindGroupAnd = new System.Windows.Forms.ToolStripButton();
		this._tbFindGroupOr = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this._tbFindAny = new System.Windows.Forms.ToolStripButton();
		this._tbFindByte = new System.Windows.Forms.ToolStripButton();
		this._tbFindShort = new System.Windows.Forms.ToolStripButton();
		this._tbFindInt = new System.Windows.Forms.ToolStripButton();
		this._tbFindLong = new System.Windows.Forms.ToolStripButton();
		this._tbFindFloat = new System.Windows.Forms.ToolStripButton();
		this._tbFindDouble = new System.Windows.Forms.ToolStripButton();
		this._tbFindString = new System.Windows.Forms.ToolStripButton();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this._deleteTagsCheckbox = new System.Windows.Forms.CheckBox();
		this.panel2 = new System.Windows.Forms.Panel();
		this.treeView2 = new System.Windows.Forms.TreeView();
		this.toolStrip2 = new System.Windows.Forms.ToolStrip();
		this._tbReplaceEdit = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceDelete = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this._tbReplaceByte = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceShort = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceInt = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceLong = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceFloat = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceDouble = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceByteArray = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceIntArray = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceLongArray = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceString = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceList = new System.Windows.Forms.ToolStripButton();
		this._tbReplaceCompound = new System.Windows.Forms.ToolStripButton();
		this._buttonFind = new System.Windows.Forms.Button();
		this._buttonReplace = new System.Windows.Forms.Button();
		this._buttonReplaceAll = new System.Windows.Forms.Button();
		this._buttonCancel = new System.Windows.Forms.Button();
		this._explorerStrip = new System.Windows.Forms.ToolStrip();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.groupBox1.SuspendLayout();
		this.panel1.SuspendLayout();
		this.toolStrip1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.panel2.SuspendLayout();
		this.toolStrip2.SuspendLayout();
		this.tableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox1.Controls.Add(this.panel1);
		this.groupBox1.Location = new System.Drawing.Point(3, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(341, 211);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Find";
		this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panel1.Controls.Add(this.treeView1);
		this.panel1.Controls.Add(this.toolStrip1);
		this.panel1.Location = new System.Drawing.Point(6, 19);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(329, 186);
		this.panel1.TabIndex = 0;
		this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.treeView1.ImageIndex = 0;
		this.treeView1.ImageList = this.imageList1;
		this.treeView1.ItemHeight = 18;
		this.treeView1.Location = new System.Drawing.Point(0, 25);
		this.treeView1.Name = "treeView1";
		this.treeView1.SelectedImageIndex = 0;
		this.treeView1.ShowPlusMinus = false;
		this.treeView1.ShowRootLines = false;
		this.treeView1.Size = new System.Drawing.Size(329, 161);
		this.treeView1.TabIndex = 1;
		this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
		this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.imageList1.Images.SetKeyName(0, "document-attribute-b.png");
		this.imageList1.Images.SetKeyName(1, "document-attribute-s.png");
		this.imageList1.Images.SetKeyName(2, "document-attribute-i.png");
		this.imageList1.Images.SetKeyName(3, "document-attribute-l.png");
		this.imageList1.Images.SetKeyName(4, "document-attribute-f.png");
		this.imageList1.Images.SetKeyName(5, "document-attribute-d.png");
		this.imageList1.Images.SetKeyName(6, "edit-code.png");
		this.imageList1.Images.SetKeyName(7, "edit-small-caps.png");
		this.imageList1.Images.SetKeyName(8, "edit-list.png");
		this.imageList1.Images.SetKeyName(9, "box.png");
		this.imageList1.Images.SetKeyName(10, "folder.png");
		this.imageList1.Images.SetKeyName(11, "block.png");
		this.imageList1.Images.SetKeyName(12, "wooden-box.png");
		this.imageList1.Images.SetKeyName(13, "map.png");
		this.imageList1.Images.SetKeyName(14, "edit-code-i.png");
		this.imageList1.Images.SetKeyName(15, "question-white.png");
		this.imageList1.Images.SetKeyName(16, "edit-code-s.png");
		this.imageList1.Images.SetKeyName(17, "edit-code-l.png");
		this.imageList1.Images.SetKeyName(18, "arrow-315.png");
		this.imageList1.Images.SetKeyName(19, "asterisk-yellow.png");
		this.imageList1.Images.SetKeyName(20, "sql-join-inner.png");
		this.imageList1.Images.SetKeyName(21, "sql-join-outer.png");
		this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
		{
			this._tbFindEdit, this._tbFindDelete, this.toolStripSeparator1, this._tbFindGroupAnd, this._tbFindGroupOr, this.toolStripSeparator3, this._tbFindAny, this._tbFindByte, this._tbFindShort, this._tbFindInt,
			this._tbFindLong, this._tbFindFloat, this._tbFindDouble, this._tbFindString
		});
		this.toolStrip1.Location = new System.Drawing.Point(0, 0);
		this.toolStrip1.Name = "toolStrip1";
		this.toolStrip1.Size = new System.Drawing.Size(329, 25);
		this.toolStrip1.TabIndex = 0;
		this.toolStrip1.Text = "toolStrip1";
		this._tbFindEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindEdit.Image = (System.Drawing.Image)resources.GetObject("_tbFindEdit.Image");
		this._tbFindEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindEdit.Name = "_tbFindEdit";
		this._tbFindEdit.Size = new System.Drawing.Size(23, 22);
		this._tbFindEdit.Text = "Edit Selected Rule";
		this._tbFindEdit.Click += new System.EventHandler(_tbFindEdit_Click);
		this._tbFindDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindDelete.Image = (System.Drawing.Image)resources.GetObject("_tbFindDelete.Image");
		this._tbFindDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindDelete.Name = "_tbFindDelete";
		this._tbFindDelete.Size = new System.Drawing.Size(23, 22);
		this._tbFindDelete.Text = "Delete Selected Rule";
		this._tbFindDelete.Click += new System.EventHandler(_tbFindDelete_Click);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
		this._tbFindGroupAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindGroupAnd.Image = (System.Drawing.Image)resources.GetObject("_tbFindGroupAnd.Image");
		this._tbFindGroupAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindGroupAnd.Name = "_tbFindGroupAnd";
		this._tbFindGroupAnd.Size = new System.Drawing.Size(23, 22);
		this._tbFindGroupAnd.Text = "Add Match-All Group";
		this._tbFindGroupAnd.Click += new System.EventHandler(_tbFindGroupAnd_Click);
		this._tbFindGroupOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindGroupOr.Image = (System.Drawing.Image)resources.GetObject("_tbFindGroupOr.Image");
		this._tbFindGroupOr.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindGroupOr.Name = "_tbFindGroupOr";
		this._tbFindGroupOr.Size = new System.Drawing.Size(23, 22);
		this._tbFindGroupOr.Text = "Add Match-Any Group";
		this._tbFindGroupOr.Click += new System.EventHandler(_tbFindGroupOr_Click);
		this.toolStripSeparator3.Name = "toolStripSeparator3";
		this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
		this._tbFindAny.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindAny.Image = (System.Drawing.Image)resources.GetObject("_tbFindAny.Image");
		this._tbFindAny.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindAny.Name = "_tbFindAny";
		this._tbFindAny.Size = new System.Drawing.Size(23, 22);
		this._tbFindAny.Text = "Add Any-Type Tag Rule";
		this._tbFindAny.Click += new System.EventHandler(_tbFindAny_Click);
		this._tbFindByte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindByte.Image = (System.Drawing.Image)resources.GetObject("_tbFindByte.Image");
		this._tbFindByte.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindByte.Name = "_tbFindByte";
		this._tbFindByte.Size = new System.Drawing.Size(23, 22);
		this._tbFindByte.Text = "Add Byte Tag Rule";
		this._tbFindByte.Click += new System.EventHandler(_tbFindByte_Click);
		this._tbFindShort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindShort.Image = (System.Drawing.Image)resources.GetObject("_tbFindShort.Image");
		this._tbFindShort.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindShort.Name = "_tbFindShort";
		this._tbFindShort.Size = new System.Drawing.Size(23, 22);
		this._tbFindShort.Text = "Add Short Tag Rule";
		this._tbFindShort.Click += new System.EventHandler(_tbFindShort_Click);
		this._tbFindInt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindInt.Image = (System.Drawing.Image)resources.GetObject("_tbFindInt.Image");
		this._tbFindInt.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindInt.Name = "_tbFindInt";
		this._tbFindInt.Size = new System.Drawing.Size(23, 22);
		this._tbFindInt.Text = "Add Int Tag Rule";
		this._tbFindInt.Click += new System.EventHandler(_tbFindInt_Click);
		this._tbFindLong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindLong.Image = (System.Drawing.Image)resources.GetObject("_tbFindLong.Image");
		this._tbFindLong.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindLong.Name = "_tbFindLong";
		this._tbFindLong.Size = new System.Drawing.Size(23, 22);
		this._tbFindLong.Text = "Add Long Tag Rule";
		this._tbFindLong.Click += new System.EventHandler(_tbFindLong_Click);
		this._tbFindFloat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindFloat.Image = (System.Drawing.Image)resources.GetObject("_tbFindFloat.Image");
		this._tbFindFloat.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindFloat.Name = "_tbFindFloat";
		this._tbFindFloat.Size = new System.Drawing.Size(23, 22);
		this._tbFindFloat.Text = "Add Float Tag Rule";
		this._tbFindFloat.Click += new System.EventHandler(_tbFindFloat_Click);
		this._tbFindDouble.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindDouble.Image = (System.Drawing.Image)resources.GetObject("_tbFindDouble.Image");
		this._tbFindDouble.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindDouble.Name = "_tbFindDouble";
		this._tbFindDouble.Size = new System.Drawing.Size(23, 22);
		this._tbFindDouble.Text = "Add Double Tag Rule";
		this._tbFindDouble.Click += new System.EventHandler(_tbFindDouble_Click);
		this._tbFindString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbFindString.Image = (System.Drawing.Image)resources.GetObject("_tbFindString.Image");
		this._tbFindString.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbFindString.Name = "_tbFindString";
		this._tbFindString.Size = new System.Drawing.Size(23, 22);
		this._tbFindString.Text = "Add Text Tag Rule";
		this._tbFindString.Click += new System.EventHandler(_tbFindString_Click);
		this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox2.Controls.Add(this._deleteTagsCheckbox);
		this.groupBox2.Controls.Add(this.panel2);
		this.groupBox2.Location = new System.Drawing.Point(350, 3);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(341, 211);
		this.groupBox2.TabIndex = 1;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Replace";
		this._deleteTagsCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this._deleteTagsCheckbox.AutoSize = true;
		this._deleteTagsCheckbox.Location = new System.Drawing.Point(6, 188);
		this._deleteTagsCheckbox.Name = "_deleteTagsCheckbox";
		this._deleteTagsCheckbox.Size = new System.Drawing.Size(268, 17);
		this._deleteTagsCheckbox.TabIndex = 1;
		this._deleteTagsCheckbox.Text = "Delete matched tags before applying replacements.";
		this._deleteTagsCheckbox.UseVisualStyleBackColor = true;
		this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panel2.Controls.Add(this.treeView2);
		this.panel2.Controls.Add(this.toolStrip2);
		this.panel2.Location = new System.Drawing.Point(6, 19);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(329, 163);
		this.panel2.TabIndex = 0;
		this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.treeView2.ImageIndex = 0;
		this.treeView2.ImageList = this.imageList1;
		this.treeView2.ItemHeight = 18;
		this.treeView2.Location = new System.Drawing.Point(0, 25);
		this.treeView2.Name = "treeView2";
		this.treeView2.SelectedImageIndex = 0;
		this.treeView2.ShowPlusMinus = false;
		this.treeView2.ShowRootLines = false;
		this.treeView2.Size = new System.Drawing.Size(329, 138);
		this.treeView2.TabIndex = 1;
		this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[15]
		{
			this._tbReplaceEdit, this._tbReplaceDelete, this.toolStripSeparator2, this._tbReplaceByte, this._tbReplaceShort, this._tbReplaceInt, this._tbReplaceLong, this._tbReplaceFloat, this._tbReplaceDouble, this._tbReplaceByteArray,
			this._tbReplaceIntArray, this._tbReplaceLongArray, this._tbReplaceString, this._tbReplaceList, this._tbReplaceCompound
		});
		this.toolStrip2.Location = new System.Drawing.Point(0, 0);
		this.toolStrip2.Name = "toolStrip2";
		this.toolStrip2.Size = new System.Drawing.Size(329, 25);
		this.toolStrip2.TabIndex = 0;
		this.toolStrip2.Text = "toolStrip2";
		this._tbReplaceEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceEdit.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceEdit.Image");
		this._tbReplaceEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceEdit.Name = "_tbReplaceEdit";
		this._tbReplaceEdit.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceEdit.Text = "Edit Selected Tag";
		this._tbReplaceEdit.Click += new System.EventHandler(_tbReplaceEdit_Click);
		this._tbReplaceDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceDelete.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceDelete.Image");
		this._tbReplaceDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceDelete.Name = "_tbReplaceDelete";
		this._tbReplaceDelete.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceDelete.Text = "Delete Selected Tag";
		this._tbReplaceDelete.Click += new System.EventHandler(_tbReplaceDelete_Click);
		this.toolStripSeparator2.Name = "toolStripSeparator2";
		this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
		this._tbReplaceByte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceByte.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceByte.Image");
		this._tbReplaceByte.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceByte.Name = "_tbReplaceByte";
		this._tbReplaceByte.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceByte.Text = "Add Byte Tag";
		this._tbReplaceByte.Click += new System.EventHandler(_tbReplaceByte_Click);
		this._tbReplaceShort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceShort.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceShort.Image");
		this._tbReplaceShort.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceShort.Name = "_tbReplaceShort";
		this._tbReplaceShort.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceShort.Text = "Add Short Tag";
		this._tbReplaceShort.Click += new System.EventHandler(_tbReplaceShort_Click);
		this._tbReplaceInt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceInt.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceInt.Image");
		this._tbReplaceInt.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceInt.Name = "_tbReplaceInt";
		this._tbReplaceInt.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceInt.Text = "Add Int Tag";
		this._tbReplaceInt.Click += new System.EventHandler(_tbReplaceInt_Click);
		this._tbReplaceLong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceLong.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceLong.Image");
		this._tbReplaceLong.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceLong.Name = "_tbReplaceLong";
		this._tbReplaceLong.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceLong.Text = "Add Long Tag";
		this._tbReplaceLong.Click += new System.EventHandler(_tbReplaceLong_Click);
		this._tbReplaceFloat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceFloat.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceFloat.Image");
		this._tbReplaceFloat.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceFloat.Name = "_tbReplaceFloat";
		this._tbReplaceFloat.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceFloat.Text = "Add Float Tag";
		this._tbReplaceFloat.Click += new System.EventHandler(_tbReplaceFloat_Click);
		this._tbReplaceDouble.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceDouble.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceDouble.Image");
		this._tbReplaceDouble.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceDouble.Name = "_tbReplaceDouble";
		this._tbReplaceDouble.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceDouble.Text = "Add Double Tag";
		this._tbReplaceDouble.Click += new System.EventHandler(_tbReplaceDouble_Click);
		this._tbReplaceByteArray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceByteArray.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceByteArray.Image");
		this._tbReplaceByteArray.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceByteArray.Name = "_tbReplaceByteArray";
		this._tbReplaceByteArray.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceByteArray.Text = "Add Byte Array Tag";
		this._tbReplaceByteArray.Click += new System.EventHandler(_tbReplaceByteArray_Click);
		this._tbReplaceIntArray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceIntArray.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceIntArray.Image");
		this._tbReplaceIntArray.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceIntArray.Name = "_tbReplaceIntArray";
		this._tbReplaceIntArray.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceIntArray.Text = "Add Int Array Tag";
		this._tbReplaceIntArray.Click += new System.EventHandler(_tbReplaceIntArray_Click);
		this._tbReplaceLongArray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceLongArray.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceLongArray.Image");
		this._tbReplaceLongArray.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceLongArray.Name = "_tbReplaceLongArray";
		this._tbReplaceLongArray.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceLongArray.Text = "Add Long Array Tag";
		this._tbReplaceLongArray.Click += new System.EventHandler(_tbReplaceLongArray_Click);
		this._tbReplaceString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceString.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceString.Image");
		this._tbReplaceString.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceString.Name = "_tbReplaceString";
		this._tbReplaceString.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceString.Text = "Add String Tag";
		this._tbReplaceString.Click += new System.EventHandler(_tbReplaceString_Click);
		this._tbReplaceList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceList.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceList.Image");
		this._tbReplaceList.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceList.Name = "_tbReplaceList";
		this._tbReplaceList.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceList.Text = "Add List Tag";
		this._tbReplaceList.Click += new System.EventHandler(_tbReplaceList_Click);
		this._tbReplaceCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._tbReplaceCompound.Image = (System.Drawing.Image)resources.GetObject("_tbReplaceCompound.Image");
		this._tbReplaceCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._tbReplaceCompound.Name = "_tbReplaceCompound";
		this._tbReplaceCompound.Size = new System.Drawing.Size(23, 22);
		this._tbReplaceCompound.Text = "Add Compound Tag";
		this._tbReplaceCompound.Click += new System.EventHandler(_tbReplaceCompound_Click);
		this._buttonFind.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonFind.Location = new System.Drawing.Point(550, 251);
		this._buttonFind.Name = "_buttonFind";
		this._buttonFind.Size = new System.Drawing.Size(75, 23);
		this._buttonFind.TabIndex = 2;
		this._buttonFind.Text = "Find Next";
		this._buttonFind.UseVisualStyleBackColor = true;
		this._buttonFind.Click += new System.EventHandler(_buttonFind_Click);
		this._buttonReplace.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonReplace.Location = new System.Drawing.Point(631, 251);
		this._buttonReplace.Name = "_buttonReplace";
		this._buttonReplace.Size = new System.Drawing.Size(75, 23);
		this._buttonReplace.TabIndex = 3;
		this._buttonReplace.Text = "Replace";
		this._buttonReplace.UseVisualStyleBackColor = true;
		this._buttonReplace.Click += new System.EventHandler(_buttonReplace_Click);
		this._buttonReplaceAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this._buttonReplaceAll.Location = new System.Drawing.Point(631, 280);
		this._buttonReplaceAll.Name = "_buttonReplaceAll";
		this._buttonReplaceAll.Size = new System.Drawing.Size(75, 23);
		this._buttonReplaceAll.TabIndex = 4;
		this._buttonReplaceAll.Text = "Replace All";
		this._buttonReplaceAll.UseVisualStyleBackColor = true;
		this._buttonReplaceAll.Click += new System.EventHandler(_buttonReplaceAll_Click);
		this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this._buttonCancel.Location = new System.Drawing.Point(12, 251);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(75, 23);
		this._buttonCancel.TabIndex = 5;
		this._buttonCancel.Text = "Cancel";
		this._buttonCancel.UseVisualStyleBackColor = true;
		this._buttonCancel.Click += new System.EventHandler(_buttonCancel_Click);
		this._explorerStrip.Location = new System.Drawing.Point(0, 0);
		this._explorerStrip.Name = "_explorerStrip";
		this._explorerStrip.Size = new System.Drawing.Size(718, 25);
		this._explorerStrip.TabIndex = 7;
		this._explorerStrip.Text = "toolStrip3";
		this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tableLayoutPanel1.ColumnCount = 2;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
		this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 28);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 1;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(694, 217);
		this.tableLayoutPanel1.TabIndex = 8;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(718, 314);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Controls.Add(this._explorerStrip);
		base.Controls.Add(this._buttonCancel);
		base.Controls.Add(this._buttonReplaceAll);
		base.Controls.Add(this._buttonReplace);
		base.Controls.Add(this._buttonFind);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FindReplace";
		this.Text = "Find and Replace";
		this.groupBox1.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.toolStrip1.ResumeLayout(false);
		this.toolStrip1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		this.toolStrip2.ResumeLayout(false);
		this.toolStrip2.PerformLayout();
		this.tableLayoutPanel1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
