using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityAnimal : EntityMob
{
	public static readonly SchemaNodeCompound AnimalSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("Age", TagType.TAG_INT, SchemaOptions.CREATE_ON_MISSING),
		new SchemaNodeScaler("InLove", TagType.TAG_INT, SchemaOptions.CREATE_ON_MISSING)
	});

	private int _age;

	private int _inLove;

	public int Age
	{
		get
		{
			return _age;
		}
		set
		{
			_age = value;
		}
	}

	public int InLove
	{
		get
		{
			return _inLove;
		}
		set
		{
			_inLove = value;
		}
	}

	protected EntityAnimal(string id)
		: base(id)
	{
	}

	public EntityAnimal()
		: this(EntityMob.TypeId)
	{
	}

	public EntityAnimal(TypedEntity e)
		: base(e)
	{
		if (e is EntityAnimal entityAnimal)
		{
			_age = entityAnimal._age;
			_inLove = entityAnimal._inLove;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_age = tagNodeCompound["Age"].ToTagInt();
		_inLove = tagNodeCompound["InLove"].ToTagInt();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Age"] = new TagNodeInt(_age);
		tagNodeCompound["InLove"] = new TagNodeInt(_inLove);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, AnimalSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityAnimal(this);
	}
}
