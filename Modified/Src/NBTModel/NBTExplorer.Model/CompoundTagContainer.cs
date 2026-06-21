using System.Collections.Generic;
using Substrate.Nbt;

namespace NBTExplorer.Model;

public class CompoundTagContainer : INamedTagContainer, ITagContainer
{
	private TagNodeCompound _tag;

	public int TagCount => _tag.Count;

	public IEnumerable<string> TagNamesInUse => _tag.Keys;

	public CompoundTagContainer(TagNodeCompound tag)
	{
		_tag = tag;
	}

	public string GetTagName(TagNode tag)
	{
		foreach (string key in _tag.Keys)
		{
			if (_tag[key] == tag)
			{
				return key;
			}
		}
		return null;
	}

	public TagNode GetTagNode(string name)
	{
		if (_tag.TryGetValue(name, out var value))
		{
			return value;
		}
		return null;
	}

	public bool AddTag(TagNode tag, string name)
	{
		if (_tag.ContainsKey(name))
		{
			return false;
		}
		_tag.Add(name, tag);
		return true;
	}

	public bool RenameTag(TagNode tag, string name)
	{
		if (_tag.ContainsKey(name))
		{
			return false;
		}
		string tagName = GetTagName(tag);
		_tag.Remove(tagName);
		_tag.Add(name, tag);
		return true;
	}

	public bool DeleteTag(TagNode tag)
	{
		foreach (string key in _tag.Keys)
		{
			if (_tag[key] == tag)
			{
				return _tag.Remove(key);
			}
		}
		return false;
	}

	public bool DeleteTag(string name)
	{
		if (!_tag.ContainsKey(name))
		{
			return false;
		}
		return DeleteTag(_tag[name]);
	}

	public bool ContainsTag(string name)
	{
		return _tag.ContainsKey(name);
	}
}
