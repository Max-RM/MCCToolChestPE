using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityMagmaCube : EntitySlime
{
	public static readonly SchemaNodeCompound MagmaCubeSchema = EntitySlime.SlimeSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "LavaSlime";

	protected EntityMagmaCube(string id)
		: base(id)
	{
	}

	public EntityMagmaCube()
		: this(TypeId)
	{
	}

	public EntityMagmaCube(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MagmaCubeSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityMagmaCube(this);
	}
}
