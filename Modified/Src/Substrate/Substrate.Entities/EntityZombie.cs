using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityZombie : EntityMob
{
	public static readonly SchemaNodeCompound ZombieSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Zombie";

	protected EntityZombie(string id)
		: base(id)
	{
	}

	public EntityZombie()
		: this(TypeId)
	{
	}

	public EntityZombie(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, ZombieSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityZombie(this);
	}
}
