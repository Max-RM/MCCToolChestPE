using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityPiston : TileEntity
{
	public static readonly SchemaNodeCompound PistonSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("blockId", TagType.TAG_INT),
		new SchemaNodeScaler("blockData", TagType.TAG_INT),
		new SchemaNodeScaler("facing", TagType.TAG_INT),
		new SchemaNodeScaler("progress", TagType.TAG_FLOAT),
		new SchemaNodeScaler("extending", TagType.TAG_BYTE)
	});

	private int? _record = null;

	private byte _extending;

	private int _blockId;

	private int _blockData;

	private int _facing;

	private float _progress;

	public static string TypeId => "Piston";

	public bool Extending
	{
		get
		{
			return _extending != 0;
		}
		set
		{
			_extending = (byte)(value ? 1u : 0u);
		}
	}

	public int BlockId
	{
		get
		{
			return _blockId;
		}
		set
		{
			_blockId = value;
		}
	}

	public int BlockData
	{
		get
		{
			return _blockData;
		}
		set
		{
			_blockData = value;
		}
	}

	public int Facing
	{
		get
		{
			return _facing;
		}
		set
		{
			_facing = value;
		}
	}

	public float Progress
	{
		get
		{
			return _progress;
		}
		set
		{
			_progress = value;
		}
	}

	protected TileEntityPiston(string id)
		: base(id)
	{
	}

	public TileEntityPiston()
		: this(TypeId)
	{
	}

	public TileEntityPiston(TileEntity te)
		: base(te)
	{
		if (te is TileEntityPiston tileEntityPiston)
		{
			_blockId = tileEntityPiston._blockId;
			_blockData = tileEntityPiston._blockData;
			_facing = tileEntityPiston._facing;
			_progress = tileEntityPiston._progress;
			_extending = tileEntityPiston._extending;
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityPiston(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_blockId = tagNodeCompound["blockId"].ToTagInt();
		_blockData = tagNodeCompound["blockData"].ToTagInt();
		_facing = tagNodeCompound["facing"].ToTagInt();
		_progress = tagNodeCompound["progress"].ToTagFloat();
		_extending = tagNodeCompound["extending"].ToTagByte();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		if (_record.HasValue)
		{
			tagNodeCompound["blockId"] = new TagNodeInt(_blockId);
			tagNodeCompound["blockData"] = new TagNodeInt(_blockData);
			tagNodeCompound["facing"] = new TagNodeInt(_facing);
			tagNodeCompound["progress"] = new TagNodeFloat(_progress);
			tagNodeCompound["extending"] = new TagNodeByte(_extending);
		}
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, PistonSchema).Verify();
	}
}
