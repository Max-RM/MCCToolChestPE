using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityMinecartChest : EntityMinecart, IItemContainer
{
	public static readonly SchemaNodeCompound MinecartChestSchema = EntityMinecart.MinecartSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeList("Items", TagType.TAG_COMPOUND, ItemCollection.Schema)
	});

	private static int _CAPACITY = 27;

	private ItemCollection _items;

	public new static string TypeId => "MinecartChest";

	public ItemCollection Items => _items;

	protected EntityMinecartChest(string id)
		: base(id)
	{
		_items = new ItemCollection(_CAPACITY);
	}

	public EntityMinecartChest()
	{
		_items = new ItemCollection(_CAPACITY);
	}

	public EntityMinecartChest(TypedEntity e)
		: base(e)
	{
		if (e is EntityMinecartChest entityMinecartChest)
		{
			_items = entityMinecartChest._items.Copy();
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		TagNodeList tree2 = tagNodeCompound["Items"].ToTagList();
		_items = _items.LoadTree(tree2);
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Items"] = _items.BuildTree();
		tagNodeCompound["id"] = new TagNodeString(TypeId);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MinecartChestSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityMinecartChest(this);
	}
}
