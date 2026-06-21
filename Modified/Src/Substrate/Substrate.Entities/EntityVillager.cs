using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityVillager : EntityMob
{
	public static readonly SchemaNodeCompound VillagerSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Profession", TagType.TAG_INT)
	});

	private int _profession;

	public new static string TypeId => "Villager";

	public VillagerProfession Profession
	{
		get
		{
			return (VillagerProfession)_profession;
		}
		set
		{
			_profession = (int)value;
		}
	}

	protected EntityVillager(string id)
		: base(id)
	{
	}

	public EntityVillager()
		: this(TypeId)
	{
	}

	public EntityVillager(TypedEntity e)
		: base(e)
	{
		if (e is EntityVillager entityVillager)
		{
			_profession = entityVillager._profession;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_profession = tagNodeCompound["Profession"].ToTagInt();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Profession"] = new TagNodeInt(_profession);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, VillagerSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityVillager(this);
	}
}
