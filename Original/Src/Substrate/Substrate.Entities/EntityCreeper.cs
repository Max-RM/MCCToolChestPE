using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityCreeper : EntityMob
{
	public static readonly SchemaNodeCompound CreeperSchema = EntityMob.MobSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("powered", TagType.TAG_BYTE, SchemaOptions.OPTIONAL)
	});

	private bool? _powered;

	public new static string TypeId => "Creeper";

	public bool Powered
	{
		get
		{
			return _powered ?? false;
		}
		set
		{
			_powered = value;
		}
	}

	protected EntityCreeper(string id)
		: base(id)
	{
	}

	public EntityCreeper()
		: this(TypeId)
	{
	}

	public EntityCreeper(TypedEntity e)
		: base(e)
	{
		if (e is EntityCreeper entityCreeper)
		{
			_powered = entityCreeper._powered;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		if (tagNodeCompound.ContainsKey("powered"))
		{
			_powered = (int)tagNodeCompound["powered"].ToTagByte() == 1;
		}
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		if (_powered.HasValue)
		{
			tagNodeCompound["powered"] = new TagNodeByte((byte)((_powered ?? false) ? 1u : 0u));
		}
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, CreeperSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityCreeper(this);
	}
}
