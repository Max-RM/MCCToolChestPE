using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityItem : TypedEntity
{
	public static readonly SchemaNodeCompound ItemSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Health", TagType.TAG_SHORT),
		new SchemaNodeScaler("Age", TagType.TAG_SHORT),
		new SchemaNodeCompound("Item", Item.Schema)
	});

	private short _health;

	private short _age;

	private Item _item;

	public static string TypeId => "Item";

	public int Health
	{
		get
		{
			return _health;
		}
		set
		{
			_health = (short)value;
		}
	}

	public int Age
	{
		get
		{
			return _age;
		}
		set
		{
			_age = (short)value;
		}
	}

	public Item Item
	{
		get
		{
			return _item;
		}
		set
		{
			_item = value;
		}
	}

	protected EntityItem(string id)
		: base(id)
	{
	}

	public EntityItem()
		: this(TypeId)
	{
	}

	public EntityItem(TypedEntity e)
		: base(e)
	{
		if (e is EntityItem entityItem)
		{
			_health = entityItem._health;
			_age = entityItem._age;
			_item = entityItem._item.Copy();
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_health = tagNodeCompound["Health"].ToTagShort();
		_age = tagNodeCompound["Age"].ToTagShort();
		_item = new Item().LoadTree(tagNodeCompound["Item"]);
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Health"] = new TagNodeShort(_health);
		tagNodeCompound["Age"] = new TagNodeShort(_age);
		tagNodeCompound["Item"] = _item.BuildTree();
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, ItemSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityItem(this);
	}
}
