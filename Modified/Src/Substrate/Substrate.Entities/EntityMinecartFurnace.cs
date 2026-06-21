using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityMinecartFurnace : EntityMinecart
{
	public static readonly SchemaNodeCompound MinecartFurnaceSchema = EntityMinecart.MinecartSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("PushX", TagType.TAG_DOUBLE),
		new SchemaNodeScaler("PushZ", TagType.TAG_DOUBLE),
		new SchemaNodeScaler("Fuel", TagType.TAG_SHORT)
	});

	private double _pushX;

	private double _pushZ;

	private short _fuel;

	public new static string TypeId => "MinecartFurnace";

	public double PushX
	{
		get
		{
			return _pushX;
		}
		set
		{
			_pushX = value;
		}
	}

	public double PushZ
	{
		get
		{
			return _pushZ;
		}
		set
		{
			_pushZ = value;
		}
	}

	public int Fuel
	{
		get
		{
			return _fuel;
		}
		set
		{
			_fuel = (short)value;
		}
	}

	protected EntityMinecartFurnace(string id)
		: base(id)
	{
	}

	public EntityMinecartFurnace()
	{
	}

	public EntityMinecartFurnace(TypedEntity e)
		: base(e)
	{
		if (e is EntityMinecartFurnace entityMinecartFurnace)
		{
			_pushX = entityMinecartFurnace._pushX;
			_pushZ = entityMinecartFurnace._pushZ;
			_fuel = entityMinecartFurnace._fuel;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_pushX = tagNodeCompound["PushX"].ToTagDouble();
		_pushZ = tagNodeCompound["PushZ"].ToTagDouble();
		_fuel = tagNodeCompound["Fuel"].ToTagShort();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["PushX"] = new TagNodeDouble(_pushX);
		tagNodeCompound["PushZ"] = new TagNodeDouble(_pushZ);
		tagNodeCompound["Fuel"] = new TagNodeShort(_fuel);
		tagNodeCompound["id"] = new TagNodeString(TypeId);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MinecartFurnaceSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityMinecartFurnace(this);
	}
}
