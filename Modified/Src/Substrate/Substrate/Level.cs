using System;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class Level : INbtObject<Level>, ICopyable<Level>
{
	private static SchemaNodeCompound _schema = new SchemaNodeCompound
	{
		new SchemaNodeCompound("Data")
		{
			new SchemaNodeScaler("Time", TagType.TAG_LONG),
			new SchemaNodeScaler("clearWeatherTime", TagType.TAG_INT, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("LastPlayed", TagType.TAG_LONG, SchemaOptions.CREATE_ON_MISSING),
			new SchemaNodeCompound("Player", Player.Schema, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("SpawnX", TagType.TAG_INT),
			new SchemaNodeScaler("SpawnY", TagType.TAG_INT),
			new SchemaNodeScaler("SpawnZ", TagType.TAG_INT),
			new SchemaNodeScaler("SizeOnDisk", TagType.TAG_LONG, SchemaOptions.CREATE_ON_MISSING),
			new SchemaNodeScaler("RandomSeed", TagType.TAG_LONG),
			new SchemaNodeScaler("version", TagType.TAG_INT, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("LevelName", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("generatorName", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("raining", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("thundering", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("rainTime", TagType.TAG_INT, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("thunderTime", TagType.TAG_INT, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("GameType", TagType.TAG_INT, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("MapFeatures", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("hardcore", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("generatorVersion", TagType.TAG_INT, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("generatorOptions", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("initialized", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("allowCommands", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("DayTime", TagType.TAG_LONG, SchemaOptions.OPTIONAL),
			new SchemaNodeCompound("GameRules", SchemaOptions.OPTIONAL)
			{
				new SchemaNodeScaler("commandBlockOutput", TagType.TAG_STRING),
				new SchemaNodeScaler("doFireTick", TagType.TAG_STRING),
				new SchemaNodeScaler("doMobLoot", TagType.TAG_STRING),
				new SchemaNodeScaler("doMobSpawning", TagType.TAG_STRING),
				new SchemaNodeScaler("doTileDrops", TagType.TAG_STRING),
				new SchemaNodeScaler("keepInventory", TagType.TAG_STRING),
				new SchemaNodeScaler("mobGriefing", TagType.TAG_STRING)
			}
		}
	};

	private TagNodeCompound _source;

	private NbtWorld _world;

	private long _time;

	private int? _clearWeatherTime;

	private long _lastPlayed;

	private Player _player;

	private int _spawnX;

	private int _spawnY;

	private int _spawnZ;

	private long _sizeOnDisk;

	private long _randomSeed;

	private int? _version;

	private string _name;

	private string _generator;

	private byte? _raining;

	private byte? _thundering;

	private int? _rainTime;

	private int? _thunderTime;

	private int? _gameType;

	private byte? _mapFeatures;

	private byte? _hardcore;

	private int? _generatorVersion;

	private string _generatorOptions;

	private byte? _initialized;

	private byte? _allowCommands;

	private long? _DayTime;

	private GameRules _gameRules;

	public long Time
	{
		get
		{
			return _time;
		}
		set
		{
			_time = value;
		}
	}

	public int ClearWeatherTime
	{
		get
		{
			return _clearWeatherTime ?? 0;
		}
		set
		{
			_clearWeatherTime = value;
		}
	}

	public long LastPlayed
	{
		get
		{
			return _lastPlayed;
		}
		set
		{
			_lastPlayed = value;
		}
	}

	public Player Player
	{
		get
		{
			return _player;
		}
		set
		{
			_player = value;
			_player.World = _name;
		}
	}

	public SpawnPoint Spawn
	{
		get
		{
			return new SpawnPoint(_spawnX, _spawnY, _spawnZ);
		}
		set
		{
			_spawnX = value.X;
			_spawnY = value.Y;
			_spawnZ = value.Z;
		}
	}

	public long SizeOnDisk => _sizeOnDisk;

	public long RandomSeed
	{
		get
		{
			return _randomSeed;
		}
		set
		{
			_randomSeed = value;
		}
	}

	public int Version
	{
		get
		{
			return _version ?? 0;
		}
		set
		{
			_version = value;
		}
	}

	public string LevelName
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
			if (_player != null)
			{
				_player.World = value;
			}
		}
	}

	public string GeneratorName
	{
		get
		{
			return _generator;
		}
		set
		{
			_generator = value;
		}
	}

	public bool IsRaining
	{
		get
		{
			return (_raining ?? 0) == 1;
		}
		set
		{
			_raining = (byte)(value ? 1 : 0);
		}
	}

	public bool IsThundering
	{
		get
		{
			return (_thundering ?? 0) == 1;
		}
		set
		{
			_thundering = (byte)(value ? 1 : 0);
		}
	}

	public int RainTime
	{
		get
		{
			return _rainTime ?? 0;
		}
		set
		{
			_rainTime = value;
		}
	}

	public int ThunderTime
	{
		get
		{
			return _thunderTime ?? 0;
		}
		set
		{
			_thunderTime = value;
		}
	}

	public GameType GameType
	{
		get
		{
			return (GameType)(_gameType ?? 0);
		}
		set
		{
			_gameType = (int)value;
		}
	}

	public bool UseMapFeatures
	{
		get
		{
			return (_mapFeatures ?? 0) == 1;
		}
		set
		{
			_mapFeatures = (byte)(value ? 1 : 0);
		}
	}

	public bool Hardcore
	{
		get
		{
			return (_hardcore ?? 0) == 1;
		}
		set
		{
			_hardcore = (byte)(value ? 1 : 0);
		}
	}

	public int GeneratorVersion
	{
		get
		{
			return _generatorVersion ?? 0;
		}
		set
		{
			_generatorVersion = value;
		}
	}

	public string GeneratorOptions
	{
		get
		{
			return _generatorOptions ?? "";
		}
		set
		{
			_generatorOptions = value;
		}
	}

	public bool Initialized
	{
		get
		{
			return (_initialized ?? 0) == 1;
		}
		set
		{
			_initialized = (byte)(value ? 1 : 0);
		}
	}

	public bool AllowCommands
	{
		get
		{
			return (_allowCommands ?? 0) == 1;
		}
		set
		{
			_allowCommands = (byte)(value ? 1 : 0);
		}
	}

	public long DayTime
	{
		get
		{
			return _DayTime ?? 0;
		}
		set
		{
			_DayTime = value;
		}
	}

	public GameRules GameRules => _gameRules;

	public TagNodeCompound Source => _source;

	public static SchemaNodeCompound Schema => _schema;

	public Level(NbtWorld world)
	{
		_world = world;
		_time = 0L;
		_lastPlayed = 0L;
		_spawnX = 0;
		_spawnY = 64;
		_spawnZ = 0;
		_sizeOnDisk = 0L;
		_randomSeed = new Random().Next();
		_version = 19133;
		_name = "Untitled";
		_generator = "default";
		_hardcore = 0;
		_generatorOptions = "";
		_generatorVersion = 1;
		_initialized = 0;
		_allowCommands = 0;
		_DayTime = 0L;
		_gameRules = new GameRules();
		GameType = GameType.SURVIVAL;
		UseMapFeatures = true;
		_source = new TagNodeCompound();
	}

	protected Level(Level p)
	{
		_world = p._world;
		_time = p._time;
		_clearWeatherTime = p._clearWeatherTime;
		_lastPlayed = p._lastPlayed;
		_spawnX = p._spawnX;
		_spawnY = p._spawnY;
		_spawnZ = p._spawnZ;
		_sizeOnDisk = p._sizeOnDisk;
		_randomSeed = p._randomSeed;
		_version = p._version;
		_name = p._name;
		_generator = p._generator;
		_raining = p._raining;
		_thundering = p._thundering;
		_rainTime = p._rainTime;
		_thunderTime = p._thunderTime;
		_gameType = p._gameType;
		_mapFeatures = p._mapFeatures;
		_hardcore = p._hardcore;
		_generatorVersion = p._generatorVersion;
		_generatorOptions = p._generatorOptions;
		_initialized = p._initialized;
		_allowCommands = p._allowCommands;
		_DayTime = p._DayTime;
		_gameRules = p._gameRules.Copy();
		if (p._player != null)
		{
			_player = p._player.Copy();
		}
		if (p._source != null)
		{
			_source = p._source.Copy() as TagNodeCompound;
		}
	}

	public void SetDefaultPlayer()
	{
		_player = new Player();
		_player.World = _name;
		_player.Position.X = _spawnX;
		_player.Position.Y = (double)_spawnY + 1.7;
		_player.Position.Z = _spawnZ;
	}

	public bool Save()
	{
		if (_world == null)
		{
			return false;
		}
		try
		{
			NBTFile nBTFile = new NBTFile(Path.Combine(_world.Path, "level.dat"));
			Stream dataOutputStream = nBTFile.GetDataOutputStream();
			if (dataOutputStream == null)
			{
				NbtIOException ex = new NbtIOException("Failed to initialize compressed NBT stream for output");
				ex.Data["Level"] = this;
				throw ex;
			}
			new NbtTree(BuildTree() as TagNodeCompound).WriteTo(dataOutputStream);
			dataOutputStream.Close();
			return true;
		}
		catch (Exception innerException)
		{
			LevelIOException ex2 = new LevelIOException("Could not save level file.", innerException);
			ex2.Data["Level"] = this;
			throw ex2;
		}
	}

	public virtual Level LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound))
		{
			return null;
		}
		_clearWeatherTime = null;
		_version = null;
		_raining = null;
		_rainTime = null;
		_thundering = null;
		_thunderTime = null;
		_gameType = null;
		_mapFeatures = null;
		_generatorOptions = null;
		_generatorVersion = null;
		_allowCommands = null;
		_initialized = null;
		_DayTime = null;
		TagNodeCompound tagNodeCompound2 = tagNodeCompound["Data"].ToTagCompound();
		_time = tagNodeCompound2["Time"].ToTagLong();
		if (tagNodeCompound2.ContainsKey("clearWeatherTime"))
		{
			_clearWeatherTime = tagNodeCompound2["clearWeatherTime"].ToTagInt();
		}
		if (tagNodeCompound2.ContainsKey("LastPlayed"))
		{
			_lastPlayed = tagNodeCompound2["LastPlayed"].ToTagLong();
		}
		if (tagNodeCompound2.ContainsKey("Player"))
		{
			_player = new Player().LoadTree(tagNodeCompound2["Player"]);
		}
		_spawnX = tagNodeCompound2["SpawnX"].ToTagInt();
		_spawnY = tagNodeCompound2["SpawnY"].ToTagInt();
		_spawnZ = tagNodeCompound2["SpawnZ"].ToTagInt();
		_sizeOnDisk = tagNodeCompound2["SizeOnDisk"].ToTagLong();
		_randomSeed = tagNodeCompound2["RandomSeed"].ToTagLong();
		if (tagNodeCompound2.ContainsKey("version"))
		{
			_version = tagNodeCompound2["version"].ToTagInt();
		}
		if (tagNodeCompound2.ContainsKey("LevelName"))
		{
			_name = tagNodeCompound2["LevelName"].ToTagString();
		}
		if (tagNodeCompound2.ContainsKey("generatorName"))
		{
			_generator = tagNodeCompound2["generatorName"].ToTagString();
		}
		if (tagNodeCompound2.ContainsKey("raining"))
		{
			_raining = tagNodeCompound2["raining"].ToTagByte();
		}
		if (tagNodeCompound2.ContainsKey("thundering"))
		{
			_thundering = tagNodeCompound2["thundering"].ToTagByte();
		}
		if (tagNodeCompound2.ContainsKey("rainTime"))
		{
			_rainTime = tagNodeCompound2["rainTime"].ToTagInt();
		}
		if (tagNodeCompound2.ContainsKey("thunderTime"))
		{
			_thunderTime = tagNodeCompound2["thunderTime"].ToTagInt();
		}
		if (tagNodeCompound2.ContainsKey("GameType"))
		{
			_gameType = tagNodeCompound2["GameType"].ToTagInt();
		}
		if (tagNodeCompound2.ContainsKey("MapFeatures"))
		{
			_mapFeatures = tagNodeCompound2["MapFeatures"].ToTagByte();
		}
		if (tagNodeCompound2.ContainsKey("hardcore"))
		{
			_hardcore = tagNodeCompound2["hardcore"].ToTagByte();
		}
		if (tagNodeCompound2.ContainsKey("generatorVersion"))
		{
			_generatorVersion = tagNodeCompound2["generatorVersion"].ToTagInt();
		}
		if (tagNodeCompound2.ContainsKey("generatorOptions") && tagNodeCompound2["generatorOptions"] is TagNodeString)
		{
			_generatorOptions = tagNodeCompound2["generatorOptions"].ToTagString();
		}
		if (tagNodeCompound2.ContainsKey("allowCommands"))
		{
			_allowCommands = tagNodeCompound2["allowCommands"].ToTagByte();
		}
		if (tagNodeCompound2.ContainsKey("initialized"))
		{
			_initialized = tagNodeCompound2["initialized"].ToTagByte();
		}
		if (tagNodeCompound2.ContainsKey("DayTime"))
		{
			_DayTime = tagNodeCompound2["DayTime"].ToTagLong();
		}
		if (tagNodeCompound2.ContainsKey("GameRules"))
		{
			TagNodeCompound tagNodeCompound3 = tagNodeCompound2["GameRules"].ToTagCompound();
			_gameRules = new GameRules();
			_gameRules.CommandBlockOutput = tagNodeCompound3["commandBlockOutput"].ToTagString().Data == "true";
			_gameRules.DoFireTick = tagNodeCompound3["doFireTick"].ToTagString().Data == "true";
			_gameRules.DoMobLoot = tagNodeCompound3["doMobLoot"].ToTagString().Data == "true";
			_gameRules.DoMobSpawning = tagNodeCompound3["doMobSpawning"].ToTagString().Data == "true";
			_gameRules.DoTileDrops = tagNodeCompound3["doTileDrops"].ToTagString().Data == "true";
			_gameRules.KeepInventory = tagNodeCompound3["keepInventory"].ToTagString().Data == "true";
			_gameRules.MobGriefing = tagNodeCompound3["mobGriefing"].ToTagString().Data == "true";
		}
		_source = tagNodeCompound2.Copy() as TagNodeCompound;
		return this;
	}

	public virtual Level LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public virtual TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound["Time"] = new TagNodeLong(_time);
		if (_clearWeatherTime.HasValue)
		{
			tagNodeCompound["clearWeatherTime"] = new TagNodeInt(_clearWeatherTime ?? 0);
		}
		tagNodeCompound["LastPlayed"] = new TagNodeLong(_lastPlayed);
		if (_player != null)
		{
			tagNodeCompound["Player"] = _player.BuildTree();
		}
		tagNodeCompound["SpawnX"] = new TagNodeInt(_spawnX);
		tagNodeCompound["SpawnY"] = new TagNodeInt(_spawnY);
		tagNodeCompound["SpawnZ"] = new TagNodeInt(_spawnZ);
		tagNodeCompound["SizeOnDisk"] = new TagNodeLong(_sizeOnDisk);
		tagNodeCompound["RandomSeed"] = new TagNodeLong(_randomSeed);
		if (_version.HasValue)
		{
			int? version = _version;
			if (version.GetValueOrDefault() != 0 || !version.HasValue)
			{
				tagNodeCompound["version"] = new TagNodeInt(_version ?? 0);
			}
		}
		if (_name != null)
		{
			tagNodeCompound["LevelName"] = new TagNodeString(_name);
		}
		if (_generator != null)
		{
			tagNodeCompound["generatorName"] = new TagNodeString(_generator);
		}
		if (((int?)_raining).HasValue)
		{
			tagNodeCompound["raining"] = new TagNodeByte(_raining ?? 0);
		}
		if (((int?)_thundering).HasValue)
		{
			tagNodeCompound["thundering"] = new TagNodeByte(_thundering ?? 0);
		}
		if (_rainTime.HasValue)
		{
			tagNodeCompound["rainTime"] = new TagNodeInt(_rainTime ?? 0);
		}
		if (_thunderTime.HasValue)
		{
			tagNodeCompound["thunderTime"] = new TagNodeInt(_thunderTime ?? 0);
		}
		if (_gameType.HasValue)
		{
			tagNodeCompound["GameType"] = new TagNodeInt(_gameType ?? 0);
		}
		if (((int?)_mapFeatures).HasValue)
		{
			tagNodeCompound["MapFeatures"] = new TagNodeByte(_mapFeatures ?? 0);
		}
		if (((int?)_hardcore).HasValue)
		{
			tagNodeCompound["hardcore"] = new TagNodeByte(_hardcore ?? 0);
		}
		if (_generatorOptions != null)
		{
			tagNodeCompound["generatorOptions"] = new TagNodeString(_generatorOptions);
		}
		if (_generatorVersion.HasValue)
		{
			tagNodeCompound["generatorVersion"] = new TagNodeInt(_generatorVersion ?? 0);
		}
		if (((int?)_allowCommands).HasValue)
		{
			tagNodeCompound["allowCommands"] = new TagNodeByte(_allowCommands ?? 0);
		}
		if (((int?)_initialized).HasValue)
		{
			tagNodeCompound["initialized"] = new TagNodeByte(_initialized ?? 0);
		}
		if (_DayTime.HasValue)
		{
			tagNodeCompound["DayTime"] = new TagNodeLong(_DayTime ?? 0);
		}
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		tagNodeCompound2["commandBlockOutput"] = new TagNodeString(_gameRules.CommandBlockOutput ? "true" : "false");
		tagNodeCompound2["doFireTick"] = new TagNodeString(_gameRules.DoFireTick ? "true" : "false");
		tagNodeCompound2["doMobLoot"] = new TagNodeString(_gameRules.DoMobLoot ? "true" : "false");
		tagNodeCompound2["doMobSpawning"] = new TagNodeString(_gameRules.DoMobSpawning ? "true" : "false");
		tagNodeCompound2["doTileDrops"] = new TagNodeString(_gameRules.DoTileDrops ? "true" : "false");
		tagNodeCompound2["keepInventory"] = new TagNodeString(_gameRules.KeepInventory ? "true" : "false");
		tagNodeCompound2["mobGriefing"] = new TagNodeString(_gameRules.MobGriefing ? "true" : "false");
		tagNodeCompound["GameRules"] = tagNodeCompound2;
		if (_source != null)
		{
			tagNodeCompound.MergeFrom(_source);
		}
		TagNodeCompound tagNodeCompound3 = new TagNodeCompound();
		tagNodeCompound3.Add("Data", tagNodeCompound);
		return tagNodeCompound3;
	}

	public virtual bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, _schema).Verify();
	}

	public virtual Level Copy()
	{
		return new Level(this);
	}
}
