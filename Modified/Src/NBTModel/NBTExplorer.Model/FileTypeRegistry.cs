using System;
using System.Collections.Generic;

namespace NBTExplorer.Model;

public class FileTypeRegistry
{
	private static Dictionary<Type, FileTypeRecord> _registry;

	public static IEnumerable<KeyValuePair<Type, FileTypeRecord>> RegisteredTypes
	{
		get
		{
			foreach (KeyValuePair<Type, FileTypeRecord> item in _registry)
			{
				yield return item;
			}
		}
	}

	public static FileTypeRecord Lookup(Type type)
	{
		if (_registry.ContainsKey(type))
		{
			return _registry[type];
		}
		return null;
	}

	public static void Register(Type type, FileTypeRecord record)
	{
		_registry[type] = record;
	}

	public static void Register<T>(FileTypeRecord record)
	{
		Register(typeof(T), record);
	}

	static FileTypeRegistry()
	{
		_registry = new Dictionary<Type, FileTypeRecord>();
		try
		{
			Register<NbtFileDataNode>(new FileTypeRecord
			{
				NamePatternTest = NbtFileDataNode.SupportedNamePattern,
				NodeCreate = NbtFileDataNode.TryCreateFrom
			});
			Register<RegionFileDataNode>(new FileTypeRecord
			{
				NamePatternTest = RegionFileDataNode.SupportedNamePattern,
				NodeCreate = RegionFileDataNode.TryCreateFrom
			});
			Register<CubicRegionDataNode>(new FileTypeRecord
			{
				NamePatternTest = CubicRegionDataNode.SupportedNamePattern,
				NodeCreate = CubicRegionDataNode.TryCreateFrom
			});
		}
		catch (Exception)
		{
		}
	}
}
