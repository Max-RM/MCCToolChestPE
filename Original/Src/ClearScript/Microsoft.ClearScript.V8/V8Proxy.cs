using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.V8;

internal abstract class V8Proxy : IDisposable
{
	private static readonly object mapLock = new object();

	private static readonly Dictionary<Type, Type> map = new Dictionary<Type, Type>();

	private static Assembly assembly;

	private static string deploymentDirName = string.Empty;

	protected static T CreateImpl<T>(params object[] args) where T : V8Proxy
	{
		Type value;
		lock (mapLock)
		{
			Type typeFromHandle = typeof(T);
			if (!map.TryGetValue(typeFromHandle, out value))
			{
				value = GetImplType(typeFromHandle);
				map.Add(typeFromHandle, value);
			}
		}
		return (T)Activator.CreateInstance(value, args);
	}

	private static Type GetImplType(Type type)
	{
		string fullRootName = type.GetFullRootName();
		Type type2 = GetAssembly().GetType(fullRootName + "Impl");
		if (type2 == null)
		{
			throw new TypeLoadException("Cannot find " + fullRootName + " implementation type in V8 interface assembly");
		}
		return type2;
	}

	private static Assembly GetAssembly()
	{
		if (assembly == null)
		{
			assembly = LoadAssembly();
		}
		return assembly;
	}

	private static Assembly LoadAssembly()
	{
		try
		{
			return Assembly.Load("ClearScriptV8");
		}
		catch (FileNotFoundException)
		{
		}
		IntPtr hLibrary = LoadNativeLibrary("v8-libcpp");
		try
		{
			IntPtr hLibrary2 = LoadNativeLibrary("v8-base");
			try
			{
				IntPtr hLibrary3 = LoadNativeLibrary("v8");
				try
				{
					string text = (Environment.Is64BitProcess ? "64" : "32");
					string text2 = "ClearScriptV8-" + text;
					string fileName = text2 + ".dll";
					StringBuilder stringBuilder = new StringBuilder();
					IEnumerable<string> enumerable = (from dirPath in GetDirPaths()
						select Path.Combine(dirPath, deploymentDirName, fileName)).Distinct();
					foreach (string item in enumerable)
					{
						try
						{
							return Assembly.LoadFrom(item);
						}
						catch (Exception ex2)
						{
							stringBuilder.AppendInvariant("\n{0}: {1}", item, MiscHelpers.EnsureNonBlank(ex2.Message, "Unknown error"));
						}
					}
					if (string.IsNullOrEmpty(deploymentDirName))
					{
						byte[] publicKeyToken = typeof(V8Proxy).Assembly.GetName().GetPublicKeyToken();
						if (publicKeyToken != null && publicKeyToken.Length != 0)
						{
							string text3 = MiscHelpers.FormatInvariant("{0}, Version={1}, Culture=neutral, PublicKeyToken={2}", text2, "5.6.0.0", BitConverter.ToString(publicKeyToken).Replace("-", string.Empty));
							try
							{
								return Assembly.Load(text3);
							}
							catch (Exception ex3)
							{
								stringBuilder.AppendInvariant("\n{0}: {1}", text3, MiscHelpers.EnsureNonBlank(ex3.Message, "Unknown error"));
							}
						}
					}
					string message = MiscHelpers.FormatInvariant("Cannot load V8 interface assembly. Load failure information for {0}:{1}", fileName, stringBuilder);
					throw new TypeLoadException(message);
				}
				finally
				{
					NativeMethods.FreeLibrary(hLibrary3);
				}
			}
			finally
			{
				NativeMethods.FreeLibrary(hLibrary2);
			}
		}
		finally
		{
			NativeMethods.FreeLibrary(hLibrary);
		}
	}

	private static IntPtr LoadNativeLibrary(string baseFileName)
	{
		string text = (Environment.Is64BitProcess ? "-x64" : "-ia32");
		string fileName = baseFileName + text + ".dll";
		StringBuilder stringBuilder = new StringBuilder();
		IEnumerable<string> enumerable = (from dirPath in GetDirPaths()
			select Path.Combine(dirPath, deploymentDirName, fileName)).Distinct();
		foreach (string item in enumerable)
		{
			IntPtr intPtr = NativeMethods.LoadLibraryW(item);
			if (intPtr != IntPtr.Zero)
			{
				return intPtr;
			}
			Win32Exception ex = new Win32Exception();
			stringBuilder.AppendInvariant("\n{0}: {1}", item, MiscHelpers.EnsureNonBlank(ex.Message, "Unknown error"));
		}
		if (string.IsNullOrEmpty(deploymentDirName))
		{
			string text2 = Path.Combine(Environment.SystemDirectory, fileName);
			IntPtr intPtr = NativeMethods.LoadLibraryW(text2);
			if (intPtr != IntPtr.Zero)
			{
				return intPtr;
			}
			Win32Exception ex = new Win32Exception();
			stringBuilder.AppendInvariant("\n{0}: {1}", text2, MiscHelpers.EnsureNonBlank(ex.Message, "Unknown error"));
		}
		string message = MiscHelpers.FormatInvariant("Cannot load V8 interface assembly. Load failure information for {0}:{1}", fileName, stringBuilder);
		throw new TypeLoadException(message);
	}

	private static IEnumerable<string> GetDirPaths()
	{
		string location = typeof(V8Proxy).Assembly.Location;
		if (!string.IsNullOrWhiteSpace(location))
		{
			yield return Path.GetDirectoryName(location);
		}
		AppDomain appDomain = AppDomain.CurrentDomain;
		yield return appDomain.BaseDirectory;
		string relativeSearchPath = appDomain.RelativeSearchPath;
		if (string.IsNullOrWhiteSpace(relativeSearchPath))
		{
			yield break;
		}
		foreach (string item in relativeSearchPath.SplitSearchPath())
		{
			yield return item;
		}
	}

	public abstract void Dispose();

	internal static void RunWithDeploymentDir(string name, Action action)
	{
		lock (mapLock)
		{
			map.Clear();
			assembly = null;
		}
		deploymentDirName = name;
		try
		{
			action();
		}
		finally
		{
			deploymentDirName = string.Empty;
		}
	}
}
