using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class Player : Entity, INbtObject<Player>, ICopyable<Player>, IItemContainer
{
	private const int _CAPACITY = 105;

	private const int _ENDER_CAPACITY = 27;

	private static readonly SchemaNodeCompound _schema = Entity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("AttackTime", TagType.TAG_SHORT),
		new SchemaNodeScaler("DeathTime", TagType.TAG_SHORT),
		new SchemaNodeScaler("Health", TagType.TAG_SHORT),
		new SchemaNodeScaler("HurtTime", TagType.TAG_SHORT),
		new SchemaNodeScaler("Dimension", TagType.TAG_INT),
		new SchemaNodeList("Inventory", TagType.TAG_COMPOUND, ItemCollection.Schema),
		new SchemaNodeScaler("World", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("Sleeping", TagType.TAG_BYTE, SchemaOptions.CREATE_ON_MISSING),
		new SchemaNodeScaler("SleepTimer", TagType.TAG_SHORT, SchemaOptions.CREATE_ON_MISSING),
		new SchemaNodeScaler("SpawnX", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("SpawnY", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("SpawnZ", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("foodLevel", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("foodTickTimer", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("foodExhaustionLevel", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("foodSaturationLevel", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("XpP", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("XpLevel", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("XpTotal", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("Score", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeScaler("playerGameType", TagType.TAG_INT, SchemaOptions.OPTIONAL),
		new SchemaNodeCompound("abilities", new SchemaNodeCompound("")
		{
			new SchemaNodeScaler("flying", TagType.TAG_BYTE),
			new SchemaNodeScaler("instabuild", TagType.TAG_BYTE),
			new SchemaNodeScaler("mayfly", TagType.TAG_BYTE),
			new SchemaNodeScaler("invulnerable", TagType.TAG_BYTE),
			new SchemaNodeScaler("mayBuild", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("walkSpeed", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("flySpeed", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL)
		}, SchemaOptions.OPTIONAL)
	});

	private short _attackTime;

	private short _deathTime;

	private short _health;

	private short _hurtTime;

	private int _dimension;

	private byte _sleeping;

	private short _sleepTimer;

	private int? _spawnX;

	private int? _spawnY;

	private int? _spawnZ;

	private int? _foodLevel;

	private int? _foodTickTimer;

	private float? _foodExhaustion;

	private float? _foodSaturation;

	private float? _xpP;

	private int? _xpLevel;

	private int? _xpTotal;

	private int? _score;

	private string _world;

	private string _name;

	private PlayerAbilities _abilities;

	private PlayerGameType? _gameType;

	private ItemCollection _inventory;

	private ItemCollection _enderItems;

	public int AttackTime
	{
		get
		{
			return _attackTime;
		}
		set
		{
			_attackTime = (short)value;
		}
	}

	public int DeathTime
	{
		get
		{
			return _deathTime;
		}
		set
		{
			_deathTime = (short)value;
		}
	}

	public int Health
	{
		get
		{
			return _health;
		}
		set
		{
			_health = (short)value;
		}
	}

	public int HurtTime
	{
		get
		{
			return _hurtTime;
		}
		set
		{
			_hurtTime = (short)value;
		}
	}

	public int Dimension
	{
		get
		{
			return _dimension;
		}
		set
		{
			_dimension = value;
		}
	}

	public PlayerGameType GameType
	{
		get
		{
			return _gameType ?? PlayerGameType.Survival;
		}
		set
		{
			_gameType = value;
		}
	}

	public bool IsSleeping
	{
		get
		{
			return _sleeping == 1;
		}
		set
		{
			_sleeping = (byte)(value ? 1u : 0u);
		}
	}

	public int SleepTimer
	{
		get
		{
			return _sleepTimer;
		}
		set
		{
			_sleepTimer = (short)value;
		}
	}

	public SpawnPoint Spawn
	{
		get
		{
			return new SpawnPoint(_spawnX ?? 0, _spawnY ?? 0, _spawnZ ?? 0);
		}
		set
		{
			_spawnX = value.X;
			_spawnY = value.Y;
			_spawnZ = value.Z;
		}
	}

	public bool HasSpawn
	{
		get
		{
			if (_spawnX.HasValue && _spawnY.HasValue)
			{
				return _spawnZ.HasValue;
			}
			return false;
		}
	}

	public string World
	{
		get
		{
			return _world;
		}
		set
		{
			_world = value;
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public int Score
	{
		get
		{
			return _score ?? 0;
		}
		set
		{
			_score = value;
		}
	}

	public int XPLevel
	{
		get
		{
			return _xpLevel ?? 0;
		}
		set
		{
			_xpLevel = value;
		}
	}

	public int XPTotal
	{
		get
		{
			return _xpTotal ?? 0;
		}
		set
		{
			_xpTotal = value;
		}
	}

	public int HungerLevel
	{
		get
		{
			return _foodLevel ?? 0;
		}
		set
		{
			_foodLevel = value;
		}
	}

	public float HungerSaturationLevel
	{
		get
		{
			return _foodSaturation ?? 0f;
		}
		set
		{
			_foodSaturation = value;
		}
	}

	public float HungerExhaustionLevel
	{
		get
		{
			return _foodExhaustion ?? 0f;
		}
		set
		{
			_foodExhaustion = value;
		}
	}

	public int HungerTimer
	{
		get
		{
			return _foodTickTimer ?? 0;
		}
		set
		{
			_foodTickTimer = value;
		}
	}

	public PlayerAbilities Abilities => _abilities;

	public new static SchemaNodeCompound Schema => _schema;

	public ItemCollection Items => _inventory;

	public ItemCollection EnderItems => _enderItems;

	public Player()
	{
		_inventory = new ItemCollection(105);
		_enderItems = new ItemCollection(27);
		_abilities = new PlayerAbilities();
		_dimension = 0;
		_sleeping = 0;
		_sleepTimer = 0;
		base.Air = 300;
		Health = 20;
		base.Fire = -20;
	}

	protected Player(Player p)
		: base(p)
	{
		_attackTime = p._attackTime;
		_deathTime = p._deathTime;
		_health = p._health;
		_hurtTime = p._hurtTime;
		_dimension = p._dimension;
		_gameType = p._gameType;
		_sleeping = p._sleeping;
		_sleepTimer = p._sleepTimer;
		_spawnX = p._spawnX;
		_spawnY = p._spawnY;
		_spawnZ = p._spawnZ;
		_world = p._world;
		_inventory = p._inventory.Copy();
		_enderItems = p._inventory.Copy();
		_foodLevel = p._foodLevel;
		_foodTickTimer = p._foodTickTimer;
		_foodSaturation = p._foodSaturation;
		_foodExhaustion = p._foodExhaustion;
		_xpP = p._xpP;
		_xpLevel = p._xpLevel;
		_xpTotal = p._xpTotal;
		_abilities = p._abilities.Copy();
	}

	public void ClearSpawn()
	{
		_spawnX = null;
		_spawnY = null;
		_spawnZ = null;
	}

	private bool AbilitiesSet()
	{
		if (!_abilities.Flying && !_abilities.InstantBuild && !_abilities.MayFly)
		{
			return _abilities.Invulnerable;
		}
		return true;
	}

	public new virtual Player LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_attackTime = tagNodeCompound["AttackTime"].ToTagShort();
		_deathTime = tagNodeCompound["DeathTime"].ToTagShort();
		_health = tagNodeCompound["Health"].ToTagShort();
		_hurtTime = tagNodeCompound["HurtTime"].ToTagShort();
		_dimension = tagNodeCompound["Dimension"].ToTagInt();
		_sleeping = tagNodeCompound["Sleeping"].ToTagByte();
		_sleepTimer = tagNodeCompound["SleepTimer"].ToTagShort();
		if (tagNodeCompound.ContainsKey("SpawnX"))
		{
			_spawnX = tagNodeCompound["SpawnX"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("SpawnY"))
		{
			_spawnY = tagNodeCompound["SpawnY"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("SpawnZ"))
		{
			_spawnZ = tagNodeCompound["SpawnZ"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("World"))
		{
			_world = tagNodeCompound["World"].ToTagString();
		}
		if (tagNodeCompound.ContainsKey("foodLevel"))
		{
			_foodLevel = tagNodeCompound["foodLevel"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("foodTickTimer"))
		{
			_foodTickTimer = tagNodeCompound["foodTickTimer"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("foodExhaustionLevel"))
		{
			_foodExhaustion = tagNodeCompound["foodExhaustionLevel"].ToTagFloat();
		}
		if (tagNodeCompound.ContainsKey("foodSaturationLevel"))
		{
			_foodSaturation = tagNodeCompound["foodSaturationLevel"].ToTagFloat();
		}
		if (tagNodeCompound.ContainsKey("XpP"))
		{
			_xpP = tagNodeCompound["XpP"].ToTagFloat();
		}
		if (tagNodeCompound.ContainsKey("XpLevel"))
		{
			_xpLevel = tagNodeCompound["XpLevel"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("XpTotal"))
		{
			_xpTotal = tagNodeCompound["XpTotal"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("Score"))
		{
			_score = tagNodeCompound["Score"].ToTagInt();
		}
		if (tagNodeCompound.ContainsKey("abilities"))
		{
			TagNodeCompound tagNodeCompound2 = tagNodeCompound["abilities"].ToTagCompound();
			_abilities = new PlayerAbilities();
			_abilities.Flying = tagNodeCompound2["flying"].ToTagByte().Data == 1;
			_abilities.InstantBuild = tagNodeCompound2["instabuild"].ToTagByte().Data == 1;
			_abilities.MayFly = tagNodeCompound2["mayfly"].ToTagByte().Data == 1;
			_abilities.Invulnerable = tagNodeCompound2["invulnerable"].ToTagByte().Data == 1;
			if (tagNodeCompound2.ContainsKey("mayBuild"))
			{
				_abilities.MayBuild = tagNodeCompound2["mayBuild"].ToTagByte().Data == 1;
			}
			if (tagNodeCompound2.ContainsKey("walkSpeed"))
			{
				_abilities.WalkSpeed = tagNodeCompound2["walkSpeed"].ToTagFloat();
			}
			if (tagNodeCompound2.ContainsKey("flySpeed"))
			{
				_abilities.FlySpeed = tagNodeCompound2["flySpeed"].ToTagFloat();
			}
		}
		if (tagNodeCompound.ContainsKey("PlayerGameType"))
		{
			_gameType = (PlayerGameType)tagNodeCompound["PlayerGameType"].ToTagInt().Data;
		}
		_inventory.LoadTree(tagNodeCompound["Inventory"].ToTagList());
		if (tagNodeCompound.ContainsKey("EnderItems") && tagNodeCompound["EnderItems"].ToTagList().Count > 0)
		{
			_enderItems.LoadTree(tagNodeCompound["EnderItems"].ToTagList());
		}
		return this;
	}

	public new virtual Player LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public new virtual TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["AttackTime"] = new TagNodeShort(_attackTime);
		tagNodeCompound["DeathTime"] = new TagNodeShort(_deathTime);
		tagNodeCompound["Health"] = new TagNodeShort(_health);
		tagNodeCompound["HurtTime"] = new TagNodeShort(_hurtTime);
		tagNodeCompound["Dimension"] = new TagNodeInt(_dimension);
		tagNodeCompound["Sleeping"] = new TagNodeByte(_sleeping);
		tagNodeCompound["SleepTimer"] = new TagNodeShort(_sleepTimer);
		if (_spawnX.HasValue && _spawnY.HasValue && _spawnZ.HasValue)
		{
			tagNodeCompound["SpawnX"] = new TagNodeInt(_spawnX ?? 0);
			tagNodeCompound["SpawnY"] = new TagNodeInt(_spawnY ?? 0);
			tagNodeCompound["SpawnZ"] = new TagNodeInt(_spawnZ ?? 0);
		}
		else
		{
			tagNodeCompound.Remove("SpawnX");
			tagNodeCompound.Remove("SpawnY");
			tagNodeCompound.Remove("SpawnZ");
		}
		if (_world != null)
		{
			tagNodeCompound["World"] = new TagNodeString(_world);
		}
		if (_foodLevel.HasValue)
		{
			tagNodeCompound["foodLevel"] = new TagNodeInt(_foodLevel ?? 0);
		}
		if (_foodTickTimer.HasValue)
		{
			tagNodeCompound["foodTickTimer"] = new TagNodeInt(_foodTickTimer ?? 0);
		}
		if (_foodExhaustion.HasValue)
		{
			tagNodeCompound["foodExhaustionLevel"] = new TagNodeFloat(_foodExhaustion ?? 0f);
		}
		if (_foodSaturation.HasValue)
		{
			tagNodeCompound["foodSaturation"] = new TagNodeFloat(_foodSaturation ?? 0f);
		}
		if (_xpP.HasValue)
		{
			tagNodeCompound["XpP"] = new TagNodeFloat(_xpP ?? 0f);
		}
		if (_xpLevel.HasValue)
		{
			tagNodeCompound["XpLevel"] = new TagNodeInt(_xpLevel ?? 0);
		}
		if (_xpTotal.HasValue)
		{
			tagNodeCompound["XpTotal"] = new TagNodeInt(_xpTotal ?? 0);
		}
		if (_score.HasValue)
		{
			tagNodeCompound["Score"] = new TagNodeInt(_score ?? 0);
		}
		if (_gameType.HasValue)
		{
			tagNodeCompound["playerGameType"] = new TagNodeInt((int)(_gameType ?? PlayerGameType.Survival));
		}
		if (AbilitiesSet())
		{
			TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
			tagNodeCompound2["flying"] = new TagNodeByte((byte)(_abilities.Flying ? 1 : 0));
			tagNodeCompound2["instabuild"] = new TagNodeByte((byte)(_abilities.InstantBuild ? 1 : 0));
			tagNodeCompound2["mayfly"] = new TagNodeByte((byte)(_abilities.MayFly ? 1 : 0));
			tagNodeCompound2["invulnerable"] = new TagNodeByte((byte)(_abilities.Invulnerable ? 1 : 0));
			tagNodeCompound2["mayBuild"] = new TagNodeByte((byte)(_abilities.MayBuild ? 1 : 0));
			tagNodeCompound2["walkSpeed"] = new TagNodeFloat(_abilities.WalkSpeed);
			tagNodeCompound2["flySpeed"] = new TagNodeFloat(_abilities.FlySpeed);
			tagNodeCompound["abilities"] = tagNodeCompound2;
		}
		tagNodeCompound["Inventory"] = _inventory.BuildTree();
		tagNodeCompound["EnderItems"] = _enderItems.BuildTree();
		return tagNodeCompound;
	}

	public new virtual bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, _schema).Verify();
	}

	public new virtual Player Copy()
	{
		return new Player(this);
	}
}
