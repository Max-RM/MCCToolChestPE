using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NBTExplorer.Model;
using NBTExplorer.Vendor.MultiSelectTreeView;
using NBTExplorer.Windows;
using NBTExplorerWrapper.Properties;
using Substrate.Nbt;

namespace NBTExplorer.Controllers;

public class NodeTreeController
{
	public delegate bool DataNodePredicate(DataNode dataNode, out GroupCapabilities caps);

	public static class Predicates
	{
		public static bool CreateByteNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_BYTE) ?? false;
		}

		public static bool CreateShortNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_SHORT) ?? false;
		}

		public static bool CreateIntNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_INT) ?? false;
		}

		public static bool CreateLongNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_LONG) ?? false;
		}

		public static bool CreateFloatNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_FLOAT) ?? false;
		}

		public static bool CreateDoubleNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_DOUBLE) ?? false;
		}

		public static bool CreateByteArrayNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_BYTE_ARRAY) ?? false;
		}

		public static bool CreateIntArrayNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_INT_ARRAY) ?? false;
		}

		public static bool CreateLongArrayNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_LONG_ARRAY) ?? false;
		}

		public static bool CreateStringNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_STRING) ?? false;
		}

		public static bool CreateListNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_LIST) ?? false;
		}

		public static bool CreateCompoundNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = GroupCapabilities.Single;
			return dataNode?.CanCreateTag(TagType.TAG_COMPOUND) ?? false;
		}

		public static bool RenameNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.RenameNodeCapabilities;
			return dataNode?.CanRenameNode ?? false;
		}

		public static bool EditNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.EditNodeCapabilities;
			return dataNode?.CanEditNode ?? false;
		}

		public static bool DeleteNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.DeleteNodeCapabilities;
			return dataNode?.CanDeleteNode ?? false;
		}

		public static bool MoveNodeUpPred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.ReorderNodeCapabilities;
			return dataNode?.CanMoveNodeUp ?? false;
		}

		public static bool MoveNodeDownPred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.ReorderNodeCapabilities;
			return dataNode?.CanMoveNodeDown ?? false;
		}

		public static bool CutNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.CutNodeCapabilities;
			return dataNode?.CanCutNode ?? false;
		}

		public static bool CopyNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.CopyNodeCapabilities;
			return dataNode?.CanCopyNode ?? false;
		}

		public static bool PasteIntoNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.PasteIntoNodeCapabilities;
			return dataNode?.CanPasteIntoNode ?? false;
		}

		public static bool SearchNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.SearchNodeCapabilites;
			return dataNode?.CanSearchNode ?? false;
		}

		public static bool ReorderNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.ReorderNodeCapabilities;
			return dataNode?.CanReoderNode ?? false;
		}

		public static bool RefreshNodePred(DataNode dataNode, out GroupCapabilities caps)
		{
			caps = dataNode.RefreshNodeCapabilites;
			return dataNode?.CanRefreshNode ?? false;
		}
	}

	public static Dictionary<string, string> entityLookups = new Dictionary<string, string>();

	private TreeView _nodeTree;

	private MultiSelectTreeView _multiTree;

	private IconRegistry _iconRegistry;

	private RootDataNode _rootData;

	public RootDataNode Root => _rootData;

	public TreeView Tree => _nodeTree;

	public IconRegistry IconRegistry => _iconRegistry;

	public ImageList IconList => _multiTree.ImageList;

	public bool ShowVirtualRoot { get; set; }

	public string VirtualRootDisplay
	{
		get
		{
			return _rootData.NodeDisplay;
		}
		set
		{
			_rootData.SetDisplayName(value);
			if (ShowVirtualRoot && _nodeTree.Nodes.Count > 0)
			{
				UpdateNodeText(_nodeTree.Nodes[0]);
			}
		}
	}

	public TreeNode SelectedNode
	{
		get
		{
			if (_multiTree != null)
			{
				return _multiTree.SelectedNode;
			}
			return _nodeTree.SelectedNode;
		}
	}

	public event EventHandler SelectionInvalidated;

	public event EventHandler<MessageBoxEventArgs> ConfirmAction;

	public NodeTreeController(TreeView nodeTree)
	{
		_nodeTree = nodeTree;
		nodeTree.TreeViewNodeSorter = new NodeTreeComparer();
		_multiTree = nodeTree as MultiSelectTreeView;
		InitializeIconRegistry();
		ShowVirtualRoot = true;
	}

	protected virtual void OnSelectionInvalidated(EventArgs e)
	{
		if (this.SelectionInvalidated != null)
		{
			this.SelectionInvalidated(this, e);
		}
	}

	private void OnSelectionInvalidated()
	{
		OnSelectionInvalidated(EventArgs.Empty);
	}

	protected virtual void OnConfirmAction(MessageBoxEventArgs e)
	{
		if (this.ConfirmAction != null)
		{
			this.ConfirmAction(this, e);
		}
	}

	private bool OnConfirmAction(string message)
	{
		MessageBoxEventArgs e = new MessageBoxEventArgs(message);
		OnConfirmAction(e);
		return !e.Cancel;
	}

	public void Save()
	{
		foreach (TreeNode node in _nodeTree.Nodes)
		{
			if (node.Tag is DataNode dataNode)
			{
				dataNode.Save();
			}
		}
		OnSelectionInvalidated();
	}

	public DataNode GetExistingNode()
	{
		DataNode result = null;
		if (_nodeTree.Nodes.Count > 0)
		{
			result = _nodeTree.Nodes[0].Tag as DataNode;
		}
		return result;
	}

	public void OpenExistingNode(DataNode node)
	{
		_nodeTree.Nodes.Clear();
		if (node != null)
		{
			_nodeTree.Nodes.Add(CreateUnexpandedNode(node));
			if (_nodeTree.Nodes.Count > 0)
			{
				_nodeTree.Nodes[0].Expand();
			}
		}
	}

	public int OpenPaths(string[] paths)
	{
		_nodeTree.Nodes.Clear();
		int num = 0;
		foreach (string path in paths)
		{
			if (Directory.Exists(path))
			{
				DirectoryDataNode node = new DirectoryDataNode(path);
				_nodeTree.Nodes.Add(CreateUnexpandedNode(node));
			}
			else
			{
				if (!File.Exists(path))
				{
					continue;
				}
				DataNode dataNode = null;
				foreach (KeyValuePair<Type, FileTypeRecord> registeredType in FileTypeRegistry.RegisteredTypes)
				{
					if (registeredType.Value.NamePatternTest(path))
					{
						dataNode = registeredType.Value.NodeCreate(path);
					}
				}
				if (dataNode != null)
				{
					_nodeTree.Nodes.Add(CreateUnexpandedNode(dataNode));
				}
				else
				{
					num++;
				}
			}
		}
		if (_nodeTree.Nodes.Count > 0)
		{
			_nodeTree.Nodes[0].Expand();
		}
		OnSelectionInvalidated();
		return num;
	}

	public void CreateNode(TreeNode node, TagType type)
	{
		if (node != null && node.Tag is DataNode)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (dataNode.CanCreateTag(type) && dataNode.CreateNode(type))
			{
				node.Text = dataNode.NodeDisplay;
				RefreshChildNodes(node, dataNode);
				OnSelectionInvalidated();
			}
		}
	}

	public void CreateNode(TagType type)
	{
		if (SelectedNode != null && _nodeTree.Nodes.Count != 0)
		{
			if (SelectedNode == null)
			{
				CreateNode(_nodeTree.Nodes[0], type);
			}
			else
			{
				CreateNode(SelectedNode, type);
			}
		}
	}

	public void DeleteNode(TreeNode node)
	{
		if (node != null && node.Tag is DataNode)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (dataNode.CanDeleteNode && dataNode.DeleteNode())
			{
				UpdateNodeText(node.Parent);
				node.Remove();
				RemoveNodeFromSelection(node);
				OnSelectionInvalidated();
			}
		}
	}

	private bool DeleteNode(IList<TreeNode> nodes)
	{
		bool? elideChildren = null;
		if (!CanOperateOnNodesEx(nodes, Predicates.DeleteNodePred, out elideChildren))
		{
			return false;
		}
		if (elideChildren == true)
		{
			nodes = ElideChildren(nodes);
		}
		bool flag = false;
		foreach (TreeNode node in nodes)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (dataNode.DeleteNode())
			{
				UpdateNodeText(node.Parent);
				node.Remove();
				RemoveNodeFromSelection(node);
				flag = true;
			}
		}
		if (flag)
		{
			OnSelectionInvalidated();
		}
		return true;
	}

	private bool RemoveNodeFromSelection(TreeNode node)
	{
		bool result = false;
		if (_multiTree != null)
		{
			if (_multiTree.SelectedNodes.Contains(node))
			{
				_multiTree.SelectedNodes.Remove(node);
				result = true;
			}
			if (_multiTree.SelectedNode == node)
			{
				_multiTree.SelectedNode = null;
				result = true;
			}
		}
		if (_nodeTree.SelectedNode == node)
		{
			_nodeTree.SelectedNode = null;
			result = true;
		}
		return result;
	}

	public void DeleteSelection()
	{
		if (_multiTree != null)
		{
			DeleteNode(_multiTree.SelectedNodes);
		}
		else
		{
			DeleteNode(SelectedNode);
		}
	}

	public void EditNode(TreeNode node)
	{
		if (node != null && node.Tag is DataNode)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (dataNode.CanEditNode && dataNode.EditNode())
			{
				node.Text = dataNode.NodeDisplay;
				OnSelectionInvalidated();
			}
		}
	}

	public void EditSelection()
	{
		EditNode(SelectedNode);
	}

	private void RenameNode(TreeNode node)
	{
		if (node != null && node.Tag is DataNode)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (dataNode.CanRenameNode && dataNode.RenameNode())
			{
				node.Text = dataNode.NodeDisplay;
				OnSelectionInvalidated();
			}
		}
	}

	public void RenameSelection()
	{
		RenameNode(SelectedNode);
	}

	private void RefreshNode(TreeNode node)
	{
		if (node != null && node.Tag is DataNode)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (dataNode.CanRefreshNode && OnConfirmAction("Refresh data anyway?") && dataNode.RefreshNode())
			{
				RefreshChildNodes(node, dataNode);
				ExpandToEdge(node);
				OnSelectionInvalidated();
			}
		}
	}

	public void RefreshSelection()
	{
		RefreshNode(SelectedNode);
	}

	private void ExpandToEdge(TreeNode node)
	{
		if (node == null || !(node.Tag is DataNode))
		{
			return;
		}
		DataNode dataNode = node.Tag as DataNode;
		if (!dataNode.IsExpanded)
		{
			return;
		}
		if (!node.IsExpanded)
		{
			node.Expand();
		}
		foreach (TreeNode node2 in node.Nodes)
		{
			ExpandToEdge(node2);
		}
	}

	private void CopyNode(TreeNode node)
	{
		if (node != null && node.Tag is DataNode)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (dataNode.CanCopyNode)
			{
				dataNode.CopyNode();
			}
		}
	}

	private void CutNode(TreeNode node)
	{
		if (node != null && node.Tag is DataNode)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (dataNode.CanCutNode && dataNode.CutNode())
			{
				UpdateNodeText(node.Parent);
				node.Remove();
				RemoveNodeFromSelection(node);
				OnSelectionInvalidated();
			}
		}
	}

	private void PasteNode(TreeNode node)
	{
		if (node != null && node.Tag is DataNode)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (dataNode.CanPasteIntoNode && dataNode.PasteNode())
			{
				node.Text = dataNode.NodeDisplay;
				RefreshChildNodes(node, dataNode);
				OnSelectionInvalidated();
			}
		}
	}

	public void CopySelection()
	{
		CopyNode(SelectedNode);
	}

	public void CutSelection()
	{
		CutNode(SelectedNode);
	}

	public void PasteIntoSelection()
	{
		PasteNode(SelectedNode);
	}

	public void MoveNodeUp(TreeNode node)
	{
		if (node != null && node.Tag is DataNode { CanMoveNodeUp: not false } dataNode && dataNode.ChangeRelativePosition(-1))
		{
			RefreshChildNodes(node.Parent, dataNode.Parent);
			OnSelectionInvalidated();
		}
	}

	public void MoveNodeDown(TreeNode node)
	{
		if (node != null && node.Tag is DataNode { CanMoveNodeDown: not false } dataNode && dataNode.ChangeRelativePosition(1))
		{
			RefreshChildNodes(node.Parent, dataNode.Parent);
			OnSelectionInvalidated();
		}
	}

	public void MoveSelectionUp()
	{
		MoveNodeUp(SelectedNode);
	}

	public void MoveSelectionDown()
	{
		MoveNodeDown(SelectedNode);
	}

	public void ExpandNode(TreeNode node)
	{
		if (node == null || !(node.Tag is DataNode) || node.IsExpanded)
		{
			return;
		}
		node.Nodes.Clear();
		DataNode dataNode = node.Tag as DataNode;
		if (!dataNode.IsExpanded)
		{
			dataNode.Expand();
			node.Text = dataNode.NodeDisplay;
		}
		foreach (DataNode node2 in dataNode.Nodes)
		{
			node.Nodes.Add(CreateUnexpandedNode(node2));
		}
	}

	public void ExpandSelectedNode()
	{
		ExpandNode(SelectedNode);
		if (SelectedNode != null)
		{
			SelectedNode.Expand();
		}
	}

	public void CollapseNode(TreeNode node)
	{
		if (node == null || !(node.Tag is DataNode))
		{
			return;
		}
		DataNode dataNode = node.Tag as DataNode;
		if (!dataNode.IsModified)
		{
			dataNode.Collapse();
			node.Name = dataNode.NodeDisplay;
			node.Nodes.Clear();
			if (dataNode.HasUnexpandedChildren)
			{
				node.Nodes.Add(new TreeNode());
			}
		}
	}

	public void CollapseSelectedNode()
	{
		CollapseNode(SelectedNode);
	}

	private TreeNode GetRootFromDataNodePath(DataNode node, out Stack<DataNode> hierarchy)
	{
		hierarchy = new Stack<DataNode>();
		while (node != null)
		{
			hierarchy.Push(node);
			node = node.Parent;
		}
		DataNode dataNode = hierarchy.Pop();
		TreeNode result = null;
		foreach (TreeNode node2 in _nodeTree.Nodes)
		{
			if (node2.Tag == dataNode)
			{
				result = node2;
			}
		}
		return result;
	}

	private TreeNode FindFrontNode(DataNode node)
	{
		Stack<DataNode> hierarchy;
		TreeNode treeNode = GetRootFromDataNodePath(node, out hierarchy);
		if (treeNode == null)
		{
			return null;
		}
		while (hierarchy.Count > 0)
		{
			if (!treeNode.IsExpanded)
			{
				treeNode.Nodes.Add(new TreeNode());
				treeNode.Expand();
			}
			DataNode dataNode = hierarchy.Pop();
			foreach (TreeNode node2 in treeNode.Nodes)
			{
				if (node2.Tag == dataNode)
				{
					treeNode = node2;
					break;
				}
			}
		}
		return treeNode;
	}

	public void CollapseBelow(DataNode node)
	{
		Stack<DataNode> hierarchy;
		TreeNode treeNode = GetRootFromDataNodePath(node, out hierarchy);
		if (treeNode == null)
		{
			return;
		}
		while (hierarchy.Count > 0)
		{
			if (!treeNode.IsExpanded)
			{
				return;
			}
			DataNode dataNode = hierarchy.Pop();
			foreach (TreeNode node2 in treeNode.Nodes)
			{
				if (node2.Tag == dataNode)
				{
					treeNode = node2;
					break;
				}
			}
		}
		if (treeNode.IsExpanded)
		{
			treeNode.Collapse();
		}
	}

	public void SelectNode(DataNode node)
	{
		if (_multiTree != null)
		{
			_multiTree.SelectedNode = FindFrontNode(node);
		}
		else
		{
			_nodeTree.SelectedNode = FindFrontNode(node);
		}
	}

	public void ScrollNode(DataNode node)
	{
		FindFrontNode(node)?.EnsureVisible();
	}

	public void RefreshRootNodes()
	{
		if (ShowVirtualRoot)
		{
			_nodeTree.Nodes.Clear();
			_nodeTree.Nodes.Add(CreateUnexpandedNode(_rootData));
			return;
		}
		if (_rootData.HasUnexpandedChildren)
		{
			_rootData.Expand();
		}
		Dictionary<DataNode, TreeNode> dictionary = new Dictionary<DataNode, TreeNode>();
		foreach (TreeNode node in _nodeTree.Nodes)
		{
			if (node.Tag is DataNode)
			{
				dictionary.Add(node.Tag as DataNode, node);
			}
		}
		_nodeTree.Nodes.Clear();
		foreach (DataNode node2 in _rootData.Nodes)
		{
			if (!dictionary.ContainsKey(node2))
			{
				_nodeTree.Nodes.Add(CreateUnexpandedNode(node2));
			}
			else
			{
				_nodeTree.Nodes.Add(dictionary[node2]);
			}
		}
	}

	public void RefreshChildNodes(TreeNode node, DataNode dataNode)
	{
		Dictionary<DataNode, TreeNode> dictionary = new Dictionary<DataNode, TreeNode>();
		foreach (TreeNode node2 in node.Nodes)
		{
			if (node2.Tag is DataNode)
			{
				dictionary.Add(node2.Tag as DataNode, node2);
			}
		}
		node.Nodes.Clear();
		foreach (DataNode node3 in dataNode.Nodes)
		{
			if (!dictionary.ContainsKey(node3))
			{
				node.Nodes.Add(CreateUnexpandedNode(node3));
			}
			else
			{
				node.Nodes.Add(dictionary[node3]);
			}
		}
		foreach (TreeNode node4 in node.Nodes)
		{
			node4.ContextMenuStrip = BuildNodeContextMenu(node4, node4.Tag as DataNode);
		}
		if (node.Nodes.Count == 0 && dataNode.HasUnexpandedChildren)
		{
			ExpandNode(node);
			node.Expand();
		}
	}

	public void RefreshTreeNode(DataNode dataNode)
	{
		TreeNode node = FindFrontNode(dataNode);
		RefreshChildNodes(node, dataNode);
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
		_iconRegistry.Register(typeof(TagLongArrayDataNode), 17);
		_iconRegistry.Register(typeof(RootDataNode), 18);
	}

	private void UpdateNodeText(TreeNode node)
	{
		if (node != null && node.Tag is DataNode)
		{
			DataNode dataNode = node.Tag as DataNode;
			node.Text = dataNode.NodeDisplay;
		}
	}

	public bool CheckModifications()
	{
		foreach (TreeNode node in _nodeTree.Nodes)
		{
			if (node.Tag is DataNode { IsModified: not false })
			{
				return true;
			}
		}
		return false;
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
			ExpandNode(treeNode);
		}
		if (node.Parent != null)
		{
			if (node.Parent.NodeName == "Entities" && node.Nodes.Count > 0)
			{
				foreach (DataNode node2 in node.Nodes)
				{
					if (node2.NodeName == "id" || node2.NodeName == "identifier")
					{
						string text = node2.NodeDisplay.Replace("identifier:", "").Replace("id:", "").Trim();
						string text2 = string.Empty;
						if (entityLookups.ContainsKey(text))
						{
							text2 = entityLookups[text];
						}
						else if (entityLookups.ContainsValue(text))
						{
							text2 = text;
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							treeNode.ImageKey = text2;
							text2 = text2.Replace("minecraft:", "");
							treeNode.Text = text2 + " " + treeNode.Text;
						}
					}
				}
			}
			if (node.Parent.NodeName == "TileEntities" && node.Nodes.Count > 0)
			{
				foreach (DataNode node3 in node.Nodes)
				{
					if (node3.NodeName == "id")
					{
						string text3 = (treeNode.ImageKey = node3.NodeDisplay.Replace("id:", "").Trim());
						treeNode.Text = text3 + " " + treeNode.Text;
					}
				}
			}
		}
		return treeNode;
	}

	public ContextMenuStrip BuildNodeContextMenu(TreeNode frontNode, DataNode node)
	{
		if (node == null)
		{
			return null;
		}
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		if (node.HasUnexpandedChildren || node.Nodes.Count > 0)
		{
			if (frontNode.IsExpanded)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("&Collapse", null, _contextCollapse_Click);
				toolStripMenuItem.Font = new Font(toolStripMenuItem.Font, FontStyle.Bold);
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Expand C&hildren", null, _contextExpandChildren_Click);
				ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("Expand &Tree", null, _contextExpandTree_Click);
				contextMenuStrip.Items.AddRange(new ToolStripItem[4]
				{
					toolStripMenuItem,
					new ToolStripSeparator(),
					toolStripMenuItem2,
					toolStripMenuItem3
				});
			}
			else
			{
				ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem("&Expand", null, _contextExpand_Click);
				toolStripMenuItem4.Font = new Font(toolStripMenuItem4.Font, FontStyle.Bold);
				contextMenuStrip.Items.Add(toolStripMenuItem4);
			}
		}
		if (node.CanReoderNode)
		{
			ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem("Move &Up", Resources.ArrowUp, _contextMoveUp_Click);
			ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem("Move &Down", Resources.ArrowDown, _contextMoveDown_Click);
			toolStripMenuItem5.Enabled = node.CanMoveNodeUp;
			toolStripMenuItem6.Enabled = node.CanMoveNodeDown;
			contextMenuStrip.Items.Add(toolStripMenuItem5);
			contextMenuStrip.Items.Add(toolStripMenuItem6);
		}
		if (node is DirectoryDataNode)
		{
			if (contextMenuStrip.Items.Count > 0)
			{
				contextMenuStrip.Items.Add(new ToolStripSeparator());
			}
			ToolStripMenuItem value = new ToolStripMenuItem("Open in E&xplorer", null, _contextOpenInExplorer_Click);
			contextMenuStrip.Items.Add(value);
		}
		if (contextMenuStrip.Items.Count <= 0)
		{
			return null;
		}
		return contextMenuStrip;
	}

	private void _contextCollapse_Click(object sender, EventArgs e)
	{
		if (_multiTree.SelectedNode != null)
		{
			_multiTree.SelectedNode.Collapse();
		}
	}

	private void _contextExpand_Click(object sender, EventArgs e)
	{
		if (_multiTree.SelectedNode != null)
		{
			_multiTree.SelectedNode.Expand();
		}
	}

	private void _contextExpandChildren_Click(object sender, EventArgs e)
	{
		if (_multiTree.SelectedNode == null)
		{
			return;
		}
		foreach (TreeNode node in _multiTree.SelectedNode.Nodes)
		{
			node.Expand();
		}
	}

	private void _contextExpandTree_Click(object sender, EventArgs e)
	{
		if (_multiTree.SelectedNode != null)
		{
			_multiTree.SelectedNode.ExpandAll();
		}
	}

	private void _contextMoveUp_Click(object sender, EventArgs e)
	{
		MoveSelectionUp();
	}

	private void _contextMoveDown_Click(object sender, EventArgs e)
	{
		MoveSelectionDown();
	}

	private void _contextOpenInExplorer_Click(object sender, EventArgs e)
	{
		if (_multiTree.SelectedNode != null && _multiTree.SelectedNode.Tag is DirectoryDataNode)
		{
			DirectoryDataNode directoryDataNode = _multiTree.SelectedNode.Tag as DirectoryDataNode;
			try
			{
				string fileName = ((!Interop.IsWindows) ? "file://" : "") + directoryDataNode.NodeDirPath;
				Process.Start(fileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Can't open directory", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	public bool CanOperateOnSelection(DataNodePredicate pred)
	{
		if (_multiTree != null)
		{
			return CanOperateOnNodes(_multiTree.SelectedNodes, pred);
		}
		return CanOperateOnNodes(new List<TreeNode> { _nodeTree.SelectedNode }, pred);
	}

	private bool CanOperateOnNodes(IList<TreeNode> nodes, DataNodePredicate pred)
	{
		bool? elideChildren = null;
		return CanOperateOnNodesEx(nodes, pred, out elideChildren);
	}

	private bool CanOperateOnNodesEx(IList<TreeNode> nodes, DataNodePredicate pred, out bool? elideChildren)
	{
		GroupCapabilities groupCapabilities = GroupCapabilities.All;
		elideChildren = null;
		foreach (TreeNode node in nodes)
		{
			if (node == null || !(node.Tag is DataNode))
			{
				return false;
			}
			DataNode dataNode = node.Tag as DataNode;
			if (!pred(dataNode, out var caps))
			{
				return false;
			}
			groupCapabilities &= caps;
			bool flag = (dataNode.DeleteNodeCapabilities & GroupCapabilities.ElideChildren) == GroupCapabilities.ElideChildren;
			if (!elideChildren.HasValue)
			{
				elideChildren = flag;
			}
			if (elideChildren != flag)
			{
				return false;
			}
		}
		if (nodes.Count > 1 && !SufficientCapabilities(nodes, groupCapabilities))
		{
			return false;
		}
		return true;
	}

	private IList<TreeNode> ElideChildren(IList<TreeNode> nodes)
	{
		List<TreeNode> list = new List<TreeNode>();
		foreach (TreeNode node in nodes)
		{
			TreeNode parent = node.Parent;
			bool flag = false;
			while (parent != null)
			{
				if (nodes.Contains(parent))
				{
					flag = true;
					break;
				}
				parent = parent.Parent;
			}
			if (!flag)
			{
				list.Add(node);
			}
		}
		return list;
	}

	private bool CommonContainer(IEnumerable<TreeNode> nodes)
	{
		object obj = null;
		foreach (TreeNode node in nodes)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (obj == null)
			{
				obj = dataNode.Parent;
			}
			if (obj != dataNode.Parent)
			{
				return false;
			}
		}
		return true;
	}

	private bool CommonType(IEnumerable<TreeNode> nodes)
	{
		Type type = null;
		foreach (TreeNode node in nodes)
		{
			DataNode dataNode = node.Tag as DataNode;
			if (type == null)
			{
				type = dataNode.GetType();
			}
			if (type != dataNode.GetType())
			{
				return false;
			}
		}
		return true;
	}

	private bool SufficientCapabilities(IEnumerable<TreeNode> nodes, GroupCapabilities commonCaps)
	{
		bool flag = CommonContainer(nodes);
		bool flag2 = CommonType(nodes);
		bool flag3 = true;
		if (flag && flag2)
		{
			flag3 = flag3 && (commonCaps & GroupCapabilities.SiblingSameType) == GroupCapabilities.SiblingSameType;
		}
		else if (flag && !flag2)
		{
			flag3 = flag3 && (commonCaps & GroupCapabilities.SiblingMixedType) == GroupCapabilities.SiblingMixedType;
		}
		else if (!flag && flag2)
		{
			flag3 = flag3 && (commonCaps & GroupCapabilities.MultiSameType) == GroupCapabilities.MultiSameType;
		}
		else if (!flag && !flag2)
		{
			flag3 = flag3 && (commonCaps & GroupCapabilities.MultiMixedType) == GroupCapabilities.MultiMixedType;
		}
		return flag3;
	}
}
