using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public class HostTypeCollection : PropertyBag
{
	private static readonly Predicate<Type> defaultFilter = (Type type) => true;

	public HostTypeCollection()
		: base(isReadOnly: true)
	{
	}

	public HostTypeCollection(params Assembly[] assemblies)
		: base(isReadOnly: true)
	{
		MiscHelpers.VerifyNonNullArgument(assemblies, "assemblies");
		Array.ForEach(assemblies, AddAssembly);
	}

	public HostTypeCollection(params string[] assemblyNames)
		: base(isReadOnly: true)
	{
		MiscHelpers.VerifyNonNullArgument(assemblyNames, "assemblyNames");
		Array.ForEach(assemblyNames, AddAssembly);
	}

	public HostTypeCollection(Predicate<Type> filter, params Assembly[] assemblies)
	{
		HostTypeCollection hostTypeCollection = this;
		MiscHelpers.VerifyNonNullArgument(assemblies, "assemblies");
		Array.ForEach(assemblies, delegate(Assembly assembly)
		{
			hostTypeCollection.AddAssembly(assembly, filter);
		});
	}

	public HostTypeCollection(Predicate<Type> filter, params string[] assemblyNames)
	{
		HostTypeCollection hostTypeCollection = this;
		MiscHelpers.VerifyNonNullArgument(assemblyNames, "assemblyNames");
		Array.ForEach(assemblyNames, delegate(string assemblyName)
		{
			hostTypeCollection.AddAssembly(assemblyName, filter);
		});
	}

	public void AddAssembly(Assembly assembly)
	{
		MiscHelpers.VerifyNonNullArgument(assembly, "assembly");
		foreach (Type item in from type in assembly.GetTypes()
			where type.IsImportable()
			select type)
		{
			AddType(item);
		}
	}

	public void AddAssembly(string assemblyName)
	{
		MiscHelpers.VerifyNonBlankArgument(assemblyName, "assemblyName", "Invalid assembly name");
		AddAssembly(Assembly.Load(AssemblyTable.GetFullAssemblyName(assemblyName)));
	}

	public void AddAssembly(Assembly assembly, Predicate<Type> filter)
	{
		MiscHelpers.VerifyNonNullArgument(assembly, "assembly");
		Predicate<Type> activeFilter = filter ?? defaultFilter;
		foreach (Type item in from type in assembly.GetTypes()
			where type.IsImportable() && activeFilter(type)
			select type)
		{
			AddType(item);
		}
	}

	public void AddAssembly(string assemblyName, Predicate<Type> filter)
	{
		MiscHelpers.VerifyNonBlankArgument(assemblyName, "assemblyName", "Invalid assembly name");
		AddAssembly(Assembly.Load(AssemblyTable.GetFullAssemblyName(assemblyName)), filter);
	}

	public void AddType(Type type)
	{
		MiscHelpers.VerifyNonNullArgument(type, "type");
		AddType(HostType.Wrap(type));
	}

	public void AddType(string typeName, params Type[] typeArgs)
	{
		AddType(TypeHelpers.ImportType(typeName, null, useAssemblyName: false, typeArgs));
	}

	public void AddType(string typeName, string assemblyName, params Type[] typeArgs)
	{
		AddType(TypeHelpers.ImportType(typeName, assemblyName, useAssemblyName: true, typeArgs));
	}

	public PropertyBag GetNamespaceNode(string name)
	{
		MiscHelpers.VerifyNonNullArgument(name, "name");
		PropertyBag propertyBag = this;
		string[] array = name.Split('.');
		string[] array2 = array;
		foreach (string key in array2)
		{
			if (!propertyBag.TryGetValue(key, out var value))
			{
				return null;
			}
			propertyBag = value as PropertyBag;
			if (propertyBag == null)
			{
				return null;
			}
		}
		return propertyBag;
	}

	private void AddType(HostType hostType)
	{
		MiscHelpers.VerifyNonNullArgument(hostType, "hostType");
		Type[] types = hostType.Types;
		foreach (Type type in types)
		{
			PropertyBag namespaceNode = GetNamespaceNode(type);
			if (namespaceNode != null)
			{
				AddTypeToNamespaceNode(namespaceNode, type);
			}
		}
	}

	private PropertyBag GetNamespaceNode(Type type)
	{
		string locator = type.GetLocator();
		string[] array = locator.Split('.');
		if (array.Length < 1)
		{
			return null;
		}
		PropertyBag propertyBag = this;
		foreach (string item in array.Take(array.Length - 1))
		{
			PropertyBag propertyBag2;
			if (!propertyBag.TryGetValue(item, out var value))
			{
				propertyBag2 = new PropertyBag(isReadOnly: true);
				propertyBag.SetPropertyNoCheck(item, propertyBag2);
			}
			else
			{
				propertyBag2 = value as PropertyBag;
				if (propertyBag2 == null)
				{
					throw new OperationCanceledException(MiscHelpers.FormatInvariant("Namespace conflicts with '{0}' at '{1}'", value.GetFriendlyName(), locator));
				}
			}
			propertyBag = propertyBag2;
		}
		return propertyBag;
	}

	private static void AddTypeToNamespaceNode(PropertyBag node, Type type)
	{
		string rootName = type.GetRootName();
		if (!node.TryGetValue(rootName, out var value))
		{
			node.SetPropertyNoCheck(rootName, HostType.Wrap(type));
			return;
		}
		if (value is HostType hostType)
		{
			Type[] array = type.ToEnumerable().Concat(hostType.Types).ToArray();
			IList<IGrouping<int, Type>> source = (from testType in array
				group testType by testType.GetGenericParamCount()).ToIList();
			if (source.Any((IGrouping<int, Type> group) => group.Count() > 1))
			{
				array = source.Select(ResolveTypeConflict).ToArray();
			}
			node.SetPropertyNoCheck(rootName, HostType.Wrap(array));
			return;
		}
		if (value is PropertyBag)
		{
			throw new OperationCanceledException(MiscHelpers.FormatInvariant("Type conflicts with namespace at '{0}'", type.GetLocator()));
		}
		throw new OperationCanceledException(MiscHelpers.FormatInvariant("Type conflicts with '{0}' at '{1}'", value.GetFriendlyName(), type.GetLocator()));
	}

	private static Type ResolveTypeConflict(IEnumerable<Type> types)
	{
		IList<Type> list = types.ToIList();
		return list.SingleOrDefault((Type type) => type.IsPublic) ?? list[0];
	}
}
