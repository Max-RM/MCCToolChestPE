using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityBrewingStand : TileEntity, IItemContainer
{
	private const int _CAPACITY = 4;

	public static readonly SchemaNodeCompound BrewingStandSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeList("Items", TagType.TAG_COMPOUND, ItemCollection.Schema),
		new SchemaNodeScaler("BrewTime", TagType.TAG_SHORT)
	});

	private ItemCollection _items;

	private short _brewTime;

	public static string TypeId => "Cauldron";

	public int BrewTime
	{
		get
		{
			return _brewTime;
		}
		set
		{
			_brewTime = (short)value;
		}
	}

	public ItemCollection Items => _items;

	protected TileEntityBrewingStand(string id)
		: base(id)
	{
		_items = new ItemCollection(4);
	}

	public TileEntityBrewingStand()
		: this(TypeId)
	{
	}

	public TileEntityBrewingStand(TileEntity te)
		: base(te)
	{
		if (te is TileEntityBrewingStand tileEntityBrewingStand)
		{
			_items = tileEntityBrewingStand._items.Copy();
			_brewTime = tileEntityBrewingStand._brewTime;
		}
		else
		{
			_items = new ItemCollection(4);
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityBrewingStand(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		TagNodeList tree2 = tagNodeCompound["Items"].ToTagList();
		_items = new ItemCollection(4).LoadTree(tree2);
		_brewTime = tagNodeCompound["BrewTime"].ToTagShort();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Items"] = _items.BuildTree();
		tagNodeCompound["BrewTime"] = new TagNodeShort(_brewTime);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, BrewingStandSchema).Verify();
	}
}
