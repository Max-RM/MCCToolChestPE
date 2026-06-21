using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityMobSpawner : TileEntity
{
	public static readonly SchemaNodeCompound MobSpawnerSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("EntityId", TagType.TAG_STRING),
		new SchemaNodeScaler("Delay", TagType.TAG_SHORT),
		new SchemaNodeScaler("MaxSpawnDelay", TagType.TAG_SHORT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("MinSpawnDelay", TagType.TAG_SHORT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("SpawnCount", TagType.TAG_SHORT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("SpawnRange", TagType.TAG_SHORT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("MaxNearbyEnemies", TagType.TAG_SHORT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("RequiredPlayerRange", TagType.TAG_SHORT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("MaxExperience", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("RemainingExperience", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("ExperienceRegenTick", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("ExperienceRegenRate", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("ExperienceRegenAmount", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeCompound("SpawnData", SchemaOptions.OPTIONAL)
	});

	private short _delay;

	private string _entityID;

	private short? _maxDelay;

	private short? _minDelay;

	private short? _spawnCount;

	private short? _spawnRange;

	private short? _maxNearbyEnemies;

	private short? _requiredPlayerRange;

	private int? _maxExperience;

	private int? _remainingExperience;

	private int? _experienceRegenTick;

	private int? _experienceRegenRate;

	private int? _experienceRegenAmount;

	private TagNodeCompound _spawnData;

	public static string TypeId => "MobSpawner";

	public int Delay
	{
		get
		{
			return _delay;
		}
		set
		{
			_delay = (short)value;
		}
	}

	public TagNodeCompound SpawnData
	{
		get
		{
			return _spawnData;
		}
		set
		{
			_spawnData = value;
		}
	}

	public string EntityID
	{
		get
		{
			return _entityID;
		}
		set
		{
			_entityID = value;
		}
	}

	public short MaxSpawnDelay
	{
		get
		{
			return _maxDelay ?? 0;
		}
		set
		{
			_maxDelay = value;
		}
	}

	public short MinSpawnDelay
	{
		get
		{
			return _minDelay ?? 0;
		}
		set
		{
			_minDelay = value;
		}
	}

	public short SpawnCount
	{
		get
		{
			return _spawnCount ?? 0;
		}
		set
		{
			_spawnCount = value;
		}
	}

	public short SpawnRange
	{
		get
		{
			return _spawnRange ?? 0;
		}
		set
		{
			_spawnRange = value;
		}
	}

	public short MaxNearbyEnemies
	{
		get
		{
			return _maxNearbyEnemies ?? 0;
		}
		set
		{
			_maxNearbyEnemies = value;
		}
	}

	public short RequiredPlayerRange
	{
		get
		{
			return _requiredPlayerRange ?? 0;
		}
		set
		{
			_requiredPlayerRange = value;
		}
	}

	public int MaxExperience
	{
		get
		{
			return _maxExperience ?? 0;
		}
		set
		{
			_maxExperience = value;
		}
	}

	public int RemainingExperience
	{
		get
		{
			return _remainingExperience ?? 0;
		}
		set
		{
			_remainingExperience = value;
		}
	}

	public int ExperienceRegenTick
	{
		get
		{
			return _experienceRegenTick ?? 0;
		}
		set
		{
			_experienceRegenTick = value;
		}
	}

	public int ExperienceRegenRate
	{
		get
		{
			return _experienceRegenRate ?? 0;
		}
		set
		{
			_experienceRegenRate = value;
		}
	}

	public int ExperienceRegenAmount
	{
		get
		{
			return _experienceRegenAmount ?? 0;
		}
		set
		{
			_experienceRegenAmount = value;
		}
	}

	protected TileEntityMobSpawner(string id)
		: base(id)
	{
	}

	public TileEntityMobSpawner()
		: this(TypeId)
	{
	}

	public TileEntityMobSpawner(TileEntity te)
		: base(te)
	{
		if (te is TileEntityMobSpawner tileEntityMobSpawner)
		{
			_delay = tileEntityMobSpawner._delay;
			_entityID = tileEntityMobSpawner._entityID;
			_maxDelay = tileEntityMobSpawner._maxDelay;
			_minDelay = tileEntityMobSpawner._minDelay;
			_spawnCount = tileEntityMobSpawner._spawnCount;
			_spawnRange = tileEntityMobSpawner._spawnRange;
			_maxNearbyEnemies = tileEntityMobSpawner._maxNearbyEnemies;
			_requiredPlayerRange = tileEntityMobSpawner._requiredPlayerRange;
			_maxExperience = tileEntityMobSpawner._maxExperience;
			_remainingExperience = tileEntityMobSpawner._remainingExperience;
			_experienceRegenTick = tileEntityMobSpawner._experienceRegenTick;
			_experienceRegenRate = tileEntityMobSpawner._experienceRegenRate;
			_experienceRegenAmount = tileEntityMobSpawner._experienceRegenAmount;
			if (tileEntityMobSpawner._spawnData != null)
			{
				_spawnData = tileEntityMobSpawner._spawnData.Copy() as TagNodeCompound;
			}
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityMobSpawner(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_delay = tagNodeCompound["Delay"].ToTagShort();
		_entityID = tagNodeCompound["EntityId"].ToTagString();
		if (tagNodeCompound.ContainsKey("MaxSpawnDelay"))
		{
			_maxDelay = tagNodeCompound["MaxSpawnDelay"].ToTagShort();
		}
		if (tagNodeCompound.ContainsKey("MinSpawnDelay"))
		{
			_minDelay = tagNodeCompound["MinSpawnDelay"].ToTagShort();
		}
		if (tagNodeCompound.ContainsKey("SpawnCount"))
		{
			_spawnCount = tagNodeCompound["SpawnCount"].ToTagShort();
		}
		if (tagNodeCompound.ContainsKey("SpawnRange"))
		{
			_spawnRange = tagNodeCompound["SpawnRange"].ToTagShort();
		}
		if (tagNodeCompound.ContainsKey("MaxNearbyEnemies"))
		{
			_maxNearbyEnemies = tagNodeCompound["MaxNearbyEnemies"].ToTagShort();
		}
		if (tagNodeCompound.ContainsKey("RequiredPlayerRange"))
		{
			_requiredPlayerRange = tagNodeCompound["RequiredPlayerRange"].ToTagShort();
		}
		if (tagNodeCompound.ContainsKey("MaxExperience"))
		{
			_maxExperience = tagNodeCompound["MaxExperience"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("RemainingExperience"))
		{
			_remainingExperience = tagNodeCompound["RemainingExperience"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("ExperienceRegenTick"))
		{
			_experienceRegenTick = tagNodeCompound["ExperienceRegenTick"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("ExperienceRegenRate"))
		{
			_experienceRegenRate = tagNodeCompound["ExperienceRegenRate"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("ExperienceRegenAmount"))
		{
			_experienceRegenRate = tagNodeCompound["ExperienceRegenAmount"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("SpawnData"))
		{
			_spawnData = tagNodeCompound["SpawnData"].ToTagCompound();
		}
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["EntityId"] = new TagNodeString(_entityID);
		tagNodeCompound["Delay"] = new TagNodeShort(_delay);
		if (((int?)_maxDelay).HasValue)
		{
			tagNodeCompound["MaxSpawnDelay"] = new TagNodeShort(_maxDelay ?? 0);
		}
		if (((int?)_minDelay).HasValue)
		{
			tagNodeCompound["MinSpawnDelay"] = new TagNodeShort(_minDelay ?? 0);
		}
		if (((int?)_spawnCount).HasValue)
		{
			tagNodeCompound["SpawnCount"] = new TagNodeShort(_spawnCount ?? 0);
		}
		if (((int?)_spawnRange).HasValue)
		{
			tagNodeCompound["SpawnRange"] = new TagNodeShort(_spawnRange ?? 0);
		}
		if (((int?)_maxNearbyEnemies).HasValue)
		{
			tagNodeCompound["MaxNearbyEnemies"] = new TagNodeShort(_maxNearbyEnemies ?? 0);
		}
		if (((int?)_requiredPlayerRange).HasValue)
		{
			tagNodeCompound["RequiredPlayerRange"] = new TagNodeShort(_requiredPlayerRange ?? 0);
		}
		if (_maxExperience.HasValue)
		{
			tagNodeCompound["MaxExperience"] = new TagNodeInt(_maxExperience ?? 0);
		}
		if (_remainingExperience.HasValue)
		{
			tagNodeCompound["RemainingExperience"] = new TagNodeInt(_remainingExperience ?? 0);
		}
		if (_experienceRegenTick.HasValue)
		{
			tagNodeCompound["ExperienceRegenTick"] = new TagNodeInt(_experienceRegenTick ?? 0);
		}
		if (_experienceRegenRate.HasValue)
		{
			tagNodeCompound["ExperienceRegenRate"] = new TagNodeInt(_experienceRegenRate ?? 0);
		}
		if (_experienceRegenAmount.HasValue)
		{
			tagNodeCompound["ExperienceRegenAmount"] = new TagNodeInt(_experienceRegenAmount ?? 0);
		}
		if (_spawnData != null && _spawnData.Count > 0)
		{
			tagNodeCompound["SpawnData"] = _spawnData;
		}
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MobSpawnerSchema).Verify();
	}
}
