using System;
using System.Collections.Generic;
using NBTModel.Interop;
using Substrate.Nbt;

namespace NBTExplorer.Model;

public abstract class TagDataNode : DataNode
{
	public abstract class Container : TagDataNode, IMetaTagContainer, ITagContainer
	{
		public virtual int TagCount => 0;

		public virtual bool IsNamedContainer => false;

		public virtual bool IsOrderedContainer => false;

		public virtual INamedTagContainer NamedTagContainer => null;

		public virtual IOrderedTagContainer OrderedTagContainer => null;

		protected override NodeCapabilities Capabilities => (NodeCapabilities)(0x67 | ((base.TagParent != null && base.TagParent.IsNamedContainer) ? 8 : 0) | ((base.TagParent != null && base.TagParent.IsOrderedContainer) ? 256 : 0) | 0x80);

		public override bool HasUnexpandedChildren
		{
			get
			{
				if (!base.IsExpanded)
				{
					return TagCount > 0;
				}
				return false;
			}
		}

		public override bool IsContainerType => true;

		public override string NodeDisplay => base.NodeDisplayPrefix + TagCount + ((TagCount == 1) ? " entry" : " entries");

		protected Container(TagNode tag)
			: base(tag)
		{
		}

		public virtual bool DeleteTag(TagNode tag)
		{
			return false;
		}

		public virtual void Clear()
		{
		}
	}

	private static Dictionary<TagType, Type> _tagRegistry;

	private TagNode _tag;

	protected IMetaTagContainer TagParent => base.Parent as IMetaTagContainer;

	public TagNode Tag
	{
		get
		{
			return _tag;
		}
		protected set
		{
			if (_tag.GetTagType() == value.GetTagType())
			{
				_tag = value;
			}
		}
	}

	protected override NodeCapabilities Capabilities => (NodeCapabilities)(0x33 | ((TagParent != null && TagParent.IsNamedContainer) ? 8 : 0) | ((TagParent != null && TagParent.IsOrderedContainer) ? 256 : 0));

	public override bool CanMoveNodeUp
	{
		get
		{
			if (TagParent != null && TagParent.IsOrderedContainer)
			{
				return TagParent.OrderedTagContainer.GetTagIndex(Tag) > 0;
			}
			return false;
		}
	}

	public override bool CanMoveNodeDown
	{
		get
		{
			if (TagParent != null && TagParent.IsOrderedContainer)
			{
				return TagParent.OrderedTagContainer.GetTagIndex(Tag) < TagParent.TagCount - 1;
			}
			return false;
		}
	}

	public override string NodeName
	{
		get
		{
			if (TagParent == null || !TagParent.IsNamedContainer)
			{
				return null;
			}
			return TagParent.NamedTagContainer.GetTagName(Tag);
		}
	}

	public override string NodePathName
	{
		get
		{
			if (base.Parent is Container)
			{
				Container container = base.Parent as Container;
				if (container.IsOrderedContainer)
				{
					return container.OrderedTagContainer.GetTagIndex(Tag).ToString();
				}
			}
			return base.NodePathName;
		}
	}

	protected string NodeDisplayPrefix
	{
		get
		{
			string nodeName = NodeName;
			if (!string.IsNullOrEmpty(nodeName))
			{
				return nodeName + ": ";
			}
			return "";
		}
	}

	public override string NodeDisplay => NodeDisplayPrefix + Tag.ToString();

	static TagDataNode()
	{
		_tagRegistry = new Dictionary<TagType, Type>();
		_tagRegistry[TagType.TAG_BYTE] = typeof(TagByteDataNode);
		_tagRegistry[TagType.TAG_BYTE_ARRAY] = typeof(TagByteArrayDataNode);
		_tagRegistry[TagType.TAG_COMPOUND] = typeof(TagCompoundDataNode);
		_tagRegistry[TagType.TAG_DOUBLE] = typeof(TagDoubleDataNode);
		_tagRegistry[TagType.TAG_FLOAT] = typeof(TagFloatDataNode);
		_tagRegistry[TagType.TAG_INT] = typeof(TagIntDataNode);
		_tagRegistry[TagType.TAG_INT_ARRAY] = typeof(TagIntArrayDataNode);
		_tagRegistry[TagType.TAG_LIST] = typeof(TagListDataNode);
		_tagRegistry[TagType.TAG_LONG] = typeof(TagLongDataNode);
		_tagRegistry[TagType.TAG_LONG_ARRAY] = typeof(TagLongArrayDataNode);
		_tagRegistry[TagType.TAG_SHORT] = typeof(TagShortDataNode);
		_tagRegistry[TagType.TAG_SHORT_ARRAY] = typeof(TagShortArrayDataNode);
		_tagRegistry[TagType.TAG_STRING] = typeof(TagStringDataNode);
	}

	public static TagDataNode CreateFromTag(TagNode tag)
	{
		if (tag == null || !_tagRegistry.ContainsKey(tag.GetTagType()))
		{
			return null;
		}
		return Activator.CreateInstance(_tagRegistry[tag.GetTagType()], tag) as TagDataNode;
	}

	public static TagNode DefaultTag(TagType type)
	{
		return type switch
		{
			TagType.TAG_BYTE => new TagNodeByte(0), 
			TagType.TAG_BYTE_ARRAY => new TagNodeByteArray(new byte[0]), 
			TagType.TAG_COMPOUND => new TagNodeCompound(), 
			TagType.TAG_DOUBLE => new TagNodeDouble(0.0), 
			TagType.TAG_FLOAT => new TagNodeFloat(0f), 
			TagType.TAG_INT => new TagNodeInt(0), 
			TagType.TAG_INT_ARRAY => new TagNodeIntArray(new int[0]), 
			TagType.TAG_LIST => new TagNodeList(TagType.TAG_BYTE), 
			TagType.TAG_LONG => new TagNodeLong(0L), 
			TagType.TAG_LONG_ARRAY => new TagNodeLongArray(new long[0]), 
			TagType.TAG_SHORT => new TagNodeShort(0), 
			TagType.TAG_SHORT_ARRAY => new TagNodeShortArray(new short[0]), 
			TagType.TAG_STRING => new TagNodeString(""), 
			_ => new TagNodeByte(0), 
		};
	}

	protected TagDataNode(TagNode tag)
	{
		_tag = tag;
	}

	public virtual bool Parse(string value)
	{
		return false;
	}

	public override bool DeleteNode()
	{
		if (CanDeleteNode && TagParent != null)
		{
			TagParent.DeleteTag(Tag);
			base.IsParentModified = true;
			return base.Parent.Nodes.Remove(this);
		}
		return false;
	}

	public override bool RenameNode()
	{
		if (CanRenameNode && TagParent != null && TagParent.IsNamedContainer && FormRegistry.EditString != null)
		{
			RestrictedStringFormData restrictedStringFormData = new RestrictedStringFormData(TagParent.NamedTagContainer.GetTagName(Tag));
			restrictedStringFormData.RestrictedValues.AddRange(TagParent.NamedTagContainer.TagNamesInUse);
			if (FormRegistry.RenameTag(restrictedStringFormData) && TagParent.NamedTagContainer.RenameTag(Tag, restrictedStringFormData.Value))
			{
				base.IsDataModified = true;
				return true;
			}
		}
		return false;
	}

	public override bool CopyNode()
	{
		if (CanCopyNode)
		{
			NbtClipboardController.CopyToClipboard(new NbtClipboardData(NodeName, Tag));
			return true;
		}
		return false;
	}

	public override bool CutNode()
	{
		if (CanCutNode && TagParent != null)
		{
			NbtClipboardController.CopyToClipboard(new NbtClipboardData(NodeName, Tag));
			TagParent.DeleteTag(Tag);
			base.IsParentModified = true;
			base.Parent.Nodes.Remove(this);
			return true;
		}
		return false;
	}

	public override bool ChangeRelativePosition(int offset)
	{
		if (CanReoderNode && TagParent != null)
		{
			int tagIndex = TagParent.OrderedTagContainer.GetTagIndex(Tag);
			int num = tagIndex + offset;
			if (num < 0 || num >= TagParent.OrderedTagContainer.TagCount)
			{
				return false;
			}
			TagParent.OrderedTagContainer.DeleteTag(Tag);
			TagParent.OrderedTagContainer.InsertTag(Tag, num);
			DataNode parent = base.Parent;
			parent.Nodes.Remove(this);
			parent.Nodes.Insert(num, this);
			base.IsParentModified = true;
			return true;
		}
		return false;
	}

	protected bool EditScalarValue(TagNode tag)
	{
		if (FormRegistry.EditTagScalar != null && FormRegistry.EditTagScalar(new TagScalarFormData(tag)))
		{
			base.IsDataModified = true;
			return true;
		}
		return false;
	}

	protected bool EditStringValue(TagNode tag)
	{
		if (FormRegistry.EditString != null)
		{
			StringFormData stringFormData = new StringFormData(tag.ToTagString().Data);
			if (FormRegistry.EditString(stringFormData))
			{
				tag.ToTagString().Data = stringFormData.Value;
				base.IsDataModified = true;
				return true;
			}
		}
		return false;
	}

	protected bool EditByteHexValue(TagNode tag)
	{
		if (FormRegistry.EditByteArray != null)
		{
			byte[] array = new byte[tag.ToTagByteArray().Length];
			Array.Copy(tag.ToTagByteArray().Data, array, array.Length);
			ByteArrayFormData byteArrayFormData = new ByteArrayFormData();
			byteArrayFormData.NodeName = NodeName;
			byteArrayFormData.BytesPerElement = 1;
			byteArrayFormData.Data = array;
			ByteArrayFormData byteArrayFormData2 = byteArrayFormData;
			if (FormRegistry.EditByteArray(byteArrayFormData2))
			{
				tag.ToTagByteArray().Data = byteArrayFormData2.Data;
				base.IsDataModified = true;
				return true;
			}
		}
		return false;
	}

	protected bool EditShortHexValue(TagNode tag)
	{
		if (FormRegistry.EditByteArray != null)
		{
			TagNodeShortArray tagNodeShortArray = tag.ToTagShortArray();
			byte[] array = new byte[tagNodeShortArray.Length * 2];
			for (int i = 0; i < tagNodeShortArray.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(tagNodeShortArray.Data[i]);
				Array.Copy(bytes, 0, array, 2 * i, 2);
			}
			ByteArrayFormData byteArrayFormData = new ByteArrayFormData();
			byteArrayFormData.NodeName = NodeName;
			byteArrayFormData.BytesPerElement = 2;
			byteArrayFormData.Data = array;
			ByteArrayFormData byteArrayFormData2 = byteArrayFormData;
			if (FormRegistry.EditByteArray(byteArrayFormData2))
			{
				tagNodeShortArray.Data = new short[byteArrayFormData2.Data.Length / 2];
				for (int j = 0; j < tagNodeShortArray.Length; j++)
				{
					tagNodeShortArray.Data[j] = BitConverter.ToInt16(byteArrayFormData2.Data, j * 2);
				}
				base.IsDataModified = true;
				return true;
			}
		}
		return false;
	}

	protected bool EditIntHexValue(TagNode tag)
	{
		if (FormRegistry.EditByteArray != null)
		{
			TagNodeIntArray tagNodeIntArray = tag.ToTagIntArray();
			byte[] array = new byte[tagNodeIntArray.Length * 4];
			for (int i = 0; i < tagNodeIntArray.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(tagNodeIntArray.Data[i]);
				Array.Copy(bytes, 0, array, 4 * i, 4);
			}
			ByteArrayFormData byteArrayFormData = new ByteArrayFormData();
			byteArrayFormData.NodeName = NodeName;
			byteArrayFormData.BytesPerElement = 4;
			byteArrayFormData.Data = array;
			ByteArrayFormData byteArrayFormData2 = byteArrayFormData;
			if (FormRegistry.EditByteArray(byteArrayFormData2))
			{
				tagNodeIntArray.Data = new int[byteArrayFormData2.Data.Length / 4];
				for (int j = 0; j < tagNodeIntArray.Length; j++)
				{
					tagNodeIntArray.Data[j] = BitConverter.ToInt32(byteArrayFormData2.Data, j * 4);
				}
				base.IsDataModified = true;
				return true;
			}
		}
		return false;
	}

	protected bool EditLongHexValue(TagNode tag)
	{
		if (FormRegistry.EditByteArray != null)
		{
			TagNodeLongArray tagNodeLongArray = tag.ToTagLongArray();
			byte[] array = new byte[tagNodeLongArray.Length * 8];
			for (int i = 0; i < tagNodeLongArray.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(tagNodeLongArray.Data[i]);
				Array.Copy(bytes, 0, array, 8 * i, 8);
			}
			ByteArrayFormData byteArrayFormData = new ByteArrayFormData();
			byteArrayFormData.NodeName = NodeName;
			byteArrayFormData.BytesPerElement = 8;
			byteArrayFormData.Data = array;
			ByteArrayFormData byteArrayFormData2 = byteArrayFormData;
			if (FormRegistry.EditByteArray(byteArrayFormData2))
			{
				tagNodeLongArray.Data = new long[byteArrayFormData2.Data.Length / 8];
				for (int j = 0; j < tagNodeLongArray.Length; j++)
				{
					tagNodeLongArray.Data[j] = BitConverter.ToInt64(byteArrayFormData2.Data, j * 8);
				}
				base.IsDataModified = true;
				return true;
			}
		}
		return false;
	}

	public virtual void SyncTag()
	{
	}
}
