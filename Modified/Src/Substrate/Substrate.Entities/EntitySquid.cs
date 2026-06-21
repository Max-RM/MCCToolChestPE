using Substrate.Nbt;

namespace Substrate.Entities;

public class EntitySquid : EntityMob
{
	public static readonly SchemaNodeCompound SquidSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Squid";

	protected EntitySquid(string id)
		: base(id)
	{
	}

	public EntitySquid()
		: this(TypeId)
	{
	}

	public EntitySquid(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SquidSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntitySquid(this);
	}
}
