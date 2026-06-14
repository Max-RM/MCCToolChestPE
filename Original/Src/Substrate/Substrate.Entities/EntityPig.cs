using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityPig : EntityAnimal
{
	public static readonly SchemaNodeCompound PigSchema = EntityAnimal.AnimalSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Saddle", TagType.TAG_BYTE)
	});

	private bool _saddle;

	public new static string TypeId => "Pig";

	public bool HasSaddle
	{
		get
		{
			return _saddle;
		}
		set
		{
			_saddle = value;
		}
	}

	protected EntityPig(string id)
		: base(id)
	{
	}

	public EntityPig()
		: this(TypeId)
	{
	}

	public EntityPig(TypedEntity e)
		: base(e)
	{
		if (e is EntityPig entityPig)
		{
			_saddle = entityPig._saddle;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_saddle = (int)tagNodeCompound["Saddle"].ToTagByte() == 1;
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Saddle"] = new TagNodeByte((byte)(_saddle ? 1u : 0u));
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, PigSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityPig(this);
	}
}
