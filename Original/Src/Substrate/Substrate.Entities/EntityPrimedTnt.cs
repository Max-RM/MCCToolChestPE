using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityPrimedTnt : TypedEntity
{
	public static readonly SchemaNodeCompound PrimedTntSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Fuse", TagType.TAG_BYTE)
	});

	private byte _fuse;

	public static string TypeId => "PrimedTnt";

	public int Fuse
	{
		get
		{
			return _fuse;
		}
		set
		{
			_fuse = (byte)value;
		}
	}

	protected EntityPrimedTnt(string id)
		: base(id)
	{
	}

	public EntityPrimedTnt()
		: this(TypeId)
	{
	}

	public EntityPrimedTnt(TypedEntity e)
		: base(e)
	{
		if (e is EntityPrimedTnt entityPrimedTnt)
		{
			_fuse = entityPrimedTnt._fuse;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_fuse = tagNodeCompound["Fuse"].ToTagByte();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Fuse"] = new TagNodeByte(_fuse);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, PrimedTntSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityPrimedTnt(this);
	}
}
