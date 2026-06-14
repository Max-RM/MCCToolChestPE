using System;
using System.Collections;
using System.Collections.Generic;
using Substrate.Nbt;

namespace Substrate;

public class EntityCollection : IEnumerable<TypedEntity>, IEnumerable
{
	private struct Enumerator : IEnumerator<TypedEntity>, IDisposable, IEnumerator
	{
		private IEnumerator<TagNode> _enum;

		private bool _next;

		private TypedEntity _cur;

		public TypedEntity Current
		{
			get
			{
				if (!_next)
				{
					throw new InvalidOperationException();
				}
				return _cur;
			}
		}

		object IEnumerator.Current => Current;

		internal Enumerator(TagNodeList entities)
		{
			_enum = entities.GetEnumerator();
			_cur = null;
			_next = false;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (!_enum.MoveNext())
			{
				_next = false;
				return false;
			}
			_cur = EntityFactory.Create(_enum.Current.ToTagCompound());
			if (_cur == null)
			{
				_cur = EntityFactory.CreateGeneric(_enum.Current.ToTagCompound());
			}
			_next = true;
			return true;
		}

		void IEnumerator.Reset()
		{
			_cur = null;
			_next = false;
			_enum.Reset();
		}
	}

	private TagNodeList _entities;

	private bool _dirty;

	public bool IsDirty
	{
		get
		{
			return _dirty;
		}
		set
		{
			_dirty = value;
		}
	}

	public EntityCollection(TagNodeList entities)
	{
		_entities = entities;
	}

	public List<TypedEntity> FindAll(string id)
	{
		List<TypedEntity> list = new List<TypedEntity>();
		foreach (TagNodeCompound entity in _entities)
		{
			if (entity.TryGetValue("id", out var value) && !(value.ToTagString().Data != id))
			{
				TypedEntity typedEntity = EntityFactory.Create(entity);
				if (typedEntity != null)
				{
					list.Add(typedEntity);
				}
			}
		}
		return list;
	}

	public List<TypedEntity> FindAll(Predicate<TypedEntity> match)
	{
		List<TypedEntity> list = new List<TypedEntity>();
		foreach (TagNodeCompound entity in _entities)
		{
			TypedEntity typedEntity = EntityFactory.Create(entity);
			if (typedEntity != null && match(typedEntity))
			{
				list.Add(typedEntity);
			}
		}
		return list;
	}

	public void Add(TypedEntity ent)
	{
		_entities.Add(ent.BuildTree());
		_dirty = true;
	}

	public int RemoveAll(string id)
	{
		int num = _entities.RemoveAll(delegate(TagNode val)
		{
			if (!(val is TagNodeCompound tagNodeCompound))
			{
				return false;
			}
			TagNode value;
			return tagNodeCompound.TryGetValue("id", out value) && value.ToTagString().Data == id;
		});
		if (num > 0)
		{
			_dirty = true;
		}
		return num;
	}

	public int RemoveAll(Predicate<TypedEntity> match)
	{
		int num = _entities.RemoveAll(delegate(TagNode val)
		{
			if (!(val is TagNodeCompound tree))
			{
				return false;
			}
			TypedEntity typedEntity = EntityFactory.Create(tree);
			return typedEntity != null && match(typedEntity);
		});
		if (num > 0)
		{
			_dirty = true;
		}
		return num;
	}

	public IEnumerator<TypedEntity> GetEnumerator()
	{
		return new Enumerator(_entities);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(_entities);
	}
}
