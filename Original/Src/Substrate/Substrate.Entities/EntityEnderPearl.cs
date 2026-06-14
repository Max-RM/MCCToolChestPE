using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityEnderPearl : EntityThrowable
{
	public static readonly SchemaNodeCompound EnderPearlSchema = EntityThrowable.ThrowableSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public static string TypeId => "ThrownEnderpearl";

	protected EntityEnderPearl(string id)
		: base(id)
	{
	}

	public EntityEnderPearl()
		: this(TypeId)
	{
	}

	public EntityEnderPearl(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, EnderPearlSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityEnderPearl(this);
	}
}
