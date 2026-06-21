using Substrate.Core;

namespace Substrate;

public class PlayerAbilities : ICopyable<PlayerAbilities>
{
	private bool _flying;

	private bool _instabuild;

	private bool _mayfly;

	private bool _invulnerable;

	private bool _maybuild = true;

	private float _walkSpeed = 0.1f;

	private float _flySpeed = 0.05f;

	public bool Flying
	{
		get
		{
			return _flying;
		}
		set
		{
			_flying = value;
		}
	}

	public bool InstantBuild
	{
		get
		{
			return _instabuild;
		}
		set
		{
			_instabuild = value;
		}
	}

	public bool MayFly
	{
		get
		{
			return _mayfly;
		}
		set
		{
			_mayfly = value;
		}
	}

	public bool Invulnerable
	{
		get
		{
			return _invulnerable;
		}
		set
		{
			_invulnerable = value;
		}
	}

	public bool MayBuild
	{
		get
		{
			return _maybuild;
		}
		set
		{
			_maybuild = value;
		}
	}

	public float FlySpeed
	{
		get
		{
			return _flySpeed;
		}
		set
		{
			_flySpeed = value;
		}
	}

	public float WalkSpeed
	{
		get
		{
			return _walkSpeed;
		}
		set
		{
			_walkSpeed = value;
		}
	}

	public PlayerAbilities Copy()
	{
		PlayerAbilities playerAbilities = new PlayerAbilities();
		playerAbilities._flying = _flying;
		playerAbilities._instabuild = _instabuild;
		playerAbilities._mayfly = _mayfly;
		playerAbilities._invulnerable = _invulnerable;
		playerAbilities._maybuild = _maybuild;
		playerAbilities._walkSpeed = _walkSpeed;
		playerAbilities._flySpeed = _flySpeed;
		return playerAbilities;
	}
}
