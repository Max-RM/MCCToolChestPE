using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityRecordPlayer : TileEntity
{
	public static readonly SchemaNodeCompound RecordPlayerSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Record", TagType.TAG_INT, SchemaOptions.OPTIONAL)
	});

	private int? _record = null;

	public static string TypeId => "RecordPlayer";

	public int? Record
	{
		get
		{
			return _record;
		}
		set
		{
			_record = value;
		}
	}

	protected TileEntityRecordPlayer(string id)
		: base(id)
	{
	}

	public TileEntityRecordPlayer()
		: this(TypeId)
	{
	}

	public TileEntityRecordPlayer(TileEntity te)
		: base(te)
	{
		if (te is TileEntityRecordPlayer tileEntityRecordPlayer)
		{
			_record = tileEntityRecordPlayer._record;
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityRecordPlayer(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		if (tagNodeCompound.ContainsKey("Record"))
		{
			_record = tagNodeCompound["Record"].ToTagInt();
		}
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		if (_record.HasValue)
		{
			tagNodeCompound["Record"] = new TagNodeInt(_record.Value);
		}
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, RecordPlayerSchema).Verify();
	}
}
