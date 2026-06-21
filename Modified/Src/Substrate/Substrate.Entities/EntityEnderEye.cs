using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityEnderEye : TypedEntity
{
	public static readonly SchemaNodeCompound EnderEyeSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public static string TypeId => "EyeOfEnderSignal";

	protected EntityEnderEye(string id)
		: base(id)
	{
	}

	public EntityEnderEye()
		: this(TypeId)
	{
	}

	public EntityEnderEye(TypedEntity e)
		: base(e)
	{
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, EnderEyeSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityEnderEye(this);
	}
}
