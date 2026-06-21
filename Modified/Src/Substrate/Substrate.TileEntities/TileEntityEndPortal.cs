using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityEndPortal : TileEntity
{
	public static readonly SchemaNodeCompound EndPortalSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId)
	});

	public static string TypeId => "Airportal";

	protected TileEntityEndPortal(string id)
		: base(id)
	{
	}

	public TileEntityEndPortal()
		: this(TypeId)
	{
	}

	public TileEntityEndPortal(TileEntity te)
		: base(te)
	{
	}

	public override TileEntity Copy()
	{
		return new TileEntityEndPortal(this);
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
		return new NbtVerifier(tree, EndPortalSchema).Verify();
	}
}
