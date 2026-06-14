using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityMinecart : TypedEntity
{
	public enum CartType
	{
		EMPTY,
		CHEST,
		FURNACE
	}

	public static readonly SchemaNodeCompound MinecartSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Type", TagType.TAG_INT)
	});

	private CartType _type;

	public static string TypeId => "Minecart";

	public CartType Type => _type;

	protected EntityMinecart(string id)
		: base(id)
	{
	}

	public EntityMinecart()
		: this(TypeId)
	{
	}

	public EntityMinecart(TypedEntity e)
		: base(e)
	{
		if (e is EntityMinecart entityMinecart)
		{
			_type = entityMinecart._type;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_type = (CartType)tagNodeCompound["Type"].ToTagInt().Data;
		return _type switch
		{
			CartType.EMPTY => this, 
			CartType.CHEST => new EntityMinecartChest().LoadTreeSafe(tree), 
			CartType.FURNACE => new EntityMinecartFurnace().LoadTreeSafe(tree), 
			_ => this, 
		};
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Type"] = new TagNodeInt((int)_type);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MinecartSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityMinecart(this);
	}
}
