using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Substrate.Core;

namespace Substrate.Nbt;

public class NbtTree : ICopyable<NbtTree>
{
	private static bool isFileBigEndian = true;

	private bool useBigEndian = true;

	private Stream _stream;

	private TagNodeCompound _root;

	private string _rootName = "";

	private static TagNodeNull _nulltag = new TagNodeNull();

	public static bool IsFileBigEndian
	{
		get
		{
			return isFileBigEndian;
		}
		set
		{
			isFileBigEndian = value;
		}
	}

	public bool UseBigEndian
	{
		get
		{
			return useBigEndian;
		}
		set
		{
			useBigEndian = value;
		}
	}

	public TagNodeCompound Root => _root;

	public string Name
	{
		get
		{
			return _rootName;
		}
		set
		{
			_rootName = value;
		}
	}

	public NbtTree()
	{
		useBigEndian = isFileBigEndian;
		_root = new TagNodeCompound();
	}

	public NbtTree(TagNodeCompound tree)
	{
		useBigEndian = isFileBigEndian;
		_root = tree;
	}

	public NbtTree(TagNodeCompound tree, string name)
	{
		useBigEndian = isFileBigEndian;
		_root = tree;
		_rootName = name;
	}

	public NbtTree(Stream s)
	{
		useBigEndian = isFileBigEndian;
		ReadFrom(s);
	}

	public void ReadFrom(Stream s)
	{
		if (s != null)
		{
			_stream = s;
			_root = ReadRoot();
			_stream = null;
		}
	}

	public void WriteTo(Stream s)
	{
		if (s != null)
		{
			_stream = s;
			if (_root != null)
			{
				WriteTag(_rootName, _root);
			}
			_stream = null;
		}
	}

	public void ChildrenWriteTo(Stream s)
	{
		if (s == null)
		{
			return;
		}
		_stream = s;
		if (_root != null)
		{
			foreach (string key in _root.Keys)
			{
				TagNode val = _root[key];
				WriteTag(key, val);
			}
		}
		_stream = null;
	}

	private TagNode ReadValue(TagType type)
	{
		return type switch
		{
			TagType.TAG_END => null, 
			TagType.TAG_BYTE => ReadByte(), 
			TagType.TAG_SHORT => ReadShort(), 
			TagType.TAG_INT => ReadInt(), 
			TagType.TAG_LONG => ReadLong(), 
			TagType.TAG_FLOAT => ReadFloat(), 
			TagType.TAG_DOUBLE => ReadDouble(), 
			TagType.TAG_BYTE_ARRAY => ReadByteArray(), 
			TagType.TAG_STRING => ReadString(), 
			TagType.TAG_LIST => ReadList(), 
			TagType.TAG_COMPOUND => ReadCompound(), 
			TagType.TAG_INT_ARRAY => ReadIntArray(), 
			TagType.TAG_LONG_ARRAY => ReadLongArray(), 
			TagType.TAG_SHORT_ARRAY => ReadShortArray(), 
			_ => throw new Exception(), 
		};
	}

	private TagNode ReadByte()
	{
		int num = _stream.ReadByte();
		if (num == -1)
		{
			throw new NBTException("Gzip Error: Unexpected end of stream");
		}
		return new TagNodeByte((byte)num);
	}

	private TagNode ReadShort()
	{
		byte[] array = new byte[2];
		_stream.Read(array, 0, 2);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		return new TagNodeShort(BitConverter.ToInt16(array, 0));
	}

	private TagNode ReadInt()
	{
		byte[] array = new byte[4];
		_stream.Read(array, 0, 4);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		return new TagNodeInt(BitConverter.ToInt32(array, 0));
	}

	private TagNode ReadLong()
	{
		byte[] array = new byte[8];
		_stream.Read(array, 0, 8);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		return new TagNodeLong(BitConverter.ToInt64(array, 0));
	}

	private TagNode ReadFloat()
	{
		byte[] array = new byte[4];
		_stream.Read(array, 0, 4);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		return new TagNodeFloat(BitConverter.ToSingle(array, 0));
	}

	private TagNode ReadDouble()
	{
		byte[] array = new byte[8];
		_stream.Read(array, 0, 8);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		return new TagNodeDouble(BitConverter.ToDouble(array, 0));
	}

	private TagNode ReadByteArray()
	{
		byte[] array = new byte[4];
		_stream.Read(array, 0, 4);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		int num = BitConverter.ToInt32(array, 0);
		if (num < 0)
		{
			throw new NBTException("Read Error: Negative length");
		}
		byte[] array2 = new byte[num];
		_stream.Read(array2, 0, num);
		return new TagNodeByteArray(array2);
	}

	private TagNode ReadString()
	{
		byte[] array = new byte[2];
		_stream.Read(array, 0, 2);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		short num = BitConverter.ToInt16(array, 0);
		if (num < 0)
		{
			throw new NBTException("Read Error: Negative length");
		}
		byte[] array2 = new byte[num];
		_stream.Read(array2, 0, num);
		Encoding uTF = Encoding.UTF8;
		return new TagNodeString(uTF.GetString(array2));
	}

	private TagNode ReadList()
	{
		int num = _stream.ReadByte();
		if (num == -1)
		{
			throw new NBTException("Gzip Error: Unexpected end of stream");
		}
		TagNodeList tagNodeList = new TagNodeList((TagType)num);
		if ((int)tagNodeList.ValueType > Enum.GetValues(typeof(TagType)).GetUpperBound(0))
		{
			throw new NBTException("Read Error: Invalid value type");
		}
		byte[] array = new byte[4];
		_stream.Read(array, 0, 4);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		int num2 = BitConverter.ToInt32(array, 0);
		if (num2 < 0)
		{
			throw new NBTException("Read Error: Negative length");
		}
		if (tagNodeList.ValueType == TagType.TAG_END)
		{
			return new TagNodeList(TagType.TAG_BYTE);
		}
		for (int i = 0; i < num2; i++)
		{
			tagNodeList.Add(ReadValue(tagNodeList.ValueType));
		}
		return tagNodeList;
	}

	private TagNode ReadCompound()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		while (ReadTag(tagNodeCompound))
		{
		}
		return tagNodeCompound;
	}

	private TagNode ReadIntArray()
	{
		byte[] array = new byte[4];
		_stream.Read(array, 0, 4);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		int num = BitConverter.ToInt32(array, 0);
		if (num < 0)
		{
			throw new NBTException("Read Error: Negative length");
		}
		int[] array2 = new int[num];
		byte[] array3 = new byte[4];
		for (int i = 0; i < num; i++)
		{
			_stream.Read(array3, 0, 4);
			if (BitConverter.IsLittleEndian && UseBigEndian)
			{
				Array.Reverse(array3);
			}
			array2[i] = BitConverter.ToInt32(array3, 0);
		}
		return new TagNodeIntArray(array2);
	}

	private TagNode ReadLongArray()
	{
		byte[] array = new byte[4];
		_stream.Read(array, 0, 4);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		int num = BitConverter.ToInt32(array, 0);
		if (num < 0)
		{
			throw new NBTException("Read Error: Negative length");
		}
		long[] array2 = new long[num];
		byte[] array3 = new byte[8];
		for (int i = 0; i < num; i++)
		{
			_stream.Read(array3, 0, 8);
			if (BitConverter.IsLittleEndian && UseBigEndian)
			{
				Array.Reverse(array3);
			}
			array2[i] = BitConverter.ToInt64(array3, 0);
		}
		return new TagNodeLongArray(array2);
	}

	private TagNode ReadShortArray()
	{
		byte[] array = new byte[4];
		_stream.Read(array, 0, 4);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(array);
		}
		int num = BitConverter.ToInt32(array, 0);
		if (num < 0)
		{
			throw new NBTException("Read Error: Negative length");
		}
		short[] array2 = new short[num];
		byte[] array3 = new byte[2];
		for (int i = 0; i < num; i++)
		{
			_stream.Read(array3, 0, 2);
			if (BitConverter.IsLittleEndian && UseBigEndian)
			{
				Array.Reverse(array3);
			}
			array2[i] = BitConverter.ToInt16(array3, 0);
		}
		return new TagNodeShortArray(array2);
	}

	private TagNodeCompound ReadRoot()
	{
		TagType tagType = (TagType)_stream.ReadByte();
		if (tagType == TagType.TAG_COMPOUND)
		{
			_rootName = ReadString().ToTagString().Data;
			return ReadValue(tagType) as TagNodeCompound;
		}
		return null;
	}

	private bool ReadTag(TagNodeCompound parent)
	{
		TagType tagType = (TagType)_stream.ReadByte();
		if (tagType != TagType.TAG_END)
		{
			string data = ReadString().ToTagString().Data;
			parent[data] = ReadValue(tagType);
			return true;
		}
		return false;
	}

	private void WriteValue(TagNode val)
	{
		switch (val.GetTagType())
		{
		case TagType.TAG_BYTE:
			WriteByte(val.ToTagByte());
			break;
		case TagType.TAG_SHORT:
			WriteShort(val.ToTagShort());
			break;
		case TagType.TAG_INT:
			WriteInt(val.ToTagInt());
			break;
		case TagType.TAG_LONG:
			WriteLong(val.ToTagLong());
			break;
		case TagType.TAG_FLOAT:
			WriteFloat(val.ToTagFloat());
			break;
		case TagType.TAG_DOUBLE:
			WriteDouble(val.ToTagDouble());
			break;
		case TagType.TAG_BYTE_ARRAY:
			WriteByteArray(val.ToTagByteArray());
			break;
		case TagType.TAG_STRING:
			WriteString(val.ToTagString());
			break;
		case TagType.TAG_LIST:
			WriteList(val.ToTagList());
			break;
		case TagType.TAG_COMPOUND:
			WriteCompound(val.ToTagCompound());
			break;
		case TagType.TAG_INT_ARRAY:
			WriteIntArray(val.ToTagIntArray());
			break;
		case TagType.TAG_LONG_ARRAY:
			WriteLongArray(val.ToTagLongArray());
			break;
		case TagType.TAG_SHORT_ARRAY:
			WriteShortArray(val.ToTagShortArray());
			break;
		case TagType.TAG_END:
			break;
		}
	}

	private void WriteByte(TagNodeByte val)
	{
		_stream.WriteByte(val.Data);
	}

	private void WriteShort(TagNodeShort val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Data);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.Write(bytes, 0, 2);
	}

	private void WriteInt(TagNodeInt val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Data);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.Write(bytes, 0, 4);
	}

	private void WriteLong(TagNodeLong val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Data);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.Write(bytes, 0, 8);
	}

	private void WriteFloat(TagNodeFloat val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Data);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.Write(bytes, 0, 4);
	}

	private void WriteDouble(TagNodeDouble val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Data);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.Write(bytes, 0, 8);
	}

	private void WriteByteArray(TagNodeByteArray val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Length);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.Write(bytes, 0, 4);
		_stream.Write(val.Data, 0, val.Length);
	}

	private void WriteString(TagNodeString val)
	{
		Encoding uTF = Encoding.UTF8;
		byte[] bytes = uTF.GetBytes(val.Data);
		byte[] bytes2 = BitConverter.GetBytes((short)bytes.Length);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes2);
		}
		_stream.Write(bytes2, 0, 2);
		_stream.Write(bytes, 0, bytes.Length);
	}

	private void WriteList(TagNodeList val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Count);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.WriteByte((byte)val.ValueType);
		_stream.Write(bytes, 0, 4);
		foreach (TagNode item in val)
		{
			WriteValue(item);
		}
	}

	private void WriteCompound(TagNodeCompound val)
	{
		foreach (KeyValuePair<string, TagNode> item in val)
		{
			WriteTag(item.Key, item.Value);
		}
		WriteTag(null, _nulltag);
	}

	private void WriteIntArray(TagNodeIntArray val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Length);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.Write(bytes, 0, 4);
		byte[] array = new byte[val.Length * 4];
		for (int i = 0; i < val.Length; i++)
		{
			byte[] bytes2 = BitConverter.GetBytes(val.Data[i]);
			if (BitConverter.IsLittleEndian && UseBigEndian)
			{
				Array.Reverse(bytes2);
			}
			Array.Copy(bytes2, 0, array, i * 4, 4);
		}
		_stream.Write(array, 0, array.Length);
	}

	private void WriteLongArray(TagNodeLongArray val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Length);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.Write(bytes, 0, 4);
		byte[] array = new byte[val.Length * 8];
		for (int i = 0; i < val.Length; i++)
		{
			byte[] bytes2 = BitConverter.GetBytes(val.Data[i]);
			if (BitConverter.IsLittleEndian && UseBigEndian)
			{
				Array.Reverse(bytes2);
			}
			Array.Copy(bytes2, 0, array, i * 8, 8);
		}
		_stream.Write(array, 0, array.Length);
	}

	private void WriteShortArray(TagNodeShortArray val)
	{
		byte[] bytes = BitConverter.GetBytes(val.Length);
		if (BitConverter.IsLittleEndian && UseBigEndian)
		{
			Array.Reverse(bytes);
		}
		_stream.Write(bytes, 0, 4);
		byte[] array = new byte[val.Length * 2];
		for (int i = 0; i < val.Length; i++)
		{
			byte[] bytes2 = BitConverter.GetBytes(val.Data[i]);
			if (BitConverter.IsLittleEndian && UseBigEndian)
			{
				Array.Reverse(bytes2);
			}
			Array.Copy(bytes2, 0, array, i * 2, 2);
		}
		_stream.Write(array, 0, array.Length);
	}

	private void WriteTag(string name, TagNode val)
	{
		_stream.WriteByte((byte)val.GetTagType());
		if (val.GetTagType() != TagType.TAG_END)
		{
			WriteString(name);
			WriteValue(val);
		}
	}

	public NbtTree Copy()
	{
		NbtTree nbtTree = new NbtTree();
		nbtTree._root = _root.Copy() as TagNodeCompound;
		return nbtTree;
	}
}
