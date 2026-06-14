using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityFallingSand : TypedEntity
{
	public static readonly SchemaNodeCompound FallingSandSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Tile", TagType.TAG_BYTE)
	});

	private byte _tile;

	public static string TypeId => "FallingSand";

	public int Tile
	{
		get
		{
			return _tile;
		}
		set
		{
			_tile = (byte)value;
		}
	}

	protected EntityFallingSand(string id)
		: base(id)
	{
	}

	public EntityFallingSand()
		: this(TypeId)
	{
	}

	public EntityFallingSand(TypedEntity e)
		: base(e)
	{
		if (e is EntityFallingSand entityFallingSand)
		{
			_tile = entityFallingSand._tile;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_tile = tagNodeCompound["Tile"].ToTagByte();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Tile"] = new TagNodeByte(_tile);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, FallingSandSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityFallingSand(this);
	}
}
