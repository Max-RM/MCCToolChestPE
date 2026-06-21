using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityOzelot : EntityMob
{
	public static readonly SchemaNodeCompound OzelotSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("CatType", TagType.TAG_INT)
	});

	private int _catType;

	public new static string TypeId => "Ozelot";

	public int CatType
	{
		get
		{
			return _catType;
		}
		set
		{
			_catType = value;
		}
	}

	protected EntityOzelot(string id)
		: base(id)
	{
	}

	public EntityOzelot()
		: this(TypeId)
	{
	}

	public EntityOzelot(TypedEntity e)
		: base(e)
	{
		if (e is EntityOzelot entityOzelot)
		{
			_catType = entityOzelot._catType;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_catType = tagNodeCompound["CatType"].ToTagInt();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["CatType"] = new TagNodeInt(_catType);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, OzelotSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityOzelot(this);
	}
}
