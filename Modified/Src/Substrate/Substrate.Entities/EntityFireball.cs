using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityFireball : TypedEntity
{
	public static readonly SchemaNodeCompound FireballSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("xTile", TagType.TAG_SHORT),
		new SchemaNodeScaler("yTile", TagType.TAG_SHORT),
		new SchemaNodeScaler("zTile", TagType.TAG_SHORT),
		new SchemaNodeScaler("inTile", TagType.TAG_BYTE),
		new SchemaNodeScaler("inGround", TagType.TAG_BYTE)
	});

	private short _xTile;

	private short _yTile;

	private short _zTile;

	private byte _inTile;

	private byte _inGround;

	public static string TypeId => "Fireball";

	public int XTile
	{
		get
		{
			return _xTile;
		}
		set
		{
			_xTile = (short)value;
		}
	}

	public int YTile
	{
		get
		{
			return _yTile;
		}
		set
		{
			_yTile = (short)value;
		}
	}

	public int ZTile
	{
		get
		{
			return _zTile;
		}
		set
		{
			_zTile = (short)value;
		}
	}

	public int InTile
	{
		get
		{
			return _inTile;
		}
		set
		{
			_inTile = (byte)value;
		}
	}

	public bool IsInGround
	{
		get
		{
			return _inGround == 1;
		}
		set
		{
			_inGround = (byte)(value ? 1u : 0u);
		}
	}

	protected EntityFireball(string id)
		: base(id)
	{
	}

	public EntityFireball()
		: this(TypeId)
	{
	}

	public EntityFireball(TypedEntity e)
		: base(e)
	{
		if (e is EntityFireball entityFireball)
		{
			_xTile = entityFireball._xTile;
			_yTile = entityFireball._yTile;
			_zTile = entityFireball._zTile;
			_inTile = entityFireball._inTile;
			_inGround = entityFireball._inGround;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_xTile = tagNodeCompound["xTile"].ToTagShort();
		_yTile = tagNodeCompound["yTile"].ToTagShort();
		_zTile = tagNodeCompound["zTile"].ToTagShort();
		_inTile = tagNodeCompound["inTile"].ToTagByte();
		_inGround = tagNodeCompound["inGround"].ToTagByte();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["xTile"] = new TagNodeShort(_xTile);
		tagNodeCompound["yTile"] = new TagNodeShort(_yTile);
		tagNodeCompound["zTile"] = new TagNodeShort(_zTile);
		tagNodeCompound["inTile"] = new TagNodeByte(_inTile);
		tagNodeCompound["inGround"] = new TagNodeByte(_inGround);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, FireballSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityFireball(this);
	}
}
