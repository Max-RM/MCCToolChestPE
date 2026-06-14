using System.Collections.Generic;
using Substrate.Nbt;

namespace NBTExplorer.Model;

public class DataNode
{
	private DataNode _parent;

	private DataNodeCollection _children;

	private bool _expanded;

	private bool _dataModified;

	private bool _childModified;

	public DataNode Parent
	{
		get
		{
			return _parent;
		}
		internal set
		{
			_parent = value;
		}
	}

	public DataNode Root
	{
		get
		{
			if (_parent != null)
			{
				return _parent.Root;
			}
			return this;
		}
	}

	public DataNodeCollection Nodes => _children;

	public bool IsModified
	{
		get
		{
			if (!_dataModified)
			{
				return _childModified;
			}
			return true;
		}
	}

	public bool IsDataModified
	{
		get
		{
			return _dataModified;
		}
		set
		{
			_dataModified = value;
			CalculateChildModifiedState();
		}
	}

	protected bool IsChildModified
	{
		get
		{
			return _childModified;
		}
		set
		{
			_childModified = value;
			CalculateChildModifiedState();
		}
	}

	protected bool IsParentModified
	{
		get
		{
			if (Parent != null)
			{
				return Parent.IsModified;
			}
			return false;
		}
		set
		{
			if (Parent != null)
			{
				Parent.IsDataModified = value;
			}
		}
	}

	public bool IsExpanded
	{
		get
		{
			return _expanded;
		}
		private set
		{
			_expanded = value;
		}
	}

	public virtual string NodeName => "";

	public string NodePath
	{
		get
		{
			string text = NodePathName;
			if (string.IsNullOrEmpty(text))
			{
				text = "*";
			}
			if (Parent == null)
			{
				return '/' + text;
			}
			return Parent.NodePath + '/' + text;
		}
	}

	public virtual string NodePathName => NodeName;

	public virtual string NodeDisplay => "";

	public virtual bool IsContainerType => false;

	public virtual bool HasUnexpandedChildren => false;

	protected virtual NodeCapabilities Capabilities => NodeCapabilities.None;

	public virtual bool CanRenameNode => (Capabilities & NodeCapabilities.Rename) != 0;

	public virtual bool CanEditNode => (Capabilities & NodeCapabilities.Edit) != 0;

	public virtual bool CanDeleteNode => (Capabilities & NodeCapabilities.Delete) != 0;

	public virtual bool CanCopyNode => (Capabilities & NodeCapabilities.Copy) != 0;

	public virtual bool CanCutNode => (Capabilities & NodeCapabilities.Cut) != 0;

	public virtual bool CanPasteIntoNode => (Capabilities & NodeCapabilities.PasteInto) != 0;

	public virtual bool CanSearchNode => (Capabilities & NodeCapabilities.Search) != 0;

	public virtual bool CanReoderNode => (Capabilities & NodeCapabilities.Reorder) != 0;

	public virtual bool CanRefreshNode => (Capabilities & NodeCapabilities.Refresh) != 0;

	public virtual bool CanMoveNodeUp => false;

	public virtual bool CanMoveNodeDown => false;

	public virtual GroupCapabilities RenameNodeCapabilities => GroupCapabilities.Single;

	public virtual GroupCapabilities EditNodeCapabilities => GroupCapabilities.Single;

	public virtual GroupCapabilities DeleteNodeCapabilities => GroupCapabilities.All;

	public virtual GroupCapabilities CutNodeCapabilities => GroupCapabilities.Single;

	public virtual GroupCapabilities CopyNodeCapabilities => GroupCapabilities.Single;

	public virtual GroupCapabilities PasteIntoNodeCapabilities => GroupCapabilities.Single;

	public virtual GroupCapabilities SearchNodeCapabilites => GroupCapabilities.Single;

	public virtual GroupCapabilities ReorderNodeCapabilities => GroupCapabilities.Single;

	public virtual GroupCapabilities RefreshNodeCapabilites => GroupCapabilities.Single;

	public DataNode()
	{
		_children = new DataNodeCollection(this);
	}

	private void CalculateChildModifiedState()
	{
		_childModified = false;
		foreach (DataNode node in Nodes)
		{
			if (node.IsModified)
			{
				_childModified = true;
			}
		}
		if (Parent != null)
		{
			Parent.CalculateChildModifiedState();
		}
	}

	public void Expand()
	{
		if (!IsExpanded)
		{
			ExpandCore();
			IsExpanded = true;
		}
	}

	protected virtual void ExpandCore()
	{
	}

	public void Collapse()
	{
		if (IsExpanded && !IsModified)
		{
			Release();
			IsExpanded = false;
		}
	}

	public void Release()
	{
		foreach (DataNode node in Nodes)
		{
			node.Release();
		}
		ReleaseCore();
		IsExpanded = false;
		IsDataModified = false;
	}

	protected virtual void ReleaseCore()
	{
		Nodes.Clear();
	}

	public void Save()
	{
		foreach (DataNode node in Nodes)
		{
			if (node.IsModified)
			{
				node.Save();
			}
		}
		SaveCore();
		IsDataModified = false;
	}

	protected virtual void SaveCore()
	{
	}

	protected Dictionary<string, object> BuildExpandSet(DataNode node)
	{
		if (node == null || !node.IsExpanded)
		{
			return null;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (DataNode node2 in node.Nodes)
		{
			Dictionary<string, object> dictionary2 = BuildExpandSet(node2);
			if (dictionary2 != null)
			{
				dictionary[node2.NodePathName] = dictionary2;
			}
		}
		return dictionary;
	}

	protected void RestoreExpandSet(DataNode node, Dictionary<string, object> expandSet)
	{
		if (expandSet == null)
		{
			return;
		}
		node.Expand();
		foreach (DataNode node2 in node.Nodes)
		{
			if (expandSet.ContainsKey(node2.NodePathName))
			{
				Dictionary<string, object> dictionary = (Dictionary<string, object>)expandSet[node2.NodePathName];
				if (dictionary != null)
				{
					RestoreExpandSet(node2, dictionary);
				}
			}
		}
	}

	public virtual bool CanCreateTag(TagType type)
	{
		return false;
	}

	public virtual bool CreateNode(TagType type)
	{
		return false;
	}

	public virtual bool RenameNode()
	{
		return false;
	}

	public virtual bool EditNode()
	{
		return false;
	}

	public virtual bool DeleteNode()
	{
		return false;
	}

	public virtual bool CopyNode()
	{
		return false;
	}

	public virtual bool CutNode()
	{
		return false;
	}

	public virtual bool PasteNode()
	{
		return false;
	}

	public virtual bool ChangeRelativePosition(int offset)
	{
		return false;
	}

	public virtual bool RefreshNode()
	{
		return false;
	}
}
