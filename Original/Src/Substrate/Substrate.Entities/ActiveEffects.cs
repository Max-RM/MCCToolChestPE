using Substrate.Core;

namespace Substrate.Entities;

public class ActiveEffects : ICopyable<ActiveEffects>
{
	private byte _id;

	private byte _amplifier;

	private int _duration;

	public int Id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = (byte)value;
		}
	}

	public int Amplifier
	{
		get
		{
			return _amplifier;
		}
		set
		{
			_amplifier = (byte)value;
		}
	}

	public int Duration
	{
		get
		{
			return _duration;
		}
		set
		{
			_duration = value;
		}
	}

	public bool IsValid
	{
		get
		{
			if (_id != 0 && _amplifier != 0)
			{
				return _duration != 0;
			}
			return false;
		}
	}

	public ActiveEffects Copy()
	{
		ActiveEffects activeEffects = new ActiveEffects();
		activeEffects._amplifier = _amplifier;
		activeEffects._duration = _duration;
		activeEffects._id = _id;
		return activeEffects;
	}
}
