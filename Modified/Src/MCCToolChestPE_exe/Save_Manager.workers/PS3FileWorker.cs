using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Save_Manager.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.workers;

public class PS3FileWorker
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<PS3GameFile> LoadFileList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<PS3GameFile> list = new List<PS3GameFile>();
		DriveInfo[] drives = DriveInfo.GetDrives();
		DriveInfo[] array = drives;
		foreach (DriveInfo driveInfo in array)
		{
			_ = driveInfo.IsReady;
			if (!driveInfo.IsReady || !(driveInfo.DriveFormat == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209234)) || driveInfo.DriveType != DriveType.Removable || !Directory.Exists(driveInfo.Name + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209248)))
			{
				continue;
			}
			string[] directories = Directory.GetDirectories(driveInfo.Name + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209248));
			string[] array2 = directories;
			foreach (string text in array2)
			{
				string text2 = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100);
				if (File.Exists(text2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70730)) && File.Exists(text2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209276)))
				{
					PS3GameFile pS3GameFile = q7mSeYviijr(text2);
					if (pS3GameFile != null)
					{
						list.Add(pS3GameFile);
					}
				}
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PS3GameFile q7mSeYviijr(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PS3GameFile pS3GameFile = null;
		string path = P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209276);
		if (File.Exists(path))
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));
			binaryReader.BaseStream.Position = 2608L;
			string text = tURSe3HvgCb(binaryReader);
			if (text.StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209298)))
			{
				pS3GameFile = new PS3GameFile();
				binaryReader.BaseStream.Position = 2480L;
				string name = tURSe3HvgCb(binaryReader);
				pS3GameFile.Name = name;
				pS3GameFile.Path = P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70730);
				pS3GameFile.Size = uBISe10xPN6(P_0);
				pS3GameFile.ImageBytes = XSUSeECwJiR(P_0);
			}
		}
		return pS3GameFile;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string tURSe3HvgCb(BinaryReader P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<byte> list = new List<byte>();
		byte b;
		do
		{
			b = P_0.ReadByte();
			if (b != 0)
			{
				list.Add(b);
			}
		}
		while (b != 0);
		return Encoding.Default.GetString(list.ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long uBISe10xPN6(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string fileName = P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70730);
		return new FileInfo(fileName).Length;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] XSUSeECwJiR(string P_0)
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
	public PS3FileWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
