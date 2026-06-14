using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityItemFrame : TypedEntity
{
	public enum DirectionType
	{
		EAST,
		NORTH,
		WEST,
		SOUTH
	}

	public static readonly SchemaNodeCompound ItemFrameSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Facing", TagType.TAG_BYTE),
		new SchemaNodeScaler("TileX", TagType.TAG_INT),
		new SchemaNodeScaler("TileY", TagType.TAG_INT),
		new SchemaNodeScaler("TileZ", TagType.TAG_INT),
		new SchemaNodeScaler("Item", TagType.TAG_COMPOUND),
		new SchemaNodeScaler("ItemDropChance", TagType.TAG_FLOAT),
		new SchemaNodeScaler("ItemRotation", TagType.TAG_BYTE)
	});

	private DirectionType _facing;

	private int _xTile;

	private int _yTile;

	private int _zTile;

	private float _itemDropChance;

	private byte _itemRotation;

	public static string TypeId => "ItemFrame";

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

	public float ItemDropChance
	{
		get
		{
			return _itemDropChance;
		}
		set
		{
			_itemDropChance = value;
		}
	}

	public byte ItemRotation
	{
		get
		{
			return _itemRotation;
		}
		set
		{
			_itemRotation = value;
		}
	}

	protected EntityItemFrame(string id)
		: base(id)
	{
	}

	public EntityItemFrame()
		: this(TypeId)
	{
	}

	public EntityItemFrame(TypedEntity e)
		: base(e)
	{
		if (e is EntityItemFrame entityItemFrame)
		{
			_xTile = entityItemFrame._xTile;
			_yTile = entityItemFrame._yTile;
			_zTile = entityItemFrame._zTile;
			_facing = entityItemFrame._facing;
			_itemDropChance = entityItemFrame._itemDropChance;
			_itemRotation = entityItemFrame._itemRotation;
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
		_xTile = tagNodeCompound["TileX"].ToTagInt();
		_yTile = tagNodeCompound["TileY"].ToTagInt();
		_zTile = tagNodeCompound["TileZ"].ToTagInt();
		_itemDropChance = tagNodeCompound["ItemDropChance"].ToTagFloat();
		_itemRotation = tagNodeCompound["ItemRotation"].ToTagByte();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Facing"] = new TagNodeByte((byte)_facing);
		tagNodeCompound["TileX"] = new TagNodeInt(_xTile);
		tagNodeCompound["TileY"] = new TagNodeInt(_yTile);
		tagNodeCompound["TileZ"] = new TagNodeInt(_zTile);
		tagNodeCompound["ItemDropChance"] = new TagNodeFloat(_itemDropChance);
		tagNodeCompound["ItemRotation"] = new TagNodeByte(_itemRotation);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, ItemFrameSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityItemFrame(this);
	}
}
