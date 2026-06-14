using Substrate.Nbt;

namespace Substrate.Entities;

public class EntitySlime : EntityMob
{
	public static readonly SchemaNodeCompound SlimeSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Size", TagType.TAG_INT)
	});

	private int _size;

	public new static string TypeId => "Slime";

	public int Size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
		}
	}

	protected EntitySlime(string id)
		: base(id)
	{
	}

	public EntitySlime()
		: this(TypeId)
	{
	}

	public EntitySlime(TypedEntity e)
		: base(e)
	{
		if (e is EntitySlime entitySlime)
		{
			_size = entitySlime._size;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_size = tagNodeCompound["Size"].ToTagInt();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Size"] = new TagNodeInt(_size);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SlimeSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntitySlime(this);
	}
}
