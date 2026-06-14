using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using MCCToolChest.utils;
using PortableDevices;
using Save_Manager.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.workers;

public class WPDPEFileWorker
{
	private enum FMcRDjjWy46qy7LqO3E
	{

	}

	private static Dictionary<string, Tuple<FMcRDjjWy46qy7LqO3E, FMcRDjjWy46qy7LqO3E>> UCHSWkwDxhi;

	private static FMcRDjjWy46qy7LqO3E sQ6SWY7cKq3;

	private List<PEWorldFolder> qUmSW3dEO9k;

	[CompilerGenerated]
	private static Func<PEWorldFolder, DateTime> tsOSW1ehtkU;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<PEWorldFolder> LoadFileList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qUmSW3dEO9k = new List<PEWorldFolder>();
		PortableDeviceCollection portableDeviceCollection = new PortableDeviceCollection();
		portableDeviceCollection.Refresh();
		foreach (PortableDevice item in portableDeviceCollection)
		{
			item.Connect();
			string friendlyName = item.FriendlyName;
			PortableDeviceFolder portableDeviceFolder = null;
			if (friendlyName.Length == 1 || (friendlyName.Length > 1 && friendlyName[1] != ':'))
			{
				Console.WriteLine(friendlyName);
				portableDeviceFolder = item.GetContents();
			}
			item.Disconnect();
			if (portableDeviceFolder == null)
			{
				continue;
			}
			foreach (PortableDeviceObject file in portableDeviceFolder.Files)
			{
				DisplayObject(item, file);
			}
		}
		qUmSW3dEO9k = qUmSW3dEO9k.OrderByDescending([MethodImpl(MethodImplOptions.NoInlining)] (PEWorldFolder P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.Date;
		}).ToList();
		return qUmSW3dEO9k;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisplayObject(PortableDevice device, PortableDeviceObject portableDeviceObject)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		sQ6SWY7cKq3 = (FMcRDjjWy46qy7LqO3E)0;
		Console.WriteLine(portableDeviceObject.Name);
		if (portableDeviceObject is PortableDeviceFolder)
		{
			WalkDeviceFolders(device, (PortableDeviceFolder)portableDeviceObject, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28858));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WalkDeviceFolders(PortableDevice device, PortableDeviceFolder folder, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (PortableDeviceObject file in folder.Files)
		{
			device.Connect();
			if (file is PortableDeviceFolder && UCHSWkwDxhi.ContainsKey(file.Name) && UCHSWkwDxhi[file.Name].Item2 == sQ6SWY7cKq3)
			{
				sQ6SWY7cKq3 = UCHSWkwDxhi[file.Name].Item1;
				if (sQ6SWY7cKq3 == (FMcRDjjWy46qy7LqO3E)3)
				{
					SeRSWxepT9d(device, file as PortableDeviceFolder);
					sQ6SWY7cKq3 = (FMcRDjjWy46qy7LqO3E)0;
					break;
				}
				WalkDeviceFolders(device, (PortableDeviceFolder)file, Path.Combine(path, file.Name));
				sQ6SWY7cKq3 = UCHSWkwDxhi[file.Name].Item1;
			}
			device.Disconnect();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SeRSWxepT9d(PortableDevice P_0, PortableDeviceFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (PortableDeviceObject file in P_1.Files)
		{
			P_0.Connect();
			if (file is PortableDeviceFolder)
			{
				PEWorldFolder pEWorldFolder = GdOSWMt8E2F(P_0, file as PortableDeviceFolder);
				if (pEWorldFolder != null)
				{
					qUmSW3dEO9k.Add(pEWorldFolder);
				}
			}
			P_0.Disconnect();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, Tuple<PortableDevice, PortableDeviceFile>> M4iSWealSc5(PortableDevice P_0, PortableDeviceFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, Tuple<PortableDevice, PortableDeviceFile>> dictionary = new Dictionary<string, Tuple<PortableDevice, PortableDeviceFile>>();
		foreach (PortableDeviceObject file in P_1.Files)
		{
			P_0.Connect();
			if (file is PortableDeviceFile)
			{
				PortableDeviceFile portableDeviceFile = file as PortableDeviceFile;
				dictionary.Add(portableDeviceFile.Name, new Tuple<PortableDevice, PortableDeviceFile>(P_0, portableDeviceFile));
			}
			P_0.Disconnect();
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PEWorldFolder GdOSWMt8E2F(PortableDevice P_0, PortableDeviceFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, Tuple<PortableDevice, PortableDeviceFile>> dictionary = M4iSWealSc5(P_0, P_1);
		PEWorldFolder pEWorldFolder = null;
		if (dictionary.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)))
		{
			pEWorldFolder = new PEWorldFolder();
			pEWorldFolder.FolderType = PEFolderType.WPD;
			pEWorldFolder.DeviceId = P_0.DeviceId;
			pEWorldFolder.FolderId = P_1.Id;
			TagNodeCompound tagNodeCompound = cgjSWgkpD9q(dictionary[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)].Item1, dictionary[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)].Item2);
			pEWorldFolder.Name = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)] as TagNodeString;
			pEWorldFolder.GameType = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71312)] as TagNodeInt;
			pEWorldFolder.Path = P_1.Name;
			long num = (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71344)) ? (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71344)] as TagNodeLong) : ((TagNodeLong)0));
			pEWorldFolder.Date = Utils.UnixTimeStampToDateTime(num);
			if (dictionary.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52776)))
			{
				pEWorldFolder.ImageBytes = x2HSWLbMjJc(dictionary[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52776)].Item1, dictionary[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52776)].Item2);
			}
		}
		return pEWorldFolder;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long VipSWUFd4ea(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return 0L;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] x2HSWLbMjJc(PortableDevice P_0, PortableDeviceFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Connect();
		byte[] result = P_0.DownloadFile(P_1);
		P_0.Disconnect();
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound cgjSWgkpD9q(PortableDevice P_0, PortableDeviceFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Connect();
		byte[] source = P_0.DownloadFile(P_1);
		P_0.Disconnect();
		MemoryStream s = new MemoryStream(source.Skip(8).ToArray());
		NbtTree nbtTree = new NbtTree();
		nbtTree.UseBigEndian = false;
		nbtTree.ReadFrom(s);
		return nbtTree.Root;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long iCVSWP6E7GJ(DirectoryInfo P_0)
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
			num += iCVSWP6E7GJ(directoryInfo);
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WPDPEFileWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static DateTime qL0SWRaHqGX(PEWorldFolder P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Date;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static WPDPEFileWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		UCHSWkwDxhi = new Dictionary<string, Tuple<FMcRDjjWy46qy7LqO3E, FMcRDjjWy46qy7LqO3E>>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85374),
				new Tuple<FMcRDjjWy46qy7LqO3E, FMcRDjjWy46qy7LqO3E>((FMcRDjjWy46qy7LqO3E)1, (FMcRDjjWy46qy7LqO3E)0)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85388),
				new Tuple<FMcRDjjWy46qy7LqO3E, FMcRDjjWy46qy7LqO3E>((FMcRDjjWy46qy7LqO3E)2, (FMcRDjjWy46qy7LqO3E)1)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85412),
				new Tuple<FMcRDjjWy46qy7LqO3E, FMcRDjjWy46qy7LqO3E>((FMcRDjjWy46qy7LqO3E)3, (FMcRDjjWy46qy7LqO3E)2)
			}
		};
		sQ6SWY7cKq3 = (FMcRDjjWy46qy7LqO3E)0;
	}
}
