using Substrate.Nbt;

namespace Substrate.Entities;

public class EntitySilverfish : EntityMob
{
	public static readonly SchemaNodeCompound SilverfishSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Silverfish";

	protected EntitySilverfish(string id)
		: base(id)
	{
	}

	public EntitySilverfish()
		: this(TypeId)
	{
	}

	public EntitySilverfish(TypedEntity e)
		: base(e)
	{
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		return this;
	}

	public override TagNode BuildTree()
	{
		return base.BuildTree() as TagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SilverfishSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntitySilverfish(this);
	}
}
