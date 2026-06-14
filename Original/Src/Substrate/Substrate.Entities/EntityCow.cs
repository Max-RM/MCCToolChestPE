using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityCow : EntityMob
{
	public static readonly SchemaNodeCompound CowSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Cow";

	protected EntityCow(string id)
		: base(id)
	{
	}

	public EntityCow()
		: this(TypeId)
	{
	}

	public EntityCow(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, CowSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityCow(this);
	}
}
