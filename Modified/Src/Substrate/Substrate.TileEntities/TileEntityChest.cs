using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityChest : TileEntity, IItemContainer
{
	private const int _CAPACITY = 27;

	public static readonly SchemaNodeCompound ChestSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeList("Items", TagType.TAG_COMPOUND, ItemCollection.Schema)
	});

	private ItemCollection _items;

	public static string TypeId => "Chest";

	public ItemCollection Items => _items;

	protected TileEntityChest(string id)
		: base(id)
	{
		_items = new ItemCollection(27);
	}

	public TileEntityChest()
		: this(TypeId)
	{
	}

	public TileEntityChest(TileEntity te)
		: base(te)
	{
		if (te is TileEntityChest tileEntityChest)
		{
			_items = tileEntityChest._items.Copy();
		}
		else
		{
			_items = new ItemCollection(27);
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityChest(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		TagNodeList tree2 = tagNodeCompound["Items"].ToTagList();
		_items = new ItemCollection(27).LoadTree(tree2);
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
		return new NbtVerifier(tree, ChestSchema).Verify();
	}
}
