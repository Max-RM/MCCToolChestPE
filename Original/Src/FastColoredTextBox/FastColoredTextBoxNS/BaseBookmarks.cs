using System;
using System.Collections;
using System.Collections.Generic;

namespace FastColoredTextBoxNS;

public abstract class BaseBookmarks : ICollection<Bookmark>, IEnumerable<Bookmark>, IEnumerable, IDisposable
{
	public abstract int Count { get; }

	public abstract bool IsReadOnly { get; }

	public abstract void Add(Bookmark item);

	public abstract void Clear();

	public abstract bool Contains(Bookmark item);

	public abstract void CopyTo(Bookmark[] array, int arrayIndex);

	public abstract bool Remove(Bookmark item);

	public abstract IEnumerator<Bookmark> GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public abstract void Dispose();

	public abstract void Add(int lineIndex, string bookmarkName);

	public abstract void Add(int lineIndex);

	public abstract bool Contains(int lineIndex);

	public abstract bool Remove(int lineIndex);

	public abstract Bookmark GetBookmark(int i);
}
