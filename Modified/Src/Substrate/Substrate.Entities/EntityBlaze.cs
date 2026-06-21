using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityBlaze : EntityMob
{
	public static readonly SchemaNodeCompound BlazeSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Blaze";

	protected EntityBlaze(string id)
		: base(id)
	{
	}

	public EntityBlaze()
		: this(TypeId)
	{
	}

	public EntityBlaze(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, BlazeSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityBlaze(this);
	}
}
