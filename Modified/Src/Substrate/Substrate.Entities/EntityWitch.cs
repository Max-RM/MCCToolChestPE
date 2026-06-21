using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityWitch : EntityMob
{
	public static readonly SchemaNodeCompound WitchSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Witch";

	protected EntityWitch(string id)
		: base(id)
	{
	}

	public EntityWitch()
		: this(TypeId)
	{
	}

	public EntityWitch(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, WitchSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityWitch(this);
	}
}
