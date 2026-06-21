using System;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public class ExtendedHostFunctions : HostFunctions
{
	public object type(string name, params object[] hostTypeArgs)
	{
		return TypeHelpers.ImportType(name, null, useAssemblyName: false, hostTypeArgs);
	}

	public object type(string name, string assemblyName, params object[] hostTypeArgs)
	{
		return TypeHelpers.ImportType(name, assemblyName, useAssemblyName: true, hostTypeArgs);
	}

	public object type(Type type)
	{
		return HostType.Wrap(type);
	}

	public object arrType<T>(int rank = 1)
	{
		return HostType.Wrap(typeof(T).MakeArrayType(rank));
	}

	public HostTypeCollection lib(params string[] assemblyNames)
	{
		return lib(null, assemblyNames);
	}

	public HostTypeCollection lib(HostTypeCollection collection, params string[] assemblyNames)
	{
		HostTypeCollection hostTypeCollection = collection ?? new HostTypeCollection();
		Array.ForEach(assemblyNames, hostTypeCollection.AddAssembly);
		return hostTypeCollection;
	}

	public object comType(string progID, string serverName = null)
	{
		return HostType.Wrap(MiscHelpers.GetCOMType(progID, serverName));
	}

	public object newComObj(string progID, string serverName = null)
	{
		return MiscHelpers.CreateCOMObject(progID, serverName);
	}
}
