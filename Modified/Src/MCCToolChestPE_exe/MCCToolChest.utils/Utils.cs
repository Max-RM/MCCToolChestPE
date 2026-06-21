using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public class Utils
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsHex(IEnumerable<char> chars)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (char @char in chars)
		{
			if ((@char < '0' || @char > '9') && (@char < 'a' || @char > 'f') && (@char < 'A' || @char > 'F'))
			{
				return false;
			}
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ConvertByteToHexString(byte b)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214646), b);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ConvertByteArrayToHexString(byte[] ba)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
		foreach (byte b in ba)
		{
			stringBuilder.AppendFormat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214646), b);
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] ConvertHexStringToByteArray(string hexString)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = null;
		try
		{
			if (hexString.Length % 2 == 0)
			{
				array = new byte[hexString.Length / 2];
				for (int i = 0; i < array.Length; i++)
				{
					string s = hexString.Substring(i * 2, 2);
					array[i] = byte.Parse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
				}
			}
		}
		catch (Exception)
		{
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] AddPreFixPostFix(byte[] buffer)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] first = new byte[3] { 10, 0, 0 };
		byte[] array = new byte[2];
		byte[] second = array;
		buffer = first.Concat(buffer).ToArray();
		buffer = buffer.Concat(second).ToArray();
		return buffer;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SaveBiomeChanges(ConvertType converType, List<BiomeChange> biomeChanges)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		Settings settings = new Settings();
		for (int i = 0; i < biomeChanges.Count; i++)
		{
			stringBuilder.Append(biomeChanges[i].ToString());
		}
		if (converType == ConvertType.TO_PC)
		{
			settings.ToPCBiomeTranslations = stringBuilder.ToString();
		}
		else
		{
			settings.FromPCBiomeTranslations = stringBuilder.ToString();
		}
		settings.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<BiomeChange> ReadBiomeChanges(ConvertType converType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BiomeChange> list = new List<BiomeChange>();
		Settings settings = new Settings();
		string text = "";
		text = ((converType != ConvertType.TO_PC) ? settings.FromPCBiomeTranslations : settings.ToPCBiomeTranslations);
		string[] array = text.Split('|');
		string[] array2 = array;
		foreach (string changeStr in array2)
		{
			BiomeChange biomeChange = BiomeChange.FromString(changeStr);
			if (biomeChange != null)
			{
				list.Add(biomeChange);
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SaveBlockChanges(ConvertType converType, List<BlockChange> blockChanges)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Settings settings = new Settings();
		string text = CreateBlockReplaceString(blockChanges);
		if (converType == ConvertType.TO_PC)
		{
			settings.ToPCBlockTranslations = text;
		}
		else
		{
			settings.FromPCBlockTranslations = text;
		}
		settings.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<BlockChange> ReadBlockChanges(ConvertType converType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Settings settings = new Settings();
		string text = "";
		if (converType == ConvertType.TO_PC)
		{
			text = settings.ToPCBlockTranslations;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214662);
			}
		}
		else
		{
			text = settings.FromPCBlockTranslations;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(227006);
			}
		}
		return ConvertBlockReplaceString(text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string CreateBlockReplaceString(List<BlockChange> blockChanges)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < blockChanges.Count; i++)
		{
			stringBuilder.Append(blockChanges[i].ToString());
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<BlockChange> ConvertBlockReplaceString(string blockReplaceString)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockChange> list = new List<BlockChange>();
		string[] array = blockReplaceString.Split('|');
		string[] array2 = array;
		foreach (string changeStr in array2)
		{
			BlockChange blockChange = BlockChange.FromString(changeStr);
			if (blockChange != null)
			{
				list.Add(blockChange);
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SaveBlockChangesII(ConvertType converType, BlocksReplaceDefinition blockChanges)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Settings settings = new Settings();
		string text = CreateBlockReplaceStringII(blockChanges);
		if (converType == ConvertType.TO_PC)
		{
			settings.ToPCBlockTranslations = text;
		}
		else
		{
			settings.FromPCBlockTranslations = text;
		}
		settings.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlocksReplaceDefinition ReadBlockChangesII(ConvertType converType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Settings settings = new Settings();
		string text = "";
		text = ((converType != ConvertType.TO_PC) ? settings.FromPCBlockTranslations : settings.ToPCBlockTranslations);
		return ConvertBlockReplaceStringII(text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string CreateBlockReplaceStringII(BlocksReplaceDefinition blockChanges)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return JsonDataConversion.Serialize(blockChanges);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlocksReplaceDefinition ConvertBlockReplaceStringII(string blockReplaceString)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlocksReplaceDefinition blocksReplaceDefinition = null;
		try
		{
			return JsonDataConversion.Deserialize<BlocksReplaceDefinition>(blockReplaceString);
		}
		catch (Exception)
		{
			return new BlocksReplaceDefinition();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetGetMCPCSaveFolder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(241600);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetGetMCPESaveFolder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(241638);
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		folderPath = Path.GetDirectoryName(folderPath);
		return Path.Combine(folderPath, path);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool[] GetQuickBlocksLookup(ConvertParameters convertParameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new bool[257];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetRegionFileCount(string regionPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		string[] regionFileNames = Constants.regionFileNames;
		foreach (string text in regionFileNames)
		{
			string path = FileUtils.CheckFolderSep(regionPath) + text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64946);
			if (File.Exists(path))
			{
				num++;
			}
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ReadIntFromArray(byte[] array, int startPos)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array2 = new byte[4]
		{
			array[startPos],
			array[startPos + 1],
			array[startPos + 2],
			array[startPos + 3]
		};
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(array2);
		}
		return BitConverter.ToInt32(array2, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteBlocksUsedInfo(Dictionary<int, List<int>> blocksUsed, string regionName, string workingFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<int> list = blocksUsed.Keys.ToList();
		list.Sort();
		using StreamWriter streamWriter = new StreamWriter(workingFolder + regionName + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69582));
		foreach (int item in list)
		{
			string value = INYifyudg3hCpcrleHt.zhkS0lPoAGR()[item].qkOSyYT9Kd5();
			streamWriter.WriteLine(value);
			blocksUsed[item].Sort();
			foreach (int item2 in blocksUsed[item])
			{
				streamWriter.WriteLine(item + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72448) + item2);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetLibraryFolder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return LibraryPath();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetBlockReplaceDefFolder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return BRDPath();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SaveConvertFromPCFolder(string mcpcFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Settings settings = new Settings();
		settings.ConvertFromPCFolder = FileUtils.CheckFolderSep(mcpcFolder);
		settings.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ReadConvertFromPCFolder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Settings settings = new Settings();
		return FileUtils.CheckFolderSep(settings.ConvertFromPCFolder);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SaveConvertToPCFolder(string mcpcFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Settings settings = new Settings();
		settings.ConvertToPCFolder = FileUtils.CheckFolderSep(mcpcFolder);
		settings.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ReadConvertToPCFolder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Settings settings = new Settings();
		return FileUtils.CheckFolderSep(settings.ConvertToPCFolder);
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
			result = result.AddSeconds(unixTimeStamp).ToLocalTime();
			return result;
		}
		catch (Exception)
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static long DateTimeToUnixTimestamp()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		double totalMilliseconds = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
		return (long)totalMilliseconds;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int Timestamp()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DateTime now = DateTime.Now;
		return (int)((DateTime.UtcNow - now).Ticks / 10000000);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string LibraryPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(241832);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BRDPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(241888);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string SRGPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(241978);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string LibraryImagePath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242060);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BehaviorPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242130);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ErrorPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242198);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ChunkLibraryPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242252);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string AreaLibraryPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242312);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string RegionLibraryPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242370);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ProcessDataPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242432);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ScriptPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242490);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string OutputPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242540);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ConversionPath()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242588);
		path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
		Directory.CreateDirectory(path);
		return path;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Utils()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
