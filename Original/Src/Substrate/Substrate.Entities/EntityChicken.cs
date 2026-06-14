using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityChicken : EntityAnimal
{
	public static readonly SchemaNodeCompound ChickenSchema = EntityAnimal.AnimalSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public new static string TypeId => "Chicken";

	protected EntityChicken(string id)
		: base(id)
	{
	}

	public EntityChicken()
		: this(TypeId)
	{
	}

	public EntityChicken(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, ChickenSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityChicken(this);
	}
}
