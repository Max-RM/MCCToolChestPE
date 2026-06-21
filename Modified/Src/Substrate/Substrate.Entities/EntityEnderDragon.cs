using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityEnderDragon : EntityMob
{
	public static readonly SchemaNodeCompound EnderDragonSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "EnderDragon";

	protected EntityEnderDragon(string id)
		: base(id)
	{
	}

	public EntityEnderDragon()
		: this(TypeId)
	{
	}

	public EntityEnderDragon(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, EnderDragonSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityEnderDragon(this);
	}
}
