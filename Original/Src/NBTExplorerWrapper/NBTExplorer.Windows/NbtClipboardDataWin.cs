using System;
using NBTModel.Interop;
using Substrate.Nbt;

namespace NBTExplorer.Windows;

[Serializable]
public class NbtClipboardDataWin
{
	private string _name;

	private byte[] _data;

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
			return NbtClipboardData.DeserializeNode(_data);
		}
		set
		{
			_data = NbtClipboardData.SerializeNode(value);
		}
	}

	public NbtClipboardDataWin(NbtClipboardData data)
	{
		Name = data.Name;
		Node = data.Node;
	}
}
