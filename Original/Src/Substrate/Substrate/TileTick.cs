using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class TileTick : INbtObject<TileTick>, ICopyable<TileTick>
{
	private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("i", TagType.TAG_INT),
		new SchemaNodeScaler("t", TagType.TAG_INT),
		new SchemaNodeScaler("x", TagType.TAG_INT),
		new SchemaNodeScaler("y", TagType.TAG_INT),
		new SchemaNodeScaler("z", TagType.TAG_INT)
	};

	private int _blockId;

	private int _ticks;

	private int _x;

	private int _y;

	private int _z;

	private TagNodeCompound _source;

	public int ID
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

	public int Ticks
	{
		get
		{
			return _ticks;
		}
		set
		{
			_ticks = value;
		}
	}

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

	public static SchemaNodeCompound Schema => _schema;

	public TileTick()
	{
	}

	public TileTick(TileTick tt)
	{
		_blockId = tt._blockId;
		_ticks = tt._ticks;
		_x = tt._x;
		_y = tt._y;
		_z = tt._z;
		if (tt._source != null)
		{
			_source = tt._source.Copy() as TagNodeCompound;
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

	public static TileTick FromTree(TagNode tree)
	{
		return new TileTick().LoadTree(tree);
	}

	public static TileTick FromTreeSafe(TagNode tree)
	{
		return new TileTick().LoadTreeSafe(tree);
	}

	public TileTick LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound))
		{
			return null;
		}
		_blockId = tagNodeCompound["i"].ToTagInt();
		_ticks = tagNodeCompound["t"].ToTagInt();
		_x = tagNodeCompound["x"].ToTagInt();
		_y = tagNodeCompound["y"].ToTagInt();
		_z = tagNodeCompound["z"].ToTagInt();
		_source = tagNodeCompound.Copy() as TagNodeCompound;
		return this;
	}

	public TileTick LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound["i"] = new TagNodeInt(_blockId);
		tagNodeCompound["t"] = new TagNodeInt(_ticks);
		tagNodeCompound["x"] = new TagNodeInt(_x);
		tagNodeCompound["y"] = new TagNodeInt(_y);
		tagNodeCompound["z"] = new TagNodeInt(_z);
		if (_source != null)
		{
			tagNodeCompound.MergeFrom(_source);
		}
		return tagNodeCompound;
	}

	public bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, _schema).Verify();
	}

	public virtual TileTick Copy()
	{
		return new TileTick(this);
	}
}
