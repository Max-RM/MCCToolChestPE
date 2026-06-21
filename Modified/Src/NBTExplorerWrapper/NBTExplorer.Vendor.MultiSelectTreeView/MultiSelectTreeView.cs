using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NBTExplorer.Vendor.MultiSelectTreeView;

public class MultiSelectTreeView : TreeView
{
	private const int WM_ERASEBKGND = 20;

	private List<TreeNode> m_SelectedNodes;

	private TreeNode m_SelectedNode;

	public List<TreeNode> SelectedNodes
	{
		get
		{
			return m_SelectedNodes;
		}
		set
		{
			BeginUpdate();
			ClearSelectedNodes();
			if (value != null)
			{
				foreach (TreeNode item in value)
				{
					ToggleNode(item, bSelectNode: true);
				}
			}
			EndUpdate();
		}
	}

	public new TreeNode SelectedNode
	{
		get
		{
			return m_SelectedNode;
		}
		set
		{
			ClearSelectedNodes();
			if (value != null)
			{
				SelectNode(value);
			}
		}
	}

	public MultiSelectTreeView()
	{
		DoubleBuffered = true;
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		m_SelectedNodes = new List<TreeNode>();
		base.SelectedNode = null;
	}

	private void UpdateExtendedStyles()
	{
		if (Interop.WinInteropAvailable)
		{
			int num = 0;
			if (DoubleBuffered)
			{
				num |= 4;
			}
			if (num != 0)
			{
				Interop.SendMessage(base.Handle, 4396, (IntPtr)4, (IntPtr)num);
			}
		}
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		if (Interop.WinInteropAvailable)
		{
			UpdateExtendedStyles();
			if (!Interop.IsWinXP)
			{
				Interop.SendMessage(base.Handle, 4381, IntPtr.Zero, (IntPtr)ColorTranslator.ToWin32(BackColor));
			}
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		try
		{
			if (m_SelectedNode == null && base.TopNode != null)
			{
				ToggleNode(base.TopNode, bSelectNode: true);
			}
			base.OnGotFocus(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		try
		{
			base.SelectedNode = null;
			TreeNode nodeAt = GetNodeAt(e.Location);
			if (nodeAt != null)
			{
				int num = nodeAt.Bounds.X;
				if (nodeAt.TreeView.ImageList != null)
				{
					num -= 20;
				}
				int num2 = nodeAt.Bounds.Right + 10;
				if (e.Location.X > num && e.Location.X < num2 && (Control.ModifierKeys != Keys.None || !m_SelectedNodes.Contains(nodeAt)))
				{
					SelectNode(nodeAt);
				}
			}
			base.OnMouseDown(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		try
		{
			TreeNode nodeAt = GetNodeAt(e.Location);
			if (nodeAt != null && Control.ModifierKeys == Keys.None && m_SelectedNodes.Contains(nodeAt))
			{
				int num = nodeAt.Bounds.X;
				int num2 = nodeAt.Bounds.Right + 10;
				if (e.Location.X > num && e.Location.X < num2)
				{
					SelectNode(nodeAt);
				}
			}
			base.OnMouseUp(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnItemDrag(ItemDragEventArgs e)
	{
		try
		{
			if (e.Item is TreeNode treeNode && !m_SelectedNodes.Contains(treeNode))
			{
				SelectSingleNode(treeNode);
				ToggleNode(treeNode, bSelectNode: true);
			}
			base.OnItemDrag(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
	{
		try
		{
			base.SelectedNode = null;
			e.Cancel = true;
			base.OnBeforeSelect(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnAfterSelect(TreeViewEventArgs e)
	{
		try
		{
			base.OnAfterSelect(e);
			base.SelectedNode = null;
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		if (e.KeyCode == Keys.ShiftKey)
		{
			return;
		}
		bool flag = Control.ModifierKeys == Keys.Shift;
		try
		{
			if (m_SelectedNode == null && base.TopNode != null)
			{
				ToggleNode(base.TopNode, bSelectNode: true);
			}
			if (m_SelectedNode == null)
			{
				return;
			}
			if (e.KeyCode == Keys.Left)
			{
				if (m_SelectedNode.IsExpanded && m_SelectedNode.Nodes.Count > 0)
				{
					m_SelectedNode.Collapse();
				}
				else if (m_SelectedNode.Parent != null)
				{
					SelectSingleNode(m_SelectedNode.Parent);
				}
				return;
			}
			if (e.KeyCode == Keys.Right)
			{
				if (!m_SelectedNode.IsExpanded)
				{
					m_SelectedNode.Expand();
				}
				else
				{
					SelectSingleNode(m_SelectedNode.FirstNode);
				}
				return;
			}
			if (e.KeyCode == Keys.Up)
			{
				if (m_SelectedNode.PrevVisibleNode != null)
				{
					SelectNode(m_SelectedNode.PrevVisibleNode);
				}
				return;
			}
			if (e.KeyCode == Keys.Down)
			{
				if (m_SelectedNode.NextVisibleNode != null)
				{
					SelectNode(m_SelectedNode.NextVisibleNode);
				}
				return;
			}
			if (e.KeyCode == Keys.Home)
			{
				if (flag)
				{
					if (m_SelectedNode.Parent == null)
					{
						if (base.Nodes.Count > 0)
						{
							SelectNode(base.Nodes[0]);
						}
					}
					else
					{
						SelectNode(m_SelectedNode.Parent.FirstNode);
					}
				}
				else if (base.Nodes.Count > 0)
				{
					SelectSingleNode(base.Nodes[0]);
				}
				return;
			}
			if (e.KeyCode == Keys.End)
			{
				if (flag)
				{
					if (m_SelectedNode.Parent == null)
					{
						if (base.Nodes.Count > 0)
						{
							SelectNode(base.Nodes[base.Nodes.Count - 1]);
						}
					}
					else
					{
						SelectNode(m_SelectedNode.Parent.LastNode);
					}
				}
				else if (base.Nodes.Count > 0)
				{
					TreeNode lastNode = base.Nodes[0].LastNode;
					while (lastNode.IsExpanded && lastNode.LastNode != null)
					{
						lastNode = lastNode.LastNode;
					}
					SelectSingleNode(lastNode);
				}
				return;
			}
			if (e.KeyCode == Keys.Prior)
			{
				int num = base.VisibleCount;
				TreeNode prevVisibleNode = m_SelectedNode;
				while (num > 0 && prevVisibleNode.PrevVisibleNode != null)
				{
					prevVisibleNode = prevVisibleNode.PrevVisibleNode;
					num--;
				}
				SelectSingleNode(prevVisibleNode);
				return;
			}
			if (e.KeyCode == Keys.Next)
			{
				int num2 = base.VisibleCount;
				TreeNode nextVisibleNode = m_SelectedNode;
				while (num2 > 0 && nextVisibleNode.NextVisibleNode != null)
				{
					nextVisibleNode = nextVisibleNode.NextVisibleNode;
					num2--;
				}
				SelectSingleNode(nextVisibleNode);
				return;
			}
			string value = ((char)e.KeyValue).ToString();
			TreeNode nextVisibleNode2 = m_SelectedNode;
			while (nextVisibleNode2.NextVisibleNode != null)
			{
				nextVisibleNode2 = nextVisibleNode2.NextVisibleNode;
				if (nextVisibleNode2.Text.StartsWith(value))
				{
					SelectSingleNode(nextVisibleNode2);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
		finally
		{
			EndUpdate();
		}
	}

	private void SelectNode(TreeNode node)
	{
		try
		{
			BeginUpdate();
			if (m_SelectedNode == null || Control.ModifierKeys == Keys.Control)
			{
				bool flag = m_SelectedNodes.Contains(node);
				ToggleNode(node, !flag);
			}
			else if (Control.ModifierKeys == Keys.Shift)
			{
				TreeNode treeNode = m_SelectedNode;
				if (treeNode.Parent == node.Parent)
				{
					if (treeNode.Index < node.Index)
					{
						while (treeNode != node)
						{
							treeNode = treeNode.NextVisibleNode;
							if (treeNode == null)
							{
								break;
							}
							ToggleNode(treeNode, bSelectNode: true);
						}
					}
					else if (treeNode.Index != node.Index)
					{
						while (treeNode != node)
						{
							treeNode = treeNode.PrevVisibleNode;
							if (treeNode == null)
							{
								break;
							}
							ToggleNode(treeNode, bSelectNode: true);
						}
					}
				}
				else
				{
					TreeNode treeNode2 = treeNode;
					TreeNode treeNode3 = node;
					int num = Math.Min(treeNode2.Level, treeNode3.Level);
					while (treeNode2.Level > num)
					{
						treeNode2 = treeNode2.Parent;
					}
					while (treeNode3.Level > num)
					{
						treeNode3 = treeNode3.Parent;
					}
					while (treeNode2.Parent != treeNode3.Parent)
					{
						treeNode2 = treeNode2.Parent;
						treeNode3 = treeNode3.Parent;
					}
					if (treeNode2.Index < treeNode3.Index)
					{
						while (treeNode != node)
						{
							treeNode = treeNode.NextVisibleNode;
							if (treeNode == null)
							{
								break;
							}
							ToggleNode(treeNode, bSelectNode: true);
						}
					}
					else if (treeNode2.Index == treeNode3.Index)
					{
						if (treeNode.Level < node.Level)
						{
							while (treeNode != node)
							{
								treeNode = treeNode.NextVisibleNode;
								if (treeNode == null)
								{
									break;
								}
								ToggleNode(treeNode, bSelectNode: true);
							}
						}
						else
						{
							while (treeNode != node)
							{
								treeNode = treeNode.PrevVisibleNode;
								if (treeNode == null)
								{
									break;
								}
								ToggleNode(treeNode, bSelectNode: true);
							}
						}
					}
					else
					{
						while (treeNode != node)
						{
							treeNode = treeNode.PrevVisibleNode;
							if (treeNode == null)
							{
								break;
							}
							ToggleNode(treeNode, bSelectNode: true);
						}
					}
				}
			}
			else
			{
				SelectSingleNode(node);
			}
			OnAfterSelect(new TreeViewEventArgs(m_SelectedNode));
		}
		finally
		{
			EndUpdate();
		}
	}

	private void ClearSelectedNodes()
	{
		try
		{
			foreach (TreeNode selectedNode in m_SelectedNodes)
			{
				selectedNode.BackColor = BackColor;
				selectedNode.ForeColor = ForeColor;
			}
		}
		finally
		{
			m_SelectedNodes.Clear();
			m_SelectedNode = null;
		}
	}

	private void SelectSingleNode(TreeNode node)
	{
		if (node != null)
		{
			ClearSelectedNodes();
			ToggleNode(node, bSelectNode: true);
			node.EnsureVisible();
		}
	}

	private void ToggleNode(TreeNode node, bool bSelectNode)
	{
		if (bSelectNode)
		{
			m_SelectedNode = node;
			if (!m_SelectedNodes.Contains(node))
			{
				m_SelectedNodes.Add(node);
			}
			node.BackColor = SystemColors.Highlight;
			node.ForeColor = SystemColors.HighlightText;
		}
		else
		{
			m_SelectedNodes.Remove(node);
			node.BackColor = BackColor;
			node.ForeColor = ForeColor;
		}
	}

	private void HandleException(Exception ex)
	{
		MessageBox.Show(ex.Message);
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg != 20)
		{
			base.WndProc(ref m);
		}
	}
}
