using Substrate.Nbt;

namespace Substrate.Entities;

public class EntitySnowball : EntityThrowable
{
	public static readonly SchemaNodeCompound SnowballSchema = EntityThrowable.ThrowableSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public static string TypeId => "Snowball";

	protected EntitySnowball(string id)
		: base(id)
	{
	}

	public EntitySnowball()
		: this(TypeId)
	{
	}

	public EntitySnowball(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SnowballSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntitySnowball(this);
	}
}
