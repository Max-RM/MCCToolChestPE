using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityEnchantmentTable : TileEntity
{
	public static readonly SchemaNodeCompound EnchantTableSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public static string TypeId => "EnchantTable";

	protected TileEntityEnchantmentTable(string id)
		: base(id)
	{
	}

	public TileEntityEnchantmentTable()
		: this(TypeId)
	{
	}

	public TileEntityEnchantmentTable(TileEntity te)
		: base(te)
	{
	}

	public override TileEntity Copy()
	{
		return new TileEntityEnchantmentTable(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		return this;
	}

	public override TagNode BuildTree()
	{
		return base.BuildTree() as TagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, EnchantTableSchema).Verify();
	}
}
