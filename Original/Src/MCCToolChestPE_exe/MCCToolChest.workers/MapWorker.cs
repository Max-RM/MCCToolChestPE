using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using MCCToolChest.MCSBCode.Workers;
using MCCToolChest.PECode;
using MCCToolChest.utils;
using MCPELevelDBI.model;
using MCPELevelDBI.workers;
using Substrate.Data;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class MapWorker
{
	private BackgroundWorker csUS3G7S9rj;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Dictionary<long, long> yogSYCr7kCn(string P_0, string P_1, BackgroundWorker P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		csUS3G7S9rj = P_2;
		return FtpSY7iT65i(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<long, long> FtpSY7iT65i(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = ypDSY8181qe(P_0);
		Dictionary<long, long> dictionary = new Dictionary<long, long>();
		foreach (DBRecord item in list)
		{
			NbtTree nbtTree = new NbtTree();
			nbtTree.UseBigEndian = false;
			nbtTree.ReadFrom(new MemoryStream(item.Value));
			TagNodeCompound root = nbtTree.Root;
			try
			{
				csUS3G7S9rj.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247248) + Encoding.ASCII.GetString(item.Key));
				daqSYAmnSwH(root, P_1, dictionary);
			}
			catch (Exception)
			{
			}
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void daqSYAmnSwH(TagNodeCompound P_0, string P_1, Dictionary<long, long> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Path.Combine(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206));
		byte d = 0;
		byte d2 = 0;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88450)))
		{
			d2 = (((int)(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88450)] as TagNodeByte) != 1) ? ((byte)1) : ((byte)0));
			d = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88450)] as TagNodeByte;
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247296)))
		{
			d = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247296)] as TagNodeByte;
		}
		byte d3 = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] as TagNodeByte;
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64958)] = new TagNodeInt(1976);
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)] = tagNodeCompound2;
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247318)] = new TagNodeList(TagType.TAG_COMPOUND);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247336)] = new TagNodeList(TagType.TAG_COMPOUND);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] = new TagNodeInt(d3);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247352)] = new TagNodeByte(d);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88520)] = new TagNodeByte(0);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247368)] = new TagNodeByte(d2);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247404)] = new TagNodeByte(0);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88548)] = new TagNodeInt(int.MaxValue);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88566)] = new TagNodeInt(int.MaxValue);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73608)] = new TagNodeByteArray(u5HSYIXB5iV(P_0));
		long num = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88480)] as TagNodeLong;
		long num2 = ((num < 0 || num > int.MaxValue) ? 0 : num);
		while (File.Exists(Path.Combine(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88438) + num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554))))
		{
			num2++;
		}
		P_2[num] = num2;
		MemoryStream memoryStream = new MemoryStream();
		NbtTree nbtTree = new NbtTree(tagNodeCompound);
		nbtTree.UseBigEndian = true;
		nbtTree.WriteTo(memoryStream);
		FileUtils.WriteFile(memoryStream, Path.Combine(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88438) + num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554)));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Dictionary<long, long> Rt6SYdPfIFx(string P_0, string P_1, BackgroundWorker P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		csUS3G7S9rj = P_2;
		return hTISYHWHQO9(P_1, P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<long, long> hTISYHWHQO9(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<long> list = L2aSY9rJnrX(P_1);
		Dictionary<long, long> dictionary = new Dictionary<long, long>();
		string[] files = Directory.GetFiles(Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99040));
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_1);
		try
		{
			string[] array = files;
			foreach (string text in array)
			{
				try
				{
					csUS3G7S9rj.ReportProgress(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247248) + Path.GetFileNameWithoutExtension(text));
					ErISYFFCLY7(text, list, dictionary, levelDBWorker);
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			levelDBWorker.CloseDB();
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ErISYFFCLY7(string P_0, List<long> P_1, Dictionary<long, long> P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] buffer = FileUtils.pURSg6Zk53A(P_0);
		MemoryStream s = new MemoryStream(buffer);
		NbtTree nbtTree = new NbtTree();
		nbtTree.UseBigEndian = true;
		nbtTree.ReadFrom(s);
		if (nbtTree.Root != null)
		{
			TagNodeCompound root = nbtTree.Root;
			TagNodeCompound tagNodeCompound = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)] as TagNodeCompound;
			TagNodeCompound tagNodeCompound2 = VwGSYzer6bS(root);
			long result = 0L;
			string s2 = Path.GetFileNameWithoutExtension(P_0).Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88438), "");
			long.TryParse(s2, out result);
			long num;
			for (num = result; P_1.Contains(num); num++)
			{
			}
			P_2[result] = num;
			P_1.Add(num);
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88480)] = new TagNodeLong(num);
			byte d = 0;
			if (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] is TagNodeByte)
			{
				d = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] as TagNodeByte;
			}
			else if (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] is TagNodeInt)
			{
				d = (byte)(int)(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] as TagNodeInt);
			}
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] = new TagNodeInt(d);
			byte d2 = 0;
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247352)))
			{
				d2 = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247352)] as TagNodeByte;
			}
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247296)] = new TagNodeByte(d2);
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88450)] = new TagNodeByte(d2);
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247404)] = new TagNodeByte(0);
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88520)] = new TagNodeByte(0);
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88548)] = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88548)];
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88566)] = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88566)];
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73624)] = new TagNodeShort(128);
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88534)] = new TagNodeShort(128);
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88494)] = new TagNodeLong(-1L);
			LU3SYjwAD3y(tagNodeCompound2, num, P_3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LU3SYjwAD3y(TagNodeCompound P_0, long P_1, LevelDBWorker P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string s = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88438) + P_1;
		MemoryStream memoryStream = new MemoryStream();
		NbtTree nbtTree = new NbtTree(P_0);
		nbtTree.UseBigEndian = false;
		nbtTree.WriteTo(memoryStream);
		P_2.Put(Encoding.ASCII.GetBytes(s), memoryStream.ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<DBRecord> ypDSY8181qe(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_0);
		List<DBRecord> maps = levelDBWorker.GetMaps();
		levelDBWorker.CloseDB();
		return maps;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<long> L2aSY9rJnrX(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = ypDSY8181qe(P_0);
		List<long> list2 = new List<long>();
		foreach (DBRecord item in list)
		{
			long result = 0L;
			string s = Encoding.ASCII.GetString(item.Key).Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88438), "");
			if (long.TryParse(s, out result))
			{
				list2.Add(result);
			}
		}
		list = null;
		return list2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] u5HSYIXB5iV(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Map map = new Map();
		map.Height = 128;
		map.Width = 128;
		MapConverterWorker mapConverterWorker = new MapConverterWorker();
		Bitmap bmp = mapConverterWorker.ToImage(P_0);
		MapConverter mapConverter = new MapConverter();
		mapConverter.BitmapToMap(map, bmp);
		return map.Colors;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound VwGSYzer6bS(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Map map = new Map();
		map.Height = 128;
		map.Width = 128;
		TagNodeCompound tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)] as TagNodeCompound;
		map.Colors = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73608)] as TagNodeByteArray;
		MapConverter mapConverter = new MapConverter();
		Bitmap bmp = mapConverter.MapToBitmap(map);
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		MapConverterWorker mapConverterWorker = new MapConverterWorker();
		mapConverterWorker.FromImage(tagNodeCompound2, bmp);
		return tagNodeCompound2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ixeS3TpoUsZ(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<long> list = L2aSY9rJnrX(P_0);
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_0);
		foreach (long item in list)
		{
			levelDBWorker.Delete(Encoding.ASCII.GetBytes(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88438) + item));
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void TayS3S371Vv(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] files = Directory.GetFiles(Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99040));
		string[] array = files;
		foreach (string path in array)
		{
			File.Delete(path);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
