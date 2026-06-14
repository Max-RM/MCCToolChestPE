using System;
using System.Collections.Generic;

namespace Substrate;

public class EnchantmentInfo
{
	private class CacheTableDict<T> : ICacheTable<T>
	{
		private Dictionary<int, T> _cache;

		public T this[int index]
		{
			get
			{
				if (_cache.TryGetValue(index, out var value))
				{
					return value;
				}
				return default(T);
			}
		}

		public CacheTableDict(Dictionary<int, T> cache)
		{
			_cache = cache;
		}
	}

	private static Random _rand;

	private static readonly Dictionary<int, EnchantmentInfo> _enchTable;

	private int _id;

	private string _name = "";

	private int _maxLevel;

	private static readonly CacheTableDict<EnchantmentInfo> _enchTableCache;

	public static EnchantmentInfo Protection;

	public static EnchantmentInfo FireProtection;

	public static EnchantmentInfo FeatherFalling;

	public static EnchantmentInfo BlastProtection;

	public static EnchantmentInfo ProjectileProtection;

	public static EnchantmentInfo Respiration;

	public static EnchantmentInfo AquaAffinity;

	public static EnchantmentInfo Sharpness;

	public static EnchantmentInfo Smite;

	public static EnchantmentInfo BaneOfArthropods;

	public static EnchantmentInfo Knockback;

	public static EnchantmentInfo FireAspect;

	public static EnchantmentInfo Looting;

	public static EnchantmentInfo Efficiency;

	public static EnchantmentInfo SilkTouch;

	public static EnchantmentInfo Unbreaking;

	public static EnchantmentInfo Fortune;

	public static ICacheTable<EnchantmentInfo> EnchantmentTable => _enchTableCache;

	public int ID => _id;

	public string Name => _name;

	public int MaxLevel => _maxLevel;

	public EnchantmentInfo(int id)
	{
		_id = id;
		_enchTable[_id] = this;
	}

	public EnchantmentInfo(int id, string name)
	{
		_id = id;
		_name = name;
		_enchTable[_id] = this;
	}

	public EnchantmentInfo SetMaxLevel(int level)
	{
		_maxLevel = level;
		return this;
	}

	public static EnchantmentInfo GetRandomEnchantment()
	{
		List<EnchantmentInfo> list = new List<EnchantmentInfo>(_enchTable.Values);
		return list[_rand.Next(list.Count)];
	}

	static EnchantmentInfo()
	{
		_rand = new Random();
		_enchTable = new Dictionary<int, EnchantmentInfo>();
		_enchTableCache = new CacheTableDict<EnchantmentInfo>(_enchTable);
		Protection = new EnchantmentInfo(0, "Protection").SetMaxLevel(4);
		FireProtection = new EnchantmentInfo(1, "Fire Protection").SetMaxLevel(4);
		FeatherFalling = new EnchantmentInfo(2, "Feather Falling").SetMaxLevel(4);
		BlastProtection = new EnchantmentInfo(3, "Blast Protection").SetMaxLevel(4);
		ProjectileProtection = new EnchantmentInfo(4, "Projectile Protection").SetMaxLevel(4);
		Respiration = new EnchantmentInfo(5, "Respiration").SetMaxLevel(3);
		AquaAffinity = new EnchantmentInfo(6, "Aqua Affinity").SetMaxLevel(1);
		Sharpness = new EnchantmentInfo(16, "Sharpness").SetMaxLevel(5);
		Smite = new EnchantmentInfo(17, "Smite").SetMaxLevel(5);
		BaneOfArthropods = new EnchantmentInfo(18, "Bane of Arthropods").SetMaxLevel(5);
		Knockback = new EnchantmentInfo(19, "Knockback").SetMaxLevel(2);
		FireAspect = new EnchantmentInfo(20, "Fire Aspect").SetMaxLevel(2);
		Looting = new EnchantmentInfo(21, "Looting").SetMaxLevel(3);
		Efficiency = new EnchantmentInfo(32, "Efficiency").SetMaxLevel(5);
		SilkTouch = new EnchantmentInfo(33, "Silk Touch").SetMaxLevel(1);
		Unbreaking = new EnchantmentInfo(34, "Unbreaking").SetMaxLevel(4);
		Fortune = new EnchantmentInfo(35, "Fortune").SetMaxLevel(3);
	}
}
