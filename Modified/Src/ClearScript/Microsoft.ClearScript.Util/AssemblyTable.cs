using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

namespace Microsoft.ClearScript.Util;

internal static class AssemblyTable
{
	private static ConcurrentDictionary<string, string> table;

	static AssemblyTable()
	{
		LoadAssemblyTable();
		if (table != null)
		{
			AppDomain.CurrentDomain.AssemblyLoad += delegate(object sender, AssemblyLoadEventArgs args)
			{
				table.TryAdd(args.LoadedAssembly.GetName().Name, args.LoadedAssembly.FullName);
			};
			AppDomain.CurrentDomain.GetAssemblies().ForEach(delegate(Assembly assembly)
			{
				table.TryAdd(assembly.GetName().Name, assembly.FullName);
			});
		}
	}

	public static string GetFullAssemblyName(string name)
	{
		if (table == null || !table.TryGetValue(name, out var value))
		{
			return name;
		}
		return value;
	}

	private static void LoadAssemblyTable()
	{
		string text = null;
		try
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			if (!string.IsNullOrWhiteSpace(folderPath))
			{
				folderPath = Path.Combine(folderPath, "Microsoft", "ClearScript", Environment.Is64BitProcess ? "x64" : "x86", GetRuntimeVersionDirectoryName());
				Directory.CreateDirectory(folderPath);
				text = Path.Combine(folderPath, "AssemblyTable.bin");
				if (File.Exists(text))
				{
					try
					{
						using FileStream serializationStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read);
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						table = (ConcurrentDictionary<string, string>)binaryFormatter.Deserialize(serializationStream);
					}
					catch (Exception)
					{
					}
				}
			}
		}
		catch (Exception)
		{
		}
		if (table != null)
		{
			return;
		}
		BuildAssemblyTable();
		if (table == null || text == null)
		{
			return;
		}
		try
		{
			using FileStream serializationStream2 = new FileStream(text, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			BinaryFormatter binaryFormatter2 = new BinaryFormatter();
			binaryFormatter2.Serialize(serializationStream2, table);
		}
		catch (Exception)
		{
		}
	}

	private static void BuildAssemblyTable()
	{
		try
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework");
			if (registryKey == null)
			{
				return;
			}
			string path = Path.Combine((string)registryKey.GetValue("InstallRoot"), GetRuntimeVersionDirectoryName());
			table = new ConcurrentDictionary<string, string>();
			foreach (string item in Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories))
			{
				try
				{
					AssemblyName name = Assembly.ReflectionOnlyLoadFrom(item).GetName();
					table.TryAdd(name.Name, name.FullName);
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static string GetRuntimeVersionDirectoryName()
	{
		return MiscHelpers.FormatInvariant("v{0}", Environment.Version.ToString(3));
	}
}
