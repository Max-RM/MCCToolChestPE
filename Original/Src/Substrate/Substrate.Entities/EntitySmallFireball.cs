using Substrate.Nbt;

namespace Substrate.Entities;

public class EntitySmallFireball : EntityFireball
{
	public static readonly SchemaNodeCompound SmallFireballSchema = EntityFireball.FireballSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "SmallFireball";

	protected EntitySmallFireball(string id)
		: base(id)
	{
	}

	public EntitySmallFireball()
		: this(TypeId)
	{
	}

	public EntitySmallFireball(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SmallFireballSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntitySmallFireball(this);
	}
}
