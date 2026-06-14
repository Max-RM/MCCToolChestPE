using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityMonster : EntityMob
{
	public static readonly SchemaNodeCompound MonsterSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Monster";

	protected EntityMonster(string id)
		: base(id)
	{
	}

	public EntityMonster()
		: this(TypeId)
	{
	}

	public EntityMonster(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MonsterSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityMonster(this);
	}
}
