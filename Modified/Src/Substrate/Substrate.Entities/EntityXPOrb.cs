using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityXPOrb : TypedEntity
{
	public static readonly SchemaNodeCompound XPOrbSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Health", TagType.TAG_SHORT),
		new SchemaNodeScaler("Age", TagType.TAG_SHORT),
		new SchemaNodeScaler("Value", TagType.TAG_SHORT)
	});

	private short _health;

	private short _age;

	private short _value;

	public static string TypeId => "XPOrb";

	public int Health
	{
		get
		{
			return _health;
		}
		set
		{
			_health = (short)(value & 0xFF);
		}
	}

	public int Age
	{
		get
		{
			return _age;
		}
		set
		{
			_age = (short)value;
		}
	}

	public int Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = (short)value;
		}
	}

	protected EntityXPOrb(string id)
		: base(id)
	{
	}

	public EntityXPOrb()
		: this(TypeId)
	{
	}

	public EntityXPOrb(TypedEntity e)
		: base(e)
	{
		if (e is EntityXPOrb entityXPOrb)
		{
			_health = entityXPOrb._health;
			_age = entityXPOrb._age;
			_value = entityXPOrb._value;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_health = tagNodeCompound["Health"].ToTagShort();
		_age = tagNodeCompound["Age"].ToTagShort();
		_value = tagNodeCompound["Value"].ToTagShort();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Health"] = new TagNodeShort(_health);
		tagNodeCompound["Age"] = new TagNodeShort(_age);
		tagNodeCompound["Value"] = new TagNodeShort(_value);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, XPOrbSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityXPOrb(this);
	}
}
