using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityPigZombie : EntityMob
{
	public static readonly SchemaNodeCompound PigZombieSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Anger", TagType.TAG_SHORT)
	});

	private short _anger;

	public new static string TypeId => "PigZombie";

	public int Anger
	{
		get
		{
			return _anger;
		}
		set
		{
			_anger = (short)value;
		}
	}

	protected EntityPigZombie(string id)
		: base(id)
	{
	}

	public EntityPigZombie()
		: this(TypeId)
	{
	}

	public EntityPigZombie(TypedEntity e)
		: base(e)
	{
		if (e is EntityPigZombie entityPigZombie)
		{
			_anger = entityPigZombie._anger;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_anger = tagNodeCompound["Anger"].ToTagShort();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Anger"] = new TagNodeShort(_anger);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, PigZombieSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityPigZombie(this);
	}
}
