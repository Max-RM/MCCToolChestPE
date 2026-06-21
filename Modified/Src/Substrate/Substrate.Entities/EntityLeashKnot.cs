using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityLeashKnot : TypedEntity
{
	public static readonly SchemaNodeCompound LeashKnotSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public static string TypeId => "LeashKnot";

	protected EntityLeashKnot(string id)
		: base(id)
	{
	}

	public EntityLeashKnot()
		: this(TypeId)
	{
	}

	public EntityLeashKnot(TypedEntity e)
		: base(e)
	{
		EntityLeashKnot entityLeashKnot = e as EntityLeashKnot;
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
		return new NbtVerifier(tree, LeashKnotSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityLeashKnot(this);
	}
}
