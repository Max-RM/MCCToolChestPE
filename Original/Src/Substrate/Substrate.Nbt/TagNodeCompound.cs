using System;
using System.Collections;
using System.Collections.Generic;

namespace Substrate.Nbt;

public sealed class TagNodeCompound : TagNode, IDictionary<string, TagNode>, ICollection<KeyValuePair<string, TagNode>>, IEnumerable<KeyValuePair<string, TagNode>>, IEnumerable
{
	private Dictionary<string, TagNode> _tags;

	public int Count => _tags.Count;

	public ICollection<string> Keys => _tags.Keys;

	public ICollection<TagNode> Values => _tags.Values;

	public TagNode this[string key]
	{
		get
		{
			return _tags[key];
		}
		set
		{
			_tags[key] = value;
		}
	}

	public bool IsReadOnly => false;

	public override TagNodeCompound ToTagCompound()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_COMPOUND;
	}

	public TagNodeCompound()
	{
		_tags = new Dictionary<string, TagNode>();
	}

	public void MergeFrom(TagNodeCompound tree)
	{
		foreach (KeyValuePair<string, TagNode> item in tree)
		{
			if (!_tags.ContainsKey(item.Key))
			{
				_tags.Add(item.Key, item.Value);
			}
		}
	}

	public override TagNode Copy()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		foreach (KeyValuePair<string, TagNode> tag in _tags)
		{
			tagNodeCompound[tag.Key] = tag.Value.Copy();
		}
		return tagNodeCompound;
	}

	public override string ToString()
	{
		return _tags.ToString();
	}

	public void Add(string key, TagNode value)
	{
		_tags.Add(key, value);
	}

	public bool ContainsKey(string key)
	{
		return _tags.ContainsKey(key);
	}

	public bool Remove(string key)
	{
		return _tags.Remove(key);
	}

	public bool TryGetValue(string key, out TagNode value)
	{
		return _tags.TryGetValue(key, out value);
	}

	public void Add(KeyValuePair<string, TagNode> item)
	{
		_tags.Add(item.Key, item.Value);
	}

	public void Clear()
	{
		_tags.Clear();
	}

	public bool Contains(KeyValuePair<string, TagNode> item)
	{
		if (!_tags.TryGetValue(item.Key, out var value))
		{
			return false;
		}
		return value == item.Value;
	}

	public void CopyTo(KeyValuePair<string, TagNode>[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException();
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (array.Length - arrayIndex < _tags.Count)
		{
			throw new ArgumentException();
		}
		foreach (KeyValuePair<string, TagNode> tag in _tags)
		{
			array[arrayIndex] = tag;
			arrayIndex++;
		}
	}

	public bool Remove(KeyValuePair<string, TagNode> item)
	{
		if (Contains(item))
		{
			_tags.Remove(item.Key);
			return true;
		}
		return false;
	}

	public IEnumerator<KeyValuePair<string, TagNode>> GetEnumerator()
	{
		return _tags.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _tags.GetEnumerator();
	}
}
