using System.Collections.Generic;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class Item : INbtObject<Item>, ICopyable<Item>
{
	private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("id", TagType.TAG_SHORT),
		new SchemaNodeScaler("Damage", TagType.TAG_SHORT),
		new SchemaNodeScaler("Count", TagType.TAG_BYTE),
		new SchemaNodeCompound("tag", new SchemaNodeCompound("")
		{
			new SchemaNodeList("ench", TagType.TAG_COMPOUND, Enchantment.Schema, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("title", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("author", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
			new SchemaNodeList("pages", TagType.TAG_STRING, SchemaOptions.OPTIONAL)
		}, SchemaOptions.OPTIONAL)
	};

	private TagNodeCompound _source;

	private short _id;

	private byte _count;

	private short _damage;

	private List<Enchantment> _enchantments;

	public ItemInfo Info => ItemInfo.ItemTable[_id];

	public int ID
	{
		get
		{
			return _id;
		}
		set
		{
			_id = (short)value;
		}
	}

	public int Damage
	{
		get
		{
			return _damage;
		}
		set
		{
			_damage = (short)value;
		}
	}

	public int Count
	{
		get
		{
			return _count;
		}
		set
		{
			_count = (byte)value;
		}
	}

	public IList<Enchantment> Enchantments => _enchantments;

	public TagNodeCompound Source => _source;

	public static SchemaNodeCompound Schema => _schema;

	public Item()
	{
		_enchantments = new List<Enchantment>();
		_source = new TagNodeCompound();
	}

	public Item(int id)
		: this()
	{
		_id = (short)id;
	}

	public Item Copy()
	{
		Item item = new Item();
		item._id = _id;
		item._count = _count;
		item._damage = _damage;
		foreach (Enchantment enchantment in _enchantments)
		{
			item._enchantments.Add(enchantment.Copy());
		}
		if (_source != null)
		{
			item._source = _source.Copy() as TagNodeCompound;
		}
		return item;
	}

	public Item LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound))
		{
			return null;
		}
		_enchantments.Clear();
		_id = tagNodeCompound["id"].ToTagShort();
		_count = tagNodeCompound["Count"].ToTagByte();
		_damage = tagNodeCompound["Damage"].ToTagShort();
		if (tagNodeCompound.ContainsKey("tag"))
		{
			TagNodeCompound tagNodeCompound2 = tagNodeCompound["tag"].ToTagCompound();
			if (tagNodeCompound2.ContainsKey("ench"))
			{
				TagNodeList tagNodeList = tagNodeCompound2["ench"].ToTagList();
				foreach (TagNode item in tagNodeList)
				{
					_enchantments.Add(new Enchantment().LoadTree(item));
				}
			}
		}
		_source = tagNodeCompound.Copy() as TagNodeCompound;
		return this;
	}

	public Item LoadTreeSafe(TagNode tree)
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
		tagNodeCompound["id"] = new TagNodeShort(_id);
		tagNodeCompound["Count"] = new TagNodeByte(_count);
		tagNodeCompound["Damage"] = new TagNodeShort(_damage);
		if (_enchantments.Count > 0)
		{
			TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
			foreach (Enchantment enchantment in _enchantments)
			{
				tagNodeList.Add(enchantment.BuildTree());
			}
			TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
			tagNodeCompound2["ench"] = tagNodeList;
			if (_source != null && _source.ContainsKey("tag"))
			{
				tagNodeCompound2.MergeFrom(_source["tag"].ToTagCompound());
			}
			tagNodeCompound["tag"] = tagNodeCompound2;
		}
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
}
