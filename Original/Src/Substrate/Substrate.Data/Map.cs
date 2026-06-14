using System;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.Data;

public class Map : INbtObject<Map>, ICopyable<Map>
{
	private static SchemaNodeCompound _schema = new SchemaNodeCompound
	{
		new SchemaNodeCompound("data")
		{
			new SchemaNodeScaler("scale", TagType.TAG_BYTE),
			new SchemaNodeScaler("dimension", TagType.TAG_BYTE),
			new SchemaNodeScaler("height", TagType.TAG_SHORT),
			new SchemaNodeScaler("width", TagType.TAG_SHORT),
			new SchemaNodeScaler("xCenter", TagType.TAG_INT),
			new SchemaNodeScaler("zCenter", TagType.TAG_INT),
			new SchemaNodeArray("colors")
		}
	};

	private TagNodeCompound _source;

	private NbtWorld _world;

	private int _id;

	private byte _scale;

	private byte _dimension;

	private short _height;

	private short _width;

	private int _x;

	private int _z;

	private byte[] _colors;

	public int Id
	{
		get
		{
			return _id;
		}
		set
		{
			if (_id < 0 || _id >= 65536)
			{
				throw new ArgumentOutOfRangeException("value", value, "Map Ids must be in the range [0, 65535].");
			}
			_id = value;
		}
	}

	public int Scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_scale = (byte)value;
		}
	}

	public int Dimension
	{
		get
		{
			return _dimension;
		}
		set
		{
			_dimension = (byte)value;
		}
	}

	public int Height
	{
		get
		{
			return _height;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("value", "Height must be a positive number");
			}
			if (_height != value)
			{
				_height = (short)value;
				_colors = new byte[_width * _height];
			}
		}
	}

	public int Width
	{
		get
		{
			return _width;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("value", "Width must be a positive number");
			}
			if (_width != value)
			{
				_width = (short)value;
				_colors = new byte[_width * _height];
			}
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

	public byte[] Colors
	{
		get
		{
			return _colors;
		}
		set
		{
			_colors = value;
		}
	}

	public byte this[int x, int z]
	{
		get
		{
			if (x < 0 || x >= _width || z < 0 || z >= _height)
			{
				throw new IndexOutOfRangeException();
			}
			return _colors[x + _width * z];
		}
		set
		{
			if (x < 0 || x >= _width || z < 0 || z >= _height)
			{
				throw new IndexOutOfRangeException();
			}
			_colors[x + _width * z] = value;
		}
	}

	public Map()
	{
		_scale = 3;
		_dimension = 0;
		_height = 128;
		_width = 128;
		_colors = new byte[_width * _height];
	}

	protected Map(Map p)
	{
		_world = p._world;
		_id = p._id;
		_scale = p._scale;
		_dimension = p._dimension;
		_height = p._height;
		_width = p._width;
		_x = p._x;
		_z = p._z;
		_colors = new byte[_width * _height];
		if (p._colors != null)
		{
			p._colors.CopyTo(_colors, 0);
		}
	}

	public bool Save()
	{
		if (_world == null)
		{
			return false;
		}
		try
		{
			string path = Path.Combine(_world.Path, _world.DataDirectory);
			NBTFile nBTFile = new NBTFile(Path.Combine(path, "map_" + _id + ".dat"));
			Stream dataOutputStream = nBTFile.GetDataOutputStream();
			if (dataOutputStream == null)
			{
				NbtIOException ex = new NbtIOException("Failed to initialize compressed NBT stream for output");
				ex.Data["Map"] = this;
				throw ex;
			}
			new NbtTree(BuildTree() as TagNodeCompound).WriteTo(dataOutputStream);
			dataOutputStream.Close();
			return true;
		}
		catch (Exception innerException)
		{
			Exception ex2 = new Exception("Could not save map file.", innerException);
			ex2.Data["Map"] = this;
			throw ex2;
		}
	}

	public virtual Map LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound))
		{
			return null;
		}
		TagNodeCompound tagNodeCompound2 = tagNodeCompound;
		if (tagNodeCompound2.ContainsKey("data"))
		{
			tagNodeCompound2 = tagNodeCompound2["data"] as TagNodeCompound;
		}
		if (tagNodeCompound2.ContainsKey("data"))
		{
			tagNodeCompound2 = tagNodeCompound2["data"] as TagNodeCompound;
		}
		_scale = tagNodeCompound2["scale"].ToTagByte();
		_dimension = tagNodeCompound2["dimension"].ToTagByte();
		_height = tagNodeCompound2["height"].ToTagShort();
		_width = tagNodeCompound2["width"].ToTagShort();
		_x = tagNodeCompound2["xCenter"].ToTagInt();
		_z = tagNodeCompound2["zCenter"].ToTagInt();
		_colors = tagNodeCompound2["colors"].ToTagByteArray();
		_source = tagNodeCompound2.Copy() as TagNodeCompound;
		return this;
	}

	public virtual Map LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		Map map = LoadTree(tree);
		if (map != null && map._colors.Length != map._width * map._height)
		{
			throw new Exception("Unexpected length of colors byte array in Map");
		}
		return map;
	}

	public virtual TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound["scale"] = new TagNodeByte(_scale);
		tagNodeCompound["dimension"] = new TagNodeByte(_dimension);
		tagNodeCompound["height"] = new TagNodeShort(_height);
		tagNodeCompound["width"] = new TagNodeShort(_width);
		tagNodeCompound["xCenter"] = new TagNodeInt(_x);
		tagNodeCompound["zCenter"] = new TagNodeInt(_z);
		tagNodeCompound["colors"] = new TagNodeByteArray(_colors);
		if (_source != null)
		{
			tagNodeCompound.MergeFrom(_source);
		}
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		tagNodeCompound2.Add("data", tagNodeCompound);
		return tagNodeCompound2;
	}

	public virtual bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, _schema).Verify();
	}

	public virtual Map Copy()
	{
		return new Map(this);
	}
}
