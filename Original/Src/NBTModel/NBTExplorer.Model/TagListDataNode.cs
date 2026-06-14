using System;
using NBTModel.Interop;
using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagListDataNode : TagDataNode.Container
{
	private ListTagContainer _container;

	public new TagNodeList Tag
	{
		get
		{
			return base.Tag as TagNodeList;
		}
		set
		{
			base.Tag = value;
		}
	}

	public override bool CanPasteIntoNode
	{
		get
		{
			if (NbtClipboardController.ContainsData)
			{
				NbtClipboardData nbtClipboardData = NbtClipboardController.CopyFromClipboard();
				if (nbtClipboardData == null)
				{
					return false;
				}
				if (nbtClipboardData.Node != null && (nbtClipboardData.Node.GetTagType() == Tag.ValueType || Tag.Count == 0))
				{
					return true;
				}
			}
			return false;
		}
	}

	public override bool IsOrderedContainer => true;

	public override IOrderedTagContainer OrderedTagContainer => _container;

	public override int TagCount => _container.TagCount;

	public TagListDataNode(TagNodeList tag)
		: base(tag)
	{
		Action<bool> modifyHandler = delegate
		{
			base.IsDataModified = true;
		};
		_container = new ListTagContainer(tag, modifyHandler);
	}

	protected override void ExpandCore()
	{
		foreach (TagNode item in Tag)
		{
			TagDataNode tagDataNode = TagDataNode.CreateFromTag(item);
			if (tagDataNode != null)
			{
				base.Nodes.Add(tagDataNode);
			}
		}
	}

	public override bool CanCreateTag(TagType type)
	{
		if (Tag.Count > 0)
		{
			return Tag.ValueType == type;
		}
		if (Enum.IsDefined(typeof(TagType), type))
		{
			return type != TagType.TAG_END;
		}
		return false;
	}

	public override bool CreateNode(TagType type)
	{
		if (!CanCreateTag(type))
		{
			return false;
		}
		if (Tag.Count == 0)
		{
			Tag.ChangeValueType(type);
		}
		AppendTag(TagDataNode.DefaultTag(type));
		return true;
	}

	public override bool PasteNode()
	{
		if (!CanPasteIntoNode)
		{
			return false;
		}
		NbtClipboardData nbtClipboardData = NbtClipboardController.CopyFromClipboard();
		if (nbtClipboardData == null || nbtClipboardData.Node == null)
		{
			return false;
		}
		if (Tag.Count == 0)
		{
			Tag.ChangeValueType(nbtClipboardData.Node.GetTagType());
		}
		AppendTag(nbtClipboardData.Node);
		return true;
	}

	public override bool DeleteTag(TagNode tag)
	{
		return _container.DeleteTag(tag);
	}

	public override void Clear()
	{
		if (TagCount != 0)
		{
			base.Nodes.Clear();
			Tag.Clear();
			base.IsDataModified = true;
		}
	}

	public bool AppendTag(TagNode tag)
	{
		if (tag == null || !CanCreateTag(tag.GetTagType()))
		{
			return false;
		}
		_container.InsertTag(tag, _container.TagCount);
		base.IsDataModified = true;
		if (base.IsExpanded)
		{
			TagDataNode tagDataNode = TagDataNode.CreateFromTag(tag);
			if (tagDataNode != null)
			{
				base.Nodes.Add(tagDataNode);
			}
		}
		return true;
	}
}
