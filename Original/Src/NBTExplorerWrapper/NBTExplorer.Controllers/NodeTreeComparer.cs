using System.Collections;
using System.Windows.Forms;
using NBTExplorer.Model;
using NBTExplorer.Utility;
using Substrate.Nbt;

namespace NBTExplorer.Controllers;

public class NodeTreeComparer : IComparer
{
	private NaturalComparer _comparer = new NaturalComparer();

	public int OrderForTag(TagType tagID)
	{
		switch (tagID)
		{
		case TagType.TAG_COMPOUND:
			return 0;
		case TagType.TAG_LIST:
			return 1;
		case TagType.TAG_BYTE:
		case TagType.TAG_SHORT:
		case TagType.TAG_INT:
		case TagType.TAG_LONG:
		case TagType.TAG_FLOAT:
		case TagType.TAG_DOUBLE:
		case TagType.TAG_STRING:
			return 2;
		default:
			return 3;
		}
	}

	public int OrderForNode(object node)
	{
		if (node is DirectoryDataNode)
		{
			return 0;
		}
		return 1;
	}

	public int Compare(object x, object y)
	{
		TreeNode treeNode = x as TreeNode;
		TreeNode treeNode2 = y as TreeNode;
		TagDataNode tagDataNode = treeNode.Tag as TagDataNode;
		TagDataNode tagDataNode2 = treeNode2.Tag as TagDataNode;
		if (tagDataNode == null || tagDataNode2 == null)
		{
			int num = OrderForNode(treeNode.Tag).CompareTo(OrderForNode(treeNode2.Tag));
			if (num != 0)
			{
				return num;
			}
			return _comparer.Compare(treeNode.Text, treeNode2.Text);
		}
		TagDataNode tagDataNode3 = tagDataNode.Parent as TagDataNode;
		TagDataNode tagDataNode4 = tagDataNode2.Parent as TagDataNode;
		if (tagDataNode3 != null && tagDataNode4 != null && (tagDataNode3.Tag.GetTagType() == TagType.TAG_LIST || tagDataNode4.Tag.GetTagType() == TagType.TAG_LIST))
		{
			return 1;
		}
		TagType tagType = tagDataNode.Tag.GetTagType();
		TagType tagType2 = tagDataNode2.Tag.GetTagType();
		int num2 = OrderForTag(tagType).CompareTo(OrderForTag(tagType2));
		if (num2 != 0)
		{
			return num2;
		}
		return _comparer.Compare(tagDataNode.NodeDisplay, tagDataNode2.NodeDisplay);
	}
}
