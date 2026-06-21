using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityMusic : TileEntity
{
	public static readonly SchemaNodeCompound MusicSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("note", TagType.TAG_BYTE)
	});

	private byte _note;

	public static string TypeId => "Music";

	public int Note
	{
		get
		{
			return _note;
		}
		set
		{
			_note = (byte)value;
		}
	}

	protected TileEntityMusic(string id)
		: base(id)
	{
	}

	public TileEntityMusic()
		: this(TypeId)
	{
	}

	public TileEntityMusic(TileEntity te)
		: base(te)
	{
		if (te is TileEntityMusic tileEntityMusic)
		{
			_note = tileEntityMusic._note;
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityMusic(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_note = tagNodeCompound["note"].ToTagByte();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["note"] = new TagNodeByte(_note);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MusicSchema).Verify();
	}
}
