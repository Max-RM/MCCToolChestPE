using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityWolf : EntityAnimal
{
	public static readonly SchemaNodeCompound WolfSchema = EntityAnimal.AnimalSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Owner", TagType.TAG_STRING),
		new SchemaNodeScaler("Sitting", TagType.TAG_BYTE),
		new SchemaNodeScaler("Angry", TagType.TAG_BYTE)
	});

	private string _owner;

	private bool _sitting;

	private bool _angry;

	public new static string TypeId => "Wolf";

	public string Owner
	{
		get
		{
			return _owner;
		}
		set
		{
			_owner = value;
		}
	}

	public bool IsSitting
	{
		get
		{
			return _sitting;
		}
		set
		{
			_sitting = value;
		}
	}

	public bool IsAngry
	{
		get
		{
			return _angry;
		}
		set
		{
			_angry = value;
		}
	}

	protected EntityWolf(string id)
		: base(id)
	{
	}

	public EntityWolf()
		: this(TypeId)
	{
	}

	public EntityWolf(TypedEntity e)
		: base(e)
	{
		if (e is EntityWolf entityWolf)
		{
			_owner = entityWolf._owner;
			_sitting = entityWolf._sitting;
			_angry = entityWolf._angry;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_owner = tagNodeCompound["Owner"].ToTagString();
		_sitting = (int)tagNodeCompound["Sitting"].ToTagByte() == 1;
		_angry = (int)tagNodeCompound["Angry"].ToTagByte() == 1;
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Owner"] = new TagNodeString(_owner);
		tagNodeCompound["Sitting"] = new TagNodeByte((byte)(_sitting ? 1u : 0u));
		tagNodeCompound["Angry"] = new TagNodeByte((byte)(_angry ? 1u : 0u));
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, WolfSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityWolf(this);
	}
}
