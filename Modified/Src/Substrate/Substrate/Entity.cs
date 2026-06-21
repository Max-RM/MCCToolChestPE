using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class Entity : INbtObject<Entity>, ICopyable<Entity>
{
	private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
	{
		new SchemaNodeList("Pos", TagType.TAG_DOUBLE, 3),
		new SchemaNodeList("Motion", TagType.TAG_DOUBLE, 3),
		new SchemaNodeList("Rotation", TagType.TAG_FLOAT, 2),
		new SchemaNodeScaler("FallDistance", TagType.TAG_FLOAT),
		new SchemaNodeScaler("Fire", TagType.TAG_SHORT),
		new SchemaNodeScaler("Air", TagType.TAG_SHORT),
		new SchemaNodeScaler("OnGround", TagType.TAG_BYTE)
	};

	private TagNodeCompound _source;

	private Vector3 _pos;

	private Vector3 _motion;

	private Orientation _rotation;

	private float _fallDistance;

	private short _fire;

	private short _air;

	private byte _onGround;

	public Vector3 Position
	{
		get
		{
			return _pos;
		}
		set
		{
			_pos = value;
		}
	}

	public Vector3 Motion
	{
		get
		{
			return _motion;
		}
		set
		{
			_motion = value;
		}
	}

	public Orientation Rotation
	{
		get
		{
			return _rotation;
		}
		set
		{
			_rotation = value;
		}
	}

	public double FallDistance
	{
		get
		{
			return _fallDistance;
		}
		set
		{
			_fallDistance = (float)value;
		}
	}

	public int Fire
	{
		get
		{
			return _fire;
		}
		set
		{
			_fire = (short)value;
		}
	}

	public int Air
	{
		get
		{
			return _air;
		}
		set
		{
			_air = (short)value;
		}
	}

	public bool IsOnGround
	{
		get
		{
			return _onGround == 1;
		}
		set
		{
			_onGround = (byte)(value ? 1u : 0u);
		}
	}

	public TagNodeCompound Source => _source;

	public static SchemaNodeCompound Schema => _schema;

	public Entity()
	{
		_pos = new Vector3();
		_motion = new Vector3();
		_rotation = new Orientation();
		_source = new TagNodeCompound();
	}

	protected Entity(Entity e)
	{
		_pos = new Vector3();
		_pos.X = e._pos.X;
		_pos.Y = e._pos.Y;
		_pos.Z = e._pos.Z;
		_motion = new Vector3();
		_motion.X = e._motion.X;
		_motion.Y = e._motion.Y;
		_motion.Z = e._motion.Z;
		_rotation = new Orientation();
		_rotation.Pitch = e._rotation.Pitch;
		_rotation.Yaw = e._rotation.Yaw;
		_fallDistance = e._fallDistance;
		_fire = e._fire;
		_air = e._air;
		_onGround = e._onGround;
		if (e._source != null)
		{
			_source = e._source.Copy() as TagNodeCompound;
		}
	}

	public virtual void MoveBy(int diffX, int diffY, int diffZ)
	{
		_pos.X += diffX;
		_pos.Y += diffY;
		_pos.Z += diffZ;
	}

	public Entity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound))
		{
			return null;
		}
		TagNodeList tagNodeList = tagNodeCompound["Pos"].ToTagList();
		_pos = new Vector3();
		_pos.X = tagNodeList[0].ToTagDouble();
		_pos.Y = tagNodeList[1].ToTagDouble();
		_pos.Z = tagNodeList[2].ToTagDouble();
		TagNodeList tagNodeList2 = tagNodeCompound["Motion"].ToTagList();
		_motion = new Vector3();
		_motion.X = tagNodeList2[0].ToTagDouble();
		_motion.Y = tagNodeList2[1].ToTagDouble();
		_motion.Z = tagNodeList2[2].ToTagDouble();
		TagNodeList tagNodeList3 = tagNodeCompound["Rotation"].ToTagList();
		_rotation = new Orientation();
		_rotation.Yaw = tagNodeList3[0].ToTagFloat();
		_rotation.Pitch = tagNodeList3[1].ToTagFloat();
		_fire = tagNodeCompound["Fire"].ToTagShort();
		_air = tagNodeCompound["Air"].ToTagShort();
		_onGround = tagNodeCompound["OnGround"].ToTagByte();
		_source = tagNodeCompound.Copy() as TagNodeCompound;
		return this;
	}

	public Entity LoadTreeSafe(TagNode tree)
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
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_DOUBLE);
		tagNodeList.Add(new TagNodeDouble(_pos.X));
		tagNodeList.Add(new TagNodeDouble(_pos.Y));
		tagNodeList.Add(new TagNodeDouble(_pos.Z));
		tagNodeCompound["Pos"] = tagNodeList;
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_DOUBLE);
		tagNodeList2.Add(new TagNodeDouble(_motion.X));
		tagNodeList2.Add(new TagNodeDouble(_motion.Y));
		tagNodeList2.Add(new TagNodeDouble(_motion.Z));
		tagNodeCompound["Motion"] = tagNodeList2;
		TagNodeList tagNodeList3 = new TagNodeList(TagType.TAG_FLOAT);
		tagNodeList3.Add(new TagNodeFloat((float)_rotation.Yaw));
		tagNodeList3.Add(new TagNodeFloat((float)_rotation.Pitch));
		tagNodeCompound["Rotation"] = tagNodeList3;
		tagNodeCompound["FallDistance"] = new TagNodeFloat(_fallDistance);
		tagNodeCompound["Fire"] = new TagNodeShort(_fire);
		tagNodeCompound["Air"] = new TagNodeShort(_air);
		tagNodeCompound["OnGround"] = new TagNodeByte(_onGround);
		tagNodeCompound["OnGround"] = new TagNodeByte(_onGround);
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

	public Entity Copy()
	{
		return new Entity(this);
	}
}
