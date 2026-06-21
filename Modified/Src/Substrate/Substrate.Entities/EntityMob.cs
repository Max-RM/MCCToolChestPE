using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityMob : TypedEntity
{
	public static readonly SchemaNodeCompound MobSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("AttackTime", TagType.TAG_SHORT),
		new SchemaNodeScaler("DeathTime", TagType.TAG_SHORT),
		new SchemaNodeScaler("Health", TagType.TAG_SHORT),
		new SchemaNodeScaler("HurtTime", TagType.TAG_SHORT),
		new SchemaNodeCompound("ActiveEffects", SchemaOptions.OPTIONAL)
		{
			new SchemaNodeScaler("Id", TagType.TAG_BYTE),
			new SchemaNodeScaler("Amplifier", TagType.TAG_BYTE),
			new SchemaNodeScaler("Duration", TagType.TAG_INT)
		}
	});

	private short _attackTime;

	private short _deathTime;

	private short _health;

	private short _hurtTime;

	private ActiveEffects _activeEffects;

	public static string TypeId => "Mob";

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

	public ActiveEffects ActiveEffects
	{
		get
		{
			return _activeEffects;
		}
		set
		{
			_activeEffects = value;
		}
	}

	protected EntityMob(string id)
		: base(id)
	{
		_activeEffects = new ActiveEffects();
	}

	public EntityMob()
		: this(TypeId)
	{
	}

	public EntityMob(TypedEntity e)
		: base(e)
	{
		if (e is EntityMob entityMob)
		{
			_attackTime = entityMob._attackTime;
			_deathTime = entityMob._deathTime;
			_health = entityMob._health;
			_hurtTime = entityMob._hurtTime;
			_activeEffects = entityMob._activeEffects.Copy();
		}
		else
		{
			_activeEffects = new ActiveEffects();
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_attackTime = tagNodeCompound["AttackTime"].ToTagShort();
		_deathTime = tagNodeCompound["DeathTime"].ToTagShort();
		_health = tagNodeCompound["Health"].ToTagShort();
		_hurtTime = tagNodeCompound["HurtTime"].ToTagShort();
		if (tagNodeCompound.ContainsKey("ActiveEffects"))
		{
			TagNodeCompound tagNodeCompound2 = tagNodeCompound["ActiveEffects"].ToTagCompound();
			_activeEffects = new ActiveEffects();
			_activeEffects.Id = tagNodeCompound2["Id"].ToTagByte();
			_activeEffects.Amplifier = tagNodeCompound2["Amplifier"].ToTagByte();
			_activeEffects.Duration = tagNodeCompound2["Duration"].ToTagInt();
		}
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["AttackTime"] = new TagNodeShort(_attackTime);
		tagNodeCompound["DeathTime"] = new TagNodeShort(_deathTime);
		tagNodeCompound["Health"] = new TagNodeShort(_health);
		tagNodeCompound["HurtTime"] = new TagNodeShort(_hurtTime);
		if (_activeEffects != null && _activeEffects.IsValid)
		{
			TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
			tagNodeCompound2["Id"] = new TagNodeByte((byte)_activeEffects.Id);
			tagNodeCompound2["Amplifier"] = new TagNodeByte((byte)_activeEffects.Amplifier);
			tagNodeCompound2["Duration"] = new TagNodeInt(_activeEffects.Duration);
			tagNodeCompound["ActiveEffects"] = tagNodeCompound2;
		}
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MobSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityMob(this);
	}
}
