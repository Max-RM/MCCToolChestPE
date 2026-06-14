using Substrate.Nbt;

namespace Substrate.Entities;

public class EntitySpider : EntityMob
{
	public static readonly SchemaNodeCompound SpiderSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Spider";

	protected EntitySpider(string id)
		: base(id)
	{
	}

	public EntitySpider()
		: this(TypeId)
	{
	}

	public EntitySpider(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SpiderSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntitySpider(this);
	}
}
