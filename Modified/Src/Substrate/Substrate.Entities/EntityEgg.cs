using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityEgg : EntityThrowable
{
	public static readonly SchemaNodeCompound EggSchema = EntityThrowable.ThrowableSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public static string TypeId => "Egg";

	protected EntityEgg(string id)
		: base(id)
	{
	}

	public EntityEgg()
		: this(TypeId)
	{
	}

	public EntityEgg(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, EggSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityEgg(this);
	}
}
