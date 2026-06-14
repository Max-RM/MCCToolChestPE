using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityPainting : TypedEntity
{
	public enum DirectionType
	{
		EAST,
		NORTH,
		WEST,
		SOUTH
	}

	public static readonly SchemaNodeCompound PaintingSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Facing", TagType.TAG_BYTE),
		new SchemaNodeScaler("TileX", TagType.TAG_INT),
		new SchemaNodeScaler("TileY", TagType.TAG_INT),
		new SchemaNodeScaler("TileZ", TagType.TAG_INT),
		new SchemaNodeScaler("Motive", TagType.TAG_STRING)
	});

	private DirectionType _facing;

	private string _motive = "";

	private int _xTile;

	private int _yTile;

	private int _zTile;

	public static string TypeId => "Painting";

	public DirectionType Facing
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

	public string Motive
	{
		get
		{
			return _motive;
		}
		set
		{
			_motive = value;
		}
	}

	public int TileX
	{
		get
		{
			return _xTile;
		}
		set
		{
			_xTile = value;
		}
	}

	public int TileY
	{
		get
		{
			return _yTile;
		}
		set
		{
			_yTile = value;
		}
	}

	public int TileZ
	{
		get
		{
			return _zTile;
		}
		set
		{
			_zTile = value;
		}
	}

	protected EntityPainting(string id)
		: base(id)
	{
	}

	public EntityPainting()
		: this(TypeId)
	{
	}

	public EntityPainting(TypedEntity e)
		: base(e)
	{
		if (e is EntityPainting entityPainting)
		{
			_xTile = entityPainting._xTile;
			_yTile = entityPainting._yTile;
			_zTile = entityPainting._zTile;
			_facing = entityPainting._facing;
			_motive = entityPainting._motive;
		}
	}

	public override void MoveBy(int diffX, int diffY, int diffZ)
	{
		base.MoveBy(diffX, diffY, diffZ);
		_xTile += diffX;
		_yTile += diffY;
		_zTile += diffZ;
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_facing = (DirectionType)tagNodeCompound["Facing"].ToTagByte().Data;
		_motive = tagNodeCompound["Motive"].ToTagString();
		_xTile = tagNodeCompound["TileX"].ToTagInt();
		_yTile = tagNodeCompound["TileY"].ToTagInt();
		_zTile = tagNodeCompound["TileZ"].ToTagInt();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Facing"] = new TagNodeByte((byte)_facing);
		tagNodeCompound["Motive"] = new TagNodeString(_motive);
		tagNodeCompound["TileX"] = new TagNodeInt(_xTile);
		tagNodeCompound["TileY"] = new TagNodeInt(_yTile);
		tagNodeCompound["TileZ"] = new TagNodeInt(_zTile);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, PaintingSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityPainting(this);
	}
}
