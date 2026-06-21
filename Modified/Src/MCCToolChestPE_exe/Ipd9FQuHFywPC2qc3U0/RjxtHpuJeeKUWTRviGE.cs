using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Ipd9FQuHFywPC2qc3U0;

internal class RjxtHpuJeeKUWTRviGE
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1
	{
		public string category;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass1()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _003CGetCategoryItems_003Eb__0(LibraryItem p)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return p.Category == category;
		}
	}

	private static List<string> FRtStleFvUV;

	private static List<LibraryItem> kvLSt2vJeSJ;

	private static bool VC6Sty0ynk5;

	[CompilerGenerated]
	private static Func<LibraryItem, string> hY2St0RTRmk;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void NbSStZbS2Td()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!VC6Sty0ynk5)
		{
			IG2StKl6lIt();
			jViSthYX1jj();
			VC6Sty0ynk5 = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] lZKStfRmi9D()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return FRtStleFvUV.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<LibraryItem> lcJStiZ18vl(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003C_003Ec__DisplayClass1 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass1();
		CS_0024_003C_003E8__locals3.category = P_0;
		if (CS_0024_003C_003E8__locals3.category == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57302))
		{
			return kvLSt2vJeSJ;
		}
		return kvLSt2vJeSJ.Where([MethodImpl(MethodImplOptions.NoInlining)] (LibraryItem p) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return p.Category == CS_0024_003C_003E8__locals3.category;
		}).ToList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void la7Stsk9diD(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (LibraryItem item in kvLSt2vJeSJ)
		{
			if (item.Name.ToLower() == P_0.ToLower())
			{
				kvLSt2vJeSJ.Remove(item);
				break;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdgStq3SisE(LibraryItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		la7Stsk9diD(P_0.Name);
		kvLSt2vJeSJ.Add(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void IG2StKl6lIt()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Utils.GetLibraryFolder() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208240);
		if (!File.Exists(path))
		{
			return;
		}
		foreach (string item in File.ReadLines(path))
		{
			string text = item.Trim();
			if (!string.IsNullOrWhiteSpace(text) && !FRtStleFvUV.Contains(text))
			{
				FRtStleFvUV.Add(text);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void jViSthYX1jj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string libraryFolder = Utils.GetLibraryFolder();
		string[] files = Directory.GetFiles(libraryFolder, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208272));
		string[] array = files;
		foreach (string text in array)
		{
			LibraryItem libraryItem = a4EStmJANlb(text);
			if (libraryItem != null)
			{
				kvLSt2vJeSJ.Add(libraryItem);
				if (!string.IsNullOrWhiteSpace(libraryItem.Category) && !FRtStleFvUV.Contains(libraryItem.Category))
				{
					string item = libraryItem.Category.Trim();
					FRtStleFvUV.Add(item);
				}
			}
		}
		kvLSt2vJeSJ = kvLSt2vJeSJ.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (LibraryItem P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.Name;
		}).ToList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LibraryItem a4EStmJANlb(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LibraryItem libraryItem = null;
		string text = null;
		if (File.Exists(P_0))
		{
			using StreamReader streamReader = new StreamReader(File.Open(P_0, FileMode.Open));
			text = streamReader.ReadToEnd();
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			try
			{
				libraryItem = DataConversion.Deserialize<LibraryItem>(text);
				libraryItem.Path = P_0;
			}
			catch (Exception)
			{
			}
		}
		return libraryItem;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RjxtHpuJeeKUWTRviGE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static string wAQStn1uZI8(LibraryItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Name;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static RjxtHpuJeeKUWTRviGE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		FRtStleFvUV = new List<string>();
		kvLSt2vJeSJ = new List<LibraryItem>();
		VC6Sty0ynk5 = false;
	}
}
