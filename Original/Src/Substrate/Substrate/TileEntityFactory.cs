using System;
using System.Collections.Generic;
using Substrate.Nbt;
using Substrate.TileEntities;

namespace Substrate;

public class TileEntityFactory
{
	private static Dictionary<string, Type> _registry;

	public static IEnumerable<KeyValuePair<string, Type>> RegisteredTileEntities
	{
		get
		{
			foreach (KeyValuePair<string, Type> item in _registry)
			{
				yield return item;
			}
		}
	}

	public static TileEntity Create(string type)
	{
		if (!_registry.TryGetValue(type, out var value))
		{
			return null;
		}
		return Activator.CreateInstance(value) as TileEntity;
	}

	public static TileEntity Create(TagNodeCompound tree)
	{
		string key = tree["id"].ToTagString();
		if (!_registry.TryGetValue(key, out var value))
		{
			return null;
		}
		TileEntity tileEntity = Activator.CreateInstance(value) as TileEntity;
		return tileEntity.LoadTreeSafe(tree);
	}

	public static TileEntity CreateGeneric(TagNodeCompound tree)
	{
		string key = tree["id"].ToTagString();
		if (!_registry.TryGetValue(key, out var value))
		{
			value = typeof(TileEntity);
		}
		TileEntity tileEntity = Activator.CreateInstance(value, nonPublic: true) as TileEntity;
		return tileEntity.LoadTreeSafe(tree);
	}

	public static Type Lookup(string type)
	{
		if (!_registry.TryGetValue(type, out var value))
		{
			return null;
		}
		return value;
	}

	public static void Register(string id, Type subtype)
	{
		_registry[id] = subtype;
	}

	static TileEntityFactory()
	{
		_registry = new Dictionary<string, Type>();
		_registry[TileEntityEndPortal.TypeId] = typeof(TileEntityEndPortal);
		_registry[TileEntityBeacon.TypeId] = typeof(TileEntityBeacon);
		_registry[TileEntityBrewingStand.TypeId] = typeof(TileEntityBrewingStand);
		_registry[TileEntityChest.TypeId] = typeof(TileEntityChest);
		_registry[TileEntityControl.TypeId] = typeof(TileEntityControl);
		_registry[TileEntityEnchantmentTable.TypeId] = typeof(TileEntityEnchantmentTable);
		_registry[TileEntityFurnace.TypeId] = typeof(TileEntityFurnace);
		_registry[TileEntityMobSpawner.TypeId] = typeof(TileEntityMobSpawner);
		_registry[TileEntityMusic.TypeId] = typeof(TileEntityMusic);
		_registry[TileEntityPiston.TypeId] = typeof(TileEntityPiston);
		_registry[TileEntityRecordPlayer.TypeId] = typeof(TileEntityRecordPlayer);
		_registry[TileEntitySign.TypeId] = typeof(TileEntitySign);
		_registry[TileEntityTrap.TypeId] = typeof(TileEntityTrap);
	}
}
