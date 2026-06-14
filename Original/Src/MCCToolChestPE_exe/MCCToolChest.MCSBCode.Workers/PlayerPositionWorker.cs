using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode.Workers;

public class PlayerPositionWorker
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LoadPlayersMapData()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<PlayerMapData> list = new List<PlayerMapData>();
		if (Directory.Exists(Working.T92StMGt1p4() + Working.WorkFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436)))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Working.T92StMGt1p4() + Working.WorkFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436));
			FileInfo[] files = directoryInfo.GetFiles(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28454));
			FileInfo[] array = files;
			foreach (FileInfo fileInfo in array)
			{
				Path.GetFileName(fileInfo.FullName);
				TagNodeCompound tagNodeCompound = LnjSwbqKJ0j(fileInfo.FullName);
				PlayerMapData item = JTLSwvBS8FG(tagNodeCompound);
				list.Add(item);
			}
		}
		Working.playerMapData = list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TagNodeCompound LnjSwbqKJ0j(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Path.GetFileNameWithoutExtension(P_0);
		byte[] buffer = FileUtils.pURSg6Zk53A(P_0);
		MemoryStream s = new MemoryStream(buffer);
		NbtTree nbtTree = new NbtTree(s);
		return nbtTree.Root;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static PlayerMapData JTLSwvBS8FG(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int x = 0;
		int y = 0;
		int z = 0;
		string name = string.Empty;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28468)))
		{
			name = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28468)] as TagNodeString;
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)))
		{
			TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
			x = (int)(float)(tagNodeList[0] as TagNodeFloat);
			y = (int)(float)(tagNodeList[1] as TagNodeFloat);
			z = (int)(float)(tagNodeList[2] as TagNodeFloat);
		}
		return new PlayerMapData(x, y, z, name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerPositionWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
