using System;
using System.Collections.Generic;
using NBTModel.Interop;
using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagCompoundDataNode : TagDataNode.Container
{
	private CompoundTagContainer _container;

	protected new TagNodeCompound Tag => base.Tag as TagNodeCompound;

	public override bool CanPasteIntoNode => NbtClipboardController.ContainsData;

	public override bool IsNamedContainer => true;

	public override INamedTagContainer NamedTagContainer => _container;

	public override int TagCount => _container.TagCount;

	public TagCompoundDataNode(TagNodeCompound tag)
		: base(tag)
	{
		_container = new CompoundTagContainer(tag);
	}

	protected override void ExpandCore()
	{
		SortedList<TagKey, TagNode> sortedList = new SortedList<TagKey, TagNode>();
		foreach (KeyValuePair<string, TagNode> item in Tag)
		{
			sortedList.Add(new TagKey(item.Key, item.Value.GetTagType()), item.Value);
		}
		foreach (KeyValuePair<TagKey, TagNode> item2 in sortedList)
		{
			TagDataNode tagDataNode = TagDataNode.CreateFromTag(item2.Value);
			if (tagDataNode != null)
			{
				base.Nodes.Add(tagDataNode);
			}
		}
	}

	public override bool CanCreateTag(TagType type)
	{
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
		if (FormRegistry.CreateNode != null)
		{
			CreateTagFormData createTagFormData = new CreateTagFormData();
			createTagFormData.TagType = type;
			createTagFormData.HasName = true;
			CreateTagFormData createTagFormData2 = createTagFormData;
			createTagFormData2.RestrictedNames.AddRange(_container.TagNamesInUse);
			if (FormRegistry.CreateNode(createTagFormData2))
			{
				AddTag(createTagFormData2.TagNode, createTagFormData2.TagName);
				return true;
			}
		}
		return false;
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
		string text = nbtClipboardData.Name;
		if (string.IsNullOrEmpty(text))
		{
			text = "UNNAMED";
		}
		AddTag(nbtClipboardData.Node, MakeUniqueName(text));
		return true;
	}

	public override bool DeleteTag(TagNode tag)
	{
		return _container.DeleteTag(tag);
	}

	public bool ContainsTag(string name)
	{
		return _container.ContainsTag(name);
	}

	public override void SyncTag()
	{
		Dictionary<TagNode, TagDataNode> dictionary = new Dictionary<TagNode, TagDataNode>();
		foreach (TagDataNode node in base.Nodes)
		{
			dictionary[node.Tag] = node;
		}
		foreach (KeyValuePair<TagNode, TagDataNode> item in dictionary)
		{
			if (!Tag.Values.Contains(item.Key))
			{
				base.Nodes.Remove(item.Value);
			}
		}
		foreach (TagNode value in Tag.Values)
		{
			if (!dictionary.ContainsKey(value))
			{
				TagDataNode tagDataNode2 = TagDataNode.CreateFromTag(value);
				if (tagDataNode2 != null)
				{
					base.Nodes.Add(tagDataNode2);
					tagDataNode2.Expand();
				}
			}
		}
		foreach (TagDataNode node2 in base.Nodes)
		{
			node2.SyncTag();
		}
	}

	private void AddTag(TagNode tag, string name)
	{
		_container.AddTag(tag, name);
		base.IsDataModified = true;
		if (base.IsExpanded)
		{
			TagDataNode tagDataNode = TagDataNode.CreateFromTag(tag);
			if (tagDataNode != null)
			{
				base.Nodes.Add(tagDataNode);
			}
		}
	}

	private string MakeUniqueName(string name)
	{
		List<string> list = new List<string>(_container.TagNamesInUse);
		if (!list.Contains(name))
		{
			return name;
		}
		int i;
		for (i = 1; list.Contains(MakeCandidateName(name, i)); i++)
		{
		}
		return MakeCandidateName(name, i);
	}

	private string MakeCandidateName(string name, int index)
	{
		return name + " (Copy " + index + ")";
	}
}
