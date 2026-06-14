using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Save_Manager.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.workers;

public class WiiUFileWorker
{
	private string[] hXsSeJO8bhL;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<WiiUGameFile> LoadFileList(string saviineFolder, string readFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<WiiUGameFile> list = new List<WiiUGameFile>();
		string[] array = hXsSeJO8bhL;
		foreach (string text in array)
		{
			string path = saviineFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209334) + text;
			if (Directory.Exists(path))
			{
				string[] directories = Directory.GetDirectories(path);
				string[] array2 = directories;
				foreach (string text2 in array2)
				{
					cJrSerUSHxH(list, text2);
				}
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cJrSerUSHxH(List<WiiUGameFile> P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] files = Directory.GetFiles(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209378));
		string[] array = files;
		foreach (string text in array)
		{
			WiiUGameFile wiiUGameFile = PShSe5sMSLy(text);
			if (wiiUGameFile != null)
			{
				P_0.Add(wiiUGameFile);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WiiUGameFile PShSe5sMSLy(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WiiUGameFile wiiUGameFile = null;
		if (File.Exists(P_0))
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(P_0, FileMode.Open));
			string text = P_0.Substring(0, P_0.Length - 4);
			wiiUGameFile = new WiiUGameFile();
			wiiUGameFile.Name = Om2Se6Duin1(binaryReader);
			wiiUGameFile.Path = text;
			wiiUGameFile.Size = WuqSeD5gikV(text);
			wiiUGameFile.ImageBytes = etiSeNuYJW3(binaryReader);
		}
		return wiiUGameFile;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string Om2Se6Duin1(BinaryReader P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = "";
		List<byte> list = new List<byte>();
		byte b;
		do
		{
			b = P_0.ReadByte();
			b = P_0.ReadByte();
			if (b != 0)
			{
				list.Add(b);
			}
		}
		while (b != 0);
		return Encoding.UTF8.GetString(list.ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] etiSeNuYJW3(BinaryReader P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[P_0.BaseStream.Length - 256];
		P_0.BaseStream.Position = 256L;
		return P_0.ReadBytes((int)P_0.BaseStream.Length - 256);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long WuqSeD5gikV(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new FileInfo(P_0).Length;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] zHbSecD0UQo(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209320);
		byte[] array = null;
		if (File.Exists(path))
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));
			long length = binaryReader.BaseStream.Length;
			binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			array = new byte[length];
			binaryReader.Read(array, 0, (int)length);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WiiUFileWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		hXsSeJO8bhL = new string[3]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209392),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209430),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209468)
		};
	}
}
