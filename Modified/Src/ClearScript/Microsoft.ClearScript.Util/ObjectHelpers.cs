using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Util;

internal static class ObjectHelpers
{
	[ComImport]
	[Guid("b196b283-bab4-101a-b69c-00aa00341d07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	private interface IProvideClassInfo
	{
		[PreserveSig]
		int GetClassInfo([MarshalAs(UnmanagedType.Interface)] out ITypeInfo typeInfo);
	}

	private static readonly Guid managedNameGuid = new Guid("{0f21f359-ab84-41e8-9a78-36d110e6d2f9}");

	public static Type GetTypeOrTypeInfo(this object value)
	{
		Type type = value.GetType();
		IDispatch dispatch = null;
		Type type2 = null;
		System.Runtime.InteropServices.ComTypes.TYPEKIND tYPEKIND = System.Runtime.InteropServices.ComTypes.TYPEKIND.TKIND_ENUM;
		System.Runtime.InteropServices.ComTypes.TYPEFLAGS tYPEFLAGS = (System.Runtime.InteropServices.ComTypes.TYPEFLAGS)0;
		if (type.IsUnknownCOMObject())
		{
			dispatch = value as IDispatch;
			if (dispatch != null && RawCOMHelpers.HResult.Succeeded(dispatch.GetTypeInfoCount(out var count)) && count != 0 && RawCOMHelpers.HResult.Succeeded(dispatch.GetTypeInfo(0u, 0, out var typeInfo)))
			{
				type2 = GetTypeForTypeInfo(typeInfo);
				tYPEKIND = GetTypeInfoKind(typeInfo);
				tYPEFLAGS = GetTypeInfoFlags(typeInfo);
			}
			if (type2 == null && value is IProvideClassInfo provideClassInfo && RawCOMHelpers.HResult.Succeeded(provideClassInfo.GetClassInfo(out var typeInfo2)))
			{
				type2 = GetTypeForTypeInfo(typeInfo2);
				tYPEKIND = GetTypeInfoKind(typeInfo2);
				tYPEFLAGS = GetTypeInfoFlags(typeInfo2);
			}
		}
		if (type2 != null)
		{
			if (dispatch != null && tYPEKIND == System.Runtime.InteropServices.ComTypes.TYPEKIND.TKIND_DISPATCH && tYPEFLAGS.HasFlag(System.Runtime.InteropServices.ComTypes.TYPEFLAGS.TYPEFLAG_FDISPATCHABLE) && !tYPEFLAGS.HasFlag(System.Runtime.InteropServices.ComTypes.TYPEFLAGS.TYPEFLAG_FDUAL))
			{
				return type2;
			}
			if (type2.IsInstanceOfType(value))
			{
				return type2;
			}
			Type[] interfaces = type2.GetInterfaces();
			foreach (Type type3 in interfaces)
			{
				if (type3.IsInstanceOfType(value))
				{
					return type3;
				}
			}
		}
		return type;
	}

	public static string GetFriendlyName(this object value)
	{
		return value.GetFriendlyName(null);
	}

	public static string GetFriendlyName(this object value, Type type)
	{
		if (type == null)
		{
			if (value == null)
			{
				return "[null]";
			}
			type = value.GetType();
		}
		if (type.IsArray && value != null)
		{
			Array array = (Array)value;
			IEnumerable<int> source = Enumerable.Range(0, type.GetArrayRank());
			string text = string.Join(",", source.Select(array.GetLength));
			return MiscHelpers.FormatInvariant("{0}[{1}]", type.GetElementType().GetFriendlyName(), text);
		}
		return type.GetFriendlyName();
	}

	public static T DynamicCast<T>(this object value)
	{
		return (T)(dynamic)value;
	}

	public static object ToDynamicResult(this object result, ScriptEngine engine)
	{
		if (result is Nonexistent)
		{
			return Undefined.Value;
		}
		if (result is HostTarget || result is IPropertyBag)
		{
			return HostItem.Wrap(engine, result);
		}
		return result;
	}

	private static Type GetTypeForTypeInfo(ITypeInfo typeInfo)
	{
		try
		{
			typeInfo.GetContainingTypeLib(out var ppTLB, out var pIndex);
			Assembly assembly = LoadPrimaryInteropAssembly(ppTLB);
			if (assembly != null)
			{
				string name = GetManagedTypeInfoName(typeInfo, ppTLB);
				Guid guid = GetTypeInfoGuid(typeInfo);
				Type type = assembly.GetType(name, throwOnError: false, ignoreCase: true);
				if (type != null && type.GUID == guid)
				{
					return type;
				}
				Type[] types = assembly.GetTypes();
				if (pIndex >= 0 && pIndex < types.Length)
				{
					type = types[pIndex];
					if (type.GUID == guid && type.FullName == name)
					{
						return type;
					}
				}
				type = types.FirstOrDefault((Type testType) => testType.GUID == guid && testType.FullName.Equals(name, StringComparison.OrdinalIgnoreCase));
				if (type != null)
				{
					return type;
				}
			}
			IntPtr comInterfaceForObject = Marshal.GetComInterfaceForObject(typeInfo, typeof(ITypeInfo));
			try
			{
				return Marshal.GetTypeForITypeInfo(comInterfaceForObject);
			}
			finally
			{
				Marshal.Release(comInterfaceForObject);
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	private static Assembly LoadPrimaryInteropAssembly(ITypeLib typeLib)
	{
		try
		{
			typeLib.GetLibAttr(out var ppTLibAttr);
			try
			{
				System.Runtime.InteropServices.ComTypes.TYPELIBATTR tYPELIBATTR = (System.Runtime.InteropServices.ComTypes.TYPELIBATTR)Marshal.PtrToStructure(ppTLibAttr, typeof(System.Runtime.InteropServices.ComTypes.TYPELIBATTR));
				if (new TypeLibConverter().GetPrimaryInteropAssembly(tYPELIBATTR.guid, tYPELIBATTR.wMajorVerNum, tYPELIBATTR.wMinorVerNum, tYPELIBATTR.lcid, out var asmName, out var asmCodeBase))
				{
					return Assembly.Load(new AssemblyName(asmName)
					{
						CodeBase = asmCodeBase
					});
				}
			}
			finally
			{
				typeLib.ReleaseTLibAttr(ppTLibAttr);
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	private static string GetManagedTypeInfoName(ITypeInfo typeInfo, ITypeLib typeLib)
	{
		if (typeInfo is ITypeInfo2 typeInfo2)
		{
			try
			{
				Guid guid = managedNameGuid;
				typeInfo2.GetCustData(ref guid, out var pVarVal);
				if (pVarVal is string text)
				{
					return text.Trim();
				}
			}
			catch (Exception)
			{
			}
		}
		return GetManagedTypeLibName(typeLib) + "." + Marshal.GetTypeInfoName(typeInfo);
	}

	private static string GetManagedTypeLibName(ITypeLib typeLib)
	{
		if (typeLib is ITypeLib2 typeLib2)
		{
			try
			{
				Guid guid = managedNameGuid;
				typeLib2.GetCustData(ref guid, out var pVarVal);
				if (pVarVal is string text)
				{
					string text2 = text.Trim();
					if (text2.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || text2.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
					{
						return text2.Substring(0, text2.Length - 4);
					}
					return text2;
				}
			}
			catch (Exception)
			{
			}
		}
		return Marshal.GetTypeLibName(typeLib);
	}

	private static Guid GetTypeInfoGuid(ITypeInfo typeInfo)
	{
		typeInfo.GetTypeAttr(out var ppTypeAttr);
		try
		{
			return ((System.Runtime.InteropServices.ComTypes.TYPEATTR)Marshal.PtrToStructure(ppTypeAttr, typeof(System.Runtime.InteropServices.ComTypes.TYPEATTR))).guid;
		}
		finally
		{
			typeInfo.ReleaseTypeAttr(ppTypeAttr);
		}
	}

	private static System.Runtime.InteropServices.ComTypes.TYPEKIND GetTypeInfoKind(ITypeInfo typeInfo)
	{
		typeInfo.GetTypeAttr(out var ppTypeAttr);
		try
		{
			return ((System.Runtime.InteropServices.ComTypes.TYPEATTR)Marshal.PtrToStructure(ppTypeAttr, typeof(System.Runtime.InteropServices.ComTypes.TYPEATTR))).typekind;
		}
		finally
		{
			typeInfo.ReleaseTypeAttr(ppTypeAttr);
		}
	}

	private static System.Runtime.InteropServices.ComTypes.TYPEFLAGS GetTypeInfoFlags(ITypeInfo typeInfo)
	{
		typeInfo.GetTypeAttr(out var ppTypeAttr);
		try
		{
			return ((System.Runtime.InteropServices.ComTypes.TYPEATTR)Marshal.PtrToStructure(ppTypeAttr, typeof(System.Runtime.InteropServices.ComTypes.TYPEATTR))).wTypeFlags;
		}
		finally
		{
			typeInfo.ReleaseTypeAttr(ppTypeAttr);
		}
	}
}
