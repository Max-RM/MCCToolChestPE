using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityMinecartTNT : EntityMinecart
{
	public static readonly SchemaNodeCompound MinecartTNTSchema = EntityMinecart.MinecartSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("TNTFuse", TagType.TAG_INT)
	});

	private int _tntFuse = -1;

	public new static string TypeId => "MinecartTNT";

	public int Fuel
	{
		get
		{
			return _tntFuse;
		}
		set
		{
			_tntFuse = value;
		}
	}

	protected EntityMinecartTNT(string id)
		: base(id)
	{
	}

	public EntityMinecartTNT()
	{
	}

	public EntityMinecartTNT(TypedEntity e)
		: base(e)
	{
		if (e is EntityMinecartTNT entityMinecartTNT)
		{
			_tntFuse = entityMinecartTNT._tntFuse;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_tntFuse = tagNodeCompound["TNTFuse"].ToTagInt();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["TNTFuse"] = new TagNodeInt(_tntFuse);
		tagNodeCompound["id"] = new TagNodeString(TypeId);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, MinecartTNTSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityMinecartTNT(this);
	}
}
