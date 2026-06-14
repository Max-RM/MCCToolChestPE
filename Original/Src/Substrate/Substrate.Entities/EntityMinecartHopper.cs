using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityMinecartHopper : EntityMinecart, IItemContainer
{
	public static readonly SchemaNodeCompound MinecartHopperSchema = EntityMinecart.MinecartSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeList("Items", TagType.TAG_COMPOUND, ItemCollection.Schema),
		new SchemaNodeScaler("TransferCooldown", TagType.TAG_INT),
		new SchemaNodeScaler("Enabled", TagType.TAG_BYTE)
	});

	private static int _CAPACITY = 4;

	private ItemCollection _items;

	private int _transferCooldown;

	private bool _enabled;

	public new static string TypeId => "MinecartHopper";

	public ItemCollection Items => _items;

	public int TransferCooldown
	{
		get
		{
			return _transferCooldown;
		}
		set
		{
			_transferCooldown = value;
		}
	}

	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			_enabled = value;
		}
	}

	protected EntityMinecartHopper(string id)
		: base(id)
	{
		_items = new ItemCollection(_CAPACITY);
	}

	public EntityMinecartHopper()
	{
		_items = new ItemCollection(_CAPACITY);
	}

	public EntityMinecartHopper(TypedEntity e)
		: base(e)
	{
		if (e is EntityMinecartHopper entityMinecartHopper)
		{
			_items = entityMinecartHopper._items.Copy();
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
		_transferCooldown = tagNodeCompound["TransferCooldown"].ToTagInt();
		_enabled = (int)tagNodeCompound["Enabled"].ToTagByte() == 1;
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Items"] = _items.BuildTree();
		tagNodeCompound["id"] = new TagNodeString(TypeId);
		tagNodeCompound["TransferCooldown"] = new TagNodeInt(TransferCooldown);
		tagNodeCompound["Enabled"] = new TagNodeByte((byte)(Enabled ? 1u : 0u));
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MinecartHopperSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityMinecartHopper(this);
	}
}
