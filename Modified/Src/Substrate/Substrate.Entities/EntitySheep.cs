using Substrate.Nbt;

namespace Substrate.Entities;

public class EntitySheep : EntityAnimal
{
	public static readonly SchemaNodeCompound SheepSchema = EntityAnimal.AnimalSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Sheared", TagType.TAG_BYTE),
		new SchemaNodeScaler("Color", TagType.TAG_BYTE, SchemaOptions.CREATE_ON_MISSING)
	});

	private bool _sheared;

	private byte _color;

	public new static string TypeId => "Sheep";

	public bool IsSheared
	{
		get
		{
			return _sheared;
		}
		set
		{
			_sheared = value;
		}
	}

	public int Color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = (byte)value;
		}
	}

	protected EntitySheep(string id)
		: base(id)
	{
	}

	public EntitySheep()
		: this(TypeId)
	{
	}

	public EntitySheep(TypedEntity e)
		: base(e)
	{
		if (e is EntitySheep entitySheep)
		{
			_sheared = entitySheep._sheared;
			_color = entitySheep._color;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_sheared = (int)tagNodeCompound["Sheared"].ToTagByte() == 1;
		_color = tagNodeCompound["Color"].ToTagByte();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Sheared"] = new TagNodeByte((byte)(_sheared ? 1u : 0u));
		tagNodeCompound["Color"] = new TagNodeByte(_color);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SheepSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntitySheep(this);
	}
}
