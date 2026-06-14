using System;
using System.Collections;
using System.Collections.Generic;

namespace Substrate.Nbt;

public sealed class TagNodeList : TagNode, IList<TagNode>, ICollection<TagNode>, IEnumerable<TagNode>, IEnumerable
{
	private TagType _type;

	private List<TagNode> _items;

	public int Count => _items.Count;

	public TagType ValueType => _type;

	public TagNode this[int index]
	{
		get
		{
			return _items[index];
		}
		set
		{
			if (value.GetTagType() != _type)
			{
				throw new ArgumentException("The tag type of the assigned subnode is invalid for this node");
			}
			_items[index] = value;
		}
	}

	public bool IsReadOnly => false;

	public override TagNodeList ToTagList()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_LIST;
	}

	public TagNodeList(TagType type)
	{
		_type = type;
		_items = new List<TagNode>();
	}

	public TagNodeList(TagType type, List<TagNode> items)
	{
		_type = type;
		_items = items;
	}

	public override TagNode Copy()
	{
		TagNodeList tagNodeList = new TagNodeList(_type);
		foreach (TagNode item in _items)
		{
			tagNodeList.Add(item.Copy());
		}
		return tagNodeList;
	}

	public TagNode Find(Predicate<TagNode> match)
	{
		return _items.Find(match);
	}

	public List<TagNode> FindAll(Predicate<TagNode> match)
	{
		return _items.FindAll(match);
	}

	public int RemoveAll(Predicate<TagNode> match)
	{
		return _items.RemoveAll(match);
	}

	public void Reverse()
	{
		_items.Reverse();
	}

	public void Reverse(int index, int count)
	{
		_items.Reverse(index, count);
	}

	public void Sort()
	{
		_items.Sort();
	}

	public override string ToString()
	{
		return _items.ToString();
	}

	public void ChangeValueType(TagType type)
	{
		if (type != _type)
		{
			_items.Clear();
			_type = type;
		}
	}

	public int IndexOf(TagNode item)
	{
		return _items.IndexOf(item);
	}

	public void Insert(int index, TagNode item)
	{
		if (item.GetTagType() != _type)
		{
			throw new ArgumentException("The tag type of item is invalid for this node");
		}
		_items.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		_items.RemoveAt(index);
	}

	public void Add(TagNode item)
	{
		if (item.GetTagType() != _type)
		{
			throw new ArgumentException("The tag type of item is invalid for this node");
		}
		_items.Add(item);
	}

	public void Clear()
	{
		_items.Clear();
	}

	public bool Contains(TagNode item)
	{
		return _items.Contains(item);
	}

	public void CopyTo(TagNode[] array, int arrayIndex)
	{
		_items.CopyTo(array, arrayIndex);
	}

	public bool Remove(TagNode item)
	{
		return _items.Remove(item);
	}

	public IEnumerator<TagNode> GetEnumerator()
	{
		return _items.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _items.GetEnumerator();
	}
}
