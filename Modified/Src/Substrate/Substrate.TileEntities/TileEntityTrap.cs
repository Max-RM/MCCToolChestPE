using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityTrap : TileEntity, IItemContainer
{
	private const int _CAPACITY = 8;

	public static readonly SchemaNodeCompound TrapSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeList("Items", TagType.TAG_COMPOUND, ItemCollection.Schema)
	});

	private ItemCollection _items;

	public static string TypeId => "Trap";

	public ItemCollection Items => _items;

	protected TileEntityTrap(string id)
		: base(id)
	{
		_items = new ItemCollection(8);
	}

	public TileEntityTrap()
		: this(TypeId)
	{
	}

	public TileEntityTrap(TileEntity te)
		: base(te)
	{
		if (te is TileEntityTrap tileEntityTrap)
		{
			_items = tileEntityTrap._items.Copy();
		}
		else
		{
			_items = new ItemCollection(8);
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityTrap(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		TagNodeList tree2 = tagNodeCompound["Items"].ToTagList();
		_items = new ItemCollection(8).LoadTree(tree2);
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Items"] = _items.BuildTree();
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, TrapSchema).Verify();
	}
}
