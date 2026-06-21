namespace Substrate;

public class BlockInfo
{
	private class CacheTableArray<T> : ICacheTable<T>
	{
		private T[] _cache;

		public T this[int index] => _cache[index];

		public CacheTableArray(T[] cache)
		{
			_cache = cache;
		}
	}

	private class DataLimits
	{
		private int _low;

		private int _high;

		private int _bitmask;

		public int Low => _low;

		public int High => _high;

		public int Bitmask => _bitmask;

		public DataLimits(int low, int high, int bitmask)
		{
			_low = low;
			_high = high;
			_bitmask = bitmask;
		}

		public bool Test(int data)
		{
			int num = data & ~_bitmask;
			if (num >= _low)
			{
				return num <= _high;
			}
			return false;
		}
	}

	public const int MAX_BLOCKS = 4096;

	public const int MAX_OPACITY = 15;

	public const int MIN_OPACITY = 0;

	public const int MAX_LUMINANCE = 15;

	public const int MIN_LUMINANCE = 0;

	private static readonly BlockInfo[] _blockTable;

	private static readonly int[] _opacityTable;

	private static readonly int[] _luminanceTable;

	private int _id;

	private string _name = "";

	private int _tick;

	private int _opacity = 15;

	private int _luminance;

	private bool _transmitLight;

	private bool _blocksFluid = true;

	private bool _registered;

	private BlockState _state;

	private DataLimits _dataLimits;

	private static readonly CacheTableArray<BlockInfo> _blockTableCache;

	private static readonly CacheTableArray<int> _opacityTableCache;

	private static readonly CacheTableArray<int> _luminanceTableCache;

	public static BlockInfo Air;

	public static BlockInfo Stone;

	public static BlockInfo Grass;

	public static BlockInfo Dirt;

	public static BlockInfo Cobblestone;

	public static BlockInfo WoodPlank;

	public static BlockInfo Sapling;

	public static BlockInfo Bedrock;

	public static BlockInfo Water;

	public static BlockInfo StationaryWater;

	public static BlockInfo Lava;

	public static BlockInfo StationaryLava;

	public static BlockInfo Sand;

	public static BlockInfo Gravel;

	public static BlockInfo GoldOre;

	public static BlockInfo IronOre;

	public static BlockInfo CoalOre;

	public static BlockInfo Wood;

	public static BlockInfo Leaves;

	public static BlockInfo Sponge;

	public static BlockInfo Glass;

	public static BlockInfo LapisOre;

	public static BlockInfo LapisBlock;

	public static BlockInfoEx Dispenser;

	public static BlockInfo Sandstone;

	public static BlockInfoEx NoteBlock;

	public static BlockInfo Bed;

	public static BlockInfo PoweredRail;

	public static BlockInfo DetectorRail;

	public static BlockInfo StickyPiston;

	public static BlockInfo Cobweb;

	public static BlockInfo TallGrass;

	public static BlockInfo DeadShrub;

	public static BlockInfo Piston;

	public static BlockInfo PistonHead;

	public static BlockInfo Wool;

	public static BlockInfoEx PistonMoving;

	public static BlockInfo YellowFlower;

	public static BlockInfo RedRose;

	public static BlockInfo BrownMushroom;

	public static BlockInfo RedMushroom;

	public static BlockInfo GoldBlock;

	public static BlockInfo IronBlock;

	public static BlockInfo DoubleStoneSlab;

	public static BlockInfo StoneSlab;

	public static BlockInfo BrickBlock;

	public static BlockInfo TNT;

	public static BlockInfo Bookshelf;

	public static BlockInfo MossStone;

	public static BlockInfo Obsidian;

	public static BlockInfo Torch;

	public static BlockInfo Fire;

	public static BlockInfoEx MonsterSpawner;

	public static BlockInfo WoodStairs;

	public static BlockInfoEx Chest;

	public static BlockInfo RedstoneWire;

	public static BlockInfo DiamondOre;

	public static BlockInfo DiamondBlock;

	public static BlockInfo CraftTable;

	public static BlockInfo Crops;

	public static BlockInfo Farmland;

	public static BlockInfoEx Furnace;

	public static BlockInfoEx BurningFurnace;

	public static BlockInfoEx SignPost;

	public static BlockInfo WoodDoor;

	public static BlockInfo Ladder;

	public static BlockInfo Rails;

	public static BlockInfo CobbleStairs;

	public static BlockInfoEx WallSign;

	public static BlockInfo Lever;

	public static BlockInfo StonePlate;

	public static BlockInfo IronDoor;

	public static BlockInfo WoodPlate;

	public static BlockInfo RedstoneOre;

	public static BlockInfo GlowRedstoneOre;

	public static BlockInfo RedstoneTorch;

	public static BlockInfo RedstoneTorchOn;

	public static BlockInfo StoneButton;

	public static BlockInfo Snow;

	public static BlockInfo Ice;

	public static BlockInfo SnowBlock;

	public static BlockInfo Cactus;

	public static BlockInfo ClayBlock;

	public static BlockInfo SugarCane;

	public static BlockInfo Jukebox;

	public static BlockInfo Fence;

	public static BlockInfo Pumpkin;

	public static BlockInfo Netherrack;

	public static BlockInfo SoulSand;

	public static BlockInfo Glowstone;

	public static BlockInfo Portal;

	public static BlockInfo JackOLantern;

	public static BlockInfo CakeBlock;

	public static BlockInfo RedstoneRepeater;

	public static BlockInfo RedstoneRepeaterOn;

	public static BlockInfoEx LockedChest;

	public static BlockInfo Trapdoor;

	public static BlockInfo SilverfishStone;

	public static BlockInfo StoneBrick;

	public static BlockInfo HugeRedMushroom;

	public static BlockInfo HugeBrownMushroom;

	public static BlockInfo IronBars;

	public static BlockInfo GlassPane;

	public static BlockInfo Melon;

	public static BlockInfo PumpkinStem;

	public static BlockInfo MelonStem;

	public static BlockInfo Vines;

	public static BlockInfo FenceGate;

	public static BlockInfo BrickStairs;

	public static BlockInfo StoneBrickStairs;

	public static BlockInfo Mycelium;

	public static BlockInfo LillyPad;

	public static BlockInfo NetherBrick;

	public static BlockInfo NetherBrickFence;

	public static BlockInfo NetherBrickStairs;

	public static BlockInfo NetherWart;

	public static BlockInfoEx EnchantmentTable;

	public static BlockInfoEx BrewingStand;

	public static BlockInfo Cauldron;

	public static BlockInfoEx EndPortal;

	public static BlockInfo EndPortalFrame;

	public static BlockInfo EndStone;

	public static BlockInfo DragonEgg;

	public static BlockInfo RedstoneLampOff;

	public static BlockInfo RedstoneLampOn;

	public static BlockInfo DoubleWoodSlab;

	public static BlockInfo WoodSlab;

	public static BlockInfo CocoaPlant;

	public static BlockInfo SandstoneStairs;

	public static BlockInfo EmeraldOre;

	public static BlockInfoEx EnderChest;

	public static BlockInfo TripwireHook;

	public static BlockInfo Tripwire;

	public static BlockInfo EmeraldBlock;

	public static BlockInfo SpruceWoodStairs;

	public static BlockInfo BirchWoodStairs;

	public static BlockInfo JungleWoodStairs;

	public static BlockInfoEx CommandBlock;

	public static BlockInfoEx BeaconBlock;

	public static BlockInfo CobblestoneWall;

	public static BlockInfo FlowerPot;

	public static BlockInfo Carrots;

	public static BlockInfo Potatoes;

	public static BlockInfo WoodButton;

	public static BlockInfo Heads;

	public static BlockInfo Anvil;

	public static BlockInfoEx TrappedChest;

	public static BlockInfo WeightedPressurePlateLight;

	public static BlockInfo WeightedPressurePlateHeavy;

	public static BlockInfo RedstoneComparatorInactive;

	public static BlockInfo RedstoneComparatorActive;

	public static BlockInfo DaylightSensor;

	public static BlockInfo RedstoneBlock;

	public static BlockInfo NetherQuartzOre;

	public static BlockInfoEx Hopper;

	public static BlockInfo QuartzBlock;

	public static BlockInfo QuartzStairs;

	public static BlockInfo ActivatorRail;

	public static BlockInfoEx Dropper;

	public static BlockInfo StainedClay;

	public static BlockInfo HayBlock;

	public static BlockInfo Carpet;

	public static BlockInfo HardenedClay;

	public static BlockInfo CoalBlock;

	public static ICacheTable<BlockInfo> BlockTable => _blockTableCache;

	public static ICacheTable<int> OpacityTable => _opacityTableCache;

	public static ICacheTable<int> LuminanceTable => _luminanceTableCache;

	public int ID => _id;

	public string Name => _name;

	public int Opacity => _opacity;

	public int Luminance => _luminance;

	public bool TransmitsLight => _transmitLight;

	public bool ObscuresLight
	{
		get
		{
			if (_opacity <= 0)
			{
				return !_transmitLight;
			}
			return true;
		}
	}

	public bool BlocksFluid => _blocksFluid;

	public BlockState State => _state;

	public bool Registered => _registered;

	public int Tick => _tick;

	internal BlockInfo(int id)
	{
		_id = id;
		_name = "Unknown Block";
		_blockTable[_id] = this;
	}

	public BlockInfo(int id, string name)
	{
		_id = id;
		_name = name;
		_blockTable[_id] = this;
		_registered = true;
	}

	public BlockInfo SetOpacity(int opacity)
	{
		_opacity = opacity;
		_opacityTable[_id] = _opacity;
		if (opacity == 15)
		{
			_transmitLight = false;
		}
		else
		{
			_transmitLight = true;
		}
		return this;
	}

	public BlockInfo SetLuminance(int luminance)
	{
		_luminance = luminance;
		_luminanceTable[_id] = _luminance;
		return this;
	}

	public BlockInfo SetLightTransmission(bool transmit)
	{
		_transmitLight = transmit;
		return this;
	}

	public BlockInfo SetDataLimits(int low, int high, int bitmask)
	{
		_dataLimits = new DataLimits(low, high, bitmask);
		return this;
	}

	public BlockInfo SetState(BlockState state)
	{
		_state = state;
		if (_state == BlockState.SOLID)
		{
			_blocksFluid = true;
		}
		else
		{
			_blocksFluid = false;
		}
		return this;
	}

	public BlockInfo SetBlocksFluid(bool blocks)
	{
		_blocksFluid = blocks;
		return this;
	}

	public BlockInfo SetTick(int tick)
	{
		_tick = tick;
		return this;
	}

	public bool TestData(int data)
	{
		if (_dataLimits == null)
		{
			return true;
		}
		return _dataLimits.Test(data);
	}

	static BlockInfo()
	{
		_blockTable = new BlockInfo[4096];
		_opacityTable = new int[4096];
		_luminanceTable = new int[4096];
		_blockTableCache = new CacheTableArray<BlockInfo>(_blockTable);
		_opacityTableCache = new CacheTableArray<int>(_opacityTable);
		_luminanceTableCache = new CacheTableArray<int>(_luminanceTable);
		Air = new BlockInfo(0, "Air").SetOpacity(0).SetState(BlockState.NONSOLID);
		Stone = new BlockInfo(1, "Stone");
		Grass = new BlockInfo(2, "Grass").SetTick(10);
		Dirt = new BlockInfo(3, "Dirt");
		Cobblestone = new BlockInfo(4, "Cobblestone");
		WoodPlank = new BlockInfo(5, "Wooden Plank");
		Sapling = new BlockInfo(6, "Sapling").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		Bedrock = new BlockInfo(7, "Bedrock");
		Water = new BlockInfo(8, "Water").SetOpacity(3).SetState(BlockState.FLUID).SetTick(5);
		StationaryWater = new BlockInfo(9, "Stationary Water").SetOpacity(3).SetState(BlockState.FLUID);
		Lava = new BlockInfo(10, "Lava").SetOpacity(0).SetLuminance(15).SetState(BlockState.FLUID)
			.SetTick(30);
		StationaryLava = new BlockInfo(11, "Stationary Lava").SetOpacity(0).SetLuminance(15).SetState(BlockState.FLUID)
			.SetTick(10);
		Sand = new BlockInfo(12, "Sand").SetTick(3);
		Gravel = new BlockInfo(13, "Gravel").SetTick(3);
		GoldOre = new BlockInfo(14, "Gold Ore");
		IronOre = new BlockInfo(15, "Iron Ore");
		CoalOre = new BlockInfo(16, "Coal Ore");
		Wood = new BlockInfo(17, "Wood");
		Leaves = new BlockInfo(18, "Leaves").SetOpacity(1).SetTick(10);
		Sponge = new BlockInfo(19, "Sponge");
		Glass = new BlockInfo(20, "Glass").SetOpacity(0);
		LapisOre = new BlockInfo(21, "Lapis Lazuli Ore");
		LapisBlock = new BlockInfo(22, "Lapis Lazuli Block");
		Dispenser = (BlockInfoEx)new BlockInfoEx(23, "Dispenser").SetTick(4);
		Sandstone = new BlockInfo(24, "Sandstone");
		NoteBlock = new BlockInfoEx(25, "Note Block");
		Bed = new BlockInfo(26, "Bed").SetOpacity(0);
		PoweredRail = new BlockInfo(27, "Powered Rail").SetOpacity(0).SetState(BlockState.NONSOLID);
		DetectorRail = new BlockInfo(28, "Detector Rail").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(20);
		StickyPiston = new BlockInfo(29, "Sticky Piston").SetOpacity(0);
		Cobweb = new BlockInfo(30, "Cobweb").SetOpacity(0).SetState(BlockState.NONSOLID);
		TallGrass = new BlockInfo(31, "Tall Grass").SetOpacity(0).SetState(BlockState.NONSOLID);
		DeadShrub = new BlockInfo(32, "Dead Shrub").SetOpacity(0).SetState(BlockState.NONSOLID);
		Piston = new BlockInfo(33, "Piston").SetOpacity(0);
		PistonHead = new BlockInfo(34, "Piston Head").SetOpacity(0);
		Wool = new BlockInfo(35, "Wool");
		PistonMoving = (BlockInfoEx)new BlockInfoEx(36, "Piston Moving").SetOpacity(0);
		YellowFlower = new BlockInfo(37, "Yellow Flower").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		RedRose = new BlockInfo(38, "Red Rose").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		BrownMushroom = new BlockInfo(39, "Brown Mushroom").SetOpacity(0).SetLuminance(1).SetState(BlockState.NONSOLID)
			.SetTick(10);
		RedMushroom = new BlockInfo(40, "Red Mushroom").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		GoldBlock = new BlockInfo(41, "Gold Block");
		IronBlock = new BlockInfo(42, "Iron Block");
		DoubleStoneSlab = new BlockInfo(43, "Double Slab");
		StoneSlab = new BlockInfo(44, "Slab").SetOpacity(0);
		BrickBlock = new BlockInfo(45, "Brick Block");
		TNT = new BlockInfo(46, "TNT");
		Bookshelf = new BlockInfo(47, "Bookshelf");
		MossStone = new BlockInfo(48, "Moss Stone");
		Obsidian = new BlockInfo(49, "Obsidian");
		Torch = new BlockInfo(50, "Torch").SetOpacity(0).SetLuminance(14).SetState(BlockState.NONSOLID)
			.SetTick(10);
		Fire = new BlockInfo(51, "Fire").SetOpacity(0).SetLuminance(15).SetState(BlockState.NONSOLID)
			.SetTick(40);
		MonsterSpawner = (BlockInfoEx)new BlockInfoEx(52, "Monster Spawner").SetOpacity(0);
		WoodStairs = new BlockInfo(53, "Wooden Stairs").SetOpacity(0);
		Chest = (BlockInfoEx)new BlockInfoEx(54, "Chest").SetOpacity(0);
		RedstoneWire = new BlockInfo(55, "Redstone Wire").SetOpacity(0).SetState(BlockState.NONSOLID);
		DiamondOre = new BlockInfo(56, "Diamond Ore");
		DiamondBlock = new BlockInfo(57, "Diamond Block");
		CraftTable = new BlockInfo(58, "Crafting Table");
		Crops = new BlockInfo(59, "Crops").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		Farmland = new BlockInfo(60, "Farmland").SetOpacity(0).SetTick(10);
		Furnace = new BlockInfoEx(61, "Furnace");
		BurningFurnace = (BlockInfoEx)new BlockInfoEx(62, "Burning Furnace").SetLuminance(14);
		SignPost = (BlockInfoEx)new BlockInfoEx(63, "Sign Post").SetOpacity(0).SetState(BlockState.NONSOLID);
		WoodDoor = new BlockInfo(64, "Wooden Door").SetOpacity(0);
		Ladder = new BlockInfo(65, "Ladder").SetOpacity(0);
		Rails = new BlockInfo(66, "Rails").SetOpacity(0).SetState(BlockState.NONSOLID);
		CobbleStairs = new BlockInfo(67, "Cobblestone Stairs").SetOpacity(0);
		WallSign = (BlockInfoEx)new BlockInfoEx(68, "Wall Sign").SetOpacity(0).SetState(BlockState.NONSOLID);
		Lever = new BlockInfo(69, "Lever").SetOpacity(0).SetState(BlockState.NONSOLID);
		StonePlate = new BlockInfo(70, "Stone Pressure Plate").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(20);
		IronDoor = new BlockInfo(71, "Iron Door").SetOpacity(0);
		WoodPlate = new BlockInfo(72, "Wooden Pressure Plate").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(20);
		RedstoneOre = new BlockInfo(73, "Redstone Ore").SetTick(30);
		GlowRedstoneOre = new BlockInfo(74, "Glowing Redstone Ore").SetLuminance(9).SetTick(30);
		RedstoneTorch = new BlockInfo(75, "Redstone Torch (Off)").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(2);
		RedstoneTorchOn = new BlockInfo(76, "Redstone Torch (On)").SetOpacity(0).SetLuminance(7).SetState(BlockState.NONSOLID)
			.SetTick(2);
		StoneButton = new BlockInfo(77, "Stone Button").SetOpacity(0).SetState(BlockState.NONSOLID);
		Snow = new BlockInfo(78, "Snow").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		Ice = new BlockInfo(79, "Ice").SetOpacity(3).SetTick(10);
		SnowBlock = new BlockInfo(80, "Snow Block").SetTick(10);
		Cactus = new BlockInfo(81, "Cactus").SetOpacity(0).SetTick(10);
		ClayBlock = new BlockInfo(82, "Clay Block");
		SugarCane = new BlockInfo(83, "Sugar Cane").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		Jukebox = new BlockInfo(84, "Jukebox");
		Fence = new BlockInfo(85, "Fence").SetOpacity(0);
		Pumpkin = new BlockInfo(86, "Pumpkin");
		Netherrack = new BlockInfo(87, "Netherrack");
		SoulSand = new BlockInfo(88, "Soul Sand");
		Glowstone = new BlockInfo(89, "Glowstone Block").SetLuminance(15);
		Portal = new BlockInfo(90, "Portal").SetOpacity(0).SetLuminance(11).SetState(BlockState.NONSOLID);
		JackOLantern = new BlockInfo(91, "Jack-O-Lantern").SetLuminance(15);
		CakeBlock = new BlockInfo(92, "Cake Block").SetOpacity(0);
		RedstoneRepeater = new BlockInfo(93, "Redstone Repeater (Off)").SetOpacity(0).SetTick(10);
		RedstoneRepeaterOn = new BlockInfo(94, "Redstone Repeater (On)").SetOpacity(0).SetLuminance(7).SetTick(10);
		LockedChest = (BlockInfoEx)new BlockInfoEx(95, "Locked Chest").SetLuminance(15).SetTick(10);
		Trapdoor = new BlockInfo(96, "Trapdoor").SetOpacity(0);
		SilverfishStone = new BlockInfo(97, "Stone with Silverfish");
		StoneBrick = new BlockInfo(98, "Stone Brick");
		HugeRedMushroom = new BlockInfo(99, "Huge Red Mushroom");
		HugeBrownMushroom = new BlockInfo(100, "Huge Brown Mushroom");
		IronBars = new BlockInfo(101, "Iron Bars").SetOpacity(0);
		GlassPane = new BlockInfo(102, "Glass Pane").SetOpacity(0);
		Melon = new BlockInfo(103, "Melon");
		PumpkinStem = new BlockInfo(104, "Pumpkin Stem").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		MelonStem = new BlockInfo(105, "Melon Stem").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		Vines = new BlockInfo(106, "Vines").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		FenceGate = new BlockInfo(107, "Fence Gate").SetOpacity(0);
		BrickStairs = new BlockInfo(108, "Brick Stairs").SetOpacity(0);
		StoneBrickStairs = new BlockInfo(109, "Stone Brick Stairs").SetOpacity(0);
		Mycelium = new BlockInfo(110, "Mycelium").SetTick(10);
		LillyPad = new BlockInfo(111, "Lilly Pad").SetOpacity(0).SetState(BlockState.NONSOLID);
		NetherBrick = new BlockInfo(112, "Nether Brick");
		NetherBrickFence = new BlockInfo(113, "Nether Brick Fence").SetOpacity(0);
		NetherBrickStairs = new BlockInfo(114, "Nether Brick Stairs").SetOpacity(0);
		NetherWart = new BlockInfo(115, "Nether Wart").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		EnchantmentTable = (BlockInfoEx)new BlockInfoEx(116, "Enchantment Table").SetOpacity(0);
		BrewingStand = (BlockInfoEx)new BlockInfoEx(117, "Brewing Stand").SetOpacity(0);
		Cauldron = new BlockInfo(118, "Cauldron").SetOpacity(0);
		EndPortal = (BlockInfoEx)new BlockInfoEx(119, "End Portal").SetOpacity(0).SetLuminance(15).SetState(BlockState.NONSOLID);
		EndPortalFrame = new BlockInfo(120, "End Portal Frame").SetLuminance(15);
		EndStone = new BlockInfo(121, "End Stone");
		DragonEgg = new BlockInfo(122, "Dragon Egg").SetOpacity(0).SetLuminance(1).SetTick(3);
		RedstoneLampOff = new BlockInfo(123, "Redstone Lamp (Off)").SetTick(2);
		RedstoneLampOn = new BlockInfo(124, "Redstone Lamp (On)").SetLuminance(15).SetTick(2);
		DoubleWoodSlab = new BlockInfo(125, "Double Wood Slab");
		WoodSlab = new BlockInfo(126, "Wood Slab");
		CocoaPlant = new BlockInfo(127, "Cocoa Plant").SetLuminance(2).SetOpacity(0);
		SandstoneStairs = new BlockInfo(128, "Sandstone Stairs").SetOpacity(0);
		EmeraldOre = new BlockInfo(129, "Emerald Ore");
		EnderChest = (BlockInfoEx)new BlockInfoEx(130, "Ender Chest").SetLuminance(7).SetOpacity(0);
		TripwireHook = new BlockInfo(131, "Tripwire Hook").SetOpacity(0).SetState(BlockState.NONSOLID);
		Tripwire = new BlockInfo(132, "Tripwire").SetOpacity(0).SetState(BlockState.NONSOLID);
		EmeraldBlock = new BlockInfo(133, "Emerald Block");
		SpruceWoodStairs = new BlockInfo(134, "Sprice Wood Stairs").SetOpacity(0);
		BirchWoodStairs = new BlockInfo(135, "Birch Wood Stairs").SetOpacity(0);
		JungleWoodStairs = new BlockInfo(136, "Jungle Wood Stairs").SetOpacity(0);
		CommandBlock = new BlockInfoEx(137, "Command Block");
		BeaconBlock = (BlockInfoEx)new BlockInfoEx(138, "Beacon Block").SetOpacity(0).SetLuminance(15);
		CobblestoneWall = new BlockInfo(139, "Cobblestone Wall").SetOpacity(0);
		FlowerPot = new BlockInfo(140, "Flower Pot").SetOpacity(0);
		Carrots = new BlockInfo(141, "Carrots").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		Potatoes = new BlockInfo(142, "Potatoes").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		WoodButton = new BlockInfo(143, "Wooden Button").SetOpacity(0).SetState(BlockState.NONSOLID);
		Heads = new BlockInfo(144, "Heads").SetOpacity(0);
		Anvil = new BlockInfo(145, "Anvil").SetOpacity(0);
		TrappedChest = (BlockInfoEx)new BlockInfoEx(146, "Trapped Chest").SetOpacity(0).SetTick(10);
		WeightedPressurePlateLight = new BlockInfo(147, "Weighted Pressure Plate (Light)").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(20);
		WeightedPressurePlateHeavy = new BlockInfo(148, "Weighted Pressure Plate (Heavy)").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(20);
		RedstoneComparatorInactive = new BlockInfo(149, "Redstone Comparator (Inactive)").SetOpacity(0).SetTick(10);
		RedstoneComparatorActive = new BlockInfo(150, "Redstone Comparator (Active)").SetOpacity(0).SetLuminance(9).SetTick(10);
		DaylightSensor = new BlockInfo(151, "Daylight Sensor").SetOpacity(0).SetTick(10);
		RedstoneBlock = new BlockInfo(152, "Block of Redstone").SetTick(10);
		NetherQuartzOre = new BlockInfo(153, "Neither Quartz Ore");
		Hopper = (BlockInfoEx)new BlockInfoEx(154, "Hopper").SetOpacity(0).SetTick(10);
		QuartzBlock = new BlockInfo(155, "Block of Quartz");
		QuartzStairs = new BlockInfo(156, "Quartz Stairs").SetOpacity(0);
		ActivatorRail = new BlockInfo(157, "Activator Rail").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
		Dropper = (BlockInfoEx)new BlockInfoEx(158, "Dropper").SetTick(10);
		StainedClay = new BlockInfo(159, "Stained Clay");
		HayBlock = new BlockInfo(170, "Hay Block");
		Carpet = new BlockInfo(171, "Carpet").SetOpacity(0);
		HardenedClay = new BlockInfo(172, "Hardened Clay");
		CoalBlock = new BlockInfo(173, "Block of Coal");
		for (int i = 0; i < 4096; i++)
		{
			if (_blockTable[i] == null)
			{
				_blockTable[i] = new BlockInfo(i);
			}
		}
		Lava.SetLightTransmission(transmit: false);
		StationaryLava.SetLightTransmission(transmit: false);
		StoneSlab.SetLightTransmission(transmit: false);
		WoodStairs.SetLightTransmission(transmit: false);
		Farmland.SetLightTransmission(transmit: false);
		CobbleStairs.SetLightTransmission(transmit: false);
		BrickStairs.SetLightTransmission(transmit: false);
		StoneBrickStairs.SetLightTransmission(transmit: false);
		NetherBrickStairs.SetLightTransmission(transmit: false);
		WoodSlab.SetLightTransmission(transmit: false);
		SandstoneStairs.SetLightTransmission(transmit: false);
		SpruceWoodStairs.SetLightTransmission(transmit: false);
		BirchWoodStairs.SetLightTransmission(transmit: false);
		JungleWoodStairs.SetLightTransmission(transmit: false);
		QuartzStairs.SetLightTransmission(transmit: false);
		Carpet.SetLightTransmission(transmit: false);
		SignPost.SetBlocksFluid(blocks: true);
		WallSign.SetBlocksFluid(blocks: true);
		Cactus.SetBlocksFluid(blocks: false);
		Dispenser.SetTileEntity("Trap");
		NoteBlock.SetTileEntity("Music");
		PistonMoving.SetTileEntity("Piston");
		MonsterSpawner.SetTileEntity("MobSpawner");
		Chest.SetTileEntity("Chest");
		Furnace.SetTileEntity("Furnace");
		BurningFurnace.SetTileEntity("Furnace");
		SignPost.SetTileEntity("Sign");
		WallSign.SetTileEntity("Sign");
		EnchantmentTable.SetTileEntity("EnchantTable");
		BrewingStand.SetTileEntity("Cauldron");
		EndPortal.SetTileEntity("Airportal");
		EnderChest.SetTileEntity("EnderChest");
		CommandBlock.SetTileEntity("Control");
		BeaconBlock.SetTileEntity("Beacon");
		TrappedChest.SetTileEntity("Chest");
		Hopper.SetTileEntity("Hopper");
		Dropper.SetTileEntity("Dropper");
		Wood.SetDataLimits(0, 2, 0);
		Leaves.SetDataLimits(0, 2, 0);
		Jukebox.SetDataLimits(0, 2, 0);
		Sapling.SetDataLimits(0, 15, 0);
		Cactus.SetDataLimits(0, 15, 0);
		SugarCane.SetDataLimits(0, 15, 0);
		Water.SetDataLimits(0, 7, 8);
		Lava.SetDataLimits(0, 7, 8);
		TallGrass.SetDataLimits(0, 2, 0);
		Crops.SetDataLimits(0, 7, 0);
		PoweredRail.SetDataLimits(0, 5, 8);
		DetectorRail.SetDataLimits(0, 5, 8);
		StickyPiston.SetDataLimits(1, 5, 8);
		Piston.SetDataLimits(1, 5, 8);
		PistonHead.SetDataLimits(1, 5, 8);
		Wool.SetDataLimits(0, 15, 0);
		Torch.SetDataLimits(1, 5, 0);
		RedstoneTorch.SetDataLimits(0, 5, 0);
		RedstoneTorchOn.SetDataLimits(0, 5, 0);
		Rails.SetDataLimits(0, 9, 0);
		Ladder.SetDataLimits(2, 5, 0);
		WoodStairs.SetDataLimits(0, 3, 4);
		CobbleStairs.SetDataLimits(0, 3, 4);
		Lever.SetDataLimits(0, 6, 8);
		WoodDoor.SetDataLimits(0, 3, 12);
		IronDoor.SetDataLimits(0, 3, 12);
		StoneButton.SetDataLimits(1, 4, 8);
		Snow.SetDataLimits(0, 7, 0);
		SignPost.SetDataLimits(0, 15, 0);
		WallSign.SetDataLimits(2, 5, 0);
		Furnace.SetDataLimits(2, 5, 0);
		BurningFurnace.SetDataLimits(2, 5, 0);
		Dispenser.SetDataLimits(2, 5, 0);
		Pumpkin.SetDataLimits(0, 3, 0);
		JackOLantern.SetDataLimits(0, 3, 0);
		StonePlate.SetDataLimits(0, 0, 1);
		WoodPlate.SetDataLimits(0, 0, 1);
		StoneSlab.SetDataLimits(0, 5, 0);
		DoubleStoneSlab.SetDataLimits(0, 5, 8);
		Cactus.SetDataLimits(0, 5, 0);
		Bed.SetDataLimits(0, 3, 8);
		RedstoneRepeater.SetDataLimits(0, 0, 15);
		RedstoneRepeaterOn.SetDataLimits(0, 0, 15);
		Trapdoor.SetDataLimits(0, 3, 4);
		StoneBrick.SetDataLimits(0, 2, 0);
		HugeRedMushroom.SetDataLimits(0, 10, 0);
		HugeBrownMushroom.SetDataLimits(0, 10, 0);
		Vines.SetDataLimits(0, 0, 15);
		FenceGate.SetDataLimits(0, 3, 4);
		SilverfishStone.SetDataLimits(0, 2, 0);
		BrewingStand.SetDataLimits(0, 0, 7);
		Cauldron.SetDataLimits(0, 3, 0);
		EndPortalFrame.SetDataLimits(0, 0, 7);
		WoodSlab.SetDataLimits(0, 5, 0);
		DoubleWoodSlab.SetDataLimits(0, 5, 8);
		TripwireHook.SetDataLimits(0, 3, 12);
		Tripwire.SetDataLimits(0, 0, 5);
		Anvil.SetDataLimits(0, 0, 13);
		QuartzBlock.SetDataLimits(0, 4, 0);
		QuartzStairs.SetDataLimits(0, 3, 4);
		Carpet.SetDataLimits(0, 15, 0);
		Dropper.SetDataLimits(0, 5, 0);
		Hopper.SetDataLimits(0, 5, 0);
	}
}
