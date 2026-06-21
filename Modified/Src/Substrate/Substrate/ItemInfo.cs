using System;
using System.Collections.Generic;

namespace Substrate;

public class ItemInfo
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

	private static readonly Dictionary<int, ItemInfo> _itemTable;

	private int _id;

	private string _name = "";

	private int _stack = 1;

	private static readonly CacheTableDict<ItemInfo> _itemTableCache;

	public static ItemInfo IronShovel;

	public static ItemInfo IronPickaxe;

	public static ItemInfo IronAxe;

	public static ItemInfo FlintAndSteel;

	public static ItemInfo Apple;

	public static ItemInfo Bow;

	public static ItemInfo Arrow;

	public static ItemInfo Coal;

	public static ItemInfo Diamond;

	public static ItemInfo IronIngot;

	public static ItemInfo GoldIngot;

	public static ItemInfo IronSword;

	public static ItemInfo WoodenSword;

	public static ItemInfo WoodenShovel;

	public static ItemInfo WoodenPickaxe;

	public static ItemInfo WoodenAxe;

	public static ItemInfo StoneSword;

	public static ItemInfo StoneShovel;

	public static ItemInfo StonePickaxe;

	public static ItemInfo StoneAxe;

	public static ItemInfo DiamondSword;

	public static ItemInfo DiamondShovel;

	public static ItemInfo DiamondPickaxe;

	public static ItemInfo DiamondAxe;

	public static ItemInfo Stick;

	public static ItemInfo Bowl;

	public static ItemInfo MushroomSoup;

	public static ItemInfo GoldSword;

	public static ItemInfo GoldShovel;

	public static ItemInfo GoldPickaxe;

	public static ItemInfo GoldAxe;

	public static ItemInfo String;

	public static ItemInfo Feather;

	public static ItemInfo Gunpowder;

	public static ItemInfo WoodenHoe;

	public static ItemInfo StoneHoe;

	public static ItemInfo IronHoe;

	public static ItemInfo DiamondHoe;

	public static ItemInfo GoldHoe;

	public static ItemInfo Seeds;

	public static ItemInfo Wheat;

	public static ItemInfo Bread;

	public static ItemInfo LeatherCap;

	public static ItemInfo LeatherTunic;

	public static ItemInfo LeatherPants;

	public static ItemInfo LeatherBoots;

	public static ItemInfo ChainHelmet;

	public static ItemInfo ChainChestplate;

	public static ItemInfo ChainLeggings;

	public static ItemInfo ChainBoots;

	public static ItemInfo IronHelmet;

	public static ItemInfo IronChestplate;

	public static ItemInfo IronLeggings;

	public static ItemInfo IronBoots;

	public static ItemInfo DiamondHelmet;

	public static ItemInfo DiamondChestplate;

	public static ItemInfo DiamondLeggings;

	public static ItemInfo DiamondBoots;

	public static ItemInfo GoldHelmet;

	public static ItemInfo GoldChestplate;

	public static ItemInfo GoldLeggings;

	public static ItemInfo GoldBoots;

	public static ItemInfo Flint;

	public static ItemInfo RawPorkchop;

	public static ItemInfo CookedPorkchop;

	public static ItemInfo Painting;

	public static ItemInfo GoldenApple;

	public static ItemInfo Sign;

	public static ItemInfo WoodenDoor;

	public static ItemInfo Bucket;

	public static ItemInfo WaterBucket;

	public static ItemInfo LavaBucket;

	public static ItemInfo Minecart;

	public static ItemInfo Saddle;

	public static ItemInfo IronDoor;

	public static ItemInfo RedstoneDust;

	public static ItemInfo Snowball;

	public static ItemInfo Boat;

	public static ItemInfo Leather;

	public static ItemInfo Milk;

	public static ItemInfo ClayBrick;

	public static ItemInfo Clay;

	public static ItemInfo SugarCane;

	public static ItemInfo Paper;

	public static ItemInfo Book;

	public static ItemInfo Slimeball;

	public static ItemInfo StorageMinecart;

	public static ItemInfo PoweredMinecart;

	public static ItemInfo Egg;

	public static ItemInfo Compass;

	public static ItemInfo FishingRod;

	public static ItemInfo Clock;

	public static ItemInfo GlowstoneDust;

	public static ItemInfo RawFish;

	public static ItemInfo CookedFish;

	public static ItemInfo Dye;

	public static ItemInfo Bone;

	public static ItemInfo Sugar;

	public static ItemInfo Cake;

	public static ItemInfo Bed;

	public static ItemInfo RedstoneRepeater;

	public static ItemInfo Cookie;

	public static ItemInfo Map;

	public static ItemInfo Shears;

	public static ItemInfo MelonSlice;

	public static ItemInfo PumpkinSeeds;

	public static ItemInfo MelonSeeds;

	public static ItemInfo RawBeef;

	public static ItemInfo Steak;

	public static ItemInfo RawChicken;

	public static ItemInfo CookedChicken;

	public static ItemInfo RottenFlesh;

	public static ItemInfo EnderPearl;

	public static ItemInfo BlazeRod;

	public static ItemInfo GhastTear;

	public static ItemInfo GoldNugget;

	public static ItemInfo NetherWart;

	public static ItemInfo Potion;

	public static ItemInfo GlassBottle;

	public static ItemInfo SpiderEye;

	public static ItemInfo FermentedSpiderEye;

	public static ItemInfo BlazePowder;

	public static ItemInfo MagmaCream;

	public static ItemInfo BrewingStand;

	public static ItemInfo Cauldron;

	public static ItemInfo EyeOfEnder;

	public static ItemInfo GlisteringMelon;

	public static ItemInfo SpawnEgg;

	public static ItemInfo BottleOEnchanting;

	public static ItemInfo FireCharge;

	public static ItemInfo BookAndQuill;

	public static ItemInfo WrittenBook;

	public static ItemInfo Emerald;

	public static ItemInfo ItemFrame;

	public static ItemInfo FlowerPot;

	public static ItemInfo Carrot;

	public static ItemInfo Potato;

	public static ItemInfo BakedPotato;

	public static ItemInfo PoisonPotato;

	public static ItemInfo EmptyMap;

	public static ItemInfo GoldenCarrot;

	public static ItemInfo MobHead;

	public static ItemInfo CarrotOnStick;

	public static ItemInfo NetherStar;

	public static ItemInfo PumpkinPie;

	public static ItemInfo FireworkRocket;

	public static ItemInfo FireworkStar;

	public static ItemInfo EnchantedBook;

	public static ItemInfo RedstoneComparator;

	public static ItemInfo NetherBrick;

	public static ItemInfo NetherQuartz;

	public static ItemInfo TntMinecart;

	public static ItemInfo HopperMinecart;

	public static ItemInfo IronHorseArmor;

	public static ItemInfo GoldHorseArmor;

	public static ItemInfo DiamondHorseArmor;

	public static ItemInfo Lead;

	public static ItemInfo NameTag;

	public static ItemInfo MusicDisc13;

	public static ItemInfo MusicDiscCat;

	public static ItemInfo MusicDiscBlocks;

	public static ItemInfo MusicDiscChirp;

	public static ItemInfo MusicDiscFar;

	public static ItemInfo MusicDiscMall;

	public static ItemInfo MusicDiscMellohi;

	public static ItemInfo MusicDiscStal;

	public static ItemInfo MusicDiscStrad;

	public static ItemInfo MusicDiscWard;

	public static ItemInfo MusicDisc11;

	public static ICacheTable<ItemInfo> ItemTable => _itemTableCache;

	public int ID => _id;

	public string Name => _name;

	public int StackSize => _stack;

	public ItemInfo(int id)
	{
		_id = id;
		_itemTable[_id] = this;
	}

	public ItemInfo(int id, string name)
	{
		_id = id;
		_name = name;
		_itemTable[_id] = this;
	}

	public ItemInfo SetStackSize(int stack)
	{
		_stack = stack;
		return this;
	}

	public static ItemInfo GetRandomItem()
	{
		List<ItemInfo> list = new List<ItemInfo>(_itemTable.Values);
		return list[_rand.Next(list.Count)];
	}

	static ItemInfo()
	{
		_rand = new Random();
		_itemTable = new Dictionary<int, ItemInfo>();
		_itemTableCache = new CacheTableDict<ItemInfo>(_itemTable);
		IronShovel = new ItemInfo(256, "Iron Shovel");
		IronPickaxe = new ItemInfo(257, "Iron Pickaxe");
		IronAxe = new ItemInfo(258, "Iron Axe");
		FlintAndSteel = new ItemInfo(259, "Flint and Steel");
		Apple = new ItemInfo(260, "Apple").SetStackSize(64);
		Bow = new ItemInfo(261, "Bow");
		Arrow = new ItemInfo(262, "Arrow").SetStackSize(64);
		Coal = new ItemInfo(263, "Coal").SetStackSize(64);
		Diamond = new ItemInfo(264, "Diamond").SetStackSize(64);
		IronIngot = new ItemInfo(265, "Iron Ingot").SetStackSize(64);
		GoldIngot = new ItemInfo(266, "Gold Ingot").SetStackSize(64);
		IronSword = new ItemInfo(267, "Iron Sword");
		WoodenSword = new ItemInfo(268, "Wooden Sword");
		WoodenShovel = new ItemInfo(269, "Wooden Shovel");
		WoodenPickaxe = new ItemInfo(270, "Wooden Pickaxe");
		WoodenAxe = new ItemInfo(271, "Wooden Axe");
		StoneSword = new ItemInfo(272, "Stone Sword");
		StoneShovel = new ItemInfo(273, "Stone Shovel");
		StonePickaxe = new ItemInfo(274, "Stone Pickaxe");
		StoneAxe = new ItemInfo(275, "Stone Axe");
		DiamondSword = new ItemInfo(276, "Diamond Sword");
		DiamondShovel = new ItemInfo(277, "Diamond Shovel");
		DiamondPickaxe = new ItemInfo(278, "Diamond Pickaxe");
		DiamondAxe = new ItemInfo(279, "Diamond Axe");
		Stick = new ItemInfo(280, "Stick").SetStackSize(64);
		Bowl = new ItemInfo(281, "Bowl").SetStackSize(64);
		MushroomSoup = new ItemInfo(282, "Mushroom Soup");
		GoldSword = new ItemInfo(283, "Gold Sword");
		GoldShovel = new ItemInfo(284, "Gold Shovel");
		GoldPickaxe = new ItemInfo(285, "Gold Pickaxe");
		GoldAxe = new ItemInfo(286, "Gold Axe");
		String = new ItemInfo(287, "String").SetStackSize(64);
		Feather = new ItemInfo(288, "Feather").SetStackSize(64);
		Gunpowder = new ItemInfo(289, "Gunpowder").SetStackSize(64);
		WoodenHoe = new ItemInfo(290, "Wooden Hoe");
		StoneHoe = new ItemInfo(291, "Stone Hoe");
		IronHoe = new ItemInfo(292, "Iron Hoe");
		DiamondHoe = new ItemInfo(293, "Diamond Hoe");
		GoldHoe = new ItemInfo(294, "Gold Hoe");
		Seeds = new ItemInfo(295, "Seeds").SetStackSize(64);
		Wheat = new ItemInfo(296, "Wheat").SetStackSize(64);
		Bread = new ItemInfo(297, "Bread").SetStackSize(64);
		LeatherCap = new ItemInfo(298, "Leather Cap");
		LeatherTunic = new ItemInfo(299, "Leather Tunic");
		LeatherPants = new ItemInfo(300, "Leather Pants");
		LeatherBoots = new ItemInfo(301, "Leather Boots");
		ChainHelmet = new ItemInfo(302, "Chain Helmet");
		ChainChestplate = new ItemInfo(303, "Chain Chestplate");
		ChainLeggings = new ItemInfo(304, "Chain Leggings");
		ChainBoots = new ItemInfo(305, "Chain Boots");
		IronHelmet = new ItemInfo(306, "Iron Helmet");
		IronChestplate = new ItemInfo(307, "Iron Chestplate");
		IronLeggings = new ItemInfo(308, "Iron Leggings");
		IronBoots = new ItemInfo(309, "Iron Boots");
		DiamondHelmet = new ItemInfo(310, "Diamond Helmet");
		DiamondChestplate = new ItemInfo(311, "Diamond Chestplate");
		DiamondLeggings = new ItemInfo(312, "Diamond Leggings");
		DiamondBoots = new ItemInfo(313, "Diamond Boots");
		GoldHelmet = new ItemInfo(314, "Gold Helmet");
		GoldChestplate = new ItemInfo(315, "Gold Chestplate");
		GoldLeggings = new ItemInfo(316, "Gold Leggings");
		GoldBoots = new ItemInfo(317, "Gold Boots");
		Flint = new ItemInfo(318, "Flint").SetStackSize(64);
		RawPorkchop = new ItemInfo(319, "Raw Porkchop").SetStackSize(64);
		CookedPorkchop = new ItemInfo(320, "Cooked Porkchop").SetStackSize(64);
		Painting = new ItemInfo(321, "Painting").SetStackSize(64);
		GoldenApple = new ItemInfo(322, "Golden Apple").SetStackSize(64);
		Sign = new ItemInfo(323, "Sign");
		WoodenDoor = new ItemInfo(324, "Door");
		Bucket = new ItemInfo(325, "Bucket");
		WaterBucket = new ItemInfo(326, "Water Bucket");
		LavaBucket = new ItemInfo(327, "Lava Bucket");
		Minecart = new ItemInfo(328, "Minecart");
		Saddle = new ItemInfo(329, "Saddle");
		IronDoor = new ItemInfo(330, "Iron Door");
		RedstoneDust = new ItemInfo(331, "Redstone Dust").SetStackSize(64);
		Snowball = new ItemInfo(332, "Snowball").SetStackSize(16);
		Boat = new ItemInfo(333, "Boat");
		Leather = new ItemInfo(334, "Leather").SetStackSize(64);
		Milk = new ItemInfo(335, "Milk");
		ClayBrick = new ItemInfo(336, "Clay Brick").SetStackSize(64);
		Clay = new ItemInfo(337, "Clay").SetStackSize(64);
		SugarCane = new ItemInfo(338, "Sugar Cane").SetStackSize(64);
		Paper = new ItemInfo(339, "Paper").SetStackSize(64);
		Book = new ItemInfo(340, "Book").SetStackSize(64);
		Slimeball = new ItemInfo(341, "Slimeball").SetStackSize(64);
		StorageMinecart = new ItemInfo(342, "Storage Miencart");
		PoweredMinecart = new ItemInfo(343, "Powered Minecart");
		Egg = new ItemInfo(344, "Egg").SetStackSize(16);
		Compass = new ItemInfo(345, "Compass");
		FishingRod = new ItemInfo(346, "Fishing Rod");
		Clock = new ItemInfo(347, "Clock");
		GlowstoneDust = new ItemInfo(348, "Glowstone Dust").SetStackSize(64);
		RawFish = new ItemInfo(349, "Raw Fish").SetStackSize(64);
		CookedFish = new ItemInfo(350, "Cooked Fish").SetStackSize(64);
		Dye = new ItemInfo(351, "Dye").SetStackSize(64);
		Bone = new ItemInfo(352, "Bone").SetStackSize(64);
		Sugar = new ItemInfo(353, "Sugar").SetStackSize(64);
		Cake = new ItemInfo(354, "Cake");
		Bed = new ItemInfo(355, "Bed");
		RedstoneRepeater = new ItemInfo(356, "Redstone Repeater").SetStackSize(64);
		Cookie = new ItemInfo(357, "Cookie").SetStackSize(8);
		Map = new ItemInfo(358, "Map");
		Shears = new ItemInfo(359, "Shears");
		MelonSlice = new ItemInfo(360, "Melon Slice").SetStackSize(64);
		PumpkinSeeds = new ItemInfo(361, "Pumpkin Seeds").SetStackSize(64);
		MelonSeeds = new ItemInfo(362, "Melon Seeds").SetStackSize(64);
		RawBeef = new ItemInfo(363, "Raw Beef").SetStackSize(64);
		Steak = new ItemInfo(364, "Steak").SetStackSize(64);
		RawChicken = new ItemInfo(365, "Raw Chicken").SetStackSize(64);
		CookedChicken = new ItemInfo(366, "Cooked Chicken").SetStackSize(64);
		RottenFlesh = new ItemInfo(367, "Rotten Flesh").SetStackSize(64);
		EnderPearl = new ItemInfo(368, "Ender Pearl").SetStackSize(64);
		BlazeRod = new ItemInfo(369, "Blaze Rod").SetStackSize(64);
		GhastTear = new ItemInfo(370, "Ghast Tear").SetStackSize(64);
		GoldNugget = new ItemInfo(371, "Gold Nugget").SetStackSize(64);
		NetherWart = new ItemInfo(372, "Nether Wart").SetStackSize(64);
		Potion = new ItemInfo(373, "Potion");
		GlassBottle = new ItemInfo(374, "Glass Bottle").SetStackSize(64);
		SpiderEye = new ItemInfo(375, "Spider Eye").SetStackSize(64);
		FermentedSpiderEye = new ItemInfo(376, "Fermented Spider Eye").SetStackSize(64);
		BlazePowder = new ItemInfo(377, "Blaze Powder").SetStackSize(64);
		MagmaCream = new ItemInfo(378, "Magma Cream").SetStackSize(64);
		BrewingStand = new ItemInfo(379, "Brewing Stand").SetStackSize(64);
		Cauldron = new ItemInfo(380, "Cauldron");
		EyeOfEnder = new ItemInfo(381, "Eye of Ender").SetStackSize(64);
		GlisteringMelon = new ItemInfo(382, "Glistering Melon").SetStackSize(64);
		SpawnEgg = new ItemInfo(383, "Spawn Egg").SetStackSize(64);
		BottleOEnchanting = new ItemInfo(384, "Bottle O' Enchanting").SetStackSize(64);
		FireCharge = new ItemInfo(385, "Fire Charge").SetStackSize(64);
		BookAndQuill = new ItemInfo(386, "Book and Quill");
		WrittenBook = new ItemInfo(387, "Written Book");
		Emerald = new ItemInfo(388, "Emerald").SetStackSize(64);
		ItemFrame = new ItemInfo(389, "Item Frame").SetStackSize(64);
		FlowerPot = new ItemInfo(390, "Flower Pot").SetStackSize(64);
		Carrot = new ItemInfo(391, "Carrot").SetStackSize(64);
		Potato = new ItemInfo(392, "Potato").SetStackSize(64);
		BakedPotato = new ItemInfo(393, "Baked Potato").SetStackSize(64);
		PoisonPotato = new ItemInfo(394, "Poisonous Potato").SetStackSize(64);
		EmptyMap = new ItemInfo(395, "Empty Map").SetStackSize(64);
		GoldenCarrot = new ItemInfo(396, "Golden Carrot").SetStackSize(64);
		MobHead = new ItemInfo(397, "Mob Head").SetStackSize(64);
		CarrotOnStick = new ItemInfo(398, "Carrot on a Stick");
		NetherStar = new ItemInfo(399, "Nether Star").SetStackSize(64);
		PumpkinPie = new ItemInfo(400, "Pumpkin Pie").SetStackSize(64);
		FireworkRocket = new ItemInfo(401, "Firework Rocket");
		FireworkStar = new ItemInfo(402, "Firework Star").SetStackSize(64);
		EnchantedBook = new ItemInfo(403, "Enchanted Book");
		RedstoneComparator = new ItemInfo(404, "Redstone Comparator").SetStackSize(64);
		NetherBrick = new ItemInfo(405, "Nether Brick").SetStackSize(64);
		NetherQuartz = new ItemInfo(406, "Nether Quartz").SetStackSize(64);
		TntMinecart = new ItemInfo(407, "Minecart with TNT");
		HopperMinecart = new ItemInfo(408, "Minecart with Hopper");
		IronHorseArmor = new ItemInfo(417, "Iron Horse Armor");
		GoldHorseArmor = new ItemInfo(418, "Gold Horse Armor");
		DiamondHorseArmor = new ItemInfo(419, "Diamond Horse Armor");
		Lead = new ItemInfo(420, "Lead").SetStackSize(64);
		NameTag = new ItemInfo(421, "Name Tag").SetStackSize(64);
		MusicDisc13 = new ItemInfo(2256, "13 Disc");
		MusicDiscCat = new ItemInfo(2257, "Cat Disc");
		MusicDiscBlocks = new ItemInfo(2258, "Blocks Disc");
		MusicDiscChirp = new ItemInfo(2259, "Chirp Disc");
		MusicDiscFar = new ItemInfo(2260, "Far Disc");
		MusicDiscMall = new ItemInfo(2261, "Mall Disc");
		MusicDiscMellohi = new ItemInfo(2262, "Mellohi Disc");
		MusicDiscStal = new ItemInfo(2263, "Stal Disc");
		MusicDiscStrad = new ItemInfo(2264, "Strad Disc");
		MusicDiscWard = new ItemInfo(2265, "Ward Disc");
		MusicDisc11 = new ItemInfo(2266, "11 Disc");
	}
}
