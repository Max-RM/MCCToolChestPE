using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityBoat : TypedEntity
{
	public static readonly SchemaNodeCompound BoatSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public static string TypeId => "Boat";

	protected EntityBoat(string id)
		: base(id)
	{
	}

	public EntityBoat()
		: this(TypeId)
	{
	}

	public EntityBoat(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, BoatSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityBoat(this);
	}
}
