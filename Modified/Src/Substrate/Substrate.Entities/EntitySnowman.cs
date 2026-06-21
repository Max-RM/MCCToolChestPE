using Substrate.Nbt;

namespace Substrate.Entities;

public class EntitySnowman : EntityMob
{
	public static readonly SchemaNodeCompound SnowmanSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "SnowMan";

	protected EntitySnowman(string id)
		: base(id)
	{
	}

	public EntitySnowman()
		: this(TypeId)
	{
	}

	public EntitySnowman(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SnowmanSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntitySnowman(this);
	}
}
