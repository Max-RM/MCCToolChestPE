using System;
using System.Collections;
using System.Collections.Generic;

namespace Substrate.Nbt;

public sealed class SchemaNodeCompound : SchemaNode, ICollection<SchemaNode>, IEnumerable<SchemaNode>, IEnumerable
{
	private List<SchemaNode> _subnodes;

	public int Count => _subnodes.Count;

	public bool IsReadOnly => false;

	public void Add(SchemaNode item)
	{
		_subnodes.Add(item);
	}

	public void Clear()
	{
		_subnodes.Clear();
	}

	public bool Contains(SchemaNode item)
	{
		return _subnodes.Contains(item);
	}

	public void CopyTo(SchemaNode[] array, int arrayIndex)
	{
		_subnodes.CopyTo(array, arrayIndex);
	}

	public bool Remove(SchemaNode item)
	{
		return _subnodes.Remove(item);
	}

	public IEnumerator<SchemaNode> GetEnumerator()
	{
		return _subnodes.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _subnodes.GetEnumerator();
	}

	public SchemaNodeCompound()
		: base("")
	{
		_subnodes = new List<SchemaNode>();
	}

	public SchemaNodeCompound(SchemaOptions options)
		: base("", options)
	{
		_subnodes = new List<SchemaNode>();
	}

	public SchemaNodeCompound(string name)
		: base(name)
	{
		_subnodes = new List<SchemaNode>();
	}

	public SchemaNodeCompound(string name, SchemaOptions options)
		: base(name, options)
	{
		_subnodes = new List<SchemaNode>();
	}

	public SchemaNodeCompound(string name, SchemaNode subschema)
		: base(name)
	{
		_subnodes = new List<SchemaNode>();
		if (!(subschema is SchemaNodeCompound schemaNodeCompound))
		{
			return;
		}
		foreach (SchemaNode subnode in schemaNodeCompound._subnodes)
		{
			_subnodes.Add(subnode);
		}
	}

	public SchemaNodeCompound(string name, SchemaNode subschema, SchemaOptions options)
		: base(name, options)
	{
		_subnodes = new List<SchemaNode>();
		if (!(subschema is SchemaNodeCompound schemaNodeCompound))
		{
			return;
		}
		foreach (SchemaNode subnode in schemaNodeCompound._subnodes)
		{
			_subnodes.Add(subnode);
		}
	}

	public SchemaNodeCompound MergeInto(SchemaNodeCompound tree)
	{
		foreach (SchemaNode node in _subnodes)
		{
			List<SchemaNode> subnodes = tree._subnodes;
			Predicate<SchemaNode> match = (SchemaNode n) => n.Name == node.Name;
			if (subnodes.Find(match) == null)
			{
				tree.Add(node);
			}
		}
		return tree;
	}

	public override TagNode BuildDefaultTree()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		foreach (SchemaNode subnode in _subnodes)
		{
			tagNodeCompound[subnode.Name] = subnode.BuildDefaultTree();
		}
		return tagNodeCompound;
	}
}
