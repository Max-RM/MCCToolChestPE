using Substrate.Core;

namespace Substrate;

public class GameRules : ICopyable<GameRules>
{
	private bool _commandBlockOutput = true;

	private bool _doFireTick = true;

	private bool _doMobLoot = true;

	private bool _doMobSpawning = true;

	private bool _doTileDrops = true;

	private bool _keepInventory;

	private bool _mobGriefing = true;

	public bool CommandBlockOutput
	{
		get
		{
			return _commandBlockOutput;
		}
		set
		{
			_commandBlockOutput = value;
		}
	}

	public bool DoFireTick
	{
		get
		{
			return _doFireTick;
		}
		set
		{
			_doFireTick = value;
		}
	}

	public bool DoMobLoot
	{
		get
		{
			return _doMobLoot;
		}
		set
		{
			_doMobLoot = value;
		}
	}

	public bool DoMobSpawning
	{
		get
		{
			return _doMobSpawning;
		}
		set
		{
			_doMobSpawning = value;
		}
	}

	public bool DoTileDrops
	{
		get
		{
			return _doTileDrops;
		}
		set
		{
			_doTileDrops = value;
		}
	}

	public bool KeepInventory
	{
		get
		{
			return _keepInventory;
		}
		set
		{
			_keepInventory = value;
		}
	}

	public bool MobGriefing
	{
		get
		{
			return _mobGriefing;
		}
		set
		{
			_mobGriefing = value;
		}
	}

	public GameRules Copy()
	{
		GameRules gameRules = new GameRules();
		gameRules._commandBlockOutput = _commandBlockOutput;
		gameRules._doFireTick = _doFireTick;
		gameRules._doMobLoot = _doMobLoot;
		gameRules._doMobSpawning = _doMobSpawning;
		gameRules._doTileDrops = _doTileDrops;
		gameRules._keepInventory = _keepInventory;
		gameRules._mobGriefing = _mobGriefing;
		return gameRules;
	}
}
