using System;
using System.Collections.Generic;
using Substrate.Entities;
using Substrate.Nbt;

namespace Substrate;

public class EntityFactory
{
	private static Dictionary<string, Type> _registry;

	public static IEnumerable<KeyValuePair<string, Type>> RegisteredEntities
	{
		get
		{
			foreach (KeyValuePair<string, Type> item in _registry)
			{
				yield return item;
			}
		}
	}

	public static TypedEntity Create(string type)
	{
		if (!_registry.TryGetValue(type, out var value))
		{
			return null;
		}
		return Activator.CreateInstance(value) as TypedEntity;
	}

	public static TypedEntity Create(TagNodeCompound tree)
	{
		if (!tree.TryGetValue("id", out var value))
		{
			return null;
		}
		if (!_registry.TryGetValue(value.ToTagString(), out var value2))
		{
			return null;
		}
		TypedEntity typedEntity = Activator.CreateInstance(value2) as TypedEntity;
		return typedEntity.LoadTreeSafe(tree);
	}

	public static TypedEntity CreateGeneric(TagNodeCompound tree)
	{
		if (!tree.TryGetValue("id", out var value))
		{
			return null;
		}
		TypedEntity typedEntity = new TypedEntity(value.ToTagString().Data);
		return typedEntity.LoadTreeSafe(tree);
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

	static EntityFactory()
	{
		_registry = new Dictionary<string, Type>();
		_registry[EntityArrow.TypeId] = typeof(EntityArrow);
		_registry[EntityBlaze.TypeId] = typeof(EntityBlaze);
		_registry[EntityBoat.TypeId] = typeof(EntityBoat);
		_registry[EntityCaveSpider.TypeId] = typeof(EntityCaveSpider);
		_registry[EntityChicken.TypeId] = typeof(EntityChicken);
		_registry[EntityCow.TypeId] = typeof(EntityCow);
		_registry[EntityCreeper.TypeId] = typeof(EntityCreeper);
		_registry[EntityEgg.TypeId] = typeof(EntityEgg);
		_registry[EntityEnderDragon.TypeId] = typeof(EntityEnderDragon);
		_registry[EntityEnderman.TypeId] = typeof(EntityEnderman);
		_registry[EntityEnderEye.TypeId] = typeof(EntityEnderEye);
		_registry[EntityFallingSand.TypeId] = typeof(EntityFallingSand);
		_registry[EntityFireball.TypeId] = typeof(EntityFireball);
		_registry[EntityGhast.TypeId] = typeof(EntityGhast);
		_registry[EntityGiant.TypeId] = typeof(EntityGiant);
		_registry[EntityItem.TypeId] = typeof(EntityItem);
		_registry[EntityMagmaCube.TypeId] = typeof(EntityMagmaCube);
		_registry[EntityMinecart.TypeId] = typeof(EntityMinecart);
		_registry[EntityMinecartChest.TypeId] = typeof(EntityMinecartChest);
		_registry[EntityMinecartFurnace.TypeId] = typeof(EntityMinecartFurnace);
		_registry[EntityMinecartTNT.TypeId] = typeof(EntityMinecartTNT);
		_registry[EntityMinecartHopper.TypeId] = typeof(EntityMinecartHopper);
		_registry[EntityMob.TypeId] = typeof(EntityMob);
		_registry[EntityMonster.TypeId] = typeof(EntityMonster);
		_registry[EntityMooshroom.TypeId] = typeof(EntityMooshroom);
		_registry[EntityPainting.TypeId] = typeof(EntityPainting);
		_registry[EntityItemFrame.TypeId] = typeof(EntityItemFrame);
		_registry[EntityPig.TypeId] = typeof(EntityPig);
		_registry[EntityPigZombie.TypeId] = typeof(EntityPigZombie);
		_registry[EntityPrimedTnt.TypeId] = typeof(EntityPrimedTnt);
		_registry[EntitySheep.TypeId] = typeof(EntitySheep);
		_registry[EntitySilverfish.TypeId] = typeof(EntitySilverfish);
		_registry[EntitySkeleton.TypeId] = typeof(EntitySkeleton);
		_registry[EntitySlime.TypeId] = typeof(EntitySlime);
		_registry[EntitySmallFireball.TypeId] = typeof(EntitySmallFireball);
		_registry[EntitySnowball.TypeId] = typeof(EntitySnowball);
		_registry[EntitySnowman.TypeId] = typeof(EntitySnowman);
		_registry[EntitySpider.TypeId] = typeof(EntitySpider);
		_registry[EntitySquid.TypeId] = typeof(EntitySquid);
		_registry[EntityEnderPearl.TypeId] = typeof(EntityEnderPearl);
		_registry[EntityVillager.TypeId] = typeof(EntityVillager);
		_registry[EntityWolf.TypeId] = typeof(EntityWolf);
		_registry[EntityXPOrb.TypeId] = typeof(EntityXPOrb);
		_registry[EntityZombie.TypeId] = typeof(EntityZombie);
		_registry[EntityBat.TypeId] = typeof(EntityBat);
		_registry[EntityWitch.TypeId] = typeof(EntityWitch);
		_registry[EntityOzelot.TypeId] = typeof(EntityOzelot);
		_registry[EntityLeashKnot.TypeId] = typeof(EntityLeashKnot);
	}
}
