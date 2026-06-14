using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityBeacon : TileEntity
{
	public static readonly SchemaNodeCompound BeaconSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Levels", TagType.TAG_INT),
		new SchemaNodeScaler("Primary", TagType.TAG_INT),
		new SchemaNodeScaler("Secondary", TagType.TAG_INT)
	});

	private int _levels;

	private int _primary;

	private int _secondary;

	public static string TypeId => "Beacon";

	public int Levels
	{
		get
		{
			return _levels;
		}
		set
		{
			_levels = value;
		}
	}

	public int Primary
	{
		get
		{
			return _primary;
		}
		set
		{
			_primary = value;
		}
	}

	public int Secondary
	{
		get
		{
			return _secondary;
		}
		set
		{
			_secondary = value;
		}
	}

	protected TileEntityBeacon(string id)
		: base(id)
	{
	}

	public TileEntityBeacon()
		: this(TypeId)
	{
	}

	public TileEntityBeacon(TileEntity te)
		: base(te)
	{
		if (te is TileEntityBeacon tileEntityBeacon)
		{
			_levels = tileEntityBeacon._levels;
			_primary = tileEntityBeacon._primary;
			_secondary = tileEntityBeacon._secondary;
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityBeacon(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_levels = tagNodeCompound["Levels"].ToTagInt();
		_primary = tagNodeCompound["Primary"].ToTagInt();
		_secondary = tagNodeCompound["Secondary"].ToTagInt();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Levels"] = new TagNodeInt(_levels);
		tagNodeCompound["Primary"] = new TagNodeInt(_primary);
		tagNodeCompound["Secondary"] = new TagNodeInt(_secondary);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, BeaconSchema).Verify();
	}
}
