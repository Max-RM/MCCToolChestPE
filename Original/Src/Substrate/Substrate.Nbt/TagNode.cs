using System;
using Substrate.Core;

namespace Substrate.Nbt;

public abstract class TagNode : ICopyable<TagNode>
{
	public virtual TagNodeNull ToTagNull()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeByte ToTagByte()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeShort ToTagShort()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeInt ToTagInt()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeLong ToTagLong()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeFloat ToTagFloat()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeDouble ToTagDouble()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeByteArray ToTagByteArray()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeString ToTagString()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeList ToTagList()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeCompound ToTagCompound()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeIntArray ToTagIntArray()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeLongArray ToTagLongArray()
	{
		throw new InvalidCastException();
	}

	public virtual TagNodeShortArray ToTagShortArray()
	{
		throw new InvalidCastException();
	}

	public virtual TagType GetTagType()
	{
		return TagType.TAG_END;
	}

	public virtual bool IsCastableTo(TagType type)
	{
		return type == GetTagType();
	}

	public virtual TagNode Copy()
	{
		return null;
	}
}
