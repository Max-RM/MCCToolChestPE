using System;
using System.IO;
using System.Windows.Forms;
using NBTModel.Interop;
using Substrate.Nbt;

namespace NBTExplorer.Windows;

public class NbtClipboardControllerWin : INbtClipboardController
{
	public bool ContainsData
	{
		get
		{
			if (Clipboard.ContainsData(typeof(NbtClipboardDataWin).FullName))
			{
				return true;
			}
			if (Clipboard.ContainsText())
			{
				string text = Clipboard.GetText();
				if (text.Length % 2 == 0 && Utils.IsHex(text))
				{
					return true;
				}
			}
			return false;
		}
	}

	public void CopyToClipboard(NbtClipboardData data)
	{
		NbtClipboardDataWin data2 = new NbtClipboardDataWin(data);
		DataObject dataObject = new DataObject();
		Clipboard.SetDataObject(dataObject);
		NbtTree nbtTree = new NbtTree();
		nbtTree.UseBigEndian = true;
		string key = ((data.Name != null) ? data.Name : "");
		nbtTree.Root.Add(key, data.Node);
		MemoryStream memoryStream = new MemoryStream();
		nbtTree.ChildrenWriteTo(memoryStream);
		byte[] array = memoryStream.ToArray();
		string text = "0a0001" + Utils.ConvertByteToHexString(array[0]) + Utils.ConvertByteArrayToHexString(array) + "00";
		dataObject.SetData(typeof(NbtClipboardDataWin).FullName, autoConvert: true, data2);
		dataObject.SetText(text);
		Clipboard.SetDataObject(dataObject);
	}

	public NbtClipboardData CopyFromClipboard()
	{
		NbtClipboardDataWin nbtClipboardDataWin = Clipboard.GetData(typeof(NbtClipboardDataWin).FullName) as NbtClipboardDataWin;
		if (nbtClipboardDataWin == null)
		{
			string text = Clipboard.GetText();
			if (Utils.IsHex(text))
			{
				byte[] array = Utils.ConvertHexStringToByteArray(text);
				if (array != null && array.Length > 0)
				{
					NbtTree nbtTree = new NbtTree();
					nbtTree.UseBigEndian = true;
					using (MemoryStream s = new MemoryStream(array))
					{
						try
						{
							nbtTree.ReadFrom(s);
						}
						catch (Exception)
						{
						}
					}
					if (nbtTree != null && nbtTree.Root != null)
					{
						foreach (string key in nbtTree.Root.Keys)
						{
							TagNode node = nbtTree.Root[key];
							array = NbtClipboardData.SerializeNode(node);
							NbtClipboardData data = new NbtClipboardData(key, NbtClipboardData.DeserializeNode(array));
							nbtClipboardDataWin = new NbtClipboardDataWin(data);
						}
					}
				}
			}
		}
		if (nbtClipboardDataWin == null)
		{
			return null;
		}
		TagNode node2 = nbtClipboardDataWin.Node;
		if (node2 == null)
		{
			return null;
		}
		return new NbtClipboardData(nbtClipboardDataWin.Name, node2);
	}
}
