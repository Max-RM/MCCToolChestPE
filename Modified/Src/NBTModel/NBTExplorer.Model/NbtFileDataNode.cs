using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using NBTModel.Interop;
using Substrate.Core;
using Substrate.Nbt;

namespace NBTExplorer.Model;

public class NbtFileDataNode : DataNode, IMetaTagContainer, ITagContainer
{
	private NbtTree _tree;

	private string _path;

	private CompressionType _compressionType;

	private bool _bedrockHeaderFormat;

	private byte[] _bedrockHeader;

	private CompoundTagContainer _container;

	private static Regex _namePattern = new Regex("\\.(dat|nbt|schematic|dat_mcr|dat_old|bpt|rc)$");

	public NbtTree Tree
	{
		get
		{
			return _tree;
		}
		set
		{
			_tree = value;
		}
	}

	protected override NodeCapabilities Capabilities => NodeCapabilities.PasteInto | NodeCapabilities.Rename | NodeCapabilities.CreateTag | NodeCapabilities.Search | NodeCapabilities.Refresh;

	public override string NodeName => Path.GetFileName(_path);

	public override string NodePathName => Path.GetFileName(_path);

	public override string NodeDisplay
	{
		get
		{
			if (_tree != null && _tree.Root != null)
			{
				if (!string.IsNullOrEmpty(_tree.Name))
				{
					return NodeName + " [" + _tree.Name + ": " + _tree.Root.Count + " entries]";
				}
				return NodeName + " [" + _tree.Root.Count + " entries]";
			}
			return NodeName;
		}
	}

	public override bool HasUnexpandedChildren => !base.IsExpanded;

	public override bool IsContainerType => true;

	public override bool CanRenameNode => _tree != null;

	public override bool CanPasteIntoNode
	{
		get
		{
			if (_tree != null && _tree.Root != null)
			{
				return NbtClipboardController.ContainsData;
			}
			return false;
		}
	}

	public bool IsNamedContainer => true;

	public bool IsOrderedContainer => false;

	public INamedTagContainer NamedTagContainer => _container;

	public IOrderedTagContainer OrderedTagContainer => null;

	public int TagCount => _container.TagCount;

	private NbtFileDataNode(string path, CompressionType compressionType)
	{
		_path = path;
		_compressionType = compressionType;
		_container = new CompoundTagContainer(new TagNodeCompound());
	}

	public static NbtFileDataNode TryCreateFrom(string path)
	{
		return TryCreateFrom(path, CompressionType.GZip) ?? TryCreateFrom(path, CompressionType.None) ?? TryCreateBedrockFrom(path);
	}

	private static NbtFileDataNode TryCreateBedrockFrom(string path)
	{
		try
		{
			byte[] array = File.ReadAllBytes(path);
			if (array.Length <= 8)
			{
				return null;
			}
			MemoryStream memoryStream = new MemoryStream(array, 8, array.Length - 8, writable: false);
			NbtTree nbtTree = new NbtTree();
			nbtTree.UseBigEndian = false;
			nbtTree.ReadFrom(memoryStream);
			if (nbtTree.Root == null)
			{
				return null;
			}
			NbtFileDataNode nbtFileDataNode = new NbtFileDataNode(path, CompressionType.None);
			nbtFileDataNode._bedrockHeaderFormat = true;
			nbtFileDataNode._bedrockHeader = new byte[8];
			Array.Copy(array, 0, nbtFileDataNode._bedrockHeader, 0, 8);
			nbtFileDataNode._tree = nbtTree;
			nbtFileDataNode._container = new CompoundTagContainer(nbtTree.Root);
			return nbtFileDataNode;
		}
		catch
		{
			return null;
		}
	}

	private static NbtFileDataNode TryCreateFrom(string path, CompressionType compressionType)
	{
		try
		{
			NBTFile nBTFile = new NBTFile(path);
			NbtTree nbtTree = new NbtTree();
			nbtTree.ReadFrom(nBTFile.GetDataInputStream(compressionType));
			if (nbtTree.Root == null)
			{
				return null;
			}
			return new NbtFileDataNode(path, compressionType);
		}
		catch
		{
			return null;
		}
	}

	public static bool SupportedNamePattern(string path)
	{
		path = Path.GetFileName(path);
		return _namePattern.IsMatch(path);
	}

	protected override void ExpandCore()
	{
		if (_tree == null)
		{
			if (_bedrockHeaderFormat)
			{
				byte[] array = File.ReadAllBytes(_path);
				if (array.Length > 8)
				{
					MemoryStream memoryStream = new MemoryStream(array, 8, array.Length - 8, writable: false);
					_tree = new NbtTree();
					_tree.UseBigEndian = false;
					_tree.ReadFrom(memoryStream);
				}
			}
			else
			{
				NBTFile nBTFile = new NBTFile(_path);
				_tree = new NbtTree();
				_tree.ReadFrom(nBTFile.GetDataInputStream(_compressionType));
			}
			if (_tree.Root != null)
			{
				_container = new CompoundTagContainer(_tree.Root);
			}
		}
		SortedList<TagKey, TagNode> sortedList = new SortedList<TagKey, TagNode>();
		foreach (KeyValuePair<string, TagNode> item in _tree.Root)
		{
			sortedList.Add(new TagKey(item.Key, item.Value.GetTagType()), item.Value);
		}
		foreach (TagNode value in sortedList.Values)
		{
			TagDataNode tagDataNode = TagDataNode.CreateFromTag(value);
			if (tagDataNode != null)
			{
				base.Nodes.Add(tagDataNode);
			}
		}
	}

	protected override void ReleaseCore()
	{
		_tree = null;
		base.Nodes.Clear();
	}

	protected override void SaveCore()
	{
		if (_bedrockHeaderFormat)
		{
			MemoryStream memoryStream = new MemoryStream();
			_tree.UseBigEndian = false;
			_tree.WriteTo(memoryStream);
			byte[] array = memoryStream.ToArray();
			MemoryStream memoryStream2 = new MemoryStream();
			if (_bedrockHeader != null && _bedrockHeader.Length == 8)
			{
				memoryStream2.Write(_bedrockHeader, 0, 8);
			}
			else
			{
				memoryStream2.Write(BitConverter.GetBytes(1), 0, 4);
				memoryStream2.Write(BitConverter.GetBytes(array.Length), 0, 4);
			}
			memoryStream2.Write(array, 0, array.Length);
			File.WriteAllBytes(_path, memoryStream2.ToArray());
			return;
		}
		NBTFile nBTFile = new NBTFile(_path);
		using Stream s = nBTFile.GetDataOutputStream(_compressionType);
		_tree.WriteTo(s);
	}

	public override bool RefreshNode()
	{
		Dictionary<string, object> dictionary = BuildExpandSet(this);
		Release();
		RestoreExpandSet(this, dictionary);
		return dictionary != null;
	}

	public override bool RenameNode()
	{
		if (CanRenameNode && FormRegistry.EditString != null)
		{
			RestrictedStringFormData restrictedStringFormData = new RestrictedStringFormData(_tree.Name ?? "");
			restrictedStringFormData.AllowEmpty = true;
			RestrictedStringFormData restrictedStringFormData2 = restrictedStringFormData;
			if (FormRegistry.RenameTag(restrictedStringFormData2) && _tree.Name != restrictedStringFormData2.Value)
			{
				_tree.Name = restrictedStringFormData2.Value;
				base.IsDataModified = true;
				return true;
			}
		}
		return false;
	}

	public override bool CanCreateTag(TagType type)
	{
		if (_tree != null && _tree.Root != null && Enum.IsDefined(typeof(TagType), type))
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

	public bool DeleteTag(TagNode tag)
	{
		return _container.DeleteTag(tag);
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
