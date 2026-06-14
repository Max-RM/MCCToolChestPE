using System;
using Substrate.Nbt;

namespace NBTExplorer.Model;

public class TagKey : IComparable<TagKey>
{
	public string Name { get; set; }

	public TagType TagType { get; set; }

	public TagKey(string name, TagType type)
	{
		Name = name;
		TagType = type;
	}

	public int Compare(TagKey x, TagKey y)
	{
		int num = x.TagType - y.TagType;
		if (num != 0)
		{
			return num;
		}
		return string.Compare(x.Name, y.Name, ignoreCase: false);
	}

	public int CompareTo(TagKey other)
	{
		return Compare(this, other);
	}
}
