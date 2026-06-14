using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityCaveSpider : EntitySpider
{
	public static readonly SchemaNodeCompound CaveSpiderSchema = EntitySpider.SpiderSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "CaveSpider";

	protected EntityCaveSpider(string id)
		: base(id)
	{
	}

	public EntityCaveSpider()
		: this(TypeId)
	{
	}

	public EntityCaveSpider(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, CaveSpiderSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityCaveSpider(this);
	}
}
