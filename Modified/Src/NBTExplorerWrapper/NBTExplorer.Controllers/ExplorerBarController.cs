using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NBTExplorer.Model;
using NBTExplorer.Windows;

namespace NBTExplorer.Controllers;

internal class ExplorerBarController
{
	private ToolStrip _explorerStrip;

	private DataNode _rootNode;

	private IconRegistry _registry;

	private ImageList _iconList;

	public DataNode SearchRoot
	{
		get
		{
			return _rootNode;
		}
		set
		{
			if (_rootNode != value)
			{
				_rootNode = value;
				Initialize();
				OnSearchRootChanged();
			}
		}
	}

	public event EventHandler SearchRootChanged;

	public ExplorerBarController(ToolStrip toolStrip, IconRegistry registry, ImageList iconList, DataNode rootNode)
	{
		_explorerStrip = toolStrip;
		_registry = registry;
		_iconList = iconList;
		_rootNode = rootNode;
		Initialize();
	}

	private void Initialize()
	{
		_explorerStrip.Items.Clear();
		List<DataNode> list = new List<DataNode>();
		for (DataNode dataNode = _rootNode; dataNode != null; dataNode = dataNode.Parent)
		{
			list.Add(dataNode);
		}
		list.Reverse();
		foreach (DataNode item in list)
		{
			ToolStripSplitButton toolStripSplitButton = new ToolStripSplitButton(item.NodePathName);
			toolStripSplitButton.Tag = item;
			ToolStripSplitButton toolStripSplitButton2 = toolStripSplitButton;
			toolStripSplitButton2.ButtonClick += delegate(object s, EventArgs e)
			{
				if (s is ToolStripSplitButton toolStripSplitButton3)
				{
					SearchRoot = toolStripSplitButton3.Tag as DataNode;
				}
			};
			toolStripSplitButton2.DropDown.ImageList = _iconList;
			if (_explorerStrip.Items.Count == 0)
			{
				toolStripSplitButton2.ImageIndex = _registry.Lookup(item.GetType());
			}
			if (!item.IsExpanded)
			{
				item.Expand();
			}
			foreach (DataNode node in item.Nodes)
			{
				if (!node.IsContainerType)
				{
					continue;
				}
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(node.NodePathName);
				toolStripMenuItem.ImageIndex = _registry.Lookup(node.GetType());
				toolStripMenuItem.Tag = node;
				ToolStripMenuItem toolStripMenuItem2 = toolStripMenuItem;
				toolStripMenuItem2.Click += delegate(object s, EventArgs e)
				{
					if (s is ToolStripMenuItem toolStripMenuItem3)
					{
						SearchRoot = toolStripMenuItem3.Tag as DataNode;
					}
				};
				if (list.Contains(node))
				{
					toolStripMenuItem2.Font = new Font(toolStripMenuItem2.Font, FontStyle.Bold);
				}
				toolStripSplitButton2.DropDownItems.Add(toolStripMenuItem2);
			}
			_explorerStrip.Items.Add(toolStripSplitButton2);
		}
	}

	protected virtual void OnSearchRootChanged()
	{
		this.SearchRootChanged?.Invoke(this, EventArgs.Empty);
	}
}
