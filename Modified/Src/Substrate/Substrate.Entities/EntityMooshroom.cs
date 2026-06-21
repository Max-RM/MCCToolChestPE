using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityMooshroom : EntityCow
{
	public static readonly SchemaNodeCompound MooshroomSchema = EntityCow.CowSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "MushroomCow";

	protected EntityMooshroom(string id)
		: base(id)
	{
	}

	public EntityMooshroom()
		: this(TypeId)
	{
	}

	public EntityMooshroom(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MooshroomSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityMooshroom(this);
	}
}
