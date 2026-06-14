using System;
using System.IO;
using Substrate.Nbt;

namespace NBTModel.Interop;

public class NbtClipboardData
{
	private string _name;

	private TagNode _node;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public TagNode Node
	{
		get
		{
			return _node;
		}
		set
		{
			_node = value;
		}
	}

	public NbtClipboardData(string name, TagNode node)
	{
		_name = name;
		_node = node;
	}

	public static byte[] SerializeNode(TagNode node)
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound.Add("root", node);
		NbtTree nbtTree = new NbtTree(tagNodeCompound);
		nbtTree.UseBigEndian = true;
		using MemoryStream memoryStream = new MemoryStream();
		nbtTree.WriteTo(memoryStream);
		byte[] array = new byte[memoryStream.Length];
		Array.Copy(memoryStream.GetBuffer(), array, memoryStream.Length);
		return array;
	}

	public static TagNode DeserializeNode(byte[] data)
	{
		NbtTree nbtTree = new NbtTree();
		nbtTree.UseBigEndian = true;
		using (MemoryStream s = new MemoryStream(data))
		{
			nbtTree.ReadFrom(s);
		}
		TagNodeCompound root = nbtTree.Root;
		if (root == null || !root.ContainsKey("root"))
		{
			return null;
		}
		return root["root"];
	}
}
