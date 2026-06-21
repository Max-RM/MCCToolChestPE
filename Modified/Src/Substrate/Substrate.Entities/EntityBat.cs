using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityBat : EntityMob
{
	public static readonly SchemaNodeCompound BatSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("batFlags", TagType.TAG_BYTE, SchemaOptions.OPTIONAL)
	});

	private bool? _batFlags;

	public new static string TypeId => "Bat";

	public bool BatFlags
	{
		get
		{
			return _batFlags ?? false;
		}
		set
		{
			_batFlags = value;
		}
	}

	protected EntityBat(string id)
		: base(id)
	{
	}

	public EntityBat()
		: this(TypeId)
	{
	}

	public EntityBat(TypedEntity e)
		: base(e)
	{
		if (e is EntityBat entityBat)
		{
			_batFlags = entityBat._batFlags;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		if (tagNodeCompound.ContainsKey("batFlags"))
		{
			_batFlags = (int)tagNodeCompound["batFlags"].ToTagByte() == 1;
		}
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		if (_batFlags.HasValue)
		{
			tagNodeCompound["batFlags"] = new TagNodeByte((byte)((_batFlags ?? false) ? 1u : 0u));
		}
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, BatSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityBat(this);
	}
}
