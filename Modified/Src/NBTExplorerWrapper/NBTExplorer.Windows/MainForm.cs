using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NBTExplorer.Controllers;
using NBTExplorer.Model;
using NBTExplorer.Vendor.MultiSelectTreeView;
using NBTModel.Interop;
using Substrate.Nbt;

namespace NBTExplorer.Windows;

public class MainForm : Form
{
	private static Dictionary<TagType, int> _tagIconIndex;

	private NodeTreeController _controller;

	private IconRegistry _iconRegistry;

	private string _openFolderPath;

	private CancelSearchForm _searchForm;

	private SearchStateWin _searchState;

	private IContainer components;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem fileToolStripMenuItem;

	private ToolStripMenuItem searchToolStripMenuItem;

	private ToolStripMenuItem helpToolStripMenuItem;

	private MultiSelectTreeView _nodeTree;

	private ToolStrip toolStrip1;

	private ToolStripButton _buttonOpen;

	private ToolStripButton _buttonSave;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripButton _buttonRename;

	private ToolStripButton _buttonEdit;

	private ToolStripButton _buttonDelete;

	private ToolStripSeparator toolStripSeparator2;

	private ToolStripButton _buttonAddTagByte;

	private ToolStripButton _buttonAddTagShort;

	private ToolStripButton _buttonAddTagInt;

	private ToolStripButton _buttonAddTagLong;

	private ToolStripButton _buttonAddTagFloat;

	private ToolStripButton _buttonAddTagDouble;

	private ToolStripButton _buttonAddTagByteArray;

	private ToolStripButton _buttonAddTagList;

	private ToolStripButton _buttonAddTagCompound;

	private ImageList imageList1;

	private ToolStripButton _buttonAddTagString;

	private ToolStripMenuItem _menuItemAbout;

	private ToolStripMenuItem _menuItemOpen;

	private ToolStripMenuItem _menuItemOpenFolder;

	private ToolStripSeparator toolStripSeparator3;

	private ToolStripMenuItem _menuItemSave;

	private ToolStripSeparator toolStripSeparator4;

	private ToolStripMenuItem _menuItemExit;

	private ToolStripMenuItem _menuItemFind;

	private ToolStripMenuItem _menuItemFindNext;

	private ToolStripSeparator toolStripSeparator5;

	private ToolStripButton _buttonFindNext;

	private ToolStripButton _buttonOpenFolder;

	private ToolStripMenuItem _menuItemOpenMinecraftSaveFolder;

	private ToolStripPanel BottomToolStripPanel;

	private ToolStripPanel TopToolStripPanel;

	private ToolStripPanel RightToolStripPanel;

	private ToolStripPanel LeftToolStripPanel;

	private ToolStripContentPanel ContentPanel;

	private ToolStripButton _buttonAddTagIntArray;

	private ToolStripMenuItem editToolStripMenuItem;

	private ToolStripMenuItem _menuItemCut;

	private ToolStripMenuItem _menuItemCopy;

	private ToolStripMenuItem _menuItemPaste;

	private ToolStripSeparator toolStripSeparator7;

	private ToolStripMenuItem _menuItemRename;

	private ToolStripMenuItem _menuItemEditValue;

	private ToolStripMenuItem _menuItemDelete;

	private ToolStripButton _buttonCut;

	private ToolStripButton _buttonCopy;

	private ToolStripButton _buttonPaste;

	private ToolStripSeparator toolStripSeparator6;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem testToolStripMenuItem;

	private ToolStripMenuItem _menuItemRecentFiles;

	private ToolStripMenuItem _menuItemRecentFolders;

	private ToolStripSeparator toolStripSeparator8;

	private ToolStripButton _buttonRefresh;

	private ToolStripMenuItem _menuItemRefresh;

	private ToolStripSeparator toolStripSeparator9;

	private ToolStripMenuItem replaceToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator10;

	private ToolStripMenuItem _menuItemMoveUp;

	private ToolStripMenuItem _menuItemMoveDown;

	private ToolStripSeparator toolStripSeparator11;

	private ToolStripMenuItem findBlockToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator12;

	private ToolStripMenuItem _menuItemOpenInExplorer;

	private ToolStripButton _buttonAddTagLongArray;

	static MainForm()
	{
		try
		{
			_tagIconIndex = new Dictionary<TagType, int>();
			_tagIconIndex[TagType.TAG_BYTE] = 0;
			_tagIconIndex[TagType.TAG_SHORT] = 1;
			_tagIconIndex[TagType.TAG_INT] = 2;
			_tagIconIndex[TagType.TAG_LONG] = 3;
			_tagIconIndex[TagType.TAG_FLOAT] = 4;
			_tagIconIndex[TagType.TAG_DOUBLE] = 5;
			_tagIconIndex[TagType.TAG_BYTE_ARRAY] = 6;
			_tagIconIndex[TagType.TAG_STRING] = 7;
			_tagIconIndex[TagType.TAG_LIST] = 8;
			_tagIconIndex[TagType.TAG_COMPOUND] = 9;
			_tagIconIndex[TagType.TAG_INT_ARRAY] = 14;
			_tagIconIndex[TagType.TAG_SHORT_ARRAY] = 16;
			_tagIconIndex[TagType.TAG_LONG_ARRAY] = 17;
		}
		catch (Exception e)
		{
			Program.StaticInitFailure(e);
		}
	}

	public MainForm()
	{
		InitializeComponent();
		InitializeIconRegistry();
		FormHandlers.Register();
		NbtClipboardController.Initialize(new NbtClipboardControllerWin());
		_controller = new NodeTreeController(_nodeTree);
		_controller.ConfirmAction += _controller_ConfirmAction;
		_controller.SelectionInvalidated += _controller_SelectionInvalidated;
		base.FormClosing += MainForm_Closing;
		_nodeTree.BeforeExpand += _nodeTree_BeforeExpand;
		_nodeTree.AfterCollapse += _nodeTree_AfterCollapse;
		_nodeTree.AfterSelect += _nodeTree_AfterSelect;
		_nodeTree.NodeMouseDoubleClick += _nodeTree_NodeMouseDoubleClick;
		_nodeTree.NodeMouseClick += _nodeTree_NodeMouseClick;
		_nodeTree.DragEnter += _nodeTree_DragEnter;
		_nodeTree.DragDrop += _nodeTree_DragDrop;
		_buttonOpen.Click += _buttonOpen_Click;
		_buttonOpenFolder.Click += _buttonOpenFolder_Click;
		_buttonSave.Click += _buttonSave_Click;
		_buttonEdit.Click += _buttonEdit_Click;
		_buttonRename.Click += _buttonRename_Click;
		_buttonDelete.Click += _buttonDelete_Click;
		_buttonCopy.Click += _buttonCopy_Click;
		_buttonCut.Click += _buttonCut_Click;
		_buttonPaste.Click += _buttonPaste_Click;
		_buttonAddTagByte.Click += _buttonAddTagByte_Click;
		_buttonAddTagByteArray.Click += _buttonAddTagByteArray_Click;
		_buttonAddTagCompound.Click += _buttonAddTagCompound_Click;
		_buttonAddTagDouble.Click += _buttonAddTagDouble_Click;
		_buttonAddTagFloat.Click += _buttonAddTagFloat_Click;
		_buttonAddTagInt.Click += _buttonAddTagInt_Click;
		_buttonAddTagIntArray.Click += _buttonAddTagIntArray_Click;
		_buttonAddTagList.Click += _buttonAddTagList_Click;
		_buttonAddTagLong.Click += _buttonAddTagLong_Click;
		_buttonAddTagLongArray.Click += _buttonAddTagLongArray_Click;
		_buttonAddTagShort.Click += _buttonAddTagShort_Click;
		_buttonAddTagString.Click += _buttonAddTagString_Click;
		_buttonFindNext.Click += _buttonFindNext_Click;
		_menuItemOpen.Click += _menuItemOpen_Click;
		_menuItemOpenFolder.Click += _menuItemOpenFolder_Click;
		_menuItemOpenMinecraftSaveFolder.Click += _menuItemOpenMinecraftSaveFolder_Click;
		_menuItemSave.Click += _menuItemSave_Click;
		_menuItemExit.Click += _menuItemExit_Click;
		_menuItemEditValue.Click += _menuItemEditValue_Click;
		_menuItemRename.Click += _menuItemRename_Click;
		_menuItemDelete.Click += _menuItemDelete_Click;
		_menuItemCopy.Click += _menuItemCopy_Click;
		_menuItemCut.Click += _menuItemCut_Click;
		_menuItemPaste.Click += _menuItemPaste_Click;
		_menuItemFind.Click += _menuItemFind_Click;
		_menuItemFindNext.Click += _menuItemFindNext_Click;
		_menuItemAbout.Click += _menuItemAbout_Click;
		_menuItemOpenInExplorer.Click += _menuItemOpenInExplorer_Click;
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length > 1)
		{
			string[] array = new string[commandLineArgs.Length - 1];
			Array.Copy(commandLineArgs, 1, array, 0, array.Length);
			OpenPaths(array);
		}
		else
		{
			OpenMinecraftDirectory();
		}
		UpdateOpenMenu();
	}

	private void _menuItemOpenInExplorer_Click(object sender, EventArgs e)
	{
		if (_nodeTree.SelectedNode.Tag is DirectoryDataNode)
		{
			DirectoryDataNode directoryDataNode = _nodeTree.SelectedNode.Tag as DirectoryDataNode;
			try
			{
				string fileName = ((!Interop.IsWindows) ? "file://" : "") + directoryDataNode.NodeDirPath;
				Process.Start(fileName);
			}
			catch (Win32Exception ex)
			{
				MessageBox.Show(ex.Message, "Can't open directory", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void InitializeIconRegistry()
	{
		_iconRegistry = new IconRegistry();
		_iconRegistry.DefaultIcon = 15;
		_iconRegistry.Register(typeof(TagByteDataNode), 0);
		_iconRegistry.Register(typeof(TagShortDataNode), 1);
		_iconRegistry.Register(typeof(TagIntDataNode), 2);
		_iconRegistry.Register(typeof(TagLongDataNode), 3);
		_iconRegistry.Register(typeof(TagFloatDataNode), 4);
		_iconRegistry.Register(typeof(TagDoubleDataNode), 5);
		_iconRegistry.Register(typeof(TagByteArrayDataNode), 6);
		_iconRegistry.Register(typeof(TagStringDataNode), 7);
		_iconRegistry.Register(typeof(TagListDataNode), 8);
		_iconRegistry.Register(typeof(TagCompoundDataNode), 9);
		_iconRegistry.Register(typeof(RegionChunkDataNode), 9);
		_iconRegistry.Register(typeof(DirectoryDataNode), 10);
		_iconRegistry.Register(typeof(RegionFileDataNode), 11);
		_iconRegistry.Register(typeof(CubicRegionDataNode), 11);
		_iconRegistry.Register(typeof(NbtFileDataNode), 12);
		_iconRegistry.Register(typeof(TagIntArrayDataNode), 14);
		_iconRegistry.Register(typeof(TagShortArrayDataNode), 16);
	}

	private void OpenFile()
	{
		if (!ConfirmAction("Open new file anyway?"))
		{
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.RestoreDirectory = true;
		openFileDialog.Multiselect = true;
		openFileDialog.Filter = "All Files|*|NBT Files (*.dat, *.schematic)|*.dat;*.nbt;*.schematic|Region Files (*.mca, *.mcr)|*.mca;*.mcr";
		openFileDialog.FilterIndex = 0;
		using (OpenFileDialog openFileDialog2 = openFileDialog)
		{
			if (openFileDialog2.ShowDialog() == DialogResult.OK)
			{
				OpenPaths(openFileDialog2.FileNames);
			}
		}
		UpdateUI();
	}

	private void OpenFolder()
	{
		if (!ConfirmAction("Open new folder anyway?"))
		{
			return;
		}
		if ((Control.ModifierKeys & Keys.Control) > Keys.None && (Control.ModifierKeys & Keys.Shift) == 0)
		{
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select any file in the directory to open";
			openFileDialog.Filter = "All files (*.*)|*.*";
			if (_openFolderPath != null)
			{
				openFileDialog.InitialDirectory = _openFolderPath;
			}
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				_openFolderPath = Path.GetDirectoryName(openFileDialog.FileName);
				OpenPaths(new string[1] { _openFolderPath });
			}
		}
		else
		{
			using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (_openFolderPath != null)
			{
				folderBrowserDialog.SelectedPath = _openFolderPath;
			}
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				_openFolderPath = folderBrowserDialog.SelectedPath;
				OpenPaths(new string[1] { folderBrowserDialog.SelectedPath });
			}
		}
		UpdateUI();
	}

	private void OpenPaths(string[] paths)
	{
		int num = _controller.OpenPaths(paths);
		for (int i = 0; i < paths.Length; i++)
		{
			_ = paths[i];
		}
		UpdateUI();
		UpdateOpenMenu();
		if (num > 0)
		{
			MessageBox.Show("One or more selected files failed to open.");
		}
	}

	private void OpenMinecraftDirectory()
	{
		if (!ConfirmAction("Open Minecraft save folder anyway?"))
		{
			return;
		}
		try
		{
			string text = Environment.ExpandEnvironmentVariables("%APPDATA%");
			if (!Directory.Exists(text))
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			}
			text = Path.Combine(text, ".minecraft");
			text = Path.Combine(text, "saves");
			if (!Directory.Exists(text))
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
			}
			OpenPaths(new string[1] { text });
		}
		catch (Exception ex)
		{
			MessageBox.Show("Could not open default Minecraft save directory");
			Console.WriteLine(ex.Message);
			try
			{
				OpenPaths(new string[1] { Directory.GetCurrentDirectory() });
			}
			catch (Exception)
			{
				MessageBox.Show("Could not open current directory, this tool is probably not compatible with your platform.");
				Console.WriteLine(ex.Message);
				Application.Exit();
			}
		}
		UpdateUI();
	}

	private TreeNode CreateUnexpandedNode(DataNode node)
	{
		TreeNode treeNode = new TreeNode(node.NodeDisplay);
		treeNode.ImageIndex = _iconRegistry.Lookup(node.GetType());
		treeNode.SelectedImageIndex = treeNode.ImageIndex;
		treeNode.Tag = node;
		if (node.HasUnexpandedChildren || node.Nodes.Count > 0)
		{
			treeNode.Nodes.Add(new TreeNode());
		}
		return treeNode;
	}

	private void ExpandNode(TreeNode node)
	{
		_controller.ExpandNode(node);
		UpdateUI(node.Tag as DataNode);
	}

	private void CollapseNode(TreeNode node)
	{
		_controller.CollapseNode(node);
		UpdateUI(node.Tag as DataNode);
	}

	private bool ConfirmExit()
	{
		if (_controller.CheckModifications() && MessageBox.Show("You currently have unsaved changes.  Close anyway?", "Unsaved Changes", MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			return false;
		}
		return true;
	}

	private bool ConfirmAction(string actionMessage)
	{
		if (_controller.CheckModifications() && MessageBox.Show("You currently have unsaved changes.  " + actionMessage, "Unsaved Changes", MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			return false;
		}
		return true;
	}

	private void _controller_ConfirmAction(object sender, MessageBoxEventArgs e)
	{
		if (_controller.CheckModifications() && MessageBox.Show("You currently have unsaved changes.  " + e.Message, "Unsaved Changes", MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			e.Cancel = true;
		}
	}

	private void SearchNode(TreeNode node)
	{
		if (node == null || !(node.Tag is DataNode))
		{
			return;
		}
		DataNode dataNode = node.Tag as DataNode;
		if (dataNode.CanSearchNode)
		{
			Find find = new Find();
			if (find.ShowDialog() == DialogResult.OK)
			{
				_searchState = new SearchStateWin(this)
				{
					RootNode = dataNode,
					SearchName = find.NameToken,
					SearchValue = find.ValueToken,
					DiscoverCallback = SearchDiscoveryCallback,
					CollapseCallback = SearchCollapseCallback,
					EndCallback = SearchEndCallback
				};
				SearchNextNode();
			}
		}
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
				UpdateUI();
			}
			thread.Join();
		}
	}

	public void SearchDiscoveryCallback(DataNode node)
	{
		_controller.SelectNode(node);
		if (_searchForm != null)
		{
			_searchForm.DialogResult = DialogResult.OK;
			_searchForm = null;
		}
	}

	public void SearchCollapseCallback(DataNode node)
	{
		_controller.CollapseBelow(node);
	}

	public void SearchEndCallback(DataNode node)
	{
		if (_searchForm != null)
		{
			_searchForm.DialogResult = DialogResult.OK;
			_searchForm = null;
		}
		_searchState = null;
		UpdateUI();
		MessageBox.Show("End of results");
	}

	private void UpdateUI()
	{
		TreeNode selectedNode = _nodeTree.SelectedNode;
		if (_nodeTree.SelectedNodes.Count > 1)
		{
			UpdateUI(_nodeTree.SelectedNodes);
			return;
		}
		if (selectedNode != null && selectedNode.Tag is DataNode)
		{
			UpdateUI(selectedNode.Tag as DataNode);
			return;
		}
		DisableButtons(_buttonAddTagByte, _buttonAddTagByteArray, _buttonAddTagCompound, _buttonAddTagDouble, _buttonAddTagFloat, _buttonAddTagInt, _buttonAddTagIntArray, _buttonAddTagList, _buttonAddTagLong, _buttonAddTagLongArray, _buttonAddTagShort, _buttonAddTagString, _buttonCopy, _buttonCut, _buttonDelete, _buttonEdit, _buttonPaste, _buttonRefresh, _buttonRename);
		_buttonSave.Enabled = _controller.CheckModifications();
		_buttonFindNext.Enabled = false;
		DisableMenuItems(_menuItemCopy, _menuItemCut, _menuItemDelete, _menuItemEditValue, _menuItemPaste, _menuItemRefresh, _menuItemRename, _menuItemMoveUp, _menuItemMoveDown);
		_menuItemSave.Enabled = _buttonSave.Enabled;
		_menuItemFind.Enabled = false;
		_menuItemFindNext.Enabled = _searchState != null;
	}

	private void DisableButtons(params ToolStripButton[] buttons)
	{
		foreach (ToolStripButton toolStripButton in buttons)
		{
			toolStripButton.Enabled = false;
		}
	}

	private void DisableMenuItems(params ToolStripMenuItem[] buttons)
	{
		foreach (ToolStripMenuItem toolStripMenuItem in buttons)
		{
			toolStripMenuItem.Enabled = false;
		}
	}

	private void UpdateUI(DataNode node)
	{
		if (node != null)
		{
			_buttonAddTagByte.Enabled = node.CanCreateTag(TagType.TAG_BYTE);
			_buttonAddTagByteArray.Enabled = node.CanCreateTag(TagType.TAG_BYTE_ARRAY);
			_buttonAddTagCompound.Enabled = node.CanCreateTag(TagType.TAG_COMPOUND);
			_buttonAddTagDouble.Enabled = node.CanCreateTag(TagType.TAG_DOUBLE);
			_buttonAddTagFloat.Enabled = node.CanCreateTag(TagType.TAG_FLOAT);
			_buttonAddTagInt.Enabled = node.CanCreateTag(TagType.TAG_INT);
			_buttonAddTagIntArray.Enabled = node.CanCreateTag(TagType.TAG_INT_ARRAY);
			_buttonAddTagList.Enabled = node.CanCreateTag(TagType.TAG_LIST);
			_buttonAddTagLong.Enabled = node.CanCreateTag(TagType.TAG_LONG);
			_buttonAddTagLongArray.Enabled = node.CanCreateTag(TagType.TAG_LONG_ARRAY);
			_buttonAddTagShort.Enabled = node.CanCreateTag(TagType.TAG_SHORT);
			_buttonAddTagString.Enabled = node.CanCreateTag(TagType.TAG_STRING);
			_buttonSave.Enabled = _controller.CheckModifications();
			_buttonCopy.Enabled = node.CanCopyNode && NbtClipboardController.IsInitialized;
			_buttonCut.Enabled = node.CanCutNode && NbtClipboardController.IsInitialized;
			_buttonDelete.Enabled = node.CanDeleteNode;
			_buttonEdit.Enabled = node.CanEditNode;
			_buttonFindNext.Enabled = node.CanSearchNode || _searchState != null;
			_buttonPaste.Enabled = node.CanPasteIntoNode && NbtClipboardController.IsInitialized;
			_buttonRename.Enabled = node.CanRenameNode;
			_buttonRefresh.Enabled = node.CanRefreshNode;
			_menuItemSave.Enabled = _buttonSave.Enabled;
			_menuItemCopy.Enabled = node.CanCopyNode && NbtClipboardController.IsInitialized;
			_menuItemCut.Enabled = node.CanCutNode && NbtClipboardController.IsInitialized;
			_menuItemDelete.Enabled = node.CanDeleteNode;
			_menuItemEditValue.Enabled = node.CanEditNode;
			_menuItemFind.Enabled = node.CanSearchNode;
			_menuItemPaste.Enabled = node.CanPasteIntoNode && NbtClipboardController.IsInitialized;
			_menuItemRename.Enabled = node.CanRenameNode;
			_menuItemRefresh.Enabled = node.CanRefreshNode;
			_menuItemFind.Enabled = node.CanSearchNode;
			_menuItemFindNext.Enabled = _searchState != null;
			_menuItemMoveUp.Enabled = node.CanMoveNodeUp;
			_menuItemMoveDown.Enabled = node.CanMoveNodeDown;
			_menuItemOpenInExplorer.Enabled = node is DirectoryDataNode;
			UpdateUI(_nodeTree.SelectedNodes);
		}
	}

	private void UpdateUI(IList<TreeNode> nodes)
	{
		if (nodes != null)
		{
			_buttonAddTagByte.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateByteNodePred);
			_buttonAddTagShort.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateShortNodePred);
			_buttonAddTagInt.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateIntNodePred);
			_buttonAddTagLong.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateLongNodePred);
			_buttonAddTagFloat.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateFloatNodePred);
			_buttonAddTagDouble.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateDoubleNodePred);
			_buttonAddTagByteArray.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateByteArrayNodePred);
			_buttonAddTagIntArray.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateIntArrayNodePred);
			_buttonAddTagLongArray.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateLongArrayNodePred);
			_buttonAddTagString.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateStringNodePred);
			_buttonAddTagList.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateListNodePred);
			_buttonAddTagCompound.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CreateCompoundNodePred);
			_buttonSave.Enabled = _controller.CheckModifications();
			_buttonRename.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.RenameNodePred);
			_buttonEdit.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.EditNodePred);
			_buttonDelete.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.DeleteNodePred);
			_buttonCut.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CutNodePred) && NbtClipboardController.IsInitialized;
			_buttonCopy.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.CopyNodePred) && NbtClipboardController.IsInitialized;
			_buttonPaste.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.PasteIntoNodePred) && NbtClipboardController.IsInitialized;
			_buttonFindNext.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.SearchNodePred) || _searchState != null;
			_buttonRefresh.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.RefreshNodePred);
			_menuItemSave.Enabled = _buttonSave.Enabled;
			_menuItemRename.Enabled = _buttonRename.Enabled;
			_menuItemEditValue.Enabled = _buttonEdit.Enabled;
			_menuItemDelete.Enabled = _buttonDelete.Enabled;
			_menuItemMoveUp.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.MoveNodeUpPred);
			_menuItemMoveDown.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.MoveNodeDownPred);
			_menuItemCut.Enabled = _buttonCut.Enabled;
			_menuItemCopy.Enabled = _buttonCopy.Enabled;
			_menuItemPaste.Enabled = _buttonPaste.Enabled;
			_menuItemFind.Enabled = _controller.CanOperateOnSelection(NodeTreeController.Predicates.SearchNodePred);
			_menuItemRefresh.Enabled = _buttonRefresh.Enabled;
			_menuItemFindNext.Enabled = _searchState != null;
		}
	}

	private void UpdateOpenMenu()
	{
	}

	private void _controller_SelectionInvalidated(object sender, EventArgs e)
	{
		UpdateUI();
	}

	private ToolStripDropDown BuildRecentEntriesDropDown(StringCollection list)
	{
		if (list == null || list.Count == 0)
		{
			return new ToolStripDropDown();
		}
		ToolStripDropDown toolStripDropDown = new ToolStripDropDown();
		StringEnumerator enumerator = list.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("&" + (toolStripDropDown.Items.Count + 1) + " " + current);
				toolStripMenuItem.Tag = current;
				toolStripMenuItem.Click += _menuItemRecentPaths_Click;
				toolStripDropDown.Items.Add(toolStripMenuItem);
			}
			return toolStripDropDown;
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}

	private void AddPathToHistory(StringCollection list, string entry)
	{
		if (list == null)
		{
			return;
		}
		StringEnumerator enumerator = list.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				if (current == entry)
				{
					list.Remove(current);
					break;
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		while (list.Count >= 5)
		{
			list.RemoveAt(list.Count - 1);
		}
		list.Insert(0, entry);
	}

	private GroupCapabilities CommonCapabilities(IEnumerable<GroupCapabilities> capabilities)
	{
		GroupCapabilities groupCapabilities = GroupCapabilities.All;
		foreach (GroupCapabilities capability in capabilities)
		{
			groupCapabilities &= capability;
		}
		return groupCapabilities;
	}

	private void MainForm_Closing(object sender, CancelEventArgs e)
	{
		if (!ConfirmExit())
		{
			e.Cancel = true;
		}
	}

	private void _nodeTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
	{
		ExpandNode(e.Node);
	}

	private void _nodeTree_AfterCollapse(object sender, TreeViewEventArgs e)
	{
		CollapseNode(e.Node);
	}

	private void _nodeTree_AfterSelect(object sender, TreeViewEventArgs e)
	{
		if (e.Node != null)
		{
			UpdateUI(e.Node.Tag as DataNode);
		}
	}

	private void _nodeTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		_controller.EditNode(e.Node);
	}

	private void _nodeTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			e.Node.ContextMenuStrip = _controller.BuildNodeContextMenu(e.Node, e.Node.Tag as DataNode);
			_nodeTree.SelectedNode = e.Node;
		}
	}

	private void _nodeTree_DragDrop(object sender, DragEventArgs e)
	{
		OpenPaths((string[])e.Data.GetData(DataFormats.FileDrop));
	}

	private void _nodeTree_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.Copy;
		}
	}

	private void _buttonOpen_Click(object sender, EventArgs e)
	{
		OpenFile();
	}

	private void _buttonOpenFolder_Click(object sender, EventArgs e)
	{
		OpenFolder();
	}

	private void _buttonSave_Click(object sender, EventArgs e)
	{
		_controller.Save();
	}

	private void _buttonEdit_Click(object sender, EventArgs e)
	{
		_controller.EditSelection();
	}

	private void _buttonRename_Click(object sender, EventArgs e)
	{
		_controller.RenameSelection();
	}

	private void _buttonDelete_Click(object sender, EventArgs e)
	{
		_controller.DeleteSelection();
	}

	private void _buttonCopy_Click(object sernder, EventArgs e)
	{
		_controller.CopySelection();
	}

	private void _buttonCut_Click(object sernder, EventArgs e)
	{
		_controller.CutSelection();
	}

	private void _buttonPaste_Click(object sernder, EventArgs e)
	{
		_controller.PasteIntoSelection();
	}

	private void _buttonAddTagByteArray_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_BYTE_ARRAY);
	}

	private void _buttonAddTagByte_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_BYTE);
	}

	private void _buttonAddTagCompound_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_COMPOUND);
	}

	private void _buttonAddTagDouble_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_DOUBLE);
	}

	private void _buttonAddTagFloat_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_FLOAT);
	}

	private void _buttonAddTagInt_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_INT);
	}

	private void _buttonAddTagIntArray_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_INT_ARRAY);
	}

	private void _buttonAddTagList_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_LIST);
	}

	private void _buttonAddTagLong_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_LONG);
	}

	private void _buttonAddTagLongArray_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_LONG_ARRAY);
	}

	private void _buttonAddTagShort_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_SHORT);
	}

	private void _buttonAddTagString_Click(object sender, EventArgs e)
	{
		_controller.CreateNode(TagType.TAG_STRING);
	}

	private void _buttonFindNext_Click(object sender, EventArgs e)
	{
		if (_searchState != null)
		{
			SearchNextNode();
		}
		else
		{
			SearchNode(_nodeTree.SelectedNode);
		}
	}

	private void _buttonRefresh_Click(object sender, EventArgs e)
	{
		_controller.RefreshSelection();
	}

	private void _menuItemOpen_Click(object sender, EventArgs e)
	{
		OpenFile();
	}

	private void _menuItemOpenFolder_Click(object sender, EventArgs e)
	{
		OpenFolder();
	}

	private void _menuItemOpenMinecraftSaveFolder_Click(object sender, EventArgs e)
	{
		OpenMinecraftDirectory();
	}

	private void _menuItemSave_Click(object sender, EventArgs e)
	{
		_controller.Save();
	}

	private void _menuItemExit_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void _menuItemEditValue_Click(object sender, EventArgs e)
	{
		_controller.EditSelection();
	}

	private void _menuItemRename_Click(object sender, EventArgs e)
	{
		_controller.RenameSelection();
	}

	private void _menuItemDelete_Click(object sender, EventArgs e)
	{
		_controller.DeleteSelection();
	}

	private void _menuItemCopy_Click(object sender, EventArgs e)
	{
		_controller.CopySelection();
	}

	private void _menuItemCut_Click(object sender, EventArgs e)
	{
		_controller.CutSelection();
	}

	private void _menuItemPaste_Click(object sender, EventArgs e)
	{
		_controller.PasteIntoSelection();
	}

	private void _menuItemFind_Click(object sender, EventArgs e)
	{
		SearchNode(_nodeTree.SelectedNode);
	}

	private void _menuItemFindNext_Click(object sender, EventArgs e)
	{
		SearchNextNode();
	}

	private void _menuItemAbout_Click(object sender, EventArgs e)
	{
		new About().ShowDialog();
	}

	private void _menuItemRecentPaths_Click(object sender, EventArgs e)
	{
		if (sender is ToolStripMenuItem toolStripMenuItem && toolStripMenuItem.Tag is string)
		{
			OpenPaths(new string[1] { toolStripMenuItem.Tag as string });
		}
	}

	private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
	{
		_controller.RefreshSelection();
	}

	private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Form form = new FindReplace(this, _controller, _nodeTree.SelectedNode.Tag as DataNode);
		form.Show();
	}

	private void _menuItemMoveUp_Click(object sender, EventArgs e)
	{
		_controller.MoveSelectionUp();
	}

	private void _menuItemMoveDown_Click(object sender, EventArgs e)
	{
		_controller.MoveSelectionDown();
	}

	private void findBlockToolStripMenuItem_Click(object sender, EventArgs e)
	{
		FindBlock findBlock = new FindBlock(_nodeTree.SelectedNode.Tag as DataNode);
		if (findBlock.ShowDialog() == DialogResult.OK)
		{
			if (findBlock.Result != null)
			{
				_controller.SelectNode(findBlock.Result);
				_controller.ExpandSelectedNode();
				_controller.ScrollNode(findBlock.Result);
			}
			else
			{
				MessageBox.Show("Chunk not found.");
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NBTExplorer.Windows.MainForm));
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemOpenMinecraftSaveFolder = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
		this._menuItemOpenInExplorer = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this._menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this._menuItemRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemRecentFolders = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
		this._menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
		this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemCut = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
		this._menuItemRename = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemEditValue = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
		this._menuItemMoveUp = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemMoveDown = new System.Windows.Forms.ToolStripMenuItem();
		this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemFind = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemFindNext = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
		this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
		this.findBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this._menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		this._buttonOpen = new System.Windows.Forms.ToolStripButton();
		this._buttonOpenFolder = new System.Windows.Forms.ToolStripButton();
		this._buttonSave = new System.Windows.Forms.ToolStripButton();
		this._buttonRefresh = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this._buttonCut = new System.Windows.Forms.ToolStripButton();
		this._buttonCopy = new System.Windows.Forms.ToolStripButton();
		this._buttonPaste = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
		this._buttonRename = new System.Windows.Forms.ToolStripButton();
		this._buttonEdit = new System.Windows.Forms.ToolStripButton();
		this._buttonDelete = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this._buttonAddTagByte = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagShort = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagInt = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagLong = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagFloat = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagDouble = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagByteArray = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagIntArray = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagLongArray = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagString = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagList = new System.Windows.Forms.ToolStripButton();
		this._buttonAddTagCompound = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
		this._buttonFindNext = new System.Windows.Forms.ToolStripButton();
		this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
		this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
		this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
		this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
		this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this._nodeTree = new NBTExplorer.Vendor.MultiSelectTreeView.MultiSelectTreeView();
		this.menuStrip1.SuspendLayout();
		this.toolStrip1.SuspendLayout();
		this.contextMenuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.fileToolStripMenuItem, this.editToolStripMenuItem, this.searchToolStripMenuItem, this.helpToolStripMenuItem });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new System.Drawing.Size(638, 24);
		this.menuStrip1.TabIndex = 0;
		this.menuStrip1.Text = "menuStrip1";
		this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[13]
		{
			this._menuItemOpen, this._menuItemOpenFolder, this._menuItemOpenMinecraftSaveFolder, this.toolStripSeparator12, this._menuItemOpenInExplorer, this.toolStripSeparator3, this._menuItemSave, this._menuItemRefresh, this.toolStripSeparator4, this._menuItemRecentFiles,
			this._menuItemRecentFolders, this.toolStripSeparator8, this._menuItemExit
		});
		this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
		this.fileToolStripMenuItem.Text = "&File";
		this._menuItemOpen.Image = (System.Drawing.Image)resources.GetObject("_menuItemOpen.Image");
		this._menuItemOpen.Name = "_menuItemOpen";
		this._menuItemOpen.ShortcutKeys = System.Windows.Forms.Keys.O | System.Windows.Forms.Keys.Control;
		this._menuItemOpen.Size = new System.Drawing.Size(233, 22);
		this._menuItemOpen.Text = "&Open...";
		this._menuItemOpenFolder.Image = (System.Drawing.Image)resources.GetObject("_menuItemOpenFolder.Image");
		this._menuItemOpenFolder.Name = "_menuItemOpenFolder";
		this._menuItemOpenFolder.ShortcutKeys = System.Windows.Forms.Keys.O | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control;
		this._menuItemOpenFolder.Size = new System.Drawing.Size(233, 22);
		this._menuItemOpenFolder.Text = "Open &Folder...";
		this._menuItemOpenMinecraftSaveFolder.Name = "_menuItemOpenMinecraftSaveFolder";
		this._menuItemOpenMinecraftSaveFolder.Size = new System.Drawing.Size(233, 22);
		this._menuItemOpenMinecraftSaveFolder.Text = "Open &Minecraft Save Folder";
		this.toolStripSeparator12.Name = "toolStripSeparator12";
		this.toolStripSeparator12.Size = new System.Drawing.Size(230, 6);
		this._menuItemOpenInExplorer.Enabled = false;
		this._menuItemOpenInExplorer.Name = "_menuItemOpenInExplorer";
		this._menuItemOpenInExplorer.ShortcutKeys = System.Windows.Forms.Keys.E | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control;
		this._menuItemOpenInExplorer.Size = new System.Drawing.Size(233, 22);
		this._menuItemOpenInExplorer.Text = "Open in &Explorer";
		this.toolStripSeparator3.Name = "toolStripSeparator3";
		this.toolStripSeparator3.Size = new System.Drawing.Size(230, 6);
		this._menuItemSave.Image = (System.Drawing.Image)resources.GetObject("_menuItemSave.Image");
		this._menuItemSave.Name = "_menuItemSave";
		this._menuItemSave.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
		this._menuItemSave.Size = new System.Drawing.Size(233, 22);
		this._menuItemSave.Text = "&Save";
		this._menuItemRefresh.Image = (System.Drawing.Image)resources.GetObject("_menuItemRefresh.Image");
		this._menuItemRefresh.Name = "_menuItemRefresh";
		this._menuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
		this._menuItemRefresh.Size = new System.Drawing.Size(233, 22);
		this._menuItemRefresh.Text = "Refresh";
		this._menuItemRefresh.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
		this.toolStripSeparator4.Name = "toolStripSeparator4";
		this.toolStripSeparator4.Size = new System.Drawing.Size(230, 6);
		this._menuItemRecentFiles.Name = "_menuItemRecentFiles";
		this._menuItemRecentFiles.Size = new System.Drawing.Size(233, 22);
		this._menuItemRecentFiles.Text = "Recent Files";
		this._menuItemRecentFolders.Name = "_menuItemRecentFolders";
		this._menuItemRecentFolders.Size = new System.Drawing.Size(233, 22);
		this._menuItemRecentFolders.Text = "Recent Folders";
		this.toolStripSeparator8.Name = "toolStripSeparator8";
		this.toolStripSeparator8.Size = new System.Drawing.Size(230, 6);
		this._menuItemExit.Image = (System.Drawing.Image)resources.GetObject("_menuItemExit.Image");
		this._menuItemExit.Name = "_menuItemExit";
		this._menuItemExit.ShortcutKeys = System.Windows.Forms.Keys.F4 | System.Windows.Forms.Keys.Alt;
		this._menuItemExit.Size = new System.Drawing.Size(233, 22);
		this._menuItemExit.Text = "E&xit";
		this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[10] { this._menuItemCut, this._menuItemCopy, this._menuItemPaste, this.toolStripSeparator7, this._menuItemRename, this._menuItemEditValue, this._menuItemDelete, this.toolStripSeparator10, this._menuItemMoveUp, this._menuItemMoveDown });
		this.editToolStripMenuItem.Name = "editToolStripMenuItem";
		this.editToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Control;
		this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
		this.editToolStripMenuItem.Text = "&Edit";
		this._menuItemCut.Image = (System.Drawing.Image)resources.GetObject("_menuItemCut.Image");
		this._menuItemCut.Name = "_menuItemCut";
		this._menuItemCut.ShortcutKeys = System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Control;
		this._menuItemCut.Size = new System.Drawing.Size(203, 22);
		this._menuItemCut.Text = "Cu&t";
		this._menuItemCopy.Image = (System.Drawing.Image)resources.GetObject("_menuItemCopy.Image");
		this._menuItemCopy.Name = "_menuItemCopy";
		this._menuItemCopy.ShortcutKeys = System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control;
		this._menuItemCopy.Size = new System.Drawing.Size(203, 22);
		this._menuItemCopy.Text = "&Copy";
		this._menuItemPaste.Image = (System.Drawing.Image)resources.GetObject("_menuItemPaste.Image");
		this._menuItemPaste.Name = "_menuItemPaste";
		this._menuItemPaste.ShortcutKeys = System.Windows.Forms.Keys.V | System.Windows.Forms.Keys.Control;
		this._menuItemPaste.Size = new System.Drawing.Size(203, 22);
		this._menuItemPaste.Text = "&Paste";
		this.toolStripSeparator7.Name = "toolStripSeparator7";
		this.toolStripSeparator7.Size = new System.Drawing.Size(200, 6);
		this._menuItemRename.Image = (System.Drawing.Image)resources.GetObject("_menuItemRename.Image");
		this._menuItemRename.Name = "_menuItemRename";
		this._menuItemRename.ShortcutKeys = System.Windows.Forms.Keys.R | System.Windows.Forms.Keys.Control;
		this._menuItemRename.Size = new System.Drawing.Size(203, 22);
		this._menuItemRename.Text = "&Rename";
		this._menuItemEditValue.Image = (System.Drawing.Image)resources.GetObject("_menuItemEditValue.Image");
		this._menuItemEditValue.Name = "_menuItemEditValue";
		this._menuItemEditValue.ShortcutKeys = System.Windows.Forms.Keys.E | System.Windows.Forms.Keys.Control;
		this._menuItemEditValue.Size = new System.Drawing.Size(203, 22);
		this._menuItemEditValue.Text = "&Edit Value";
		this._menuItemDelete.Image = (System.Drawing.Image)resources.GetObject("_menuItemDelete.Image");
		this._menuItemDelete.Name = "_menuItemDelete";
		this._menuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
		this._menuItemDelete.Size = new System.Drawing.Size(203, 22);
		this._menuItemDelete.Text = "&Delete";
		this.toolStripSeparator10.Name = "toolStripSeparator10";
		this.toolStripSeparator10.Size = new System.Drawing.Size(200, 6);
		this._menuItemMoveUp.Image = (System.Drawing.Image)resources.GetObject("_menuItemMoveUp.Image");
		this._menuItemMoveUp.Name = "_menuItemMoveUp";
		this._menuItemMoveUp.ShortcutKeys = System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Control;
		this._menuItemMoveUp.Size = new System.Drawing.Size(203, 22);
		this._menuItemMoveUp.Text = "Move &Up";
		this._menuItemMoveUp.Click += new System.EventHandler(_menuItemMoveUp_Click);
		this._menuItemMoveDown.Image = (System.Drawing.Image)resources.GetObject("_menuItemMoveDown.Image");
		this._menuItemMoveDown.Name = "_menuItemMoveDown";
		this._menuItemMoveDown.ShortcutKeys = System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Control;
		this._menuItemMoveDown.Size = new System.Drawing.Size(203, 22);
		this._menuItemMoveDown.Text = "Move Do&wn";
		this._menuItemMoveDown.Click += new System.EventHandler(_menuItemMoveDown_Click);
		this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { this._menuItemFind, this._menuItemFindNext, this.toolStripSeparator9, this.replaceToolStripMenuItem, this.toolStripSeparator11, this.findBlockToolStripMenuItem });
		this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
		this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
		this.searchToolStripMenuItem.Text = "&Search";
		this._menuItemFind.Image = (System.Drawing.Image)resources.GetObject("_menuItemFind.Image");
		this._menuItemFind.Name = "_menuItemFind";
		this._menuItemFind.ShortcutKeys = System.Windows.Forms.Keys.F | System.Windows.Forms.Keys.Control;
		this._menuItemFind.Size = new System.Drawing.Size(167, 22);
		this._menuItemFind.Text = "&Find...";
		this._menuItemFindNext.Image = (System.Drawing.Image)resources.GetObject("_menuItemFindNext.Image");
		this._menuItemFindNext.Name = "_menuItemFindNext";
		this._menuItemFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
		this._menuItemFindNext.Size = new System.Drawing.Size(167, 22);
		this._menuItemFindNext.Text = "Find &Next";
		this.toolStripSeparator9.Name = "toolStripSeparator9";
		this.toolStripSeparator9.Size = new System.Drawing.Size(164, 6);
		this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
		this.replaceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.H | System.Windows.Forms.Keys.Control;
		this.replaceToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
		this.replaceToolStripMenuItem.Text = "&Replace...";
		this.replaceToolStripMenuItem.Click += new System.EventHandler(replaceToolStripMenuItem_Click);
		this.toolStripSeparator11.Name = "toolStripSeparator11";
		this.toolStripSeparator11.Size = new System.Drawing.Size(164, 6);
		this.findBlockToolStripMenuItem.Name = "findBlockToolStripMenuItem";
		this.findBlockToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
		this.findBlockToolStripMenuItem.Text = "&Chunk Finder...";
		this.findBlockToolStripMenuItem.Click += new System.EventHandler(findBlockToolStripMenuItem_Click);
		this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this._menuItemAbout });
		this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
		this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
		this.helpToolStripMenuItem.Text = "&Help";
		this._menuItemAbout.Image = (System.Drawing.Image)resources.GetObject("_menuItemAbout.Image");
		this._menuItemAbout.Name = "_menuItemAbout";
		this._menuItemAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
		this._menuItemAbout.Size = new System.Drawing.Size(126, 22);
		this._menuItemAbout.Text = "&About";
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
		this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[27]
		{
			this._buttonOpen, this._buttonOpenFolder, this._buttonSave, this._buttonRefresh, this.toolStripSeparator1, this._buttonCut, this._buttonCopy, this._buttonPaste, this.toolStripSeparator6, this._buttonRename,
			this._buttonEdit, this._buttonDelete, this.toolStripSeparator2, this._buttonAddTagByte, this._buttonAddTagShort, this._buttonAddTagInt, this._buttonAddTagLong, this._buttonAddTagFloat, this._buttonAddTagDouble, this._buttonAddTagByteArray,
			this._buttonAddTagIntArray, this._buttonAddTagLongArray, this._buttonAddTagString, this._buttonAddTagList, this._buttonAddTagCompound, this.toolStripSeparator5, this._buttonFindNext
		});
		this.toolStrip1.Location = new System.Drawing.Point(0, 24);
		this.toolStrip1.Name = "toolStrip1";
		this.toolStrip1.Size = new System.Drawing.Size(638, 25);
		this.toolStrip1.Stretch = true;
		this.toolStrip1.TabIndex = 0;
		this._buttonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonOpen.Image = (System.Drawing.Image)resources.GetObject("_buttonOpen.Image");
		this._buttonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonOpen.Name = "_buttonOpen";
		this._buttonOpen.Size = new System.Drawing.Size(23, 22);
		this._buttonOpen.Text = "Open NBT Data Source";
		this._buttonOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonOpenFolder.Image = (System.Drawing.Image)resources.GetObject("_buttonOpenFolder.Image");
		this._buttonOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonOpenFolder.Name = "_buttonOpenFolder";
		this._buttonOpenFolder.Size = new System.Drawing.Size(23, 22);
		this._buttonOpenFolder.Text = "Open Folder";
		this._buttonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonSave.Image = (System.Drawing.Image)resources.GetObject("_buttonSave.Image");
		this._buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonSave.Name = "_buttonSave";
		this._buttonSave.Size = new System.Drawing.Size(23, 22);
		this._buttonSave.Text = "Save All Modified Tags";
		this._buttonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonRefresh.Image = (System.Drawing.Image)resources.GetObject("_buttonRefresh.Image");
		this._buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonRefresh.Name = "_buttonRefresh";
		this._buttonRefresh.Size = new System.Drawing.Size(23, 22);
		this._buttonRefresh.Text = "Refresh Content From Disk";
		this._buttonRefresh.Click += new System.EventHandler(_buttonRefresh_Click);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
		this._buttonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonCut.Image = (System.Drawing.Image)resources.GetObject("_buttonCut.Image");
		this._buttonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonCut.Name = "_buttonCut";
		this._buttonCut.Size = new System.Drawing.Size(23, 22);
		this._buttonCut.Text = "Cut";
		this._buttonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonCopy.Image = (System.Drawing.Image)resources.GetObject("_buttonCopy.Image");
		this._buttonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonCopy.Name = "_buttonCopy";
		this._buttonCopy.Size = new System.Drawing.Size(23, 22);
		this._buttonCopy.Text = "Copy";
		this._buttonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonPaste.Image = (System.Drawing.Image)resources.GetObject("_buttonPaste.Image");
		this._buttonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonPaste.Name = "_buttonPaste";
		this._buttonPaste.Size = new System.Drawing.Size(23, 22);
		this._buttonPaste.Text = "Paste";
		this.toolStripSeparator6.Name = "toolStripSeparator6";
		this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
		this._buttonRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonRename.Image = (System.Drawing.Image)resources.GetObject("_buttonRename.Image");
		this._buttonRename.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonRename.Name = "_buttonRename";
		this._buttonRename.Size = new System.Drawing.Size(23, 22);
		this._buttonRename.Text = "Rename Tag";
		this._buttonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonEdit.Image = (System.Drawing.Image)resources.GetObject("_buttonEdit.Image");
		this._buttonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonEdit.Name = "_buttonEdit";
		this._buttonEdit.Size = new System.Drawing.Size(23, 22);
		this._buttonEdit.Text = "Edit Tag Value";
		this._buttonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonDelete.Image = (System.Drawing.Image)resources.GetObject("_buttonDelete.Image");
		this._buttonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonDelete.Name = "_buttonDelete";
		this._buttonDelete.Size = new System.Drawing.Size(23, 22);
		this._buttonDelete.Text = "Delete Tag";
		this.toolStripSeparator2.Name = "toolStripSeparator2";
		this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
		this._buttonAddTagByte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagByte.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagByte.Image");
		this._buttonAddTagByte.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagByte.Name = "_buttonAddTagByte";
		this._buttonAddTagByte.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagByte.Text = "Add Byte Tag";
		this._buttonAddTagShort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagShort.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagShort.Image");
		this._buttonAddTagShort.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagShort.Name = "_buttonAddTagShort";
		this._buttonAddTagShort.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagShort.Text = "Add Short Tag";
		this._buttonAddTagInt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagInt.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagInt.Image");
		this._buttonAddTagInt.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagInt.Name = "_buttonAddTagInt";
		this._buttonAddTagInt.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagInt.Text = "Add Int Tag";
		this._buttonAddTagLong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagLong.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagLong.Image");
		this._buttonAddTagLong.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagLong.Name = "_buttonAddTagLong";
		this._buttonAddTagLong.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagLong.Text = "Add Long Tag";
		this._buttonAddTagFloat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagFloat.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagFloat.Image");
		this._buttonAddTagFloat.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagFloat.Name = "_buttonAddTagFloat";
		this._buttonAddTagFloat.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagFloat.Text = "Add Float Tag";
		this._buttonAddTagDouble.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagDouble.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagDouble.Image");
		this._buttonAddTagDouble.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagDouble.Name = "_buttonAddTagDouble";
		this._buttonAddTagDouble.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagDouble.Text = "Add Double Tag";
		this._buttonAddTagByteArray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagByteArray.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagByteArray.Image");
		this._buttonAddTagByteArray.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagByteArray.Name = "_buttonAddTagByteArray";
		this._buttonAddTagByteArray.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagByteArray.Text = "Add Byte Array Tag";
		this._buttonAddTagIntArray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagIntArray.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagIntArray.Image");
		this._buttonAddTagIntArray.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this._buttonAddTagIntArray.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagIntArray.Name = "_buttonAddTagIntArray";
		this._buttonAddTagIntArray.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagIntArray.Text = "Add Int Array Tag";
		this._buttonAddTagLongArray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagLongArray.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagLongArray.Image");
		this._buttonAddTagLongArray.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this._buttonAddTagLongArray.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagLongArray.Name = "_buttonAddTagLongArray";
		this._buttonAddTagLongArray.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagLongArray.Text = "Add Long Array Tag";
		this._buttonAddTagString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagString.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagString.Image");
		this._buttonAddTagString.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagString.Name = "_buttonAddTagString";
		this._buttonAddTagString.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagString.Text = "Add String Tag";
		this._buttonAddTagList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagList.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagList.Image");
		this._buttonAddTagList.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagList.Name = "_buttonAddTagList";
		this._buttonAddTagList.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagList.Text = "Add List Tag";
		this._buttonAddTagCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonAddTagCompound.Image = (System.Drawing.Image)resources.GetObject("_buttonAddTagCompound.Image");
		this._buttonAddTagCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonAddTagCompound.Name = "_buttonAddTagCompound";
		this._buttonAddTagCompound.Size = new System.Drawing.Size(23, 22);
		this._buttonAddTagCompound.Text = "Add Compound Tag";
		this.toolStripSeparator5.Name = "toolStripSeparator5";
		this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
		this._buttonFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this._buttonFindNext.Image = (System.Drawing.Image)resources.GetObject("_buttonFindNext.Image");
		this._buttonFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
		this._buttonFindNext.Name = "_buttonFindNext";
		this._buttonFindNext.Size = new System.Drawing.Size(23, 22);
		this._buttonFindNext.Text = "Find / Find Next";
		this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
		this.BottomToolStripPanel.Name = "BottomToolStripPanel";
		this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
		this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
		this.TopToolStripPanel.Name = "TopToolStripPanel";
		this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
		this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
		this.RightToolStripPanel.Name = "RightToolStripPanel";
		this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
		this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
		this.LeftToolStripPanel.Name = "LeftToolStripPanel";
		this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
		this.ContentPanel.Size = new System.Drawing.Size(562, 376);
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.testToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(97, 26);
		this.testToolStripMenuItem.Name = "testToolStripMenuItem";
		this.testToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
		this.testToolStripMenuItem.Text = "Test";
		this._nodeTree.AllowDrop = true;
		this._nodeTree.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this._nodeTree.ImageIndex = 0;
		this._nodeTree.ImageList = this.imageList1;
		this._nodeTree.ItemHeight = 18;
		this._nodeTree.Location = new System.Drawing.Point(0, 49);
		this._nodeTree.Margin = new System.Windows.Forms.Padding(0);
		this._nodeTree.Name = "_nodeTree";
		this._nodeTree.SelectedImageIndex = 0;
		this._nodeTree.SelectedNodes = (System.Collections.Generic.List<System.Windows.Forms.TreeNode>)resources.GetObject("_nodeTree.SelectedNodes");
		this._nodeTree.Size = new System.Drawing.Size(638, 374);
		this._nodeTree.TabIndex = 0;
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(638, 423);
		base.Controls.Add(this.toolStrip1);
		base.Controls.Add(this._nodeTree);
		base.Controls.Add(this.menuStrip1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MainMenuStrip = this.menuStrip1;
		base.Name = "MainForm";
		this.Text = "NBTExplorer";
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.toolStrip1.ResumeLayout(false);
		this.toolStrip1.PerformLayout();
		this.contextMenuStrip1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
