using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityFurnace : TileEntity, IItemContainer
{
	private const int _CAPACITY = 3;

	public static readonly SchemaNodeCompound FurnaceSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("BurnTime", TagType.TAG_SHORT),
		new SchemaNodeScaler("CookTime", TagType.TAG_SHORT),
		new SchemaNodeList("Items", TagType.TAG_COMPOUND, ItemCollection.Schema)
	});

	private short _burnTime;

	private short _cookTime;

	private ItemCollection _items;

	public static string TypeId => "Furnace";

	public int BurnTime
	{
		get
		{
			return _burnTime;
		}
		set
		{
			_burnTime = (short)value;
		}
	}

	public int CookTime
	{
		get
		{
			return _cookTime;
		}
		set
		{
			_cookTime = (short)value;
		}
	}

	public ItemCollection Items => _items;

	protected TileEntityFurnace(string id)
		: base(id)
	{
		_items = new ItemCollection(3);
	}

	public TileEntityFurnace()
		: this(TypeId)
	{
	}

	public TileEntityFurnace(TileEntity te)
		: base(te)
	{
		if (te is TileEntityFurnace tileEntityFurnace)
		{
			_cookTime = tileEntityFurnace._cookTime;
			_burnTime = tileEntityFurnace._burnTime;
			_items = tileEntityFurnace._items.Copy();
		}
		else
		{
			_items = new ItemCollection(3);
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityFurnace(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_burnTime = tagNodeCompound["BurnTime"].ToTagShort();
		_cookTime = tagNodeCompound["CookTime"].ToTagShort();
		TagNodeList tree2 = tagNodeCompound["Items"].ToTagList();
		_items = new ItemCollection(3).LoadTree(tree2);
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["BurnTime"] = new TagNodeShort(_burnTime);
		tagNodeCompound["CookTime"] = new TagNodeShort(_cookTime);
		tagNodeCompound["Items"] = _items.BuildTree();
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, FurnaceSchema).Verify();
	}
}
