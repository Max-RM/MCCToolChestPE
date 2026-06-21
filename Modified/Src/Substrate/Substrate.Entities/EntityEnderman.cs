using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityEnderman : EntityMob
{
	public static readonly SchemaNodeCompound EndermanSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("carried", TagType.TAG_SHORT, SchemaOptions.CREATE_ON_MISSING),
		new SchemaNodeScaler("carriedData", TagType.TAG_SHORT, SchemaOptions.CREATE_ON_MISSING)
	});

	private short _carried;

	private short _carryingData;

	public new static string TypeId => "Enderman";

	public int Carried
	{
		get
		{
			return _carried;
		}
		set
		{
			_carried = (short)value;
		}
	}

	public int CarryingData
	{
		get
		{
			return _carryingData;
		}
		set
		{
			_carryingData = (short)value;
		}
	}

	protected EntityEnderman(string id)
		: base(id)
	{
	}

	public EntityEnderman()
		: this(TypeId)
	{
	}

	public EntityEnderman(TypedEntity e)
		: base(e)
	{
		if (e is EntityEnderman entityEnderman)
		{
			_carried = entityEnderman._carried;
			_carryingData = entityEnderman._carryingData;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_carried = tagNodeCompound["carried"].ToTagShort();
		_carryingData = tagNodeCompound["carriedData"].ToTagShort();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["carried"] = new TagNodeShort(_carried);
		tagNodeCompound["carriedData"] = new TagNodeShort(_carryingData);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, EndermanSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityEnderman(this);
	}
}
