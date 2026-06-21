using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.utils;
using Save_Manager.model;
using Substrate.Core;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.workers;

public class PCFileWorker
{
	[CompilerGenerated]
	private static Func<PCWorldFolder, string> sY7SWX15rLL;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<PCWorldFolder> LoadFileList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<PCWorldFolder> list = new List<PCWorldFolder>();
		string text = string.Empty;
		try
		{
			text = Utils.GetGetMCPCSaveFolder();
			string[] directories = Directory.GetDirectories(text);
			if (directories != null)
			{
				string[] array = directories;
				foreach (string text2 in array)
				{
					try
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							Path.GetFileName(text2);
							PCWorldFolder pCWorldFolder = mX7SW2WQhxW(text2);
							if (pCWorldFolder != null)
							{
								list.Add(pCWorldFolder);
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			list = list.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (PCWorldFolder P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.Name;
			}).ToList();
		}
		catch (Exception ex2)
		{
			string text3 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85264) + text + Environment.NewLine + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85296) + ex2.Message;
			MessageBox.Show(text3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85316));
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PCWorldFolder mX7SW2WQhxW(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PCWorldFolder pCWorldFolder = null;
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516));
		if (File.Exists(path))
		{
			pCWorldFolder = new PCWorldFolder();
			TagNodeCompound tagNodeCompound = IN5SWBGvnKl(P_0);
			pCWorldFolder.Name = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)] as TagNodeString;
			pCWorldFolder.GameType = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71312)] as TagNodeInt;
			pCWorldFolder.Path = P_0;
			long num = (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71344)) ? (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71344)] as TagNodeLong) : ((TagNodeLong)0));
			pCWorldFolder.Date = UnixTimeStampToDateTime(num);
			pCWorldFolder.ImageBytes = PYMSW0xsu6T(P_0);
		}
		return pCWorldFolder;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long UvkSWyGwM8j(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return 0L;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] PYMSW0xsu6T(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85354));
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
	public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		try
		{
			result = result.AddMilliseconds(unixTimeStamp).ToLocalTime();
			return result;
		}
		catch (Exception)
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound IN5SWBGvnKl(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516));
		if (File.Exists(path))
		{
			NBTFile nBTFile = new NBTFile(path);
			Stream dataInputStream = nBTFile.GetDataInputStream();
			if (dataInputStream != null)
			{
				NbtTree nbtTree = new NbtTree();
				nbtTree.UseBigEndian = true;
				nbtTree.ReadFrom(dataInputStream);
				result = nbtTree.Root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeCompound;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long zYbSWt095VI(DirectoryInfo P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		long num = 0L;
		FileInfo[] files = P_0.GetFiles();
		FileInfo[] array = files;
		foreach (FileInfo fileInfo in array)
		{
			num += fileInfo.Length;
		}
		DirectoryInfo[] directories = P_0.GetDirectories();
		DirectoryInfo[] array2 = directories;
		foreach (DirectoryInfo directoryInfo in array2)
		{
			num += zYbSWt095VI(directoryInfo);
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PCFileWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static string DXRSWaFOS0n(PCWorldFolder P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Name;
	}
}
