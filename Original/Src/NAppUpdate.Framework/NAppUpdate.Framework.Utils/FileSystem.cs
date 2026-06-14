using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NAppUpdate.Framework.Utils;

public static class FileSystem
{
	public static void CreateDirectoryStructure(string path)
	{
		CreateDirectoryStructure(path, pathIncludeFile: true);
	}

	public static void CreateDirectoryStructure(string path, bool pathIncludeFile)
	{
		string[] array = path.Split(Path.DirectorySeparatorChar);
		int num = array.Length;
		if (pathIncludeFile)
		{
			num--;
		}
		for (int i = 0; i < num; i++)
		{
			string text = array[0] + "\\";
			for (int j = 1; j <= i; j++)
			{
				text = Path.Combine(text, array[j]);
			}
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
		}
	}

	public static void DeleteDirectory(string targetDir)
	{
		string[] files = Directory.GetFiles(targetDir);
		string[] directories = Directory.GetDirectories(targetDir);
		string[] array = files;
		foreach (string path in array)
		{
			File.SetAttributes(path, FileAttributes.Normal);
			File.Delete(path);
		}
		string[] array2 = directories;
		foreach (string targetDir2 in array2)
		{
			DeleteDirectory(targetDir2);
		}
		File.SetAttributes(targetDir, FileAttributes.Normal);
		Directory.Delete(targetDir, recursive: false);
	}

	public static IEnumerable<string> GetFiles(string path, string searchPattern, SearchOption searchOption)
	{
		string[] array = searchPattern.Split('|');
		List<string> list = new List<string>();
		string[] array2 = array;
		foreach (string searchPattern2 in array2)
		{
			list.AddRange(Directory.GetFiles(path, searchPattern2, searchOption));
		}
		return list;
	}

	public static bool IsExeRunning(string path)
	{
		Process[] processes = Process.GetProcesses();
		Process[] array = processes;
		foreach (Process process in array)
		{
			if (process.MainModule.FileName.StartsWith(path, StringComparison.InvariantCultureIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}
}
