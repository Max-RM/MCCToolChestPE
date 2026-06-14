using Substrate.Nbt;

namespace Substrate.Entities;

public class EntitySkeleton : EntityMob
{
	public static readonly SchemaNodeCompound SkeletonSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Skeleton";

	protected EntitySkeleton(string id)
		: base(id)
	{
	}

	public EntitySkeleton()
		: this(TypeId)
	{
	}

	public EntitySkeleton(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SkeletonSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntitySkeleton(this);
	}
}
