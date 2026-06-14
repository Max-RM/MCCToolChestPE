using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FolderSelect;
using PdZ7Q5ulfs6I7OgARis;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public class FileUtils
{
	public enum ByteOrder
	{
		LittleEndian,
		BigEndian
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static byte[] pURSg6Zk53A(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = null;
		if (File.Exists(P_0))
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(P_0, FileMode.Open));
			long length = binaryReader.BaseStream.Length;
			binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			array = new byte[length];
			binaryReader.Read(array, 0, (int)length);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string BugSgNoWh4E(string P_0, string P_1, string P_2, string P_3 = "")
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		string result = null;
		P_2 = ibGSgD3rXpX(P_2);
		openFileDialog.DefaultExt = P_0;
		openFileDialog.Filter = P_1;
		openFileDialog.InitialDirectory = P_2;
		openFileDialog.FileName = P_3;
		DialogResult dialogResult = openFileDialog.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			result = openFileDialog.FileName;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string ibGSgD3rXpX(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			if (!string.IsNullOrWhiteSpace(P_0))
			{
				P_0 = Path.GetDirectoryName(P_0);
			}
		}
		catch (Exception)
		{
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string VXKSgcyptXi(string P_0, string P_1, string P_2, string P_3 = "")
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		string result = null;
		saveFileDialog.DefaultExt = P_0;
		saveFileDialog.Filter = P_1;
		saveFileDialog.InitialDirectory = P_2;
		saveFileDialog.FileName = P_3;
		DialogResult dialogResult = saveFileDialog.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			result = saveFileDialog.FileName;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string W66SgJArfAS(string P_0, string P_1 = "MC World Folder")
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = null;
		FolderSelectDialog folderSelectDialog = new FolderSelectDialog();
		folderSelectDialog.Title = P_1;
		folderSelectDialog.InitialDirectory = P_0;
		if (folderSelectDialog.ShowDialog(IntPtr.Zero))
		{
			result = folderSelectDialog.FileName;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string qUVSgu6gYOG(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = P_0;
		int num = text.LastIndexOf('\\');
		if (num > 0)
		{
			text = text.Substring(num + 1);
		}
		num = text.LastIndexOf('.');
		if (num > 0)
		{
			text = text.Substring(0, num);
		}
		return text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteFile(MemoryStream stream, string filename)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(filename, FileMode.Create));
		byte[] buffer = stream.ToArray();
		binaryWriter.Write(buffer);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteFile(byte[] bytes, string filename)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(filename, FileMode.Create));
		binaryWriter.Write(bytes);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static short ReadShort(BinaryReader reader)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[2];
		array = reader.ReadBytes(2);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(array);
		}
		return BitConverter.ToInt16(array, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] ReadBytes(BinaryReader reader, int fieldSize, ByteOrder byteOrder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[fieldSize];
		if (byteOrder == ByteOrder.LittleEndian)
		{
			return reader.ReadBytes(fieldSize);
		}
		for (int num = fieldSize - 1; num > -1; num--)
		{
			array[num] = reader.ReadByte();
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint ReadUInt32(BinaryReader reader, ByteOrder byteOrder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (byteOrder == ByteOrder.LittleEndian)
		{
			return (uint)reader.ReadInt32();
		}
		return BitConverter.ToUInt32(ReadBytes(reader, 4, ByteOrder.BigEndian), 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteUInt32(BinaryWriter writer, uint value, ByteOrder byteOrder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = BitConverter.GetBytes(value);
		if (byteOrder == ByteOrder.BigEndian)
		{
			array = array.Reverse().ToArray();
		}
		writer.Write(array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void mNASgoolwl6(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] files = Directory.GetFiles(P_0);
		foreach (string path in files)
		{
			File.Delete(path);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TTSSgQ9uTyR(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Directory.Exists(P_0))
		{
			Directory.CreateDirectory(P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string CheckFolderSep(string folderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (folderPath != null && !folderPath.EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100)))
		{
			folderPath += Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100);
		}
		return folderPath;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckFolderExists(string folderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		folderPath = CheckFolderSep(folderPath);
		return Directory.Exists(folderPath);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeleteFile(string filePath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (File.Exists(filePath))
		{
			File.Delete(filePath);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HONSgOivHYv(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (File.Exists(P_0))
		{
			File.Move(P_0, P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tDGSgCpUGpC(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (File.Exists(P_0))
		{
			if (File.Exists(P_1))
			{
				DeleteFile(P_1);
			}
			File.Copy(P_0, P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeleteDirectory(string target_dir)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] files = Directory.GetFiles(target_dir);
		string[] directories = Directory.GetDirectories(target_dir);
		string[] array = files;
		foreach (string path in array)
		{
			File.SetAttributes(path, FileAttributes.Normal);
			File.Delete(path);
		}
		string[] array2 = directories;
		foreach (string target_dir2 in array2)
		{
			DeleteDirectory(target_dir2);
		}
		Directory.Delete(target_dir, recursive: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CopyFoldersAndFiles(string source, string target)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DirectoryInfo source2 = new DirectoryInfo(source);
		DirectoryInfo target2 = new DirectoryInfo(target);
		CopyFoldersAndFiles(source2, target2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CopyFoldersAndFiles(DirectoryInfo source, DirectoryInfo target)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		aQPuvouUn6uQnBG85CL aQPuvouUn6uQnBG85CL2 = new aQPuvouUn6uQnBG85CL();
		DirectoryInfo[] directories = source.GetDirectories();
		foreach (DirectoryInfo directoryInfo in directories)
		{
			CopyFoldersAndFiles(directoryInfo, target.CreateSubdirectory(directoryInfo.Name));
		}
		FileInfo[] files = source.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			aQPuvouUn6uQnBG85CL2.sDXSYEhsqao(fileInfo.FullName, Path.Combine(target.FullName, fileInfo.Name));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FileUtils()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
