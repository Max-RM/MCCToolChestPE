using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityGiant : EntityMob
{
	public static readonly SchemaNodeCompound GiantSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Giant";

	protected EntityGiant(string id)
		: base(id)
	{
	}

	public EntityGiant()
		: this(TypeId)
	{
	}

	public EntityGiant(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, GiantSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityGiant(this);
	}
}
