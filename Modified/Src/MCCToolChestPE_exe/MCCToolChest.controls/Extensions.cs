using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MCCToolChest.controls;

public static class Extensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MoveUp(this TreeNode node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode parent = node.Parent;
		if (parent != null)
		{
			int num = parent.Nodes.IndexOf(node);
			if (num > 0)
			{
				parent.Nodes.RemoveAt(num);
				parent.Nodes.Insert(num - 1, node);
				node.TreeView.SelectedNode = node;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MoveDown(this TreeNode node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode parent = node.Parent;
		if (parent != null)
		{
			int num = parent.Nodes.IndexOf(node);
			if (num < parent.Nodes.Count - 1)
			{
				parent.Nodes.RemoveAt(num);
				parent.Nodes.Insert(num + 1, node);
				node.TreeView.SelectedNode = node;
			}
		}
	}
}
