using System.Collections.Generic;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class ItemCollection : INbtObject<ItemCollection>, ICopyable<ItemCollection>
{
	private static readonly SchemaNodeCompound _schema = Item.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("Slot", TagType.TAG_BYTE)
	});

	private static readonly SchemaNodeList _listSchema = new SchemaNodeList("", TagType.TAG_COMPOUND, _schema);

	private Dictionary<int, Item> _items;

	private int _capacity;

	public int Capacity => _capacity;

	public int Count => _items.Count;

	public Item this[int slot]
	{
		get
		{
			_items.TryGetValue(slot, out var value);
			return value;
		}
		set
		{
			if (slot >= 0 && slot < _capacity)
			{
				_items[slot] = value;
			}
		}
	}

	public static SchemaNodeCompound Schema => _schema;

	public ItemCollection(int capacity)
	{
		_capacity = capacity;
		_items = new Dictionary<int, Item>();
	}

	public bool ItemExists(int slot)
	{
		return _items.ContainsKey(slot);
	}

	public bool Clear(int slot)
	{
		return _items.Remove(slot);
	}

	public void ClearAllItems()
	{
		_items.Clear();
	}

	public ItemCollection Copy()
	{
		ItemCollection itemCollection = new ItemCollection(_capacity);
		foreach (KeyValuePair<int, Item> item in _items)
		{
			itemCollection[item.Key] = item.Value.Copy();
		}
		return itemCollection;
	}

	public ItemCollection LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeList tagNodeList))
		{
			return null;
		}
		foreach (TagNodeCompound item in tagNodeList)
		{
			int key = item["Slot"].ToTagByte();
			_items[key] = new Item().LoadTree(item);
		}
		return this;
	}

	public ItemCollection LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public TagNode BuildTree()
	{
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		foreach (KeyValuePair<int, Item> item in _items)
		{
			TagNodeCompound tagNodeCompound = item.Value.BuildTree() as TagNodeCompound;
			tagNodeCompound["Slot"] = new TagNodeByte((byte)item.Key);
			tagNodeList.Add(tagNodeCompound);
		}
		return tagNodeList;
	}

	public bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, _listSchema).Verify();
	}
}
