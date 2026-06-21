using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class TileEntity : INbtObject<TileEntity>, ICopyable<TileEntity>
{
	private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("id", TagType.TAG_STRING),
		new SchemaNodeScaler("x", TagType.TAG_INT),
		new SchemaNodeScaler("y", TagType.TAG_INT),
		new SchemaNodeScaler("z", TagType.TAG_INT)
	};

	private TagNodeCompound _source;

	private string _id;

	private int _x;

	private int _y;

	private int _z;

	public string ID => _id;

	public int X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public int Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public int Z
	{
		get
		{
			return _z;
		}
		set
		{
			_z = value;
		}
	}

	public TagNodeCompound Source => _source;

	public static SchemaNodeCompound Schema => _schema;

	protected TileEntity()
	{
		_source = new TagNodeCompound();
	}

	public TileEntity(string id)
	{
		_id = id;
		_source = new TagNodeCompound();
	}

	public TileEntity(TileEntity te)
	{
		_id = te._id;
		_x = te._x;
		_y = te._y;
		_z = te._z;
		if (te._source != null)
		{
			_source = te._source.Copy() as TagNodeCompound;
		}
	}

	public bool LocatedAt(int x, int y, int z)
	{
		if (_x == x && _y == y)
		{
			return _z == z;
		}
		return false;
	}

	public virtual void MoveBy(int diffX, int diffY, int diffZ)
	{
		_x += diffX;
		_y += diffY;
		_z += diffZ;
	}

	public virtual TileEntity Copy()
	{
		return new TileEntity(this);
	}

	public static TileEntity FromTree(TagNode tree)
	{
		return new TileEntity().LoadTree(tree);
	}

	public static TileEntity FromTreeSafe(TagNode tree)
	{
		return new TileEntity().LoadTreeSafe(tree);
	}

	public virtual TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound))
		{
			return null;
		}
		_id = tagNodeCompound["id"].ToTagString();
		_x = tagNodeCompound["x"].ToTagInt();
		_y = tagNodeCompound["y"].ToTagInt();
		_z = tagNodeCompound["z"].ToTagInt();
		_source = tagNodeCompound.Copy() as TagNodeCompound;
		return this;
	}

	public virtual TileEntity LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public virtual TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound["id"] = new TagNodeString(_id);
		tagNodeCompound["x"] = new TagNodeInt(_x);
		tagNodeCompound["y"] = new TagNodeInt(_y);
		tagNodeCompound["z"] = new TagNodeInt(_z);
		if (_source != null)
		{
			tagNodeCompound.MergeFrom(_source);
		}
		return tagNodeCompound;
	}

	public virtual bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, _schema).Verify();
	}
}
