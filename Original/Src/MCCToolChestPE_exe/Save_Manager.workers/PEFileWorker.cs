using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.PECode;
using MCCToolChest.utils;
using Save_Manager.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.workers;

public class PEFileWorker
{
	[CompilerGenerated]
	private static Func<PEWorldFolder, DateTime> OpTSekR8ULR;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<PEWorldFolder> LoadFileList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<PEWorldFolder> list = new List<PEWorldFolder>();
		string text = string.Empty;
		try
		{
			text = Utils.GetGetMCPESaveFolder();
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
							PEWorldFolder pEWorldFolder = lhxSeUZEKtL(text2);
							if (pEWorldFolder != null)
							{
								list.Add(pEWorldFolder);
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			list = list.OrderByDescending([MethodImpl(MethodImplOptions.NoInlining)] (PEWorldFolder P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.Date;
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
	private PEWorldFolder lhxSeUZEKtL(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEWorldFolder pEWorldFolder = null;
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516));
		if (File.Exists(path))
		{
			pEWorldFolder = new PEWorldFolder();
			DirectoryInfo directoryInfo = new DirectoryInfo(P_0);
			TagNodeCompound tagNodeCompound = PEUtility.LoadPELevelRaw(P_0);
			pEWorldFolder.Name = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)] as TagNodeString;
			pEWorldFolder.GameType = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71312)] as TagNodeInt;
			pEWorldFolder.Path = P_0;
			pEWorldFolder.Size = YkTSePHmHqN(directoryInfo);
			long num = (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71344)) ? (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71344)] as TagNodeLong) : ((TagNodeLong)0));
			pEWorldFolder.Date = Utils.UnixTimeStampToDateTime(num);
			pEWorldFolder.ImageBytes = rmlSegTZKmO(P_0);
		}
		return pEWorldFolder;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long KQcSeLD5UJQ(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return 0L;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] rmlSegTZKmO(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52776));
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
	private long YkTSePHmHqN(DirectoryInfo P_0)
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
			num += YkTSePHmHqN(directoryInfo);
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEFileWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static DateTime GA3SeRcMDI3(PEWorldFolder P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Date;
	}
}
