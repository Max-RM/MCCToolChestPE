using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityGhast : EntityMob
{
	public static readonly SchemaNodeCompound GhastSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Ghast";

	protected EntityGhast(string id)
		: base(id)
	{
	}

	public EntityGhast()
		: this(TypeId)
	{
	}

	public EntityGhast(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, GhastSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityGhast(this);
	}
}
